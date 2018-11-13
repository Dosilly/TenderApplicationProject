import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { RequirementService } from '../services/requirement.service';
import { Requirement } from '../_models/requirement';
import { MatPaginator, MatSort, MatTableDataSource, MAT_DIALOG_DATA, MatDialogRef, MatDialog } from '@angular/material';
import { trigger, state, transition, animate, style } from '@angular/animations';
import { GroupService } from '../services/group.service';
import { Group } from '../_models/group';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import { SelectionModel } from '@angular/cdk/collections';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css'],
  animations: [ // in collapsed state expandable row is now visible, on state change animation begins and expands row
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class GroupComponent implements OnInit {

  constructor(public dialog: MatDialog, private groupService: GroupService, private requirementService: RequirementService) { }

  // Data sources
  requirements$ = new MatTableDataSource<Requirement>();
  groups$ = new Array<Group>();

  // Objects
  dialogRequirementDetail = new Requirement();
  selection = new SelectionModel<Requirement>(true, []);

  reqColumns = ['select', 'reqId', 'name', 'description', 'explanation', 'actions'];
  groupColumns = ['groupId', 'name', 'employee', 'workhours', 'actions'];

  loading = false;
  employeeId = 21;

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

  getGroupsByRequirementID(reqId: number) {
    this.loading = true;
    this.groupService.getGroupsByRequirementID(reqId)
      .subscribe(req => {
        this.groups$ = req as Group[];
        this.loading = false;
      });
  }

  requirementDetails(requirement: Requirement) {
    this.dialogRequirementDetail = JSON.parse(JSON.stringify(requirement));

    this.dialog.open(GroupDialogComponent, {
      width: '800px',
      disableClose: true,
      data: { requirementData: this.dialogRequirementDetail, header: 'Requirement details'}
    });
  }

  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.requirements$.data.length;
    return numSelected === numRows;
  }

  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.requirements$.data.forEach(row => this.selection.select(row));
  }


}

@Component({ // Component for popups showed after button click
  selector: 'app-group-dialog',
  templateUrl: 'groupDialog.component.html',
})
export class GroupDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<GroupDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { } // inject data to dialog

  close() {
    this.dialogRef.close('return');
  }

}
