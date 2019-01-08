"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Pages = require("./pages");
const field_1 = require("../../ui/field");
const editor_1 = require("../../ui/editor");
const repository_1 = require("../../repository");
class PagesEdit extends Bong.EditFormModule {
    constructor(props) {
        super(props);
        this.Module = Pages.Module;
        this.Title = 'Pages - Edit';
        this.state = { id: null, title: '', url: '', body: null };
        this.repository = new repository_1.default();
    }
    fetchData() {
        return this.repository.get(Pages.Module, this.id);
    }
    setValues(model) {
        this.setState({
            id: model.id,
            title: model.title,
            url: model.url,
            body: model.body
        });
    }
    getForm() {
        return (React.createElement("div", null,
            React.createElement(field_1.default, { name: "title", label: "Title", type: "text", value: this.state.title }),
            React.createElement(field_1.default, { name: "url", label: "Url", type: "text", value: this.state.url }),
            React.createElement(editor_1.default, { html: this.state.body })));
    }
}
exports.default = PagesEdit;
//# sourceMappingURL=pagesEdit.js.map