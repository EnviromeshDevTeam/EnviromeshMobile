using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Animation;
using Com.Airbnb.Lottie;

namespace GreenHouse.Droid
{
    /// <summary>
    /// GreenHouse Splash Page
    /// </summary>
    [Activity(Theme = "@style/Theme.Splash",
        MainLauncher =true,
        NoHistory =true)]
    public class SplashActivity : Activity, Animator.IAnimatorListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Activity_Splash);

            var animationView = FindViewById<LottieAnimationView>(Resource.Id.animationView);
            animationView.AddAnimatorListener(this);

            // Create your application here
        }

        public void OnAnimationCancel(Animator animtion)
        {

        }

        public void OnAnimationEnd(Animator animation)
        {
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
        }

        public void OnAnimationRepeat( Animator animation)
        {
            
        }

        public void OnAnimationStart(Animator animation)
        {
           
        }
    }
}