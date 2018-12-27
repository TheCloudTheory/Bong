import * as React from 'react';
import { Editor, EditorState, RichUtils, DefaultDraftBlockRenderMap, ContentBlock } from 'draft-js';
import { convertToHTML } from 'draft-convert';
import Textarea from '../ui/textarea';

export default class BongEditor extends React.Component<BongEditorProps, BongEditorState> {

    private editor: any;

    constructor(props: BongEditorProps) {
        super(props);
        this.state = { editorState: EditorState.createEmpty(), html: "" };
    }

    private setEditor(editor: any) {
        if (editor) {
            this.editor = editor;
        }
    }

    private focusEditor() {
        if (this.editor) {
            this.editor.focus();
        }
    }

    private onChange(editorState: EditorState) {
        this.setState({ editorState, html: convertToHTML(editorState.getCurrentContent()) });
        this.props.stateCallback(convertToHTML(editorState.getCurrentContent()));
    }

    componentDidMount() {
        this.focusEditor();
    }

    private handleKeyCommand(command: any, editorState: EditorState) {
        const newState = RichUtils.handleKeyCommand(editorState, command);
        if (newState) {
            this.onChange(newState);
            return 'handled';
        }

        return 'not-handled';
    }

    private _onClick = (e: any) => {
        e.preventDefault();
        let newState = RichUtils.toggleInlineStyle(this.state.editorState, e.target.name);
        this.onChange(newState);
    }

    private blockRenderer(contentBlock: any) {
        const type = contentBlock.getType();
        if (type === 'MyCustomBlock') {

        }
    }

    private blockStyleFn(contentBlock: ContentBlock): string {
        return 'foo';
    }

    render() {
        const styles = ['BOLD', 'ITALIC', 'UNDERLINE', 'H1', 'H2', 'H3', 'H4', 'H5', 'H6', 'CODE', 'QUOTE'];
        const styleMap = {
            'H1': {
                fontSize: '36px'
            },
            'H2': {
                fontSize: '24px'
            },
            'H3': {
                fontSize: '18px'
            },
            'H4': {
                fontSize: '14px'
            },
            'H5': {
                fontSize: '12px'
            },
            'H6': {
                fontSize: '11px'
            }

        }
        const buttons = styles.map(style => {
            return <button key={style} onMouseDown={this._onClick} name={style} type="button">{style}</button>
        })

        return (
            <div className="editor" onClick={this.focusEditor.bind(this)}>
                <Textarea label="" name="body" rows={1} text={this.state.html} isHidden={true} />
                {buttons}
                <Editor
                    ref={this.setEditor.bind(this)}
                    editorState={this.state.editorState}
                    handleKeyCommand={this.handleKeyCommand}
                    onChange={this.onChange.bind(this)}
                    customStyleMap={styleMap}
                    blockRendererFn={this.blockRenderer}
                    blockStyleFn={this.blockStyleFn}
                />
            </div>
        );
    }
}

type BongEditorProps = {
    stateCallback(html: string): void
};

type BongEditorState = {
    editorState: EditorState,
    html: string
};