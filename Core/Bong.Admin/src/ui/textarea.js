"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
class Textarea extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            value: props.text
        };
    }
    render() {
        return (React.createElement("div", { className: this.props.isHidden ? "d-invisible hidden" : "form-group" },
            React.createElement("label", { className: "form-label" }, this.props.label),
            React.createElement("textarea", { className: "form-input", name: this.props.name, placeholder: this.props.placeholder, rows: this.props.rows, value: this.state.value, onChange: (e) => this.handleChange(e) })));
    }
    componentWillReceiveProps(...props) {
        if (props && props.length > 0) {
            this.setState({
                value: props[0].text
            });
        }
    }
    handleChange(event) {
        this.setState({
            value: event.currentTarget.value
        });
    }
}
exports.default = Textarea;
//# sourceMappingURL=textarea.js.map