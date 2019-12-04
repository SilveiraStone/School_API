﻿using Dapper;
using School.Core.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace School.Core.Validators.IdValidator
{
    public class IdExistValidator : IIdExistValidator
    {
        private readonly string _connectionString;

        public IdExistValidator(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public bool ValidateIdExist(long id)
        {
            string sql = @"
                SELECT
                    1
                FROM
                    dbo.Teacher
                WHERE
                    TeacherId = @Id";

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int64);

            using (SqlConnection sqlConnection = new SqlConnection(this._connectionString))
            {
                sqlConnection.Open();

                return sqlConnection.QueryFirstOrDefault<bool>(sql, parameters);
            }
        }
    }
}
