import React, { Component } from 'react';
import axios from 'axios';

class Autor extends Component {
    constructor() {
        super();
        this.state = {
            autores: []
        };
    };
    componentDidMount() {
        axios.get("https://localhost:5001/api/Author/")
            .then(response => {
                return response.data;
            }).then(data => {
                this.setState({ ...this.state, autores: data });
            });
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