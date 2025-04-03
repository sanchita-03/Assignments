import { TestBed } from '@angular/core/testing';

import { EventmodelService } from './eventmodel.service';

describe('EventmodelService', () => {
  let service: EventmodelService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(EventmodelService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
