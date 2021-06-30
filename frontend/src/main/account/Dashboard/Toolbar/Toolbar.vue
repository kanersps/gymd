<template>
  <div class="shadow-md w-full bg-white flex items-center rounded-xl pt-3 pb-3 pl-5 pr-5">
    <div class="flex flex-1">
      <ToolbarItem :selected="true">Overview</ToolbarItem>
      <ToolbarItem :selected="false">Exercises</ToolbarItem>
    </div>
    <div class="flex items-center p-1 pl-4 pr-4 cursor-pointer hover:bg-gray-100 transition-all duration-75 rounded">
      <div class="inline">
        {{ nickname }}
      </div>
      <div class="inline ml-4 rounded-full bg-indigo-200 pt-0.5 pb-0.5 pr-1 pl-1">
        <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 inline mb-0.5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
        </svg>
      </div>
    </div>
  </div>
</template>

<script>
import ToolbarItem from "./ToolbarItem.vue";

export default {
  components: { ToolbarItem },
  props: ["nickname"],
  computed: {
    currentTab: function () {
      return "";
    },
  },
};
</script>