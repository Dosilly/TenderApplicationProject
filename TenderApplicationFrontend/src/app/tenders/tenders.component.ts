import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Tender } from '../_models/tender';
import { TenderService } from '../services/tender.service';
import {animate, state, style, transition, trigger} from '@angular/animations';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css'],
  animations: [
    trigger('detailExpand', [
      state('collapsed', style({height: '0px', minHeight: '0', display: 'none'})),
      state('expanded', style({height: '*'})),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TendersComponent implements OnInit {

  constructor(private tenderService: TenderService, public dialog: MatDialog) { }

  tenders$ = new MatTableDataSource<Tender>();
  requirements$ = 'test2';
  emptyTender = new Tender();
  dialogAddTender = new Tender();
  dialogEditTender = new Tender();
  columns: string[];

  @ViewChild(MatPaginator) paginator: MatPaginator; // paginator for table
  @ViewChild(MatSort) sort: MatSort; // sorting feature by table

  applyFilter(filterValue: string) { // angular material feature to filter table by single string
      this.tenders$.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
    this.columns = this.tenderService.getColumns();
    this.tenders$.paginator = this.paginator;
    this.tenders$.sort = this.sort;
    this.getTenders();
  }
  getTenders() {
    this.tenderService.getTenders()
    .subscribe(tenders => {
      this.tenders$.data = tenders as Tender[];
      console.log(this.tenders$);
    });
  }

}
