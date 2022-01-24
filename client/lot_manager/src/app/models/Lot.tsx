import { Spot } from './Spot';

export interface Lot
{
    id: string,
    lotName: string,
    phone: string,
    addrLine1: string,
    addrLine2: string | null,
    city: string,
    state: string,
    zip: string,
    spots: Spot[]
}