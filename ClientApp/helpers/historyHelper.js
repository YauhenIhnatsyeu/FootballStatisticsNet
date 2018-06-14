import createHistory from "history/createBrowserHistory";

export function getHistory() {
    return createHistory();
}

export function push(path) {
    const history = createHistory();
    history.push(path);
    window.location.reload();
}
