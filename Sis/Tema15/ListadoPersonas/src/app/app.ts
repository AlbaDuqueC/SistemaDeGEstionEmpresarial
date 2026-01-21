import { Component } from '@angular/core';
import { CommonModule } from '@angular/common'; // Para *ngIf, *ngFor, date pipe
import { RouterOutlet } from '@angular/router';
import { MobxAngularModule } from 'mobx-angular'; // IMPORTANTE para la reactividad
import { PeopleListVM } from './people-list.vm'; // Tu ViewModel
import { container } from '../inversify.config'; // Tu contenedor configurado

@Component({
  selector: 'app-root',
  standalone: true,
  // Importamos CommonModule para las directivas básicas y MobxAngularModule para conectar la vista
  imports: [CommonModule, RouterOutlet, MobxAngularModule], 
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  
  // Exponemos el VM a la vista
  public vm: PeopleListVM;

  constructor() {
    // INYECCIÓN:
    // Como tu VM tiene dependencias de Inversify (@inject), Angular no puede instanciarlo solo.
    // Usamos el contenedor para resolver el VM y todas sus dependencias internas (Repositorios).
    this.vm = container.resolve(PeopleListVM);
  }
}