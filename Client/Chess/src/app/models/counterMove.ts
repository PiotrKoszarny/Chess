import { CounterEnum } from './counterEnum';
import { Movement } from '../movement';

export interface CounterMove {
    move?: Movement;
    counter?: CounterEnum;
}
