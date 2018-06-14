export function getValue(key) {
    return localStorage.getItem(key);
}

export function getJSONValue(key) {
    return JSON.parse(getValue(key));
}

export function setValue(key, value) {
    localStorage.setItem(key, value);
}

export function setJSONValue(key, value) {
    setValue(key, JSON.stringify(value));
}

export function removeValue(key) {
    localStorage.removeItem(key);
}

export function pushValue(key, value) {
    let item = getValue(key);

    if (item) {
        item = JSON.parse(item);
        item.push(value);
        item = JSON.stringify(item);
    } else {
        item = JSON.stringify([value]);
    }

    setValue(key, item);
}

export function popValue(key, value) {
    let item = getValue(key);

    if (item) {
        item = JSON.parse(item);
        const indexOfValue = item.indexOf(value);

        if (indexOfValue !== -1) {
            item.splice(indexOfValue, 1);
            item = JSON.stringify(item);
            setValue(key, item);
        }
    }
}
