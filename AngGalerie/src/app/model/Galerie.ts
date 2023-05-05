import { Picture } from './Picture';
export class Galerie {
    constructor( public id:number, public name: string,
        public isPublic: boolean, public pictures?: Picture[]) {

    }
}
