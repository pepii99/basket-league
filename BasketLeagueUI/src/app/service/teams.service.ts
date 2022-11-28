import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class TeamsService {
  constructor(private http: HttpClient) {}

  baseUrl: string = 'https://localhost:7266/api/';

  getAllTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(this.baseUrl + 'teams');
  }

  getDefenseExperts(): Observable<MVPTeams[]> {
    return this.http.get<MVPTeams[]>(this.baseUrl + 'BestDefensiveTeam');
  }

  getOffenseExperts(): Observable<MVPTeams[]> {
    return this.http.get<MVPTeams[]>(this.baseUrl + 'BestOffensiveTeam');
  }
}

export interface Team {
  name: string;
}

export interface MVPTeams {
  name: string;
  score: number;
}
