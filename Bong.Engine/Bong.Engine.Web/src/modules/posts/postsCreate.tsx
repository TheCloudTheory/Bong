import * as React from 'react';
import * as Bong from '../bong';
import * as Posts from './posts';

import NameUrl from '../../ui/nameUrl';
import BongEditor from '../../ui/editor';

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
                <NameUrl />
                <BongEditor />
            </div>
        );
    }
}