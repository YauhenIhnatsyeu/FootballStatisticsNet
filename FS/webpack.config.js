const path = require("path");

module.exports = {
    devtool: "source-map",
    entry: ["babel-polyfill", "./ClientApp/index.jsx"],
    output: {
        filename: "bundle.js",
        path: path.resolve(__dirname, "wwwroot"),
    },
    resolve: {
        alias: {
            Css: path.resolve(__dirname, "ClientApp/css"),

            Constants: path.resolve(__dirname, "ClientApp/constants"),

            Components: path.resolve(__dirname, "ClientApp/components"),
            Containers: path.resolve(__dirname, "ClientApp/containers"),

            Pages: path.resolve(__dirname, "ClientApp/components/pages"),
            PlayersPageSections: path.resolve(__dirname, "ClientApp/components/pages/teamPage/pages/playersPage/sections"),
            FixturesPageSections: path.resolve(__dirname, "ClientApp/components/pages/teamPage/pages/fixturesPage/sections"),

            ActionTypes: path.resolve(__dirname, "ClientApp/actions/actionTypes/index"),
            ActionCreators: path.resolve(__dirname, "ClientApp/actions/actionCreators/index"),

            Clients: path.resolve(__dirname, "ClientApp/clients"),
            Helpers: path.resolve(__dirname, "ClientApp/helpers"),
            Services: path.resolve(__dirname, "ClientApp/services"),

            Utilities: path.resolve(__dirname, "ClientApp/utils"),
        },
        extensions: [".js", ".jsx"],
    },
    module: {
        rules: [
            {
                test: /\.jsx?$/,
                exclude: /node_modules/,
                use: {
                    loader: "babel-loader",
                },
            },
            {
                test: /\.css$/,
                loader: "style-loader!css-loader",
            },
        ],
    },
    devServer: {
        contentBase: [
            //__dirname,
            path.join(__dirname, "Views/Home"),
            path.join(__dirname, "wwwroot"),
        ],
    },
};
