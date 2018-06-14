import React from "react";

import PropTypes from "prop-types";

import ItemList from "Components/ItemsList";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

import FixtureItem from "Pages/teamPage/pages/fixturesPage/FixtureItem";

import head2HeadsOnOnePageCount from "Constants/head2HeadsOnOnePageCount";

import DetailsHeader from "../DetailsHeader";

import "./index.css";

export default class DetailsSection extends React.Component {
    componentDidMount() {
        this.props.fetchHead2Head(this.props.currentFixtureId);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.currentFixtureId !== nextProps.currentFixtureId) {
            this.props.fetchHead2Head(nextProps.currentFixtureId);
        }
    }

    render() {
        if (this.props.head2HeadFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.head2Head) {
            return <Loading />;
        }

        const fixtureItem = (
            <FixtureItem
                currentFixtureId={this.props.currentFixtureId}
            />
        );

        return (
            <div className="details-section">
                <div className="details-section__details-header-container">
                    <DetailsHeader
                        head2Head={this.props.head2Head}
                    />
                </div>

                <ItemList
                    items={
                        this.props.head2Head.fixtures
                            .slice(0, head2HeadsOnOnePageCount)
                    }
                    itemComponent={fixtureItem}
                    itemKey="fixture"
                />
            </div>
        );
    }
}

DetailsSection.propTypes = {
    currentFixtureId: PropTypes.number.isRequired,
    fetchHead2Head: PropTypes.func.isRequired,
    head2HeadFetchingErrorOccured: PropTypes.bool.isRequired,
    head2Head: PropTypes.shape({
        fixture: PropTypes.shape({}).isRequired,
        fixtures: PropTypes.arrayOf(PropTypes.object).isRequired,
        info: PropTypes.shape({}).isRequired,
    }),
};

DetailsSection.defaultProps = {
    head2Head: null,
};
