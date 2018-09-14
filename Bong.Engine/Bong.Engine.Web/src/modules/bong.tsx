import * as React from 'react';

import PanelWithForm from '../ui/panelWithForm';

export = Bong;

namespace Bong {
    export class Module extends React.Component {}

    export abstract class FormModule<TModule extends Bong.EntityModule> extends React.Component {
        protected abstract getForm() : JSX.Element;

        protected abstract get Title(): string;
        protected abstract get Module(): string;

        render() {
            return (<PanelWithForm module={this.Module} title={this.Title} html={this.getForm()} />);
        }
    }

    export class EntityModule {
        
    }
}