<template>
  <div>
    <div class="grid grid-cols-3 gap-3">
      <div class="h-96 p-3 col-span-3 bg-white shadow-md rounded">
        <div class="flex">
          <span class="font-semibold flex-1 text-gray-800">Your Exercises</span>
        </div>

        <table class="w-full text-left mt-4">
          <thead>
            <tr>
              <th>Name</th>
              <th>Equipment</th>
              <th>Created</th>
              <th></th>
            </tr>
          </thead>

          <tbody></tbody>
        </table>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  setup() {},
};
</script>