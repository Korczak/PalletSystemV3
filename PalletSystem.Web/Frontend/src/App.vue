<template>
	<v-app>
		<v-app-bar app>
			<router-link :to="{ name: 'PalletList' }">
				<v-container>
					<v-img
						src="./assets/logo.svg"
						alt="Logo"
						width="60"
					></v-img>
				</v-container>
			</router-link>
			<v-tabs v-if="userData.validUser">
				<v-tab :to="{ name: 'PalletList' }">
					{{ translation.PalletList }}
				</v-tab>
				<v-tab :to="{ name: 'ProgramList' }">
					{{ translation.ProgramList }}
				</v-tab>
				<v-spacer></v-spacer>
				<v-layout align-center justify-end>
					<v-btn @click="logout" v-if="userData.validUser" icon>
						<v-icon>logout</v-icon>
					</v-btn>
				</v-layout>
			</v-tabs>
		</v-app-bar>
		<v-content v-if="loadComplete">
			<router-view v-if="userData.validUser" />
			<login-main v-else></login-main>
		</v-content>
	</v-app>
</template>

<script lang="ts">
import Vue from "vue";
import { Mixins, Component, Inject } from "vue-property-decorator";
import Translation from "./language/translation";
import { globalStore } from "@/main";
import userHasRole from "@/users/authorization";
import LoginMain from "@/login/LoginMain.vue";
import { SelfClient, UserLoginResult } from "./api-clients/ClientsGenerated";

@Component({ components: { LoginMain } })
export default class App extends Mixins(Translation) {
	@Inject() readonly selfClient!: SelfClient;

	userData = globalStore.userData;
	loadComplete = false;

	async created() {
		const result = await this.selfClient.getCurrentUser();
		this.loadComplete = true;
		if (result.result == UserLoginResult.Success) {
			this.userData.login(result);
		} else {
			this.userData.logout();
		}
	}

	async logout() {
		await this.selfClient.logout();
		this.userData.logout();
	}
}
</script>
