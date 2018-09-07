import * as React from 'react';
import * as Bong from '../bong';

import PanelWithList from '../../ui/panelWithList';

export default class PagesList extends Bong.Module {

    render() {
        return (
            <PanelWithList
                title="Pages"
                module="page"
                createItemButtonText="Add new page"
                columns={['Title', 'Slug', 'Created']}
            />
        );
    }
} 