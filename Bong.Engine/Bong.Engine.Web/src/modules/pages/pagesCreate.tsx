import * as React from 'react';
import * as Bong from '../bong';

import PanelWithForm from '../../ui/panelWithForm';
import Field from '../../ui/field';
import Textarea from '../../ui/textarea';

export default class PagesCreate extends Bong.FormModule {

    protected getForm(): JSX.Element {
        return (
            <div>
                <Field label='Title' type='text' placeholder='Title of a new page' />
                <Textarea label='' rows={3} />
            </div>
        );
    }

    render() {
        return (<PanelWithForm title='Pages - Create' html={this.getForm()} />);
    }
}