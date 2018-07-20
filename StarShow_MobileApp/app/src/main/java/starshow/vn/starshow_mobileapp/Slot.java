package starshow.vn.starshow_mobileapp;

import android.support.annotation.Nullable;

import java.sql.Time;
import java.util.Date;

public class Slot {
    public String id;
    @Nullable
    public Date date;
    @Nullable
    public Time startTime;
    @Nullable
    public Time endTime;
    public String locationId;
    public String showId;
    public String guest;
}
