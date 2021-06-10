import { createStore } from 'vuex';

const store = createStore({
    state() {
        return {
            loggedIn: false
        }
    },
    mutations: {
        setLoggedIn(state, payload) {
            state.loggedIn = payload;
        }
    }
});

export default store;
