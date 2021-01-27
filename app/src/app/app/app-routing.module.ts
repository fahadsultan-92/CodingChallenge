import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { JobListComponent } from './Job/job-list/job-list.component';
import { JobDetailComponent } from './Job/job-detail/job-detail.component';
import { JobCandidatesComponent } from './Job/job-candidate/job-candidate.component';
import { JobCandidateResolver } from './Job/job-candidate/job-candidate.resolver';

const routes: Routes = [
  
  {path: '', component: JobListComponent},
  {path: 'job', component: JobListComponent},
  {path: 'job/:id', component: JobCandidatesComponent, resolve : {job: JobCandidateResolver}}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
