import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MainRoutingModule } from './main-routing.module';
import { MainComponent } from './main.component';
import { HomeComponent } from './pages/home/home.component';
import { ItemTrainingComponent } from './components/item-training/item-training.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HeaderComponent } from 'src/app/components/header/header.component';
import { TrainingComponent } from './pages/training/training.component';
import { TrainingVideoComponent } from './pages/training-video/training-video.component';
import { ItemMyTrainingComponent } from './components/item-my-training/item-my-training.component';
import { FooterComponent } from 'src/app/components/footer/footer.component';

@NgModule({
  declarations: [
    MainComponent,
    HomeComponent,
    ItemTrainingComponent,
    HeaderComponent,
    TrainingComponent,
    TrainingVideoComponent,
    ItemMyTrainingComponent,
    FooterComponent,
  ],

  imports: [
    CommonModule,
    MainRoutingModule,
    NgbModule,
    FormsModule,
    ReactiveFormsModule,
  ],
})
export class MainModule {}
