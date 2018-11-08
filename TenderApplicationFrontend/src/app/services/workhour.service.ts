import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Tender } from '../_models/tender';
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

  workhourUrl = 'http://localhost:3708/api/workhour';

  getWorkhoursByRequirementID(reqId: number): any {
    throw new Error('Method not implemented.');
  }

  assignWorkhours(result: Workhour): any {
    console.log(result);
    throw new Error('Method not implemented.');
  }
}
