import store from "./store/AppStore";

const apiUrl = "http://localhost:5000/api/"

export default {
    post(endpoint, data) {
        const authenticated = {};

        if (store.state.loggedIn) {
            authenticated.Authorization = store.state.token;
        }

        return fetch(apiUrl + endpoint, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json',
                ...authenticated
            },
            body: JSON.stringify(data)
        }).catch().then(response => {
            return response.json();
        });
    },
    get(endpoint, data) {
        const authenticated = {};

        if (store.state.loggedIn) {
            authenticated.Authorization = store.state.token;
        }

        return fetch(apiUrl + endpoint, {
            method: "GET",
            headers: {
                'Content-Type': 'application/json',
                ...authenticated
            },
            body: JSON.stringify(data)
        }).catch().then(response => response.json());
    }
}