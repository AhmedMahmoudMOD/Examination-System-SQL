﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Examination_System_Web_App.Models;

public partial class Exam
{
    public int exam_id { get; set; }

    public string exam_name { get; set; }

    public DateTime? exam_date { get; set; }

    public int? exam_duration { get; set; }

    public int? crs_id { get; set; }

    public int? dept_no { get; set; }

    public virtual ICollection<Student_answer> Student_answers { get; set; } = new List<Student_answer>();

    public virtual Course crs { get; set; }

    public virtual Department dept_noNavigation { get; set; }
}