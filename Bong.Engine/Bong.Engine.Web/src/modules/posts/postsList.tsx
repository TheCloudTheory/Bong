import * as React from 'react';
import * as Bong from '../bong';

import PanelWithList from '../../ui/panelWithList';

export default class PostsList extends Bong.Module {

    render() {
        return (
            <PanelWithList
                title='Posts'
                module='post'
                createItemButtonText='Add new post'
                columns={['Title', 'Created']}
            />
        );
    }
} 