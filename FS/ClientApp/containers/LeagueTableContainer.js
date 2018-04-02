import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { fetchLeague } from "ActionCreators";

import LeagueTable from "Pages/tablePage/LeagueTable";

const mapStateToProps = state => ({
    league: state.league,
    leagueIndex: state.leagueIndex,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ fetchLeague }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(LeagueTable);
