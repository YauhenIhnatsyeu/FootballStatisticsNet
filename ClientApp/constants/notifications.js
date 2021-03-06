const tryAgain = "Please, try again later";
const tryReload = "Please, try to reload the page";

export default {
    loginSucceeded: {
        title: "You have successfully logged in!",
    },
    loginFailed: {
        title: "Login failed",
        text: "Name or password is incorrect",
    },
    registerSucceeded: {
        title: "You have successfully signed up!",
    },
    registerFailed: {
        title: "Registration failed",
        text: tryAgain,
    },
    createFanClubFailed: {
        title: "Fan club creation failed",
        text: tryAgain,
    },
    getFavoriteTeamsFailed: {
        title: "Cannot get your favorite teams",
        text: tryReload,
    },
    addTeamToFavoritesFailed: {
        title: "Cannot add this team to favorites",
        text: tryReload,
    },
    removeTeamFromFavoritesFailed: {
        title: "Cannot remove this team from favorites",
        text: tryReload,
    },
};
