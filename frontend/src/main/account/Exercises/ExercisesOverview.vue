<template>
  <div>
    <div class="grid grid-cols-3 gap-3">
      <div class="p-3 col-span-3 flex flex-col bg-white shadow-md rounded">
        <div class="flex">
          <span class="font-semibold flex-1 text-gray-800">Your Exercises</span>
        </div>

        <div class="rounded t-height border-gray-200 border-b shadow flex flex-col justify-between flex-grow mt-3">
          <table class="w-full text-left">
            <thead class="bg-gray-50 text-gray-700 uppercase">
              <tr>
                <th class="px-2 py-3 font-semibold">Name</th>
                <th class="py-3 font-semibold">Equipment</th>
                <th class="py-3 font-semibold">Created</th>
                <th class="py-3 font-semibold"></th>
              </tr>
            </thead>

            <tbody>
              <tr v-for="exercise of exercises" :key="exercise">
                <td class="px-2">{{ exercise.name }}</td>
                <td>{{ exercise.equipment }}</td>
                <td>{{ exercise.created }}</td>
              </tr>
            </tbody>
          </table>

          <div class="flex justify-end h-8">
            <button
              :disabled="loading"
              @click="previousPage()"
              class="border-gray-700 w-20 disabled:bg-gray-200 disabled:cursor-default rounded-l border-t border-l border-b border-opacity-50 px-2 py-1 hover:bg-gray-100 cursor-pointer"
            >
              Previous
            </button>
            <div class="border border-gray-700 w-full md:w-32 text-center text-gray-700 border-opacity-50 px-2 py-1">
              <svg v-show="loading" class="animate-spin mb-1 h-5 w-5 inline-block" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
              </svg>
              <span v-show="!loading">Page {{ currentPage }}/{{ pages }}</span>
            </div>
            <button
              :disabled="loading"
              @click="nextPage()"
              class="border-r w-20 rounded-r disabled:bg-gray-200 disabled:cursor-default border-b border-t border-gray-700 border-opacity-50 px-2 py-1 hover:bg-gray-100 cursor-pointer"
            >
              Next
            </button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.t-height {
  height: 360px;
}
</style>

<script>
import api from "../../../api";
export default {
  data() {
    return {
      exercises: [],
      currentPage: 1,
      pages: 1,
      loading: true,
    };
  },
  created() {
    api
      .post("exercise/exercises", {
        // lastview is datetime 1970-01-01T00:00:00Z
        LastView: "1970-01-01T00:00:00Z",
        NextPage: true,
      })
      .then((data) => {
        this.exercises = data.exercises;
        this.pages = data.pages;
        this.loading = false;
      });
  },
  methods: {
    previousPage() {
      if (this.currentPage > 1 && this.currentPage <= this.pages) {
        this.loading = true;
        api
          .post("exercise/exercises", {
            // lastview is datetime 1970-01-01T00:00:00Z
            LastView: this.exercises[this.exercises.length - 1].created,
            NextPage: false,
          })
          .then((data) => {
            this.exercises = data.exercises;
            this.pages = data.pages;
            this.currentPage--;
            this.loading = false;
          });
      }
    },
    nextPage() {
      if (this.currentPage < this.pages && this.currentPage >= 1) {
        this.loading = true;
        api
          .post("exercise/exercises", {
            // lastview is datetime 1970-01-01T00:00:00Z
            LastView: this.exercises[this.exercises.length - 1].created,
            NextPage: true,
          })
          .then((data) => {
            this.exercises = data.exercises;
            this.pages = data.pages;
            this.currentPage++;
            this.loading = false;
          });
      }
    },
  },
};
</script>