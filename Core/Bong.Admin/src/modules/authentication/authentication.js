"use strict";
var Authentication;
(function (Authentication) {
    Authentication.Module = 'authentication';
    let AuthenticationType;
    (function (AuthenticationType) {
        AuthenticationType[AuthenticationType["Basic"] = 0] = "Basic";
    })(AuthenticationType = Authentication.AuthenticationType || (Authentication.AuthenticationType = {}));
})(Authentication || (Authentication = {}));
module.exports = Authentication;
//# sourceMappingURL=authentication.js.map