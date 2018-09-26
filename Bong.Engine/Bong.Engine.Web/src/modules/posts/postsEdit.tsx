import * as React from 'react';
import * as Bong from '../bong';
import * as Posts from './posts';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';
import Repository from '../../repository';
import { AxiosPromise } from 'axios';

export default class PostsEdit extends Bong.EditFormModule<Posts.Entity, PostsEditState> {
    private repository: Repository<Posts.Entity>;

    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = Posts.Module;
        this.Title = 'Posts - Edit';
        this.state = { id: null, title: '', url: '', body: null };

        this.repository = new Repository<Posts.Entity>();
    }

    protected fetchData(): AxiosPromise<Posts.Entity> {
        return this.repository.get(Posts.Module, this.id);
    }

    protected setValues(model: Posts.Entity): void {
        this.setState({
            id: model.id,
            title: model.title,
            url: model.url,
            body: model.body
        })
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field name='title' label='Title' type='text' value={this.state.title} />
                <Field name='url' label='Url' type='text' value={this.state.url} />
                <Textarea name='body' label='' rows={20} text={this.state.body} />
            </div>
        );
    }
}

type PostsEditState = {
    id: string,
    title: string,
    url: string,
    body: string
}