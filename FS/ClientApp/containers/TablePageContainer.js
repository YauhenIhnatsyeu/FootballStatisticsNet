import { connect } from "react-redux";
import { bindActionCreators } from "redux";

import { updateLeagueIndex } from "ActionCreators";

import TablePage from "Pages/tablePage/TablePage";

const mapStateToProps = () => ({});

const mapDispatchToProps = dispatch =>
    bindActionCreators({ updateLeagueIndex }, dispatch);

export default
connect(mapStateToProps, mapDispatchToProps)(TablePage);
