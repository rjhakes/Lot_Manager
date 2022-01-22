import { Spot } from './Spot';

export interface Lot
{
    id: string,
    lotName: string,
    phone: string,
    addrLine1: string,
    addrLin12: string | null,
    city: string,
    state: string,
    zip: string,
    spots: Spot[]
}