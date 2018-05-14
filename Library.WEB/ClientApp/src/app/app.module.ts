import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    BookListComponent,
    MagazineListComponent,
    PublicationListComponent,
    BrochureListComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: PublicationListComponent, pathMatch: 'full' },
      { path: 'book-list', component: BookListComponent },
      { path: 'magazine-list', component: MagazineListComponent },
      { path: 'brochure-list', component: BrochureListComponent },
    ])
  ],
  providers: [BookService, windowProvider, MagazineService, PublicationService, BrochureService],
  bootstrap: [AppComponent]
})
export class AppModule { }
