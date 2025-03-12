import { Product } from "../product";
import { ApiResult } from "./api-result";

export class ApiResultProduct extends ApiResult {
  data? = Product
}
