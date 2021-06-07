<template>
  <nav class="bg-gray-300 dark:bg-gray-800 dark:text-white p-2">
    <div class="pl-4 w-full pr-4 flex items-center">
      <router-link class="flex-1" to="/">
        <span class="text-2xl font-light">Gym<span class="text-yellow-500 font-bold">T</span></span>
      </router-link>

      <span class="flex gap-2">
        <NavButton link="/">Home</NavButton>
        <NavButton link="/account">Account</NavButton>
      </span>
    </div>
  </nav>
</template>

<script>
import NavButton from "@/components/navigation/NavButton";
export default {
name: "NavMenu",
  components: {NavButton}
}
</script>

<style scoped>

</style>
