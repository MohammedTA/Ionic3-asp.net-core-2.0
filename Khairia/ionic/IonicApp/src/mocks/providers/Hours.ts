import { Injectable } from '@angular/core';

import { Hour } from '../../models/hour';

@Injectable()
export class Hours {
  hourList: Hour[] = [];
  constructor() {
     this.hourList = [ {label:"صباحاً", hour: 8, code: 1},
     {label:"صباحاً", hour: 9, code: 2},
     {label:"صباحاً", hour: 10, code: 3},
     {label:"صباحاً", hour: 11, code: 4},

     {label:"مساءاً", hour: 4, code: 5},
     {label:"مساءاً", hour: 5, code: 6},
     {label:"مساءاً", hour: 6, code: 7},
     {label:"مساءاً", hour: 7, code: 8}
     ]
  }

  query(params?: any) {
    if (!params) {
      return this.hourList;
    }
  }
}
