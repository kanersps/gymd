<template>
  <div class="flex justify-center">
    <div class="p-3 mt-10 w-full md:w-1/3">
      <div class="text-4xl border-yellow-500 border-b-2 pb-2">Login</div>

      <form class="grid grid-cols-1 gap-3 flex mt-4 w-full">
        <label class="block text-gray-700 text-sm font-bold" for="email">E-Mail</label>
        <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email">

        <label class="block text-gray-700 text-sm font-bold" for="password">Password</label>
        <input class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="password">

        <div class="justify-center flex">
          <input class="pt-3 pb-3 w-full md:w-1/2 rounded bg-yellow-500 hover:bg-yellow-400 cursor-pointer transition duration:100 text-white text-lg" type="submit" value="Login">
        </div>
      </form>
    </div>
  </div>
</template>

<script>
export default {
name: "Login"
}
</script>

<style scoped>

</style>
