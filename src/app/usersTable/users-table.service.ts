import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from './usersTable.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersTableService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Array<User>> {
   return this.http.get<Array<User>>('https://jsonplaceholder.typicode.com/users');
  }

  getUsersByUsername(username: string): Observable<Array<User>> {
    const parm = new HttpParams().set('username', username);
    return this.http.get<Array<User>>('https://jsonplaceholder.typicode.com/users?username=', {params: parm});
  }

  getColumns(): string[] {
    return ['id', 'username', 'name'];
  }
}
