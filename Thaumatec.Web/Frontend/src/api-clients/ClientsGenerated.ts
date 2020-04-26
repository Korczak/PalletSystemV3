﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.4.2.0 (NJsonSchema v10.1.11.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export class UsersFrontend {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    register(input: UserRegisterRequest | null): Promise<UserRegisterResponse> {
        let url_ = this.baseUrl + "/api/users";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(input);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processRegister(_response);
        });
    }

    protected processRegister(response: Response): Promise<UserRegisterResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 201) {
            return response.text().then((_responseText) => {
            let result201: any = null;
            let resultData201 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result201 = UserRegisterResponse.fromJS(resultData201);
            return result201;
            });
        } else if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = UserRegisterResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<UserRegisterResponse>(<any>null);
    }
}

export class SelfFrontend {
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

export class DeviceFrontend {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "";
    }

    getDevicesForUser(): Promise<GetUserDevicesResponse> {
        let url_ = this.baseUrl + "/api/devices";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetDevicesForUser(_response);
        });
    }

    protected processGetDevicesForUser(response: Response): Promise<GetUserDevicesResponse> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
            let result200: any = null;
            let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
            result200 = GetUserDevicesResponse.fromJS(resultData200);
            return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<GetUserDevicesResponse>(<any>null);
    }

    addNewDevice(name: string | null | undefined, location: string | null | undefined, serialNumber: string | null | undefined): Promise<FileResponse | null> {
        let url_ = this.baseUrl + "/api/devices?";
        if (name !== undefined)
            url_ += "name=" + encodeURIComponent("" + name) + "&";
        if (location !== undefined)
            url_ += "location=" + encodeURIComponent("" + location) + "&";
        if (serialNumber !== undefined)
            url_ += "serialNumber=" + encodeURIComponent("" + serialNumber) + "&";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "POST",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processAddNewDevice(_response);
        });
    }

    protected processAddNewDevice(response: Response): Promise<FileResponse | null> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200 || status === 206) {
            const contentDisposition = response.headers ? response.headers.get("content-disposition") : undefined;
            const fileNameMatch = contentDisposition ? /filename="?([^"]*?)"?(;|$)/g.exec(contentDisposition) : undefined;
            const fileName = fileNameMatch && fileNameMatch.length > 1 ? fileNameMatch[1] : undefined;
            return response.blob().then(blob => { return { fileName: fileName, data: blob, status: status, headers: _headers }; });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
            return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<FileResponse | null>(<any>null);
    }
}

export class UserRegisterResponse implements IUserRegisterResponse {
    status!: UserRegisterStatus;
    username?: string | null;
    temporaryPassword?: string | null;

    constructor(data?: IUserRegisterResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.status = _data["status"] !== undefined ? _data["status"] : <any>null;
            this.username = _data["username"] !== undefined ? _data["username"] : <any>null;
            this.temporaryPassword = _data["temporaryPassword"] !== undefined ? _data["temporaryPassword"] : <any>null;
        }
    }

    static fromJS(data: any): UserRegisterResponse {
        data = typeof data === 'object' ? data : {};
        let result = new UserRegisterResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["status"] = this.status !== undefined ? this.status : <any>null;
        data["username"] = this.username !== undefined ? this.username : <any>null;
        data["temporaryPassword"] = this.temporaryPassword !== undefined ? this.temporaryPassword : <any>null;
        return data; 
    }
}

export interface IUserRegisterResponse {
    status: UserRegisterStatus;
    username?: string | null;
    temporaryPassword?: string | null;
}

export enum UserRegisterStatus {
    Success = "Success",
    UserExists = "UserExists",
    UsernameIsEmpty = "UsernameIsEmpty",
    UsernameContainsWhitespace = "UsernameContainsWhitespace",
}

export class UserRegisterRequest implements IUserRegisterRequest {
    username?: string | null;
    role!: Role;

    constructor(data?: IUserRegisterRequest) {
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
            this.role = _data["role"] !== undefined ? _data["role"] : <any>null;
        }
    }

    static fromJS(data: any): UserRegisterRequest {
        data = typeof data === 'object' ? data : {};
        let result = new UserRegisterRequest();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["username"] = this.username !== undefined ? this.username : <any>null;
        data["role"] = this.role !== undefined ? this.role : <any>null;
        return data; 
    }
}

export interface IUserRegisterRequest {
    username?: string | null;
    role: Role;
}

export enum Role {
    Unknown = "Unknown",
    User = "User",
    Admin = "Admin",
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
        return data; 
    }
}

export interface IUserLoginResponse {
    result: UserLoginResult;
    userId?: string | null;
    username?: string | null;
    role: Role;
}

export class GetUserDevicesResponse implements IGetUserDevicesResponse {
    devices?: GetUserDeviceItem[] | null;

    constructor(data?: IGetUserDevicesResponse) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
            if (data.devices) {
                this.devices = [];
                for (let i = 0; i < data.devices.length; i++) {
                    let item = data.devices[i];
                    this.devices[i] = item && !(<any>item).toJSON ? new GetUserDeviceItem(item) : <GetUserDeviceItem>item;
                }
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            if (Array.isArray(_data["devices"])) {
                this.devices = [] as any;
                for (let item of _data["devices"])
                    this.devices!.push(GetUserDeviceItem.fromJS(item));
            }
        }
    }

    static fromJS(data: any): GetUserDevicesResponse {
        data = typeof data === 'object' ? data : {};
        let result = new GetUserDevicesResponse();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        if (Array.isArray(this.devices)) {
            data["devices"] = [];
            for (let item of this.devices)
                data["devices"].push(item.toJSON());
        }
        return data; 
    }
}

export interface IGetUserDevicesResponse {
    devices?: IGetUserDeviceItem[] | null;
}

export class GetUserDeviceItem implements IGetUserDeviceItem {
    name?: string | null;
    lastUpdateDateTime!: string;
    lastPrintDateTime!: string;
    status!: DeviceStatus;

    constructor(data?: IGetUserDeviceItem) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.name = _data["name"] !== undefined ? _data["name"] : <any>null;
            this.lastUpdateDateTime = _data["lastUpdateDateTime"] !== undefined ? _data["lastUpdateDateTime"] : <any>null;
            this.lastPrintDateTime = _data["lastPrintDateTime"] !== undefined ? _data["lastPrintDateTime"] : <any>null;
            this.status = _data["status"] !== undefined ? _data["status"] : <any>null;
        }
    }

    static fromJS(data: any): GetUserDeviceItem {
        data = typeof data === 'object' ? data : {};
        let result = new GetUserDeviceItem();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["name"] = this.name !== undefined ? this.name : <any>null;
        data["lastUpdateDateTime"] = this.lastUpdateDateTime !== undefined ? this.lastUpdateDateTime : <any>null;
        data["lastPrintDateTime"] = this.lastPrintDateTime !== undefined ? this.lastPrintDateTime : <any>null;
        data["status"] = this.status !== undefined ? this.status : <any>null;
        return data; 
    }
}

export interface IGetUserDeviceItem {
    name?: string | null;
    lastUpdateDateTime: string;
    lastPrintDateTime: string;
    status: DeviceStatus;
}

export enum DeviceStatus {
    NotAuthenticated = "NotAuthenticated",
    Active = "Active",
    Printing = "Printing",
    Aborting = "Aborting",
}

export interface FileResponse {
    data: Blob;
    status: number;
    fileName?: string;
    headers?: { [name: string]: any };
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