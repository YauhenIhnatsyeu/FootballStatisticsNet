import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { updateLeagueIndex, fetchLeague } from "ActionCreators";

import TablePage from "Pages/tablePage/TablePage";

const mapStateToProps = state => ({
    league: state.leagueData.league,
    leagueIndex: state.leagueData.leagueIndex,
    leagueFetchingErrorOccured: state.fetchingErrors.leagueFetchingErrorOccured,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ updateLeagueIndex, fetchLeague }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(TablePage);
