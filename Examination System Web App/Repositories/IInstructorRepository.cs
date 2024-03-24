﻿using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IInstructorRepository
    {
        public Instructor GetByIDWithDepartments(int id);

        public List<Course> GetCourses(int insId, int deptNo);

        List<Department> GetDepartments(int insId);

        Instructor GetInstructorLogin(string email, string pass);
    }
}
