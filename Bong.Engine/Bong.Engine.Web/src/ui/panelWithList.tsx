import * as React from 'react';
import { Link } from 'react-router-dom';
import * as Bong from '../modules/bong';

import Repository from '../repository';
import {Toast, ToastStatus} from './toast';

export default class PanelWithList<TModule extends Bong.EntityModule> extends React.Component<PanelWithListProps, PanelWithListState> {

    private repository: Repository<TModule>;

    constructor(props: PanelWithListProps) {
        super(props);

        this.state = { data: [], isLoading: true, isError: false };
        this.repository = new Repository<TModule>();
    }

    componentDidMount() {
        this.repository.list(this.props.module).then(_ => {
            this.setState({
                data: _.data,
                isLoading: false,
                isError: false
            })
        }).catch(_ => {
            this.setState({
                isError: true,
                isLoading: false,
                errorMessage: _.message
            })
        });
    }

    render() {
        return (
            <div className="panel bong-panel-list">
                <div className="panel-header">
                    <div className="panel-title">
                        <div className="columns">
                            <div className="column col-6">
                                <h2>{this.props.title}</h2>
                            </div>
                            <div className="column col-6 text-right">
                                <Link className="btn btn-primary" to={`${this.props.module}/create`}>{this.props.createItemButtonText}</Link>
                            </div>
                        </div>
                    </div>
                </div>
                <div className="panel-nav">
                </div>
                <div className={this.state.isLoading ? 'panel-body loading' : 'panel-body'}>
                    {this.state.isError && <Toast text={this.state.errorMessage} status={ToastStatus.Error} />}
                    <table className="table table-striped table-hover">
                        <thead>
                            <tr>{this.generateHeaders()}</tr>
                        </thead>
                        <tbody>
                            {this.state.data.length > 0 && this.generateRows()}
                            {this.state.data.length === 0 && <tr className="active"><td colSpan={this.props.columns.length}>No records available</td></tr>}
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }

    private generateHeaders(): Array<JSX.Element> {
        var html: Array<JSX.Element> = [];

        this.props.columns.forEach((value, index) => {
            html.push(<th key={index}>{value}</th>)
        })

        return html;
    }

    private generateRows(): Array<JSX.Element> {
        var html: Array<JSX.Element> = [];

        this.state.data.forEach((value, index) => {
            html.push(<tr key={index}>{this.generateCols(value)}</tr>)
        })

        return html;
    }

    private generateCols(values: TModule): Array<JSX.Element> {
        var html: Array<JSX.Element> = [];

        for (let value in values) {
            html.push(<td key={value}>{values[value]}</td>)
        }

        return html;
    }
}

type PanelWithListProps = {
    title: string,
    module: string,
    createItemButtonText: string,
    columns: Array<string>
}

type PanelWithListState = {
    data: Array<any>,
    isLoading: boolean,
    isError: boolean,
    errorMessage?: string
}