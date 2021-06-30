<template>
  <div class="grid grid-cols-3 gap-3">
    <div class="h-96 p-3 bg-white shadow-md rounded">
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
    <div class="h-96 p-3 bg-white shadow-md rounded col-span-2">
      <span class="font-semibold text-gray-800">Your Exercises</span>
    </div>
    <div class="h-96 p-3 bg-white shadow-md rounded"></div>
    <div class="h-96 p-3 bg-white shadow-md rounded"></div>
    <div class="h-96 p-3 bg-white shadow-md rounded"></div>
  </div>
</template>

<style scoped>
.activity-log {
  grid-template-columns: 3rem 1fr;
}
</style>

<script>
export default {
  setup() {},
};
</script>