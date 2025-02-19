<template>
  <div>
    <NavMenu></NavMenu>
    <div class="absolute z-10 top-0 left-0 w-full h-full from-green-400 to-blue-500 bg-gradient-to-bl bg-gradient-from-tr" />
    <div class="flex justify-center z-20 absolute top-14 bottom-0 bg-white w-full">
      <div class="p-3 mt-10 pt-10 w-full md:w-1/3">
        <div class="text-4xl border-indigo-500 border-b-2 pb-2">Register</div>

        <form @submit="submitForm" class="grid grid-cols-1 gap-3 mt-4 w-full">
          <label class="block text-gray-700 text-sm font-bold" for="nickname">Nickname</label>
          <input
            v-model="nickname"
            v-on:keydown="inputChanged('nickname')"
            v-on:blur="touchedInput('nickname')"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="nickname"
          />

          <Error v-bind:message="errors.nickname" />

          <label class="block text-gray-700 text-sm font-bold" for="email">E-Mail</label>
          <input
            v-model="email"
            v-on:keydown="inputChanged('email')"
            v-on:blur="touchedInput('email')"
            class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
            id="email"
          />

          <Error v-bind:message="errors.email" />

          <label class="block text-gray-700 text-sm font-bold" for="password">Password</label>
          <div class="border shadow rounded flex items-center">
            <input
              v-on:blur="touchedInput('password')"
              v-on:keydown="inputChanged('password')"
              v-model="password"
              v-bind:type="displayPassword ? 'text' : 'password'"
              class="inline flex-1 appearance-none py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
              id="password"
            />

            <div @click="displayPassword = !displayPassword" class="inline mr-2 cursor-pointer">
              <svg v-if="!displayPassword" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 inline" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M13.875 18.825A10.05 10.05 0 0112 19c-4.478 0-8.268-2.943-9.543-7a9.97 9.97 0 011.563-3.029m5.858.908a3 3 0 114.243 4.243M9.878 9.878l4.242 4.242M9.88 9.88l-3.29-3.29m7.532 7.532l3.29 3.29M3 3l3.59 3.59m0 0A9.953 9.953 0 0112 5c4.478 0 8.268 2.943 9.543 7a10.025 10.025 0 01-4.132 5.411m0 0L21 21"
                />
              </svg>

              <svg v-if="displayPassword" xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 inline" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M15 12a3 3 0 11-6 0 3 3 0 016 0z" />
                <path
                  stroke-linecap="round"
                  stroke-linejoin="round"
                  stroke-width="2"
                  d="M2.458 12C3.732 7.943 7.523 5 12 5c4.478 0 8.268 2.943 9.542 7-1.274 4.057-5.064 7-9.542 7-4.477 0-8.268-2.943-9.542-7z"
                />
              </svg>
            </div>
          </div>

          <Error v-bind:message="errors.password" />

          <div>
            <input v-model="terms" class="shadow border rounded text-gray-700 bg-red-800 leading-tight" type="checkbox" id="terms" />&nbsp;
            <label class="text-gray-700 text-sm font-bold" for="terms">I agree to the terms and conditions</label>
          </div>
          <Error v-bind:message="errors.terms" />

          <div class="justify-center flex">
            <input class="pt-3 pb-3 w-full md:w-1/2 rounded bg-indigo-500 hover:bg-indigo-400 cursor-pointer transition duration:100 text-white text-lg" type="submit" value="Register" />
          </div>
        </form>

        <div class="border-indigo-500 border-b-2 mt-4 pb-2">Already have an account?</div>

        <div class="flex justify-center mt-4">
          <router-link to="/account/login">
            <Button>Login to your account</Button>
          </router-link>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
/* eslint-disable no-unused-vars */
import NavMenu from "../../components/navigation/NavMenu.vue";
import Button from "@/components/ui/Button";
import Error from "@/components/ui/Error";
import api from "../../api";

const MailRegex = new RegExp(/^[^\s@]+@[^\s@]+$/);

export default {
  name: "Register",
  components: { Error, Button, NavMenu },
  data: function () {
    return {
      nickname: "",
      email: "",
      password: "",
      terms: false,
      displayPassword: false,
      errors: {
        email: "",
        password: "",
        terms: "",
        nickname: "",
      },
      touched: {
        email: false,
        password: false,
        terms: false,
        nickname: false,
      },
    };
  },
  methods: {
    submitForm: function (e) {
      e.preventDefault();

      for (let t in this.touched) {
        this.touched[t] = true;
      }

      if (!MailRegex.test(this.email)) {
        this.errors.email = "This e-mail is in an incorrect format!";
      } else {
        this.errors.email = "";
      }

      for (let t in this.touched) {
        this.inputChanged(this[t]);
      }

      if (Object.values(this.errors).every((e) => e === "")) {
        api.post("account/register", {
          nickname: this.nickname,
          email: this.email,
          password: this.password,
        });
      }
    },
    inputChanged: function (input) {
      if (this.touched[input])
        switch (input) {
          case "email":
            if (!MailRegex.test(this.email)) {
              this.errors.email = "This e-mail is in an incorrect format!";
            } else {
              this.errors.email = "";
            }

            break;
          case "password":
            if (this.password.length <= 0) {
              this.errors.password = "This password is too short!";
            } else {
              this.errors.password = "";
            }

            break;
          case "nickname":
            if (this.nickname.length <= 2) {
              this.errors.nickname = "This nickname is too short!";
            } else {
              this.errors.nickname = "";
            }
        }
    },
    nicknameChanged: function () {
      if (!this.touched.email)
        if (!MailRegex.test(this.email)) {
          this.errors.email = "This e-mail is in an incorrect format!";
        } else {
          this.errors.email = "";
        }
    },
    touchedInput: function (input) {
      this.touched[input] = true;

      this.inputChanged(input);
    },
  },
};
</script>

<style scoped>
</style>
