import { fetchFixtures as getFixtures } from "Clients/footballApiClient";
import addPropertiesToFixtures from "Utilities/fixturesUtils/addPropertiesToFixtures";

export default async function fetchFixtures(teamId, dates) {
    const fixturesData = await getFixtures(teamId, dates);
    const { fixtures } = fixturesData;
    addPropertiesToFixtures(fixtures);
    return fixtures;
}
