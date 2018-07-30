import React from "react";

import PropTypes from "prop-types";

import ItemsList from "Reusable/items/ItemsList";

import Spinner from "Reusable/spinners/Spinner";
import Error from "Reusable/messages/Error";

import { getComponentsUsingArrayOfProps } from "Helpers/reactHelper";

import FixtureItem from "Pages/teamPage/pages/fixturesPage/FixtureItem";

import head2HeadsOnOnePageCount from "Constants/head2HeadsOnOnePageCount";

import MountAnimation from "Components/animations/MountAnimation";

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

    getFixtures = () => this.props.head2Head.fixtures
        .slice(0, head2HeadsOnOnePageCount)

    getFixtureItemProps = () => ({ currentFixtureId: this.props.currentFixtureId })

    render() {
        if (this.props.head2HeadFetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.head2Head) {
            return <Spinner />;
        }

        return (
            <MountAnimation>
                <div className="details-section">
                    <div className="details-section__details-header-container">
                        <DetailsHeader
                            head2Head={this.props.head2Head}
                        />
                    </div>

                    <ItemsList>
                        {getComponentsUsingArrayOfProps(
                            FixtureItem,
                            "fixture",
                            this.getFixtures(),
                            this.getFixtureItemProps(),
                        )}
                    </ItemsList>
                </div>
            </MountAnimation>
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
