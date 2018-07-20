package starshow.vn.starshow_mobileapp;

import android.content.Intent;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ListView;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    RestService restService;
    ListView mListView;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        restService = new RestService();
        mListView = (ListView) findViewById(R.id.listView);
        final List<Show> listShow = new ArrayList<>();
        mListView.setAdapter(new ShowAdapter(this, listShow));
        mListView.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> adapterView, View view, int i, long l) {
                Show show = (Show) mListView.getItemAtPosition(i);
                Intent intent = new Intent( MainActivity.this, DetailActivity.class);
                intent.putExtra("name", show.title);
                intent.putExtra("description", show.description);
                intent.putExtra("id", show.id);
                startActivity(intent);
            }
        });
    }
}
