import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { Job } from "../../models/Job";

@Component({
    selector: 'app-job-candidate',
    templateUrl: './job-candidate.component.html',
    styleUrls: ['./job-candidate.component.scss']
})

export class JobCandidatesComponent implements OnInit {
    job: Job;
    constructor(private route: ActivatedRoute) { }
    ngOnInit() {
        this.job = this.route.snapshot.data.job;
    }
}