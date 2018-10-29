import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { User } from '../usersTable/usersTable.component';
import { Observable} from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type':  'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class UsersTableService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
   return this.http.get<User[]>('http://localhost:3708/api/user');
  }

  addUser(user: User): Observable<User> {
    console.log(user);
    return this.http.post<User>('http://localhost:3708/api/user', user, httpOptions);
  }

  editUser(user: User) {
    console.log(JSON.stringify( user ));
  }

  getColumns(): string[] {
    return ['userId', 'username', 'fName', 'lName', 'role', 'actions'];
  }

}
