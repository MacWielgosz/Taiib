export enum TypeEnum {
    Admin = 0,
    Casual = 1
}

export interface UserDTO {
    id: number;
    login: string;
    password: string;
    isActive: boolean;
    type: TypeEnum;
}