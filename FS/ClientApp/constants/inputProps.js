const register = {
    name: {
        name: "userName",
        label: "Name",
        type: "text",
    },
    birthDate: {
        name: "birthDate",
        label: "Birth date",
        type: "date",
        value: "2000-01-01",
    },
    email: {
        name: "email",
        label: "Email",
        type: "text",
    },
    password: {
        name: "password",
        label: "Password",
        type: "Password",
    },
};

export default {
    register,
    login: {
        name: register.name,
        password: register.password,
    },
};
