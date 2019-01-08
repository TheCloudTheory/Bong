"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const start_1 = require("./start/start");
const pagesList_1 = require("./pages/pagesList");
const pagesCreate_1 = require("./pages/pagesCreate");
const pagesEdit_1 = require("./pages/pagesEdit");
const postsList_1 = require("./posts/postsList");
const postsCreate_1 = require("./posts/postsCreate");
const postsEdit_1 = require("./posts/postsEdit");
const authenticationEdit_1 = require("./authentication/authenticationEdit");
module.exports = {
    Start: start_1.default,
    PagesList: pagesList_1.default,
    PagesCreate: pagesCreate_1.default,
    PagesEdit: pagesEdit_1.default,
    PostsList: postsList_1.default,
    PostsCreate: postsCreate_1.default,
    PostsEdit: postsEdit_1.default,
    AuthenticationEdit: authenticationEdit_1.default
};
//# sourceMappingURL=modules.js.map