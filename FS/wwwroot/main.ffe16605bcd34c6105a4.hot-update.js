webpackHotUpdate("main",{

/***/ "./ClientApp/components/pages/registerPage/index.jsx":
/*!***********************************************************!*\
  !*** ./ClientApp/components/pages/registerPage/index.jsx ***!
  \***********************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _createClass = function () { function defineProperties(target, props) { for (var i = 0; i < props.length; i++) { var descriptor = props[i]; descriptor.enumerable = descriptor.enumerable || false; descriptor.configurable = true; if ("value" in descriptor) descriptor.writable = true; Object.defineProperty(target, descriptor.key, descriptor); } } return function (Constructor, protoProps, staticProps) { if (protoProps) defineProperties(Constructor.prototype, protoProps); if (staticProps) defineProperties(Constructor, staticProps); return Constructor; }; }();

var _react = __webpack_require__(/*! react */ "./node_modules/react/index.js");

var _react2 = _interopRequireDefault(_react);

var _propTypes = __webpack_require__(/*! prop-types */ "./node_modules/prop-types/index.js");

var _propTypes2 = _interopRequireDefault(_propTypes);

__webpack_require__(/*! Css/form.css */ "./ClientApp/css/form.css");

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function _classCallCheck(instance, Constructor) { if (!(instance instanceof Constructor)) { throw new TypeError("Cannot call a class as a function"); } }

function _possibleConstructorReturn(self, call) { if (!self) { throw new ReferenceError("this hasn't been initialised - super() hasn't been called"); } return call && (typeof call === "object" || typeof call === "function") ? call : self; }

function _inherits(subClass, superClass) { if (typeof superClass !== "function" && superClass !== null) { throw new TypeError("Super expression must either be null or a function, not " + typeof superClass); } subClass.prototype = Object.create(superClass && superClass.prototype, { constructor: { value: subClass, enumerable: false, writable: true, configurable: true } }); if (superClass) Object.setPrototypeOf ? Object.setPrototypeOf(subClass, superClass) : subClass.__proto__ = superClass; }

var RegisterPage = function (_Component) {
    _inherits(RegisterPage, _Component);

    function RegisterPage(props) {
        _classCallCheck(this, RegisterPage);

        var _this = _possibleConstructorReturn(this, (RegisterPage.__proto__ || Object.getPrototypeOf(RegisterPage)).call(this, props));

        _this.handleChange = function (e) {
            var _e$target = e.target,
                inputName = _e$target.name,
                inputValue = _e$target.value;


            _this.user[inputName] = inputValue;

            console.log(JSON.stringify(_this.user));
        };

        _this.handleSubmit = function (e) {
            e.preventDefault();

            _this.props.register(_this.user);
        };

        _this.user = {
            login: "",
            password: ""
        };
        return _this;
    }

    _createClass(RegisterPage, [{
        key: "render",
        value: function render() {
            return _react2.default.createElement(
                "form",
                { className: "form", onSubmit: this.handleSubmit },
                _react2.default.createElement("input", { className: "form__input", type: "password", name: "password", onChange: this.handleChange }),
                _react2.default.createElement("input", { className: "form__input", type: "submit", value: "Register" })
            );
        }
    }]);

    return RegisterPage;
}(_react.Component);

exports.default = RegisterPage;


RegisterPage.propTypes = {
    register: _propTypes2.default.func.isRequired
};

RegisterPage.defaultProps = {};

/***/ })

})
//# sourceMappingURL=main.ffe16605bcd34c6105a4.hot-update.js.map