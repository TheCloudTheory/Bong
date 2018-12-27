import * as React from 'react';
import * as Bong from '../bong';
import * as Pages from './pages';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';
import BongEditor from '../../ui/editor';

export default class PagesCreate extends Bong.FormModule<Bong.EntityModule, any> {
    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);
        this.state = {};

        this.Module = Pages.Module;
        this.Title = 'Pages - Create'; 
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field name="title" label="Title" type="text" placeholder="Title of a new page" />
                <Field name="url" label="Url" type="text" />
                <Textarea label="" name="body" rows={1} text={this.state.body} />
                <BongEditor stateCallback={(html: string) => this.convertEditorToHtml(html)} />
            </div>
        );
    }

    private convertEditorToHtml(html: string) {
        this.setState({
            body: html
        });
    }
}