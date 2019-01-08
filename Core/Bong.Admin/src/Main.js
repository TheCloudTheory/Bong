"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const react_router_dom_1 = require("react-router-dom");
const menu_1 = require("./menu");
const modules = require("./modules/modules");
class Main extends React.Component {
    render() {
        return (React.createElement(react_router_dom_1.BrowserRouter, null,
            React.createElement("div", { className: "off-canvas off-canvas-sidebar-show" },
                React.createElement("div", { className: "off-canvas-sidebar active" },
                    React.createElement(menu_1.default, null)),
                React.createElement("div", { className: "off-canvas-content" },
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/", component: modules['Start'] }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/pages", component: modules['PagesList'] }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/pages/create", component: modules['PagesCreate'] }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/pages/edit/:id", component: react_router_dom_1.withRouter(modules['PagesEdit']) }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/posts", component: modules['PostsList'] }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/posts/create", component: modules['PostsCreate'] }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/posts/edit/:id", component: react_router_dom_1.withRouter(modules['PostsEdit']) }),
                    React.createElement(react_router_dom_1.Route, { exact: true, path: "/authentication", component: modules['AuthenticationEdit'] })))));
    }
}
exports.default = Main;
//# sourceMappingURL=Main.js.map