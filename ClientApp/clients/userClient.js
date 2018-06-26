import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";

function getAvatarRequestOptions(avatar) {
    const body = new FormData();
    body.append("avatar", avatar);

    return { method: "POST", body };
}

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

export function* uploadAvatar(avatar) {
    return yield fetchUrl(
        getCurrentUrl() + apiRoutePaths.avatar,
        getAvatarRequestOptions(avatar),
    );
}

export function* register(user, avatarId) {
    return yield fetchUrl(
        getCurrentUrl() + apiRoutePaths.register,
        getRegisterRequestOptions(user, avatarId),
    );
}

export function* login(user) {
    return yield fetchUrl(
        getCurrentUrl() + apiRoutePaths.login,
        getLoginRequestOptions(user),
    );
}

export function* logout() {
    return yield fetchUrl(getCurrentUrl() + apiRoutePaths.logout);
}
