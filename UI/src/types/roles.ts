export enum RoleEnum {
  User=  'user' ,
  Admin=   'admin'
}

export type Role = RoleEnum.Admin | RoleEnum.User

export interface User {
    id: number;
    name: string;
    email: string;
    role: string;
    status: string;
    joinDate: string;
    movies: number;
    lastActive: string;
}