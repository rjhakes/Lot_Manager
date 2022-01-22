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

    
}