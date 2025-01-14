
import { NavLink, Outlet, useLocation } from 'react-router-dom'
import './App.css'

import { Container, Menu } from 'semantic-ui-react';
import { useEffect } from 'react';


function App() {

    const location = useLocation();
    //useEffect(() => {
    //    console.log("Current location:", location.pathname);
    //}, [location]);

  return (
      <>
          <Menu inverted>
           <Menu.Item name="home" as={NavLink} to="/">
                  Home
              </Menu.Item>
              <Menu.Item name="products" as={NavLink} to="/products">
                  Products
              </Menu.Item>
              <Menu.Item name="categories" as={NavLink} to="/categories">
                  Categories
              </Menu.Item>
             
          </Menu>        
          
              <Container className="container-style">
                <Outlet/>
              </Container>
          
    </>
  )
}

export default App
