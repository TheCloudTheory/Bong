'use strict';

Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.Main = undefined;

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _reactRouterDom = require('react-router-dom');

var _modules = require('./modules/modules');

var modules = _interopRequireWildcard(_modules);

function _interopRequireWildcard(obj) { if (obj && obj.__esModule) { return obj; } else { var newObj = {}; if (obj != null) { for (var key in obj) { if (Object.prototype.hasOwnProperty.call(obj, key)) newObj[key] = obj[key]; } } newObj.default = obj; return newObj; } }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Main = exports.Main = function (_React$Component) {
    _inherits(Main, _React$Component);

    function Main() {
        _classCallCheck(this, Main);

        return _possibleConstructorReturn(this, (Main.__proto__ || Object.getPrototypeOf(Main)).apply(this, arguments));
    }

    _createClass(Main, [{
        key: 'render',
        value: function render() {
            return React.createElement(
                _reactRouterDom.BrowserRouter,
                null,
                React.createElement(
                    'div',
                    { className: 'container' },
                    React.createElement(
                        'div',
                        { className: 'columns' },
                        React.createElement(
                            'div',
                            { className: 'column col-2', style: { backgroundColor: 'rgb(250, 250, 250)' } },
                            React.createElement('img', { src: 'images/logo.png', style: { display: 'block', margin: '1em auto' } }),
                            React.createElement(
                                'ul',
                                { className: 'menu menu-nav' },
                                React.createElement(
                                    'li',
                                    { className: 'menu-item' },
                                    React.createElement(
                                        'a',
                                        { href: 'getting-started.html#introduction' },
                                        'Dashboard'
                                    )
                                )
                            ),
                            React.createElement(
                                'div',
                                { className: 'accordion', style: { padding: '.4rem' } },
                                React.createElement('input', { type: 'checkbox', id: 'accordion-1', name: 'accordion-checkbox', hidden: true }),
                                React.createElement(
                                    'label',
                                    { className: 'accordion-header c-hand', htmlFor: 'accordion-1' },
                                    'Content'
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'accordion-body' },
                                    React.createElement(
                                        'ul',
                                        { className: 'menu menu-nav' },
                                        React.createElement(
                                            'li',
                                            { className: 'menu-item' },
                                            React.createElement(
                                                'a',
                                                { href: 'getting-started.html#introduction' },
                                                'Pages'
                                            )
                                        ),
                                        React.createElement(
                                            'li',
                                            { className: 'menu-item' },
                                            React.createElement(
                                                'a',
                                                { href: 'getting-started.html#installation' },
                                                'Posts'
                                            )
                                        )
                                    )
                                )
                            ),
                            React.createElement(
                                'div',
                                { className: 'accordion', style: { padding: '.4rem' } },
                                React.createElement('input', { type: 'checkbox', id: 'accordion-2', name: 'accordion-checkbox', hidden: true }),
                                React.createElement(
                                    'label',
                                    { className: 'accordion-header c-hand', htmlFor: 'accordion-2' },
                                    'Settings'
                                ),
                                React.createElement(
                                    'div',
                                    { className: 'accordion-body' },
                                    React.createElement(
                                        'ul',
                                        { className: 'menu menu-nav' },
                                        React.createElement(
                                            'li',
                                            { className: 'menu-item' },
                                            React.createElement(
                                                'a',
                                                { href: 'getting-started.html#introduction' },
                                                'Site'
                                            )
                                        ),
                                        React.createElement(
                                            'li',
                                            { className: 'menu-item' },
                                            React.createElement(
                                                'a',
                                                { href: 'getting-started.html#installation' },
                                                'Email'
                                            )
                                        ),
                                        React.createElement(
                                            'li',
                                            { className: 'menu-item' },
                                            React.createElement(
                                                'a',
                                                { href: 'getting-started.html#installation' },
                                                'Azure'
                                            )
                                        )
                                    )
                                )
                            )
                        ),
                        React.createElement(
                            'div',
                            { className: 'column col-10' },
                            React.createElement(_reactRouterDom.Route, { exact: true, path: '/', component: modules.Start })
                        )
                    )
                )
            );
        }
    }]);

    return Main;
}(React.Component);

module.exports = Main;
