import React, { Component } from "react";

import PropTypes from "prop-types";

import SectionHeader from "Components/SectionHeader";

export default class Section extends Component {
    render() {
        return (
            <div className="team-page__section">
                {this.props.title && <SectionHeader title={this.props.title} />}
                
                <div className={this.props.title && "team-page__section-content"}>
                    {this.props.children}
                </div>
            </div>
        );
    }
}

Section.propTypes = {
    title: PropTypes.string,
    children: PropTypes.node,
};

Section.defaultProps = {
    title: null,
    children: null,
};
