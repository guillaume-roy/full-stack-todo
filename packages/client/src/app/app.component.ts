import { Component, OnInit } from '@angular/core';
import { TodoService } from './services/todo.service';
import { TodoItem } from './models/todo-item.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  public todoItems: TodoItem[] = [];

  constructor(private todoService: TodoService) {

  }

  ngOnInit() {
    this.refresh();
  }

  refresh() {
    this.todoService.getAll()
      .subscribe(data => {
        this.todoItems = data;
      });
  }

  addItem(body: string) {
    this.todoService.add(body).subscribe(() => {
      this.refresh();
    });
  }

  checkItem(item: TodoItem) {
    this.todoService.check(item.id).subscribe(() => {
      this.refresh();
    });
  }

  deleteItem(item: TodoItem) {
    this.todoService.delete(item.id).subscribe(() => {
      this.refresh();
    });
  }
}
