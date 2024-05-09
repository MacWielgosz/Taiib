export enum TypeEnum {
    Admin = 0,
    Casual = 1
}

export interface UserDTO {
    iD: number;
    login: string;
    password: string;
    isActive: boolean;
    type: TypeEnum;
}