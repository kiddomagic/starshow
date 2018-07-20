package starshow.vn.starshow_mobileapp;

import java.util.List;

import retrofit.Callback;
import retrofit.http.Body;
import retrofit.http.DELETE;
import retrofit.http.GET;
import retrofit.http.POST;
import retrofit.http.PUT;
import retrofit.http.Path;

public interface SlotService {
    @GET("/Slots")
    public void GetSlots(Callback<List<Slot>> callback);

    @GET("/Slots/{id}")
    public void GetSlot(@Path("id") String id, Callback<Slot> callback);

    @DELETE("/Slots/{id}")
    public void DeleteSlot (@Path("id") String id, Callback<Slot> callback);

    @PUT("/Slots/{id}")
    public void UpdateSlot (@Path("id") String id, @Body Slot slot, Callback<Slot> callback);

    @POST("/Slots")
    public void AddSlot (@Body Slot slot, Callback<Slot> callback);
}
