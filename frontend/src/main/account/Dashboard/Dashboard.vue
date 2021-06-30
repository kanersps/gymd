<template>
  <div class="grid grid-all">
    <Menu></Menu>

    <div class="p-10 bg-gray-100">
      <Toolbar :nickname="nickname" />

      <Overview />
    </div>
  </div>
</template>

<style scoped>
.grid-all {
  grid-template-columns: 16rem 1fr;
}
</style>

<script>
import api from "@/api.js";
import Menu from "./Menu/Menu.vue";
import Toolbar from "./Toolbar/Toolbar.vue";
import Overview from "./Overview.vue";
export default {
  components: { Menu, Toolbar, Overview },
  name: "Dashboard",
  data: function () {
    return {
      nickname: "",
    };
  },
  created() {
    this.$watch(
      () => this.$route.params,
      () => {
        this.loadDashboard();
      },
      { immediate: true }
    );
  },
  methods: {
    loadDashboard() {
      api.get("account/dashboard").then((data) => {
        this.nickname = data.nickname;
      });
    },
  },
};
</script>