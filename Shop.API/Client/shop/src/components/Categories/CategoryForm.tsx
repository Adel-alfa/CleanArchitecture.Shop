import {  NavLink, useNavigate, useParams } from "react-router-dom";
import { CategoryDto } from "../../models/categoryDto";
import apiConnector from "../../api/apiConnector";
import { ChangeEvent, useEffect, useState } from "react";
import { Form, Segment, Button } from "semantic-ui-react";

export default function CategoryForm() {

    const { id } = useParams();
    const navigate = useNavigate();
    const [category, setCategory] = useState<CategoryDto>({
        id: undefined,
        name: ''
    });

    useEffect(() => {

        if (id) {
            apiConnector.getCategoryById(id).then(category => setCategory(category!))

        }

    }, [id]);

    function handleSubmit() {
        if (!category.id) {
            apiConnector.createCategory(category).then(() => navigate('/categories'));
        } else {
            apiConnector.editCategory(category).then(() => navigate('/categories'));
        }
    }
    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setCategory({ ...category, [name]: value });
    }

    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete='off' className='ui invereted form'>
                <Form.Input placeholder='Title' name='name' value={category.name} onChange={handleInputChange} />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button as={NavLink} to='/categories' floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}
