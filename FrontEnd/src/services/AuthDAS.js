import http from "../http-common";

class AuthDAS {
  login(data) {
    return http.post("/Auth/Login", data);
  }

  register(data) {
    return http.post("/Auth/Create", data);
  }

  
  
}

export default new AuthDAS();