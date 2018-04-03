import React from "react";
import ReactDOM from "react-dom";

import { createStore, applyMiddleware, compose } from "redux";
import createSagaMiddleware from "redux-saga";
import { Provider } from "react-redux";

import App from "Components/App";

import rootReducer from "./reducers";
import rootSaga from "./sagas";

import "./css/reset.css";
import "./css/wrapper.css";
import "./css/font-size.css";
import "./css/item.css";

const defaultState = {};

const composeEnhancers = window.__REDUX_DEVTOOLS_EXTENSION_COMPOSE__ || compose;

const sagaMiddleware = createSagaMiddleware();

const store = createStore(
    rootReducer,
    defaultState,
    composeEnhancers(applyMiddleware(sagaMiddleware)),
);

sagaMiddleware.run(rootSaga);

ReactDOM.render(
    <Provider store={store}>
        <App />
    </Provider>,
    document.getElementById("app"),
);

