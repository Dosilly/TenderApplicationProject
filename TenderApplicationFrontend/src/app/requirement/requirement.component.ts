import { Component, OnInit, ViewChild } from '@angular/core';
import { RequirementService } from '../services/requirement.service';
import { Requirement } from '../_models/requirement';
import { MatPaginator, MatSort, MatTableDataSource } from '@angular/material';
import { Workhour } from '../_models/workhour';

@Component({
  selector: 'app-requirement',
  templateUrl: './requirement.component.html',
  styleUrls: ['./requirement.component.css']
})
export class RequirementComponent implements OnInit {

  constructor(private requirementService: RequirementService) { }

  // Data sources
  requirements$ = new MatTableDataSource<Requirement>();
  workhours$ = new Array<Workhour>();
  // Req objects
  emptyRequirement = new Requirement;
  dialogAddMeasureWH = new Workhour();
  dialogEditMeasureWH = new Workhour();

  reqColumns = ['reqId', 'name', 'description', 'explanation', 'actions'];

  @ViewChild(MatPaginator) paginator: MatPaginator; // paginator for table
  @ViewChild(MatSort) sort: MatSort; // sorting feature by table

  applyFilter(filterValue: string) { // angular material feature to filter table by single string
    this.requirements$.filter = filterValue.trim().toLowerCase();
  }

  ngOnInit() {
    this.requirements$.paginator = this.paginator;
    this.requirements$.sort = this.sort;
    this.getRequirements();
  }

  getRequirements() {
    this.requirementService.getRequirements()
      .subscribe(req => {
        this.requirements$.data = req as Requirement[];
      });
  }

}
