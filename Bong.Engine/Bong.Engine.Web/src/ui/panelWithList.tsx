import * as React from 'react';
import { Link } from 'react-router-dom';
import * as Bong from '../modules/bong';

import Repository from '../repository';
import { Toast, ToastStatus } from './toast';
import Modal from '../ui/modal';

export default class PanelWithList<TModule extends Bong.EntityModule> extends React.Component<PanelWithListProps, PanelWithListState> {

    private repository: Repository<TModule>;

    constructor(props: PanelWithListProps) {
        super(props);

        this.state = { data: [], isLoading: true, isError: false, isDeletingActive: false, idToDelete: null, isDeleted: false }; 
        this.repository = new Repository<TModule>();
    }

    componentDidMount() {
        this.loadData();
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
                    {this.state.isDeleted && <Toast text="Record deleted!" status={ToastStatus.Success} />}
                    <table className="table table-striped table-hover">
                        <thead>
                            <tr>{this.generateHeaders()}</tr>
                        </thead>
                        <tbody>
                            {this.state.data.length > 0 && this.generateRows()}
                            {this.state.data.length === 0 && <tr className="active"><td colSpan={this.props.columns.length + 1}>No records available</td></tr>}
                        </tbody>
                    </table>
                </div>
                {this.state.isDeletingActive &&
                    <Modal
                        title="Delete a page"
                        content="Are you sure you want to delete a page?"
                        buttonText="Delete"
                        buttonClass="error"
                        onCloseCallback={() => this.onModalCloseCallback()}
                        onProceedCallback={() => this.onProceedCallback()}
                    />}
            </div>
        );
    }

    private loadData(): void {
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

    private generateHeaders(): Array<JSX.Element> {
        var html: Array<JSX.Element> = [];

        this.props.columns.forEach((value, index) => {
            html.push(<th key={index}>{value}</th>)
        })

        html.push(<th key='9999'></th>)

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
            if (value !== 'id') {
                html.push(<td key={value}>{values[value]}</td>)
            }
        }

        html.push(
            <td key="9999" className="text-right">
                <Link className="btn btn-action btn-primary tooltip" data-tooltip="Edit" to={`${this.props.module}/edit/${values.id}`}><i className="icon icon-edit"></i></Link>
                <button className="btn btn-action btn-error tooltip" data-tooltip="Delete" onClick={() => this.handleDeletion(values.id)}><i className="icon icon-delete"></i></button>
            </td>)

        return html;
    }

    private handleDeletion(id: string): void {
        this.setState({
            isDeletingActive: true,
            idToDelete: id
        });
    }

    private onModalCloseCallback(): void {
        this.setState({
            isDeletingActive: false
        });
    }

    private onProceedCallback(): void {
        this.repository.delete(this.props.module, this.state.idToDelete).then(_ => {
            this.setState({
                isDeletingActive: false,
                idToDelete: null,
                isDeleted: true,
                isLoading: true
            });

            this.loadData();
        }).catch(_ => {
            this.setState({
                isDeletingActive: false,
                isError: true,
                idToDelete: null
            })
        });
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
    isDeleted: boolean,
    errorMessage?: string,
    isDeletingActive: boolean,
    idToDelete: string
}