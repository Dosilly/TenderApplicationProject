import {Component} from '@angular/core';
import { TouchSequence } from 'selenium-webdriver';
import { UsersTableService } from './users-table.service';
import { from, Observable } from 'rxjs';

@Component({
    selector: 'app-userstable',
    templateUrl: './usersTable.component.html'
})

export class UsersTableComponent {

    constructor(private usersTableService: UsersTableService) {}

    users$: Observable<Array<User>>;
    searchedUsername = '';
    searchedFirstName = '';
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
}

export interface User {
    id?: number;
    name?: string;
    username?: string;
}
