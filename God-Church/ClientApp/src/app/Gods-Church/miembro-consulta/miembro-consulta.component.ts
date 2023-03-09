import { Component, OnInit } from '@angular/core';
import { Miembro } from 'src/app/models/miembro';
import { MiembroService } from 'src/app/services/miembro.service';

@Component({
  selector: 'app-miembro-consulta',
  templateUrl: './miembro-consulta.component.html',
  styleUrls: ['./miembro-consulta.component.css']
})
export class MiembroConsultaComponent implements OnInit {
  searchText = "";  
  miembros: Miembro[] | undefined;
  constructor(private miembroService: MiembroService) { }

  ngOnInit() {
    this.miembroService.get().subscribe(result => {
    this.miembros = result;
    });
    }

}
