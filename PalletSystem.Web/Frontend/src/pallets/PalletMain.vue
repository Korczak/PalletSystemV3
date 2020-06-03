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

					<!-- <v-data-table
						class="dataTable"
						:headers="headers"
						:items="pallets"
						hide-default-footer
						show-select
					>
						<template v-slot:item.rfid="{ item }">
							{{ item.rfid }}
						</template>
						<template v-slot:item.program="{ item }">
							{{ item.programName }}
						</template>
						<template v-slot:item.steps="{ item }">
							<span>
								{{ item.stepsDone }} / {{ item.stepsTotal }}
							</span>
						</template>
						<template v-slot:item.status="{ item }">
							<span>
								{{ item.palletStatus }}
							</span>
						</template>
						<template v-slot:item.actions="{ item }">
							<run-pallet-dialog
								v-if="isPalletReady(item.palletStatus)"
								@onAdded="loadData"
								:palletRFID="item.rfid"
								:palletId="item.id"
							>
							</run-pallet-dialog>
							<v-btn v-else width="35" height="35" icon>
								<v-icon x-large color="#90caf9">forward</v-icon>
							</v-btn>
						</template>
					</v-data-table> -->
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

@Component({ components: { AddPalletDialog, PalletItem } })
export default class PalletMain extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;

	searchText = "";

	moment = moment;

	pallets: PalletInformation[] = [];

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
