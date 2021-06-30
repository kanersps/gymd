import {
    createRouter,
    createWebHistory
} from "vue-router";
import Home from "@/main/home/Home.vue";
import Account from "@/main/account/Account";
import Register from "@/main/home/Register";
import Login from "@/main/home/Login";
import Dashboard from "@/main/account/Dashboard/Dashboard";
import DashboardExercises from "@/main/account/Dashboard/DashboardExercises";
import DashboardOverview from "@/main/account/Dashboard/DashboardOverview";
import Friends from "@/main/account/Friends/Friends";
import Exercises from "@/main/account/Exercises/Exercises";
import Achievements from "@/main/account/Achievements/Achievements";

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
            component: Dashboard,
            children: [{
                path: "",
                component: DashboardOverview
            }, {
                path: "exercises",
                component: DashboardExercises
            }]
        }, {
            path: "exercises",
            component: Exercises
        }, {
            path: "friends",
            component: Friends
        }, {
            path: "achievements",
            component: Achievements
        }]
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes
});

export default router;