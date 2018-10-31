import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders, HttpErrorResponse } from '@angular/common/http';
import { User } from '../_models/user';
import { Observable } from 'rxjs';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class UsersTableService {

  constructor(private http: HttpClient) { }

  userUrl = 'http://localhost:3708/api/user';

  getUsers(): Observable<User[]> {
    return this.http.get<User[]>(this.userUrl); // GET api/user
  }

  addUser(user: User): Observable<User> {
    return this.http.post<User>(this.userUrl, user, httpOptions); // POST api/user
  }

  deleteUser(user: User): Observable<User> {
    const url = `${this.userUrl}/${user.userId}`; // DELETE api/user/5
    return this.http.delete<User>(url, httpOptions);
  }

  editUser(user: User) {
    const url = `${this.userUrl}/${user.userId}`;
    return this.http.post<User>(url, user, httpOptions); // POST api/user/5
  }

  getColumns(): string[] {
    return ['userId', 'username', 'fName', 'lName', 'role', 'actions'];
  }

}
