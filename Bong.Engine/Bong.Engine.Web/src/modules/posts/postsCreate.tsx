import * as React from 'react';
import * as Bong from '../bong';
import * as Posts from './posts';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';

export default class PostsCreate extends Bong.FormModule<Bong.EntityModule, any> {
    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = Posts.Module;
        this.Title = 'Posts - Create';
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field name='title' label='Title' type='text' placeholder='Title of a new post' />
                <Field name='url' label='Url' type='text' />
                <Textarea name='body' label='' rows={20} />
            </div>
        );
    }
}