import * as React from 'react';

export default class Textarea extends React.Component<TextareaProps, TextareaState> {

    constructor(props: TextareaProps) {
        super(props);

        this.state = {
            value: props.text
        };
    }

    render() {
        return (
            <div className={this.props.isHidden ? "d-invisible hidden" : "form-group"}>
                <label className="form-label">{this.props.label}</label>
                <textarea
                    className="form-input"
                    name={this.props.name}
                    placeholder={this.props.placeholder}
                    rows={this.props.rows}
                    value={this.state.value}
                    onChange={(e) => this.handleChange(e)} />
            </div>
        );
    }

    componentWillReceiveProps(...props: any) {
        if (props && props.length > 0) {
            this.setState({
                value: props[0].text
            });
        }
    }

    private handleChange(event: React.ChangeEvent<HTMLTextAreaElement>): void {
        this.setState({
            value: event.currentTarget.value
        });
    }
}

type TextareaProps = {
    label: string,
    rows: number,
    name: string,
    placeholder?: string,
    text?: string,
    isHidden?: boolean
}

type TextareaState = {
    value: any
}