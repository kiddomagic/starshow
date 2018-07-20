package starshow.vn.starshow_mobileapp;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.Spinner;
import android.widget.TextView;

import java.util.List;

import retrofit.Callback;
import retrofit.RetrofitError;
import retrofit.client.Response;

public class ShowAdapter extends BaseAdapter {
    private List<Show> listData;
    private LayoutInflater layoutInflater;
    private Context context;

    public ShowAdapter(Context context, List<Show> listData) {
        this.context = context;
        this.listData = listData;
        layoutInflater = LayoutInflater.from(context);
    }

    @Override
    public int getCount() {
        return listData.size();
    }

    @Override
    public Object getItem(int i) {
        return listData.get(i);
    }

    @Override
    public long getItemId(int i) {
        return i;
    }

    @Override
    public View getView(int i, View view, ViewGroup viewGroup) {
        ViewHolder viewHolder;
        if (view == null) {
            view = layoutInflater.inflate(R.layout.list_show_items, null);
            viewHolder = new ViewHolder();
            viewHolder.txtName = (TextView) view.findViewById(R.id.txtName);
            viewHolder.txtDescription = (TextView) view.findViewById(R.id.txtDescription);
            viewHolder.txtLocation = (TextView) view.findViewById(R.id.txtLocation);
            viewHolder.txtPrice = (TextView) view.findViewById(R.id.txtPrice);
            view.setTag(viewHolder);
        } else {
            viewHolder = (ViewHolder) view.getTag();
        }
        Show show = this.listData.get(i);
        RestService restService = new RestService();
        SlotService slotService = restService.getSlotService();
        Callback<List<Slot>> callback = null;
        slotService.GetSlots( callback );
        List<Slot> slots = null;
        callback.success( slots, null);
        viewHolder.txtName.setText(show.title);
        String locationId = "";
        Ticket ticket;
        TicketService ticketService = restService.getTicketService();
        Callback<List<Ticket>> callBackTicket = null;
        ticketService.GetTickets(callBackTicket);
        List<Ticket> tickets = null;
        callBackTicket.success(tickets, null);
        for (Slot slot: slots) {
            if (slot.showId.equals(show.id)){
                locationId = slot.locationId;
                for (Ticket _ticket: tickets) {
                    if (_ticket.slotId.equals(slot.id)) {
                        viewHolder.txtPrice.setText("" + _ticket.price);
                    }
                    break;
                }
                break;
            }
        }
        List<Location> locations = null;
        LocationService service = restService.getLocationService();
        Callback<List<Location>> callbackl = null;
        service.GetLocations(callbackl);
        callbackl.success(locations, null);
        for (Location location: locations) {
            if (location.id.equals(locationId)) {
                viewHolder.txtLocation.setText(location.name + " - " + location.address);
                break;
            }
        }
        viewHolder.txtDescription.setText(show.description);
        return view;
    }

    static class ViewHolder {
        TextView txtName, txtLocation, txtDescription, txtPrice;
    }
}
