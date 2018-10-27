import {Component, Inject} from '@angular/core';
import { UsersTableService } from '../services/users-table.service';
import { from, Observable } from 'rxjs';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig} from '@angular/material';
import { AngularWaitBarrier } from 'blocking-proxy/built/lib/angular_wait_barrier';


export class User {
    id: number;
    username: string;
    name: string;
    firstName: string;
    lastName: string;
    role: string;
}


@Component({
    selector: 'app-userstable',
    templateUrl: './usersTable.component.html',
    styleUrls: ['./usersTable.component.css']
})

export class UsersTableComponent {

    constructor(private usersTableService: UsersTableService, public dialog: MatDialog) {}

    users$: Observable<Array<User>>;
    selectedUser = new User();
    emptyUser = new User();
    dialogAddUser = new User();
    dialogEditUser = new User();

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

    addUser() {

        this.dialogAddUser = JSON.parse(JSON.stringify(this.emptyUser));

        const dialogRef = this.dialog.open(DialogOverviewComponent, {
            width: '500px',
            disableClose: true,
            data: {userData: this.dialogAddUser,  header: 'Add user'}
          });

          dialogRef.afterClosed().subscribe(result => {
              if (result !== 'return') {
                  console.log('addUser in component: ' + result.username);
                this.usersTableService.addUser(result);
              }
          });
    }

    editUser(user: User) {
        console.log('edit user with id: ' + user.id);

        this.dialogEditUser = JSON.parse(JSON.stringify(user));

        const dialogConfig = new MatDialogConfig();
        dialogConfig.data = {userData: this.dialogEditUser, header: 'Edit user'};
        dialogConfig.width = '500px';
        dialogConfig.disableClose = true;

        const dialogRef = this.dialog.open(DialogOverviewComponent, dialogConfig);

          dialogRef.afterClosed().subscribe(result => {
            if (result !== 'return') {
                this.usersTableService.editUser(result);
            }
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
      @Inject(MAT_DIALOG_DATA) public data: any) {}

      close() {
        this.dialogRef.close('return');
      }

  }
