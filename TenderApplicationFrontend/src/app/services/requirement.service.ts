import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Requirement } from '../_models/requirement';
import { Observable } from 'rxjs';
import { Tender } from '../_models/tender';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};
@Injectable({
  providedIn: 'root'
})
export class RequirementService {

  constructor(private http: HttpClient) { }

  requirementUrl = 'http://localhost:3708/api/requirement';

  getRequirements(): Observable<Requirement[]> {
    return this.http.get<Requirement[]>(this.requirementUrl);
  }

  getRequirementsByTenderID(tender: Tender): Observable<Requirement[]> {
    const url = `${this.requirementUrl}/${tender.tenderId}`;
    return this.http.get<Requirement[]>(url);
  }
}
