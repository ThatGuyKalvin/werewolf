import axios from './axios'

export default {
    validateSessionOld(sessionId: string) {
        return axios().get(`/Session?sessionId=${sessionId}`)
    },
    async validateSession(sessionId: string) {
        try {
            const response = await axios().get(`/Session?sessionId=${sessionId}`);
            if (response.status === 200) {
                return true;
            } else {
                return false;
            }
        } catch (error) {
            return false;
        }
    },
    createSession(userId: string) {
        return axios().post(`/Session?userId=${userId}`)
    }
}