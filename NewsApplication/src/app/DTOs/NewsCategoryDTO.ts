export class NewsCategoryDTO {
    constructor(
        public id: number,
        public imageAddress: string,
        public name: string,
        public order: number
    ) {
    }
}
