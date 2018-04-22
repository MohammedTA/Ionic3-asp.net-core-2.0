import { Injectable } from '@angular/core';
import { Api } from '../api/api';

@Injectable()
export class Hours {

  constructor(public api: Api) { }

  query(params?: any) {
    return this.api.get('/hours', params);
  }
}
