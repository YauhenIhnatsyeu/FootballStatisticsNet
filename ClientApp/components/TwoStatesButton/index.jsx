import React, { Component } from "react";

import PropTypes from "prop-types";

export default class TwoStatesButton extends Component {
    constructor(props) {
        super(props);

        this.state = {
            currentState: this.props.defaultState,
        };
    }

    componentWillReceiveProps(nextProps) {
        if (this.state.currentState !== nextProps.defaultState) {
            this.setState({
                currentState: nextProps.defaultState,
            });
        }
    }

    handleClick = () => {
        this.setState({
            currentState: !this.state.currentState,
        });

        if (this.props.onClick) {
            this.props.onClick(this.state.currentState);
        }
    }

    render() {
        const { className, trueStateCaption, falseStateCaption } = this.props;

        return (
            <button className={className} onClick={this.handleClick}>
                {this.state.currentState ? trueStateCaption : falseStateCaption}
            </button>
        );
    }
}

TwoStatesButton.propTypes = {
    className: PropTypes.string,
    onClick: PropTypes.func,
    falseStateCaption: PropTypes.string,
    trueStateCaption: PropTypes.string,
    defaultState: PropTypes.bool,
};

TwoStatesButton.defaultProps = {
    className: null,
    onClick: null,
    falseStateCaption: null,
    trueStateCaption: null,
    defaultState: false,
};
