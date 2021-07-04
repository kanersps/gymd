import {
    createStore
} from 'vuex';
import * as Authentication from "./actions/Authentication";
import * as Exercise from "./actions/Exercise";

const store = createStore({
    state() {
        return {
            ...Authentication.State,
            ...Exercise.State
        }
    },
    mutations: {
        ...Authentication.Mutations,
        ...Exercise.Mutations
    },
    actions: {
        ...Authentication.Actions,
        ...Exercise.Actions
    }
});

export default store;