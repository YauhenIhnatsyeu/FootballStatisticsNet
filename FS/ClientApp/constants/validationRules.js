export default {
    allowEmpty: {
        isValid: (s, value) => (s === "") === value,
        errorMessage: () => "This value cannot be empty",
    },
    minLength: {
        isValid: (s, value) => s && s.length >= value,
        errorMessage: value =>
            `This value should have greater than or equal to ${value} symbols`,
    },
    maxLength: {
        isValid: (s, value) => s && s.length <= value,
        errorMessage: value =>
            `This value should have less than or equal to ${value} symbols`,
    },
    regex: {
        isValid: (s, value) => new RegExp(value).test(s),
        errorMessage: () =>
            "This value does not match with the pattern",
    },
};
