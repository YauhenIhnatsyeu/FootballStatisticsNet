import { fetchHead2Head as getHead2Head } from "Clients/footballApiClient";
import addPropertiesToFixtures from "Utilities/fixturesUtils/addPropertiesToFixtures";

export default function* fetchHead2Head(fixtureId) {
    const head2HeadData = yield getHead2Head(fixtureId);

    const { head2head: head2Head } = head2HeadData;
    const { fixtures } = head2Head;
    addPropertiesToFixtures(fixtures);
    delete head2Head.fixtures;

    return {
        fixtures,
        fixture: head2HeadData.fixture,
        info: head2Head,
    };
}
