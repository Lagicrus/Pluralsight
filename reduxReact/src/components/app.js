import React from "react";
import {Route, Switch} from "react-router-dom";
import HomePage from "./home/homePage";
import AboutPage from "./about/aboutPage";
import Header from "./common/header";
import PageNotFound from "./pageNotFound";
import CoursesPage from "./courses/coursesPage";
import ManageCoursePage from "./courses/manageCoursePage";
import {ToastContainer} from "react-toastify";
import "react-toastify/dist/ReactToastify.css";

function App() {
    return (
        <div className="container-fluid">
            <Header/>
            <Switch>
                <Route exact path="/">
                    <HomePage/>
                </Route>
                <Route path="/about">
                    <AboutPage/>
                </Route>
                <Route path="/courses">
                    <CoursesPage/>
                </Route>
                <Route path="/course/:slug">
                    <ManageCoursePage/>
                </Route>
                <Route path="/course">
                    <ManageCoursePage/>
                </Route>
                <Route>
                    <PageNotFound/>
                </Route>
            </Switch>
            <ToastContainer autoClose={3000} hideProgressBar/>
        </div>
    );
}

export default App;
