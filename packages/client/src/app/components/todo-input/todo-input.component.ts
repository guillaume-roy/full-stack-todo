import { Component, OnInit, Output, EventEmitter } from '@angular/core';

@Component({
  selector: 'app-todo-input',
  templateUrl: './todo-input.component.html',
  styleUrls: ['./todo-input.component.scss']
})
export class TodoInputComponent implements OnInit {
  @Output() add = new EventEmitter<string>();

  public body = '';

  constructor() { }

  ngOnInit(): void {
  }

  onAdd() {
    this.add.emit(this.body);
    this.body = '';
  }

}
