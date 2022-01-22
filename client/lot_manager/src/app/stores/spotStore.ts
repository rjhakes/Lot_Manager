import { ChangeEvent } from "react";
import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Spot } from "../models/Spot";
import { v4 as uuid } from "uuid"

export default class SpotStore {
    spotRegistry = new Map<string, Spot>();
    selectedSpot: Spot | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;

    constructor() {
        makeAutoObservable(this);
    }

    loadSpots = async () => {
        this.loadingInitial = true;
        try {
            const spots = await agent.Spots.list();
            spots.forEach(spot => {
                this.setSpot(spot);
            })
            this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    loadSpot = async (id: string) => {
        let spot = this.getSpot(id);
        if (spot) {
            this.selectedSpot = spot;
        } else {
            this.loadingInitial = true;
            try {
                spot = await agent.Spots.details(id);
                this.setSpot(spot);
                this.selectedSpot = spot;
                this.setLoadingInitial(false);
            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }

    private setSpot = (spot: Spot) => {
        this.spotRegistry.set(spot.id, spot);
    }

    private getSpot = (id: string) => {
        return this.spotRegistry.get(id);
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    selectSpot = (id: string) => {
        this.selectedSpot = this.spotRegistry.get(id);
    }

    cancelSelectedSpot = () => {
        this.selectedSpot = undefined;
    }

    openForm = (id?: string) => {
        id ? this.selectSpot(id) : this.cancelSelectedSpot();
        this.editMode = true;
    }

    closeForm = () => {
        this.editMode = false;
    }

    createSpot = async (spot: Spot) => {
        this.loading = true;
        spot.id = uuid();
        try {
            await agent.Spots.create(spot);
            runInAction(() => {
                this.spotRegistry.set(spot.id, spot);
                this.selectedSpot = spot;
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

    updateSpot = async (spot: Spot) => {
        this.loading = true;
        try {
            await agent.Spots.update(spot);
            runInAction(() => {
                this.spotRegistry.set(spot.id, spot);
                this.selectedSpot = spot;
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

    deleteSpot = async (id: string) => {
        this.loading = true;
        try {
            await agent.Spots.delete(id);
            runInAction(() => {
                this.spotRegistry.delete(id);
                // if (this.selectedSpot?.id === id) this.cancelSelectedSpot();
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteAllSpots = async () => {
        this.loading = true;
        try {
            this.spotRegistry.forEach(async spot => {
                this.deleteSpot(spot.id);
            });
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
}