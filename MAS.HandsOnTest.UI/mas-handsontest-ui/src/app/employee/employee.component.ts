import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { EmployeeService } from '../core/services/employee.service';
import { IEmployee } from '../core/models/IEmployee.interface';
import { isNumeric } from 'tslint';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css'],
})
export class EmployeeComponent implements OnInit {
  employees: IEmployee[];
  searchForm;

  // constructor() {}

  constructor(
    private employeeService: EmployeeService,
    private formBuilder: FormBuilder
  ) {
    this.searchForm = this.formBuilder.group({
      id: '',
    });
  }

  ngOnInit(): void {}

  getEmployees(value): void {
    this.employees = [];

    if (value.id !== '' && !isNaN(Number(value.id))) {
      this.employeeService.getEmployeeById(value.id).subscribe((emp) => {
        if (emp) {
          this.employees.push(emp);
        }
      });
    } else {
      this.employeeService.getEmployees().subscribe((emp) => {
        if (emp) {
          this.employees = emp;
        }
      });
    }
  }
}
