import { OnInit } from '@angular/core';
import {FormGroup, FormControl, Validators} from '@angular/forms';

export class FormularioPersona implements OnInit {

  formulario!: FormGroup;

  constructor() {

  }

  ngOnInit(): void {

    this.formulario = new FormGroup(

      {

        nombre: new FormControl('',[Validators.required]),

        apellidos: new FormControl('', [])

      }

    );

  }

  saluda() {

    if (this.formulario.valid) {

      alert('Hola ' + this.formulario.controls['nombre'].value + ' ' +
        this.formulario.controls['apellidos'].value);

    }

  }
}