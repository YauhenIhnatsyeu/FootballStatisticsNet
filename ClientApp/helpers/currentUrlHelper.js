export default function getCurrenUrl() {
    const { hostname, port } = window.location;
    return `https://${hostname}${port ? `:${port}` : ""}`;
}
