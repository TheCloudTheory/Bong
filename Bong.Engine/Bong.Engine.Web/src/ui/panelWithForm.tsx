import * as React from 'react';
import { withRouter, RouteComponentProps } from 'react-router-dom';
import * as Bong from '../modules/bong';

import Repository from '../repository';
import {Toast, ToastStatus} from './toast';
import { AxiosPromise } from 'axios';

export class PanelWithForm<TModule extends Bong.EntityModule> extends React.Component<PanelWithFormProps, PanelWithFormState> {

    private repository: Repository<TModule>

    constructor(props: PanelWithFormProps) {
        super(props);

        this.state = { isLoading: false, isError: false, isSuccess: false };
        this.repository = new Repository<TModule>();
    }

    componentDidMount() {
        if(this.props.fetchAction) {
            this.props.fetchAction().then(_ => {
                console.log(_);
            }).catch(_ => {
                this.setState({
                    isError: true
                })
            })
        }
    }

    render() {
        return (
            <form onSubmit={this.handleSubmit.bind(this)}>
                <div className="panel bong-panel-list">
                    <div className="panel-header">
                        <div className="panel-title">
                            <div className="columns">
                                <div className="column col-12">
                                    <h2>{this.props.title}</h2>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div className="panel-nav">
                    </div>
                    <div className="panel-body">
                        {this.state.isError && <Toast text='Something went wrong!' status={ToastStatus.Error} />}
                        {this.state.isSuccess && <Toast text='Success!' status={ToastStatus.Success} />}
                        {this.props.html}
                    </div>
                    <div className="panel-footer">
                        <div className="columns">
                            <div className="column col-6">
                                <button className="btn" onClick={() => this.props.history.goBack()}>Back</button>
                            </div>
                            <div className="column col-6 text-right">
                                <button type="submit" className={this.state.isLoading ? 'btn btn-primary loading' : 'btn btn-primary'}>Save</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        );
    }

    private handleSubmit(event: Event): void {
        event.preventDefault();

        let json: object = {};
        let form = event.target as HTMLFormElement;
        let data = new FormData(form);

        this.setState({ isLoading: true });

        data.forEach((value, key) => {
            let jsonValue = (json as any)[key];
            if (typeof jsonValue !== 'undefined') {
                if (typeof jsonValue == 'object') {
                    jsonValue.push(value);
                } else {
                    let currentValue = jsonValue;

                    jsonValue = [];
                    jsonValue.push(currentValue);
                    jsonValue.push(value);
                }
            } else {
                if (key.endsWith('[]')) {
                    jsonValue = [value];
                }
                else {
                    jsonValue = value;
                }
            }
        });

        this.repository.create<TModule>(this.props.module, json as TModule).then(_ => {
            this.setState({
                isLoading: false,
                isSuccess: true
            });

            setTimeout(() => {
                this.props.history.goBack();
            }, 1000)
        });
    }
}


type PanelWithFormProps = RouteComponentProps<any> & {
    title: string,
    html: JSX.Element,
    module: string,
    fetchAction?: () => AxiosPromise<object>;
}

type PanelWithFormState = {
    isLoading: boolean,
    isSuccess: boolean,
    isError: boolean
}

export default withRouter(PanelWithForm);