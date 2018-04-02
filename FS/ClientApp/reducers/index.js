import { combineReducers } from "redux";

import fetchingErrorOccured from "./fetchingErrorOccured";
import league from "./league";
import leagueIndex from "./leagueIndex";
import teams from "./teams";
import team from "./team";
import teamPageIndex from "./teamPageIndex";
import players from "./players";
import playersPageIndex from "./playersPageIndex";
import fixtures from "./fixtures";
import fixtureIndex from "./fixtureIndex";
import fixturesPageIndex from "./fixturesPageIndex";
import head2Head from "./head2Head";
import favouriteTeams from "./favouriteTeams";
import dates from "./dates";

export default combineReducers({
    fetchingErrorOccured,
    league,
    leagueIndex,
    teams,
    team,
    teamPageIndex,
    players,
    playersPageIndex,
    fixtures,
    fixtureIndex,
    fixturesPageIndex,
    head2Head,
    favouriteTeams,
    dates,
});
