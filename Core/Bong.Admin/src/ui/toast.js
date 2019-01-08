"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
class Toast extends React.Component {
    render() {
        return (React.createElement("div", { className: this.determineClass() }, this.props.text));
    }
    determineClass() {
        switch (this.props.status) {
            case ToastStatus.Default:
                return 'toast';
            case ToastStatus.Primary:
                return 'toast toast-primary';
            case ToastStatus.Success:
                return 'toast toast-success';
            case ToastStatus.Warning:
                return 'toast toast-warning';
            case ToastStatus.Error:
                return 'toast toast-error';
        }
    }
}
exports.Toast = Toast;
var ToastStatus;
(function (ToastStatus) {
    ToastStatus[ToastStatus["Default"] = 0] = "Default";
    ToastStatus[ToastStatus["Primary"] = 1] = "Primary";
    ToastStatus[ToastStatus["Success"] = 2] = "Success";
    ToastStatus[ToastStatus["Warning"] = 3] = "Warning";
    ToastStatus[ToastStatus["Error"] = 4] = "Error";
})(ToastStatus = exports.ToastStatus || (exports.ToastStatus = {}));
//# sourceMappingURL=toast.js.map