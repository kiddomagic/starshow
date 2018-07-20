package starshow.vn.starshow_mobileapp;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.DELETE;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.PUT;
import retrofit.http.Path;

public interface LocationService {
    @GET("/Locations")
    public void GetLocations(Callback<List<Location>> callback);

    @GET("/Locations/{id}")
    public void GetLocation(@Path("id") String id, Callback<Location> callback);

    @DELETE("/Locations/{id}")
    public void DeleteLocation (@Path("id") String id, Callback<Location> callback);

    @PUT("/Locations/{id}")
    public void UpdateLocation (@Path("id") String id, @Body Location location, Callback<Location> callback);

    @POST("/Locations")
    public void AddLocation (@Body Location location, Callback<Location> callback);
}
