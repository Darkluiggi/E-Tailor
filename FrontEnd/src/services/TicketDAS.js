import http from "../http-common";

class TicketDAS {
  GetTicketsByTailor(id) {
    return http.get(`/Ticket/GetList/${id}`);
  }
  GetTicketsByCustomer(id) {
    return http.get(`/Ticket/GetTicketsByCustomer/${id}`);
  }
  create(data) {
    return http.post("/Ticket/Create", data);
  }
  closeAppointment(id){
    return http.get(`/Ticket/CloseAppointment/${id}`)
  }
  
}

export default new TicketDAS();