import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import LoginPage from "Pages/LoginPage";

import { login } from "ActionCreators";

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ login }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(LoginPage);
