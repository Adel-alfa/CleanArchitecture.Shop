

export interface PaginationParameters {
    currentPage: number;
    itemsPerPage: number;
    totalItems: number;
    totalPages: number;
}

export class PaginationResult<TData> {
    data: TData;
    paginationParameters: PaginationParameters | undefined;

    constructor(data: TData, paginationParameters: PaginationParameters) {
        this.data = data;
        this.paginationParameters = paginationParameters;
    }
}
export class PaginationRequestParameters {
    pageSize: number;
    pageNumber: number;
    constructor(pageSize: number, pageNumber: number) {
        this.pageSize = pageSize;
        this.pageNumber = pageNumber;
    }
}