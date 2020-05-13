<template>
	<v-dialog v-model="dialog" @input="loadData" persistent max-width="360px">
		<template v-slot:activator="{ on }">
			<v-btn
				class="oval-button"
				fab
				v-on="on"
				color="#2babe2"
				height="55"
				width="55"
			>
				<v-icon color="#ffffff">add</v-icon>
			</v-btn>
		</template>
		<v-card>
			<v-card-title></v-card-title>
			<v-card-text>
				<v-container>
					<v-form ref="form" v-model="valid" lazy-validation>
						<v-row>
							<v-col cols="12">
								<v-row>
									<span class="headline black--text">{{
										translation.AddPallet
									}}</span>
								</v-row>
								<v-row>
									<v-text-field
										label="RFID"
										v-model="programInput.rfid"
										required
										:error-messages="errorMessage"
										@change="errorMessage = null"
										:rules="[
											v =>
												!!v || this.translation.Required
										]"
									></v-text-field>
								</v-row>
							</v-col>
						</v-row>
						<v-card-actions>
							<discard-btn @click="closeDialog"></discard-btn>
							<v-spacer></v-spacer>
							<save-btn
								@click="saveData"
								:disabled="!valid"
								:text="this.translation.Save"
							>
							</save-btn>
						</v-card-actions>
					</v-form>
				</v-container>
			</v-card-text>
		</v-card>
	</v-dialog>
</template>

<script lang="ts">
import { Vue, Component, Mixins, Inject, Prop } from "vue-property-decorator";
import Translation from "@/language/translation";
import {
	PalletAddResult,
	PalletAddRequest,
	PalletsClient
} from "../api-clients/ClientsGenerated";

@Component({ components: {} })
export default class AddPalletDialog extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;

	programInput: PalletAddRequest = new PalletAddRequest();

	dialog = false;
	valid = false;
	errorMessage: string | null = null;
	loadData() {}
	closeDialog() {
		this.dialog = false;
	}

	async saveData() {
		this.valid = (this.$refs.form as Vue & {
			validate: () => boolean;
		}).validate();

		if (!this.valid) return;
		const result = await this.palletClient.addPallet(this.programInput);

		if (result == PalletAddResult.PalletAlreadyExists) {
			this.errorMessage = this.translation.PalletAlreadyExists;
		} else {
			this.closeDialog();
			this.$emit("onAdded");
			this.programInput = new PalletAddRequest();
		}
	}
}
</script>
<style></style>
