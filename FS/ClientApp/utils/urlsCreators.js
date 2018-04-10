import routePaths from "Constants/routePaths";

export default function createTeamUrl(id) {
    const regexp = /:.*$/;
    if (regexp.test(routePaths.team)) {
        return routePaths.team.replace(regexp, id);
    }
    return "";
}
