using Domain.Dtos.JobHistoryDto;
using Domain.Wrapper;

namespace Infrastructure.Services;

public interface IJobHistoryService
{
    Task<Response<List<GetJobHistoryDto>>> GetJobHistory();
    Task<Response<GetJobHistoryDto>> GetJobHistoryById(int id);
    Task<Response<AddJobHistoryDto>> AddJobHistory(AddJobHistoryDto model);
    Task<Response<AddJobHistoryDto>> UpdateJobHistory(AddJobHistoryDto model);
    Task<Response<string>> DeleteJobHistory(int id);
}