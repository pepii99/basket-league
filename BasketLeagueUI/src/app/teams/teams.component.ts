import { Component, OnInit } from '@angular/core';
import { MVPTeams, Team, TeamsService } from '../service/teams.service';
import { teams, attackTeams, defenseTeams } from '../../dbData';

@Component({
  selector: 'app-teams',
  templateUrl: './teams.component.html',
  styleUrls: ['./teams.component.css'],
})
export class TeamsComponent implements OnInit {
  teams: Team[] = [];
  defenseExperts: MVPTeams[] = [];
  offenseExperts: MVPTeams[] = [];

  constructor(private teamsService: TeamsService) {}

  ngOnInit(): void {
    this.getAllTeams();
    this.getDefenseExperts();
    this.getOffenseExperts();
  }

  getAllTeams() {
    // return this.teamsService.getAllTeams().subscribe((response) => {
    //   this.teams = response;
    // });

    this.teams = teams;
  }

  getDefenseExperts() {
    // return this.teamsService.getDefenseExperts().subscribe((response) => {
    //   this.defenseExperts = response;
    // });

    this.defenseExperts = defenseTeams;
  }

  getOffenseExperts() {
    // return this.teamsService.getOffenseExperts().subscribe((response) => {
    //   this.offenseExperts = response;
    // });

    this.offenseExperts = attackTeams;
  }
}
