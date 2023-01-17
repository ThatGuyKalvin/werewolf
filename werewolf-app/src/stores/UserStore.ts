import { defineStore } from 'pinia'

// You can name the return value of `defineStore()` anything you want, 
// but it's best to use the name of the store and surround it with `use` 
// and `Store` (e.g. `useUserStore`, `useCartStore`, `useProductStore`)
// the first argument is a unique id of the store across your application
export const useUserStore = defineStore('user', {
    state: () => ({
        name: 'Default Name',
        sessionId: '000A',
        isHost: false
    }),
    getters: {
    },
    actions: {
        setName(name: string) {
            this.name = name
        },
        setSessionId(sessionId: string) {
            this.sessionId = sessionId
        },
        setIsHost(isHost: boolean) {
            this.isHost = isHost
        },
    },
})