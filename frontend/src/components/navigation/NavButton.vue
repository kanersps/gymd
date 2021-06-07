<template>
  <router-link v-bind:to="link" class="outline-none block">
    <button v-bind:class="{ 'bg-gray-700': (active || isPathActive), 'bg-gray-800': !(active || isPathActive) }"
            class="pl-4 pr-4 pt-2 pb-2 w-full md:w-auto focus:outline-none hover:bg-gray-600 md:rounded transition-all">
      <slot></slot>
    </button>
  </router-link>
</template>

<script>
export default {
  name: "NavButton",
  props: {
    link: String,
    active: Boolean
  },
  computed: {
    isPathActive: function () {
      return this.$route.path.split("/")[1] === this.link.replace(/\//g, "");
    }
  }
}
</script>

<style scoped>

</style>
