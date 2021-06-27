const apiUrl = "http://localhost:5000/api/"
export default {
    post(endpoint, data) {
        return fetch(apiUrl + endpoint, {
            method: "POST",
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(data)
        })
    }
}
