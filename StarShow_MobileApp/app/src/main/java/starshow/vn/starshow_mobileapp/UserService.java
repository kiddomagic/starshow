package starshow.vn.starshow_mobileapp;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.DELETE;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.PUT;
import retrofit.http.Path;

public interface UserService {
    @GET("/Users")
    public void GetUsers(Callback<List<User>> callback);

    @GET("/Users/{id}")
    public User GetUser(@Path("id") String id, Callback<User> callback);

    @DELETE("/Users/{id}")
    public void DeleteUser (@Path("id") String id, Callback<User> callback);

    @PUT("/Users/{id}")
    public void UpdateUser (@Path("id") String id, @Body User user, Callback<User> callback);

    @POST("/Users")
    public void AddUser (@Body User user, Callback<User> callback);
}
