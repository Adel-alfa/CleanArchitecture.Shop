import { Button } from "semantic-ui-react";
import apiConnector from "../../api/apiConnector";
import { CategoryDto } from "../../models/categoryDto";
import { NavLink } from "react-router-dom";



interface Props {
    category: CategoryDto;
}

export default function CategoryTableItem({ category }: Props) {

    return (
        <>
            <tr className="center aligned">
                <td data-label="Id">{category.id}</td>
                <td data-label="Name">{category.name}</td>
                <td data-label="Action">
                    <Button as={NavLink} to={`editCategory/${category.id}`} color="yellow" type="submit" > Edit</Button>
                    <Button color="red" type="button" onClick={async () => {
                        await apiConnector.deleteCategory(category.id!);
                        window.location.reload();
                    }} > Delete</Button>
                </td>
            </tr>
        </>
    )
}