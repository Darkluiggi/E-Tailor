import http from "../http-common";

class ScheduleDAS {
  getAll() {
    return http.get("/Schedule/GetTailorList");
  }
}

  export default new ScheduleDAS();