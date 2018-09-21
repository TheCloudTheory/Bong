import * as React from 'react';

export default class Field extends React.Component<FieldProps, FieldState> {

    constructor(props: FieldProps) {
        super(props);

        this.state = {
            value: props.value
        };
    }

    render() {
        return (
            <div className="form-group">
                <label className="form-label">{this.props.label}</label>
                <input
                    className="form-input"
                    type={this.props.type}
                    placeholder={this.props.placeholder}
                    name={this.props.name}
                    value={this.state.value}
                    onChange={(e) => this.handleChange(e)}
                />
            </div>
        );
    }

    private handleChange(event: React.ChangeEvent<HTMLInputElement>): void {
        this.setState({
            value: event.currentTarget.value
        });
    }
}

type FieldProps = {
    label: string,
    type: string,
    name: string,
    placeholder?: string,
    value?: any
}

type FieldState = {
    value: any
}