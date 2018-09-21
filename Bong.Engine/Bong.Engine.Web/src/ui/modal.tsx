import * as React from 'react';

export default class Modal extends React.Component<ModalProps> {

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
                        <button className={`btn btn-${this.props.buttonClass}`} onClick={() => this.props.onProceedCallback()}>{this.props.buttonText}</button> 
                    </div>
                </div>
            </div>
        );
    }
}

type ModalProps = {
    title: string,
    content: string,
    buttonText: string,
    buttonClass: string,
    onCloseCallback: () => void,
    onProceedCallback: () => void
}