<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>
import api from "@/api.js";
export default {
  components: {},
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
        this.$store.commit("setNickname", data.nickname);
      });
    },
  },
};
</script>