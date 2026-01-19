import { Routes } from '@angular/router';
import { TablaPersonasComponent } from './tabla-persona/tabla-persona';
import { ListadoPersonasComponent } from './lista-personas/lista-personas';

export const routes: Routes = [
  { path: '', component: TablaPersonasComponent },
  { path: 'listado', component: ListadoPersonasComponent },
  { path: '**', redirectTo: '' }
];