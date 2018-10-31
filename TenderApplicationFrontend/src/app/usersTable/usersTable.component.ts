import { Component, Inject, ViewChild } from '@angular/core';
import { UsersTableService } from '../services/users-table.service';
import { from, Observable } from 'rxjs';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig, MatTab, MatSort } from '@angular/material';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';
import { MatPaginator, MatTableDataSource } from '@angular/material';

export class User {
    userId: number;
    username: string;
    userPass: string;
    name: string;
    fName: string;
    lName: string;
    role: string;
}

interface DataSource<T> {
    connect(): Observable<T[]>;
}

@Component({
    selector: 'app-userstable',
    templateUrl: './usersTable.component.html',
    styleUrls: ['./usersTable.component.css']
})


export class UsersTableComponent {

    constructor(private usersTableService: UsersTableService, public dialog: MatDialog) { }

    users$ = new MatTableDataSource<User>();
    emptyUser = new User();
    dialogAddUser = new User();
    dialogEditUser = new User();
    columns: string[];

    @ViewChild(MatPaginator) paginator: MatPaginator; // paginator for table
    @ViewChild(MatSort) sort: MatSort; // sorting feature by table

    applyFilter(filterValue: string) { // angular material feature to filter table by single string
        this.users$.filter = filterValue.trim().toLowerCase();
    }

    // tslint:disable-next-line:use-life-cycle-interface
    ngOnInit() {
        this.columns = this.usersTableService.getColumns();
        this.users$.paginator = this.paginator;
        this.users$.sort = this.sort;
        this.getUsers();
    }

    getUsers() {
        this.usersTableService.getUsers()
            .subscribe(users => {
                this.users$.data = users as User[]; // observable to array of users
            });
    }

    deleteUser(user: User) {
        if (confirm('Are you sure to delete this user?')) {
            this.usersTableService.deleteUser(user).subscribe(result => {
                console.log(result);
                this.getUsers(); // Updating table
            });
        }
    }

    addUser() {

        this.dialogAddUser = JSON.parse(JSON.stringify(this.emptyUser));

        const dialogRef = this.dialog.open(DialogOverviewComponent, {
            width: '500px',
            disableClose: true,
            data: { userData: this.dialogAddUser, header: 'Add user' }
        });

        dialogRef.afterClosed().subscribe(result => {
            if (result !== 'return') {
                this.usersTableService.addUser(result).subscribe(post => {
                    console.log(post);
                    this.getUsers(); // Updating table
                });
            }
        });
    }

    editUser(user: User) {
        this.dialogEditUser = JSON.parse(JSON.stringify(user));

        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = { userData: this.dialogEditUser, header: 'Edit user' };
        dialogConfig.width = '500px';
        dialogConfig.disableClose = true;

        const dialogRef = this.dialog.open(DialogOverviewComponent, dialogConfig);

        dialogRef.afterClosed().subscribe(result => {
            if (result !== 'return') {
                this.usersTableService.editUser(result).subscribe(result2 => {
                    console.log(result2);
                    this.getUsers(); // Updating table
                });
            }
        });
    }
}

@Component({ // Component for popups showed after button click
    selector: 'app-dialog-overview',
    templateUrl: 'dialogView.component.html',
})
export class DialogOverviewComponent {

    constructor(
        public dialogRef: MatDialogRef<DialogOverviewComponent>,
        @Inject(MAT_DIALOG_DATA) public data: any) { } // inject data to dialog

    close() {
        this.dialogRef.close('return');
    }

}
