import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { IEmployee } from '../models/IEmployee.interface';
import { environment } from '../../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class EmployeeService {
  constructor(private http: HttpClient) {}

  getEmployees(): Observable<IEmployee[]> {
    return this.http.get<IEmployee[]>(
      `${environment.masHandsOnTestApiUl}/Employees`
    );
  }

  getEmployeeById(id: number): Observable<IEmployee> {
    return this.http.get<IEmployee>(
      `${environment.masHandsOnTestApiUl}/Employees/${id}`
    );
  }
}
