import { fetchFixtures as getFixtures } from "Clients/footballApiClient";
import filterFixturesByDate from "Utilities/fixturesUtils/filterFixturesByDate";
import addPropertiesToFixtures from "Utilities/fixturesUtils/addPropertiesToFixtures";

export default async function fetchFixtures(teamId, dates) {
    const fixturesData = await getFixtures(teamId);
    let { fixtures } = fixturesData;
    fixtures = filterFixturesByDate(fixtures, dates);
    addPropertiesToFixtures(fixtures);
    return fixtures;
}
