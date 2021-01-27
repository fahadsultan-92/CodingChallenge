import { Component, Input, OnInit } from "@angular/core";
import { JobService } from "../../Service/job.service";
import { Job } from "../../models/job";
import { ActivatedRoute } from "@angular/router";

@Component({

    selector: 'app-job-detail',
    templateUrl: './job-detail.component.html',
    styleUrls: ['./job-detail.component.scss']

})

export class JobDetailComponent implements OnInit {

    @Input() job: Job;
    @Input() showCandidate: boolean;

    constructor(private srv: JobService, private route: ActivatedRoute) { }

    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.
    }

}