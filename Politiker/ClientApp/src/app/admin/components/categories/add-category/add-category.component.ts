import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {

  categoryForm: FormGroup;
  constructor(private fb: FormBuilder) {
    this.categoryForm = fb.group({
      Name: ['', Validators.required],
    });
  }

  ngOnInit() {
  }

}
