import {
    createRouter,
    createWebHistory
} from "vue-router";
import Home from "@/main/home/Home.vue";
import Account from "@/main/account/Account";
import Register from "@/main/home/Register";
import Login from "@/main/home/Login";
import Dashboard from "@/main/account/Dashboard/Dashboard";

const routes = [{
        path: "/",
        name: "Home",
        component: Home
    }, {
        path: "/register",
        component: Register
    },
    {
        path: "/login",
        component: Login
    },
    {
        path: "/account",
        name: "Account",
        component: Account,
        children: [{
            path: "dashboard",
            component: Dashboard
        }]
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;