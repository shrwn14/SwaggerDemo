import { Component, OnInit } from '@angular/core';
import { TodoService, ITodo } from './../services/nswag-generated-api';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  todos: ITodo[] = [];
  description: string = '';

  constructor(private todoSvc: TodoService) { }

  ngOnInit() {
    this.loadTodo();
  }

  loadTodo(): void {
    this.todoSvc.get().subscribe(res => {
      this.todos = res;
    }, err => alert('error'));
  }

  addTodo() {
    this.todoSvc.post(this.description).subscribe(res => {
      this.loadTodo();
      setTimeout(() => { this.description = '' }, 200);
    }, err => alert('error'));
  }
}
