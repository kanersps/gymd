<template>
  <div class="flex flex-col h-screen">
    <NavMenu></NavMenu>
    <RouterView class="flex-1 overflow-y-scroll"></RouterView>
  </div>
</template>

<script>

import NavMenu from "@/components/navigation/NavMenu";
export default {
  name: 'App',
  components: {
    NavMenu
  }
}
</script>

<style>
</style>
