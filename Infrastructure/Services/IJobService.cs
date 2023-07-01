using Domain.Dtos.JobDto;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IJobService
{
    Task<Response<List<GetJobDto>>> GetJob();
    Task<Response<GetJobDto>> GetJobById(int id);
    Task<Response<AddJobDto>> AddJob(AddJobDto model);
    Task<Response<AddJobDto>> UpdateJob(AddJobDto model);
    Task<Response<string>> DeleteJob(int id);
}