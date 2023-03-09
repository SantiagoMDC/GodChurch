import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { catchError, Observable, tap } from 'rxjs';
import { HandleHttpErrorService } from '../@base/handle-http-error.service';
import { Miembro } from '../models/miembro';

@Injectable({
  providedIn: 'root',
})
export class MiembroService {
  baseUrl: string;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
  ) {
    this.baseUrl = baseUrl;
  }

  get(): Observable<Miembro[]> {
    return this.http.get<Miembro[]>(this.baseUrl + 'api/Miembro').pipe(
      tap((_) => this.handleErrorService.log('Datos enviados')),
      catchError(
        this.handleErrorService.handleError<Miembro[]>('Consulta Miembro')
      )
    );
  }

  post(miembro: Miembro): Observable<Miembro> {
    return this.http.post<Miembro>(this.baseUrl + 'api/Miembro', miembro).pipe(
      tap((_) => this.handleErrorService.log('Datos enviados')),
      catchError(
        this.handleErrorService.handleError<Miembro>('Miembro Registrado')
      )
    );
  }

  buscarIdentificacion(identificacion: string): Observable<Miembro> {
    return this.http
      .get<Miembro>(this.baseUrl + 'api/Miembro/' + identificacion)
      .pipe(
        catchError(
          this.handleErrorService.handleError<Miembro>(
            'Consulta identificacion'
          )
        )
      );
  }
}
