import { CounterEnum } from './counterEnum';
import { FieldPosition } from './fieldPosition';

export interface Counter {
    imgName?: string;
    counter?: CounterEnum;
    position?: FieldPosition;
    isSelected?: boolean;
}
