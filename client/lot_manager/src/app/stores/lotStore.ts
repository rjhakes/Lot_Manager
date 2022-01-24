import { ChangeEvent } from "react";
import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { Lot } from "../models/Lot";
import { v4 as uuid } from "uuid"

export default class LotStore {
    lotRegistry = new Map<string, Lot>();
    selectedLot: Lot | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;

    constructor() {
        makeAutoObservable(this);
    }

    get lots() {
        return Array.from(this.lotRegistry.values());
    }

    loadLots = async () => {
        this.loadingInitial = true;
        try {
            const lots = await agent.Lots.list();
            lots.forEach(lot => {
                this.setLot(lot);
            })
            this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    loadLot = async (id: string) => {
        let lot = this.getLot(id);
        if (lot) {
            this.selectedLot = lot;
        } else {
            this.loadingInitial = true;
            try {
                lot = await agent.Lots.details(id);
                this.setLot(lot);
                this.selectedLot = lot;
                this.setLoadingInitial(false);
            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }

    private setLot = (lot: Lot) => {
        this.lotRegistry.set(lot.id, lot);
    }

    private getLot = (id: string) => {
        return this.lotRegistry.get(id);
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    selectLot = (id: string) => {
        this.selectedLot = this.lotRegistry.get(id);
    }

    cancelSelectedLot = () => {
        this.selectedLot = undefined;
    }

    openForm = (id?: string) => {
        id ? this.selectLot(id) : this.cancelSelectedLot();
        this.editMode = true;
    }

    closeForm = () => {
        this.editMode = false;
    }

    createLot = async (lot: Lot) => {
        this.loading = true;
        lot.id = uuid();
        try {
            await agent.Lots.create(lot);
            runInAction(() => {
                this.lotRegistry.set(lot.id, lot);
                this.selectedLot = lot;
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

    updateLot = async (lot: Lot) => {
        this.loading = true;
        try {
            await agent.Lots.update(lot);
            runInAction(() => {
                this.lotRegistry.set(lot.id, lot);
                this.selectedLot = lot;
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

    deleteLot = async (id: string) => {
        this.loading = true;
        try {
            await agent.Lots.delete(id);
            runInAction(() => {
                this.lotRegistry.delete(id);
                // if (this.selectedLot?.id === id) this.cancelSelectedLot();
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteAllLots = async () => {
        this.loading = true;
        try {
            this.lotRegistry.forEach(async lot => {
                this.deleteLot(lot.id);
            });
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
}