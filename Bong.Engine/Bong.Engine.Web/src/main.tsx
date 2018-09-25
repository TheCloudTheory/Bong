import * as React from 'react';
import { BrowserRouter, Route, withRouter } from 'react-router-dom';
import Menu from './menu';
import * as modules from './modules/modules';

export default class Main extends React.Component<{}, {}> {
    public render() {
        return (<BrowserRouter>
            <div className="off-canvas off-canvas-sidebar-show">
                    <div className="off-canvas-sidebar active"><Menu /></div>
                    <div className="off-canvas-content">
                        <Route exact path="/" component={(modules as any)['Start']} />
                        <Route exact path="/pages" component={(modules as any)['PagesList']} />
                        <Route exact path="/pages/create" component={(modules as any)['PagesCreate']} />
                        <Route exact path="/pages/edit/:id" component={withRouter((modules as any)['PagesEdit'])} />
                        <Route exact path="/posts" component={(modules as any)['PostsList']} />
                        <Route exact path="/posts/create" component={(modules as any)['PostsCreate']} />
                </div>
            </div>
        </BrowserRouter>);
    }
}