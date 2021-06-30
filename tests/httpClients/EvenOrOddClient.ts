import { AxiosResponse } from 'axios';
import HttpClient from './common/httpClient';

export default class EvenOrOddClient extends HttpClient {
    constructor() {
        super('https://localhost:5001')
    }

    getIsOddOrEven = (value: number) => this.instance.get<AxiosResponse>(`/isoddoreven/${value}`);

    getIsOdd = (value: number) => this.instance.get<AxiosResponse>(`/iseven/${value}`);

    getIsEven = (value: number) => this.instance.get<AxiosResponse>(`/isodd/${value}`);
}