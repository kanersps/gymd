<template>
  <div class="flex justify-center">
    <div class="p-3 mt-10 w-full md:w-1/3">
      <div class="text-4xl border-indigo-500 border-b-2 pb-2">Login</div>

      <form class="grid grid-cols-1 gap-3 flex mt-4 w-full">
        <label class="block text-gray-700 text-sm font-bold" for="email">E-Mail</label>
        <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email">

        <label class="block text-gray-700 text-sm font-bold" for="password">Password</label>
        <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="password">

        <div class="justify-center flex">
          <input class="pt-3 pb-3 w-full md:w-1/2 rounded bg-indigo-500 hover:bg-indigo-400 cursor-pointer transition duration:100 text-white text-lg" type="submit" value="Login">
        </div>
      </form>

      <div class="border-indigo-500 border-b-2 mt-4 pb-2">Don't have an account yet?</div>

      <div class="flex justify-center mt-4">
        <router-link to="/account/register">
          <Button>Create an account</Button>
        </router-link>
      </div>
    </div>
  </div>
</template>

<script>
import Button from "@/components/ui/Button";
export default {
name: "Login",
  components: {Button}
}
</script>

<style scoped>

</style>
