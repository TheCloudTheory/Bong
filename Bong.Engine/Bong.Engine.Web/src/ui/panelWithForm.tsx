import * as React from 'react';
import { withRouter, RouteComponentProps } from 'react-router-dom';

export class PanelWithForm extends React.Component<PanelWithFormProps> {

    render() {
        return (
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
                    {this.props.html}
                </div>
                <div className="panel-footer">
                    <div className="columns">
                        <div className="column col-6">
                        <button className="btn" onClick={() => this.props.history.goBack()}>Back</button>
                        </div>
                        <div className="column col-6 text-right">
                            <button className="btn btn-primary">Save</button>
                        </div>
                    </div>
                </div>
            </div>
        );
    }
}


type PanelWithFormProps = RouteComponentProps<any> & {
    title: string,
    html: JSX.Element
}

export default withRouter(PanelWithForm);