import { Spot } from "./Spot";
import { User } from "./User";


export interface Reservation
{
    id: string,
    spot: Spot,
    user: User,
    startDate: Date,
    endDate: Date,
    description: string | null,
    review: string | null,
}