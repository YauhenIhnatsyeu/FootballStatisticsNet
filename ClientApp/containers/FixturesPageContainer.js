import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import {
    fetchFixtures,
    fetchHead2Head,
    updateCurrentFixtureId,
    updateFixturesPageIndex,
    updateDates,
} from "ActionCreators";

import FixturesPage from "Pages/teamPage/pages/fixturesPage/FixturesPage";

const mapStateToProps = state => ({
    teamId: state.team.id,
    fixtures: state.fixturesData.fixtures,
    fixturesFetchingErrorOccured: state.fetchingErrors.fixturesFetchingErrorOccured,
    head2HeadFetchingErrorOccured: state.fetchingErrors.head2HeadFetchingErrorOccured,
    currentFixtureId: state.fixturesData.currentFixtureId,
    fixturesPageIndex: state.fixturesData.fixturesPageIndex,
    head2Head: state.head2Head,
    dates: state.dates,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        fetchFixtures,
        fetchHead2Head,
        updateCurrentFixtureId,
        updateFixturesPageIndex,
        updateDates,
    }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(FixturesPage);
