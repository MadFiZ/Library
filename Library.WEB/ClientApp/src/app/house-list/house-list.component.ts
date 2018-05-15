import { Component, OnInit, Inject } from '@angular/core';

import { HousesService } from '../house-list/houses.service';
import { PublicationHouse } from "../house-list/house";
import { windowProvider } from '../window';


@Component({
  selector: 'app-house-list',
  templateUrl: './house-list.component.html',
  styleUrls: ['./house-list.component.css']
})
export class HouseListComponent implements OnInit {

  publicationHouse: PublicationHouse = new PublicationHouse();
  public publicationHouses: PublicationHouse[];
  tableMode: boolean = true;

  constructor(private publicationHouseService: HousesService,
    @Inject(windowProvider.provide) private window: Window) { }

  ngOnInit() {
    this.loadPublicationHouses();    // загрузка данных при старте компонента  
  }

  loadPublicationHouses() {
    this.publicationHouseService.getPublicationHouses()
      .subscribe((data: PublicationHouse[]) => this.publicationHouses = data);
  }
  // сохранение данных
  save() {
    if (this.publicationHouse.id == null) {
      this.publicationHouseService.createPublicationHouse(this.publicationHouse)
        .subscribe((data: PublicationHouse) => this.publicationHouses.push(data));
    } else {
      this.publicationHouseService.updatePublicationHouse(this.publicationHouse)
        .subscribe(data => this.loadPublicationHouses());
    }
    this.cancel();
  }
  editPublicationHouse(p: PublicationHouse) {
    this.publicationHouse = p;
  }
  cancel() {
    this.publicationHouse = new PublicationHouse();
    this.tableMode = true;
  }
  delete(b: PublicationHouse) {
    this.publicationHouseService.deletePublicationHouse(b.id)
      .subscribe(data => this.loadPublicationHouses());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }

}
