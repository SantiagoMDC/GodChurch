import { Component, OnInit } from '@angular/core';
import { Miembro } from 'src/app/models/miembro';
import { MiembroService } from 'src/app/services/miembro.service';

@Component({
  selector: 'app-miembro-registro',
  templateUrl: './miembro-registro.component.html',
  styleUrls: ['./miembro-registro.component.css']
})
export class MiembroRegistroComponent implements OnInit {

  miembro: Miembro = new Miembro;
  constructor(private miembroService: MiembroService) { }

  ngOnInit(): void {
    miembro : Miembro  ;
  }

  add(){
    this.miembroService.post(this.miembro).subscribe(p =>{
      if (p != null){
        alert('¡Miembro creado!');
        this.miembro = p;
      }
    })
  }



}
