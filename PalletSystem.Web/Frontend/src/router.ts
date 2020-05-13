import Vue from "vue";
import Router, { Route } from "vue-router";
import Home from "@/home/Home.vue";
import LoginMain from "@/login/LoginMain.vue";
import PalletMain from "@/pallets/PalletMain.vue";
import ProgramMain from "@/programs/ProgramMain.vue";

Vue.use(Router);

export default new Router({
	mode: "history",
	scrollBehavior(to, from, savedPosition) {
		return { x: 0, y: 0 };
	},
	base: process.env.BASE_URL,
	routes: [
		{
			path: "/",
			component: Home,
			name: "Home"
		},
		{
			path: "/pallets",
			component: PalletMain,
			name: "PalletList"
		},
		{
			path: "/programs",
			component: ProgramMain,
			name: "ProgramList"
		},
		{
			path: "/login",
			component: LoginMain,
			name: "Login"
		}
	]
});
