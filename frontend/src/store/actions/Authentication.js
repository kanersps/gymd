import api from "../../api";
import router from "../../router";

export const ACTIONS = Object.freeze({
    LOGIN: "AUTHENTICATION_LOGIN"
})

export const State = {
    loggedIn: false,
    loggingIn: false,
    token: "",
    loginError: ""
}

export const Mutations = {
    setLoggedIn(state, payload) {
        state.loggedIn = payload;
    },
    setToken(state, payload) {
        state.token = payload;
    },
    setLoginError(state, payload) {
        state.loginError = payload;
    },
    setLoggingIn(state, payload) {
        state.loggingIn = payload;
    }
}

export const Actions = {
    [ACTIONS.LOGIN]({
        commit
    }, payload) {
        commit('setLoginError', "");
        commit('setLoggingIn', true);

        api.post("account/login", {
            email: payload.email,
            password: payload.password
        }).then(response => {
            if (response.success) {
                commit('setToken', response.token);
                commit('setLoggedIn', true);

                router.push('/account/dashboard');
            } else {
                commit('setLoginError', response.error)
            }

            commit('setLoggingIn', false);
        }).catch(e => {
            commit('setLoggingIn', false);
            commit('setLoginError', "We were unable to connect to GymT, raw message: " + String(e))
        })
    }
}