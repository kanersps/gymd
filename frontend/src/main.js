import { createApp } from 'vue'
import App from './App.vue'
import router from "@/router";
import './index.css';

const _App = createApp(App);

_App.use(router);

_App.mount('#app')
