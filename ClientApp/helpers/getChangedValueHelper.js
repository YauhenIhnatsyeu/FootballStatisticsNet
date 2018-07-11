export function getChangedValueFromEvent(e) {
    if (e && e.target && e.target.name && e.target.value) {
        return e.target.value;
    }
    return null;
}

export function getChangedValueFromFileEvent(e) {
    if (e && e.target && e.target.name && e.target.files) {
        return e.target.files;
    }
    return null;
}

export function getChangedValueFromTeamChooser(teamComponent) {
    if (teamComponent && teamComponent.props && teamComponent.props.team && teamComponent.props.team.id) {
        return teamComponent.props.team.id;
    }
    return null;
}
