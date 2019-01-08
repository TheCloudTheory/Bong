"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
class Field extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            value: props.value
        };
    }
    render() {
        return (React.createElement("div", { className: "form-group" },
            React.createElement("label", { className: "form-label" }, this.props.label),
            React.createElement("input", { className: "form-input", type: this.props.type, placeholder: this.props.placeholder, name: this.props.name, value: this.state.value, onChange: (e) => this.handleChange(e) })));
    }
    handleChange(event) {
        this.setState({
            value: event.currentTarget.value
        });
        if (typeof (this.props.onChangeCallback) !== 'undefined') {
            this.props.onChangeCallback(event.currentTarget.value);
        }
    }
    componentWillReceiveProps(...props) {
        if (props.length > 0) {
            let prop = props[0];
            this.setState({
                value: prop.value
            });
        }
    }
}
exports.default = Field;
//# sourceMappingURL=field.js.map