import * as React from 'react';
import * as Bong from '../bong';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';

export default class PostsCreate extends Bong.FormModule<Bong.EntityModule> {
    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = 'post';
        this.Title = 'Posts - Create';
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field name='title' label='Title' type='text' placeholder='Title of a new post' />
                <Field name='url' label='Url' type='text' />
                <Textarea label='' rows={20} />
            </div>
        );
    }
}