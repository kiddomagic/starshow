package starshow.vn.starshow_mobileapp;

import android.content.Intent;
import android.provider.ContactsContract;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import com.squareup.picasso.Picasso;

import java.time.Instant;
import java.util.ArrayList;
import java.util.Date;
import java.util.List;

import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class DetailActivity extends AppCompatActivity {

    RestService restService;
    TextView txtName, txtPrice, txtDescription, txtLocation;
    EditText txtAmount;
    Spinner spnDate;
    ImageView imgView;
    String mEmail;

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
        final String email = intent.getStringExtra("email");
        mEmail = email;
        String image = intent.getStringExtra("image");
        txtAmount = (EditText) findViewById(R.id.txtAmount);
        txtDescription = (TextView) findViewById(R.id.txtDescription);
        txtLocation = (TextView) findViewById(R.id.txtLocation);
        txtName = (TextView) findViewById(R.id.txtName);
        txtPrice = (TextView) findViewById(R.id.txtPrice);
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
                    if (order.userId.equals(email)){
                        txtAmount.setText(order.ticketQuantity);
                    }
                }
            }

            @Override
            public void failure(RetrofitError retrofitError) {

            }
        });
        List<String> slotDate = new ArrayList<>();
        for (Slot slot: mSlots) {
            slotDate.add(slot.date.toString());
        }
        spnDate = (Spinner) findViewById(R.id.spnDate);
        ArrayAdapter<String> adapter = new ArrayAdapter<String>(DetailActivity.this, R.layout.support_simple_spinner_dropdown_item, slotDate);
        spnDate.setAdapter(adapter);
        txtName.setText(showName);
        txtPrice.setText(price);
        txtLocation.setText(location);
        txtDescription.setText(description);
        imgView = (ImageView) findViewById(R.id.imgView);
        Picasso.with(DetailActivity.this).load(image).into(imgView);
    }

    public void clickToSubmit(View view) {
        Order order = new Order();
        final List<Order> mOrders = new ArrayList<>();
        restService.getOrderService().GetOrders(new Callback<List<Order>>() {
            @Override
            public void success(List<Order> orders, Response response) {
                for (Order order: orders) {
                    mOrders.add(order);
                }
            }

            @Override
            public void failure(RetrofitError retrofitError) {

            }
        });
        order.userId = mEmail;
        order.buyAt = "MobileApp";
        order.id = "DH" + mOrders.size();
        order.buyTime = new Date();
        order.ticketQuantity = Integer.parseInt(txtAmount.getText().toString());
        order.totalMoney = Double.parseDouble(txtPrice.getText().toString()) * Integer.parseInt(txtAmount.getText().toString());
        restService.getOrderService().AddOrder(order, new Callback<Order>() {
            @Override
            public void success(Order order, Response response) {
                Toast.makeText(DetailActivity.this, "Đặt hàng thành công!", Toast.LENGTH_LONG);
            }

            @Override
            public void failure(RetrofitError retrofitError) {
                Toast.makeText(DetailActivity.this, retrofitError.getMessage().toString(), Toast.LENGTH_LONG);
            }
        });
    }
}
