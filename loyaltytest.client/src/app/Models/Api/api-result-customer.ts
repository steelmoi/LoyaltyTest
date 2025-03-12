import { Customer } from "../customer";
import { ApiResult } from "./api-result";

export class ApiResultCustomer extends ApiResult {
  data?: Customer
}
