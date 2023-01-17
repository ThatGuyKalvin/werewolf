import { createRouter, createWebHistory } from 'vue-router'
import SessionOptions from '@/components/SessionOptions.vue'
import JoinSessionForm from '@/components/JoinSessionForm.vue'
import GameAsPlayer from '@/components/GameAsPlayer.vue'

export default createRouter({
    history: createWebHistory(),
    routes: [
        {
            name: 'Home',
            path: '/',
            component: SessionOptions,
        },
        {
            name: 'GameAsPlayer',
            path: '/Play',
            component: GameAsPlayer,
        },
        {
            name: 'JoinSession',
            path: '/JoinSession',
            component: JoinSessionForm,
        },
        {
            name: 'CreateSession',
            path: '/CreateSession',
            component: JoinSessionForm,
        },
    ],
})
