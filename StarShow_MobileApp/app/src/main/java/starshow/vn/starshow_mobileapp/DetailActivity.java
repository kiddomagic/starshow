package starshow.vn.starshow_mobileapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;

import java.util.ArrayList;
import java.util.List;

import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class DetailActivity extends AppCompatActivity {

    RestService restService;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_detail);
        restService = new RestService();
        final List<Slot> mSlots = new ArrayList<>();
        Intent intent = getIntent();
        final String showId = intent.getStringExtra("id");
        String showName = intent.getStringExtra("name");
        String location = intent.getStringExtra("location");
        String price = "" + intent.getDoubleExtra("price", 0);
        String description = intent.getStringExtra("description");
        restService.getSlotService().GetSlots(new Callback<List<Slot>>() {
            @Override
            public void success(List<Slot> slots, Response response) {
                for (Slot slot: slots) {
                    if (slot.showId.equals(showId)){
                        mSlots.add(slot);
                    }
                }
            }

            @Override
            public void failure(RetrofitError retrofitError) {

            }
        });
        restService.getOrderService().GetOrders(new Callback<List<Order>>() {
            @Override
            public void success(List<Order> orders, Response response) {
                for (Order order: orders) {

                }
            }

            @Override
            public void failure(RetrofitError retrofitError) {

            }
        });
    }
}
