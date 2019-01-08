"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const field_1 = require("./field");
class NameUrl extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            url: ""
        };
    }
    render() {
        return (React.createElement("div", null,
            React.createElement(field_1.default, { name: "title", label: "Title", type: "text", placeholder: "Title of a new post", onChangeCallback: (_) => this.callback(_) }),
            React.createElement(field_1.default, { name: "url", label: "Url", type: "text", value: this.state.url })));
    }
    callback(currentValue) {
        currentValue = currentValue.replace(",", "");
        currentValue = currentValue.replace(".", "");
        currentValue = currentValue.replace("!", "");
        currentValue = currentValue.replace("?", "");
        currentValue = currentValue.replace(":", "");
        currentValue = currentValue.replace(";", "");
        currentValue = currentValue.replace("`", "");
        currentValue = currentValue.replace("~", "");
        currentValue = currentValue.replace("@", "");
        currentValue = currentValue.replace("#", "");
        currentValue = currentValue.replace("$", "");
        currentValue = currentValue.replace("%", "");
        currentValue = currentValue.replace("^", "");
        currentValue = currentValue.replace("&", "");
        currentValue = currentValue.replace("*", "");
        currentValue = currentValue.replace("(", "");
        currentValue = currentValue.replace(")", "");
        currentValue = currentValue.replace("-", "");
        currentValue = currentValue.replace("_", "");
        currentValue = currentValue.replace("+", "");
        currentValue = currentValue.replace("=", "");
        currentValue = currentValue.replace("[", "");
        currentValue = currentValue.replace("]", "");
        currentValue = currentValue.replace("{", "");
        currentValue = currentValue.replace("}", "");
        currentValue = currentValue.replace("'", "");
        currentValue = currentValue.replace("", "");
        currentValue = currentValue.replace(",\"", "");
        currentValue = currentValue.replace("'", "");
        currentValue = currentValue.replace("<", "");
        currentValue = currentValue.replace(">", "");
        currentValue = currentValue.replace("|", "");
        currentValue = currentValue.replace("\\", "");
        currentValue = currentValue.replace("/", "");
        let lowercase = currentValue.toLocaleLowerCase();
        let words = lowercase.split(' ');
        let url = words.join('-');
        this.setState({
            url: url
        });
    }
}
exports.default = NameUrl;
//# sourceMappingURL=nameUrl.js.map