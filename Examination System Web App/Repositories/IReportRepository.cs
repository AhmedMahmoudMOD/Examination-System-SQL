﻿using Examination_System_Web_App.View_Models;

namespace Examination_System_Web_App.Repositories
{
    public interface IReportRepository
    {
        IQueryable<TopicsReportVM> GetTopicsReport(int crsId);
    }
}