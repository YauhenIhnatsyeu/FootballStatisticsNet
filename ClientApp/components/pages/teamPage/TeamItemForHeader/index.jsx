import React, { Component } from "react";

import PropTypes from "prop-types";

import createTeamUrl from "Utilities/urlsCreators";

import teamRoutes from "Constants/teamRoutes";

import Tabs from "Reusable/Tabs";

// import Item from "Reusable/items/Item";
import TeamItem from "Reusable/TeamItem";

import "./index.css";

export default class TeamItemForHeader extends Component {
    render() {
        return (
            <TeamItem team={this.props.team}>
                <div className="team-item__tabs-container">
                    <Tabs
                        titles={teamRoutes.map(route => route.caption)}
                        defaultIndex={this.props.defaultTeamPageIndex}
                        hrefs={teamRoutes.map(route => createTeamUrl(this.props.team.id) + route.path)}
                    />
                </div>
            </TeamItem>
            // <Item>
            //     <div className="team-item-for-header__team">
            //         <img src={this.props.team.crestUrl} className="team-item-for-header__img" alt="" />
            //         <div className="team-item__info-container">
            //             <p className="team-item-for-header__name">{this.props.team.name}</p>
            //             <p>Short name: {this.props.team.shortName}</p>
            //         </div>
            //     </div>

                
            // </Item>
        );
    }
}

TeamItemForHeader.propTypes = {
    team: PropTypes.shape({
        id: PropTypes.number.isRequired,
        crestUrl: PropTypes.string.isRequired,
        name: PropTypes.string.isRequired,
        shortName: PropTypes.string.isRequired,
    }).isRequired,
    defaultTeamPageIndex: PropTypes.number,
};

TeamItemForHeader.defaultProps = {
    defaultTeamPageIndex: 0,
};
