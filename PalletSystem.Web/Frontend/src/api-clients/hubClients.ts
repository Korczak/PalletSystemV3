import * as signalR from "@microsoft/signalr";

export class DeviceConnectorPrintStatusUpdateHubClient {
	private connection: signalR.HubConnection;
	constructor() {
		this.connection = new signalR.HubConnectionBuilder()
			.withAutomaticReconnect()
			.withUrl("/printStatusUpdateHub")
			.build();
		if (this.connection.state === signalR.HubConnectionState.Disconnected) {
			this.connection.start();
		}
	}

	StopConnections() {
		this.connection.off("StatusUpdate");
	}

	OnUpdateConnection(updateMethod: () => any) {
		this.connection.on("StatusUpdate", updateMethod);
	}
}
