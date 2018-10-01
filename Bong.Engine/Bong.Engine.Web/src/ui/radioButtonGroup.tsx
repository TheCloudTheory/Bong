import * as React from 'react';

import RadioButton from './radioButton';

export default class RadioButtonGroup extends React.Component<RadioButtonGroupProps> {

    render() {
        return (
            <div className="form-group">
                <label className="form-label">{this.props.label}</label>
                {this.generateFields()}
            </div>
        );
    }

    private generateFields(): Array<JSX.Element> {
        let html: Array<JSX.Element> = [];

        this.props.fields.forEach((value, index) => {
            if (this.props.values[index] === this.props.defaultValue) {
                html.push(<RadioButton key={index} label={value} name={this.props.name} value={this.props.values[index]} isChecked={true} />);
            }
            else {
                html.push(<RadioButton key={index} label={value} name={this.props.name} value={this.props.values[index]} />);
            }
        });

        return html;
    }
}

type RadioButtonGroupProps = {
    label: string,
    fields: Array<string>,
    name: string,
    values: Array<any>
    defaultValue: any
}