import React, { Component } from 'react';
import axios from 'axios';
import AutorService from '../services/autor';


class Autor extends Component {
    constructor() {
        super();
        this.state = {
            autores: []
        };
    };
    componentDidMount() {
        let service = new AutorService();
        service.getAutores(autores => this.setState({ ...this.state, autores: autores }));
    }

    render() {
        return (
            <div>
                <h1>Listagem dos autores</h1>
                <div>
                    {this.state.autores.map(autor =>
                        <p key={autor.id} >{autor.firstName}</p>
                    )}
                </div>
            </div>
        );
    };
}

export default Autor;