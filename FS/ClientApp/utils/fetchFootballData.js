export default async function fetchUrl(url) {
    const fetchInit = {
        headers: {
            "X-Auth-Token": "22cb5922f71544ee9aea4544d3256e40",
        },
    };
    const response = await fetch(url, fetchInit);
    return response.json();
}
