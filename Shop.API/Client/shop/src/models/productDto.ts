export interface ProductDto {
    id: number | undefined,
    name: string,
    description: string,
    creationDate: string | undefined,
    modificationDate: string | undefined,
    price: number | undefined,
    quantity: number | undefined,
    categoryId: number | undefined,
    categoryName: string
}