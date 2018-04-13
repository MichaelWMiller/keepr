import Vue from 'vue'
import Router from 'vue-router'
import Home from '@/components/Home'
import Dashboard from '@/components/Dashboard'
import VaultList from '@/components/VaultList'
import Vault from '@/components/Vault'
import Keep from '@/components/Keep'

Vue.use(Router)

export default new Router({
    routes: [{
            path: '/',
            name: 'Home',
            component: Home
        },
        {
            path: '/account/login',
            name: 'Login',
            component: Dashboard
        },
        {
            path: '/api/keep',
            name: 'Keep',
            component: Home
        },
        {
            path: '/api/vault',
            name: 'VaultList',
            component: VaultList
        }
    ]
})