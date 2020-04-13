﻿using MQTTnet;
using MQTTnet.Protocol;
using MQTTnet.Server;
using Serilog;
using System.Text;
using System.Threading.Tasks;
using Thaumatec.Core.Configuration;

namespace Thaumatec.MqttServer
{
    public class MqttServerService
    {
        private readonly IMqttServer _mqttServer;
        private readonly IMqttServerOptions _options;
        private static ILogger _logger;


        public MqttServerService(Config config, ILogger logger)
        {
            _logger = logger;
            var optionsBuilder = new MqttServerOptionsBuilder()
             .WithDefaultEndpoint().WithDefaultEndpointPort(config.BrokerSettings.Port).WithConnectionValidator(
                 c =>
                 {
                     var currentUser = config.ClientSettings;

                     if (currentUser == null)
                     {
                         c.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                         LogMessage(c, true);
                         return;
                     }

                     if (c.Username != currentUser.UserName)
                     {
                         c.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                         LogMessage(c, true);
                         return;
                     }

                     if (c.Password != currentUser.Password)
                     {
                         c.ReasonCode = MqttConnectReasonCode.BadUserNameOrPassword;
                         LogMessage(c, true);
                         return;
                     }

                     c.ReasonCode = MqttConnectReasonCode.Success;
                     LogMessage(c, false);
                 }).WithSubscriptionInterceptor(
                 c =>
                 {
                     c.AcceptSubscription = true;
                     LogMessage(c, true);
                 }).WithApplicationMessageInterceptor(
                 c =>
                 {
                     c.AcceptPublish = true;
                     LogMessage(c);
                 });

            _mqttServer = new MqttFactory().CreateMqttServer();
            _options = optionsBuilder.Build();
        }


        /// <summary> 
        ///     Logs the message from the MQTT subscription interceptor context. 
        /// </summary> 
        /// <param name="context">The MQTT subscription interceptor context.</param> 
        /// <param name="successful">A <see cref="bool"/> value indicating whether the subscription was successful or not.</param> 
        private static void LogMessage(MqttSubscriptionInterceptorContext context, bool successful)
        {
            if (context == null)
            {
                return;
            }

            _logger.Information(successful ? $"New subscription: ClientId = {context.ClientId}, TopicFilter = {context.TopicFilter}" : $"Subscription failed for clientId = {context.ClientId}, TopicFilter = {context.TopicFilter}");
        }

        /// <summary>
        ///     Logs the message from the MQTT message interceptor context.
        /// </summary>
        /// <param name="context">The MQTT message interceptor context.</param>
        private static void LogMessage(MqttApplicationMessageInterceptorContext context)
        {
            if (context == null)
            {
                return;
            }

            var payload = context.ApplicationMessage?.Payload == null ? null : Encoding.UTF8.GetString(context.ApplicationMessage?.Payload);

            _logger.Information(
                $"Message: ClientId = {context.ClientId}, Topic = {context.ApplicationMessage?.Topic},"
                + $" Payload = {payload}, QoS = {context.ApplicationMessage?.QualityOfServiceLevel},"
                + $" Retain-Flag = {context.ApplicationMessage?.Retain}");
        }

        /// <summary> 
        ///     Logs the message from the MQTT connection validation context. 
        /// </summary> 
        /// <param name="context">The MQTT connection validation context.</param> 
        /// <param name="showPassword">A <see cref="bool"/> value indicating whether the password is written to the log or not.</param> 
        private static void LogMessage(MqttConnectionValidatorContext context, bool showPassword)
        {
            if (context == null)
            {
                return;
            }

            if (showPassword)
            {
                _logger.Information(
                    $"New connection: ClientId = {context.ClientId}, Endpoint = {context.Endpoint},"
                    + $" Username = {context.Username}, Password = {context.Password},"
                    + $" CleanSession = {context.CleanSession}");
            }
            else
            {
                _logger.Information(
                    $"New connection: ClientId = {context.ClientId}, Endpoint = {context.Endpoint},"
                    + $" Username = {context.Username}, CleanSession = {context.CleanSession}");
            }
        }

        public void Start()
        {
            var serverStarting = Task.Run(() => _mqttServer.StartAsync(_options));
            serverStarting.GetAwaiter();
        }

        public void Stop()
        {
            var serverStopping = Task.Run(() => _mqttServer.StopAsync());
            serverStopping.GetAwaiter();
        }
    }
}
