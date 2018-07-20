package starshow.vn.starshow_mobileapp;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.DELETE;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.PUT;
import retrofit.http.Path;

public interface OrderService {
    @GET("/Orders")
    public void GetOrders(Callback<List<Order>> callback);

    @GET("/Orders/{id}")
    public void GetOrder(@Path("id") String id, Callback<Order> callback);

    @DELETE("/Orders/{id}")
    public void DeleteOrder (@Path("id") String id, Callback<Order> callback);

    @PUT("/Orders/{id}")
    public void UpdateOrder (@Path("id") String id, @Body Order order, Callback<Order> callback);

    @POST("/Orders")
    public void AddOrder (@Body Order order, Callback<Order> callback);
}
