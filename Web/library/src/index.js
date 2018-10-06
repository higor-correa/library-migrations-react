import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import * as serviceWorker from './serviceWorker';
import { Router } from "react-router";
import { createBrowserHistory } from "history";
import Main from './pages/main/main.js';

const hist = createBrowserHistory();

ReactDOM.render((
    <Router history={hist}>
        <Main />
    </Router>
), document.getElementById('app'));

serviceWorker.unregister();
