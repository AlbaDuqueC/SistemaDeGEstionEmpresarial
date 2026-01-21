import { Component, Output, EventEmitter } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-calendario',
  standalone: true,
  imports: [CommonModule],
  template: `
    <div class="calendario-container">
      <div class="calendario-header">
        <button (click)="mesAnterior()" class="btn-nav">◀</button>
        <h2>{{ nombreMes }} {{ anioActual }}</h2>
        <button (click)="mesSiguiente()" class="btn-nav">▶</button>
      </div>

      <div class="calendario-grid">
        <!-- Días de la semana -->
        <div class="dia-semana" *ngFor="let dia of diasSemana">{{ dia }}</div>

        <!-- Días del mes anterior (grises) -->
        <div 
          class="dia dia-otro-mes" 
          *ngFor="let dia of diasMesAnterior">
          {{ dia }}
        </div>

        <!-- Días del mes actual -->
        <div 
          class="dia"
          *ngFor="let dia of diasMesActual"
          [class.hoy]="esHoy(dia)"
          [class.seleccionado]="esSeleccionado(dia)"
          (click)="seleccionarDia(dia)">
          {{ dia }}
        </div>

        <!-- Días del mes siguiente (grises) -->
        <div 
          class="dia dia-otro-mes" 
          *ngFor="let dia of diasMesSiguiente">
          {{ dia }}
        </div>
      </div>

      <div class="fecha-seleccionada" *ngIf="diaSeleccionado">
        <strong>Fecha seleccionada:</strong> 
        {{ diaSeleccionado }}/{{ mesActual + 1 }}/{{ anioActual }}
      </div>
    </div>
  `,
  styles: [`
    .calendario-container {
      background-color: white;
      border-radius: 12px;
      box-shadow: 0 4px 12px rgba(0,0,0,0.15);
      padding: 20px;
      max-width: 400px;
      margin: 20px auto;
    }

    .calendario-header {
      display: flex;
      justify-content: space-between;
      align-items: center;
      margin-bottom: 20px;
    }

    .calendario-header h2 {
      margin: 0;
      font-size: 20px;
      color: #333;
    }

    .btn-nav {
      background-color: #4CAF50;
      color: white;
      border: none;
      border-radius: 50%;
      width: 36px;
      height: 36px;
      font-size: 18px;
      cursor: pointer;
      transition: background-color 0.3s;
    }

    .btn-nav:hover {
      background-color: #45a049;
    }

    .calendario-grid {
      display: grid;
      grid-template-columns: repeat(7, 1fr);
      gap: 8px;
    }

    .dia-semana {
      text-align: center;
      font-weight: bold;
      color: #666;
      padding: 8px;
      font-size: 14px;
    }

    .dia {
      text-align: center;
      padding: 12px;
      border-radius: 8px;
      cursor: pointer;
      transition: all 0.3s;
      font-size: 14px;
      color: #333;
    }

    .dia:hover {
      background-color: #e8f5e9;
    }

    .dia-otro-mes {
      color: #ccc;
      cursor: default;
    }

    .dia-otro-mes:hover {
      background-color: transparent;
    }

    .hoy {
      background-color: #2196F3;
      color: white;
      font-weight: bold;
    }

    .hoy:hover {
      background-color: #1976D2;
    }

    .seleccionado {
      background-color: #4CAF50;
      color: white;
      font-weight: bold;
    }

    .seleccionado:hover {
      background-color: #45a049;
    }

    .fecha-seleccionada {
      margin-top: 20px;
      padding: 12px;
      background-color: #f5f5f5;
      border-radius: 8px;
      text-align: center;
      color: #333;
    }

    .fecha-seleccionada strong {
      color: #4CAF50;
    }
  `]
})
export class CalendarioComponent {
  @Output() fechaSeleccionada = new EventEmitter<Date>();

  diasSemana = ['Dom', 'Lun', 'Mar', 'Mié', 'Jue', 'Vie', 'Sáb'];
  meses = [
    'Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
    'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'
  ];

  hoy = new Date();
  mesActual = this.hoy.getMonth();
  anioActual = this.hoy.getFullYear();
  diaSeleccionado: number | null = null;

  diasMesAnterior: number[] = [];
  diasMesActual: number[] = [];
  diasMesSiguiente: number[] = [];

  constructor() {
    this.generarCalendario();
  }

  get nombreMes(): string {
    return this.meses[this.mesActual];
  }

  generarCalendario() {
    // Primer día del mes
    const primerDia = new Date(this.anioActual, this.mesActual, 1);
    const diaSemana = primerDia.getDay();

    // Último día del mes
    const ultimoDia = new Date(this.anioActual, this.mesActual + 1, 0);
    const totalDias = ultimoDia.getDate();

    // Días del mes anterior
    const ultimoDiaMesAnterior = new Date(this.anioActual, this.mesActual, 0).getDate();
    this.diasMesAnterior = [];
    for (let i = diaSemana - 1; i >= 0; i--) {
      this.diasMesAnterior.push(ultimoDiaMesAnterior - i);
    }

    // Días del mes actual
    this.diasMesActual = [];
    for (let i = 1; i <= totalDias; i++) {
      this.diasMesActual.push(i);
    }

    // Días del mes siguiente para completar la grilla
    const totalCeldas = this.diasMesAnterior.length + this.diasMesActual.length;
    const diasRestantes = 42 - totalCeldas; // 6 filas x 7 columnas = 42
    this.diasMesSiguiente = [];
    for (let i = 1; i <= diasRestantes; i++) {
      this.diasMesSiguiente.push(i);
    }
  }

  mesAnterior() {
    if (this.mesActual === 0) {
      this.mesActual = 11;
      this.anioActual--;
    } else {
      this.mesActual--;
    }
    this.diaSeleccionado = null;
    this.generarCalendario();
  }

  mesSiguiente() {
    if (this.mesActual === 11) {
      this.mesActual = 0;
      this.anioActual++;
    } else {
      this.mesActual++;
    }
    this.diaSeleccionado = null;
    this.generarCalendario();
  }

  esHoy(dia: number): boolean {
    return (
      dia === this.hoy.getDate() &&
      this.mesActual === this.hoy.getMonth() &&
      this.anioActual === this.hoy.getFullYear()
    );
  }

  esSeleccionado(dia: number): boolean {
    return dia === this.diaSeleccionado;
  }

  seleccionarDia(dia: number) {
    this.diaSeleccionado = dia;
    const fecha = new Date(this.anioActual, this.mesActual, dia);
    this.fechaSeleccionada.emit(fecha);
  }
}