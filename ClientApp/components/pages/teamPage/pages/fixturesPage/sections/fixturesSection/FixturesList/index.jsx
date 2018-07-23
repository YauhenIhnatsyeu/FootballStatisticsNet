import React, { Component } from "react";

import PropTypes from "prop-types";

import Message from "Components/messages/Message";
import Spinner from "Components/spinners/Spinner";
import Error from "Components/messages/Error";

import ItemsListWithPagingControls from "Components/ItemsListWithPagingControls";

import FixtureItem from "Pages/teamPage/pages/fixturesPage/FixtureItem";

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
            <React.Fragment>
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
