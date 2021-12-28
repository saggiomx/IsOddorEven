import { Selector } from 'testcafe';
import { Logger } from 'tslog';
import EvenOrOddClient from './common/httpclients/EvenOrOddClient';

fixture`IsEvenOrOddtests`

test('IsEvenOrOd Method Api Tests', async t => {
    process.env.Node_TLS_REJECT_UNAUTHORIZED='0';
    const log: Logger = new Logger();
    const value: number = 2;
    let evenOrOddClient = new EvenOrOddClient();

    const result = await evenOrOddClient.getIsOddOrEven(value);
    log.silly(`the ${value} for 'getIsEven' method is ${result.data}`);

    await t.expect(200).eql(result.status, `result.status missmatch, expected 200, actual ${result.status}`);
    await t.expect('Even').eql(result.data, `result.payload missmatch, expected Even, actual ${result.data}`);
});