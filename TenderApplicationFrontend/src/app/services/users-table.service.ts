import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../usersTable/usersTable.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersTableService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<Array<User>> {
   return this.http.get<Array<User>>('http://localhost:3708/api/user');
  }

  getUsersByUsername(username: string, name: string): Observable<Array<User>> {
    const parm = new HttpParams()
    .set('username', username)
    .set('name', name);
    return this.http.get<Array<User>>('https://jsonplaceholder.typicode.com/users', {params: parm});
  }

  addUser(user: User) {
    console.log(JSON.stringify( user ));
  }

  editUser(user: User) {
    console.log(JSON.stringify( user ));
  }

  getColumns(): string[] {
    return ['userId', 'username', 'fName', 'lName', 'role', 'actions'];
  }
}
