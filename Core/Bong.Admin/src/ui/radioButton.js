"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
class RadioButton extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            value: props.value
        };
    }
    render() {
        return (React.createElement("label", { className: "form-radio" },
            React.createElement("input", { type: "radio", name: this.props.name, value: this.state.value, onChange: (e) => this.handleChange(e), checked: this.props.isChecked && this.props.isChecked === true }),
            React.createElement("i", { className: "form-icon" }),
            " ",
            this.props.label));
    }
    handleChange(event) {
        this.setState({
            value: event.currentTarget.value
        });
    }
}
exports.default = RadioButton;
//# sourceMappingURL=radioButton.js.map