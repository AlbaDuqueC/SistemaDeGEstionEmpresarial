import { Component, signal } from '@angular/core';
import { FormularioPersona } from "./components/formulario-persona/formulario-persona";
import { TablaPersonas } from "./components/tabla-personas/tabla-personas";
import { CommonModule } from '@angular/common';


@Component({
  selector: 'app-root',
  imports: [CommonModule, FormularioPersona, TablaPersonas],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {

  mostrarTabla = true;
  mostrarFormulario = false;
  mostrarListado = false;

  abrirFormulario() {
    this.mostrarTabla = false;
    this.mostrarFormulario = true;
    this.mostrarListado = false;
  }

  abrirListado() {
    this.mostrarTabla = false;
    this.mostrarFormulario = false;
    this.mostrarListado = true;
  }

  volverATabla() {
    this.mostrarTabla = true;
    this.mostrarFormulario = false;
    this.mostrarListado = false;
  }
}