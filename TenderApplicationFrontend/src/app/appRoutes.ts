import { Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { UsersTableComponent } from './usersTable/usersTable.component';
import { TendersComponent } from './tenders/tenders.component';
import { RequirementComponent } from './requirement/requirement.component';
import { GroupComponent } from './group/group.component';
import { AuthGuard } from './guards/auth.guard';


export const appRoutes: Routes = [
    { path: 'login', component: LoginComponent },
    { path: 'users', component: UsersTableComponent, canActivate: [AuthGuard]},
    { path: 'tenders', component: TendersComponent, canActivate: [AuthGuard]},
    { path: 'requirements', component: RequirementComponent, canActivate: [AuthGuard]},
    { path: 'groups', component: GroupComponent, canActivate: [AuthGuard]},
    { path: '',
    redirectTo: '/login',
    pathMatch: 'full'
  },
];
