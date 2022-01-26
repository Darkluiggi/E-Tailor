import http from "../http-common";

class ScheduleDAS {
  getAll() {
    return http.get("/Schedule/GetTailorList");
  }
  getAppointmentsByCustomer(id){
    return http.get(`/Schedule/GetAppointmentsByCustomer/${id}`)
  }
  getAppointmentsByTailor(id){
    return http.get(`/Schedule/GetAppointmentsByTailor/${id}`)
  }
  saveAppointment(id, data) {
    return http.post(`/Schedule/CreateAppointment/${id}`, data);
  }
  getTailorAvailability(data){
    return http.post("/Schedule/GetTailorAvailability", data);
  }
  getAppointmentById(id){
    return http.get(`/Schedule/GetAppointmentById/${id}`)
  }
  delete(id){
    return http.delete(`/Schedule/Delete/${id}`);
  }
  Deliverticket(id){
    return http.post(`/Schedule/Deliverticket/${id}`);
  }
}

  export default new ScheduleDAS();