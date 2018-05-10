webpackHotUpdate("main",{

/***/ "./ClientApp/reducers/index.js":
/*!*************************************!*\
  !*** ./ClientApp/reducers/index.js ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});

var _redux = __webpack_require__(/*! redux */ "./node_modules/redux/es/index.js");

var _leagueData = __webpack_require__(/*! ./leagueData */ "./ClientApp/reducers/leagueData.js");

var _leagueData2 = _interopRequireDefault(_leagueData);

var _teams = __webpack_require__(/*! ./teams */ "./ClientApp/reducers/teams.js");

var _teams2 = _interopRequireDefault(_teams);

var _teamData = __webpack_require__(/*! ./teamData */ "./ClientApp/reducers/teamData.js");

var _teamData2 = _interopRequireDefault(_teamData);

var _playersData = __webpack_require__(/*! ./playersData */ "./ClientApp/reducers/playersData.js");

var _playersData2 = _interopRequireDefault(_playersData);

var _fixturesData = __webpack_require__(/*! ./fixturesData */ "./ClientApp/reducers/fixturesData.js");

var _fixturesData2 = _interopRequireDefault(_fixturesData);

var _head2Head = __webpack_require__(/*! ./head2Head */ "./ClientApp/reducers/head2Head.js");

var _head2Head2 = _interopRequireDefault(_head2Head);

var _fetchingErrors = __webpack_require__(/*! ./fetchingErrors */ "./ClientApp/reducers/fetchingErrors.js");

var _fetchingErrors2 = _interopRequireDefault(_fetchingErrors);

var _favoriteTeams = __webpack_require__(/*! ./favoriteTeams */ "./ClientApp/reducers/favoriteTeams.js");

var _favoriteTeams2 = _interopRequireDefault(_favoriteTeams);

var _dates = __webpack_require__(/*! ./dates */ "./ClientApp/reducers/dates.js");

var _dates2 = _interopRequireDefault(_dates);

var _registering = __webpack_require__(/*! ./registering */ "./ClientApp/reducers/registering.js");

var _registering2 = _interopRequireDefault(_registering);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

exports.default = (0, _redux.combineReducers)({
    fetchingErrors: _fetchingErrors2.default,
    leagueData: _leagueData2.default,
    teams: _teams2.default,
    teamData: _teamData2.default,
    playersData: _playersData2.default,
    fixturesData: _fixturesData2.default,
    head2Head: _head2Head2.default,
    favoriteTeams: _favoriteTeams2.default,
    dates: _dates2.default
});

/***/ }),

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
exports.default = playersData;

var _ActionTypes = __webpack_require__(/*! ActionTypes */ "./ClientApp/actions/actionTypes/index.js");

var _ActionTypes2 = _interopRequireDefault(_ActionTypes);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var initialState = false;

function playersData() {
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
//# sourceMappingURL=main.53018b61672866945768.hot-update.js.map