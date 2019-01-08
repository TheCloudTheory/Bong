"use strict";
const React = require("react");
const panelWithForm_1 = require("../ui/panelWithForm");
var Bong;
(function (Bong) {
    class Module extends React.Component {
    }
    Bong.Module = Module;
    class FormModule extends React.Component {
        render() {
            return (React.createElement(panelWithForm_1.default, { module: this.Module, title: this.Title, html: this.getForm(), isEdit: false }));
        }
    }
    Bong.FormModule = FormModule;
    class EditFormModule extends Bong.FormModule {
        get id() {
            return this.props.match.params.id;
        }
        render() {
            return (React.createElement(panelWithForm_1.default, { module: this.Module, title: this.Title, html: this.getForm(), fetchAction: () => this.fetchData(), setValues: (model) => this.setValues(model), isEdit: true, id: this.id }));
        }
    }
    Bong.EditFormModule = EditFormModule;
    class EntityModule {
    }
    Bong.EntityModule = EntityModule;
})(Bong || (Bong = {}));
module.exports = Bong;
//# sourceMappingURL=bong.js.map