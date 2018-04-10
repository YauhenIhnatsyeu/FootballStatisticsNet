import { takeEvery } from "redux-saga/effects"; import fetchLeague from "./fetchLeague";

import fetchTeams from "./fetchTeams";
import fetchTeam from "./fetchTeam";
import fetchPlayers from "./fetchPlayers";
import fetchFixtures from "./fetchFixtures";
import fetchHead2Head from "./fetchHead2Head";
import {
    addTeamToFavorites,
    removeTeamFromFavorites,
    getTeamsFromFavorites,
} from "./useFavorites";

export default function* rootSaga() {
    yield takeEvery("LEAGUE_FETCH_REQUESTED", fetchLeague);
    yield takeEvery("TEAMS_FETCH_REQUESTED", fetchTeams);
    yield takeEvery("TEAM_FETCH_REQUESTED", fetchTeam);
    yield takeEvery("PLAYERS_FETCH_REQUESTED", fetchPlayers);
    yield takeEvery("FIXTURES_FETCH_REQUESTED", fetchFixtures);
    yield takeEvery("HEAD_2_HEAD_FETCH_REQUESTED", fetchHead2Head);
    yield takeEvery("ADD_TEAM_TO_FAVORITES", addTeamToFavorites);
    yield takeEvery("REMOVE_TEAM_FROM_FAVORITES", removeTeamFromFavorites);
    yield takeEvery("GET_TEAMS_FROM_FAVORITES_REQUESTED", getTeamsFromFavorites);
}
