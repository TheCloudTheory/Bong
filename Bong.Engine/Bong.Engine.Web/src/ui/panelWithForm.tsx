import * as React from 'react';

export default class PanelWithForm extends React.Component<PanelWithFormProps> {

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
                <div className="panel-footer text-right">
                    <button className="btn btn-primary">Save</button>
                </div>
            </div>
        );
    }
}

type PanelWithFormProps = {
    title: string,
    html: JSX.Element
}