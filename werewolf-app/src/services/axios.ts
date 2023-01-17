import axios from 'axios'

export default (url='https://localhost:5002/game') => {
    return axios.create({
        baseURL: url,
    })
}