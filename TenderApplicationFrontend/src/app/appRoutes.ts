import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UsersTableComponent } from './usersTable/usersTable.component';
import { TendersComponent } from './tenders/tenders.component';
import { RequirementComponent } from './requirement/requirement.component';
import { GroupComponent } from './group/group.component';


export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'users', component: UsersTableComponent},
    { path: 'tenders', component: TendersComponent},
    { path: 'requirements', component: RequirementComponent},
    { path: 'groups', component: GroupComponent},
    { path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
];
