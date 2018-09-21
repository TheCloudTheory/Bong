import * as React from 'react';
import * as axios from 'axios';

import PanelWithForm from '../ui/panelWithForm';
import { RouteComponentProps } from 'react-router';

export = Bong;

namespace Bong {
    export class Module extends React.Component { }

    export abstract class FormModule<TModule extends Bong.EntityModule, TState> extends React.Component<RouteComponentProps<BongRouteComponentProps>, TState> {
        protected abstract getForm(): JSX.Element;

        protected abstract get Title(): string;
        protected abstract get Module(): string;

        render() {
            return (<PanelWithForm module={this.Module} title={this.Title} html={this.getForm()} />);
        }
    }

    export abstract class EditFormModule<TModule extends Bong.EntityModule, TState> extends Bong.FormModule<TModule, TState> {
        protected get id(): string {
            return this.props.match.params.id;
        }

        protected abstract fetchData(): axios.AxiosPromise<TModule>;
        protected abstract setValues(model: TModule): void;

        render() {
            return (
                <PanelWithForm
                    module={this.Module}
                    title={this.Title}
                    html={this.getForm()}
                    fetchAction={() => this.fetchData()}
                    setValues={(model: TModule) => this.setValues(model)}
                />
            );
        }
    }

    export class EntityModule {
        public id: string;
    }

    type BongRouteComponentProps = {
        id: string
    }
}