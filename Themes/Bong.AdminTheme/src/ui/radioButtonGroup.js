"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const radioButton_1 = require("./radioButton");
class RadioButtonGroup extends React.Component {
    render() {
        return (React.createElement("div", { className: "form-group" },
            React.createElement("label", { className: "form-label" }, this.props.label),
            this.generateFields()));
    }
    generateFields() {
        let html = [];
        this.props.fields.forEach((value, index) => {
            if (this.props.values[index] === this.props.defaultValue) {
                html.push(React.createElement(radioButton_1.default, { key: index, label: value, name: this.props.name, value: this.props.values[index], isChecked: true }));
            }
            else {
                html.push(React.createElement(radioButton_1.default, { key: index, label: value, name: this.props.name, value: this.props.values[index] }));
            }
        });
        return html;
    }
}
exports.default = RadioButtonGroup;
//# sourceMappingURL=radioButtonGroup.js.map