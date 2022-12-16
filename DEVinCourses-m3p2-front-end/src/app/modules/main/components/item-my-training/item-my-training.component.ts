import { Component, Input, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ITraining } from 'src/app/models/training';
import { AlertService } from '../../services/alert/alert.service';
import { TrainingService } from '../../../../services/training/training.service';
import { IRegistration } from 'src/app/models/registration';

@Component({
  selector: 'pro-item-my-training',
  templateUrl: './item-my-training.component.html',
  styleUrls: ['./item-my-training.component.scss'],
})
export class ItemMyTrainingComponent implements OnInit {
  userId!: number;

  @Input()
  registration: any = {
    id: 0,
    userId: 0,
    trainingId: 0,
    status: 0,
    refreshDate: 0,
    training: {
      id: 1,
      url: '',
      title: '',
      description: '',
      teacher: '',
      duration: '',
      active: true,
      category: '',
      modules:[]
    }
  };

  constructor(
    private alertService: AlertService,
    private trainingService: TrainingService,
    private router: Router
  ) {}

  ngOnInit(): void {}

  removeTraining(id:number) {
    this.alertService.alertDeleteTraining(id);
  }

  selectTraining(registration: IRegistration) {
    this.trainingService.registration = registration;
    this.router.navigate(['home/video']);
    this.refreshRecentTraining(1, Date.now());
  }

  refreshRecentTraining(id: number, dateRefresh: number) {
    this.trainingService.PatchRecentTrainingsByUser(id, dateRefresh);
  }

  formatarDuracao(duracao:number):any{
    return duracao.toString().replace(':00:00', '')
  }
}
