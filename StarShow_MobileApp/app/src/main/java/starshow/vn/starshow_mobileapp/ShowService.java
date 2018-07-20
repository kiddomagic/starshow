package starshow.vn.starshow_mobileapp;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.DELETE;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.PUT;
import retrofit.http.Path;

public interface ShowService {
    @GET("/Shows")
    public void GetShows(Callback<List<Show>> callback);

    @GET("/Shows/{id}")
    public void GetShow(@Path("id") String id, Callback<Show> callback);

    @DELETE("/Shows/{id}")
    public void DeleteShow (@Path("id") String id, Callback<Show> callback);

    @PUT("/Shows/{id}")
    public void UpdateShow (@Path("id") String id, @Body Show show, Callback<Show> callback);

    @POST("/Shows")
    public void AddShow (@Body Show show, Callback<Show> callback);
}