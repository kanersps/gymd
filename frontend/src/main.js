import { createApp } from 'vue'
import App from './App.vue'
import router from "@/router";
import './index.css';
import AppStore from "@/store/AppStore";

const _App = createApp(App);

_App.use(router);
_App.use(AppStore);

_App.mount('#app')
