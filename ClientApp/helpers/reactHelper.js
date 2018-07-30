import React from "react";

export function getComponentsUsingArrayOfProps(type, propKey, propsArray, defaultProps) {
    return propsArray.map((prop, index) => {
        const props = { key: index, ...defaultProps };
        props[propKey] = prop;
        return React.createElement(type, props);
    });
}
