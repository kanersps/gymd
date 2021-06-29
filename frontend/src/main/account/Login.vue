<template>
  <div>
    <NavMenu></NavMenu>
    <div class="absolute z-10 top-0 left-0 w-full h-full from-green-400 to-blue-500 bg-gradient-to-bl bg-gradient-from-tr" />
    <div class="flex justify-center z-20 absolute top-14 bottom-0 bg-white w-full">
      <div class="p-3 mt-10 pt-10 absolute w-full md:w-1/3">
        <div class="text-4xl border-indigo-500 border-b-2 pb-2">Login</div>

        <form @submit="submit" class="grid-cols-1 gap-3 grid mt-4 w-full">
          <label class="block text-gray-700 text-sm font-bold" for="email">E-Mail</label>
          <input v-model="email" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="email" />

          <label class="block text-gray-700 text-sm font-bold" for="password">Password</label>
          <input v-model="password" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" id="password" />

          <Error v-bind:message="loginError" />

          <div class="justify-center flex">
            <button
              v-bind:disabled="loggingIn"
              class="w-full md:w-1/2 relative rounded bg-indigo-500 disabled:cursor-default hover:bg-indigo-400 cursor-pointer transition duration:100 text-white text-lg p-2"
              type="submit"
            >
              <div class="relative items-center">
                <span> Login </span>
                <div class="absolute left-0 top-0">
                  <svg v-show="loggingIn" class="animate-spin ml-1 mb-1 mr-3 h-5 w-5 text-white inline-block" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                    <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                    <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                  </svg>
                </div>
              </div>
            </button>
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
  </div>
</template>

<script>
import NavMenu from "../../components/navigation/NavMenu.vue";
import Button from "@/components/ui/Button";
import Error from "../../components/ui/Error";
import * as Authentication from "../../store/actions/Authentication";
import AccountErrors from "../../store/errors/AccountErrors";

export default {
  name: "Login",
  components: { Error, Button, NavMenu },
  data: function () {
    return {
      email: "",
      password: "",
    };
  },
  methods: {
    submit: function (e) {
      e.preventDefault();

      this.$store.dispatch(Authentication.ACTIONS.LOGIN, {
        email: this.email,
        password: this.password,
      });
    },
  },
  computed: {
    loginError() {
      return AccountErrors[this.$store.state.loginError] ? AccountErrors[this.$store.state.loginError] : this.$store.state.loginError;
    },
    loggingIn() {
      return this.$store.state.loggingIn;
    },
  },
};
</script>

<style scoped>
</style>
