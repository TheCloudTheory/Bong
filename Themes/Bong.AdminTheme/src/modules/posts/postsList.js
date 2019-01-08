"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Posts = require("./posts");
const panelWithList_1 = require("../../ui/panelWithList");
class PostsList extends Bong.Module {
    render() {
        return (React.createElement(panelWithList_1.default, { title: 'Posts', module: Posts.Module, createItemButtonText: 'Add new post', columns: ['Title', 'Created'] }));
    }
}
exports.default = PostsList;
//# sourceMappingURL=postsList.js.map