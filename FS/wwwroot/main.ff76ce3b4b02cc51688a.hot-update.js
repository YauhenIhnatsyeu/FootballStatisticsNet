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

var _createBrowserHistory = __webpack_require__(/*! history/createBrowserHistory */ "./node_modules/history/createBrowserHistory.js");

var _createBrowserHistory2 = _interopRequireDefault(_createBrowserHistory);

__webpack_require__(/*! ActionCreators */ "./ClientApp/actions/actionCreators/index.js");

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var _marked = /*#__PURE__*/regeneratorRuntime.mark(register);

//MOVE TO HELPERS


function register(action) {
    var history, user, requestOptions;
    return regeneratorRuntime.wrap(function register$(_context) {
        while (1) {
            switch (_context.prev = _context.next) {
                case 0:
                    _context.prev = 0;
                    history = (0, _createBrowserHistory2.default)();

                    console.log(history);

                    user = action.payload;
                    requestOptions = {
                        method: "POST",
                        headers: { "Content-Type": "application/json" },
                        body: JSON.stringify(user)
                    };


                    fetch("http://localhost:5000/users/register", requestOptions);
                    _context.next = 13;
                    break;

                case 8:
                    _context.prev = 8;
                    _context.t0 = _context["catch"](0);

                    console.log(_context.t0);
                    _context.next = 13;
                    return (0, _effects.put)(onFixturesFetchFailed(_context.t0));

                case 13:
                case "end":
                    return _context.stop();
            }
        }
    }, _marked, this, [[0, 8]]);
}

/***/ })

})
//# sourceMappingURL=main.ff76ce3b4b02cc51688a.hot-update.js.map