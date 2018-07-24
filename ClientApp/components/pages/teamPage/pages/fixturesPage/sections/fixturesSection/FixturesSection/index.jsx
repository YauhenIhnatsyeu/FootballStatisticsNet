import React, { Component } from "react";

import PropTypes from "prop-types";

import Item from "Reusable/Item";

import DatesForms from "../DatesForm";
import FixturesList from "../FixturesList";

export default class FixturesSection extends Component {
    render() {
        return (
            <React.Fragment>
                <Item>
                    <DatesForms
                        dates={this.props.dates}
                        updateDates={this.props.updateDates}
                    />
                </Item>

                <FixturesList
                    fixtures={this.props.fixtures}
                    fixturesFetchingErrorOccured={this.props.fixturesFetchingErrorOccured}
                    currentFixtureId={this.props.currentFixtureId}
                    fixturesPageIndex={this.props.fixturesPageIndex}
                    updateCurrentFixtureId={this.props.updateCurrentFixtureId}
                    updateFixturesPageIndex={this.props.updateFixturesPageIndex}
                />
            </React.Fragment>
        );
    }
}

FixturesSection.propTypes = {
    fixtures: PropTypes.arrayOf(PropTypes.object),
    fixturesFetchingErrorOccured: PropTypes.bool.isRequired,
    currentFixtureId: PropTypes.number.isRequired,
    fixturesPageIndex: PropTypes.number.isRequired,
    dates: PropTypes.shape({
        from: PropTypes.object.isRequired,
        to: PropTypes.object,
    }).isRequired,
    updateCurrentFixtureId: PropTypes.func.isRequired,
    updateFixturesPageIndex: PropTypes.func.isRequired,
    updateDates: PropTypes.func.isRequired,
};

FixturesSection.defaultProps = {
    fixtures: null,
};
