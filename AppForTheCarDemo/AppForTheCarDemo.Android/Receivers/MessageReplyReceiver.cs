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

namespace AppForTheCarDemo.Droid.Receivers
{
    [BroadcastReceiver]
    public class MessageReplyReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {

            Android.Util.Log.Info("Xamarin", "Android Auto Reply Receiver!");

        }
    }
}