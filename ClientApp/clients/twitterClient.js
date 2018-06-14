import { fetchUrl } from "Helpers/ajaxHelper";
import getCurrentUrl from "Helpers/currentUrlHelper";
import routePaths from "Constants/routePaths";

export default function* search(q) {
    const url = `${getCurrentUrl()}${routePaths.searchTweets}?q=${encodeURIComponent(q)}`;
    return yield fetchUrl(url);
}
