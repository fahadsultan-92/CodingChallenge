import { Component, OnInit } from "@angular/core";
import { Job } from "../../models/job";
import { JobService } from "../../Service/job.service";

@Component({

    selector: 'app-job-list',
    templateUrl: './job-list.component.html',
    styleUrls: ['./job-list.component.scss']
})

export class JobListComponent implements OnInit {
    jobs: Job[] = [];

    constructor(private srv: JobService) { }

    ngOnInit() {

        this.srv.getJobList().
            subscribe(result => {
                this.jobs = result;
            });
    }

}