import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { MobxAngularModule } from 'mobx-angular';
import { PeopleListVM } from '../ui/ViewModel/PeopleListVM';
import { container } from '../core/Container';
import { TYPES } from '../core/types'; // Necesitas importar TYPES
import {ListaPersonas} from './lista-personas/lista-personas'

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RouterOutlet, MobxAngularModule, ListaPersonas], 
  templateUrl: './app.html',
  styleUrls: ['./app.css']
})
export class App {
  
  public vm: PeopleListVM;

  constructor() {
    // CORRECCIÓN: Usa get() en lugar de resolve()
    this.vm = container.get<PeopleListVM>(TYPES.IndexVM);
  }
}