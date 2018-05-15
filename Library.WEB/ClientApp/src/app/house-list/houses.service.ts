import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { PublicationHouse } from '../house-list/house';

@Injectable()
export class HousesService {

  private url = "/api/houses";

  constructor(private http: HttpClient) {
  }

  getPublicationHouses(): Observable<PublicationHouse[]> {
    return this.http.get<PublicationHouse[]>(this.url);
  }

  createPublicationHouse(publicationHouse: PublicationHouse) {
    return this.http.post(this.url, publicationHouse);
  }
  updatePublicationHouse(publicationHouse: PublicationHouse) {

    return this.http.put(this.url + '/' + publicationHouse.id, publicationHouse);
  }
  deletePublicationHouse(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
