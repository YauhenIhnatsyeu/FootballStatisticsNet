import React from "react";

import Input from "Components/form/Input";

export function renderInputs(inputProps) {
    return Object.keys(inputProps).map((key, index) => (
        React.createElement(
            Input,
            {
                name: inputProps[key].name,
                label: inputProps[key].label,
                type: inputProps[key].type,
                defaultValue: inputProps[key].defaultValue,
                validation: inputProps[key].validation,
                key: index,
            },
        )
    ));
}
