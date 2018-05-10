import routePaths from "Constants/routePaths";

import TablePageContainer from "Containers/TablePageContainer";
import LeaguePageContainer from "Containers/LeaguePageContainer";
import TeamPageContainer from "Containers/TeamPageContainer";
import RegisterPageContainer from "Containers/RegisterPageContainer";

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
        path: routePaths.team,
        component: TeamPageContainer,
        caption: "Team",
    },
    {
        path: routePaths.register,
        component: RegisterPageContainer,
        caption: "Register",
    },
];
