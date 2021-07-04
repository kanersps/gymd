<template>
  <div class="flex flex-1">
    <ToolbarItem :to="item.path.length > 0 ? route + '/' + item.path : route" :selected="isSelectedTab(item.path)" v-for="item in routeItems[route]" :key="item.name">{{ item.name }}</ToolbarItem>
  </div>
</template>

<script>
import ToolbarItem from "./ToolbarItem.vue";

export default {
  components: { ToolbarItem },
  data: function () {
    return {
      routeItems: {
        "/account/dashboard": [
          {
            name: "Overview",
            path: "",
          },
          {
            name: "Exercises",
            path: "exercises",
          },
        ],
        "/account/exercises": [
          {
            name: "Overview",
            path: "",
          },
          {
            name: "Create Exercise",
            path: "create",
          },
        ],
      },
    };
  },
  computed: {
    route: function () {
      for (let key in this.routeItems) {
        if (this.$route.path.startsWith(key)) {
          return key;
        }
      }

      return "";
    },
  },
  methods: {
    isSelectedTab: function (tab) {
      return this.$route.path == this.route + "/" + tab || this.$route.path == this.route + tab;
    },
  },
};
</script>