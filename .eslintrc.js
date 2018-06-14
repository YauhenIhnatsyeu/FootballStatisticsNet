module.exports = {
    "env": {
        "browser": true,
        "es6": true
    },
    "extends": [
        "eslint:recommended",
        "plugin:react/recommended",
        "airbnb"
    ],
    "parserOptions": {
        "sourceType": "module",
        "ecmaFeatures": {
            "experimentalObjectRestSpread": true,
            "jsx": true
        }
    },
    "plugins": [
        "react"
    ],
    "rules": {
        "linebreak-style": [
            "error",
            "windows"
        ],
        "quotes": [
            "error",
            "double"
        ],
        "semi": [
            "error",
            "always"
        ],
        "indent": [2, 4],
        "no-underscore-dangle": ["error", {
            "allow": [
                "_links",
                "__REDUX_DEVTOOLS_EXTENSION_COMPOSE__",
            ] 
        }],
        "react/prefer-stateless-function": 0,
        "react/jsx-indent": [2, 4],
        "react/jsx-indent-props": [2, 4],
        "react/no-array-index-key": 0,
        "jsx-a11y/anchor-is-valid": [ "error", {
            "components": [ "Link" ],
            "specialLink": [ "to" ],
        }],
        "max-len": ["error", { "code": 120 }]
    },
    "parser": "babel-eslint",
    "settings": {
        "react": {
            "createClass": "createReactClass",
            "pragma": "React",
            "version": "15.0",
            "flowVersion": "0.53"
        },  
        "propWrapperFunctions": [ "forbidExtraProps" ],
        "import/resolver": {
            "webpack": {
                "config": "webpack.config.js"
            }
        }
    }
};