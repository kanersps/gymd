import {
    createStore
} from 'vuex';
import * as Authentication from "./actions/Authentication";
import * as Exercise from "./actions/Exercise";

const store = createStore({
    state() {
        return {
            ...Authentication.State
        }
    },
    mutations: {
        ...Authentication.Mutations
    },
    actions: {
        ...Authentication.Actions,
        ...Exercise.Actions
    }
});

export default store;