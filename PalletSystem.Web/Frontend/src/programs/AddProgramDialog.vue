<template>
	<v-dialog v-model="dialog" @input="loadData" persistent max-width="960px">
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
										:rules="[
											v => !!v || translation.Required
										]"
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
													<tr>
														<th class="text-left">
															Parameter 1
														</th>
														<th class="text-left">
															Parameter 2
														</th>
														<th class="text-left">
															Parameter 3
														</th>
														<th class="text-left">
															Parameter 4
														</th>
														<th class="text-left">
															Parameter 5
														</th>
													</tr>
												</thead>
												<tbody
													v-for="item in steps"
													:key="item.step"
												>
													<tr>
														<td>
															{{ item.step }}
														</td>
														<td>
															<v-text-field
																v-model="
																	item.machineMask
																"
																type="number"
																max="5"
																min="0"
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
																v-model="
																	item.workspaceSlot
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
													<tr>
														<td>
															<v-text-field
																v-model="
																	item.parameter1
																"
															></v-text-field>
														</td>
														<td>
															<v-text-field
																v-model="
																	item.parameter2
																"
															></v-text-field>
														</td>
														<td>
															<v-text-field
																v-model="
																	item.parameter3
																"
															></v-text-field>
														</td>
														<td>
															<v-text-field
																v-model="
																	item.parameter4
																"
															></v-text-field>
														</td>
														<td>
															<v-text-field
																v-model="
																	item.parameter5
																"
															></v-text-field>
														</td>
													</tr>
												</tbody>
												<!-- 
												<template
													v-slot:item.parameter="{
														item
													}"
												>
													<v-text-field
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
												</template>
												<template
													v-slot:item.workspaceSlot="{
														item
													}"
												>
													<v-text-field
														v-model="
															item.workspaceSlot
														"
														required
														:rules="[
															v =>
																!!v ||
																translation.Required
														]"
													></v-text-field>
												</template> -->
											</template>
										</v-simple-table>
										<v-row justify="end" class="pr-3">
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
	ProgramAddRequest,
	ProgramClient,
	ProgramInstruction,
	ProgramInformation
} from "../api-clients/ClientsGenerated";

@Component({ components: {} })
export default class AddPalletDialog extends Mixins(Translation) {
	@Inject() readonly programClient!: ProgramClient;

	programInput: ProgramAddRequest = new ProgramAddRequest();
	steps: ProgramInstruction[] = [];
	stepsNum: number = 1;

	dialog = false;
	valid = false;
	errorMessage: string | null = null;
	loadData() {}
	closeDialog() {
		this.stepsNum = 1;
		let instruction = new ProgramInstruction();
		instruction.step = this.stepsNum++;
		this.steps = [instruction];
		this.dialog = false;
	}

	mounted() {
		let instruction = new ProgramInstruction();
		instruction.step = this.stepsNum++;
		this.steps = [instruction];
	}

	async saveData() {
		this.valid = (this.$refs.form as Vue & {
			validate: () => boolean;
		}).validate();

		if (!this.valid) return;

		const request = this.programInput;
		request.instructions = this.steps;

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
				text: this.translation.WorkspaceSlot,
				sortable: false,
				value: "workspaceSlot"
			}
		];
	}
	addStep() {
		var instruction = new ProgramInstruction();
		instruction.step = this.stepsNum++;
		this.steps.push(instruction);
	}
}
</script>
<style></style>
