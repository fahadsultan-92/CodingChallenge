import { Injectable } from "@angular/core";
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from "@angular/router";
import { Job } from "../../models/job";
import { JobService } from "../../Service/job.service";

@Injectable()

export class JobCandidateResolver implements Resolve<Job>{
    constructor(private srv: JobService) { }
    resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): any {
        const jobId = +route.paramMap.get('id');
        return this.srv.getJobDetail(jobId);
    }
}