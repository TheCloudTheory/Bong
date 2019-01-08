/// <reference path="../index.d.ts" />

import * as React from 'react';
import * as ReactDOM from 'react-dom';
import * as axios from 'axios';

import Main from './Main';

axios.default.defaults.baseURL = 'http://localhost:7071/api/';

ReactDOM.render(
    <Main />,
    document.getElementById('root')
);