import {
    create as createFanClub,
    fetch as getFanClubs,
} from "Clients/fanClubClient";
import uploadAvatar from "Clients/avatarClient";

export async function create(fanClub) {
    let avatarJson;

    if (fanClub.avatar && fanClub.avatar[0]) {
        avatarJson = await uploadAvatar(fanClub.avatar[0]);
    }

    await createFanClub(fanClub, avatarJson && avatarJson.avatarId);
}

export async function fetch() {
    return getFanClubs();
}
