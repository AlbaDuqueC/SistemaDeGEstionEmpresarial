import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

export interface Persona {
  id?: number;
  nombre: string;
  apellido: string;
  edad: number;
  email?: string;
}

@Component({
  selector: 'app-formulario-persona',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  template: `
    <div class="formulario-container">
      <h2>{{ modoEdicion ? 'Editar' : 'Nueva' }} Persona</h2>
      
      <form [formGroup]="formulario" (ngSubmit)="guardar()">
        
        <div class="form-group">
          <label for="nombre">Nombre *</label>
          <input 
            id="nombre"
            type="text" 
            formControlName="nombre"
            [class.error]="formulario.controls['nombre'].invalid && formulario.controls['nombre'].touched"
            placeholder="Ingresa el nombre">
          <span class="mensaje-error" *ngIf="formulario.controls['nombre'].invalid && formulario.controls['nombre'].touched">
            El nombre es obligatorio
          </span>
        </div>

        <div class="form-group">
          <label for="apellido">Apellido *</label>
          <input 
            id="apellido"
            type="text" 
            formControlName="apellido"
            [class.error]="formulario.controls['apellido'].invalid && formulario.controls['apellido'].touched"
            placeholder="Ingresa el apellido">
          <span class="mensaje-error" *ngIf="formulario.controls['apellido'].invalid && formulario.controls['apellido'].touched">
            El apellido es obligatorio
          </span>
        </div>

        <div class="form-group">
          <label for="edad">Edad *</label>
          <input 
            id="edad"
            type="number" 
            formControlName="edad"
            [class.error]="formulario.controls['edad'].invalid && formulario.controls['edad'].touched"
            placeholder="Ingresa la edad">
          <span class="mensaje-error" *ngIf="formulario.controls['edad'].invalid && formulario.controls['edad'].touched">
            La edad debe ser entre 1 y 120 años
          </span>
        </div>

        <div class="form-group">
          <label for="email">Email</label>
          <input 
            id="email"
            type="email" 
            formControlName="email"
            [class.error]="formulario.controls['email'].invalid && formulario.controls['email'].touched"
            placeholder="ejemplo@email.com">
          <span class="mensaje-error" *ngIf="formulario.controls['email'].invalid && formulario.controls['email'].touched">
            Ingresa un email válido
          </span>
        </div>

        <div class="botones">
          <button type="submit" [disabled]="formulario.invalid" class="btn-guardar">
            {{ modoEdicion ? 'Actualizar' : 'Guardar' }}
          </button>
          <button type="button" (click)="cancelar()" class="btn-cancelar">
            Cancelar
          </button>
        </div>

      </form>
    </div>
  `,
  styles: [`
    .formulario-container {
      padding: 20px;
      background-color: white;
      border-radius: 8px;
      box-shadow: 0 2px 8px rgba(0,0,0,0.1);
      max-width: 600px;
      margin: 0 auto;
    }

    h2 {
      margin-bottom: 24px;
      color: #333;
      text-align: center;
    }

    form {
      display: flex;
      flex-direction: column;
      gap: 20px;
    }

    .form-group {
      display: flex;
      flex-direction: column;
      gap: 6px;
    }

    label {
      font-weight: bold;
      color: #555;
      font-size: 14px;
    }

    input {
      padding: 10px 12px;
      border: 2px solid #ddd;
      border-radius: 4px;
      font-size: 16px;
      transition: border-color 0.3s;
    }

    input:focus {
      outline: none;
      border-color: #4CAF50;
    }

    input.error {
      border-color: #f44336;
    }

    .mensaje-error {
      color: #f44336;
      font-size: 12px;
      margin-top: 4px;
    }

    .botones {
      display: flex;
      gap: 12px;
      margin-top: 8px;
    }

    button {
      flex: 1;
      padding: 12px;
      border: none;
      border-radius: 4px;
      font-size: 16px;
      font-weight: bold;
      cursor: pointer;
      transition: all 0.3s;
    }

    .btn-guardar {
      background-color: #4CAF50;
      color: white;
    }

    .btn-guardar:hover:not(:disabled) {
      background-color: #45a049;
    }

    .btn-guardar:disabled {
      background-color: #ccc;
      cursor: not-allowed;
    }

    .btn-cancelar {
      background-color: #f44336;
      color: white;
    }

    .btn-cancelar:hover {
      background-color: #da190b;
    }
  `]
})
export class FormularioPersona implements OnInit {
  @Input() personaEditar?: Persona;
  @Input() modoEdicion: boolean = false;
  
  @Output() onGuardar = new EventEmitter<Persona>();
  @Output() onCancelar = new EventEmitter<void>();

  formulario!: FormGroup;

  ngOnInit(): void {
    this.formulario = new FormGroup({
      nombre: new FormControl('', [Validators.required]),
      apellido: new FormControl('', [Validators.required]),
      edad: new FormControl('', [
        Validators.required, 
        Validators.min(1), 
        Validators.max(120)
      ]),
      email: new FormControl('', [Validators.email])
    });

    // Si hay persona para editar, cargar los datos
    if (this.personaEditar) {
      this.formulario.patchValue({
        nombre: this.personaEditar.nombre,
        apellido: this.personaEditar.apellido,
        edad: this.personaEditar.edad,
        email: this.personaEditar.email || ''
      });
    }
  }

  guardar() {
    if (this.formulario.valid) {
      const persona: Persona = {
        id: this.personaEditar?.id || Date.now(),
        nombre: this.formulario.controls['nombre'].value,
        apellido: this.formulario.controls['apellido'].value,
        edad: this.formulario.controls['edad'].value,
        email: this.formulario.controls['email'].value
      };
      
      this.onGuardar.emit(persona);
      this.formulario.reset();
    }
  }

  cancelar() {
    this.formulario.reset();
    this.onCancelar.emit();
  }
}