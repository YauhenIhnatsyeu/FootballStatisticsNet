import extractIdFromUrl from "Utilities/extractIdFromUrl";

function addPropertiesToFixture(fixtureParam) {
    const fixture = fixtureParam;

    const fixtureId = extractIdFromUrl(fixture._links.self.href);
    fixture.id = fixtureId;

    const isFinished = fixture.status === "FINISHED";
    fixture.isFinished = isFinished;

    return fixture;
}

export default function addPropertiesToFixtures(fixtures) {
    fixtures.map(fixture => addPropertiesToFixture(fixture));
}
