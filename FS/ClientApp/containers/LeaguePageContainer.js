import { connect } from "react-redux";

import LeaguePage from "Pages/leaguePage/LeaguePage";

const mapStateToProps = state => ({
    leagueIndex: state.leagueIndex,
});

export default
connect(mapStateToProps)(LeaguePage);
