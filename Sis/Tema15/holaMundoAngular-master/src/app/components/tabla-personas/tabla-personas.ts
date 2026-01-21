import { Component, Input, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

// Interfaz para tipar los datos de persona
export interface Persona {
  id?: number;
  nombre: string;
  apellido: string;
  edad: number;
  email?: string;
}

@Component({
  selector: 'app-tabla-personas',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="tabla-container">
      <h2>Lista de Personas</h2>
      
      <table *ngIf="personas.length > 0; else sinDatos">
        <thead>
          <tr>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Edad</th>
            <th *ngIf="mostrarEmail">Email</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          <tr *ngFor="let persona of personas; let i = index">
            <td>{{ persona.nombre }}</td>
            <td>{{ persona.apellido }}</td>
            <td>{{ persona.edad }}</td>
            <td *ngIf="mostrarEmail">{{ persona.email || '-' }}</td>
            <td class="acciones">
              <button (click)="editar(persona, i)" class="btn-editar">
                Editar
              </button>
              <button (click)="eliminar(i)" class="btn-eliminar">
                Eliminar
              </button>
            </td>
          </tr>
        </tbody>
      </table>

      <ng-template #sinDatos>
        <p class="sin-datos">No hay personas registradas</p>
      </ng-template>
    </div>
  `,
  styles: [`
    .tabla-container {
      padding: 20px;
      background-color: #f5f5f5;
      border-radius: 8px;
    }

    .header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 20px;
    }

    h2 {
      margin: 0;
      color: #333;
    }

    .btn-nuevo {
      background-color: #4CAF50;
      color: white;
      padding: 10px 20px;
      font-size: 16px;
      font-weight: bold;
    }

    .btn-nuevo:hover {
      background-color: #45a049;
    }

    table {
      width: 100%;
      border-collapse: collapse;
      background-color: white;
      box-shadow: 0 2px 4px rgba(0,0,0,0.1);
    }

    th, td {
      padding: 12px;
      text-align: left;
      border-bottom: 1px solid #ddd;
    }

    th {
      background-color: #4CAF50;
      color: white;
      font-weight: bold;
    }

    tr:hover {
      background-color: #f5f5f5;
    }

    .acciones {
      display: flex;
      gap: 8px;
    }

    button {
      padding: 6px 12px;
      border: none;
      border-radius: 4px;
      cursor: pointer;
      font-size: 14px;
      transition: background-color 0.3s;
    }

    .btn-editar {
      background-color: #2196F3;
      color: white;
    }

    .btn-editar:hover {
      background-color: #0b7dda;
    }

    .btn-eliminar {
      background-color: #f44336;
      color: white;
    }

    .btn-eliminar:hover {
      background-color: #da190b;
    }

    .sin-datos {
      text-align: center;
      padding: 40px;
      color: #666;
      font-style: italic;
    }
  `]
})
export class TablaPersonas {
  @Input() personas: Persona[] = [
    {
      id: 1,
      nombre: 'Juan',
      apellido: 'García',
      edad: 28,
      email: 'juan.garcia@email.com'
    },
    {
      id: 2,
      nombre: 'María',
      apellido: 'Rodríguez',
      edad: 34,
      email: 'maria.rodriguez@email.com'
    },
    {
      id: 3,
      nombre: 'Carlos',
      apellido: 'López',
      edad: 42,
      email: 'carlos.lopez@email.com'
    },
    {
      id: 4,
      nombre: 'Ana',
      apellido: 'Martínez',
      edad: 25,
      email: 'ana.martinez@email.com'
    },
    {
      id: 5,
      nombre: 'Pedro',
      apellido: 'Sánchez',
      edad: 31,
      email: 'pedro.sanchez@email.com'
    }
  ];
  @Input() mostrarEmail: boolean = true;
  
  @Output() onEditar = new EventEmitter<{ persona: Persona, index: number }>();
  @Output() onEliminar = new EventEmitter<number>();
  @Output() onNuevo = new EventEmitter<void>();

  editar(persona: Persona, index: number) {
    this.onEditar.emit({ persona, index });
  }

  eliminar(index: number) {
    if (confirm('¿Estás seguro de eliminar esta persona?')) {
      this.onEliminar.emit(index);
    }
  }

  nuevo() {
    this.onNuevo.emit();
  }
}