import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { TodoService } from './todo.service';
import { environment } from '../../environments/environment';
import { TodoItem } from '../models/todo-item.model';
import { plainToClass } from 'class-transformer';

describe('TodoService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientTestingModule],
    });
  });

  it('should be created', () => {
    const service: TodoService = TestBed.inject(TodoService);
    expect(service).toBeTruthy();
  });

  it('should return getAll empty', () => {
    const service: TodoService = TestBed.inject(TodoService);
    const httpMock: HttpTestingController = TestBed.inject(HttpTestingController);

    service.getAll().subscribe(data => {
      expect(data).toEqual([]);
    });
    httpMock.expectOne({
      method: 'GET',
      url: `${environment.apiBaseUrl}/todo`
    }).flush([]);
  });

  it('should return getAll with values', () => {
    const service: TodoService = TestBed.inject(TodoService);
    const httpMock: HttpTestingController = TestBed.inject(HttpTestingController);
    const fakeData: TodoItem[] = [
      {
        id: '1',
        body: 'Todo 1',
        checked: true,
        creationDate: new Date(),
      },
      {
        id: '2',
        body: 'Todo 2',
        checked: false,
        creationDate: new Date(),
      }
    ];

    service.getAll().subscribe(data => {
      expect(data).toEqual(plainToClass(TodoItem, fakeData));
    });
    httpMock.expectOne({
      method: 'GET',
      url: `${environment.apiBaseUrl}/todo`
    }).flush(fakeData);
  });

  it('should add a todo', () => {
    const service: TodoService = TestBed.inject(TodoService);
    const httpMock: HttpTestingController = TestBed.inject(HttpTestingController);
    const fakeData: TodoItem = {
      id: '1',
      body: 'Todo 1',
      checked: true,
      creationDate: new Date(),
    };

    service.add('Todo 1').subscribe(data => {
      expect(data).toEqual(plainToClass(TodoItem, fakeData));
    });
    httpMock.expectOne({
      method: 'POST',
      url: `${environment.apiBaseUrl}/todo`
    }).flush(fakeData);
  });
});
