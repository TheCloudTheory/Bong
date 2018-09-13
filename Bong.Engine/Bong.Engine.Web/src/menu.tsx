import * as React from 'react';
import { Link } from 'react-router-dom';

export default class Menu extends React.Component<{}> {

    render() {
        return (<div className="bong-menu">
            <img src="images/logo.png" style={{ display: 'block', margin: '1em auto' }} />
            <div className="accordion">
                <input type="checkbox" id="accordion-1" name="accordion-checkbox" hidden />
                <label className="accordion-header c-hand" htmlFor="accordion-1">
                    Content
            </label>
                <div className="accordion-body">
                    <ul className="menu menu-nav">
                        <li className="menu-item"><Link to="/page">Pages</Link></li>
                        <li className="menu-item"><Link to="/post">Posts</Link></li>
                    </ul>
                </div>
            </div>
            <div className="accordion">
                <input type="checkbox" id="accordion-2" name="accordion-checkbox" hidden />
                <label className="accordion-header c-hand" htmlFor="accordion-2">
                    Settings
            </label>
                <div className="accordion-body">
                    <ul className="menu menu-nav">
                        <li className="menu-item"><Link to="/site">Site</Link></li>
                        <li className="menu-item"><Link to="/email">Email</Link></li>
                        <li className="menu-item"><Link to="/azure">Azure</Link></li>
                    </ul>
                </div>
            </div>
        </div>);
    }
}