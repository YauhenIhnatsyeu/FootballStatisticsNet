import React from "react";

export function injectPropsIntoComponent(Component, props) {
    return React.createElement(
        Component.type,
        Object.assign({}, Component.props, props),
        Component.children,
    );
}
