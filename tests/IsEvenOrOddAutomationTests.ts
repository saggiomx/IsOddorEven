import { Selector } from 'testcafe'
import EvenOrOddClient  from './httpClients/EvenOrOddClient'
import { Logger } from "tslog";

fixture `IsEvenOrOddApiTest`;

test('IsEvenOrOdd Method Api Tests', async t => {
    process.env.NODE_TLS_REJECT_UNAUTHORIZED='0';
    const log: Logger = new Logger();
    const value: number = 2;
    let evenOrOddClient = new EvenOrOddClient();
    const result = await evenOrOddClient.getIsOddOrEven(value);
    log.silly(`the ${value} for 'getIsEven' method is ${result.data}`);
    await t
        .expect(200).eql(result.status, `result.Status missmatch, expected:200, actual ${result.status}`)
        .expect('OK').eql(result.statusText)
        .expect('Even').eql(result.data);
});

test('IsEven Method Api Tests', async t => {
    process.env.NODE_TLS_REJECT_UNAUTHORIZED='0';
    const log: Logger = new Logger();
    const value: number = 2;
    let evenOrOddClient = new EvenOrOddClient();
    const result = await evenOrOddClient.getIsEven(value);
    log.silly(`the ${value} for 'getIsEven' method is ${result.data}`);
    await t
        .expect(200).eql(result.status, `result.Status missmatch, expected:200, actual ${result.status}`)
        .expect('OK').eql(result.statusText)
        .expect(false).eql(result.data);
});

test('IsOdd Method Api Tests', async t => {
    process.env.NODE_TLS_REJECT_UNAUTHORIZED='0';
    const log: Logger = new Logger();
    const value: number = 2;
    let evenOrOddClient = new EvenOrOddClient();
    const result = await evenOrOddClient.getIsOdd(value);
    log.silly(`the ${value} for 'getIsOdd' method is ${result.data}`);
    await t
        .expect(200).eql(result.status, `result.Status missmatch, expected:200, actual ${result.status}`)
        .expect('OK').eql(result.statusText)
        .expect(true).eql(result.data);
});