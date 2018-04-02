import React, { Component } from "react";

import PropTypes from "prop-types";

import Tabs from "Components/tabs/Tabs";
import Tab from "Components/tabs/Tab";

import LeagueTableContainer from "Containers/LeagueTableContainer";

import leaguesData from "Constants/leaguesData";

export default class TablePage extends Component {
    handleTabClick = (newIndex) => {
        this.props.updateLeagueIndex(newIndex);
    }

    render() {
        return (
            <React.Fragment>
                <Tabs onTabClick={this.handleTabClick}>
                    {leaguesData.map((leagueData, index) =>
                        (
                            <Tab title={leagueData.title} key={index} />
                        ))
                    }
                </Tabs>

                <LeagueTableContainer />
            </React.Fragment>
        );
    }
}

TablePage.propTypes = {
    updateLeagueIndex: PropTypes.func.isRequired,
};
