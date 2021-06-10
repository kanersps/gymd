<template>
  <router-view></router-view>
</template>

<script>

import AppStore from "@/store/AppStore";

export default {
name: "Account",
  beforeRouteEnter(to, from, next) {
    if(!AppStore.state.loggedIn && to.path !== "/account/login") {
      next('/account/login')
    } else {
      next();
    }
  }
}
</script>

<style scoped>

</style>
