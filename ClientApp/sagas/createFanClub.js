import { call } from "redux-saga/effects";

import { create } from "Services/fanClubService";

export default function* createFanClub(action) {
    try {
        const fanClub = action.payload;
        const result = yield call(create, fanClub);
    } catch (error) {
        console.log(error);
    }
}
