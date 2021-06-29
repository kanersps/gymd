<template>
  <h1>Welcome, {{ nickname }}</h1>
</template>

<script>
import api from "../../api";
export default {
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