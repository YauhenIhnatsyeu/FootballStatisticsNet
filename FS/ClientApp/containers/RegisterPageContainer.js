import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import RegisterPage from "Pages/RegisterPage";

import { register } from "ActionCreators";

const mapStateToProps = () => {};

const mapDispatchToProps = dispatch =>
    bindActionCreators({ register }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(RegisterPage);
