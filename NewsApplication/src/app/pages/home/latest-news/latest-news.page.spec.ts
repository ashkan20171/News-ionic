import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { IonicModule } from '@ionic/angular';

import { LatestNewsPage } from './latest-news.page';

describe('LatestNewsPage', () => {
  let component: LatestNewsPage;
  let fixture: ComponentFixture<LatestNewsPage>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LatestNewsPage ],
      imports: [IonicModule.forRoot()]
    }).compileComponents();

    fixture = TestBed.createComponent(LatestNewsPage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
