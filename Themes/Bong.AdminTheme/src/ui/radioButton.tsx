import * as React from 'react';

export default class RadioButton extends React.Component<RadioButtonProps, RadioButtonState> {

    constructor(props: RadioButtonProps) {
        super(props);

        this.state = {
            value: props.value
        };
    }

    render() {
        return (
            <label className="form-radio">
                <input type="radio" name={this.props.name} value={this.state.value} onChange={(e) => this.handleChange(e)} checked={this.props.isChecked && this.props.isChecked === true} />
                <i className="form-icon"></i> {this.props.label}
            </label>
        );
    }

    private handleChange(event: React.ChangeEvent<HTMLInputElement>): void {
        this.setState({
            value: event.currentTarget.value
        });
    }
}

type RadioButtonProps = {
    label: string,
    name: string,
    value?: any,
    isChecked?: boolean
}

type RadioButtonState = {
    value: any
}