﻿using Examination_System_Web_App.Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IStudentCourseRepository
    {
        List<Std_course> GetByCourseID(int courseID,int DeptNo);
        public List<Std_course> GetStudentDegrees(int std_id);

    }
}
