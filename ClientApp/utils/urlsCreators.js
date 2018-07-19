import routePaths from "Constants/routePaths";
import defaultRoutePaths from "Constants/defaultRoutePaths";

export default function createTeamUrl(id) {
    const regexp = /:.*$/;
    if (regexp.test(routePaths.team)) {
        return routePaths.team.replace(regexp, id)
            + defaultRoutePaths.teamDefaultPath;
    }
    return "";
}
