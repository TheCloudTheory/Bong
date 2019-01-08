import * as React from 'react';

import Field from './field';

export default class NameUrl extends React.Component<NameUrlProps, NameUrlState> {

    constructor(props: NameUrlProps) {
        super(props);

        this.state = {
            url: ""
        };
    }

    render() {
        return (
            <div>
                <Field name="title" label="Title" type="text" placeholder="Title of a new post" onChangeCallback={(_) => this.callback(_)}/>
                <Field name="url" label="Url" type="text" value={this.state.url} />
            </div>
        );
    }

    private callback(currentValue: string): void {
        currentValue = currentValue.replace(",", "");
        currentValue = currentValue.replace(".", "");
        currentValue = currentValue.replace("!", "");
        currentValue = currentValue.replace("?", "");
        currentValue = currentValue.replace(":", "");
        currentValue = currentValue.replace(";", "");
        currentValue = currentValue.replace("`", "");
        currentValue = currentValue.replace("~", "");
        currentValue = currentValue.replace("@", "");
        currentValue = currentValue.replace("#", "");
        currentValue = currentValue.replace("$", "");
        currentValue = currentValue.replace("%", "");
        currentValue = currentValue.replace("^", "");
        currentValue = currentValue.replace("&", "");
        currentValue = currentValue.replace("*", "");
        currentValue = currentValue.replace("(", "");
        currentValue = currentValue.replace(")", "");
        currentValue = currentValue.replace("-", "");
        currentValue = currentValue.replace("_", "");
        currentValue = currentValue.replace("+", "");
        currentValue = currentValue.replace("=", "");
        currentValue = currentValue.replace("[", "");
        currentValue = currentValue.replace("]", "");
        currentValue = currentValue.replace("{", "");
        currentValue = currentValue.replace("}", "");
        currentValue = currentValue.replace("'", "");
        currentValue = currentValue.replace("", "");
        currentValue = currentValue.replace(",\"", "");
        currentValue = currentValue.replace("'", "");
        currentValue = currentValue.replace("<", "");
        currentValue = currentValue.replace(">", "");
        currentValue = currentValue.replace("|", "");
        currentValue = currentValue.replace("\\", "");
        currentValue = currentValue.replace("/", "");

        let lowercase = currentValue.toLocaleLowerCase();
        let words = lowercase.split(' ');
        let url = words.join('-');
        
        this.setState({
            url: url
        });
    }
}

type NameUrlProps = {
}

type NameUrlState = {
    url: string
}