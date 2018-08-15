import searchTweets from "Clients/twitterClient";

function parseSearchResult(searchResult) {
    if (!searchResult.statuses) {
        return null;
    }

    return searchResult.statuses.map(status => ({
        name: status.user && status.user.name,
        date: status.created_at,
        isRetweet: status.retweeted_status !== undefined,
        retweetName: status.retweeted_status && status.retweeted_status.user && status.retweeted_status.user.name,
        retweetDate: status.retweeted_status && status.retweeted_status.created_at,
        text: status.text,
    }));
}

export default async function search(query) {
    const json = await searchTweets(query);

    return parseSearchResult(json.searchResult);
}
