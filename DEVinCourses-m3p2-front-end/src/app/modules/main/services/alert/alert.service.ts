import { Injectable } from '@angular/core';
import { TrainingService } from 'src/app/services/training/training.service';
import Swal from 'sweetalert2';
import { TrainingComponent } from '../../pages/training/training.component';

@Injectable({
  providedIn: 'root'
})
export class AlertService {

  constructor(private trainingService:TrainingService) { }

  alertDeleteTraining(id:number){
    Swal.fire({
      title: 'Deseja excluir o treinamento?',      
      showCancelButton: true,
      confirmButtonText: 'Sim',      
      cancelButtonText:'Cancelar'
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
        this.trainingService.deleteRegistration(id).subscribe();
        //TODO: chamar função delete api
        Swal.fire('Excluido!', '', 'success')
      } else if (result.isDenied) {
        Swal.fire('Não excluido', '', 'info')
      }
    })}

  alertUserIsRegistered(){
    Swal.fire({
      icon: 'error',
      title: 'Oops...',
      text: 'Você já está matriculado neste curso.',
      footer: '<small>© 2022 Devin[NDD] Team</small>'
    })
  }

  alertRegisterSuccess(){
    Swal.fire({
      icon: 'success',
      title: 'Matricula efetuada com sucesso!',
      footer: '<small>© 2022 Devin[NDD] Team</small>',
      showConfirmButton: false,
      timer: 2500
    })
  }
}
