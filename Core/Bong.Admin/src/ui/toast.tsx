import * as React from 'react';

export class Toast extends React.Component<ToastProps> {

    render() {
        return (
            <div className={this.determineClass()}>
                {this.props.text}
            </div>
        );
    }

    private determineClass(): string {
        switch (this.props.status) {
            case ToastStatus.Default:
                return 'toast';
            case ToastStatus.Primary:
                return 'toast toast-primary';
            case ToastStatus.Success:
                return 'toast toast-success';
            case ToastStatus.Warning:
                return 'toast toast-warning';
            case ToastStatus.Error:
                return 'toast toast-error';
        }
    }
}

type ToastProps = {
    text: string,
    status: ToastStatus
}

export enum ToastStatus {
    Default,
    Primary,
    Success,
    Warning,
    Error
}