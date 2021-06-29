import {
    createRouter,
    createWebHistory
} from "vue-router";
import Home from "@/main/home/Home.vue";
import Account from "@/main/account/Account";
import Register from "@/main/account/Register";
import Login from "@/main/account/Login";
import Dashboard from "@/main/account/Dashboard";

const routes = [{
        path: "/",
        name: "Home",
        component: Home
    },
    {
        path: "/account",
        name: "Account",
        component: Account,
        children: [{
                path: "dashboard",
                component: Dashboard
            },
            {
                path: "register",
                component: Register
            },
            {
                path: "login",
                component: Login
            },
        ]
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;