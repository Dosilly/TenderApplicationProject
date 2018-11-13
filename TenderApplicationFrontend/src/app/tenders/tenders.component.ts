import { Component, OnInit, ViewChild, Inject } from '@angular/core';
import { MatDialog, MatTableDataSource, MatPaginator, MatSort, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { Tender } from '../_models/tender';
import { TenderService } from '../services/tender.service';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { RequirementService } from '../services/requirement.service';
import { Requirement } from '../_models/requirement';

@Component({
  selector: 'app-tenders',
  templateUrl: './tenders.component.html',
  styleUrls: ['./tenders.component.css'],
  animations: [ // in collapsed state expandable row is now visible, on state change animation begins and expands row
    trigger('detailExpand', [
      state('collapsed', style({ height: '0px', minHeight: '0', display: 'none' })),
      state('expanded', style({ height: '*' })),
      transition('expanded <=> collapsed', animate('225ms cubic-bezier(0.4, 0.0, 0.2, 1)')),
    ]),
  ],
})
export class TendersComponent implements OnInit {

  constructor(private tenderService: TenderService, private requirementService: RequirementService, public dialog: MatDialog) { }

  // Data sources
  tenders$ = new MatTableDataSource<Tender>();
  requirements$ = new Array<Requirement>();
  // Tender objects
  emptyTender = new Tender();
  dialogEditTender = new Tender();
  dialogAddTender = new Tender();
  // Requirement objects
  emptyRequirement = new Requirement;
  dialogAddRequirement = new Requirement();
  dialogEditRequirement = new Requirement();

  loading = false;
  columns: string[];
  reqColumns = ['reqId', 'name', 'description', 'explanation', 'actions'];

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
      });
  }

  getRequirementByTenderID(tenderId: number) {
    this.loading = true;
    this.requirementService.getRequirementsByTenderID(tenderId)
      .subscribe(req => {
        this.requirements$ = req as Requirement[];
        this.loading = false;
      });
  }

  editTender(tender: Tender) {
    this.dialogEditTender = JSON.parse(JSON.stringify(tender));
    this.dialogEditTender.employeeId = 21; // TEMPORARY NEED TO GET ID FROM LOGGED USER !IMPORTANT

    const dialogRef = this.dialog.open(TenderDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { tenderData: this.dialogEditTender, header: 'Edit tender' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== 'return') {
        this.tenderService.editTender(result).subscribe(result2 => {
          console.log(result2);
          this.getTenders(); // Updating table
        });
      }
    });
  }

  editRequirement(requirement: Requirement) {
    this.dialogEditRequirement = JSON.parse(JSON.stringify(requirement));
    console.log(requirement);

      const dialogRef = this.dialog.open(TenderDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { requirementData: this.dialogEditRequirement, header: 'Edit requirement' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== 'return') {
        this.requirementService.editRequirement(result).subscribe(result2 => {
          console.log(result2);
          this.getRequirementByTenderID(requirement.tenderId); // Updating table
        });
      }
    });

  }

  addTender() {
    this.dialogAddTender = JSON.parse(JSON.stringify(this.emptyTender));
    this.dialogAddTender.employeeId = 21; // TEMPORARY

    const dialogRef = this.dialog.open(TenderDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { tenderData: this.dialogAddTender, header: 'Add tender' }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== 'return') {
        this.tenderService.addTender(result).subscribe(post => {
          console.log(post);
          this.getTenders(); // Updating table
        });
      }
    });
  }

  addRequirement(tender: Tender) {
    this.dialogAddRequirement = JSON.parse(JSON.stringify(this.emptyRequirement));
    this.dialogAddRequirement.tenderId = tender.tenderId;

    const dialogRef = this.dialog.open(TenderDialogComponent, {
      width: '500px',
      disableClose: true,
      data: { requirementData: this.dialogAddRequirement, header: 'Add requirement'}
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result !== 'return') {
        this.requirementService.addRequirement(result).subscribe(post => {
          console.log(post);
          this.getRequirementByTenderID(tender.tenderId); // Updating table
        });
      }
    });

  }

  deleteTender(tender: Tender) {
    if (confirm('Are you sure to delete this tender?')) {
      this.tenderService.deleteTender(tender).subscribe(result => {
        console.log(result);
        this.getTenders(); // Updating table
      });
    }
  }

  deleteRequirement(requirement: Requirement) {
    if (confirm('Are you sure to delete this requirement?')) {
      this.requirementService.deleteRequirement(requirement).subscribe(result => {
        console.log(result);
        this.getRequirementByTenderID(requirement.tenderId); // Updating table
      });
    }
  }

}

@Component({ // Component for popups showed after button click
  selector: 'app-tender-dialog',
  templateUrl: 'tenderDialog.component.html',
})
export class TenderDialogComponent {

  constructor(
    public dialogRef: MatDialogRef<TenderDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) { } // inject data to dialog

  close() {
    this.dialogRef.close('return');
  }

}
