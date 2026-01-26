import { Component, OnInit, ChangeDetectionStrategy } from '@angular/core';
import { PeopleListVM } from '../../ui/ViewModel/PeopleListVM';
// Update the import path if inversify.config.ts is in a different directory, for example:
import { container } from '../../core/Container';


@Component({
  selector: 'app-people-list',
  templateUrl: './people-list.html',
  styleUrls: ['./people-list.component.scss'],
  // Usamos OnPush para rendimiento, delegando la detección de cambios a MobX
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListaPersonas implements OnInit {
  
  public vm: PeopleListVM;

  constructor() {
    // IMPORTANTE: Como usas Inversify dentro del VM, necesitamos resolverlo
    // a través del contenedor de Inversify, no del DI de Angular directamente.
    // Esto asume que has bindeado PeopleListVM en tu contenedor.
    this.vm = container.get(PeopleListVM);
  }

  ngOnInit(): void {
    // Si necesitaras cargar datos asíncronos, aquí llamarías al VM
  }
}