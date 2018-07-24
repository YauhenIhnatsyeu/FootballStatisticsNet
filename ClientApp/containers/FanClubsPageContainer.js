import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { fetchFanClubs } from "ActionCreators";

import FanClubsPage from "Pages/fanClubsPage/FanClubsPage";

const mapStateToProps = state => ({
    fanClubs: state.fanClubs,
    fanClubsFetchingErrorOccured: state.fetchingErrors.fanClubsFetchingErrorOccured,
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ fetchFanClubs }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(FanClubsPage);
