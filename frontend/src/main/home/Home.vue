<template>
  <div class="grid-cols-1 md:grid-cols-2 h-full grid items-center">
    <div class="text-center p-4 mb-8">
      <div class="text-4xl font-bold mb-3">
        <span class="border-dotted font-light">Gym<span class="text-yellow-500 font-bold">T</span></span>
      </div>
      <div class="text-4xl font-bold">Learning Fitness Tracker</div>
      <div class="text-xl mt-2">Advanced fitness tracking app that will help you reach your goals using machine
        learning
      </div>

      <div class="inline-flex gap-3 mt-5">
        <router-link to="/account/login">
          <Button class="w-40">Login</Button>
        </router-link>
        <router-link to="/account/register">
          <Button class="w-40">Create Account</Button>
        </router-link>
      </div>
    </div>

    <div class="h-full invisible md:visible md:h-1/2 flex justify-center">
      <div class="h-full w-full md:w-1/2 cover rounded-xl"></div>
    </div>
  </div>
</template>

<script>

import Button from "@/components/ui/Button";

export default {
  name: "Home",
  components: {Button}
}
</script>

<style scoped>
.cover {
  background-image: url("../../assets/cover.jpg");
  background-position: 50% 50%;
  background-size: cover;
}
</style>
