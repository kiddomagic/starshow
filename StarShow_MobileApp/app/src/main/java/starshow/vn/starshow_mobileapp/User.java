package starshow.vn.starshow_mobileapp;

import android.support.annotation.Nullable;

import java.util.Date;

public class User {
    public String id; 
    public String name; 
    @Nullable
    public int gender;
    @Nullable
    public Date birthday;
    public String email; 
    public String phone; 
    public String type;
    @Nullable
    public boolean enable; 
    public String password; 
}
