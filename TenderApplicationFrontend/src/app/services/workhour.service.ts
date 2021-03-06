import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Workhour } from '../_models/workhour';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class WorkhourService {

  constructor(private http: HttpClient) { }

  workhourUrl = 'http://localhost:5000/api/workhour';

  getWorkhoursByRequirementID(reqId: number): Observable<Workhour[]> {
    const url = `${this.workhourUrl}/` + reqId;
    return this.http.get<Workhour[]>(url);
  }

  assignWorkhours(result: Workhour): any {
    return this.http.post<Workhour>(this.workhourUrl, result, httpOptions);
  }

  editWorkhour(workhour: Workhour) {
    const url = `${this.workhourUrl}/` + workhour.whId;
    return this.http.post<Workhour>(url, workhour, httpOptions);
  }

  deleteWorkhour(workhour: Workhour) {
    const url = `${this.workhourUrl}/` + workhour.whId;
    return this.http.delete(url, httpOptions);
  }
}

