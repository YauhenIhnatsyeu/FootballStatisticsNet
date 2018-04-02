import React, { Component } from "react";

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

    stringToDate = str =>
        new Date(+str.slice(0, 4), +str.slice(-5).slice(0, 2), +str.slice(-2))

    handleFromDateChange = (e) => {
        this.setState({
            fromDate: e.target.value,
        });

        this.props.updateFromDate(this.stringToDate(e.target.value));
    }

    handleToDateChange = (e) => {
        this.setState({
            toDate: e.target.value,
        });

        this.props.updateToDate(this.stringToDate(e.target.value));
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
