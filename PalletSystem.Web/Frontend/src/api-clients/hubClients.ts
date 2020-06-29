import * as signalR from "@microsoft/signalr";

export class PalletStatusHubClient {
	private connection: signalR.HubConnection;
	constructor() {
		this.connection = new signalR.HubConnectionBuilder()
			.withAutomaticReconnect()
			.withUrl("/palletStatusUpdateHub")
			.build();
		if (this.connection.state === signalR.HubConnectionState.Disconnected) {
			this.connection.start();
		}
	}

	StopConnections() {
		this.connection.off("ActualStatusUpdate");
	}

	OnUpdateStatus(updateMethod: () => any) {
		this.connection.on("ActualStatusUpdate", updateMethod);
	}
}

export class VirtualPalletStatusHubClient {
	private connection: signalR.HubConnection;
	constructor() {
		this.connection = new signalR.HubConnectionBuilder()
			.withAutomaticReconnect()
			.withUrl("/virtualPalletStatusUpdateHub")
			.build();
		if (this.connection.state === signalR.HubConnectionState.Disconnected) {
			this.connection.start();
		}
	}

	StopConnections() {
		this.connection.off("ActualVirtualStatusUpdate");
	}

	OnUpdateStatus(updateMethod: () => any) {
		this.connection.on("ActualVirtualStatusUpdate", updateMethod);
	}
}
