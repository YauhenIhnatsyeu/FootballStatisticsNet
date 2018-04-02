import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import {
    fetchTeams,
    updateLeagueIndex,
} from "ActionCreators";

import LeagueSelector from "Pages/leaguePage/LeagueSelector";

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ updateLeagueIndex, fetchTeams }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(LeagueSelector);
