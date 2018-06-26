import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import apiRoutePaths from "Constants/apiRoutePaths";

export default function* search(q) {
    const url = `${getCurrentUrl()}${apiRoutePaths.tweets}?q=${encodeURIComponent(q)}`;
    return yield fetchUrl(url);
}
