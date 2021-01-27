import { Candidate } from "./candidate";

export class Job{
    jobId : number;
    name : string;
    company : string;
    skills: string;
    skillList : string[];
    matchingCandidates : Candidate[];
}