package starshow.vn.starshow_mobileapp;

import android.support.annotation.Nullable;

import java.util.Date;

public class Order {
    public String id ;
    public String userId ;
    @Nullable
    public int ticketQuantity ;
    @Nullable
    public Date buyTime ;
    public String buyAt ;
    @Nullable
    public double totalMoney ;
}
