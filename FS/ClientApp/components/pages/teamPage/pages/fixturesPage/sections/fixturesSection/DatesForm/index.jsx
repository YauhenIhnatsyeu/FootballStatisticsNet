import React, { Component } from "react";

import PropTypes from "prop-types";

import { dateToString } from "Utilities/formatDate";

import "./index.css";

export default class DatesForm extends Component {
    constructor(props) {
        super(props);

        this.state = {
            fromDate: dateToString(this.props.dates.from),
            toDate: dateToString(this.props.dates.to),
        };
    }


    handleFromDateChange = (e) => {
        this.setState({
            fromDate: e.target.value,
        });

        this.props.updateFromDate(new Date(e.target.value));
    }

    handleToDateChange = (e) => {
        this.setState({
            toDate: e.target.value,
        });

        // 1 day - 86400000 milliseconds
        // Getting new date and adding a day to it
        this.props.updateToDate(new Date(new Date(e.target.value).getTime() + 86400000));
    }

    render() {
        return (
            <form className="dates-form">
                <input
                    className="dates-form__input"
                    type="date"
                    value={this.state.fromDate}
                    onChange={this.handleFromDateChange}
                />

                <input
                    className="dates-form__input dates-form__input_position_down"
                    type="date"
                    value={this.state.toDate}
                    onChange={this.handleToDateChange}
                />
            </form>
        );
    }
}

DatesForm.propTypes = {
    dates: PropTypes.shape({
        from: PropTypes.object.isRequired,
        to: PropTypes.object,
    }).isRequired,
    updateFromDate: PropTypes.func.isRequired,
    updateToDate: PropTypes.func.isRequired,
};
