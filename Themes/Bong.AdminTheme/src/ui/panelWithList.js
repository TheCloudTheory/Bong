"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const react_router_dom_1 = require("react-router-dom");
const repository_1 = require("../repository");
const toast_1 = require("./toast");
const modal_1 = require("../ui/modal");
class PanelWithList extends React.Component {
    constructor(props) {
        super(props);
        this.state = { data: [], isLoading: true, isError: false, isDeletingActive: false, idToDelete: null, isDeleted: false };
        this.repository = new repository_1.default();
    }
    componentDidMount() {
        this.loadData();
    }
    render() {
        return (React.createElement("div", { className: "panel bong-panel-list" },
            React.createElement("div", { className: "panel-header" },
                React.createElement("div", { className: "panel-title" },
                    React.createElement("div", { className: "columns" },
                        React.createElement("div", { className: "column col-6" },
                            React.createElement("h2", null, this.props.title)),
                        React.createElement("div", { className: "column col-6 text-right" },
                            React.createElement(react_router_dom_1.Link, { className: "btn btn-primary", to: `${this.props.module}/create` }, this.props.createItemButtonText))))),
            React.createElement("div", { className: "panel-nav" }),
            React.createElement("div", { className: this.state.isLoading ? 'panel-body loading' : 'panel-body' },
                this.state.isError && React.createElement(toast_1.Toast, { text: this.state.errorMessage, status: toast_1.ToastStatus.Error }),
                this.state.isDeleted && React.createElement(toast_1.Toast, { text: "Record deleted!", status: toast_1.ToastStatus.Success }),
                React.createElement("table", { className: "table table-striped table-hover" },
                    React.createElement("thead", null,
                        React.createElement("tr", null, this.generateHeaders())),
                    React.createElement("tbody", null,
                        this.state.data.length > 0 && this.generateRows(),
                        this.state.data.length === 0 && React.createElement("tr", { className: "active" },
                            React.createElement("td", { colSpan: this.props.columns.length + 1 }, "No records available"))))),
            this.state.isDeletingActive &&
                React.createElement(modal_1.default, { title: "Delete a page", content: "Are you sure you want to delete a page?", buttonText: "Delete", buttonClass: "error", onCloseCallback: () => this.onModalCloseCallback(), onProceedCallback: () => this.onProceedCallback() })));
    }
    loadData() {
        this.repository.list(this.props.module).then(_ => {
            this.setState({
                data: _.data,
                isLoading: false,
                isError: false
            });
        }).catch(_ => {
            this.setState({
                isError: true,
                isLoading: false,
                errorMessage: _.message
            });
        });
    }
    generateHeaders() {
        var html = [];
        this.props.columns.forEach((value, index) => {
            html.push(React.createElement("th", { key: index }, value));
        });
        html.push(React.createElement("th", { key: '9999' }));
        return html;
    }
    generateRows() {
        var html = [];
        this.state.data.forEach((value, index) => {
            html.push(React.createElement("tr", { key: index }, this.generateCols(value)));
        });
        return html;
    }
    generateCols(values) {
        var html = [];
        for (let value in values) {
            if (value !== 'id') {
                html.push(React.createElement("td", { key: value }, values[value]));
            }
        }
        html.push(React.createElement("td", { key: "9999", className: "text-right" },
            React.createElement(react_router_dom_1.Link, { className: "btn btn-action btn-primary tooltip", "data-tooltip": "Edit", to: `${this.props.module}/edit/${values.id}` },
                React.createElement("i", { className: "icon icon-edit" })),
            React.createElement("button", { className: "btn btn-action btn-error tooltip", "data-tooltip": "Delete", onClick: () => this.handleDeletion(values.id) },
                React.createElement("i", { className: "icon icon-delete" }))));
        return html;
    }
    handleDeletion(id) {
        this.setState({
            isDeletingActive: true,
            idToDelete: id
        });
    }
    onModalCloseCallback() {
        this.setState({
            isDeletingActive: false
        });
    }
    onProceedCallback() {
        return this.repository.delete(this.props.module, this.state.idToDelete).then(_ => {
            this.setState({
                isDeletingActive: false,
                idToDelete: null,
                isDeleted: true,
                isLoading: true
            });
            this.loadData();
        }).catch(_ => {
            this.setState({
                isDeletingActive: false,
                isError: true,
                idToDelete: null
            });
        });
    }
}
exports.default = PanelWithList;
//# sourceMappingURL=panelWithList.js.map