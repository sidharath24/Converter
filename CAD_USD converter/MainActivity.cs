using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace CAD_USD_converter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView vcad, vusd;
        EditText tcad, tusd;
        Button btnConv, btnClr;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            vcad = (TextView)FindViewById(Resource.Id.tvCAD);
            vusd = (TextView)FindViewById(Resource.Id.tvUSD);
            tcad = (EditText)FindViewById(Resource.Id.etCAD);
            tusd = (EditText)FindViewById(Resource.Id.etUSD);
            btnConv = (Button)FindViewById(Resource.Id.btnConvert);
            btnClr = (Button)FindViewById(Resource.Id.btnClear);
            btnConv.Click += delegate
            {
                if (tusd.Text != "")
                {
                    double ca, us;
                    us = double.Parse(tusd.Text); //get the amount of money in cad from user to convert ti user
                    ca = us * 1.33;
                    tcad.Text = ca.ToString();
                }

                else if (tcad.Text != "")
                {
                    double ca, us;
                    ca = double.Parse(tcad.Text); //get the amount of money in cad from user to convert ti user
                    us = ca / 1.33;
                    tusd.Text = us.ToString();
                }
                else                
                    Toast.MakeText(this, "Please enter amount to convert", ToastLength.Long).Show();               
            };

            btnClr.Click += delegate
            {
                tcad.Text = "";
                tusd.Text = "";
            };
           
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            View view = (View) sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }
	}
}

