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

__webpack_require__(/*! ActionCreators */ "./ClientApp/actions/actionCreators/index.js");

var _marked = /*#__PURE__*/regeneratorRuntime.mark(register);

function register(action) {
    return regeneratorRuntime.wrap(function register$(_context) {
        while (1) {
            switch (_context.prev = _context.next) {
                case 0:
                    _context.prev = 0;

                    console.log("D");
                    _context.next = 8;
                    break;

                case 4:
                    _context.prev = 4;
                    _context.t0 = _context["catch"](0);
                    _context.next = 8;
                    return (0, _effects.put)(onFixturesFetchFailed(_context.t0));

                case 8:
                case "end":
                    return _context.stop();
            }
        }
    }, _marked, this, [[0, 4]]);
}

/***/ })

})
//# sourceMappingURL=main.a642b1bb9a1cb146f703.hot-update.js.map