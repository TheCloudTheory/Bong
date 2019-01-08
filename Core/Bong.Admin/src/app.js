"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const ReactDOM = require("react-dom");
const axios = require("axios");
const Main_1 = require("./Main");
axios.default.defaults.baseURL = 'http://localhost:7071/api/';
ReactDOM.render(React.createElement(Main_1.default, null), document.getElementById('root'));
//# sourceMappingURL=app.js.map