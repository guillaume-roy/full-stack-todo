import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TodoItem } from '../models/todo-item.model';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { map } from 'rxjs/operators';
import { plainToClass } from 'class-transformer';

@Injectable({
  providedIn: 'root'
})
export class TodoService {
  private controllerUrl = 'todo';

  constructor(private http: HttpClient) { }

  public getAll(): Observable<TodoItem[]> {
    return this.http.get(`${environment.apiBaseUrl}/${this.controllerUrl}`)
      .pipe(
        map((d: any[]) => plainToClass(TodoItem, d))
      );
  }

  public add(body: string): Observable<TodoItem> {
    return this.http.post(
      `${environment.apiBaseUrl}/${this.controllerUrl}`,
      {
        body
      }).pipe(
        map(d => plainToClass(TodoItem, d))
      );
  }

  public delete(id: string) {
    return this.http.delete(`${environment.apiBaseUrl}/${this.controllerUrl}/${id}`);
  }

  public check(id: string) {
    return this.http.put(
      `${environment.apiBaseUrl}/${this.controllerUrl}`,
      {
        id
      });
  }
}
