import millisecondsValues from "Constants/millisecondsValues";

export default function fiterFixturesByDate(fixtures, dates) {
    let { to } = dates;
    to = new Date(to.getTime() + millisecondsValues.day);
    to.setHours(0, 0, 0, 0);

    if (dates.from > to) {
        return [];
    }

    return fixtures.filter((fixture) => {
        const fixtureDate = new Date(fixture.date);
        return fixtureDate >= dates.from && fixtureDate <= to;
    });
}
