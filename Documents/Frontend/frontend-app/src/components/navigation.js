import React,{Component} from 'react';
import {NavLink} from 'react-router-dom'; 
import {Navbar,Nav, NavDropdown} from 'react-bootstrap';




class Navigation extends Component {
    render(){
        return (
            <Navbar bg="light" expand="lg">
                <Navbar.Toggle aria-controls="basic-navbar-nav" />
                <Navbar.Collapse id="basic-navbar-nav"/>
                <Nav className="nav-main">
                    <NavLink to="/allGames">AllGames</NavLink>
                    <NavLink to="/lives">Lives</NavLink>
                    <NavLink to="/myTeams">MyTemas</NavLink>
                    <NavLink to="/profile">Profile</NavLink>
                    <NavDropdown title="Date" id="basic-nav-dropdown">
                        <NavDropdown.Item >Prvi</NavDropdown.Item>
                        <NavDropdown.Item>Drugi</NavDropdown.Item>
                        
                    </NavDropdown>


                </Nav>
                
            </Navbar>
        )
    }
}

export default Navigation;
