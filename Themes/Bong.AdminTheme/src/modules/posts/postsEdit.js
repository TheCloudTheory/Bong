"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Posts = require("./posts");
const field_1 = require("../../ui/field");
const editor_1 = require("../../ui/editor");
const repository_1 = require("../../repository");
class PostsEdit extends Bong.EditFormModule {
    constructor(props) {
        super(props);
        this.Module = Posts.Module;
        this.Title = 'Posts - Edit';
        this.state = { id: null, title: '', url: '', body: null, subtitle: '' };
        this.repository = new repository_1.default();
    }
    fetchData() {
        return this.repository.get(Posts.Module, this.id);
    }
    setValues(model) {
        this.setState({
            id: model.id,
            title: model.title,
            url: model.url,
            body: model.body,
            subtitle: model.subtitle
        });
    }
    getForm() {
        return (React.createElement("div", null,
            React.createElement(field_1.default, { name: "title", label: "Title", type: "text", value: this.state.title }),
            React.createElement(field_1.default, { name: "url", label: "Url", type: "text", value: this.state.url }),
            React.createElement(field_1.default, { name: "subtitle", label: "Subtitle", type: "text", value: this.state.subtitle }),
            React.createElement(editor_1.default, { html: this.state.body })));
    }
}
exports.default = PostsEdit;
//# sourceMappingURL=postsEdit.js.map