import teamRoutePaths from "Constants/teamRoutePaths";

import PlayersPageContainer from "Containers/PlayersPageContainer";
import FixturesPageContainer from "Containers/FixturesPageContainer";

export default [
    {
        path: teamRoutePaths.players,
        component: PlayersPageContainer,
        caption: "Players",
    },
    {
        path: teamRoutePaths.fixtures,
        component: FixturesPageContainer,
        caption: "Fixtures",
    },
];
