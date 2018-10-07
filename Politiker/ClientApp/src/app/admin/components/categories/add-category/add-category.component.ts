import { Component, OnInit } from '@angular/core';
import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Category } from '../../../../models/category';
import { FormStatus } from '../../../../enums/form-status';
import { CategoryService } from '../../../../services/category.service';

@Component({
  selector: 'app-add-category',
  templateUrl: './add-category.component.html',
  styleUrls: ['./add-category.component.scss']
})
export class AddCategoryComponent implements OnInit {

  categoryForm: FormGroup;
  category: Category = new Category();
  hasServerErrors: boolean = false;
  serverErrors: string[];
  formStatusType = FormStatus;
  formStatus: FormStatus = FormStatus.Ready;
  formErrors: object = {
    name: 'Wprowadz nazwe'
  }
  registered: string[];

  constructor(private fb: FormBuilder, private categoryService: CategoryService) {
    this.categoryForm = fb.group({
      Name: ['', Validators.required],
    });
  }

  ngOnInit() {
  }

  onSubmit() {
    if (this.categoryForm.invalid) {
      return;
    }

    this.formStatus = FormStatus.Proccessing;

    this.category = {
      ...this.categoryForm.value
    };

    this.categoryService.addCategory(this.category).subscribe(
      () => {
        this.formStatus = FormStatus.Succeed;
        this.hasServerErrors = false;
        this.categoryForm.reset();
        if (this.registered === undefined)
          this.registered = []; 
        this.registered.push(this.category.Name);
      },
      (err) => {
        this.serverErrors = err;
        this.hasServerErrors = true;
        this.formStatus = FormStatus.Ready;
      }
    );
  }
}
