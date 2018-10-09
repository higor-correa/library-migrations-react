import React, { Component } from 'react';
import { Link } from 'react-router-dom'

class Header extends Component {

    render() {
        return (
            <header className="App-header">
                <ul>
                    <li><Link to="/">Home</Link></li>
                    <li><Link to="/autores">Autores</Link></li>
                    <li><Link to="/editoras">Editoras</Link></li>
                    <li><Link to="/livros">Livros</Link></li>
                </ul>
            </header>
        );
    }
}

export default Header;