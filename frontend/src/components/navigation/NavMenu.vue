<template>
  <nav :class="onHomepage ? '' : ''" class="text-white p-2 absolute z-50 left-0 right-0 border-b-2 md:pl-10 md:pr-10 xl:pl-32 xl:pr-32">
    <div class="pl-1 md:pl-4 w-full pr-4 flex items-center">
      <div class="flex-1 flex items-center">
        <svg v-on:click="open = !open" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 inline md:hidden" fill="none" viewBox="0 0 24 24" stroke="currentColor">
          <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
        </svg>
        <router-link to="/" class="text-2xl font-light pl-3 md:pl-0">
          <span class="font-semibold font-serif">GymT</span>
        </router-link>
      </div>

      <div class="flex gap-2 invisible md:visible">
        <NavButton link="/account/dashboard">Account</NavButton>
      </div>
    </div>

    <div :class="{ hidden: !open }" class="md:hidden w-full bg-gray-300 fixed left-0 z-10">
      <div class="grid mt-2 grid-cols-1 gap-2">
        <NavButton link="/">Home</NavButton>
        <NavButton link="/account">Account</NavButton>
      </div>
    </div>
  </nav>
</template>

<script>
import NavButton from "@/components/navigation/NavButton";

export default {
  name: "NavMenu",
  components: { NavButton },
  data: function () {
    return { open: false };
  },
  computed: {
    onHomepage: function () {
      return this.$route.path !== "/";
    },
  },
};
</script>

<style scoped>
</style>
