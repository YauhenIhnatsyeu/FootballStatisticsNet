webpackHotUpdate("main",{

/***/ "./ClientApp/components/Main/index.jsx":
/*!*********************************************!*\
  !*** ./ClientApp/components/Main/index.jsx ***!
  \*********************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = __webpack_require__(/*! react */ "./node_modules/react/index.js");

var _react2 = _interopRequireDefault(_react);

var _reactRouterDom = __webpack_require__(/*! react-router-dom */ "./node_modules/react-router-dom/es/index.js");

var _routes = __webpack_require__(/*! Constants/routes */ "./ClientApp/constants/routes.js");

var _routes2 = _interopRequireDefault(_routes);

var _routePaths = __webpack_require__(/*! Constants/routePaths */ "./ClientApp/constants/routePaths.js");

var _routePaths2 = _interopRequireDefault(_routePaths);

__webpack_require__(/*! ./index.css */ "./ClientApp/components/Main/index.css");

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var Main = function (_Component) {
    _inherits(Main, _Component);

    function Main() {
        _classCallCheck(this, Main);

        return _possibleConstructorReturn(this, (Main.__proto__ || Object.getPrototypeOf(Main)).apply(this, arguments));
    }

    _createClass(Main, [{
        key: "render",
        value: function render() {
            return _react2.default.createElement(
                "main",
                null,
                _react2.default.createElement(
                    "div",
                    { className: "main__inner-container wrapper" },
                    _react2.default.createElement(
                        "div",
                        { className: "main__page-container" },
                        _react2.default.createElement(
                            _reactRouterDom.Switch,
                            null,
                            _routes2.default.map(function (route, index) {
                                return _react2.default.createElement(_reactRouterDom.Route, {
                                    path: route.path,
                                    render: function render(props) {
                                        return _react2.default.createElement(route.component, props);
                                    },
                                    key: index
                                });
                            }),
                            _react2.default.createElement(_reactRouterDom.Redirect, { to: _routePaths2.default.register })
                        )
                    )
                )
            );
        }
    }]);

    return Main;
}(_react.Component);

exports.default = Main;

/***/ })

})
//# sourceMappingURL=main.cc6ba060c5ebc0317e8f.hot-update.js.map