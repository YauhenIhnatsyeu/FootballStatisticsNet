import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import FanClubCreatePage from "Pages/FanClubCreatePage";

import { createFanClub } from "ActionCreators";

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ createFanClub }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(FanClubCreatePage);
