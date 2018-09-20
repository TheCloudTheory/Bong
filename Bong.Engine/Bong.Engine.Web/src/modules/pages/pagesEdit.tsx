import * as React from 'react';
import * as Bong from '../bong';

import Field from '../../ui/field';
import Textarea from '../../ui/textarea';
import Repository from '../../repository';
import { AxiosPromise } from 'axios';

export default class PagesEdit extends Bong.EditFormModule<Bong.EntityModule> {
    private repository: Repository<Bong.EntityModule>;
    
    protected Module: string;
    protected Title: string;

    constructor(props: any) {
        super(props);

        this.Module = 'page';
        this.Title = 'Pages - Edit'; 
        
        this.repository = new Repository<Bong.EntityModule>();
    }

    protected fetchData(): AxiosPromise<Bong.EntityModule> {
        return this.repository.get('page', this.id);
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field name='title' label='Title' type='text' />
                <Field name='url' label='Url' type='text' />
                <Textarea label='' rows={20} />
            </div>
        );
    }
}