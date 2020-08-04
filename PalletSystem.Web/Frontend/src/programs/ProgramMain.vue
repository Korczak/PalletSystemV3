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
							<add-program-dialog
								@onAdded="loadData"
								:addNew="true"
							></add-program-dialog>
						</v-layout>
					</v-col>
				</v-row>
			</v-container>
			<v-container class="py-0 px-9" fluid>
				<div>
					<v-data-table
						class="dataTable"
						:headers="headers"
						:items="programs"
						hide-default-footer
						show-select
					>
						<template v-slot:item.program="{ item }">
							{{ item.programName }}
						</template>
						<template v-slot:item.description="{ item }">
							{{ item.programDescription }}
						</template>
						<template v-slot:item.steps="{ item }">
							<span>
								{{ item.numberOfProgramSteps }}
							</span>
						</template>
						<template v-slot:item.actions="{ item }">
							<v-btn
								width="35"
								height="35"
								icon
								@click="showDetails(item.programId)"
							>
								<v-icon x-large color="#90caf9">forward</v-icon>
							</v-btn>
						</template>
					</v-data-table>
				</div>
			</v-container>
		</v-row>
		<add-program-dialog
			v-if="showProgramDetails"
			@onAdded="loadData"
			:addNew="false"
			:programId="programId"
			@onClose="showProgramDetails = false"
		></add-program-dialog>
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
	PalletInformation,
	ProgramInformation,
	ProgramClient
} from "../api-clients/ClientsGenerated";
import { globalStore } from "@/main";
import moment from "moment";
import AddProgramDialog from "./AddProgramDialog.vue";

@Component({ components: { AddProgramDialog } })
export default class ProgramMain extends Mixins(Translation) {
	@Inject() readonly programClient!: ProgramClient;

	searchText = "";

	moment = moment;

	programs: ProgramInformation[] = [];

	showProgramDetails = false;
	programId: number | undefined;

	async mounted() {
		await this.loadData();
	}

	async loadData() {
		const response = await this.programClient.getPrograms();
		this.programs = response;
	}

	showDetails(programId: number) {
		this.showProgramDetails = true;
		this.programId = programId;
	}

	get headers() {
		return [
			{ text: this.translation.Program, value: "program" },
			{ text: this.translation.Description, value: "description" },
			{ text: this.translation.StepsToDo, value: "steps" },
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
