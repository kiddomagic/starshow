package starshow.vn.starshow_mobileapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class MainActivity extends AppCompatActivity {

    RestService restService;
    ListView mListView;
    Slot _slot;
    Location _location;
    Ticket _ticket;
    boolean stop;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        restService = new RestService();

        final List<Show> listShow = new ArrayList<>();
        restService.getShowService().GetShows(new Callback<List<Show>>() {
            @Override
            public void success(List<Show> shows, Response response) {
                mListView = (ListView) findViewById(R.id.listView);
                for (final Show show: shows) {
                    stop = false;
                    restService.getSlotService().GetSlots(new Callback<List<Slot>>() {
                        @Override
                        public void success(List<Slot> slots, Response response) {
                            for (Slot slot: slots) {
                                if (slot.showId.equals(show.id)) {
                                    _slot = slot;
                                    break;
                                }
                            }
                        }

                        @Override
                        public void failure(RetrofitError retrofitError) {

                        }
                    });
                    restService.getLocationService().GetLocations(new Callback<List<Location>>() {
                        @Override
                        public void success(List<Location> locations, Response response) {
                            for (Location location: locations) {
                                if (location.id.equals(_slot.locationId)) {
                                    _location = location;
                                    break;
                                }
                            }
                        }

                        @Override
                        public void failure(RetrofitError retrofitError) {

                        }
                    });
                    restService.getTicketService().GetTickets(new Callback<List<Ticket>>() {
                        @Override
                        public void success(List<Ticket> tickets, Response response) {
                            for (Ticket ticket: tickets) {
                                if (ticket.slotId.equals(_slot.id)){
                                    _ticket = ticket;
                                    stop = true;
                                    break;
                                }
                            }
                        }

                        @Override
                        public void failure(RetrofitError retrofitError) {

                        }
                    });
                    if (stop) {
                        break;
                    }
                }
                Intent loginIntent = getIntent();
                final String email = loginIntent.getStringExtra("email");
                final ShowAdapter adapter = new ShowAdapter(MainActivity.this, R.layout.list_show_items, shows, _location, _ticket);
                mListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
                    @Override
                    public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                        Show show = (Show) mListView.getItemAtPosition(i);
                        Intent intent = new Intent( MainActivity.this, DetailActivity.class);
                        intent.putExtra("name", show.title);
                        intent.putExtra("description", show.description);
                        intent.putExtra("id", show.id);
                        intent.putExtra( "price", _ticket.price);
                        intent.putExtra( "location", _location.name+" - "+_location.address);
                        intent.putExtra("email", email);
                        intent.putExtra( "image", show.image);
                        startActivity(intent);
                    }
                });
                mListView.setAdapter(adapter);
            }

            @Override
            public void failure(RetrofitError retrofitError) {

            }
        });

    }
}
