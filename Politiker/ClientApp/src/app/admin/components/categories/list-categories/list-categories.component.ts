import { Component, OnInit, TemplateRef, ComponentRef, ComponentFactory } from '@angular/core';
import { CategoryService } from '../../../../services/category.service';
import { Category } from '../../../../models/category';
import { ModalComponentFactory } from '../../../../factories/modal-component-factory';
import { ModalElementComponent } from '../../../../components/modal-element/modal-element.component';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-list-categories',
  templateUrl: './list-categories.component.html',
  styleUrls: ['./list-categories.component.scss'],
  providers: [ModalComponentFactory]
})
export class ListCategoriesComponent implements OnInit {
  categories: Category[];
  constructor(private categoryService: CategoryService, private modalFactory: ModalComponentFactory, private route: ActivatedRoute, private router: Router) { }

  ngOnInit() {
    this.categoryService.listCategories().subscribe(
      (data) => {
        this.categories = data;
        console.log(this.categories);
      },
      (err) => {
      }
    );
  }

  removeCategory(id: number) {
    //@ts-ignore
    const instance = this.modalFactory.openInstance(ModalElementComponent);
    instance.title = "Usun kategorie";

    this.modalFactory.result$.subscribe({
      complete: () => {
        this.remove(id);
      }
    });

  }

  onRemove(id: number) {
    this.categoryService.removeCategory(id).subscribe(
      () => {
        const index = this.categories.findIndex((x) => x.Id == id);
        this.categories.splice(index, 1);
      }
    );
  }

  editCategory(id: number) {
    this.router.navigate(['edit'], { queryParams: { id: id }, relativeTo: this.route });
  }
}
