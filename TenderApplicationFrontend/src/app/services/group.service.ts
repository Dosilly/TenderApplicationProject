import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Group } from '../_models/group';
import { Requirement } from '../_models/requirement';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class GroupService {

  constructor(private http: HttpClient) { }

  groupUrl = 'http://localhost:5000/api/group';
  reqGroupUrl = 'http://localhost:5000/api/reqgroup';

  getGroups(): Observable<Group[]> {
    return this.http.get<Group[]>(this.groupUrl);
  }

  createGroup(group: Group): Observable<Group> {
    return this.http.post<Group>(this.groupUrl, group, httpOptions);
  }

  getGroupsByRequirementID(reqId: number): Observable<Group[]> {
    const url = `${this.groupUrl}/` + reqId;
    return this.http.get<Group[]>(url);
  }

  removeFromGroup(groupId: number, reqId: number): Observable<Group> {
    const url = `${this.reqGroupUrl}/` + `${reqId}/` + groupId;
    return this.http.delete<Group>(url, httpOptions);
  }

  assignReqToGroup(reqList: Requirement[], groupId: number): Observable<Requirement[]> {
    const url = `${this.reqGroupUrl}/` + groupId;
    console.log(JSON.stringify(reqList[0]));
    console.log(url);

    return this.http.post<Requirement[]>(url, JSON.stringify(reqList), httpOptions);
  }
}
