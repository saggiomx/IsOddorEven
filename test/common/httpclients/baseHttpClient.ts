import axios, { AxiosInstance, AxiosResponse } from 'axios';

declare module 'axios' {
    interface AxiosResponse<T = any> extends Promise<T> { }
}

export default abstract class Httpclient {
    protected instance: AxiosInstance;
    constructor(baseURL: string) {
        this.instance = axios.create({ baseURL });
    }
}


