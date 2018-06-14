import validationRules from "Constants/validationRules";

export default function validate(str, validationOptions) {
    if (!validationOptions) return null;

    const validationOptionsKeys = Object.keys(validationOptions).map(key => key);

    for (let i = 0; i < validationOptionsKeys.length; i += 1) {
        const key = validationOptionsKeys[i];
        const validationRule = validationRules[key];
        const requestedValue = validationOptions[key];

        if (validationRule
            && !validationRule.isValid(str, requestedValue)) {
            return validationRule.errorMessage(requestedValue);
        }
    }

    return null;
}
