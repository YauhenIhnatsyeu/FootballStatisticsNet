export function retrieveNameAndValueFromEvent(e) {
    if (e && e.target && e.target.name && e.target.value) {
        return {
            name: e.target.name,
            value: e.target.value,
        };
    }

    return {
        name: "",
        value: "",
    };
}

export function retrieveNameAndValueFromFileEvent(e) {
    if (e && e.target && e.target.name && e.target.files) {
        return {
            name: e.target.name,
            value: e.target.files,
        };
    }

    return {
        name: "",
        value: "",
    };
}

export function retrieveNameAndValueFromTeamChooser(teamComponent) {
    if (teamComponent && teamComponent.props && teamComponent.props.team && teamComponent.props.team.id) {
        return {
            name: "teamId",
            value: teamComponent.props.team.id,
        };
    }

    return {
        name: "teamId",
        value: 0,
    };
}
