import { BrowserRouter, Route } from 'react-router-dom';
import * as modules from './modules/modules';

export class Main extends React.Component {

    render() {
        return (<BrowserRouter>
            <div className="container">
                <div className="columns">
                    <div className="column col-2" style={{backgroundColor: 'rgb(250, 250, 250)'}}>
                    <img src="images/logo.png" style={{display: 'block', margin: '1em auto'}} />
                    <ul className="menu menu-nav">
                        <li className="menu-item"><a href="getting-started.html#introduction">Dashboard</a></li>
                    </ul>
                    <div className="accordion" style={{padding: '.4rem'}}>
                        <input type="checkbox" id="accordion-1" name="accordion-checkbox" hidden />
                        <label className="accordion-header c-hand" htmlFor="accordion-1">
                            Content
                        </label>
                        <div className="accordion-body">
                            <ul className="menu menu-nav">
                                <li className="menu-item"><a href="getting-started.html#introduction">Pages</a></li>
                                <li className="menu-item"><a href="getting-started.html#installation">Posts</a></li>
                            </ul>
                        </div>
                    </div>
                    <div className="accordion" style={{padding: '.4rem'}}>
                        <input type="checkbox" id="accordion-2" name="accordion-checkbox" hidden />
                        <label className="accordion-header c-hand" htmlFor="accordion-2">
                            Settings
                        </label>
                        <div className="accordion-body">
                            <ul className="menu menu-nav">
                                <li className="menu-item"><a href="getting-started.html#introduction">Site</a></li>
                                <li className="menu-item"><a href="getting-started.html#installation">Email</a></li>
                                <li className="menu-item"><a href="getting-started.html#installation">Azure</a></li>
                            </ul>
                        </div>
                    </div>
                    </div>
                    <div className="column col-10">
                        <Route exact path="/" component={modules.Start} />
                    </div>
                </div>
            </div>
        </BrowserRouter>);
    }
}

module.exports = Main;