import * as React from 'react';

import PanelWithForm from '../ui/panelWithForm';

export = Bong;

namespace Bong {
    export class Module extends React.Component {}

    export abstract class FormModule extends React.Component {
        protected abstract getForm() : JSX.Element;

        protected abstract get Title(): string;

        render() {
            return (<PanelWithForm title={this.Title} html={this.getForm()} />);
        }
    }

    export class EntityModule {
        
    }
}