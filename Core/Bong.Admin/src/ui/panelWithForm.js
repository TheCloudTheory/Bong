"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const react_router_dom_1 = require("react-router-dom");
const repository_1 = require("../repository");
const toast_1 = require("./toast");
class PanelWithForm extends React.Component {
    constructor(props) {
        super(props);
        this.state = { isLoading: false, isError: false, isSuccess: false, data: null, isDataLoaded: false };
        this.repository = new repository_1.default();
    }
    componentDidMount() {
        if (this.props.fetchAction) {
            this.props.fetchAction().then(_ => {
                this.props.setValues(_.data);
                this.setState({
                    isDataLoaded: true
                });
            }).catch(_ => {
                this.setState({
                    isError: true
                });
            });
        }
        else {
            this.setState({
                isDataLoaded: true
            });
        }
    }
    render() {
        return (React.createElement("form", { onSubmit: (e) => this.handleSubmit(e) },
            React.createElement("div", { className: "panel bong-panel-list" },
                React.createElement("div", { className: "panel-header" },
                    React.createElement("div", { className: "panel-title" },
                        React.createElement("div", { className: "columns" },
                            React.createElement("div", { className: "column col-12" },
                                React.createElement("h2", null, this.props.title))))),
                React.createElement("div", { className: "panel-nav" }),
                React.createElement("div", { className: "panel-body" },
                    this.state.isError && React.createElement(toast_1.Toast, { text: 'Something went wrong!', status: toast_1.ToastStatus.Error }),
                    this.state.isSuccess && React.createElement(toast_1.Toast, { text: 'Success!', status: toast_1.ToastStatus.Success }),
                    this.state.isDataLoaded && this.props.html),
                React.createElement("div", { className: "panel-footer" },
                    React.createElement("div", { className: "columns" },
                        React.createElement("div", { className: "column col-6" },
                            React.createElement("button", { type: "button", className: "btn", onClick: () => this.props.history.goBack() }, "Back")),
                        React.createElement("div", { className: "column col-6 text-right" },
                            React.createElement("button", { className: this.state.isLoading ? 'btn btn-primary loading' : 'btn btn-primary' }, "Save")))))));
    }
    handleSubmit(event) {
        event.preventDefault();
        let json = {};
        let data = new FormData(event.currentTarget);
        this.setState({ isLoading: true });
        data.forEach((value, key) => {
            let jsonValue = json[key];
            if (typeof jsonValue !== 'undefined') {
                if (typeof jsonValue == 'object') {
                    jsonValue.push(value);
                }
                else {
                    let currentValue = jsonValue;
                    jsonValue = [];
                    jsonValue.push(currentValue);
                    jsonValue.push(value);
                }
            }
            else {
                if (key.endsWith('[]')) {
                    jsonValue = [value];
                }
                else {
                    jsonValue = value;
                }
            }
            json[key] = value;
        });
        let action = this.props.isEdit === false || typeof (this.props.id) === 'undefined' ?
            this.repository.create(this.props.module, json) :
            this.repository.update(this.props.module, this.props.id, json);
        action.then(_ => {
            this.setState({
                isLoading: false,
                isSuccess: true
            });
            setTimeout(() => {
                this.props.history.goBack();
            }, 1000);
        }).catch(_ => {
            this.setState({
                isError: true,
                isLoading: false
            });
        });
    }
}
exports.PanelWithForm = PanelWithForm;
exports.default = react_router_dom_1.withRouter(PanelWithForm);
//# sourceMappingURL=panelWithForm.js.map