import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from "rxjs/Observable";
import { Brochure } from './brochure';

@Injectable()
export class BrochureService {

  private url = "/api/brochures";

  constructor(private http: HttpClient) {
  }

  getBrochures(): Observable<Brochure[]> {
    return this.http.get<Brochure[]>(this.url);
  }

  createBrochure(brochure: Brochure) {
    return this.http.post(this.url, brochure);
  }
  updateBrochure(brochure: Brochure) {

    return this.http.put(this.url + '/' + brochure.id, brochure);
  }
  deleteBrochure(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
