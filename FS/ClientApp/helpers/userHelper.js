import routePaths from "Constants/routePaths";
import keys from "Constants/keys";
import { tryExtractJsonFromResponse } from "Helpers/jsonHelper";
import { setValue, setJSONValue, removeValue } from "Helpers/localStorageHelper";

function getUsersFetchUrl(usersPath) {
    const { hostname, port } = window.location;
    return `http://${hostname}${port ? `:${port}` : ""}${usersPath}`;
}

export function* register(user) {
    const requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user),
    };

    const fetchUrl = getUsersFetchUrl(routePaths.usersRegister);

    const response = yield fetch(fetchUrl, requestOptions);
    return response.ok;
}

function* fetchAndHandleLogin(fetchUrl, requestOptions) {
    const response = yield fetch(fetchUrl, requestOptions);
    if (response.ok) {
        const json = yield tryExtractJsonFromResponse(response);
        if (json && json.user && json.token) {
            setJSONValue(keys.user, json.user);
            setValue(keys.token, json.token);
            return json.user;
        }
        return null;
    }
    return null;
}

export function* login(user) {
    const requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user),
    };

    const fetchUrl = getUsersFetchUrl(routePaths.usersLogin);

    return yield fetchAndHandleLogin(fetchUrl, requestOptions);
}

export function* logout() {
    const fetchUrl = getUsersFetchUrl(routePaths.usersLogout);

    yield fetch(fetchUrl);

    removeValue(keys.user);
    removeValue(keys.token);
}
