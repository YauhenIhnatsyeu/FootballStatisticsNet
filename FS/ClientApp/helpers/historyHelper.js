import createHistory from "history/createBrowserHistory";

export function push(path) {
    const history = createHistory();
    history.push(path);
    location.reload();
}
