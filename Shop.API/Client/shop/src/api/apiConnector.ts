import  { AxiosResponse } from "axios"
import { GetProductResponse } from "../models/getProductResponse";
import { ProductDto } from "../models/productDto";
import { GetProductByIdResponse } from "../models/getProductByIdResponse";
import { CategoryDto } from "../models/categoryDto.ts";
import { GetCategoryResponse } from "../models/getCategoryResponse.ts";
import { GetCategoryByIdResponse } from "../models/GetCategoryByIdResponse.ts";
import { PaginationRequestParameters, PaginationResult } from "../models/paginationResponse.ts";
import axiosInstance from "./axiosInstance.ts";



const apiConnector = {

    getProducts: async(): Promise<ProductDto[]> => {
        try {
            const response: AxiosResponse<GetProductResponse> = await axiosInstance.get(`/products`);
            const products = response.data.productDtos.map(product => ({
                ...product,
                creationDate: product.creationDate?.slice(0, 10) ?? "",
                modificationDate: product.modificationDate?.slice(0, 10) ?? ""
            }));
            return products;
        }
        catch (error) {
            console.log('Error fetching data', error);
            throw error;
        }
    },

 
    getProductsPaginition: async (paginationRequestParams: PaginationRequestParameters): Promise<PaginationResult<ProductDto[]>> => {
        try {
            const response: AxiosResponse<PaginationResult<ProductDto[]>> =
                await axiosInstance.get(`/products/page?pageSize=${paginationRequestParams.pageSize}&pageNumber=${paginationRequestParams.pageNumber}`);
            if (response.data && Array.isArray(response.data.data)) {
                const modifiedData = response.data.data.map(product => ({
                    ...product,
                    creationDate: product.creationDate?.slice(0, 10) ?? "",
                    modificationDate: product.modificationDate?.slice(0, 10) ?? ""
                }));
                return {
                    ...response.data,
                    data: modifiedData
                }
            }
            else {
                return {
                    data: [],
                    paginationParameters: {
                        totalItems: 0,
                        totalPages: 0,
                        currentPage: 0,
                        itemsPerPage: 0
                    }
                };
            }
        }
        catch (error) {
            console.log('Error fetching data', error);
            throw error;
        }
    },
    createProduct: async (product: ProductDto): Promise<void> => {
        
        try {
            await axiosInstance.post<number>(`/products`, product);
        } catch (error: unknown) {
            if (error)
            console.error("Error fetching product by id:", error);
            ;
        }
        
      
    },
    editProduct: async (product: ProductDto): Promise<void> => {
       
        await axiosInstance.put<number>(`/products/${product.id}`, product);
       
    },
    deleteProduct: async (productId: number): Promise<void> => {
       
        await axiosInstance.delete<number>(`/products/${productId}`);
      
    },
    getProductById: async (movieId: string): Promise<ProductDto | undefined> => {
        const response = await axiosInstance.get<GetProductByIdResponse>(`/products/${movieId}`);
        return response.data.productDto;
    },

    getCategories: async (): Promise<CategoryDto[]> => {
        
        const response: AxiosResponse<GetCategoryResponse> = await axiosInstance.get(`/categories`);
            const categories = response.data.categoryDtos;
            return categories;
        
    },

    createCategory: async (category: CategoryDto): Promise<void> => {
        await axiosInstance.post<number>(`/categories`, category);
    },

    editCategory: async (category: CategoryDto): Promise<void> => {
        await axiosInstance.put<number>(`/categories/${category.id}`, category);
    },

    deleteCategory: async (categoryId: number): Promise<void> => {
        await axiosInstance.delete<number>(`/categories/${categoryId}`);
    },
    getCategoryById: async (movieId: string): Promise<CategoryDto | undefined> => {
        const response = await axiosInstance.get<GetCategoryByIdResponse>(`/categories/${movieId}`);
        return response.data.categoryDto;
    }
}
export default apiConnector;