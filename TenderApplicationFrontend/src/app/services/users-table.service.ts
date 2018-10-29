import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { User } from '../usersTable/usersTable.component';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsersTableService {

  constructor(private http: HttpClient) { }

  getUsers(): Observable<User[]> {
   return this.http.get<User[]>('http://localhost:3708/api/user');
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
