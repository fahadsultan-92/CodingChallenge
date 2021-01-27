import { Component, Input, OnInit } from "@angular/core";
import { Candidate, Skill } from "../models/candidate";

@Component({
    selector: 'app-candidate-detail',
    templateUrl: './candidate-detail.component.html',
    styleUrls: ['./candidate-detail.component.scss']

})

export class CandidateDetailComponent implements OnInit {

    @Input() candidate: Candidate;
    @Input() skills: Skill[];

    ngOnInit(): void {
        //Called after the constructor, initializing input properties, and the first call to ngOnChanges.
        //Add 'implements OnInit' to the class.

        this.skills.forEach(s => {
            this.candidate.skillTagList.filter(x => x.name === s.name).forEach(x => {
                x.isMatched = true;
            })
        });

    }

}