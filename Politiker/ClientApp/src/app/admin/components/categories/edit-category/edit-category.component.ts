import { Component, OnInit } from '@angular/core';
import { CategoryService } from '../../../../services/category.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from '../../../../models/category';
import { FormStatus } from '../../../../enums/form-status';
import { ActivatedRoute } from '@angular/router';
import '../../../../extensions/object-extensions';

@Component({
  selector: 'app-edit-category',
  templateUrl: './edit-category.component.html',
  styleUrls: ['./edit-category.component.scss']
})
export class EditCategoryComponent implements OnInit {
  categoryForm: FormGroup;
  category: Category = new Category();
  hasServerErrors: boolean = false;
  serverErrors: string[];
  formStatusType = FormStatus;
  formStatus: FormStatus = FormStatus.Ready;
  formErrors: object = {
    name: 'Wprowadz nazwe'
  }
  registered: string;
  constructor(private categoryService: CategoryService, private fb: FormBuilder, private route: ActivatedRoute) {
    this.categoryForm = this.fb.group({
      Id: [],
      Name: ['', Validators.required],
    });
  }

  ngOnInit() {
    this.route.queryParams.subscribe(
      (query) => {
        this.category.Id = query.id;
      }
    );
    this.categoryService.getCategory(this.category.Id).subscribe(
      (category) => {
        this.category = category;
        this.categoryForm.patchValue(Object.pascalCaseKeys(this.category));
      }
    );


  }


  onSubmit() {
    if (this.categoryForm.invalid) {
      return;
    }

    this.formStatus = FormStatus.Proccessing;

    this.category = {
      ...this.categoryForm.value
    };
    console.log(this.category);

    this.categoryService.updateCategory(this.category).subscribe(
      () => {
        this.formStatus = FormStatus.Succeed;
        this.hasServerErrors = false;
        this.registered = this.category.Name;
      },
      (err) => {
        this.serverErrors = err;
        this.hasServerErrors = true;
        this.formStatus = FormStatus.Ready;
      }
    );
  }

}
