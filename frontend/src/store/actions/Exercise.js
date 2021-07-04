import api from "../../api"

export const ACTIONS = Object.freeze({
  CREATE_EXERCISE: "CREATE_EXERCISE"
})

export const Actions = {
  // eslint-disable-next-line no-empty-pattern
  [ACTIONS.CREATE_EXERCISE]({}, payload) {
    api.post("exercise/creator/create", {
      name: payload.name,
      type: payload.type,
      equipment: payload.equipment,
      moves: payload.moves,
    })
  }
}