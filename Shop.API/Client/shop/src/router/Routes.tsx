import { RouteObject, createBrowserRouter } from "react-router-dom";
import ProductForm from "../components/products/ProductForm";
import App from "../App";
import ProductTable from "../components/products/ProductTable";
import CategoryTable from "../components/Categories/CategoryTable";
import Home from "../components/Home/Home";
import CategoryForm from "../components/Categories/CategoryForm";
import ErrorPage from "../components/Error/ErrorPage";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App />,
        errorElement: <ErrorPage />,
        children: [
            { path: '/', element: <Home /> },
            { path: '/home', element: <Home /> },
            { path: 'products', element: <ProductTable /> },
            { path: 'products/createProduct', element: <ProductForm key='create' /> },
            { path: 'products/editProduct/:id', element: <ProductForm key='edit' /> },
            { path: 'categories', element: <CategoryTable /> },
            { path: 'categories/createCategory', element: <CategoryForm key='create' /> },
            { path: 'categories/editCategory/:id', element: <CategoryForm key='edit' /> },
            { path: '*', element: <ErrorPage /> }
        ]
    }
];

export const router = createBrowserRouter(routes);
