import React, { Component } from "react";

import PropTypes from "prop-types";

import Loading from "Components/messages/Loading";
import Error from "Components/messages/Error";

import Section from "Pages/teamPage/teamInfo/Section";

import FixturesSection from "FixturesPageSections/fixturesSection/FixturesSection";
import DetailsSection from "FixturesPageSections/detailsSection/DetailsSection";

export default class FixturesPage extends Component {
    constructor(props) {
        super(props);

        this.props.fetchFixtures(this.props.teamId, this.props.dates);
    }

    componentWillReceiveProps(nextProps) {
        if (JSON.stringify(this.props.dates) !== JSON.stringify(nextProps.dates)) {
            this.props.fetchFixtures(this.props.teamId, nextProps.dates);
        }
    }

    render() {
        if (this.props.fetchingErrorOccured) {
            return <Error />;
        }

        if (!this.props.fixtures) {
            return <Loading />;
        }

        return (
            <React.Fragment>
                <Section title="Fixtures">
                    <FixturesSection
                        fixtures={this.props.fixtures}
                        currentFixtureId={this.props.fixtures[this.props.fixtureIndex].id}
                        fixturesPageIndex={this.props.fixturesPageIndex}
                        dates={this.props.dates}
                        updateFixtureIndex={this.props.updateFixtureIndex}
                        updateFixturesPageIndex={this.props.updateFixturesPageIndex}
                        updateFromDate={this.props.updateFromDate}
                        updateToDate={this.props.updateToDate}
                    />
                </Section>
                <Section>
                    <DetailsSection
                        fixtureId={this.props.fixtures[this.props.fixtureIndex].id}
                        head2Head={this.props.head2Head}
                        fetchingErrorOccured={this.props.fetchingErrorOccured}
                        fetchHead2Head={this.props.fetchHead2Head}
                    />
                </Section>
            </React.Fragment>
        );
    }
}

FixturesPage.propTypes = {
    teamId: PropTypes.number.isRequired,
    fixtures: PropTypes.arrayOf(PropTypes.object),
    fixtureIndex: PropTypes.number.isRequired,
    fixturesPageIndex: PropTypes.number.isRequired,
    head2Head: PropTypes.shape({
        head2head: PropTypes.shape({
            fixtures: PropTypes.arrayOf(PropTypes.object).isRequired,
        }).isRequired,
    }),
    fetchFixtures: PropTypes.func.isRequired,
    fetchHead2Head: PropTypes.func.isRequired,
    fetchingErrorOccured: PropTypes.bool.isRequired,
    dates: PropTypes.shape({
        from: PropTypes.object.isRequired,
        to: PropTypes.object,
    }).isRequired,
    updateFixtureIndex: PropTypes.func.isRequired,
    updateFixturesPageIndex: PropTypes.func.isRequired,
    updateFromDate: PropTypes.func.isRequired,
    updateToDate: PropTypes.func.isRequired,
};

FixturesPage.defaultProps = {
    fixtures: null,
    head2Head: null,
};
