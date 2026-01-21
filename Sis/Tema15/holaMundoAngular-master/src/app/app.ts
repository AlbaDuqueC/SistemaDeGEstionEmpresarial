import { Component } from '@angular/core';
import { FormularioPersona, Persona } from "./components/formulario-persona/formulario-persona";
import { TablaPersonas } from "./components/tabla-personas/tabla-personas";
import { CommonModule } from '@angular/common';
import { CalendarioComponent } from './calendario/calendario';
@Component({
  selector: 'app-root',
  imports: [CommonModule, FormularioPersona, TablaPersonas, CalendarioComponent],
  templateUrl: './app.html',
  styleUrl: './app.css'
})
export class App {
  mostrarTabla = true;
  mostrarFormulario = false;
  modoEdicion = false;
  personaSeleccionada?: Persona;
  listaPersonas: Persona[] = [];

  abrirFormulario() {
    this.mostrarTabla = false;
    this.mostrarFormulario = true;
    this.modoEdicion = false;
    this.personaSeleccionada = undefined;
  }

  volverATabla() {
    this.mostrarTabla = true;
    this.mostrarFormulario = false;
  }

  guardarPersona(persona: Persona) {
    if (this.modoEdicion) {
      // Actualizar persona existente
      const index = this.listaPersonas.findIndex(p => p.id === persona.id);
      if (index !== -1) {
        this.listaPersonas[index] = persona;
      }
    } else {
      // Añadir nueva persona
      this.listaPersonas.push(persona);
    }
    this.volverATabla();
  }

  editarPersona(evento: { persona: Persona, index: number }) {
    this.modoEdicion = true;
    this.personaSeleccionada = { ...evento.persona };
    this.mostrarTabla = false;
    this.mostrarFormulario = true;
  }

  eliminarPersona(index: number) {
    this.listaPersonas.splice(index, 1);
  }
}