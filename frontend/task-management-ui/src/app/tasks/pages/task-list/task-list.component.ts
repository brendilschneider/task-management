import { Component, OnInit, inject, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TaskService } from '../../services/task.service';
import { TaskItem, CreateTaskDto } from '../../models/task.model';
import { TaskFormComponent } from '../../components/task-form/task-form.component';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, TaskFormComponent],
  templateUrl: './task-list.component.html',
  styleUrl: './task-list.component.scss'
})
export class TaskListComponent implements OnInit {
  private taskService = inject(TaskService);
  
  tasks = signal<TaskItem[]>([]);

  ngOnInit(): void {
    this.loadTasks();
  }

  loadTasks(): void {
    this.taskService.getTasks().subscribe({
      next: (data) => this.tasks.set(data),
      error: (err) => console.error('Error al cargar tareas', err)
    });
  }

  onTaskCreated(dto: CreateTaskDto): void {
    this.taskService.createTask(dto).subscribe({
      next: (newTask) => {
        this.tasks.update((current) => [...current, newTask]);
      },
      error: (err) => console.error('Error al crear tarea', err)
    });
  }

  toggleTask(task: TaskItem): void {
    const updatedDto = {
      title: task.title,
      description: task.description,
      isCompleted: !task.isCompleted
    };

    this.taskService.updateTask(task.id, updatedDto).subscribe({
      next: (updatedTask) => {
        this.tasks.update((current) =>
          current.map((t) => (t.id === updatedTask.id ? updatedTask : t))
        );
      },
      error: (err) => console.error('Error al actualizar tarea', err)
    });
  }

  deleteTask(id: number): void {
    this.taskService.deleteTask(id).subscribe({
      next: () => {
        this.tasks.update((current) => current.filter((t) => t.id !== id));
      },
      error: (err) => console.error('Error al eliminar tarea', err)
    });
  }
}