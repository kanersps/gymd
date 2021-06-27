<template>
  <div class="flex justify-center">
    <div class="p-3 mt-10 w-full md:w-1/3">
      <div class="text-4xl border-indigo-500 border-b-2 pb-2">Login</div>

      <form @submit="submit" class="grid grid-cols-1 gap-3 flex mt-4 w-full">
        <label class="block text-gray-700 text-sm font-bold" for="email">E-Mail</label>
        <input
            v-model="email"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="email">

        <label class="block text-gray-700 text-sm font-bold" for="password">Password</label>
        <input
            v-model="password"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="password">

        <Error v-bind:message="loginError"/>

        <div class="justify-center flex">
          <input
              class="pt-3 pb-3 w-full md:w-1/2 rounded bg-indigo-500 hover:bg-indigo-400 cursor-pointer transition duration:100 text-white text-lg"
              type="submit" value="Login">
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
import Error from "../../components/ui/Error";
import api from "../../api";

export default {
  name: "Login",
  components: {Error, Button},
  data: function () {
    return {
      loginError: "",
      email: "",
      password: ""
    }
  },
  methods: {
    submit: function (e) {
      e.preventDefault();
      console.log(this.email);

      api.post("account/login", {
        email: this.email,
        password: this.password
      })
    }
  }
}
</script>

<style scoped>

</style>
