using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;

namespace AppForTheCarDemo.Droid.Receivers
{
    [BroadcastReceiver]
    public class MessageReadReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            Android.Util.Log.Info("Xamarin", "Android Auto Read Receiver!");

            int conversationId = intent.GetIntExtra("conversation_id", -1);

            if (conversationId != -1)
            {
                NotificationManagerCompat.From(context).Cancel(conversationId);
            }
        }
    }
}