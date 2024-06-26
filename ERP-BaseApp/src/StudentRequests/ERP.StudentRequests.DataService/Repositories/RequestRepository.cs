﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ERP.StudentRequests.Core.Interfaces;
using ERP.StudentRequests.Core.Entity;
using ERP.StudentRequests.DataService.Data;

namespace ERP.StudentRequests.DataService.Repositories
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext context, ILogger logger) : base(context, logger)
        {
        }

        public async Task<IEnumerable<Request>> GetStudentRequestAsync(Guid studentId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.StudentId == studentId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetStudentRequestAsync function error", typeof(RequestRepository));
                return Enumerable.Empty<Request>();
            }


        }

        public async Task<IEnumerable<Request>> GetLecturerRequestAsync(Guid lecturerId)
        {
            try
            {
                return await _dbSet
                    .Where(s => s.LecturerId == lecturerId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetLecturerIdRequestAsync function error", typeof(RequestRepository));
                return Enumerable.Empty<Request>();
            }


        }

        public override async Task<IEnumerable<Request>> GetAll()
        {
            try
            {
                return await _dbSet.Where(x => x.Status == 1)
                    .AsNoTracking()
                    .AsSplitQuery()
                    .OrderBy(x => x.AddedDate)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} GetAll function error", typeof(RequestRepository));
                throw;

            }
        }

        public override async Task<bool> Delete(Guid id)
        {
            try
            {
                //get by id
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == id);

                if (result == null)
                    return false;

                result.Status = 0; //the way the result is deleted is by making it as 0
                result.UpdatedDate = DateTime.UtcNow;

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Delete function error", typeof(RequestRepository));
                throw;

            }
        }

        public override async Task<bool> Update(Request request)
        {
            try
            {
                //get by id
                var result = await _dbSet.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (result == null)
                    return false;

                result.UpdatedDate = DateTime.UtcNow;
                result.Topic = request.Topic;
                result.RequestType = request.RequestType;
                result.LecturerName = request.LecturerName;
                result.Message = request.Message;
                result.StudentName = request.StudentName;
                result.StudentRegNo = request.StudentRegNo;
                result.StudentBatch = request.StudentBatch;
                result.StudentDegree = request.StudentDegree;
                result.Semester = request.Semester;

                return true;

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} Update function error", typeof(RequestRepository));
                throw;

            }
        }

    }
}
