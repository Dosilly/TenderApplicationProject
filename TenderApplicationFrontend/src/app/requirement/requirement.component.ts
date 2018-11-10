import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { RequirementService } from '../services/requirement.service';
import { Requirement } from '../_models/requirement';
import { MatPaginator, MatSort, MatTableDataSource, MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material';
import { Workhour } from '../_models/workhour';
import { trigger, state, transition, animate, style } from '@angular/animations';
import { WorkhourService } from '../services/workhour.service';

@Component({
  selector: 'app-requirement',
  templateUrl: './requirement.component.html',
  styleUrls: ['./requirement.component.css'],
  animations: [ // in collapsed state expandable row is now visible, on state change animation begins and expands row
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class RequirementComponent implements OnInit {

  constructor(private requirementService: RequirementService, private workhourService: WorkhourService, public dialog: MatDialog) { }

  // Data sources
  requirements$ = new MatTableDataSource<Requirement>();
  workhours$ = new Array<Workhour>();
  // Req objects
  emptyWorkhour = new Workhour();
  dialogAddMeasureWH = new Workhour();
  dialogEditMeasureWH = new Workhour();

  // temp
  employeeId = 21;

  reqColumns = ['reqId', 'name', 'description', 'explanation', 'actions'];
  whColumns = ['whId', 'employee', 'workhours', 'actions'];

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

  getWorkhoursByRequirementID(reqId: number) {
    this.workhourService.getWorkhoursByRequirementID(reqId)
      .subscribe(req => {
        this.workhours$ = req as Workhour[];
      });
  }

  assignWorkhours(requirement: Requirement) {

    this.dialogAddMeasureWH = JSON.parse(JSON.stringify(this.emptyWorkhour));
    this.dialogAddMeasureWH.reqId = requirement.reqId;
    this.dialogAddMeasureWH.employeeId = 23; // TEMPORARY

    const dialogRef = this.dialog.open(WorkhourDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { workhourData: this.dialogAddMeasureWH, header: 'Add workhours'}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== 'return') {
        this.workhourService.assignWorkhours(result).subscribe(result2 => {
          console.log(result2);
          this.getWorkhoursByRequirementID(requirement.reqId); // Updating table
        });
      }
    });
  }

}

@Component({ // Component for popups showed after button click
  selector: 'app-tender-dialog',
  templateUrl: 'workhourDialog.component.html',
})
export class WorkhourDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<WorkhourDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { } // inject data to dialog

  close() {
    this.dialogRef.close('return');
  }

}

