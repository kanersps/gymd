import {createStore} from 'vuex';
import * as Authentication from "./actions/Authentication";

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
        ...Authentication.Actions
    }
});

export default store;
