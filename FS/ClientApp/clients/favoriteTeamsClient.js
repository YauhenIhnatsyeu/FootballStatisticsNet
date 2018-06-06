import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import routePaths from "Constants/routePaths";

export function* getFavoriteTeams() {
    return yield fetchUrl(getCurrentUrl() + routePaths.getFavoriteTeams);
}

export function* addFavoriteTeam(teamId) {
    return yield fetchUrl(
        getCurrentUrl() + routePaths.addFavoriteTeam,
        {
            method: "POST",
            body: { teamId },
        },
    );
}

export function* removeFavoriteTeam(teamId) {
    return yield fetchUrl(
        getCurrentUrl() + routePaths.removeFavoriteTeam,
        {
            method: "DELETE",
            body: { teamId },
        },
    );
}
