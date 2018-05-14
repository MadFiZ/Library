import { Component, OnInit, Inject } from '@angular/core';

import { BrochureService } from '../brochure-list/brochure.service';
import { Brochure } from "../brochure-list/brochure";
import { windowProvider } from '../window';

@Component({
  selector: 'app-brochure-list',
  templateUrl: './brochure-list.component.html',
  styleUrls: ['./brochure-list.component.css']
})
export class BrochureListComponent implements OnInit {

  brochure: Brochure = new Brochure();
  public brochures: Brochure[];
  tableMode: boolean = true;

  constructor(private brochureService: BrochureService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadBrochures();    // загрузка данных при старте компонента  
  }

  loadBrochures() {
    this.brochureService.getBrochures()
      .subscribe((data: Brochure[]) => this.brochures = data);
  }
  // сохранение данных
  save() {
    if (this.brochure.id == null) {
      this.brochureService.createBrochure(this.brochure)
        .subscribe((data: Brochure) => this.brochures.push(data));
    } else {
      this.brochureService.updateBrochure(this.brochure)
        .subscribe(data => this.loadBrochures());
    }
    this.cancel();
  }
  editBrochure(p: Brochure) {
    this.brochure = p;
  }
  cancel() {
    this.brochure = new Brochure();
    this.tableMode = true;
  }
  delete(b: Brochure) {
    this.brochureService.deleteBrochure(b.id)
      .subscribe(data => this.loadBrochures());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}
