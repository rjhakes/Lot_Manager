import { Lot } from './Lot';
import { Reservation } from './Reservation';

export interface Spot
{
    id: string,
    lot: Lot,
    number: number,
    reservation: Reservation[]
}