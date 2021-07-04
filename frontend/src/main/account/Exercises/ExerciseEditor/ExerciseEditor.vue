<template>
  <div class="grid grid-cols-3 gap-3">
    <div class="col-span-1 bg-white shadow-md p-3">
      <span class="font-semibold flex-1 text-gray-800">Create Exercise</span>
      <form @submit="submit" class="pt-2">
        <div class="flex flex-col">
          <div class="flex-grow">
            <div class="mb-4">
              <label for="exercise_name" class="block text-gray-700 text-sm font-semibold mb-2">Exercise Name <span class="text-red-600">*</span></label>
              <input v-model="exercise.name" id="exercise_name" class="shadow appearance-none border rounded w-full py-2 px-3 text-gray-700 leading-tight focus:outline-none focus:shadow-outline" />
            </div>

            <div class="mb-4">
              <label for="exercise_type" class="text-gray-700 text-sm font-semibold mb-2 w-full flex justify-between">
                <span>Exercise Type <span class="text-red-600">*</span></span>
                <InfoHover>Select what type of equipment this exercise will use</InfoHover>
              </label>
              <select v-model="exercise.type" id="exercise_type" class="w-full shadow border py-2 px-3">
                <option :value="0">No Equipment</option>
                <option :value="1">Machine</option>
                <option :value="2">Free Weights</option>
              </select>
            </div>

            <OnClickOutside @trigger="close" v-show="exercise.type !== 0" class="mb-4 relative">
              <label for="exercise_equipment" class="text-gray-700 text-sm font-semibold mb-2 w-full flex justify-between">
                <span>Equipment <span class="text-red-600">*</span></span>
                <InfoHover>Start typing to find equipment, if your equipment wasn't found you can enter your own</InfoHover>
              </label>
              <input
                v-on:focus="exerciseSearch.search = true"
                autocomplete="off"
                v-on:keydown="searchKeyDownAutoComplete"
                v-model="exercise.equipment"
                id="exercise_equipment"
                class="w-full shadow border py-2 px-3"
              />

              <div v-show="exerciseSearch.search" class="bg-white shadow-lg hover:bg-gray-200 cursor-pointer absolute w-full px-3 py-2" id="equipment_results">
                <div v-if="exerciseSearch.searching">Searching...</div>
                <div v-else-if="exerciseSearch.searching === false && exerciseSearch.results.length === 0">Try typing to get results</div>
                <div
                  v-else
                  v-for="result in exerciseSearch.results"
                  :key="result"
                  class=""
                  @click="
                    exercise.equipment = result;
                    exerciseSearch.search = false;
                  "
                >
                  {{ result }}
                </div>
              </div>
            </OnClickOutside>

            <div class="mb-4">
              <label for="exercise_moves" class="text-gray-700 text-sm font-semibold mb-2 w-full flex justify-between">
                <span>Exercise Moves <span class="text-red-600">*</span></span>
                <InfoHover>Add here which 'moves' your exercise consists of</InfoHover>
              </label>
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

          <div class="mb-4 flex w-full h-14">
            <Error :message="exerciseCreateError"></Error>
          </div>

          <div class="mb-4 flex flex-shrink-0 justify-end">
            <button
              v-bind:disabled="addingExercise"
              class="w-full relative rounded bg-green-500 text-white disabled:cursor-default hover:bg-green-400 cursor-pointer transition duration:100 text-white text-lg p-2"
              type="submit"
            >
              <div class="relative items-center">
                <span> Create Exercise </span>
                <div class="absolute left-0 top-0">
                  <svg v-show="addingExercise" class="animate-spin ml-1 mb-1 mr-3 h-5 w-5 text-white inline-block" xmlns="http://www.w3.org/2000/svg" fill="none" viewBox="0 0 24 24">
                    <circle class="opacity-25" cx="12" cy="12" r="10" stroke="currentColor" stroke-width="4"></circle>
                    <path class="opacity-75" fill="currentColor" d="M4 12a8 8 0 018-8V0C5.373 0 0 5.373 0 12h4zm2 5.291A7.962 7.962 0 014 12H0c0 3.042 1.135 5.824 3 7.938l3-2.647z"></path>
                  </svg>
                </div>
              </div>
            </button>
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
import api from "../../../../api";
import { OnClickOutside } from "@vueuse/components";
import InfoHover from "../../../../components/ui/InfoHover.vue";
import Error from "../../../../components/ui/Error.vue";

export default {
  components: { draggable, MoveEditor, OnClickOutside, InfoHover, Error },
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
        search: false,
        searchTimer: null,
        results: [],
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
    close() {
      this.exerciseSearch.search = false;
    },
    submit(event) {
      event.preventDefault();
      this.addingExercise = true;
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
          // set search and searching to false
          this.exerciseSearch.search = false;
          this.exerciseSearch.searching = false;
          // prevent the default behavior
          event.preventDefault();
        }
      } else {
        clearInterval(this.exerciseSearch.searchTimer);
        this.startSearchForEquipment(this.exercise.equipment);
      }
    },
    startSearchForEquipment(term) {
      this.exerciseSearch.searching = true;
      this.exerciseSearch.search = true;

      // post to api to search for equipment
      this.exerciseSearch.searchTimer = setTimeout(() => {
        api.post("creator/search/equipment", term).then((results) => {
          this.exerciseSearch.results = results;
          this.exerciseSearch.searching = false;
        });
      }, 1000);
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
    addingExercise() {
      return this.$store.state.exerciseCreating;
    },
    exerciseCreateError() {
      return this.$store.state.exerciseCreateError;
    },
  },
};
</script>