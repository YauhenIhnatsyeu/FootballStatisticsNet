import React from "react";

const handleChange = (onChange, retrieveNameAndValueFunc, params) => {
    console.log(params[0].target.name)
    const { name, value } = retrieveNameAndValueFunc
        ? retrieveNameAndValueFunc(...params)
        : { name: "", value: "" };

    if (onChange) {
        onChange(name, value);
    }
};

export default function formItemHOC(WrappedComponent, onChangeParam, retrieveNameAndValueFunc) {
    return (
        <WrappedComponent.type
            {...WrappedComponent.props}
            onChange={(...args) => handleChange(onChangeParam, retrieveNameAndValueFunc, args)}
        />
    );
}
