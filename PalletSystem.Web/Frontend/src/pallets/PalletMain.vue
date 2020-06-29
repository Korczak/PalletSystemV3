<template>
	<v-container fluid align-center justify-center class="py-11 px-11">
		<v-row>
			<v-container class="px-9">
				<v-row justify="center">
					<v-col cols="3"></v-col>
					<v-col cols="6">
						<v-text-field
							outlined
							rounded
							clearable
							append-icon="search"
							v-model="searchText"
						></v-text-field>
					</v-col>
					<v-col cols="1"></v-col>
					<v-col cols="2" justify-self="end">
						<v-layout class="actions" justify-end>
							<add-pallet-dialog
								@onAdded="loadData"
							></add-pallet-dialog>
						</v-layout>
					</v-col>
				</v-row>
			</v-container>
			<v-container class="py-0 px-9" fluid>
				<div>
					<v-row over>
						<pallet-item
							v-for="item in pallets"
							:key="item.id"
							:pallet="item"
						></pallet-item>
					</v-row>
				</div>
			</v-container>
		</v-row>
	</v-container>
</template>

<script lang="ts">
import { Component, Mixins, Inject } from "vue-property-decorator";
import Translation from "@/language/translation";
import {
	SelfClient,
	UserLoginResponse,
	UserLoginRequest,
	UserLoginResult,
	PalletsClient,
	PalletInformation,
	PalletStatus
} from "../api-clients/ClientsGenerated";
import { globalStore } from "@/main";
import moment from "moment";
import AddPalletDialog from "./AddPalletDialog.vue";
import PalletItem from "./PalletItem.vue";
import {
	PalletStatusHubClient,
	VirtualPalletStatusHubClient
} from "@/api-clients/hubClients";

@Component({ components: { AddPalletDialog, PalletItem } })
export default class PalletMain extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;
	@Inject() readonly updatePalletStatusHubClient!: PalletStatusHubClient;
	@Inject()
	readonly updateVirtualPalletStatusHubClient!: VirtualPalletStatusHubClient;

	searchText = "";

	moment = moment;

	pallets: PalletInformation[] = [];

	destroyed() {
		this.updatePalletStatusHubClient.StopConnections();
		this.updateVirtualPalletStatusHubClient.StopConnections();
	}
	created() {
		this.updatePalletStatusHubClient.OnUpdateStatus(this.loadData);
		this.updateVirtualPalletStatusHubClient.OnUpdateStatus(this.loadData);
	}

	async mounted() {
		await this.loadData();
	}

	async loadData() {
		this.pallets = await this.palletClient.getPallets();
	}

	get headers() {
		return [
			{ text: "RFID", value: "rfid" },
			{ text: this.translation.Program, value: "program" },
			{ text: this.translation.Steps, value: "steps" },
			{ text: this.translation.Status, value: "status" },
			{
				text: this.translation.Details,
				sortable: false,
				value: "actions"
			}
		];
	}
}
</script>

<style>
.dataTable th {
	border: 1px solid #90caf9;
	background-color: #e3f2fd;
}

.dataTable td {
	border-left: 1px solid #90caf9;
	border-right: 1px solid #90caf9;
	border-bottom: 1px solid #90caf9;
}
</style>
