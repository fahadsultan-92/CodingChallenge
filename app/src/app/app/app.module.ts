import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { JobListComponent } from './Job/job-list/job-list.component';
import { CandidateDetailComponent } from './Candidate/candidate-detail.component';
import { JobDetailComponent } from './Job/job-detail/job-detail.component';
import { JobCandidatesComponent } from './Job/job-candidate/job-candidate.component';
import { JobService } from './Service/job.service';
import { HttpClientModule } from '@angular/common/http';
import { JobCandidateResolver } from './Job/job-candidate/job-candidate.resolver';


@NgModule({
  declarations: [
    AppComponent,
    JobListComponent,
    CandidateDetailComponent,
    JobDetailComponent,
    JobCandidatesComponent
    
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [JobService, JobCandidateResolver],
  bootstrap: [AppComponent]
})
export class AppModule { }
