import { Component, OnDestroy, OnInit } from '@angular/core';
import { HomeStatsService } from './home-stats.service';
import { Subscription } from 'rxjs/index';
import { Select, Store } from '@ngxs/store';
import {
  SetNetworkSelectedYearAction,
  SetTopBuyersAction,
  SetTopBuyersSelectedYearAction,
  SetTopItemsAction,
  SetTopItemsSelectedYearAction,
  SetTopSuppliersAction,
  SetTopSuppliersSelectedYearAction
} from './home-state/actions';
import { HomeState } from './home-state/home.state';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.scss']
})
export class HomeComponent implements OnInit, OnDestroy {
  @Select(HomeState.topBuyersSelectedYear) public topBuyersSelectedYear$;
  @Select(HomeState.topSuppliersSelectedYear) public topSuppliersSelectedYear$;
  @Select(HomeState.topItemsSelectedYear) public topItemsSelectedYear$;
  @Select(HomeState.networkSelectedYear) public networkSelectedYear$;
  @Select(HomeState.topBuyers) private topBuyers$;
  @Select(HomeState.topSuppliers) private topSuppliers$;
  @Select(HomeState.topItems) private topItems$;
  itemsList: any = [];

  subs = new Subscription();
  topBuyers;
  topBuyersLoading = true;
  topSuppliers;
  topSuppliersLoading = true;
  topItems;
  topItemsLoading = true;
  years = ['2015', '2016', '2017', '2018'];

  /// items graph data
  itemPriceGraphData: any[];
  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C', '#AAAAAA']
  };

  constructor(private store: Store,
              private homeStats: HomeStatsService) {

  }

  public ngOnInit() {
    this.getListOfItems();
    this.getTopBuyers();
    this.getTopSuppliers();
    this.getTopItems();
  }

  public ngOnDestroy() {
    this.subs.unsubscribe();
  }

  public onItemChange(item) {
    this.subs.add(
      this.homeStats.getItemPrices(item).subscribe((prices:any) => {
        const data = {};
        const result = [];
        for (const year in prices.releaseItems) {
          const units = prices.releaseItems[year];
          for (const unityOfMeassure in units) {
            const series = [];
            const items = units[unityOfMeassure];
            for (const item of items) {
              const serie = {name: year, value: item.unitValueAmountUYU};
              series.push(serie);
            }

            if (!data[unityOfMeassure]) {
              data[unityOfMeassure] = series;
            } else {
              data[unityOfMeassure] = data[unityOfMeassure].concat(series);
            }

          }
        }
        for (const unityOfMeassure in data) {
          result.push({name: unityOfMeassure, series: data[unityOfMeassure]})
        }
        this.itemPriceGraphData = result;
      })
    );
  }

  public topBuyersSelectedYear(year) {
    this.topBuyersLoading = true;
    this.store.dispatch([new SetTopBuyersSelectedYearAction(year)]).subscribe(() => this.requestBuyers());
  }

  public topItemsSelectedYear(year) {
    this.topItemsLoading = true;
    this.store.dispatch([new SetTopItemsSelectedYearAction(year)]).subscribe(() => this.requestItems());
  }

  public topSuppliersSelectedYear(year) {
    this.topSuppliersLoading = true;
    this.store.dispatch([new SetTopSuppliersSelectedYearAction(year)]).subscribe(() => this.requestSuppliers());
  }

  public networkSelectedYear(year) {
    this.store.dispatch([new SetNetworkSelectedYearAction(year)]).subscribe(() => true);
  }

  public get networkURL() {
    const year = this.store.selectSnapshot(HomeState.networkSelectedYear);
    return `http://cuentasclaras-uy.azurewebsites.net/NetworkApp/index.html#${year}-network.gexf`
  }

  private getTopBuyers() {
    const buyersSub = this.topBuyers$.subscribe((topBuyers) => {
      if (!topBuyers) {
        this.requestBuyers();
      }
      else {
        this.topBuyers = topBuyers;
        this.topBuyersLoading = false;
      }
    }, () => {
      this.topBuyersLoading = false;
    });
    this.subs.add(buyersSub);
  }

  private requestBuyers() {
    const selectedYear = this.store.selectSnapshot(HomeState.topBuyersSelectedYear);
    const topBuyersSub = this.homeStats.getTopBuyers(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch([new SetTopBuyersAction(data)]).subscribe(() => {
        this.topBuyersLoading = false;
      }));
    });
    this.subs.add(topBuyersSub);
  }

  private getTopSuppliers() {
    const suppliersSub = this.topSuppliers$.subscribe((topSuppliers) => {
      if (!topSuppliers) {
        this.requestSuppliers();
      } else {
        this.topSuppliers = topSuppliers;
        this.topSuppliersLoading = false;
      }
    }, () => {
      this.topBuyersLoading = false;
    });
    this.subs.add(suppliersSub);
  }

  private requestSuppliers() {
    const selectedYear = this.store.selectSnapshot(HomeState.topSuppliersSelectedYear);
    const topSuppliersSub = this.homeStats.getTopSuppliers(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch([new SetTopSuppliersAction(data)]).subscribe(() => {
        this.topSuppliersLoading = false;
      }));
    });
    this.subs.add(topSuppliersSub);
  }

  private getTopItems() {
    const itemsSub = this.topItems$.subscribe((topItems) => {
      if (!topItems) {
        this.requestItems();
      } else {
        this.topItems = topItems;
        this.topItemsLoading = false;
      }
    }, () => {
      this.topItemsLoading = false;
    });
    this.subs.add(itemsSub);
  }

  private requestItems() {
    const selectedYear = this.store.selectSnapshot(HomeState.topItemsSelectedYear);
    const topItemsSub = this.homeStats.getTopItems(selectedYear).subscribe((data) => {
      this.subs.add(this.store.dispatch([new SetTopItemsAction(data)]).subscribe(() => {
        this.topItemsLoading = false;
      }));
    });
    this.subs.add(topItemsSub);
  }

  private getListOfItems() {
    this.subs.add(this.homeStats.getListofItems().subscribe((list: any) => {
      this.itemsList = list;
      if (list && list.length > 0) {
        this.onItemChange(list[0].releaseItemClassificationId);
      }
    }));

  }
}
