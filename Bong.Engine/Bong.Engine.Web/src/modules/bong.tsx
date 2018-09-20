import * as React from 'react';
import * as axios from 'axios';

import PanelWithForm from '../ui/panelWithForm';
import { withRouter, RouteComponentProps } from 'react-router';

export = Bong;

namespace Bong {
    export class Module extends React.Component {}

    export abstract class FormModule<TModule extends Bong.EntityModule> extends React.Component<RouteComponentProps<BongRouteComponentProps>> {
        protected abstract getForm(): JSX.Element;

        protected abstract get Title(): string;
        protected abstract get Module(): string;

        render() {
            return (<PanelWithForm module={this.Module} title={this.Title} html={this.getForm()} />);
        }
    }

    export abstract class EditFormModule<TModule extends Bong.EntityModule> extends Bong.FormModule<TModule> {
        protected get id(): string {
            return this.props.match.params.id;
        }

        protected abstract fetchData(): axios.AxiosPromise<TModule>; 

        render() {
            return (<PanelWithForm module={this.Module} title={this.Title} html={this.getForm()} fetchAction={() => this.fetchData()} />);
        }
    }

    export class EntityModule {
        public id: string;
    }

    type BongRouteComponentProps = {
        id: string
    }
}