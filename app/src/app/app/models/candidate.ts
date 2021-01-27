export class Candidate{

    candidateId: number;
    name: string;
    skillTags: string;
    skillTagList : Skill[];
    totalMatch: number;
}

export class Skill {
    name: string;
    isMatched: boolean;
}