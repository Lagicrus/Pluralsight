import React from 'react';
import CourseForm from "./CourseForm";
import renderer from 'react-test-renderer';
import {authors, courses} from '../../../tools/mockData';

it("sets submit button 'Saving...' when saving is true", () => {
    const tree = renderer.create(
        <CourseForm
            course={courses[0]}
            authors={authors}
            onSave={jest.fn()}
            onChange={jest.fn()}
            saving
        />
    ).toJSON();
    expect(tree).toMatchSnapshot();
});

it("sets submit button 'Save' when saving is false", () => {
    const tree = renderer.create(
        <CourseForm
            course={courses[0]}
            authors={authors}
            onSave={jest.fn()}
            onChange={jest.fn()}
            saving={false}
        />
    ).toJSON();
    expect(tree).toMatchSnapshot();
});