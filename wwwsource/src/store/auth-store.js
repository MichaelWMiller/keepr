import vue from "vue";
import vuex from "vuex";
import axios from "axios";
import router from "../router"

var api = axios.create({
    baseURL: "//localhost:5000/api/",
    timeout: 5000,
    withCredentials: true
});

var account = axios.create({
    baseURL: "//localhost:5000/account/",
    timeout: 5000,
    withCredentials: true
});

vue.use(vuex);

const authstore = {
    state: {
        user: {}
    },
    mutations: {
        updateUser(state, payload) {

            state.user = payload;
        },
        clearData(state, payload) {
            state.user = {}
        }
    },
    actions: {
        createUser({ commit, dispatch }, payload) {
            account.post("register", payload).then(res => {
                    commit('updateUser', res.data)
                })
                .catch(err => {
                    console.log(err)
                })
        },
        login({ commit, dispatch }, payload) {
            account
                .post("login", payload)
                .then(user => {
                    commit("updateUser", user.data)
                    console.log(user.data)
                    router.push({ name: "Home" })
                })
                .catch(err => {
                    router.push({ name: "Login" })
                    console.log('Invalid username or password')
                })
        },
        changePassword({ commit, dispatch }, payload) {
            account
                .put("change-password", payload)
                .then(user => {
                    commit("updateUser", user.data)
                    console.log(user.data)
                    router.push({ name: "Home " })
                })
                .catch(err => {
                    console.log('Uh oh..change password didnt work...')
                })
        },

        authenticate({ commit, dispatch }, payload) {
            account.get('authenticate')
                .then(res => {
                    console.log('AUTH SESSION', res.data)
                    commit('updateUser', res.data)
                })
                .catch(err => {
                    console.log(err)
                })
        },
        logout({ commit, dispatch }, payload) {
            account.delete('logout')
                .then(res => {
                    commit('updateUser', {})
                    commit('clearData', {})
                })
                .catch(err => {
                    console.log(err)
                })
        }
    }
};

export default authstore;