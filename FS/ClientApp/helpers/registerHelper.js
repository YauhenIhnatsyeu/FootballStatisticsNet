import routePaths from "Constants/routePaths";

export default async function register(user) {
    const requestOptions = {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(user),
    };

    const usersRegisterPath = routePaths.usersRegister;
    const { hostname, port } = location;
    const fetchUrl = `http://${hostname}${port ? `:${port}` : ""}${usersRegisterPath}`;

    fetch(fetchUrl, requestOptions);
}
