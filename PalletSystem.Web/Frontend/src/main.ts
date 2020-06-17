import Vue from "vue";
import App from "./App.vue";
import "material-design-icons-iconfont/dist/material-design-icons.css";
import vuetify from "./plugins/vuetify";
import router from "@/router";
import UserData from "@/users/user-data";

import {
	SelfClient,
	UsersClient,
	PalletsClient,
	ProgramClient
} from "./api-clients/ClientsGenerated";
import { DeviceConnectorPrintStatusUpdateHubClient } from "./api-clients/hubClients";

import SaveButton from "@/components/SaveButton.vue";
import DiscardButton from "@/components/DiscardButton.vue";

Vue.component("save-btn", SaveButton);
Vue.component("discard-btn", DiscardButton);

Vue.config.productionTip = false;

export const globalStore = new Vue({
	data: {
		userData: new UserData()
	}
});

new Vue({
	vuetify,
	router,
	render: h => h(App),
	provide: {
		selfClient: new SelfClient(),
		usersClient: new UsersClient(),
		palletClient: new PalletsClient(),
		programClient: new ProgramClient(),
		updateConnectionHubClient: new DeviceConnectorPrintStatusUpdateHubClient()
	}
}).$mount("#app");
