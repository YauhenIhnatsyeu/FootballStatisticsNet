import { connect } from "react-redux";

import Notifications from "Reusable/Notifications";

const mapStateToProps = state => ({
    notification: state.notification,
});

export default
connect(mapStateToProps)(Notifications);
