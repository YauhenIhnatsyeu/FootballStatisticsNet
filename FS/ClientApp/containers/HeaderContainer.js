import { connect } from "react-redux";
import { withRouter } from "react-router-dom";

import Header from "Components/header/Header";

const mapStateToProps = state => ({
    user: state.user,
});

export default
withRouter(connect(mapStateToProps)(Header));
