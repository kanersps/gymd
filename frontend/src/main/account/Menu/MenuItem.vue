<template>
  <router-link :to="to">
    <div :class="selected ? 'bg-white text-gray-900' : 'hover:bg-white hover:bg-opacity-10'" class="flex items-center cursor-pointer transition-all duration-100 rounded mt-3 p-1">
      <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 inline" :viewBox="viewbox || '0 0 20 20'" fill="currentColor">
        <path :d="path" />
      </svg>
      <span class="text-xl ml-5 font-semibold"> <slot /> </span>
    </div>
  </router-link>
</template>

<script>
export default {
  props: ["path", "viewbox", "to"],
  computed: {
    selected: function () {
      return this.$route.path.startsWith(this.to);
    },
  },
};
</script>