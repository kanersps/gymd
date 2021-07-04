import api from "../../api"
import router from "../../router"

export const Errors = {
  0: "None",
  1: "You forgot to fill in a value",

}

export const ACTIONS = Object.freeze({
  CREATE_EXERCISE: "CREATE_EXERCISE"
})

export const State = {
  exerciseCreateError: "",
  exerciseCreating: false
}

export const Mutations = {
  setExerciseCreationError(state, error) {
    state.exerciseCreateError = error
  },
  setExerciseCreating(state, bool) {
    state.exerciseCreating = bool
  }
}

export const Actions = {
  // eslint-disable-next-line no-empty-pattern
  [ACTIONS.CREATE_EXERCISE]({
    commit
  }, payload) {
    commit("setExerciseCreating", true)
    commit("setExerciseCreationError", "");

    api.post("creator/create", {
      name: payload.name,
      type: payload.type,
      equipment: payload.equipment,
      moves: payload.moves,
    }).then(e => {
      if (e.success) {
        router.push('/account/exercises');
        commit("setExerciseCreating", false)
      } else {
        commit("setExerciseCreationError", Errors[e.error]);
        commit("setExerciseCreating", false)
      }
    });
  }
}