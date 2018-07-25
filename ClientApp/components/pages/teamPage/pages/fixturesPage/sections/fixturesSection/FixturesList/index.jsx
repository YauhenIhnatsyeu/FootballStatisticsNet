import React, { Component } from "react";

import PropTypes from "prop-types";

import Message from "Reusable/messages/Message";
import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import ItemsListWithPagingControls from "Reusable/items/ItemsListWithPagingControls";

import FixtureItem from "Pages/teamPage/pages/fixturesPage/FixtureItem";

import MountAnimation from "Components/animations/MountAnimation";

export default class FixturesList extends Component {
    handlePageChanged = (pageIndex) => {
        this.props.updateFixturesPageIndex(pageIndex);
    }

    handleFixtureClick = fixtureId =>
        this.props.updateCurrentFixtureId(fixtureId)

    render() {
        if (this.props.fixturesFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.fixtures) {
            return <Spinner />;
        }

        if (this.props.fixtures.length < 1) {
            return (
                <Message>
                    <p>There are no fixtures in given period</p>
                </Message>
            );
        }

        const fixtureItem = (
            <FixtureItem
                currentFixtureId={this.props.currentFixtureId}
                onClick={this.handleFixtureClick}
            />
        );

        return (
            <MountAnimation>
                <ItemsListWithPagingControls
                    items={this.props.fixtures}
                    itemComponent={fixtureItem}
                    itemKey="fixture"
                    currentPageIndex={this.props.fixturesPageIndex}
                    onPageChanged={this.handlePageChanged}
                />
            </MountAnimation>
        );
    }
}

FixturesList.propTypes = {
    fixtures: PropTypes.arrayOf(PropTypes.object),
    fixturesFetchingErrorOccured: PropTypes.bool.isRequired,
    currentFixtureId: PropTypes.number.isRequired,
    fixturesPageIndex: PropTypes.number.isRequired,
    updateCurrentFixtureId: PropTypes.func.isRequired,
    updateFixturesPageIndex: PropTypes.func.isRequired,
};

FixturesList.defaultProps = {
    fixtures: null,
};
