webpackHotUpdate("main",{

/***/ "./ClientApp/reducers/registering.js":
/*!*******************************************!*\
  !*** ./ClientApp/reducers/registering.js ***!
  \*******************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.default = registering;

var _ActionTypes = __webpack_require__(/*! ActionTypes */ "./ClientApp/actions/actionTypes/index.js");

var _ActionTypes2 = _interopRequireDefault(_ActionTypes);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var initialState = false;

function registering() {
    var state = arguments.length > 0 && arguments[0] !== undefined ? arguments[0] : initialState;
    var action = arguments[1];

    switch (action.type) {
        case _ActionTypes2.default.REGISTER_REQUESTED:
            return true;

        case _ActionTypes2.default.REGISTER_SUCCEEDED:
            return false;

        case _ActionTypes2.default.REGISTER_FAILED:
            return false;

        default:
            return state;
    }
}

/***/ })

})
//# sourceMappingURL=main.efacc700cddf88d70fe7.hot-update.js.map