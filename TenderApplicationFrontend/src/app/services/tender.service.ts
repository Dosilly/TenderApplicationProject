import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Tender } from '../_models/tender';
import { Observable } from 'rxjs';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type': 'application/json'
  })
};

@Injectable({
  providedIn: 'root'
})
export class TenderService {

  constructor(private http: HttpClient) { }

  tenderUrl = 'http://localhost:5000/api/tender';

  getTenders(): Observable<Tender[]> {
    return this.http.get<Tender[]>(this.tenderUrl, httpOptions);
  }

  addTender(tender: Tender): Observable<Tender> {
    return this.http.post<Tender>(this.tenderUrl, tender, httpOptions); // POST api/tender
  }

  editTender(tender: Tender): Observable<Tender> {
    const url = `${this.tenderUrl}/${tender.tenderId}`;
    return this.http.post<Tender>(url, tender, httpOptions);
  }

  deleteTender(tender: Tender): any {
    const url = `${this.tenderUrl}/${tender.tenderId}`;
    return this.http.delete<Tender>(url, httpOptions);
  }

  getColumns(): string[] {
    return ['tenderId', 'tenderName', 'employee', 'totalWh', 'state', 'actions'];
  }

}
