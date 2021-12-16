import {apiCallError, beginApiCall} from "./apiStatusActions";
import {
    CREATE_COURSE_SUCCESS,
    DELETE_COURSE_OPTIMISTIC,
    LOAD_COURSES_SUCCESS,
    UPDATE_COURSE_SUCCESS
} from "./actionTypes";
import {
    deleteCourse as courseApiDeleteCourse,
    getCourses,
    saveCourse as courseApiSaveCourse
} from "../../api/courseApi";

export function loadCourseSuccess(courses) {
    return {
        type: LOAD_COURSES_SUCCESS,
        courses
    };
}

export function createCourseSuccess(course) {
    return {
        type: CREATE_COURSE_SUCCESS,
        course
    };
}

export function updateCourseSuccess(course) {
    return {
        type: UPDATE_COURSE_SUCCESS,
        course
    };
}

export function deleteCourseOptimistic(course) {
    return {
        type: DELETE_COURSE_OPTIMISTIC,
        course
    };
}

export function loadCourses() {
    return function (dispatch) {
        dispatch(beginApiCall());
        return getCourses()
            .then(courses => {
                dispatch(loadCourseSuccess(courses));
            })
            .catch(error => {
                dispatch(apiCallError(error));
                throw error;
            });
    };
}

export function saveCourse(course) {
    return function (dispatch) {
        dispatch(beginApiCall());
        return courseApiSaveCourse(course)
            .then(savedCourse => {
                course.id
                    ? dispatch(updateCourseSuccess(savedCourse))
                    : dispatch(createCourseSuccess(savedCourse));
            })
            .catch(error => {
                dispatch(apiCallError(error));
                throw error;
            });
    };
}

export function deleteCourse(course) {
    return function (dispatch) {
        // Doing optimistic delete, so not dispatching begin/end api call
        // actions, or apiCallError action since we're not showing the loading status for this.
        dispatch(deleteCourseOptimistic(course));
        return courseApiDeleteCourse(course.id);
    };
}
