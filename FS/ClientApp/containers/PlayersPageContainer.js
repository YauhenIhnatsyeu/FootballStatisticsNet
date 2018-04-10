import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import {
    fetchPlayers,
    updatePlayersPageIndex,
} from "ActionCreators";

import PlayersPage from "Pages/teamPage/pages/playersPage/PlayersPage";

const mapStateToProps = state => ({
    team: state.teamData.team,
    players: state.playersData.players,
    playersFetchingErrorOccured: state.fetchingErrors.playersFetchingErrorOccured,
    playersPageIndex: state.playersData.playersPageIndex,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        fetchPlayers,
        updatePlayersPageIndex,
    }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(PlayersPage);
