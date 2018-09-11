import * as React from 'react';

export default class Field extends React.Component<FieldProps> {

    render() {
        return (
            <div className="form-group">
                <label className="form-label">{this.props.label}</label>
                <input className="form-input" type={this.props.type} placeholder={this.props.placeholder} />
            </div>
        );
    }
}

type FieldProps = {
    label: string,
    type: string,
    placeholder?: string
}