import http from "../http-common";

class ScheduleDAS {
  getAll() {
    return http.get("/Schedule/GetTailorList");
  }
  getAppointmentsByCustomer(id){
    return http.get(`/Schedule/GetAppointmentsByCustomer/${id}`)
  }
  saveAppointment(id, data) {
    return http.post(`/Schedule/CreateAppointment/${id}`, data);
  }
  getTailorAvailability(data){
    return http.post("/Schedule/GetTailorAvailability", data);
  }
}

  export default new ScheduleDAS();