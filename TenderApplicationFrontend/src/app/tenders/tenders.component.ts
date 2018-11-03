import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatTableDataSource, MatPaginator, MatSort } from '@angular/material';
import { Tender } from '../_models/tender';
import { TenderService } from '../services/tender.service';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css']
})
export class TendersComponent implements OnInit {

  constructor(private tenderService: TenderService, public dialog: MatDialog) { }

  tenders$ = new MatTableDataSource<Tender>();
  emptyTender = new Tender();
  dialogAddTender = new Tender();
  dialogEditTender = new Tender();

  @ViewChild(MatPaginator) paginator: MatPaginator; // paginator for table
  @ViewChild(MatSort) sort: MatSort; // sorting feature by table

  applyFilter(filterValue: string) { // angular material feature to filter table by single string
      this.tenders$.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
    this.tenders$.paginator = this.paginator;
    this.tenders$.sort = this.sort;
    this.getTenders();
  }
  getTenders() {
    this.tenderService.getTenders()
    .subscribe(tenders => {
      this.tenders$.data = tenders as Tender[];
      console.log(tenders);
    });
  }

}
