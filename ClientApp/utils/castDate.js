export const dateToString = date =>
    date.toISOString().slice(0, 10);

export const fromStringToDateString = stringDate =>
    (new Date(stringDate)).toDateString();
