"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Pages = require("./pages");
const panelWithList_1 = require("../../ui/panelWithList");
class PagesList extends Bong.Module {
    render() {
        return (React.createElement(panelWithList_1.default, { title: 'Pages', module: Pages.Module, createItemButtonText: 'Add new page', columns: ['Title', 'Slug', 'Created'] }));
    }
}
exports.default = PagesList;
//# sourceMappingURL=pagesList.js.map