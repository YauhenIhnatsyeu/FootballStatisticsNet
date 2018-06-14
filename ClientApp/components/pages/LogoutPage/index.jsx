import { Component } from "react";

import PropTypes from "prop-types";

export default class LogoutPage extends Component {
    componentWillMount() {
        this.props.logout();
    }

    render() {
        return null;
    }
}

LogoutPage.propTypes = {
    logout: PropTypes.func.isRequired,
};
