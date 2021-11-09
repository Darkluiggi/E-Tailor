import http from "../http-common";

class UserDAS {
  getAll() {
    return http.get("/User/GetList");
  }

  get(id) {
    return http.get(`/User/Get/${id}`);
  }

  create(data) {
    return http.post("/User/Create", data);
  }

  update(id, data) {
    return http.put(`/Edit/${id}`, data);
  }

  delete(id) {
    return http.delete(`/User/Delete/${id}`);
  }

  
}

export default new UserDAS();