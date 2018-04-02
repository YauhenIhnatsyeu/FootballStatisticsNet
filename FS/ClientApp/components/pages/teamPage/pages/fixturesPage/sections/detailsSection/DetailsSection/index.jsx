import React from "react";

import PropTypes from "prop-types";

import ItemList from "Components/ItemsList";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

import FixtureItem from "Pages/teamPage/pages/fixturesPage/FixtureItem";

export default class DetailsSection extends React.Component {
    constructor(props) {
        super(props);

        this.props.fetchHead2Head(this.props.fixtureId);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.fixtureId !== nextProps.fixtureId) {
            this.props.fetchHead2Head(nextProps.fixtureId);
        }
    }

    render() {
        if (this.props.fetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.head2Head) {
            return <Loading />;
        }

        
        const fixtureItem = (
            <FixtureItem
                currentFixtureId={this.props.fixtureId}
            />
        );

        return (
            <ItemList
                items={this.props.head2Head.fixtures}
                itemComponent={fixtureItem}
                itemKey="fixture"
            />
        );
    }
}

DetailsSection.propTypes = {
    fixtureId: PropTypes.number.isRequired,
    fetchHead2Head: PropTypes.func.isRequired,
    fetchingErrorOccured: PropTypes.bool.isRequired,
    head2Head: PropTypes.shape({
        fixtures: PropTypes.arrayOf(PropTypes.object).isRequired,
    }),
};

DetailsSection.defaultProps = {
    head2Head: null,
};
