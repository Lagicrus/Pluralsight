import {LOAD_AUTHORS_SUCCESS} from "./actionTypes";
import {getAuthors} from "../../api/authorApi";

export function loadAuthorSuccess(authors) {
    return {
        type: LOAD_AUTHORS_SUCCESS,
        authors
    }
}

export function loadAuthors() {
    return function (dispatch) {
        return getAuthors().then(courses => {
            dispatch(loadAuthorSuccess(courses));
        }).catch(error => {
            throw(error);
        });
    }
}