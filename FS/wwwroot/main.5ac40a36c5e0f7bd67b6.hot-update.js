webpackHotUpdate("main",{

/***/ "./ClientApp/sagas/register.js":
/*!*************************************!*\
  !*** ./ClientApp/sagas/register.js ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.default = register;

var _effects = __webpack_require__(/*! redux-saga/effects */ "./node_modules/redux-saga/es/effects.js");

var _registerHelper = __webpack_require__(/*! Helpers/registerHelper */ "./ClientApp/helpers/registerHelper.js");

var _registerHelper2 = _interopRequireDefault(_registerHelper);

var _createBrowserHistory = __webpack_require__(/*! history/createBrowserHistory */ "./node_modules/history/createBrowserHistory.js");

var _createBrowserHistory2 = _interopRequireDefault(_createBrowserHistory);

__webpack_require__(/*! ActionCreators */ "./ClientApp/actions/actionCreators/index.js");

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var _marked = /*#__PURE__*/regeneratorRuntime.mark(register);
//MOVE TO HELPERS


function register(action) {
    var user;
    return regeneratorRuntime.wrap(function register$(_context) {
        while (1) {
            switch (_context.prev = _context.next) {
                case 0:
                    try {
                        user = action.payload;


                        (0, _registerHelper2.default)(user);
                    } catch (error) {
                        console.log(error);
                        //yield put(onFixturesFetchFailed(error));
                    }

                case 1:
                case "end":
                    return _context.stop();
            }
        }
    }, _marked, this);
}

/***/ })

})
//# sourceMappingURL=main.5ac40a36c5e0f7bd67b6.hot-update.js.map