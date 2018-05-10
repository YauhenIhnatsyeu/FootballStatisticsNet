webpackHotUpdate("main",{

/***/ "./ClientApp/sagas/index.js":
/*!**********************************!*\
  !*** ./ClientApp/sagas/index.js ***!
  \**********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";


Object.defineProperty(exports, "__esModule", {
    value: true
});
exports.default = rootSaga;

var _effects = __webpack_require__(/*! redux-saga/effects */ "./node_modules/redux-saga/es/effects.js");

var _fetchLeague = __webpack_require__(/*! ./fetchLeague */ "./ClientApp/sagas/fetchLeague.js");

var _fetchLeague2 = _interopRequireDefault(_fetchLeague);

var _fetchTeams = __webpack_require__(/*! ./fetchTeams */ "./ClientApp/sagas/fetchTeams.js");

var _fetchTeams2 = _interopRequireDefault(_fetchTeams);

var _fetchTeam = __webpack_require__(/*! ./fetchTeam */ "./ClientApp/sagas/fetchTeam.js");

var _fetchTeam2 = _interopRequireDefault(_fetchTeam);

var _fetchPlayers = __webpack_require__(/*! ./fetchPlayers */ "./ClientApp/sagas/fetchPlayers.js");

var _fetchPlayers2 = _interopRequireDefault(_fetchPlayers);

var _fetchFixtures = __webpack_require__(/*! ./fetchFixtures */ "./ClientApp/sagas/fetchFixtures.js");

var _fetchFixtures2 = _interopRequireDefault(_fetchFixtures);

var _fetchHead2Head = __webpack_require__(/*! ./fetchHead2Head */ "./ClientApp/sagas/fetchHead2Head.js");

var _fetchHead2Head2 = _interopRequireDefault(_fetchHead2Head);

var _useFavorites = __webpack_require__(/*! ./useFavorites */ "./ClientApp/sagas/useFavorites.js");

var _register = __webpack_require__(/*! ./register */ "./ClientApp/sagas/register.js");

var _register2 = _interopRequireDefault(_register);

function _interopRequireDefault(obj) { return obj && obj.__esModule ? obj : { default: obj }; }

var _marked = /*#__PURE__*/regeneratorRuntime.mark(rootSaga);

function rootSaga() {
    return regeneratorRuntime.wrap(function rootSaga$(_context) {
        while (1) {
            switch (_context.prev = _context.next) {
                case 0:
                    _context.next = 2;
                    return (0, _effects.takeEvery)("LEAGUE_FETCH_REQUESTED", _fetchLeague2.default);

                case 2:
                    _context.next = 4;
                    return (0, _effects.takeEvery)("TEAMS_FETCH_REQUESTED", _fetchTeams2.default);

                case 4:
                    _context.next = 6;
                    return (0, _effects.takeEvery)("TEAM_FETCH_REQUESTED", _fetchTeam2.default);

                case 6:
                    _context.next = 8;
                    return (0, _effects.takeEvery)("PLAYERS_FETCH_REQUESTED", _fetchPlayers2.default);

                case 8:
                    _context.next = 10;
                    return (0, _effects.takeEvery)("FIXTURES_FETCH_REQUESTED", _fetchFixtures2.default);

                case 10:
                    _context.next = 12;
                    return (0, _effects.takeEvery)("HEAD_2_HEAD_FETCH_REQUESTED", _fetchHead2Head2.default);

                case 12:
                    _context.next = 14;
                    return (0, _effects.takeEvery)("ADD_TEAM_TO_FAVORITES", _useFavorites.addTeamToFavorites);

                case 14:
                    _context.next = 16;
                    return (0, _effects.takeEvery)("REMOVE_TEAM_FROM_FAVORITES", _useFavorites.removeTeamFromFavorites);

                case 16:
                    _context.next = 18;
                    return (0, _effects.takeEvery)("GET_TEAMS_FROM_FAVORITES_REQUESTED", _useFavorites.getTeamsFromFavorites);

                case 18:
                    _context.next = 20;
                    return (0, _effects.takeEvery)("REGISTER_REQUESTED", _register2.default);

                case 20:
                case "end":
                    return _context.stop();
            }
        }
    }, _marked, this);
}

/***/ })

})
//# sourceMappingURL=main.8c2cd6d81e4df84097b2.hot-update.js.map