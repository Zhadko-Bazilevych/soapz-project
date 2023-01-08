import { BaseResponse } from "./baseResponse";

export interface User extends BaseResponse{
    Role: string;
    Token: string;
    Id: string;
    Mail: string;
}