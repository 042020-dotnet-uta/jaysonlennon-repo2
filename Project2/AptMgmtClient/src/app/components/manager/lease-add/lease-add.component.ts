import { Component, OnInit } from '@angular/core';
import { Tenant } from './../../../Tenant';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-lease-add',
  templateUrl: './lease-add.component.html',
  styleUrls: ['./lease-add.component.css'],
})
export class LeaseAddComponent implements OnInit {
  leaseForm: FormGroup;
  /**
   * loading state provided to view component
   */
  public loading = false;
  /**
   * State to determine of the form has been submitted
   */
  public submitted = false;
  public returnUrl: string;
  public error = '';

  // TODO: Use data pulled from server instead of hardcoded
  apt = ['100', '101', '102', '200', '201', '202', '300', '301', '302'];
  model = new Tenant(1, '', '', '', '', '');
  constructor(private formBuilder: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.leaseForm = this.formBuilder.group({
      name: ['', Validators.required],
      apt: [this.apt[0], Validators.required],
      rent: ['', Validators.required],
      start: ['', Validators.required],
      end: ['', Validators.required],
    });
  }

  /**
   * convenient for getting form controls in template G
   */
  get f() {
    return this.leaseForm.controls;
  }

  update(): void {
    this.submitted = true;

    // stop if form is invalid
    if (this.leaseForm.invalid) {
      return;
    }
    // TODO: make the api call for adding a new lease
    console.log('TODO: make api call');
  }
}
