import { ChangeEventHandler, createContext, useContext } from "react";
import LotStore from "./lotStore";
import SpotStore from "./spotStore";
import ReservationStore from "./reservationStore";
import UserStore from "./userStore";

interface Store {
    lotStore: LotStore;
    spotStore: SpotStore;
    reservationStore: ReservationStore;
    userStore: UserStore;
}

export const store: Store = {
    lotStore: new LotStore(),
    spotStore: new SpotStore(),
    reservationStore: new ReservationStore(),
    userStore: new UserStore()
}

export const StoreContext = createContext(store);

export function useStore() {
    return useContext(StoreContext);
}

// export function handleFileSelect(e: ChangeEventHandler<HTMLInputElement>) {
//     const file = null;

//     return file;
// }