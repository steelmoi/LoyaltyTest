import { ProductStore } from "../product-store";
import { ApiResult } from "./api-result";

export class ApiResultProductStore extends ApiResult{
  data?: ProductStore
}
