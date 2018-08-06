import React, { Component } from "react";

import PropTypes from "prop-types";

import unavailableUrl from "Constants/unavailableUrl";

import { Link } from "react-router-dom";

import "./index.css";

export default class ImageWithInfo extends Component {
    handleImageError = (e) => {
        e.target.src = unavailableUrl;
    }

    tryWrapWithLink = component => (
        this.props.link
            ? (
                <Link to={this.props.link} className="iwi-item__link">
                    {component}
                </Link>
            )
            : component
    );

    renderImage = () => this.tryWrapWithLink((
        <img
            className="iwi-item__image"
            src={this.props.imageUrl}
            alt=""
            onError={this.handleImageError}
        />
    ))

    renderTitle = () => this.props.title && this.tryWrapWithLink((
        <p className="iwi-item__title">{this.props.title}</p>
    ))

    renderInfo = () => Array.isArray(this.props.info)
        && this.props.info.map((infoStr, index) => infoStr && (
            <p className="iwi-item__info" key={index}>{infoStr}</p>
        ))

    render() {
        return (
            <div className="iwi-item">
                <div className="iwi-item__image-container">
                    {this.renderImage()}
                </div>
                <div className="iwi-item__info-container">
                    {this.renderTitle()}
                    {this.renderInfo()}
                    {this.props.extraComponentForInfo}
                </div>
            </div>
        );
    }
}

ImageWithInfo.propTypes = {
    imageUrl: PropTypes.string,
    title: PropTypes.string,
    info: PropTypes.arrayOf(PropTypes.string),
    link: PropTypes.string,
    extraComponentForInfo: PropTypes.node,
};

ImageWithInfo.defaultProps = {
    imageUrl: null,
    title: null,
    info: null,
    link: null,
    extraComponentForInfo: null,
};
