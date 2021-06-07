import {createRouter, createWebHistory} from "vue-router";
import Home from "@/main/home/Home.vue";
import Account from "@/main/account/Account";
import Register from "@/main/account/Register";
import Login from "@/main/account/Login";

const routes = [
    {path: "/", name: "Home", component: Home},
    {
        path: "/account", name: "Account", component: Account,
        children: [
            {path: "register", component: Register},
            {path: "login", component: Login}
        ]
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;
