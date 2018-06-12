import React, { Component } from "react";

import PropTypes from "prop-types";

import Section from "Pages/teamPage/Section";

import FixturesSection from "FixturesPageSections/fixturesSection/FixturesSection";
import DetailsSection from "FixturesPageSections/detailsSection/DetailsSection";

export default class FixturesPage extends Component {
    componentDidMount() {
        this.props.fetchFixtures(this.props.teamId, this.props.dates);
    }

    componentWillReceiveProps(nextProps) {
        if (this.props.dates.from !== nextProps.dates.from
                || this.props.dates.to !== nextProps.dates.to) {
            this.props.fetchFixtures(this.props.teamId, nextProps.dates);
        }
    }

    render() {
        return (
            <React.Fragment>
                <Section title="Fixtures">
                    <FixturesSection
                        fixtures={this.props.fixtures}
                        fixturesFetchingErrorOccured={this.props.fixturesFetchingErrorOccured}
                        currentFixtureId={this.props.currentFixtureId}
                        fixturesPageIndex={this.props.fixturesPageIndex}
                        dates={this.props.dates}
                        updateCurrentFixtureId={this.props.updateCurrentFixtureId}
                        updateFixturesPageIndex={this.props.updateFixturesPageIndex}
                        updateDates={this.props.updateDates}
                    />
                </Section>

                {(!this.props.fixturesFetchingErrorOccured && this.props.fixtures && this.props.fixtures.length > 0)
                && (
                    <Section>
                        <DetailsSection
                            currentFixtureId={this.props.currentFixtureId}
                            head2Head={this.props.head2Head}
                            head2HeadFetchingErrorOccured={this.props.head2HeadFetchingErrorOccured}
                            fetchHead2Head={this.props.fetchHead2Head}
                        />
                    </Section>
                )}
            </React.Fragment>
        );
    }
}

FixturesPage.propTypes = {
    teamId: PropTypes.number.isRequired,
    fixtures: PropTypes.arrayOf(PropTypes.object),
    currentFixtureId: PropTypes.number.isRequired,
    fixturesPageIndex: PropTypes.number.isRequired,
    head2Head: PropTypes.shape({
        fixture: PropTypes.shape({}).isRequired,
        fixtures: PropTypes.arrayOf(PropTypes.object).isRequired,
        info: PropTypes.shape({}).isRequired,
    }),
    fetchFixtures: PropTypes.func.isRequired,
    fetchHead2Head: PropTypes.func.isRequired,
    fixturesFetchingErrorOccured: PropTypes.bool.isRequired,
    head2HeadFetchingErrorOccured: PropTypes.bool.isRequired,
    dates: PropTypes.shape({
        from: PropTypes.object.isRequired,
        to: PropTypes.object,
    }).isRequired,
    updateCurrentFixtureId: PropTypes.func.isRequired,
    updateFixturesPageIndex: PropTypes.func.isRequired,
    updateDates: PropTypes.func.isRequired,
};

FixturesPage.defaultProps = {
    fixtures: null,
    head2Head: null,
};
