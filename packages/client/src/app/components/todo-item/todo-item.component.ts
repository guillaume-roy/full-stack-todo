import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { TodoItem } from '../../models/todo-item.model';

@Component({
  selector: 'app-todo-item',
  templateUrl: './todo-item.component.html',
  styleUrls: ['./todo-item.component.scss']
})
export class TodoItemComponent implements OnInit {
  @Input() item: TodoItem;
  @Output() check = new EventEmitter<TodoItem>();
  @Output() delete = new EventEmitter<TodoItem>();

  constructor() { }

  ngOnInit(): void {
  }

  onCheck() {
    this.check.emit(this.item);
  }

  onDelete() {
    this.delete.emit(this.item);
  }

}
