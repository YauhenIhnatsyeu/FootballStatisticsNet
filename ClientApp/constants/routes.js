import routePaths from "Constants/routePaths";

import TablePageContainer from "Containers/TablePageContainer";
import LeaguePageContainer from "Containers/LeaguePageContainer";
import FanClubsPageContainer from "Containers/FanClubsPageContainer";
import TeamPageContainer from "Containers/TeamPageContainer";
import RegisterPageContainer from "Containers/RegisterPageContainer";
import LoginPageContainer from "Containers/LoginPageContainer";
import LogoutPageContainer from "Containers/LogoutPageContainer";
import FanClubCreatePageContainer from "Containers/FanClubCreatePageContainer";

export default [
    {
        path: routePaths.table,
        component: TablePageContainer,
        caption: "Table",
    },
    {
        path: routePaths.teams,
        component: LeaguePageContainer,
        caption: "Teams",
    },
    {
        path: routePaths.fanClubs,
        component: FanClubsPageContainer,
        caption: "Fan clubs",
    },
    {
        path: routePaths.team,
        component: TeamPageContainer,
        caption: "Team",
    },
    {
        path: routePaths.register,
        component: RegisterPageContainer,
        caption: "Register",
    },
    {
        path: routePaths.login,
        component: LoginPageContainer,
        caption: "Log in",
    },
    {
        path: routePaths.logout,
        component: LogoutPageContainer,
        caption: "Log out",
    },
    {
        path: routePaths.createfanClub,
        component: FanClubCreatePageContainer,
        caption: "Create fan club",
    },
];
