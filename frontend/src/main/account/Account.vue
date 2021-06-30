<template>
  <div class="grid grid-all">
    <Menu />

    <div class="p-10 bg-gray-100">
      <Toolbar />
      <router-view />
    </div>
  </div>
</template>

<style scoped>
.grid-all {
  grid-template-columns: 16rem 1fr;
}

.fade-enter-active,
.fade-leave-active {
  transition: opacity 0.5s;
}
.fade-enter, .fade-leave-to /* .fade-leave-active below version 2.1.8 */ {
  opacity: 0;
}
</style>

<script>
import AppStore from "@/store/AppStore";
import api from "../../api";
import Menu from "./Menu/Menu.vue";
import Toolbar from "./Toolbar/Toolbar.vue";

export default {
  name: "Account",
  components: { Menu, Toolbar },
  beforeRouteEnter(to, from, next) {
    if (AppStore.state.loggedIn) {
      next();
    } else {
      const token = localStorage.getItem("token");

      if (token) {
        AppStore.commit("setToken", token);

        api.get("account/authenticated").then((response) => {
          if (response.success) {
            AppStore.commit("setLoggedIn", true);
            next();
          } else {
            next("/login");
          }
        });
      } else {
        next("/login");
      }
    }
  },
};
</script>

<style scoped>
</style>
