import * as React from 'react';
import { Link } from 'react-router-dom';

export default class PanelWithList extends React.Component<PanelWithListProps> {

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
                <div className="panel-body">
                    <table className="table table-striped table-hover">
                        <thead>
                            <tr>{this.generateHeaders()}</tr>
                        </thead>
                        <tbody>
                            <tr className="active">
                                <td>The Shawshank Redemption</td>
                                <td>Crime, Drama</td>
                                <td>14 October 1994</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
            </div>
        );
    }

    private generateHeaders(): Array<JSX.Element> {
        var html: Array<JSX.Element> = [];

        this.props.columns.forEach(value => {
            html.push(<th>{value}</th>)
        })

        return html;
    }
}

type PanelWithListProps = {
    title: string,
    module: string,
    createItemButtonText: string,
    columns: Array<string>
}