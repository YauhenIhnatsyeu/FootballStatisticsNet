import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import RegisterPage from "Pages/registerPage";

import { register } from "ActionCreators";

const mapStateToProps = state => ({
});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ register }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(RegisterPage);
