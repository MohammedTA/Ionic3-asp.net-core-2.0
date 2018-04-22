import { DateTime } from "ionic-angular";
import { AssetItem } from "./assetitem";

export class Furniture {
  constructor() {
    this.Items = [];
  }
}
export interface Furniture {
  Name: string;
  Mobile: string;
  Day: DateTime;
  Hour: string;
  Address: string;
  Lit: string;
  Long: string;
  Phone: string;
  Square: string;
  Email: string;
  Recorddate: DateTime;
  AssetType: Number;
  Assetdetails: string;
  Notes: string;
  Items: AssetItem[];
  DuCode: Number;
}
