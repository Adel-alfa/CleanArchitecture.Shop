import { Button, Container, Dropdown, Pagination } from "semantic-ui-react";
import apiConnector from "../../api/apiConnector";
import { ProductDto } from "../../models/productDto";
import { useEffect, useState } from "react";
import ProductTableItem from "./ProductTableItem";
import { NavLink } from "react-router-dom";
import { PaginationRequestParameters } from "../../models/paginationResponse";



export default function ProductTable() {

    const [products, setProducts] = useState<ProductDto[]>([]);
    const [totalPageNumber, setTotalPagesNumber] = useState(0);
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize, setPageSize] = useState(5);
    const [paginationRequestParameters, setPaginationRequestParameters] =
        useState<PaginationRequestParameters>({ pageSize: pageSize, pageNumber: currentPage });

    const fetchData = async () => {
        const paginationResult = await apiConnector.getProductsPaginition(paginationRequestParameters);

        if (paginationResult.data) {
            const { data, paginationParameters } = paginationResult;

            if (data && paginationParameters) {
                setProducts(data);
                setTotalPagesNumber(paginationParameters.totalPages);
                setCurrentPage(paginationParameters.currentPage);
                setPageSize(paginationParameters.itemsPerPage);
            }
        }
    }

    useEffect(() => {
       
        fetchData();
    }, [paginationRequestParameters]);

    const handlePageSizeChange = (_: React.SyntheticEvent, data: any) => {
        setPaginationRequestParameters({ ...paginationRequestParameters, pageSize: data.value });
    };
    const handlePageNumberChange = (_: React.MouseEvent<HTMLAnchorElement>, data: any) => {
        setPaginationRequestParameters({ ...paginationRequestParameters, pageNumber: data.activePage });
    }
    return (
        <>
            <Container className="container-style">
                <table className="ui inverted table">
                    <thead style={{ textAlign: 'center' }}>
                        <tr>
                            <th>Id</th>
                            <th>Name</th>
                            <th>Description</th>
                            <th>CreationDate</th>
                            <th>ModificationDate</th>
                            <th>Price</th>
                            <th>Quantity</th>
                            <th>Category</th>
                            <th>Action</th>
                        </tr>
                    </thead>
                    <tbody>
                        {products.length !== 0 && (
                            products.map((product, index) => (
                                <ProductTableItem key={index}  product = {product} />
                            ))
                        
                        )}
                    </tbody>
                </table>
                <div style={{ marginTop: '20px', display: 'flex', justifyContent: 'space-between', alignItems: 'center' }}>
                    <Dropdown
                        selection
                        options={[
                            { key: 5, text: '5', value: 5 },
                            { key: 10, text: '10', value: 10 },
                            { key: 20, text: '20', value: 20 },
                            { key: 50, text: '50', value: 50 },
                        ]}
                        value={pageSize} onChange={handlePageSizeChange} />
                    <Pagination
                        activePage={currentPage}
                        totalPages={totalPageNumber}
                        onPageChange={handlePageNumberChange}
                    />
                    <Button as={NavLink} to="createProduct" floated="right" type="button" content="Create Product"
                        positive />
                </div>
               
            </Container>
        </>
    )
}