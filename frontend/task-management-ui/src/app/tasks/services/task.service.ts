import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { TaskItem, CreateTaskDto, UpdateTaskDto } from '../models/task.model';

@Injectable({
  providedIn: 'root'
})
export class TaskService {
  private http = inject(HttpClient);
  
  private apiUrl = 'https://localhost:5171/api/tasks'; 

  getTasks(): Observable<TaskItem[]> {
    return this.http.get<TaskItem[]>(this.apiUrl);
  }

  createTask(dto: CreateTaskDto): Observable<TaskItem> {
    return this.http.post<TaskItem>(this.apiUrl, dto);
  }

  updateTask(id: number, dto: UpdateTaskDto): Observable<TaskItem> {
    return this.http.put<TaskItem>(`${this.apiUrl}/${id}`, dto);
  }

  deleteTask(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${id}`);
  }
}