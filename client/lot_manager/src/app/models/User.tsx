import { Reservation } from "./Reservation";
import { Vehicle } from "./Vehicle";

export interface User {
    id: string,
    fName: string,
    lName: string,
    dob: Date,
    vehicles: Vehicle[],
    reservations: Reservation[],
    email: string,
    phone: string,
    addrLine1: string,
    addrLine2: string | null,
    city: string,
    state: string,
    zip: string,
    eName: string,
    ePhone: string,
    eAddrLine1: string,
    eAddrLine2: string | null,
    eCity: string,
    eState: string,
    eZip: string,
}