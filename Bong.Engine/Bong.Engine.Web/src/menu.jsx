export class Menu extends React.Component {

    render() {
        return (<div className="column col-2 bong-menu">
            <img src="images/logo.png" style={{ display: 'block', margin: '1em auto' }} />
            <div className="accordion">
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
            <div className="accordion">
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
        </div>);
    }
}

module.exports = Menu;