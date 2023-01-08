import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MyBooksItemComponent } from './my-books-item.component';

describe('MyBooksItemComponent', () => {
  let component: MyBooksItemComponent;
  let fixture: ComponentFixture<MyBooksItemComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MyBooksItemComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(MyBooksItemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
