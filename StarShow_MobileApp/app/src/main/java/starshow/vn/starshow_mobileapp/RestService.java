package starshow.vn.starshow_mobileapp;

import retrofit.RestAdapter;

public class RestService {
    private static final String URL = "http://10.82.138.2:777/api";
    private RestAdapter restAdapter;
    private ShowService showService;
    private LocationService locationService;
    private SlotService slotService;
    private UserService userService;
    private OrderService orderService;
    private TicketService ticketService;

    public RestService() {
        restAdapter = new retrofit.RestAdapter.Builder().setEndpoint(URL).setLogLevel(RestAdapter.LogLevel.FULL).build();
        showService = restAdapter.create(ShowService.class);
        locationService = restAdapter.create(LocationService.class);
        slotService = restAdapter.create(SlotService.class);
        userService = restAdapter.create(UserService.class);
        orderService = restAdapter.create(OrderService.class);
        ticketService = restAdapter.create(TicketService.class);
    }

    public ShowService getShowService() {
        return showService;
    }

    public LocationService getLocationService() {
        return locationService;
    }

    public SlotService getSlotService() {
        return slotService;
    }

    public UserService getUserService() {
        return userService;
    }

    public OrderService getOrderService() {
        return orderService;
    }

    public TicketService getTicketService() {
        return ticketService;
    }
}
