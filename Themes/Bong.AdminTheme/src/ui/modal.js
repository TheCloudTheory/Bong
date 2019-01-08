"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
class Modal extends React.Component {
    constructor(props) {
        super(props);
        this.state = { isProcessing: false };
    }
    render() {
        return (React.createElement("div", { className: "modal active", id: "modal-id" },
            React.createElement("a", { onClick: () => this.props.onCloseCallback(), className: "modal-overlay", "aria-label": "Close" }),
            React.createElement("div", { className: "modal-container" },
                React.createElement("div", { className: "modal-header" },
                    React.createElement("a", { onClick: () => this.props.onCloseCallback(), className: "btn btn-clear float-right", "aria-label": "Close" }),
                    React.createElement("div", { className: "modal-title h5" }, this.props.title)),
                React.createElement("div", { className: "modal-body" },
                    React.createElement("div", { className: "content" }, this.props.content)),
                React.createElement("div", { className: "modal-footer" },
                    React.createElement("button", { className: "btn float-left", onClick: () => this.props.onCloseCallback() }, "Cancel"),
                    React.createElement("button", { className: this.state.isProcessing ? `btn btn-${this.props.buttonClass} loading` : `btn btn-${this.props.buttonClass}`, onClick: () => this.proceed() }, this.props.buttonText)))));
    }
    proceed() {
        this.setState({
            isProcessing: true
        });
        this.props.onProceedCallback();
    }
}
exports.default = Modal;
//# sourceMappingURL=modal.js.map