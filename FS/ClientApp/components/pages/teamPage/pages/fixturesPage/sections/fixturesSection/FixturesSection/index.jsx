import React, { Component } from "react";

import PropTypes from "prop-types";

import ItemsListWithPagingControls from "Components/ItemsListWithPagingControls";

import itemsOnOnePageCount from "Constants/itemsOnOnePageCount";

import FixtureItem from "Pages/teamPage/pages/fixturesPage/FixtureItem";

import DateForms from "../DatesForm";

import "./index.css";

export default class FixturesSection extends Component {
    handlePageChanged = (pageIndex) => {
        this.props.updateFixtureIndex(pageIndex * itemsOnOnePageCount);

        this.props.updateFixturesPageIndex(pageIndex);
    }

    handleFixtureClick = fixtureId =>
        this.props.updateFixtureIndex(this.props.fixtures.findIndex(f => f.id === fixtureId))

    render() {
        const fixtureItem = (
            <FixtureItem
                currentFixtureId={this.props.fixtures[this.props.fixtureIndex].id}
                onClick={this.handleFixtureClick}
            />
        );

        return (
            <React.Fragment>
                <div className="item fixture-section__dates-form-container">
                    <DateForms
                        dates={this.props.dates}
                        updateFromDate={this.props.updateFromDate}
                        updateToDate={this.props.updateToDate}
                    />
                </div>

                <ItemsListWithPagingControls
                    items={this.props.fixtures}
                    itemComponent={fixtureItem}
                    itemKey="fixture"
                    currentPageIndex={this.props.fixturesPageIndex}
                    onPageChanged={this.handlePageChanged}
                />
            </React.Fragment>
        );
    }
}

FixturesSection.propTypes = {
    fixtures: PropTypes.arrayOf(PropTypes.object),
    fixtureIndex: PropTypes.number.isRequired,
    fixturesPageIndex: PropTypes.number.isRequired,
    updateFixtureIndex: PropTypes.func.isRequired,
    updateFixturesPageIndex: PropTypes.func.isRequired,
};

FixturesSection.defaultProps = {
    fixtures: null,
};
