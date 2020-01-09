using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;

namespace ClassApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    
    public class MainActivity : AppCompatActivity
    {
        private TextView _textfinalInvTxt;
        private Button _buttoncalcBtn;
        private EditText _editTextyearInvTxt;
        private EditText _editTexttimesCompTxt;
        private EditText _editTextinterestTxt;
        private EditText _editTextprincipleInvTxt;

        private double PricipleInvestment;
        private double InterestRate;
        private double CompoundPerYear;
        private double YearsInvested;
        private double FinalInvestment;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);



            _editTextprincipleInvTxt = FindViewById<EditText>(Resource.Id.principleInvTxt);
            _editTextinterestTxt = FindViewById<EditText>(Resource.Id.interestTxt);
            _editTexttimesCompTxt = FindViewById<EditText>(Resource.Id.timesCompTxt);
            _editTextyearInvTxt = FindViewById<EditText>(Resource.Id.yearInvTxt);
            _buttoncalcBtn = FindViewById<Button>(Resource.Id.calcBtn);
            _textfinalInvTxt = FindViewById<TextView>(Resource.Id.finalInvTxt);

            _buttoncalcBtn.Click += _buttoncalcBtn_Click;
        }

        private void _buttoncalcBtn_Click(object sender, EventArgs e)
        {
            
            
            PricipleInvestment = double.Parse(_editTextprincipleInvTxt.Text);
            InterestRate = double.Parse(_editTextinterestTxt.Text);
            CompoundPerYear = double.Parse(_editTexttimesCompTxt.Text);
            YearsInvested = double.Parse(_editTextyearInvTxt.Text);

            CalculateFinalInvestment();
        }

        void CalculateFinalInvestment()
        {
            InterestRate = InterestRate / 100;
            FinalInvestment = PricipleInvestment * Math.Pow((1 + (InterestRate * CompoundPerYear)), (CompoundPerYear * YearsInvested));
            Printfunction();
        }

        void Printfunction()
        {
            _textfinalInvTxt.Text = _textfinalInvTxt.Text + " " + FinalInvestment.ToString();
        }
    }
}