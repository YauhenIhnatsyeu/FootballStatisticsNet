import React, { Component } from "react";

import PropTypes from "prop-types";

import classNames from "classnames";

import "./index.css";

export default class MountAnimation extends Component {
    constructor(props) {
        super(props);

        this.state = ({ visible: false });
    }

    componentDidMount() {
        requestAnimationFrame(() => {
            requestAnimationFrame(() => this.setState({ visible: true }));
        });
    }

    getStyle = () => classNames({
        "animation-container": true,
        "animation-container_visible": this.state.visible,
    })

    render() {
        return (
            <div className={this.getStyle()}>
                {this.props.children}
            </div>
        );
    }
}

MountAnimation.propTypes = {
    children: PropTypes.node,
};

MountAnimation.defaultProps = {
    children: null,
};
