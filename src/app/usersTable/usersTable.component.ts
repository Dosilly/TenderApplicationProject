import {Component} from '@angular/core';
import { TouchSequence } from 'selenium-webdriver';


@Component({
    selector: 'app-userstable',
    templateUrl: './usersTable.component.html'
})

export class UsersTableComponent {
    userID = 10;
    username = 'Dosilly';
    searchRequest = false;

    searchedUsername = '';
    searchedFirstName = '';

    onSearchUser() { // Search button event
        this.searchRequest = true;
    }
}
