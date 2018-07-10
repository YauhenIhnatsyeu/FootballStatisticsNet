import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import FanClubCreatePage from "Pages/FanClubCreatePage";

import { createFanClub, fetchTeams } from "ActionCreators";

const mapStateToProps = state => ({ teams: state.teams });

const mapDispatchToProps = dispatch =>
    bindActionCreators({ createFanClub, fetchTeams }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(FanClubCreatePage);
