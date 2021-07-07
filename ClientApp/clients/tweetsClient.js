import { fetchJson } from "Helpers/ajaxHelper";
import { createTweetsUrl } from "Helpers/fetchingUrlsCreators";

export default function search(word) {
    return fetchJson(createTweetsUrl(encodeURIComponent(word)));
}
