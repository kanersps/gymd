<template>
  <router-link v-bind:to="link" class="outline-none">
    <button v-bind:class="{ 'bg-gray-700': active || isPathActive }" class="pl-4 pr-4 pt-2 pb-2 focus:outline-none hover:bg-gray-600 rounded transition-all"> <slot></slot> </button>
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
    isPathActive: function() {
      console.log()
      return this.$route.path.split("/")[1] === this.link.replace(/\//g, "");
    }
  }
}
</script>

<style scoped>

</style>
