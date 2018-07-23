import { connect } from "react-redux";

import OverlaySpinner from "Components/spinners/OverlaySpinner";

const mapStateToProps = state => ({
    isLoading: state.isLoading,
});

export default
connect(mapStateToProps)(OverlaySpinner);
