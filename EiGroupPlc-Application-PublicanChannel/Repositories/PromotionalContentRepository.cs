using EiGroupPlc.Application.PublicanChannel.Interfaces.Repositories;
using EiGroupPlc.Application.PublicanChannel.PropertyBags;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace EiGroupPlc.Application.PublicanChannel.Repositories
{
    public class PromotionalContentRepository : IPromotionalContentRepository
    {
        private string _connectionString;

        public PromotionalContentRepository()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["ApplicationConnectionString"].ConnectionString;
        }

        public PromotionalContentRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public PromotionalContent Add(PromotionalContent entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PromotionalContent entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<PromotionalContent> GetAll()
        {
            throw new NotImplementedException();
        }

        public PromotionalContent GetByGuid(Guid id)
        {
            throw new NotImplementedException();
        }

        public PromotionalContent GetById(object id)
        {
            throw new NotImplementedException();
        }

        public List<PromotionalContent> GetPromotionalContentByPageId(string pageId)
        {
            var promotionalContent = new List<PromotionalContent>();
            var sql = "SELECT p.[Guid], p.ImageUrl, p.PageId FROM PromotionalContent p WHERE p.PageId = @PageId";

            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.Add(new SqlParameter("@PageId", pageId));
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        promotionalContent.Add(
                            new PromotionalContent() {
                                Guid = (Guid)reader["Guid"],
                                ImageUrl = reader["ImageUrl"].ToString(),
                                PageId = reader["PageId"].ToString() });
                    }
                    return promotionalContent;
                }
            }
        }

        public PromotionalContent Update(PromotionalContent entity)
        {
            throw new NotImplementedException();
        }
    }
}
