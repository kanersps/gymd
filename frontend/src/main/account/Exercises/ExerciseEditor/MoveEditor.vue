<template>
  <div v-show="addingMove" class="col-span-1 bg-white shadow-md p-3">
    <span class="font-semibold flex-1 text-gray-800">Add Move</span>

    <form @submit="createMove">
      <div class="mb-4">
        <label for="move_name" class="block text-gray-700 text-sm font-semibold mb-2">Move Name <span class="text-red-600">*</span></label>
        <input v-model="move.name" id="move_name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>

      <div class="mb-4">
        <label for="move_name" class="block text-gray-700 text-sm font-semibold mb-2">Move Instructions</label>
        <textarea v-model="move.instructions" id="move_name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>

      <div class="mb-4">
        <label for="move_quantity" class="text-gray-700 text-sm font-semibold mb-2 w-full flex justify-between">
          <span>Quantity Type <span class="text-red-600">*</span></span>
          <InfoHover>Set if this move is about weight or time (ex: you rest in seconds, or bench press with weight)</InfoHover>
        </label>
        <select v-model="move.quantityType" id="move_quantity" class="w-full shadow border py-2 px-3">
          <option :value="1">Kilo</option>
          <option :value="0">Seconds</option>
        </select>
      </div>

      <div class="mb-4">
        <label for="move_amount" class="text-gray-700 text-sm font-semibold mb-2 w-full flex justify-between">
          <span>Default Amount <span class="text-red-600">*</span></span>
          <InfoHover>How many kilo or seconds is the default for this move</InfoHover>
        </label>
        <input v-model="move.defaultAmount" id="move_amount" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
      </div>

      <div class="mb-4">
        <label for="move_repetitions" class="text-gray-700 text-sm font-semibold mb-2 w-full flex justify-between">
          <span>Default Repetitions <span class="text-red-600">*</span></span>
          <InfoHover>How many repetitions is default for this move</InfoHover>
        </label>
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
import InfoHover from "../../../../components/ui/InfoHover.vue";

export default {
  components: { InfoHover },
  props: ["addMove", "addingMove", "setAddingMove"],
  data() {
    return {
      move: {
        name: "",
        instructions: "",
        quantityType: 1,
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