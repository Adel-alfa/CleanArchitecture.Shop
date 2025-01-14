
import React, { useEffect, useState } from 'react';
import { Container, Table} from 'semantic-ui-react';
import apiConnector from '../../api/apiConnector';
import { CategoryDto } from '../../models/categoryDto';
import CategoryTableItem from './CategoryTableItem';

export default function CategoryTable() {
    const [categories, setCategories] = useState<CategoryDto[]>([]);

    useEffect(() => {
        const fetchData = async () => {
            const fetchedCategories = await apiConnector.getCategories();
            setCategories(fetchedCategories);
        }
        fetchData();
    }, []);

    return (
        <Container>
            <Table celled inverted>
                <Table.Header style={{ textAlign: 'center' }}>
                    <Table.Row>
                        <Table.HeaderCell>Id</Table.HeaderCell>
                        <Table.HeaderCell>Name</Table.HeaderCell>
                        <Table.HeaderCell>Action</Table.HeaderCell>
                    </Table.Row>
                </Table.Header>
                <Table.Body>
                    {categories.length !== 0 && (
                        categories.map((category, index) => (
                            <CategoryTableItem key={index} category={category} />
                    ))
                    )}
                </Table.Body>
            </Table>
        </Container>
    );
}
