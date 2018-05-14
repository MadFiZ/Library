import { TestBed, inject } from '@angular/core/testing';

import { BrochureService } from './brochure.service';

describe('BrochureService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [BrochureService]
    });
  });

  it('should be created', inject([BrochureService], (service: BrochureService) => {
    expect(service).toBeTruthy();
  }));
});
