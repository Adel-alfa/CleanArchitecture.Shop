
import { Link } from "react-router-dom";
import { Container, Header, Button } from "semantic-ui-react";

export default function ErrorPage() {
    return (
        <Container textAlign="center" style={{ padding: '2em' }}>
            <Header as="h1" color="orange">
                Oops! 😢Page not found.
            </Header>
            <p>We can't seem to find the page you're looking for.</p>
            <Button as={Link} to="/home" color="blue">
                Go to Home
            </Button>
        </Container>
    );
}
