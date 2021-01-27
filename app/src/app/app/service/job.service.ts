import {HttpClient, HttpParams, HttpHeaders} from '@angular/common/http'
import { Injectable } from '@angular/core';
import { ObservableInput, Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Job } from '../models/job';

@Injectable({
    providedIn : 'root'
})
export class JobService{
    apiAction = 'Job/';

constructor(private httpClient: HttpClient){}

private setHeaders(): HttpHeaders {
    const headersConfig: any = {
       'Access-Control-Allow-Origin': '*',
       'Content-Type': 'application/json',
       'Accept': 'application/json'
    };
    return new HttpHeaders(headersConfig);
 }

    getJobList():Observable<Job[]>{
     return this.httpClient
        .get<Job[]>(`${environment.api_url}${this.apiAction}`,{headers: this.setHeaders()});
    }

    getJobDetail(id:number){
        let httpParams: HttpParams = new HttpParams().append('id', id.toString());
        return this.httpClient.get<Job>(`${environment.api_url}${this.apiAction}`,{ headers: this.setHeaders(), params: httpParams });         
    }


}

