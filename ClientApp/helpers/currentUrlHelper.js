export default function getCurrenUrl() {
    const { hostname, port } = window.location;
    return `http://${hostname}${port ? `:${port}` : ""}`;
}
