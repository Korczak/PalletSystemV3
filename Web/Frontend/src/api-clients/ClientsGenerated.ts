﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.4.2.0 (NJsonSchema v10.1.11.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class SelfClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    login(request: UserLoginRequest | null): Promise<UserLoginResult> {
        let url_ = this.baseUrl + "/api/self/login";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(request);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processLogin(_response);
        });
    }

    protected processLogin(response: Response): Promise<UserLoginResult> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = resultData200 !== undefined ? resultData200 : <any>null;
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<UserLoginResult>(<any>null);
    }

    logout(): Promise<void> {
        let url_ = this.baseUrl + "/api/self/logout";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "POST",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processLogout(_response);
        });
    }

    protected processLogout(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            return;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<void>(<any>null);
    }

    getCurrentUser(): Promise<UserLoginResponse> {
        let url_ = this.baseUrl + "/api/self";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetCurrentUser(_response);
        });
    }

    protected processGetCurrentUser(response: Response): Promise<UserLoginResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = UserLoginResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<UserLoginResponse>(<any>null);
    }
}

export enum UserLoginResult {
    Success = "Success",
    PasswordOrUsernameError = "PasswordOrUsernameError",
}

export class UserLoginRequest implements IUserLoginRequest {
    username?: string | null;
    password?: string | null;

    constructor(data?: IUserLoginRequest) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.username = _data["username"] !== undefined ? _data["username"] : <any>null;
            this.password = _data["password"] !== undefined ? _data["password"] : <any>null;
        }
    }

    static fromJS(data: any): UserLoginRequest {
        data = typeof data === 'object' ? data : {};
        let result = new UserLoginRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["username"] = this.username !== undefined ? this.username : <any>null;
        data["password"] = this.password !== undefined ? this.password : <any>null;
        return data; 
    }
}

export interface IUserLoginRequest {
    username?: string | null;
    password?: string | null;
}

export class UserLoginResponse implements IUserLoginResponse {
    result!: UserLoginResult;
    userId?: string | null;
    username?: string | null;
    role!: Role;
    firstLogin!: boolean;

    constructor(data?: IUserLoginResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.result = _data["result"] !== undefined ? _data["result"] : <any>null;
            this.userId = _data["userId"] !== undefined ? _data["userId"] : <any>null;
            this.username = _data["username"] !== undefined ? _data["username"] : <any>null;
            this.role = _data["role"] !== undefined ? _data["role"] : <any>null;
            this.firstLogin = _data["firstLogin"] !== undefined ? _data["firstLogin"] : <any>null;
        }
    }

    static fromJS(data: any): UserLoginResponse {
        data = typeof data === 'object' ? data : {};
        let result = new UserLoginResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["result"] = this.result !== undefined ? this.result : <any>null;
        data["userId"] = this.userId !== undefined ? this.userId : <any>null;
        data["username"] = this.username !== undefined ? this.username : <any>null;
        data["role"] = this.role !== undefined ? this.role : <any>null;
        data["firstLogin"] = this.firstLogin !== undefined ? this.firstLogin : <any>null;
        return data; 
    }
}

export interface IUserLoginResponse {
    result: UserLoginResult;
    userId?: string | null;
    username?: string | null;
    role: Role;
    firstLogin: boolean;
}

export enum Role {
    Unknown = "Unknown",
    User = "User",
    Operator = "Operator",
    Admin = "Admin",
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}