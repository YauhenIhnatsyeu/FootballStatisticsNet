import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";

function getLoginRequestOptions(user) {
    return {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user),
    };
}

function getRegisterRequestOptions(userParam, avatarId) {
    const user = Object.assign({}, userParam, { avatarId });

    return getLoginRequestOptions(user);
}

export function register(user, avatarId) {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.register,
        getRegisterRequestOptions(user, avatarId),
    );
}

export function login(user) {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.login,
        getLoginRequestOptions(user),
    );
}

export function logout() {
    return fetchUrl(getCurrentUrl() + apiRoutePaths.logout);
}
