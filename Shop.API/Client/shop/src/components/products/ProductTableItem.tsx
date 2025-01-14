import { Button } from "semantic-ui-react";
import { ProductDto } from "../../models/productDto"
import apiConnector from "../../api/apiConnector";
import { NavLink } from "react-router-dom";

interface Props {
    product: ProductDto;
}

const truncateDescription = (description: string, maxLength: number): string => {
    if (description.length <= maxLength) {
        return description;
    }
    return description.substring(0, maxLength) + '...';
};
export default function ProductTableItem({product}: Props) {

    return (
        <>
            <tr className="center aligned">
                
                <td data-label="Id">{product.id}</td>
                <td data-label="Name">{product.name}</td>
                <td data-label="Description">{truncateDescription(product.description, 15)}</td>
                <td data-label="CreationDate">{product.creationDate}</td>
                <td data-label="ModificationDate">{product.modificationDate}</td>
                <td data-label="Price">{product.price}</td>
                <td data-label="Quantity">{product.quantity}</td>
                <td data-label="Category">{product.categoryName}</td>
                <td data-label="Action">
                    <Button as={NavLink} to={`editProduct/${product.id}`} color="yellow" type="submit" > Edit</Button>
                    <Button color="red" type="button" onClick={async () => {
                        await apiConnector.deleteProduct(product.id!);
                        window.location.reload();
                    }} > Delete</Button>
                </td>
            </tr>
           
        </>
    )
}
 