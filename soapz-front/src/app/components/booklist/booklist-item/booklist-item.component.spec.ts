import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BooklistItemComponent } from './booklist-item.component';

describe('BooklistItemComponent', () => {
  let component: BooklistItemComponent;
  let fixture: ComponentFixture<BooklistItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BooklistItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(BooklistItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
