import { fetchFixtures as getFixtures } from "Clients/footballApiClient";
import filterFixturesByDate from "Utilities/fixturesUtils/filterFixturesByDate";
import addPropertiesToFixtures from "Utilities/fixturesUtils/addPropertiesToFixtures";

export default function* fetchFixtures(teamId, dates) {
    const fixturesData = yield getFixtures(teamId);
    let { fixtures } = fixturesData;
    fixtures = filterFixturesByDate(fixtures, dates);
    addPropertiesToFixtures(fixtures);
    return fixtures;
}
