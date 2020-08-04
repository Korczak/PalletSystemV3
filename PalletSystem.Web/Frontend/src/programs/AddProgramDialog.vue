<template>
	<v-dialog v-model="dialog" persistent max-width="960px">
		<template v-slot:activator="{ on }" v-if="addNew">
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
							<v-col>
								<v-row>
									<span class="headline black--text">{{
										translation.AddProgram
									}}</span>
								</v-row>
								<v-row>
									<v-text-field
										:label="translation.ProgramName"
										v-model="programInput.name"
										required
										:rules="[
											v => !!v || translation.Required
										]"
									></v-text-field>
								</v-row>
								<v-row>
									<v-textarea
										:label="translation.Description"
										v-model="programInput.description"
										required
									></v-textarea>
								</v-row>
								<v-row>
									<span class="black--text">{{
										translation.StepsInstruction
									}}</span>
								</v-row>
								<v-row>
									<v-container fluid>
										<v-simple-table class="dataTable">
											<template v-slot:default>
												<thead>
													<tr>
														<th
															v-for="header in headers"
															:key="header.value"
															class="text-left"
														>
															{{ header.text }}
														</th>
													</tr>
												</thead>
												<tbody
													v-for="item in instructions"
													v-bind:key="item.step"
												>
													<tr>
														<td>
															{{ item.step }}
														</td>
														<td>
															<v-text-field
																:disabled="
																	!addNew
																"
																v-model="
																	item.machineMask
																"
																type="number"
																max="32"
																min="0"
																required
																:counter="32"
																:rules="[
																	v =>
																		!!v ||
																		translation.Required,
																	v =>
																		v <=
																			32 ||
																		translation.ValueExceed,
																	v =>
																		v > 0 ||
																		translation.ValueExceed
																]"
															></v-text-field>
														</td>
														<td>
															<v-text-field
																:disabled="
																	!addNew
																"
																v-model="
																	item.command
																"
																required
																:rules="[
																	v =>
																		!!v ||
																		translation.Required
																]"
															></v-text-field>
														</td>
														<td>
															<v-text-field
																:disabled="
																	!addNew
																"
																v-model="
																	item.parameters
																"
																required
																:rules="[
																	v =>
																		!!v ||
																		translation.Required
																]"
															></v-text-field>
														</td>
													</tr>
												</tbody>
											</template>
										</v-simple-table>
										<v-row
											justify="end"
											class="pr-3"
											v-if="addNew"
										>
											<v-btn
												:elevation="3"
												color="#00468b"
												height="40"
												width="40"
												@click="addStep()"
											>
												<v-icon color="#ffffff"
													>add</v-icon
												>
											</v-btn>
										</v-row>
									</v-container>
								</v-row>
							</v-col>
						</v-row>
						<v-card-actions>
							<discard-btn @click="closeDialog"></discard-btn>
							<v-spacer></v-spacer>
							<save-btn
								v-if="addNew"
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
import {
	Vue,
	Component,
	Mixins,
	Inject,
	Prop,
	Watch
} from "vue-property-decorator";
import Translation from "@/language/translation";
import {
	ProgramAddRequest,
	ProgramClient,
	ProgramInstruction,
	ProgramInformation,
	ProgramDetails
} from "../api-clients/ClientsGenerated";

@Component({ components: {} })
export default class AddPalletDialog extends Mixins(Translation) {
	@Inject() readonly programClient!: ProgramClient;
	@Prop() readonly addNew!: boolean;
	@Prop() readonly programId: string | undefined;

	programInput: ProgramAddRequest = new ProgramAddRequest();
	instructions: ProgramInstruction[] = [];
	stepsNum: number = 1;

	dialog = false;
	valid = false;
	errorMessage: string | null = null;

	async loadData() {
		const programDetails = await this.programClient.getProgramDetails(
			this.programId!
		);

		this.programInput.name = programDetails.programName;
		this.programInput.description = programDetails.programDescription;
		this.instructions = programDetails.instructions!.map(
			i =>
				new ProgramInstruction({
					step: i.numberOfStep,
					machineMask: i.operationMask,
					command: i.command,
					parameters: i.parameters
				})
		);
		debugger;
	}

	closeDialog() {
		this.stepsNum = 1;
		let instruction = new ProgramInstruction();
		instruction.step = this.stepsNum++;
		this.instructions = [instruction];
		this.dialog = false;
		this.$emit("onClose");
	}

	mounted() {
		let instruction = new ProgramInstruction();
		instruction.step = this.stepsNum++;
		this.instructions = [instruction];
		this.programInput.description = "";
		this.programInput.name = "";
		if (this.addNew == false) {
			this.dialog = true;
			this.loadData();
		}
	}

	async saveData() {
		this.valid = (this.$refs.form as Vue & {
			validate: () => boolean;
		}).validate();

		if (!this.valid) return;

		this.programInput.instructions = this.instructions;

		await this.programClient.addProgram(this.programInput);
		this.$emit("onAdded");
		this.closeDialog();
	}

	get headers() {
		return [
			{ text: this.translation.Step, value: "step" },
			{ text: this.translation.MachineMask, value: "machineMask" },
			{ text: this.translation.Command, value: "command" },
			{
				text: this.translation.Parameters,
				value: "parameters"
			}
		];
	}
	addStep() {
		var instruction = new ProgramInstruction();
		instruction.step = this.stepsNum++;
		this.$set(this.instructions!, this.instructions!.length, instruction);
	}
}
</script>
<style></style>
