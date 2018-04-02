import React, { Component } from "react";

import PropTypes from "prop-types";

import Tabs from "Components/tabs/Tabs";
import Tab from "Components/tabs/Tab";

import "./index.css";

export default class TeamItemForHeader extends Component {
    handleTabClick = (tabIndex) => {
        this.props.updateTeamPageIndex(tabIndex);
    }

    render() {
        return (
            <div className="item">
                <div className="team-item-for-header__team">
                    <img src={this.props.team.crestUrl} className="team-item-for-header__img" alt="" />
                    <div className="team-item__info-container">
                        <p className="team-item-for-header__name">{this.props.team.name}</p>
                        <p>Short name: {this.props.team.shortName}</p>
                    </div>
                </div>

                <div className="team-item-for-header__tabs-container">
                    <Tabs
                        defaultIndex={this.props.defaultTeamPageIndex}
                        onTabClick={this.handleTabClick}
                    >
                        <Tab title="Players" />
                        <Tab title="Fixtures" />
                    </Tabs>
                </div>
            </div>
        );
    }
}

TeamItemForHeader.propTypes = {
    team: PropTypes.shape({
        crestUrl: PropTypes.string.isRequired,
        name: PropTypes.string.isRequired,
        shortName: PropTypes.string.isRequired,
    }).isRequired,
    defaultTeamPageIndex: PropTypes.number,
    updateTeamPageIndex: PropTypes.func.isRequired,
};

TeamItemForHeader.defaultProps = {
    defaultTeamPageIndex: 0,
};
