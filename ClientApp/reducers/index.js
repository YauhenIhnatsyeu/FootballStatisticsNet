import { combineReducers } from "redux";

import leagueData from "./leagueData";
import teams from "./teams";
import team from "./team";
import playersData from "./playersData";
import fixturesData from "./fixturesData";
import head2Head from "./head2Head";
import fetchingErrors from "./fetchingErrors";
import favoriteTeams from "./favoriteTeams";
import dates from "./dates";
import user from "./user";
import tweets from "./tweets";
import notification from "./notification";
import isLoading from "./isLoading";
import fanClubs from "./fanClubs";

export default combineReducers({
    fetchingErrors,
    leagueData,
    teams,
    team,
    playersData,
    fixturesData,
    head2Head,
    favoriteTeams,
    dates,
    user,
    tweets,
    notification,
    isLoading,
    fanClubs,
});
