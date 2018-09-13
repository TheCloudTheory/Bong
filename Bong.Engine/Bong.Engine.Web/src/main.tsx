import * as React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import Menu from './menu';
import * as modules from './modules/modules';

export default class Main extends React.Component<{}, {}> {
    public render() {
        return (<BrowserRouter>
            <div className="off-canvas off-canvas-sidebar-show">
                    <div className="off-canvas-sidebar active"><Menu /></div>
                    <div className="off-canvas-content">
                        <Route exact path="/" component={(modules as any)['Start']} />
                        <Route exact path="/page" component={(modules as any)['PagesList']} />
                        <Route exact path="/page/create" component={(modules as any)['PagesCreate']} />
                        <Route exact path="/post" component={(modules as any)['PostsList']} />
                        <Route exact path="/post/create" component={(modules as any)['PostsCreate']} />
                </div>
            </div>
        </BrowserRouter>);
    }
}