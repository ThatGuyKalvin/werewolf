import axios from './axios'

export default {
    validateSession(sessionId: string) {
        return axios().get(`/Session?sessionId=${sessionId}`)
    },
    createSession(userId: string) {
        return axios().post(`/Session?userId=${userId}`)
    }
}