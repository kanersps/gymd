<template>
  <div class="shadow-md w-full bg-white flex items-center rounded-xl pt-3 pb-3 pl-5 pr-5 mb-3">
    <ToolbarItems />

    <div class="profile-context flex items-center transition-all duration-75 relative rounded">
      <div class="flex items-center rounded cursor-pointer hover:bg-gray-100 p-1 pl-4 pr-4">
        <div class="inline">
          {{ nickname }}
        </div>
        <div class="inline ml-4 rounded-full bg-indigo-200 pt-0.5 pb-0.5 pr-1 pl-1">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 inline mb-0.5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
          </svg>
        </div>
      </div>

      <div class="profile-context-menu absolute top-10 w-48 right-0">
        <div class="w-full h-4" />
        <div class="bg-white cursor-pointer shadow-md rounded">
          <div class="hover:bg-gray-100 p-2 transition-all duration-75">
            <span class="text-black">Profile</span>
          </div>
          <div class="hover:bg-red-100 p-2 transition-all duration-75">
            <div v-on:click="logout" class="text-red-800">Logout</div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.profile-context-menu {
  display: none;
}
.profile-context:hover .profile-context-menu {
  display: block;
}
</style>

<script>
import ToolbarItems from "./ToolbarItems.vue";
import * as Authentication from "@/store/actions/Authentication";

export default {
  components: { ToolbarItems },
  data: function () {
    return {
      showContextMenu: false,
    };
  },
  computed: {
    currentTab: function () {
      return "";
    },
    nickname: function () {
      return this.$store.state.nickname;
    },
  },
  methods: {
    logout: function () {
      this.$store.dispatch(Authentication.ACTIONS.LOGOUT);
    },
  },
};
</script>