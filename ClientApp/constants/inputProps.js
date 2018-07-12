import emailRegex from "Constants/emailRegex";

const register = {
    userName: {
        name: "userName",
        label: "Name",
        type: "text",
        validation: {
            required: true,
            pattern: "\\w{5,25}",
            title: "5 to 25 letters or numbers",
        },
    },
    birthDate: {
        name: "birthDate",
        label: "Birth date",
        type: "date",
        defaultValue: "2000-01-01",
        validation: {
            required: true,
            title: "Required",
        },
    },
    email: {
        name: "email",
        label: "Email",
        type: "text",
        validation: {
            required: true,
            pattern: emailRegex.source,
            title: "Must match email pattern",
        },
    },
    password: {
        name: "password",
        label: "Password",
        type: "Password",
        validation: {
            required: true,
            pattern: "^.{5,25}$",
            title: "5 to 25 characters",
        },
    },
};

const login = {
    userName: register.userName,
    password: register.password,
};

const createFanClub = {
    name: {
        name: "name",
        label: "Name",
        type: "text",
        validationOptions: {
            allowEmpty: false,
            minLength: 5,
            maxLength: 20,
        },
    },
    description: {
        name: "description",
        label: "Description",
        type: "text",
        validationOptions: {
            allowEmpty: true,
            maxLength: 256,
        },
    },
};

export default {
    register,
    login,
    createFanClub,
};
