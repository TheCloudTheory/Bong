import * as React from 'react';
import * as Bong from '../bong';
import * as Pages from './pages';

import PanelWithList from '../../ui/panelWithList';

export default class PagesList extends Bong.Module {

    render() {
        return (
            <PanelWithList<Bong.EntityModule>
                title='Pages'
                module={Pages.Module}
                createItemButtonText='Add new page'
                columns={['Title', 'Slug', 'Created']}
            />
        );
    }
} 