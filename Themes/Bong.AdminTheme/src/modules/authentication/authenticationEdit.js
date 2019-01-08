"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const Bong = require("../bong");
const Authentication = require("./authentication");
const repository_1 = require("../../repository");
const radioButtonGroup_1 = require("../../ui/radioButtonGroup");
class AuthenticationEdit extends Bong.EditFormModule {
    constructor(props) {
        super(props);
        this.Module = Authentication.Module;
        this.Title = 'Authentication';
        this.state = { id: null };
        this.repository = new repository_1.default();
    }
    fetchData() {
        return this.repository.fetch(Authentication.Module);
    }
    setValues(model) {
        this.setState({
            id: model.id
        });
    }
    getForm() {
        return (React.createElement("div", null,
            React.createElement(radioButtonGroup_1.default, { label: "Authentication Type", fields: ["Basic"], name: "authenticationType", values: [Authentication.AuthenticationType.Basic], defaultValue: Authentication.AuthenticationType.Basic })));
    }
}
exports.default = AuthenticationEdit;
//# sourceMappingURL=authenticationEdit.js.map