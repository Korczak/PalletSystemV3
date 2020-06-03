<template>
	<v-dialog v-model="dialog" persistent max-width="360px">
		<template v-slot:activator="{ on }">
			<v-btn icon v-on="on">
				<v-icon x-large color="#90caf9">settings</v-icon>
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
										translation.PalletSettings
									}}</span>
								</v-row>
								<v-row>
									<span>RFID: {{ palletRFID }}</span>
								</v-row>
								<v-row>
									<v-checkbox
										:label="translation.Disable"
										:value="isDisabled"
										on-icon="check_box"
										off-icon="check_box_outline_blank"
									>
									</v-checkbox>
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
	PalletsClient,
	PalletRunRequest,
	PalletRunResult,
	ProgramInformation,
	ProgramClient,
	IPalletRunRequest
} from "../api-clients/ClientsGenerated";
import SelectItem from "../common/SelectItem";

@Component({ components: {} })
export default class SettingsPalletDialog extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;
	@Prop() readonly palletRFID!: string;
	@Prop() readonly palletId!: string;

	dialog = false;
	valid = false;
	isDisabled = false;

	closeDialog() {
		this.dialog = false;
	}

	async saveData() {
		this.valid = (this.$refs.form as Vue & {
			validate: () => boolean;
		}).validate();
		if (!this.valid) return;
	}
}
</script>
<style></style>
