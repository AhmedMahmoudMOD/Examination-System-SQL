﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Examination_System_Web_App.Models;

public partial class Dept_inst_course
{
    public int dept_no { get; set; }

    public int inst_id { get; set; }

    public int crs_id { get; set; }

    public virtual Course crs { get; set; }

    public virtual Department dept_noNavigation { get; set; }

    public virtual Instructor inst { get; set; }
}