import createHistory from "history/createBrowserHistory";

export const history = createHistory();

export function push(path) {
    history.push(path);
}
