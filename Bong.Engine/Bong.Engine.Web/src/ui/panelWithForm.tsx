import * as React from 'react';
import { withRouter, RouteComponentProps } from 'react-router-dom';
import * as Bong from '../modules/bong';

import Repository from '../repository';
import { Toast, ToastStatus } from './toast';
import { AxiosPromise } from 'axios';

export class PanelWithForm<TModule extends Bong.EntityModule> extends React.Component<PanelWithFormProps<TModule>, PanelWithFormState<TModule>> {

    private repository: Repository<TModule>

    constructor(props: PanelWithFormProps<TModule>) {
        super(props);

        this.state = { isLoading: false, isError: false, isSuccess: false, data: null, isDataLoaded: false };
        this.repository = new Repository<TModule>();
    }

    componentDidMount() {
        if (this.props.fetchAction) {
            this.props.fetchAction().then(_ => {
                this.props.setValues(_.data);
                this.setState({
                    isDataLoaded: true
                });
            }).catch(_ => {
                this.setState({
                    isError: true
                })
            })
        }
    }

    render() {
        return (
            <form onSubmit={(e) => this.handleSubmit(e)}>
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
                        {this.state.isDataLoaded && this.props.html}
                    </div>
                    <div className="panel-footer">
                        <div className="columns">
                            <div className="column col-6">
                                <button type="button" className="btn" onClick={() => this.props.history.goBack()}>Back</button>
                            </div>
                            <div className="column col-6 text-right">
                                <button className={this.state.isLoading ? 'btn btn-primary loading' : 'btn btn-primary'}>Save</button>
                            </div>
                        </div>
                    </div>
                </div>
            </form>
        );
    }

    private handleSubmit(event: React.FormEvent<HTMLFormElement>): void {
        event.preventDefault();

        let json: object = {};
        let data = new FormData(event.currentTarget);

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

            (json as any)[key] = value;
        });

        this.repository.create<TModule>(this.props.module, json as TModule).then(_ => {
            this.setState({
                isLoading: false,
                isSuccess: true
            });

            setTimeout(() => {
                this.props.history.goBack();
            }, 1000)
        }).catch(_ => {
            this.setState({
                isError: true,
                isLoading: false
            })
        });
    }
}


type PanelWithFormProps<TModule> = RouteComponentProps<any> & {
    title: string,
    html: JSX.Element,
    module: string,
    fetchAction?: () => AxiosPromise<TModule>;
    setValues?: (model: TModule) => void;
}

type PanelWithFormState<TModule> = {
    isLoading: boolean,
    isSuccess: boolean,
    isError: boolean,
    data: TModule,
    isDataLoaded: boolean
}

export default withRouter(PanelWithForm);