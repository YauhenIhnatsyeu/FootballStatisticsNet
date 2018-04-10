import { combineReducers } from "redux";

import leagueData from "./leagueData";
import teams from "./teams";
import teamData from "./teamData";
import playersData from "./playersData";
import fixturesData from "./fixturesData";
import head2Head from "./head2Head";
import fetchingErrors from "./fetchingErrors";
import favoriteTeams from "./favoriteTeams";
import dates from "./dates";

export default combineReducers({
    fetchingErrors,
    leagueData,
    teams,
    teamData,
    playersData,
    fixturesData,
    head2Head,
    favoriteTeams,
    dates,
});
