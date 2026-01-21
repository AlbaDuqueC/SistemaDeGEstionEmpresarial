import { Routes } from '@angular/router';
import { TablaPersona } from './tabla-persona/tabla-persona';
import { ListaPersonas } from './lista-personas/lista-personas';

export const routes: Routes = [
  { path: '', component: TablaPersona },
  { path: 'listado', component: ListaPersonas },
  { path: '**', redirectTo: '' }
];