import * as React from 'react';
import * as Bong from '../bong';
import * as Posts from './posts';

import PanelWithList from '../../ui/panelWithList';

export default class PostsList extends Bong.Module {

    render() {
        return (
            <PanelWithList
                title='Posts'
                module={Posts.Module}
                createItemButtonText='Add new post'
                columns={['Title', 'Created']}
            />
        );
    }
} 