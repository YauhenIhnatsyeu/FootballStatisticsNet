export default async function tryExtractJsonFromResponse(response) {
    if (response && response.ok) {
        const contentType = response.headers.get("content-type");
        if (contentType && contentType.includes("application/json")) {
            const json = await response.json().then(j => j);
            return json;
        }
        return null;
    }
    return null;
}
