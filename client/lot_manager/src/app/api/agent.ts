import axios, { AxiosResponse } from 'axios';
import sleep from './sleep';
import { Lot } from '../models/Lot'
import { Spot } from '../models/Spot'
import { Reservation } from '../models/Reservation'
import { User } from '../models/User'

axios.defaults.baseURL = 'http://localhost:5000/api';

axios.interceptors.response.use(async response => {
    try {
        await sleep(1000);
        return response;
    } catch (error) {
        console.log(error);
        return await Promise.reject(error);
    }
})

const responseBody = <T> (response: AxiosResponse<T>) => response.data

const requests = {
    get: <T> (url: string) => axios.get<T>(url).then(responseBody), 
    post: <T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody), 
    put: <T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody), 
    del: <T> (url: string) => axios.delete<T>(url).then(responseBody), 
}

const Lots = {
    list: () => requests.get<Lot[]>('/Lot'),
    details: (id: string) => requests.get<Lot>(`/Lot/${id}`),
    create: (lot: Lot) => axios.post<void>('/Lot', lot),
    update: (lot: Lot) => axios.put<void>(`/Lot/${lot.id}`, lot),
    delete: (id: string) => axios.delete<void>(`/Lot/${id}`)
}

const Spots = {
    list: () => requests.get<Spot[]>('/Spot'),
    details: (id: string) => requests.get<Spot>(`/Spot/${id}`),
    create: (spot: Spot) => axios.post<void>('/Spot', spot),
    update: (spot: Spot) => axios.put<void>(`/Spot/${spot.id}`, spot),
    delete: (id: string) => axios.delete<void>(`/Spot/${id}`)
}

const Reservations = {
    list: () => requests.get<Reservation[]>('/Reservation'),
    details: (id: string) => requests.get<Reservation>(`/Reservation/${id}`),
    create: (reservation: Reservation) => axios.post<void>('/Reservation', reservation),
    update: (reservation: Reservation) => axios.put<void>(`/Reservation/${reservation.id}`, reservation),
    delete: (id: string) => axios.delete<void>(`/Reservation/${id}`)
}

const Users = {
    list: () => requests.get<User[]>('/User'),
    details: (id: string) => requests.get<User>(`/User/${id}`),
    create: (user: User) => axios.post<void>('/User', user),
    update: (user: User) => axios.put<void>(`/User/${user.id}`, user),
    delete: (id: string) => axios.delete<void>(`/User/${id}`)
}

const agent = {
    Lots,
    Spots,
    Reservations,
    Users
}

export default agent;