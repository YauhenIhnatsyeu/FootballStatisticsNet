import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import {
    fetchTeam,
    updateTeamPageIndex,
    resetTeamPageIndices,
} from "ActionCreators";

import TeamPage from "Pages/teamPage/TeamPage";

const mapStateToProps = state => ({
    team: state.team,
    teamPageIndex: state.teamPageIndex,
    fetchingErrorOccured: state.fetchingErrorOccured,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        fetchTeam,
        updateTeamPageIndex,
        resetTeamPageIndices,
    }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(TeamPage);
