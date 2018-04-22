import { DateTime } from "ionic-angular";


export class Food {

  constructor() {
  }

}

export interface Food {
  Square: string,
  Name: string,
  Mobile: string,
  Phone: string,
  Email: string,
  Asset: string,
  Number: Number,
  Day: DateTime,
  Hour: Number,
  Recoreddate: DateTime,
  Hallname: string,
  Address: string,
  Lat: string,
  Long: string,
  Stat: Number,
  Notes: string,
  Driver: Number,
  Approveddate:DateTime,
  Canceldate:DateTime,
  Code: Number
}
