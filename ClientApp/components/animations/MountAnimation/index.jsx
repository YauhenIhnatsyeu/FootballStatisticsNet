import React, { Component } from "react";

import PropTypes from "prop-types";

import classNames from "classnames";

import Animation from "Helpers/animationHelper";

import "./index.css";

export default class MountAnimation extends Component {
    constructor(props) {
        super(props);

        this.animation = new Animation();
        this.state = ({ visible: false });
    }

    componentDidMount() {
        this.animation.start(() => this.setState({ visible: true }));
    }

    componentWillUnmount() {
        this.animation.stop();
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
