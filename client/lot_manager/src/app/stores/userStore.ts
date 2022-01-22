import { ChangeEvent } from "react";
import { makeAutoObservable, runInAction } from "mobx";
import agent from "../api/agent";
import { User } from "../models/User";
import { v4 as uuid } from "uuid"

export default class UserStore {
    userRegistry = new Map<string, User>();
    selectedUser: User | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;

    constructor() {
        makeAutoObservable(this);
    }

    loadUsers = async () => {
        this.loadingInitial = true;
        try {
            const users = await agent.Users.list();
            users.forEach(user => {
                this.setUser(user);
            })
            this.setLoadingInitial(false);
        } catch (error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }

    loadUser = async (id: string) => {
        let user = this.getUser(id);
        if (user) {
            this.selectedUser = user;
        } else {
            this.loadingInitial = true;
            try {
                user = await agent.Users.details(id);
                this.setUser(user);
                this.selectedUser = user;
                this.setLoadingInitial(false);
            } catch (error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }

    private setUser = (user: User) => {
        this.userRegistry.set(user.id, user);
    }

    private getUser = (id: string) => {
        return this.userRegistry.get(id);
    }

    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    selectUser = (id: string) => {
        this.selectedUser = this.userRegistry.get(id);
    }

    cancelSelectedUser = () => {
        this.selectedUser = undefined;
    }

    openForm = (id?: string) => {
        id ? this.selectUser(id) : this.cancelSelectedUser();
        this.editMode = true;
    }

    closeForm = () => {
        this.editMode = false;
    }

    createUser = async (user: User) => {
        this.loading = true;
        user.id = uuid();
        try {
            await agent.Users.create(user);
            runInAction(() => {
                this.userRegistry.set(user.id, user);
                this.selectedUser = user;
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

    updateUser = async (user: User) => {
        this.loading = true;
        try {
            await agent.Users.update(user);
            runInAction(() => {
                this.userRegistry.set(user.id, user);
                this.selectedUser = user;
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

    deleteUser = async (id: string) => {
        this.loading = true;
        try {
            await agent.Users.delete(id);
            runInAction(() => {
                this.userRegistry.delete(id);
                // if (this.selectedUser?.id === id) this.cancelSelectedUser();
                this.loading = false;
            })
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }

    deleteAllUsers = async () => {
        this.loading = true;
        try {
            this.userRegistry.forEach(async user => {
                this.deleteUser(user.id);
            });
        } catch (error) {
            console.log(error);
            runInAction(() => {
                this.loading = false;
            })
        }
    }
}