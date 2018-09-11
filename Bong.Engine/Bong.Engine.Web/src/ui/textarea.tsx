import * as React from 'react';

export default class Textarea extends React.Component<TextareaProps> {

    render() {
        return (
            <div className="form-group">
                <label className="form-label">{this.props.label}</label>
                <textarea className="form-input" placeholder={this.props.placeholder} rows={this.props.rows}>{this.props.text}</textarea>
            </div>
        );
    }
}

type TextareaProps = {
    label: string,
    rows: number,
    placeholder?: string,
    text?: string
}