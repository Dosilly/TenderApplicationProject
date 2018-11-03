import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { UsersTableComponent } from './usersTable/usersTable.component';
import { DialogOverviewComponent } from './usersTable/usersTable.component';

import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { MaterialModule } from './material-module';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './appRoutes';
import { TendersComponent } from './tenders/tenders.component';



@NgModule({
  declarations: [
    AppComponent,
    UsersTableComponent,
    DialogOverviewComponent,
    LoginComponent,
    TendersComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    RouterModule.forRoot(
      appRoutes
    )
  ],
  providers: [],
  bootstrap: [AppComponent],
  entryComponents: [UsersTableComponent, DialogOverviewComponent],
})
export class AppModule { }
