import {Component, Inject} from '@angular/core';
import { UsersTableService } from './users-table.service';
import { from, Observable } from 'rxjs';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';

export interface User {
    id?: number;
    name?: string;
    username?: string;
}


@Component({
    selector: 'app-userstable',
    templateUrl: './usersTable.component.html',
    styleUrls: ['./usersTable.component.css']
})

export class UsersTableComponent {

    constructor(private usersTableService: UsersTableService, public dialog: MatDialog) {}

    users$: Observable<Array<User>>;
    selectedUser: User;
    searchedUsername = '';
    searchedFirstName = '';
    searchedLastName = '';
    columns: string[];

    // tslint:disable-next-line:use-life-cycle-interface
    ngOnInit() {
        this.columns = this.usersTableService.getColumns();
        this.users$ = this.usersTableService.getUsers();
    }

    getUsers() {
       this.users$ = this.usersTableService.getUsers();
    }

    getUsersByUsername() {
        this.users$ = this.usersTableService.getUsersByUsername(this.searchedUsername, this.searchedFirstName);
    }

    onSelect(user: User): void {
        this.selectedUser = user;
        console.log(this.selectedUser.id);
      }

    deleteUser(user: User) {
        console.log('delete user with id: ' + user.id);
    }

    editUser(user: User) {
        console.log('edit user with id: ' + user.id);

        const dialogRef = this.dialog.open(DialogOverviewComponent, {
            width: '500px',
            data: {user: user}
          });

          dialogRef.afterClosed().subscribe(result => {
            console.log('The dialog was closed');
            this.selectedUser = result;
          });
    }
}

@Component({
    selector: 'app-dialog-overview',
    templateUrl: 'dialogView.component.html',
  })
  export class DialogOverviewComponent {

    constructor(
      public dialogRef: MatDialogRef<DialogOverviewComponent>,
      @Inject(MAT_DIALOG_DATA) public data: User) {}

    onNoClick(): void {
      this.dialogRef.close();
    }

  }
