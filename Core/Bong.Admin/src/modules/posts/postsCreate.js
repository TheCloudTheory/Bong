"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Posts = require("./posts");
const nameUrl_1 = require("../../ui/nameUrl");
const editor_1 = require("../../ui/editor");
const field_1 = require("../../ui/field");
class PostsCreate extends Bong.FormModule {
    constructor(props) {
        super(props);
        this.Module = Posts.Module;
        this.Title = 'Posts - Create';
    }
    getForm() {
        return (React.createElement("div", null,
            React.createElement(nameUrl_1.default, null),
            React.createElement(field_1.default, { name: "subtitle", label: "Subtitle", type: "text" }),
            React.createElement(editor_1.default, null)));
    }
}
exports.default = PostsCreate;
//# sourceMappingURL=postsCreate.js.map