import http from "../http-common";

class TaskDAS {
  getAll() {
    return http.get("/Task/GetList");
  }

  get(id) {
    return http.get(`/Task/Get/${id}`);
  }

  create(data) {
    return http.post("/Task/Create", data);
  }

  update(id, data) {
    return http.put(`/Task/${id}`, data);
  }

  delete(id) {
    return http.delete(`/Task/Delete/${id}`);
  }
  GetByName(RolName) {
    return http.get("/Task/GetByName", { params: { name: RolName },
  });
}


  
}

export default new TaskDAS();