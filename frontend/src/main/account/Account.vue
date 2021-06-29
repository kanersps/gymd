<template>
  <router-view></router-view>
</template>

<script>
import AppStore from "@/store/AppStore";

export default {
  name: "Account",
  beforeRouteEnter(to, from, next) {
    if (AppStore.state.loggedIn) {
      if (to.path == "/account/register" || to.path == "/account/login" || to.path == "/account") {
        next("/account/dashboard");
      } else {
        next();
      }
    } else {
      console.log(to.path);
      if (to.path == "/account/register" || to.path == "/account/login") {
        next();
      } else {
        next("/account/login");
      }
    }
  },
};
</script>

<style scoped>
</style>
