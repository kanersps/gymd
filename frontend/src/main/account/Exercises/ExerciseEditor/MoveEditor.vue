<template>
  <div v-show="addingMove" class="col-span-1 bg-white shadow-md p-3">
    <span class="font-semibold flex-1 text-gray-800">Add Move</span>

    <form @submit="createMove">
      <div class="mb-4">
        <label for="move_name" class="block text-gray-700 text-sm font-semibold mb-2">Move Name</label>
        <input v-model="move.name" id="move_name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>

      <div class="mb-4">
        <label for="move_name" class="block text-gray-700 text-sm font-semibold mb-2">Move Instructions</label>
        <textarea v-model="move.instructions" id="move_name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>

      <div class="mb-4">
        <label for="move_quantity" class="block text-gray-700 text-sm font-semibold mb-2">Quantity Type</label>
        <select v-model="move.quantityType" id="move_quantity" class="w-full shadow border py-2 px-3">
          <option :value="0">Seconds</option>
          <option :value="1">Kilo</option>
        </select>
      </div>

      <div class="mb-4">
        <label for="move_amount" class="block text-gray-700 text-sm font-semibold mb-2">Default Amount</label>
        <input v-model="move.defaultAmount" id="move_amount" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>

      <div class="mb-4">
        <label for="move_repetitions" class="block text-gray-700 text-sm font-semibold mb-2">Default Repetitions</label>
        <input
          v-model="move.defaultRepetitions"
          id="move_repetitions"
          class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline"
        />
      </div>

      <div class="mb-4 grid grid-cols-1 md:grid-cols-2 gap-3">
        <button type="button" @click="this.setAddingMove(false)" class="bg-red-500 text-white rounded px-3 py-2 w-full">Cancel</button>
        <button type="submit" class="bg-green-500 text-white rounded px-3 py-2 w-full">Add Move</button>
      </div>
    </form>
  </div>
</template>

<script>
export default {
  props: ["addMove", "addingMove", "setAddingMove"],
  data() {
    return {
      move: {
        name: "",
        instructions: "",
        quantityType: 0,
        defaultAmount: 0,
        defaultRepetitions: 0,
      },
    };
  },
  setup() {},

  methods: {
    createMove(event) {
      event.preventDefault();
      this.addMove({ ...this.move, id: Math.random() });
    },
  },
};
</script>