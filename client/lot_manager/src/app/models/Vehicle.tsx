import { User } from "./User";

export interface Vehicle
{
    id: string,
    make: string,
    model: string,
    licensePlate: string,
    state: string,
    userId: string,
    user: User
}