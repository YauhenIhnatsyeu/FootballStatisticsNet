import emailRegex from "Constants/emailRegex";

const register = {
    userName: {
        name: "userName",
        label: "Name",
        type: "text",
        validationOptions: {
            allowEmpty: false,
            minLength: 5,
            maxLength: 20,
        },
    },
    birthDate: {
        name: "birthDate",
        label: "Birth date",
        type: "date",
        defaultValue: "2000-01-01",
        validationOptions: {
            allowEmpty: false,
        },
    },
    email: {
        name: "email",
        label: "Email",
        type: "text",
        validationOptions: {
            allowEmpty: false,
            regex: emailRegex,
        },
    },
    password: {
        name: "password",
        label: "Password",
        type: "Password",
        validationOptions: {
            allowEmpty: false,
            minLength: 5,
            maxLength: 20,
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
