import * as React from 'react';
import * as Bong from '../bong';
import * as Pages from './pages';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';
import Repository from '../../repository';
import { AxiosPromise } from 'axios';

export default class PagesEdit extends Bong.EditFormModule<Pages.Entity, PagesEditState> {
    private repository: Repository<Pages.Entity>;

    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = 'page';
        this.Title = 'Pages - Edit';
        this.state = { id: null, title: '', url: '', body: null };

        this.repository = new Repository<Pages.Entity>();
    }

    protected fetchData(): AxiosPromise<Pages.Entity> {
        return this.repository.get('page', this.id);
    }

    protected setValues(model: Pages.Entity): void {
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

type PagesEditState = {
    id: string,
    title: string,
    url: string,
    body: string
}