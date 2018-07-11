export function getChangedValueFromEvent(e) {
    if (e && e.target && e.target.name && e.target.value) {
        return e.target.value;
    }
    return "";
}

export function getChangedValueFromFileEvent(e) {
    if (e && e.target && e.target.name && e.target.files) {
        return e.target.files;
    }
    return "";
}

export function getChangedValueFromTeamChooser(teamComponent) {
    if (teamComponent && teamComponent.props && teamComponent.props.team && teamComponent.props.team.id) {
        return teamComponent.props.team.id;
    }
    return 0;
}
