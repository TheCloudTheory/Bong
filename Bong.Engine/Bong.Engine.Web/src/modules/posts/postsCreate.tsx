import * as React from 'react';
import * as Bong from '../bong';

import PanelWithForm from '../../ui/panelWithForm';
import Field from '../../ui/field';
import Textarea from '../../ui/textarea';

export default class PostsCreate extends Bong.FormModule {

    render() {
        return (<PanelWithForm title='Posts - Create' html={this.getForm()} />);
    }

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field label='Title' type='text' placeholder='Title of a new post' />
                <Field label='Url' type='text' />
                <Textarea label='' rows={20} />
            </div>
        );
    }
}