<template>
	<v-dialog v-model="dialog" @input="loadData" persistent max-width="360px">
		<template v-slot:activator="{ on }">
			<v-btn width="80" height="80" icon v-on="on">
				<v-icon style="font-size: 80px;" color="#90caf9"
					>play_circle_filled</v-icon
				>
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
										translation.AssignPalletToProgram
									}}</span>
								</v-row>
								<v-row>
									<span>RFID: {{ palletRFID }}</span>
								</v-row>
								<v-row>
									<v-autocomplete
										:label="translation.SelectProgram"
										v-model="selectedProgram"
										:items="programs"
										required
										:rules="[
											v =>
												!!v || this.translation.Required
										]"
									></v-autocomplete>
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
export default class RunPalletDialog extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;
	@Inject() readonly programClient!: ProgramClient;
	@Prop() readonly palletRFID!: string;
	@Prop() readonly palletId!: string;

	dialog = false;
	valid = false;
	errorMessage: string | null = null;
	programs: SelectItem[] = [];
	selectedProgram: string | null = null;

	async mounted() {
		await this.loadData();
	}

	async loadData() {
		const programs = await this.programClient.getPrograms();

		this.programs = programs.map(
			x => new SelectItem(x.programName!, x.programId!)
		);
	}

	closeDialog() {
		this.dialog = false;
	}

	async saveData() {
		this.valid = (this.$refs.form as Vue & {
			validate: () => boolean;
		}).validate();
		if (!this.valid) return;

		let request: IPalletRunRequest = {
			palletId: this.palletId!,
			programId: this.selectedProgram!
		};
		let requestToSend = new PalletRunRequest(request);
		console.log(requestToSend);
		const result = await this.palletClient.runPallet(requestToSend);
		console.log(result);
		if (result == PalletRunResult.PalletRun) {
			this.closeDialog();
			this.$emit("onAdded");
			this.selectedProgram = null;
		} else {
			this.errorMessage = this.translation.RunError;
		}
	}
}
</script>
<style></style>
