<template>
	<v-col cols="4" class="listStyle">
		<v-container>
			<v-card class="mx-auto" elevation="6">
				<v-row :class="getPalletClass" class="ma-0">
					<v-col cols="10" class="py-0">
						<v-list-item two-line>
							<v-list-item-content>
								<v-list-item-title class="headline">{{
									pallet.rfid
								}}</v-list-item-title>
								<v-list-item-subtitle>{{
									palletStatus
								}}</v-list-item-subtitle>
							</v-list-item-content>
						</v-list-item>
					</v-col>
					<v-col cols="2" align-self="center"
						><settings-pallet-dialog
							:palletRFID="pallet.rfid"
						></settings-pallet-dialog
					></v-col>
				</v-row>
				<v-card-text>
					<v-row align="center" justify="center">
						<v-col cols="6" justify="center">
							<v-layout justify-center>
								<v-img
									src="../assets/pallet-icon.svg"
									alt="Sunny image"
									width="40"
								></v-img>
							</v-layout>
						</v-col>
						<v-col class="display-3" cols="6">
							<v-layout justify-center>
								<run-pallet-dialog
									v-if="isPalletReady"
									@onAdded="added()"
									:palletRFID="pallet.rfid"
									:palletId="pallet.id"
								></run-pallet-dialog>
								<v-btn
									v-if="isPalletDone"
									width="80"
									height="80"
									icon
									@click="resetPallet()"
								>
									<v-icon
										style="font-size: 80px;"
										color="#90caf9"
										>settings_backup_restore</v-icon
									>
								</v-btn>
							</v-layout>
						</v-col>
					</v-row>
				</v-card-text>

				<v-divider></v-divider>

				<v-card-actions>
					<v-btn
						@click="showReport = true"
						text
						v-if="!isPalletReady"
						>{{ translation.FullReport }}</v-btn
					>
				</v-card-actions>
			</v-card>
		</v-container>
		<details-pallet-dialog
			v-if="showReport"
			:palletInformation="pallet"
			@onClose="showReport = false"
		></details-pallet-dialog>
	</v-col>
</template>

<script lang="ts">
import { Component, Mixins, Inject, Prop } from "vue-property-decorator";
import Translation from "@/language/translation";
import {
	SelfClient,
	UserLoginResponse,
	UserLoginRequest,
	UserLoginResult,
	PalletsClient,
	PalletInformation,
	PalletStatus,
	VirtualPalletStatus,
	PalletFinishRequest,
	IPalletFinishRequest
} from "../api-clients/ClientsGenerated";
import { globalStore } from "@/main";
import moment from "moment";
import RunPalletDialog from "./RunPalletDialog.vue";
import SettingsPalletDialog from "./SettingsPalletDialog.vue";
import DetailsPalletDialog from "./DetailsPalletDialog.vue";

@Component({
	components: { SettingsPalletDialog, RunPalletDialog, DetailsPalletDialog }
})
export default class PalletItem extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;
	@Prop() readonly pallet!: PalletInformation;

	showReport = false;

	get getPalletClass(): string {
		if (this.pallet.palletStatus == PalletStatus.Running) {
			if (this.pallet.virtualPalletStatus == VirtualPalletStatus.Running)
				return "pallet-running";
			if (this.pallet.virtualPalletStatus == VirtualPalletStatus.Ready)
				return "pallet-ready";
			if (this.pallet.virtualPalletStatus == VirtualPalletStatus.Error)
				return "pallet-error";
			if (this.pallet.virtualPalletStatus == VirtualPalletStatus.Done)
				return "pallet-done";
		} else {
			if (this.pallet.palletStatus == PalletStatus.Error) {
				return "pallet-error";
			}
			if (this.pallet.palletStatus == PalletStatus.Ready) {
				return "pallet-waiting";
			}
		}
		return "";
	}

	get isPalletReady(): boolean {
		return this.pallet.palletStatus == PalletStatus.Ready;
	}

	get isPalletDone(): boolean {
		return (
			this.pallet.virtualPalletStatus == VirtualPalletStatus.Done ||
			this.pallet.virtualPalletStatus == VirtualPalletStatus.Error
		);
	}

	get palletStatus(): string {
		if (this.pallet.isVirtualPalletActive)
			return this.getTranslatedValue(this.pallet.virtualPalletStatus);
		return this.getTranslatedValue(this.pallet.palletStatus);
	}

	added() {
		this.$emit("onAdded");
	}

	async resetPallet() {
		let request: IPalletFinishRequest = {
			palletId: this.pallet.id,
			rfid: this.pallet.rfid
		};

		let requestToSend = new PalletFinishRequest(request);
		await this.palletClient.finishPallet(requestToSend);
		this.pallet.virtualPalletStatus = VirtualPalletStatus.Ready;
		this.pallet.palletStatus = PalletStatus.Ready;
	}
}
</script>

<style scoped>
.pallet-running,
.pallet-ready {
	background-color: #98ae5b;
}

.pallet-done {
	background-color: green;
}

.pallet-ready {
	background-color: #e8b072;
}

.pallet-error {
	background-color: #84254a;
}
</style>
