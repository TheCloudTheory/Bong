"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Pages = require("./pages");
const field_1 = require("../../ui/field");
const editor_1 = require("../../ui/editor");
class PagesCreate extends Bong.FormModule {
    constructor(props) {
        super(props);
        this.state = {};
        this.Module = Pages.Module;
        this.Title = 'Pages - Create';
    }
    getForm() {
        return (React.createElement("div", null,
            React.createElement(field_1.default, { name: "title", label: "Title", type: "text", placeholder: "Title of a new page" }),
            React.createElement(field_1.default, { name: "url", label: "Url", type: "text" }),
            React.createElement(editor_1.default, null)));
    }
}
exports.default = PagesCreate;
//# sourceMappingURL=pagesCreate.js.map