import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

/**
 * Api is a generic REST Api handler. Set your API url first.
 */
@Injectable()
export class Api {


  production: boolean = true;
  server: string = this.production ? "http://daralkhair-001-site1.mysitepanel.net/api" : "http://localhost:51302/api";
  // server: string = this.production ? "/online/api" : "/local/api";

  url: string = this.server;

  constructor(public http: HttpClient) {
  }

  get(endpoint: string, params?: any, reqOpts?: any) {
    //return this.http.get(this.url + '/' + endpoint, reqOpts);
    return this.http.get(this.url + '/' + endpoint, {
      headers: {
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*'
      }
    });
  }

  post(endpoint: string, body: any, reqOpts?: any) {
    
    return this.http.post(this.url + '/' + endpoint, body, {
      headers: {
        'Content-Type': 'application/json; charset=utf-8',
        'Access-Control-Allow-Origin': '*'
      }
    });
  }

  put(endpoint: string, body: any, reqOpts?: any) {
    return this.http.put(this.url + '/' + endpoint, body, reqOpts);
  }

  delete(endpoint: string, reqOpts?: any) {
    return this.http.delete(this.url + '/' + endpoint, reqOpts);
  }

  patch(endpoint: string, body: any, reqOpts?: any) {
    return this.http.put(this.url + '/' + endpoint, body, reqOpts);
  }
}
