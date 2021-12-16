import {getAuthors} from "../../api/authorApi";
import {apiCallError, beginApiCall} from "./apiStatusActions";
import {LOAD_AUTHORS_SUCCESS} from "./actionTypes";

export function loadAuthorsSuccess(authors) {
    return {type: LOAD_AUTHORS_SUCCESS, authors};
}

export function loadAuthors() {
    return function (dispatch) {
        dispatch(beginApiCall());
        return getAuthors()
            .then(authors => {
                dispatch(loadAuthorsSuccess(authors));
            })
            .catch(error => {
                dispatch(apiCallError(error));
                throw error;
            });
    };
}
