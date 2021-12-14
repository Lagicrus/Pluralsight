import React from "react";
import {Route, Switch} from "react-router-dom";
import HomePage from "./home/homePage";
import AboutPage from "./about/aboutPage";
import Header from "./common/header";
import PageNotFound from "./pageNotFound";
import CoursesPage from "./courses/coursesPage";

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
                <Route>
                    <PageNotFound/>
                </Route>
            </Switch>
        </div>
    )
}

export default App;