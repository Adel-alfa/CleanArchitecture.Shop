import { NavLink, useNavigate, useParams } from "react-router-dom";
import { ProductDto } from "../../models/productDto";
import { ChangeEvent, useEffect, useState } from "react";
import apiConnector from "../../api/apiConnector";
import { Button, Form, Segment } from "semantic-ui-react";
import { SyntheticEvent } from 'react';
import { DropdownProps } from 'semantic-ui-react';

export default function ProductForm() {


    const { id } = useParams();
    const navigate = useNavigate();

    const [product, setProduct] = useState<ProductDto>({
        id: undefined,
        name: '',
        description: '',
        creationDate: undefined,
        modificationDate: undefined,
        price: undefined,
        quantity: undefined,
        categoryId: undefined,
        categoryName:''
    });
    const [categories, setCategories] = useState<{ key: number, value: number, text: string }[]>([]);
    useEffect(() => {
        if (id) {
            apiConnector.getProductById(id).then(product => setProduct(product!))

        }
        const fetchCategories = async () => {
            const fetchedCategories = await apiConnector.getCategories(); // Assuming this function fetches categories
            const categoryOptions = fetchedCategories.map((category: { id: number| undefined, name: string }) => ({
                key: category.id?? 0,
                value: category.id??0,
                text: category.name
            }));
            setCategories(categoryOptions);
        };
        fetchCategories();
    }, [id]);

    function handleSubmit() {
        if (!product.id) {
            apiConnector.createProduct(product).then(() => navigate('/products'));
        } else {
            apiConnector.editProduct(product).then(() => navigate('/products'));
        }
    }

    function handleInputChange(event: ChangeEvent<HTMLInputElement | HTMLTextAreaElement>) {
        const { name, value } = event.target;
        setProduct({ ...product, [name]: value });
    }
   
   

    function handleCategoryChange(event: SyntheticEvent<HTMLElement, Event>, data: DropdownProps) {
        const { value } = data;
        setProduct({ ...product, categoryId: value as number }); // Cast value to number
    }

    return (
        <Segment clearing inverted>
            <Form onSubmit={handleSubmit} autoComplete='off' className='ui invereted form'>
                <Form.Input placeholder='Title' name='name' value={product.name} onChange={handleInputChange} />
                <Form.TextArea placeholder='Description' name='description' value={product.description} onChange={handleInputChange} />
                <Form.Select
                    placeholder='Category'
                    options={categories}
                    value={product.categoryId}
                    onChange={handleCategoryChange}
                />
                <Form.Input placeholder='Price' name='price' value={product.price} onChange={handleInputChange} />
                <Form.Input placeholder='Quantity' name='quantity' value={product.quantity} onChange={handleInputChange} />
                <Button floated='right' positive type='submit' content='Submit' />
                <Button as={NavLink} to='/products' floated='right' type='button' content='Cancel' />
            </Form>
        </Segment>
    )
}
