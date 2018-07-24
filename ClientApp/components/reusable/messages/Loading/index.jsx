import React, { Component } from "react";

import Message from "../Message";

export default class Loading extends Component {
    render() {
        return (
            <Message>
                <p>Loading...</p>
                <p>Please, wait...</p>
            </Message>
        );
    }
}
