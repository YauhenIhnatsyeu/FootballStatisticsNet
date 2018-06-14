import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import {
    fetchPlayers,
    updatePlayersPageIndex,
    searchTweets,
} from "ActionCreators";

import PlayersPage from "Pages/teamPage/pages/playersPage/PlayersPage";

const mapStateToProps = state => ({
    team: state.team,
    players: state.playersData.players,
    playersFetchingErrorOccured: state.fetchingErrors.playersFetchingErrorOccured,
    playersPageIndex: state.playersData.playersPageIndex,
    tweets: state.tweets,
    tweetsSearchingErrorOccured: state.fetchingErrors.tweetsSearchingErrorOccured,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({
        fetchPlayers,
        updatePlayersPageIndex,
        searchTweets,
    }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(PlayersPage);
