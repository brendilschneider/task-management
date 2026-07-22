using TaskManagement.Api.DTOs;

namespace TaskManagement.Api.Services
{
    public interface ITaskService
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto?> GetByIdAsync(int id);
        Task<TaskDto> CreateAsync(CreateTaskDto createTaskDto);
        Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteAsync(int id);
    }
}