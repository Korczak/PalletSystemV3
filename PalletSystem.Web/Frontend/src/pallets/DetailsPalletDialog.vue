<template>
	<v-dialog v-model="dialog" persistent max-width="600px">
		<v-card>
			<v-container>
				<v-row>
					<v-col>
						<v-row>
							<span class="headline black--text">{{
								translation.PalletInformation
							}}</span>
						</v-row>
						<v-row>
							<v-col cols="6">RFID</v-col>
							<v-col cols="6">{{ palletInformation.rfid }}</v-col>
						</v-row>
						<div v-if="isProgramAvailable">
							<v-row>
								<v-col cols="6">{{
									translation.ProgramName
								}}</v-col>
								<v-col cols="6">{{
									palletInformation.programName
								}}</v-col>
							</v-row>
							<v-row>
								<v-col>
									<span
										>{{ translation.ProgramProgress }}
										{{
											palletDetails.virtualPalletProgram
												.stepsDone
										}}/{{
											palletDetails.virtualPalletProgram
												.stepsTotal
										}}</span
									>

									<v-progress-linear
										:color="getProgressColor"
										buffer-value="0"
										:value="getStepValue"
										stream
									></v-progress-linear>
								</v-col>
							</v-row>
							<v-data-table
								class="mt-5"
								v-if="isProgramAvailable"
								:items="
									palletDetails.virtualPalletProgram.steps
								"
								item-key="step"
								:headers="headers"
								hide-default-footer
							>
								<template v-slot:item.step="{ item }">
									{{ item.step }}
								</template>
								<template v-slot:item.operationMask="{ item }">
									{{ item.operationMask }}
								</template>
								<template v-slot:item.workspaceSlot="{ item }">
									{{ item.workspaceSlot }}
								</template>
								<template v-slot:item.results="{ item }">
									{{ getProgramsResults(item.results) }}
								</template>
							</v-data-table>
						</div>
					</v-col>
				</v-row>
				<v-card-actions>
					<discard-btn @click="closeDialog"></discard-btn>
				</v-card-actions>
			</v-container>
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
	PalletInformation,
	VirtualPalletDetails,
	VirtualPalletStatus,
	VirtualPalletProgramStepResult
} from "../api-clients/ClientsGenerated";

@Component({ components: {} })
export default class DetailsPalletDialog extends Mixins(Translation) {
	@Inject() readonly palletClient!: PalletsClient;
	@Prop() readonly palletInformation!: PalletInformation;

	palletDetails: VirtualPalletDetails | null = null;
	dialog = true;

	async mounted() {
		this.palletDetails = await this.palletClient.getVirtualPalletDetails(
			this.palletInformation.virtualPalletId!
		);
	}

	get isProgramAvailable(): boolean {
		if (!this.palletDetails) return false;
		return this.palletDetails.palletStatus != VirtualPalletStatus.Ready;
	}
	get headers() {
		return [
			{ text: this.translation.Step, value: "step" },
			{ text: this.translation.OperationMask, value: "operationMask" },
			{ text: this.translation.WorkspaceSlot, value: "workspaceSlot" },
			{ text: this.translation.Results, value: "results" }
		];
	}

	getProgramsResults(results: VirtualPalletProgramStepResult[] | null) {
		if (!results) return "";
		let resultString: string = "";
		results.map(
			r =>
				(resultString +=
					r.index + ": (" + r.value + ";" + r.status + "), ")
		);
		return resultString;
	}

	closeDialog() {
		this.$emit("onClose");
	}

	get getStepValue() {
		if (!this.palletDetails) return 0;
		if (!this.palletDetails.virtualPalletProgram) return 0;
		return (
			(this.palletDetails.virtualPalletProgram.stepsDone /
				this.palletDetails.virtualPalletProgram.stepsTotal) *
			100
		);
	}

	get getProgressColor() {
		if (!this.palletDetails) return "red";
		if (this.palletDetails.palletStatus == VirtualPalletStatus.Error)
			return "error";
		return "success";
	}
}
</script>
<style></style>
