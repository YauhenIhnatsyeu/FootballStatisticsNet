webpackHotUpdate("main",{

/***/ "./ClientApp/actions/actionCreators/registerActionCreators.js":
/*!********************************************************************!*\
  !*** ./ClientApp/actions/actionCreators/registerActionCreators.js ***!
  \********************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.register = register;
exports.onRegisterSucceeded = onRegisterSucceeded;
exports.onRegisterFailed = onRegisterFailed;

var _ActionTypes = __webpack_require__(/*! ActionTypes */ "./ClientApp/actions/actionTypes/index.js");

var _ActionTypes2 = _interopRequireDefault(_ActionTypes);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

function register(user) {
    console.log(2);
    return {
        type: _ActionTypes2.default.REGISTER_REQUESTED,
        payload: user
    };
}

function onRegisterSucceeded(user) {
    return {
        type: _ActionTypes2.default.REGISTER_SUCCEEDED,
        payload: user
    };
}

function onRegisterFailed(error) {
    return {
        type: _ActionTypes2.default.REGISTER_FAILED,
        payload: error
    };
}

/***/ })

})
//# sourceMappingURL=main.a3359f9c703d33521bae.hot-update.js.map