const path = require("path");
const HtmlWebpackPlugin = require("html-webpack-plugin");
const CleanWebpackPlugin = require("clean-webpack-plugin");

module.exports = {
    devtool: "source-map",
    entry: ["babel-polyfill", "./ClientApp/index.jsx"],
    output: {
        filename: "bundle[hash].js",
        path: path.resolve(__dirname, "FS.Web/wwwroot"),
        publicPath: "/",
    },
    plugins: [
        new CleanWebpackPlugin(path.resolve(__dirname, "FS.Web/wwwroot")),
        new HtmlWebpackPlugin({
            template: path.resolve(__dirname, "FS.Web/Templates/index.html"),
            filename: "../wwwroot/index.html",
        }),
    ],
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
            {
                test: /\.svg$/,
                use: [
                    {
                        loader: "babel-loader",
                    },
                    {
                        loader: "react-svg-loader",
                        options: {
                            jsx: true,
                        },
                    },
                ],
            },
        ],
    },
};
