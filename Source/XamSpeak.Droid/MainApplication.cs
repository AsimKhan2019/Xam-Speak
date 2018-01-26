using System;

using Android.OS;
using Android.App;
using Android.Runtime;

using Plugin.CurrentActivity;

namespace XamSpeak.Droid
{
    [Application]
    public class MainApplication : Application, Application.IActivityLifecycleCallbacks
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }

        public override void OnCreate()
        {
            base.OnCreate();
            RegisterActivityLifecycleCallbacks(this);
        }

        public override void OnTerminate()
        {
            base.OnTerminate();
            UnregisterActivityLifecycleCallbacks(this);
        }

        public void OnActivityCreated(Activity activity, Bundle savedInstanceState) => CrossCurrentActivity.Current.Activity = activity;

        public void OnActivityDestroyed(Activity activity) { }

        public void OnActivityPaused(Activity activity) { }

        public void OnActivityResumed(Activity activity) => CrossCurrentActivity.Current.Activity = activity;

        public void OnActivitySaveInstanceState(Activity activity, Bundle outState) { }

        public void OnActivityStarted(Activity activity) => CrossCurrentActivity.Current.Activity = activity;

        public void OnActivityStopped(Activity activity) { }
    }
}