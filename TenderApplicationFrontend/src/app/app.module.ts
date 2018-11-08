import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { UsersTableComponent } from './usersTable/usersTable.component';
import { DialogOverviewComponent } from './usersTable/usersTable.component';
import { TenderDialogComponent } from './tenders/tenders.component';
import { WorkhourDialogComponent } from './requirement/requirement.component';

import { FormsModule } from '@angular/forms'; // <-- NgModel lives here
import { HttpClientModule } from '@angular/common/http';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { MaterialModule } from './material-module';
import { LoginComponent } from './login/login.component';
import { RouterModule } from '@angular/router';
import { appRoutes } from './appRoutes';
import { TendersComponent } from './tenders/tenders.component';
import { RequirementComponent } from './requirement/requirement.component';



@NgModule({
  declarations: [
    AppComponent,
    UsersTableComponent,
    DialogOverviewComponent,
    TenderDialogComponent,
    LoginComponent,
    TendersComponent,
    RequirementComponent,
    WorkhourDialogComponent

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
  entryComponents: [UsersTableComponent, WorkhourDialogComponent, DialogOverviewComponent, TenderDialogComponent],
})
export class AppModule { }
