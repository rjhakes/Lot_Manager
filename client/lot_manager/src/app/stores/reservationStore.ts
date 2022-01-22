import { ChangeEvent } from "react";
import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Reservation } from "../models/Reservation";
import { v4 as uuid } from "uuid"

export default class ReservationStore {
    reservationRegistry = new Map<string, Reservation>();
    selectedReservation: Reservation | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;

    constructor() {
        makeAutoObservable(this);
    }

    loadReservations = async () => {
        this.loadingInitial = true;
        try {
            const reservations = await agent.Reservations.list();
            reservations.forEach(reservation => {
                this.setReservation(reservation);
            })
            this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    loadReservation = async (id: string) => {
        let reservation = this.getReservation(id);
        if (reservation) {
            this.selectedReservation = reservation;
        } else {
            this.loadingInitial = true;
            try {
                reservation = await agent.Reservations.details(id);
                this.setReservation(reservation);
                this.selectedReservation = reservation;
                this.setLoadingInitial(false);
            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }

    private setReservation = (reservation: Reservation) => {
        this.reservationRegistry.set(reservation.id, reservation);
    }

    private getReservation = (id: string) => {
        return this.reservationRegistry.get(id);
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    selectReservation = (id: string) => {
        this.selectedReservation = this.reservationRegistry.get(id);
    }

    cancelSelectedReservation = () => {
        this.selectedReservation = undefined;
    }

    openForm = (id?: string) => {
        id ? this.selectReservation(id) : this.cancelSelectedReservation();
        this.editMode = true;
    }

    closeForm = () => {
        this.editMode = false;
    }

    createReservation = async (reservation: Reservation) => {
        this.loading = true;
        reservation.id = uuid();
        try {
            await agent.Reservations.create(reservation);
            runInAction(() => {
                this.reservationRegistry.set(reservation.id, reservation);
                this.selectedReservation = reservation;
                this.editMode = false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    } 

    updateReservation = async (reservation: Reservation) => {
        this.loading = true;
        try {
            await agent.Reservations.update(reservation);
            runInAction(() => {
                this.reservationRegistry.set(reservation.id, reservation);
                this.selectedReservation = reservation;
                this.editMode = false;
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteReservation = async (id: string) => {
        this.loading = true;
        try {
            await agent.Reservations.delete(id);
            runInAction(() => {
                this.reservationRegistry.delete(id);
                // if (this.selectedReservation?.id === id) this.cancelSelectedReservation();
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteAllReservations = async () => {
        this.loading = true;
        try {
            this.reservationRegistry.forEach(async reservation => {
                this.deleteReservation(reservation.id);
            });
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
}