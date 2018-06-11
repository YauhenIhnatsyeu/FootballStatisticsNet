import searchTweets from "Clients/twitterClient";
import tryExtractJsonFromResponse from "Helpers/jsonHelper";

function parseSearchResult(searchResult) {
    if (!searchResult.statuses) {
        return null;
    }

    return searchResult.statuses.map(status => ({
        name: status.user && status.user.name,
        date: status.created_at,
        isRetweet: status.retweeted_status !== undefined,
        retweetName: status.retweeted_status && status.retweeted_status.user && status.retweeted_status.name,
        retweetDate: status.retweeted_status && status.retweeted_status.created_at,
        text: status.text,
    }));
}

export default function* search(query) {
    const response = yield searchTweets(query);

    if (response.ok) {
        const json = yield tryExtractJsonFromResponse(response);

        if (json && json.searchResult) {
            return parseSearchResult(json.searchResult);
        }
    }

    return null;
}
