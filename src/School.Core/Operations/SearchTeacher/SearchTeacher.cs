﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using School.Core.Mapping;
using School.Core.Models;
using School.Core.Repositories;
using School.Core.Validators;
using School.Core.Validators.DataBaseValidator;
using School.Core.Validators.SearchTeacher;
using StoneCo.Buy4.School.DataContracts.SearchTeacher;
using StoneCo.Buy4.School.DataContracts;

namespace School.Core.Operations.SearchTeacher
{
    public class SearchTeacher : ISearchTeacher
    {
        private readonly ITeacherRepository _teacherRepository;
        private readonly ISchoolMappingResolver _mappingResolver;
        private readonly ISearchTeacherValidator _validator;

        public SearchTeacher(ITeacherRepository teacherRepository, ISchoolMappingResolver mappingResolver, ISearchTeacherValidator validator)
        {
            this._teacherRepository = teacherRepository;
            this._mappingResolver = mappingResolver;
            this._validator = validator;
        }

        public SearchTeacherResponse ProcessOperation(SearchTeacherRequest request)
        {
            SearchTeacherResponse response = this._validator.ValidateParameters(request);

            if (response.Success == false)
            {
                return response;
            }

            IEnumerable<Teacher> teachers = this._teacherRepository.Search(request);

            response.Data = this._mappingResolver.BuildFrom(teachers);

            response.Success = true;

            return response;
        }
    }
}
