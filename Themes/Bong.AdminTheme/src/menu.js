"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const react_router_dom_1 = require("react-router-dom");
class Menu extends React.Component {
    render() {
        return (React.createElement("div", { className: "bong-menu" },
            React.createElement("img", { src: "images/logo.png", style: { display: 'block', margin: '1em auto' } }),
            React.createElement("div", { className: "accordion" },
                React.createElement("input", { type: "checkbox", id: "accordion-1", name: "accordion-checkbox", hidden: true }),
                React.createElement("label", { className: "accordion-header c-hand", htmlFor: "accordion-1" }, "Content"),
                React.createElement("div", { className: "accordion-body" },
                    React.createElement("ul", { className: "menu menu-nav" },
                        React.createElement("li", { className: "menu-item" },
                            React.createElement(react_router_dom_1.Link, { to: "/pages" }, "Pages")),
                        React.createElement("li", { className: "menu-item" },
                            React.createElement(react_router_dom_1.Link, { to: "/posts" }, "Posts"))))),
            React.createElement("div", { className: "accordion" },
                React.createElement("input", { type: "checkbox", id: "accordion-2", name: "accordion-checkbox", hidden: true }),
                React.createElement("label", { className: "accordion-header c-hand", htmlFor: "accordion-2" }, "Settings"),
                React.createElement("div", { className: "accordion-body" },
                    React.createElement("ul", { className: "menu menu-nav" },
                        React.createElement("li", { className: "menu-item" },
                            React.createElement(react_router_dom_1.Link, { to: "/site" }, "Site")),
                        React.createElement("li", { className: "menu-item" },
                            React.createElement(react_router_dom_1.Link, { to: "/authentication" }, "Authentication")),
                        React.createElement("li", { className: "menu-item" },
                            React.createElement(react_router_dom_1.Link, { to: "/email" }, "Email")),
                        React.createElement("li", { className: "menu-item" },
                            React.createElement(react_router_dom_1.Link, { to: "/azure" }, "Azure")))))));
    }
}
exports.default = Menu;
//# sourceMappingURL=menu.js.map