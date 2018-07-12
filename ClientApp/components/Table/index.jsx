import React, { Component } from "react";

import PropTypes from "prop-types";

import "./index.css";

export default class Table extends Component {
    renderColumn = (column, index, isHeader) => {
        const props = {
            className: `table__col${isHeader ? " table__col_header" : ""}`,
            key: index,
        };
        const children = column;

        return isHeader
            ? <th {...props}>{children}</th>
            : <td {...props}>{children}</td>;
    }

    renderRow = (row, index, isHeader) => Array.isArray(row) && (
        <tr
            className={`table__row${isHeader ? " table__row_header" : ""}`}
            key={isHeader ? 0 : index + 1}
        >
            {row.map((column, columnIndex) =>
                this.renderColumn(column, columnIndex, isHeader))}
        </tr>
    )

    renderRows = rows => Array.isArray(rows) &&
        this.props.rows.map((row, index) => this.renderRow(row, index, false))

    render() {
        return (
            <table className="table">
                <tbody>
                    {this.renderRow(this.props.header, 0, true)}
                    {this.renderRows(this.props.rows)}
                </tbody>
            </table>
        );
    }
}

Table.propTypes = {
    header: PropTypes.arrayOf(PropTypes.any),
    rows: PropTypes.arrayOf(PropTypes.any),
};

Table.defaultProps = {
    header: null,
    rows: null,
};
