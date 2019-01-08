"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
const React = require("react");
const draft_js_1 = require("draft-js");
const draft_convert_1 = require("draft-convert");
const textarea_1 = require("../ui/textarea");
class BongEditor extends React.Component {
    constructor(props) {
        super(props);
        this._onClick = (e) => {
            e.preventDefault();
            let newState = draft_js_1.RichUtils.toggleInlineStyle(this.state.editorState, e.target.name);
            this.onChange(newState);
        };
        this.state = {
            editorState: typeof (this.props.html) === 'undefined' ?
                draft_js_1.EditorState.createEmpty() :
                draft_js_1.EditorState.createWithContent(draft_js_1.ContentState.createFromBlockArray(draft_js_1.convertFromHTML(this.props.html).contentBlocks)),
            html: this.props.html
        };
    }
    setEditor(editor) {
        if (editor) {
            this.editor = editor;
        }
    }
    focusEditor() {
        if (this.editor) {
            this.editor.focus();
        }
    }
    onChange(editorState) {
        this.setState({ editorState, html: draft_convert_1.convertToHTML(editorState.getCurrentContent()) });
    }
    componentDidMount() {
        this.focusEditor();
    }
    handleKeyCommand(command, editorState) {
        const newState = draft_js_1.RichUtils.handleKeyCommand(editorState, command);
        if (newState) {
            this.onChange(newState);
            return 'handled';
        }
        return 'not-handled';
    }
    blockRenderer(contentBlock) {
        const type = contentBlock.getType();
        if (type === 'MyCustomBlock') {
        }
    }
    blockStyleFn(contentBlock) {
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
        };
        const buttons = styles.map(style => {
            return React.createElement("button", { key: style, onMouseDown: this._onClick, name: style, type: "button" }, style);
        });
        return (React.createElement("div", { className: "editor", onClick: this.focusEditor.bind(this) },
            React.createElement(textarea_1.default, { label: "", name: "body", rows: 1, text: this.state.html, isHidden: true }),
            buttons,
            React.createElement(draft_js_1.Editor, { ref: this.setEditor.bind(this), editorState: this.state.editorState, handleKeyCommand: this.handleKeyCommand, onChange: this.onChange.bind(this), customStyleMap: styleMap, blockRendererFn: this.blockRenderer, blockStyleFn: this.blockStyleFn })));
    }
}
exports.default = BongEditor;
//# sourceMappingURL=editor.js.map