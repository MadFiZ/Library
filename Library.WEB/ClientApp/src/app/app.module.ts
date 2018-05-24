import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { GridModule } from '@progress/kendo-angular-grid';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { PopupModule } from '@progress/kendo-angular-popup';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { BookListComponent } from './book-list/book-list.component';
import { BookService } from '../app/book-list/book.service';
import { windowProvider } from './window';
import { MagazineListComponent } from './magazine-list/magazine-list.component';
import { MagazineService } from '../app/magazine-list/magazine.service';
import { PublicationService } from '../app/publication-list/publication.service';
import { PublicationListComponent } from './publication-list/publication-list.component';
import { BrochureListComponent } from './brochure-list/brochure-list.component';
import { BrochureService } from '../app/brochure-list/brochure.service';
import { HouseListComponent } from './house-list/house-list.component';
import { HousesService } from '../app/house-list/houses.service';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BookListComponent,
    MagazineListComponent,
    PublicationListComponent,
    BrochureListComponent,
    HouseListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    GridModule,
    HttpClientModule,
    FormsModule,
    PopupModule,
    DropDownsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: PublicationListComponent, pathMatch: 'full' },
      { path: 'book-list', component: BookListComponent },
      { path: 'magazine-list', component: MagazineListComponent },
      { path: 'brochure-list', component: BrochureListComponent },
      { path: 'house-list', component: HouseListComponent },
    ])
  ],
  providers: [BookService, windowProvider, MagazineService, PublicationService, BrochureService, HousesService],
  bootstrap: [AppComponent]
})
export class AppModule { }
