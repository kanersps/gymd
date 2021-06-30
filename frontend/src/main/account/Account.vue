<template>
  <router-view></router-view>
</template>

<script>
import AppStore from "@/store/AppStore";
import api from "../../api";

export default {
  name: "Account",
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
