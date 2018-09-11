import * as React from 'react';
import { BrowserRouter, Route } from 'react-router-dom';
import Menu from './menu';
import * as modules from './modules/modules';

export default class Main extends React.Component<{}, {}> {
    public render() {
        return (<BrowserRouter>
            <div className="container">
                <div className="columns">
                    <Menu />
                    <div className="column col-10">
                        <Route exact path="/" component={(modules as any)['Start']} />
                        <Route exact path="/page" component={(modules as any)['PagesList']} />
                        <Route exact path="/page/create" component={(modules as any)['PagesCreate']} />
                    </div>
                </div>
            </div>
        </BrowserRouter>);
    }
}