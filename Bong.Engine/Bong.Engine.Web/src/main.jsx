import { BrowserRouter, Route } from 'react-router-dom';
import Menu from './menu';
import * as modules from './modules/modules';

export class Main extends React.Component {

    render() {
        return (<BrowserRouter>
            <div className="container">
                <div className="columns">
                    <Menu />
                    <div className="column col-10">
                        <Route exact path="/" component={modules.Start} />
                    </div>
                </div>
            </div>
        </BrowserRouter>);
    }
}

module.exports = Main;