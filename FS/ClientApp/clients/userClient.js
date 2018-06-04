import { fetchUrl } from "Helpers/ajaxHelper";
import routePaths from "Constants/routePaths";

function getUsersFetchUrl(usersPath) {
    const { hostname, port } = window.location;
    return `http://${hostname}${port ? `:${port}` : ""}${usersPath}`;
}

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
        getUsersFetchUrl(routePaths.usersAvatar),
        getAvatarRequestOptions(avatar),
    );
}

export function* register(user, avatarId) {
    return yield fetchUrl(
        getUsersFetchUrl(routePaths.usersRegister),
        getRegisterRequestOptions(user, avatarId),
    );
}

export function* login(user) {
    return yield fetchUrl(
        getUsersFetchUrl(routePaths.usersLogin),
        getLoginRequestOptions(user),
    );
}

export function* logout() {
    return yield fetchUrl(getUsersFetchUrl(routePaths.usersLogout));
}
