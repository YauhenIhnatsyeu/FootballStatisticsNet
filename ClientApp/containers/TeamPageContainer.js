import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { fetchTeam, updateTeamPageIndex } from "ActionCreators";

import TeamPage from "Pages/teamPage/TeamPage";

const mapStateToProps = state => ({
    team: state.team,
    teamFetchingErrorOccured: state.fetchingErrors.teamFetchingErrorOccured,
    teamPageIndex: state.teamPageIndex,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        fetchTeam,
        updateTeamPageIndex,
    }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(TeamPage);
