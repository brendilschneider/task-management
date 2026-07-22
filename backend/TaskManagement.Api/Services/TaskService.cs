using Microsoft.EntityFrameworkCore;
using TaskManagement.Api.Data;
using TaskManagement.Api.DTOs;
using TaskManagement.Api.Models;

namespace TaskManagement.Api.Services
{
    public class TaskService : ITaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TaskDto>> GetAllAsync()
        {
            return await _context.Tasks
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    IsCompleted = t.IsCompleted,
                    CreatedAt = t.CreatedAt
                })
                .ToListAsync();
        }

        public async Task<TaskDto?> GetByIdAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return null;

            return new TaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                IsCompleted = task.IsCompleted,
                CreatedAt = task.CreatedAt
            };
        }

        public async Task<TaskDto> CreateAsync(CreateTaskDto createTaskDto)
        {
            var taskItem = new TaskItem
            {
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tasks.Add(taskItem);
            await _context.SaveChangesAsync();

            return new TaskDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                CreatedAt = taskItem.CreatedAt
            };
        }

        public async Task<TaskDto?> UpdateAsync(int id, UpdateTaskDto updateTaskDto)
        {
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null) return null;

            taskItem.Title = updateTaskDto.Title;
            taskItem.Description = updateTaskDto.Description;
            taskItem.IsCompleted = updateTaskDto.IsCompleted;

            await _context.SaveChangesAsync();

            return new TaskDto
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                IsCompleted = taskItem.IsCompleted,
                CreatedAt = taskItem.CreatedAt
            };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var taskItem = await _context.Tasks.FindAsync(id);
            if (taskItem == null) return false;

            _context.Tasks.Remove(taskItem);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}