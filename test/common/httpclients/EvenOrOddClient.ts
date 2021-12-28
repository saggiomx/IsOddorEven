import { AxiosResponse } from "axios";
import Httpclient from './baseHttpClient'

export default class EvenOrOddClient extends Httpclient {
    constructor() {
        super('https://localhost:5001')
    }

    getIsOddOrEven = (value: number) => this.instance.get<AxiosResponse>(`/isoddoreven/${value}`);

    getIsOdd = (value: number) => this.instance.get<AxiosResponse>(`/isodd/${value}`);
    
    getIsEven = (value: number) => this.instance.get<AxiosResponse>(`/iseven/${value}`);
}



