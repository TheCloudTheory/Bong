import * as React from 'react';
import * as Bong from '../bong';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';

export default class PagesCreate extends Bong.FormModule<Bong.EntityModule> {
    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = 'page';
        this.Title = 'Pages - Create'; 
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field name='title' label='Title' type='text' placeholder='Title of a new page' />
                <Field name='url' label='Url' type='text' />
                <Textarea label='' rows={20} />
            </div>
        );
    }
}