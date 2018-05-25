import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import LogoutPage from "Pages/LogoutPage";

import { logout } from "ActionCreators";

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ logout }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(LogoutPage);
