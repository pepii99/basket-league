import { Component, OnInit } from '@angular/core';
import { Game, GamesService } from '../service/games.service';
import { games } from '../../dbData';

@Component({
  selector: 'app-games',
  templateUrl: './games.component.html',
  styleUrls: ['./games.component.css'],
})
export class GamesComponent implements OnInit {
  games: Game[] = [];

  highlightedGame: Game | any;

  constructor(private gamesService: GamesService) {}

  ngOnInit(): void {
    this.getAllGames();
  }

  getAllGames() {
    // return this.gamesService.getAllGames().subscribe((response) => {
    //   this.games = response;
    // });
    // this.highlightedGame = this.getHighlightedGame(this.games);

    this.games = games;
    this.highlightedGame = this.getHighlightedGame(this.games);
  }

  getHighlightedGame(games: Game[]): Game | any {
    const res = Math.max.apply(
      Math,
      games.map(function (o) {
        return o.maxScore;
      })
    );

    const game = this.games.find(function (o) {
      return o.maxScore === res;
    });

    return game;
  }
}
