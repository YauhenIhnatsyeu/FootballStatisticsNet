import React, { Component } from "react";

import PropTypes from "prop-types";

import { dateToString } from "Utilities/castDate";

import "Css/form.css";

export default class DatesForm extends Component {
    handleFromDateChange = (e) => {
        this.props.updateDates({
            from: new Date(e.target.value),
            to: this.props.dates.to,
        });
    }

    handleToDateChange = (e) => {
        this.props.updateDates({
            from: this.props.dates.from,
            to: new Date(e.target.value),
        });
    }

    render() {
        return (
            <form className="form">
                <input
                    className="form__input"
                    type="date"
                    value={dateToString(this.props.dates.from)}
                    onChange={this.handleFromDateChange}
                />

                <input
                    className="form__input form__input_position_down"
                    type="date"
                    value={dateToString(this.props.dates.to)}
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
    updateDates: PropTypes.func.isRequired,
};
