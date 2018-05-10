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
    var history, requestOptions;
    return regeneratorRuntime.wrap(function register$(_context) {
        while (1) {
            switch (_context.prev = _context.next) {
                case 0:
                    _context.prev = 0;
                    history = (0, _createBrowserHistory2.default)();

                    console.log(history);

                    requestOptions = {
                        method: 'POST',
                        headers: { 'Content-Type': 'application/json' },
                        body: JSON.stringify(user)
                    };


                    fetch(config.apiUrl + '/users/register', requestOptions);
                    _context.next = 11;
                    break;

                case 7:
                    _context.prev = 7;
                    _context.t0 = _context["catch"](0);
                    _context.next = 11;
                    return (0, _effects.put)(onFixturesFetchFailed(_context.t0));

                case 11:
                case "end":
                    return _context.stop();
            }
        }
    }, _marked, this, [[0, 7]]);
}

/***/ })

})
//# sourceMappingURL=main.ded5567450280c660b36.hot-update.js.map