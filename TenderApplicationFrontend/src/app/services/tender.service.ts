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

  tenderUrl = 'http://localhost:3708/api/tender';

  getTenders(): Observable<Tender[]> {
    return this.http.get<Tender[]>(this.tenderUrl, httpOptions);
  }
}
