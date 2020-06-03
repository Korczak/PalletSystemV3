using System.IO;

namespace PalletSystem.ManagementTool.WebClientGeneration
{
    internal class WebClientGenerateSettings
    {
        public string NswagConfigPath { get; }
        public string NswqgConfigConnectorPath { get; }
        public string NswagConfigDir => Path.GetDirectoryName(NswagConfigPath);

        public WebClientGenerateSettings(Solution solution)
        {
            var solutionRoot = solution.SolutionRoot;
            NswagConfigPath = Path.Combine(solutionRoot, "PalletSystem.Web", "Frontend", "src", "api-clients", "api_generation_config.nswag");
            NswqgConfigConnectorPath = Path.Combine(solutionRoot, "PalletSystem.PLCConnector", "Client", "api_generation_config.nswag");
        }
    }
}
