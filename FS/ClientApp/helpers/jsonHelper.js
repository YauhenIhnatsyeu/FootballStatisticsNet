export function* tryExtractJsonFromResponse(response) {
    if (response && response.ok) {
        const contentType = response.headers.get("content-type");
        if (contentType && contentType.includes("application/json")) {
            return yield response.json().then(json => json);
        }
        return yield null;
    }
    return yield null;
}
