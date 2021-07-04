<template>
  <div class="grid grid-cols-3 gap-3">
    <div class="col-span-1 bg-white shadow-md p-3">
      <span class="font-semibold flex-1 text-gray-800">Create Exercise</span>
      <form @submit="submit" class="pt-2">
        <div class="flex flex-col">
          <div class="flex-grow">
            <div class="mb-4">
              <label for="exercise_name" class="block text-gray-700 text-sm font-semibold mb-2">Exercise Name</label>
              <input v-model="exercise.name" id="exercise_name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
            </div>

            <div class="mb-4">
              <label for="exercise_type" class="block text-gray-700 text-sm font-semibold mb-2 w-full">Exercise Type</label>
              <select v-model="exercise.type" id="exercise_type" class="w-full shadow border py-2 px-3">
                <option :value="0">No Equipment</option>
                <option :value="1">Machine</option>
                <option :value="2">Free Weights</option>
              </select>
            </div>

            <div v-show="exercise.type !== 0" class="mb-4 relative">
              <label for="exercise_equipment" class="block text-gray-700 text-sm font-semibold mb-2 w-full">Equipment</label>
              <input v-on:keydown="searchKeyDownAutoComplete" v-model="exercise.equipment" id="exercise_equipment" class="w-full shadow border py-2 px-3" />

              <div v-show="searching" class="bg-white shadow-lg hover:bg-gray-200 cursor-pointer absolute w-full px-3 py-2" id="equipment_results">
                <div class="" @click="exercise.equipment = 'Dumbell'">Dumbell</div>
              </div>
            </div>

            <div class="mb-4">
              <label for="exercise_moves" class="block text-gray-700 text-sm font-semibold mb-2">Exercise Moves</label>
              <div class="flex justify-between">
                <span v-show="exercise.moves.length == 0">No moves have been added to this exercise</span>
                <span v-show="exercise.moves.length > 0">{{ exercise.moves.length }} moves have been added to this exercise</span>
                <button type="button" @click="addingMove = true" class="bg-indigo-500 text-white rounded px-3 py-2">Add Move</button>
              </div>

              <div class="max-h-56 mt-2 overflow-y-auto">
                <draggable
                  :component-data="{
                    tag: 'ul',
                    type: 'transition-group',
                    name: !drag ? 'flip-list' : null,
                  }"
                  :setData="modifyDragItem"
                  v-model="exercise.moves"
                  v-bind="dragOptions"
                  ghost-class="ghost"
                  handle=".handle"
                  @start="drag = true"
                  @end="drag = false"
                  item-key="id"
                >
                  <template #item="{ element }" class="rounded">
                    <div class="mt-2 flex justify-between items-center">
                      <div class="flex">
                        <button type="button" class="mr-3 bg-gray-200 rounded px-2 handle">
                          <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h16" />
                          </svg>
                        </button>
                        <div>
                          <div>{{ element.name }}</div>
                          <div>{{ element.defaultAmount }} {{ types[element.quantityType] }}</div>
                        </div>
                      </div>
                      <div>
                        <button type="button" @click="exercise.moves.splice(index, 1)" class="bg-gray-200 text-red-500 rounded px-3 py-2">
                          <svg xmlns="http://www.w3.org/2000/svg" class="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                            <path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" />
                          </svg>
                        </button>
                      </div>
                    </div>
                  </template>
                </draggable>
              </div>
            </div>
          </div>

          <div class="mb-4 flex flex-shrink-0 justify-end">
            <button type="submit" class="bg-green-500 text-white rounded px-3 py-2 w-full">Create Exercise</button>
          </div>
        </div>
      </form>
    </div>

    <MoveEditor :addMove="addMove" :addingMove="addingMove" :setAddingMove="setAddingMove"></MoveEditor>
  </div>
</template>

<style scoped>
.ghost {
  opacity: 0.5;
}
</style>

<script>
import draggable from "vuedraggable";
import MoveEditor from "./MoveEditor.vue";

export default {
  components: { draggable, MoveEditor },
  data() {
    return {
      exercise: {
        name: "",
        type: 0,
        equipment: "",
        moves: [],
      },
      exerciseSearch: {
        completedValue: "",
        searching: false,
      },
      addingMove: false,
      drag: false,
      types: {
        0: "Seconds",
        1: "Kilo",
      },
    };
  },
  setup() {},
  methods: {
    submit(event) {
      console.log(this.exercise.moves);
      event.preventDefault();
      this.$store.dispatch("CREATE_EXERCISE", {
        name: this.exercise.name,
        type: this.exercise.type,
        equipment: this.exercise.equipment,
        moves: this.exercise.moves,
      });
    },
    addMove(move) {
      this.exercise.moves.push({ ...move });
    },
    modifyDragItem(dataTransfer) {
      let img = new Image();
      dataTransfer.setDragImage(img, 0, 0);
    },
    setAddingMove(adding) {
      this.addingMove = adding;
    },
    searchKeyDownAutoComplete(event) {
      // was tab key pressed
      if (event.keyCode === 9) {
        // get first element in equipment_results
        let firstElement = document.getElementById("equipment_results").children[0];
        // get the value of the first element
        let value = firstElement.innerHTML;

        // check if the value does not equal the completedValue
        if (value !== this.exerciseSearch.completedValue) {
          // set the value of the input to the value
          this.exercise.equipment = value;
          // set completedValue to the value
          this.exerciseSearch.completedValue = value;
          // prevent the default behavior
          event.preventDefault();
        }
      }
    },
  },
  computed: {
    dragOptions() {
      return {
        animation: 200,
        group: "description",
        disabled: false,
        ghostClass: "ghost",
      };
    },
  },
};
</script>