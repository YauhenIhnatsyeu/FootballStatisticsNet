export function getValue(key) {
    const item = localStorage.getItem(key);

    return item || undefined;
}

export function getJSONValue(key) {
    const item = getValue(key);

    return item ? JSON.parse(item) : undefined;
}

export function setValue(key, value) {
    localStorage.setItem(key, value);
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
