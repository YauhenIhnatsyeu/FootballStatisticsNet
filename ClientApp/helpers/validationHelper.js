import validationRules from "Constants/validationRules";

export default function validate(str, validationOptions) {
    if (!validationOptions) return null;

    const validationOptionsKeys = Object.keys(validationOptions).map(key => key);

    for (let i = 0; i < validationOptionsKeys.length; i += 1) {
        const key = validationOptionsKeys[i];
        const validationRule = validationRules[key];
        const validationValue = validationOptions[key];

        if (validationRule
            && !validationRule.isValid(str, validationValue)) {
            return validationRule.errorMessage(validationValue);
        }
    }

    return null;
}
