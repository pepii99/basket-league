import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class GamesService {
  constructor(private http: HttpClient) {}

  baseUrl: string = 'https://localhost:7266/api/games';

  getAllGames(): Observable<Game[]> {
    return this.http.get<Game[]>(this.baseUrl);
  }
}

export interface Game {
  awayTeamName: string;
  awayTeamScore: number;
  homeTeamName: string;
  homeTeamScore: number;
  maxScore: number;
}
