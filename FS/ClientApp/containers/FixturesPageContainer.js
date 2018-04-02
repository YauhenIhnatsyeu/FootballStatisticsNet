import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import {
    fetchFixtures,
    fetchHead2Head,
    updateFixtureIndex,
    updateFixturesPageIndex,
    updateFromDate,
    updateToDate,
} from "ActionCreators";

import FixturesPage from "Pages/teamPage/pages/fixturesPage/FixturesPage";

const mapStateToProps = state => ({
    fixtures: state.fixtures,
    fixtureIndex: state.fixtureIndex,
    fixturesPageIndex: state.fixturesPageIndex,
    head2Head: state.head2Head,
    dates: state.dates,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        fetchFixtures,
        fetchHead2Head,
        updateFixtureIndex,
        updateFixturesPageIndex,
        updateFromDate,
        updateToDate,
    }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(FixturesPage);
