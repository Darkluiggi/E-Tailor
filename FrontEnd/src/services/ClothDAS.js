import http from "../http-common";

class ClothDAS {
  getAll() {
    return http.get("/Cloth/GetList");
  }

  get(id) {
    return http.get(`/Cloth/Get/${id}`);
  }

  create(data) {
    return http.post("/Cloth/Create", data);
  }

  update(id, data) {
    return http.put(`/Cloth/${id}`, data);
  }

  delete(id) {
    return http.delete(`/Cloth/Delete/${id}`);
  }
  GetByName(RolName) {
    return http.get("/Cloth/GetByName", { params: { name: RolName },
  });
}



  
}

export default new ClothDAS();