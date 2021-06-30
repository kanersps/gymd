<template>
  <div class="grid grid-all">
    <div class="toolbar flex flex-col text-white bg-gray-900">
      <div class="mt-10 text-center pt-3 pb-3 text-3xl font-semibold">GymT</div>
      <div class="flex-grow pl-3 pr-3">
        <div class="flex items-center bg-white cursor-pointer text-gray-900 rounded mt-3 p-1">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5 inline" viewBox="0 0 20 20" fill="currentColor">
            <path d="M5 4a2 2 0 012-2h6a2 2 0 012 2v14l-5-2.5L5 18V4z" />
          </svg>
          <span class="text-xl ml-5 font-semibold">Dashboard</span>
        </div>
        <div class="flex items-center text-white hover:bg-white hover:bg-opacity-10 transition-all duration-75 cursor-pointer rounded mt-3 p-1">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
            <path
              d="M13 6a3 3 0 11-6 0 3 3 0 016 0zM18 8a2 2 0 11-4 0 2 2 0 014 0zM14 15a4 4 0 00-8 0v3h8v-3zM6 8a2 2 0 11-4 0 2 2 0 014 0zM16 18v-3a5.972 5.972 0 00-.75-2.906A3.005 3.005 0 0119 15v3h-3zM4.75 12.094A5.973 5.973 0 004 15v3H1v-3a3 3 0 013.75-2.906z"
            />
          </svg>
          <span class="text-xl ml-5 font-semibold">Friends</span>
        </div>
        <div class="flex items-center text-white hover:bg-white hover:bg-opacity-10 transition-all duration-75 cursor-pointer rounded mt-3 p-1">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" viewBox="0 0 20 20" fill="currentColor">
            <path
              d="M10.394 2.08a1 1 0 00-.788 0l-7 3a1 1 0 000 1.84L5.25 8.051a.999.999 0 01.356-.257l4-1.714a1 1 0 11.788 1.838L7.667 9.088l1.94.831a1 1 0 00.787 0l7-3a1 1 0 000-1.838l-7-3zM3.31 9.397L5 10.12v4.102a8.969 8.969 0 00-1.05-.174 1 1 0 01-.89-.89 11.115 11.115 0 01.25-3.762zM9.3 16.573A9.026 9.026 0 007 14.935v-3.957l1.818.78a3 3 0 002.364 0l5.508-2.361a11.026 11.026 0 01.25 3.762 1 1 0 01-.89.89 8.968 8.968 0 00-5.35 2.524 1 1 0 01-1.4 0zM6 18a1 1 0 001-1v-2.065a8.935 8.935 0 00-2-.712V17a1 1 0 001 1z"
            />
          </svg>
          <span class="text-xl ml-5 font-semibold">Achievements</span>
        </div>
      </div>
    </div>
    <div class="p-10 bg-gray-100">
      <div class="shadow-md w-full bg-white flex items-center rounded-xl pt-3 pb-3 pl-5 pr-5">
        <div class="flex flex-1">
          <span class="text-blue-700 font-semibold pr-4">Overview</span>
          <span class="text-gray-600 font-semibold pr-4">Exercises</span>
        </div>
        <div class="flex items-center p-1 pl-4 pr-4 cursor-pointer hover:bg-gray-100 transition-all duration-75 rounded">
          <div class="inline">
            {{ nickname || "Kane" }}
          </div>
          <div class="inline ml-4 rounded-full bg-indigo-200 pt-0.5 pb-0.5 pr-1 pl-1">
            <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6 inline mb-0.5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
              <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M16 7a4 4 0 11-8 0 4 4 0 018 0zM12 14a7 7 0 00-7 7h14a7 7 0 00-7-7z" />
            </svg>
          </div>
        </div>
      </div>

      <div class="grid grid-cols-3 gap-3">
        <div class="h-96 p-3 bg-white shadow-md rounded mt-3">
          <span class="font-semibold text-gray-800">Recent Activity</span>
          <div class="mt-2">
            <div class="grid activity-log mt-2">
              <div>
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M11 16l-4-4m0 0l4-4m-4 4h14m-5 4v1a3 3 0 01-3 3H6a3 3 0 01-3-3V7a3 3 0 013-3h7a3 3 0 013 3v1" />
                </svg>
              </div>

              <div>
                <div>New account login from 127.0.0.1</div>
                <div class="flex items-center text-gray-400">
                  <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 inline" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                  <span class="ml-2">3 minutes ago</span>
                </div>
              </div>
            </div>
            <div class="grid activity-log mt-2">
              <div>
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path
                    stroke-linecap="round"
                    stroke-linejoin="round"
                    stroke-width="2"
                    d="M11.049 2.927c.3-.921 1.603-.921 1.902 0l1.519 4.674a1 1 0 00.95.69h4.915c.969 0 1.371 1.24.588 1.81l-3.976 2.888a1 1 0 00-.363 1.118l1.518 4.674c.3.922-.755 1.688-1.538 1.118l-3.976-2.888a1 1 0 00-1.176 0l-3.976 2.888c-.783.57-1.838-.197-1.538-1.118l1.518-4.674a1 1 0 00-.363-1.118l-3.976-2.888c-.784-.57-.38-1.81.588-1.81h4.914a1 1 0 00.951-.69l1.519-4.674z"
                  />
                </svg>
              </div>

              <div>
                <div>Achievement get <span class="font-semibold">10 consecutive workout days</span>!</div>
                <div class="flex items-center text-gray-400">
                  <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 inline" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                  <span class="ml-2">6 hours ago</span>
                </div>
              </div>
            </div>

            <div class="grid mt-2 activity-log">
              <div>
                <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
                </svg>
              </div>

              <div>
                <div>You added <span class="font-semibold">John</span> as a friend</div>
                <div class="flex items-center text-gray-400">
                  <svg xmlns="http://www.w3.org/2000/svg" class="h-4 w-4 inline" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                    <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M12 8v4l3 3m6-3a9 9 0 11-18 0 9 9 0 0118 0z" />
                  </svg>
                  <span class="ml-2">2 days ago</span>
                </div>
              </div>
            </div>
          </div>
        </div>
        <div class="h-96 p-3 bg-white shadow-md rounded mt-3 col-span-2">
          <span class="font-semibold text-gray-800">Your Exercises</span>
        </div>
        <div class="h-96 p-3 bg-white shadow-md rounded mt-3"></div>
        <div class="h-96 p-3 bg-white shadow-md rounded mt-3"></div>
        <div class="h-96 p-3 bg-white shadow-md rounded mt-3"></div>
      </div>
    </div>
  </div>
</template>

<style scoped>
.grid-all {
  grid-template-columns: 16rem 1fr;
}

.toolbar {
  box-shadow: 1px 0 5px -2px #888;
}

.activity-log {
  grid-template-columns: 3rem 1fr;
}
</style>

<script>
import api from "@/api.js";
export default {
  name: "Dashboard",
  data: function () {
    return {
      nickname: "",
    };
  },
  created() {
    this.$watch(
      () => this.$route.params,
      () => {
        this.loadDashboard();
      },
      { immediate: true }
    );
  },
  methods: {
    loadDashboard() {
      api.get("account/dashboard").then((data) => {
        this.nickname = data.nickname;
      });
    },
  },
};
</script>