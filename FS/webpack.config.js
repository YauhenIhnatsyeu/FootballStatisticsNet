require("babel-polyfill");

const path = require("path");

module.exports = {
    entry: ["babel-polyfill", "./ClientApp/index.jsx"],
    output: {
        filename: "bundle.js",
        path: path.resolve(__dirname, "wwwroot"),
    },
    resolve: {
        alias: {
            Constants: path.resolve(__dirname, "ClientApp/constants"),

            Components: path.resolve(__dirname, "ClientApp/components"),
            Containers: path.resolve(__dirname, "ClientApp/containers"),

            Pages: path.resolve(__dirname, "ClientApp/components/pages"),
            PlayersPageSections: path.resolve(__dirname, "ClientApp/components/pages/teamPage/pages/playersPage/sections"),
            FixturesPageSections: path.resolve(__dirname, "ClientApp/components/pages/teamPage/pages/fixturesPage/sections"),

            ActionCreators: path.resolve(__dirname, "ClientApp/actions/actionCreators"),

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
    watch: true,
};
