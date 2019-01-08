import * as React from 'react';

export default class Modal extends React.Component<ModalProps, ModalState> {

    constructor(props: ModalProps) {
        super(props);

        this.state = { isProcessing: false };
    }

    render() {
        return (
            <div className="modal active" id="modal-id">
                <a onClick={() => this.props.onCloseCallback()} className="modal-overlay" aria-label="Close"></a>
                <div className="modal-container">
                    <div className="modal-header">
                        <a onClick={() => this.props.onCloseCallback()} className="btn btn-clear float-right" aria-label="Close"></a>
                        <div className="modal-title h5">{this.props.title}</div>
                    </div>
                    <div className="modal-body">
                        <div className="content">
                            {this.props.content}
                        </div>
                    </div>
                    <div className="modal-footer">
                        <button className="btn float-left" onClick={() => this.props.onCloseCallback()}>Cancel</button>
                        <button className={this.state.isProcessing ? `btn btn-${this.props.buttonClass} loading` : `btn btn-${this.props.buttonClass}`} onClick={() => this.proceed()}>{this.props.buttonText}</button>
                    </div>
                </div>
            </div>
        );
    }

    private proceed() {
        this.setState({
            isProcessing: true
        });

        this.props.onProceedCallback();
    }
}

type ModalProps = {
    title: string,
    content: string,
    buttonText: string,
    buttonClass: string,
    onCloseCallback: () => void,
    onProceedCallback: () => Promise<void>
}

type ModalState = {
    isProcessing: boolean
}