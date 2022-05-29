export class NewsItemDTO {
    constructor(
        public id: number,
        public title: string,
        public author: string,
        public imageName: string,
        public categoryId: number,
        public categoryName: string,
        public text: string
    ) {
    }
}
