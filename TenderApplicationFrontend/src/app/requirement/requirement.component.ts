import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { RequirementService } from '../services/requirement.service';
import { Requirement } from '../_models/requirement';
import { MatPaginator, MatSort, MatTableDataSource, MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material';
import { Workhour } from '../_models/workhour';
import { trigger, state, transition, animate, style } from '@angular/animations';
import { WorkhourService } from '../services/workhour.service';
import { AuthenticationService } from '../services/login.service';

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

  constructor(private requirementService: RequirementService,
    private workhourService: WorkhourService,
    public dialog: MatDialog,
    private authenticationService: AuthenticationService) { }

  // Data sources
  requirements$ = new MatTableDataSource<Requirement>();
  workhours$ = new Array<Workhour>();
  // Req objects
  emptyWorkhour = new Workhour();
  emptyRequirement = new Requirement();
  dialogAddMeasureWH = new Workhour();
  dialogEditMeasureWH = new Workhour();
  dialogRequirementDetail = new Requirement();

  // Id that is inserted when posting objects
  employeeId = this.authenticationService.currentUser.employeeId;

  loading = false;
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
    this.loading = true;
    this.workhourService.getWorkhoursByRequirementID(reqId)
      .subscribe(req => {
        this.workhours$ = req as Workhour[];
        this.loading = false;
      });
  }

  requirementDetails(requirement: Requirement) {
    this.dialogRequirementDetail = JSON.parse(JSON.stringify(requirement));

    this.dialog.open(WorkhourDialogComponent, {
      width: '800px',
      disableClose: true,
      data: { requirementData: this.dialogRequirementDetail, header: 'Requirement details'}
    });
  }

  assignWorkhours(requirement: Requirement) {

    this.dialogAddMeasureWH = JSON.parse(JSON.stringify(this.emptyWorkhour));
    this.dialogAddMeasureWH.reqId = requirement.reqId;
    this.dialogAddMeasureWH.employeeId = this.authenticationService.currentUser.employeeId;

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

  deleteWorkhour(workhour: Workhour) {
    if (confirm('Are you sure to delete this workhour?')) {
      this.workhourService.deleteWorkhour(workhour).subscribe(result => {
        console.log(result);
        this.getWorkhoursByRequirementID(workhour.reqId); // Updating table
      });
    }
  }

  editWorkhour(workhour: Workhour) {
    this.dialogEditMeasureWH = JSON.parse(JSON.stringify(workhour));

    const dialogRef = this.dialog.open(WorkhourDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { workhourData: this.dialogEditMeasureWH, header: 'Edit workhours'}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== 'return') {
        this.workhourService.editWorkhour(result).subscribe(result2 => {
          console.log(result2);
          this.getWorkhoursByRequirementID(workhour.reqId); // Updating table
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

