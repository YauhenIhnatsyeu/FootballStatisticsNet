import { connect } from "react-redux";

import Header from "Components/header/Header";

const mapStateToProps = state => ({
    user: state.user,
});

export default
connect(mapStateToProps)(Header);
