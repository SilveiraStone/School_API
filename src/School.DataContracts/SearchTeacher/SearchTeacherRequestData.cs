﻿using System;
using System.Collections.Generic;
using System.Text;

namespace StoneCo.Buy4.School.DataContracts.SearchTeacher
{
    public class SearchTeacherRequestData
    {
        public string NameInitial { get; set; }

        public List<char?> Gender { get; set; }

        public List<char?> LevelId { get; set; }

        public decimal? MinSalary { get; set; }

        public decimal? MaxSalary { get; set; }

        public DateTime? MinAdmitionDate { get; set; }

        public DateTime? MaxAdmitionDate { get; set; }

        //public long PageSize { get; set; }

        //public long PageNumber { get; set; }
    }
}
