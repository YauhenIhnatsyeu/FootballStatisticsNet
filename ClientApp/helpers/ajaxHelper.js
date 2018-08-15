export function fetchUrl(url, requestOptions) {
    if (!url) {
        return null;
    }

    return fetch(url, requestOptions);
}

export function fetchSucceeded(url, requestOptions) {
    return new Promise(async (resolve, reject) => {
        const response = await fetchUrl(url, requestOptions);

        if (response.ok) {
            resolve();
        } else {
            reject(response.statusText);
        }
    });
}

export async function fetchJson(url, requestOptions) {
    const response = await fetchUrl(url, requestOptions);

    return new Promise(async (resolve, reject) => {
        if (response && response.ok) {
            try {
                const json = await response.json();

                if (json) {
                    resolve(json);
                } else {
                    reject();
                }
            } catch (error) {
                reject(error);
            }
        } else {
            reject();
        }
    });
}
