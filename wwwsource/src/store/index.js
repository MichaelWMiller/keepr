import vue from 'vue';
import vuex from 'vuex'
//var production = !window.location.host.includes('localhost'); // FOR HEROKU
import axios from 'axios';
import router from '../router/index';
import authStore from './auth-store';

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

export default new vuex.Store({
    state: {
        user: {},
        vaults: [],
        keeps: []
    },
    modules: {
        authStore
    },
    mutations: {
        updateUser(state, payload) {
            state.user = payload
        },
        setVaults(state, payload) {
            state.vaults = payload
        },
        setKeeps(state, payload) {
            state.keeps = payload
        }
    },
    actions: {
        getVaults({ commit, dispatch }, payload) {
            api
                .get('vaults')
                .then(res => {
                    var vaults = res.data
                    commit('setVaults', vaults)
                })
                .catch(err => {
                    console.log(err)
                })
        },
        createVault({ commit, dispatch }, payload) {
            api.post('vault', payload)
                .then(res => {
                    dispatch('getVaults')
                })
        },
        getPublicKeeps({ commit, dispatch }, payload) {
            console.log("In getPublicKeeps")
            api
                .get('public/keep')
                .then(res => {
                    var keeps = res.data
                    commit('setKeeps', keeps)
                })
                .catch(err => {
                    console.log(err)
                })
        },
        getKeepById({ commit, dispatch }, payload) {
            api
                .get('keep')
                .then(res => {
                    var keeps = res.data
                    commit('setKeeps', keeps)
                    dispatch('updateViewCount(keep)')
                })
                .catch(err => {
                    console.log(err)
                })
        },
        updateViewCount({ commit, dispatch }, payload) {
            api
                .put('keep')
                .then(res => {
                    var keeps = res.data
                    commit('setKeeps', keeps)
                    dispatch('keepTheKeep')
                    dispatch('getKeepById')
                })
                .catch(err => {
                    console.log(err)
                })
        }

    }
});