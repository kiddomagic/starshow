package starshow.vn.starshow_mobileapp;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.DELETE;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.PUT;
import retrofit.http.Path;

public interface TicketService {
    @GET("/Tickets")
    public void GetTickets(Callback<List<Ticket>> callback);

    @GET("/Tickets/{id}")
    public void GetTicket(@Path("id") String id, Callback<Ticket> callback);

    @DELETE("/Tickets/{id}")
    public void DeleteTicket (@Path("id") String id, Callback<Ticket> callback);

    @PUT("/Tickets/{id}")
    public void UpdateTicket (@Path("id") String id, @Body Ticket ticket, Callback<Ticket> callback);

    @POST("/Tickets")
    public void AddTicket (@Body Ticket ticket, Callback<Ticket> callback);
}
