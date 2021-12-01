import http from "../http-common";

class UserDAS {
  getAll() {
    return http.get("/Rols/GetList");
  }

  get(id) {
    return http.get(`/Rols/Get/${id}`);
  }

  create(data) {
    return http.post("/Rols/Create", data);
  }

  update(id, data) {
    return http.put(`/Rols/${id}`, data);
  }

  delete(id) {
    return http.delete(`/Rols/Delete/${id}`);
  }
  GetByName(RolName) {
    return http.get("/Rols/GetByName", { params: { name: RolName },
  });
}

  findByName(data){
    return http.post(`/Rols/GetByName/${data}`);
  }


  
}

export default new UserDAS();