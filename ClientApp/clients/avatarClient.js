import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";

function getAvatarRequestOptions(avatar) {
    const body = new FormData();
    body.append("avatar", avatar);

    return { method: "POST", body };
}

export default function uploadAvatar(avatar) {
    return fetchUrl(
        getCurrentUrl() + apiRoutePaths.avatar,
        getAvatarRequestOptions(avatar),
    );
}
