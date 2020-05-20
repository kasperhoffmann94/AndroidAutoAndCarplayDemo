using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using AppForTheCarDemo.Droid.Receivers;
using Java.Lang;

namespace AppForTheCarDemo.Droid.Notifications
{
    public static class Notification
    {
        private static Intent GetMessageReadIntent(int id)
        {
            return new Intent().SetAction(Class.FromType(typeof(MessageReadReceiver)).Name)
                    .PutExtra("conversation_id", id);
        }

        // Creates an Intent that will be triggered when a voice reply is received.
        private static Intent GetMessageReplyIntent(int conversationId)
        {
            return new Intent().SetAction(Class.FromType(typeof(MessageReplyReceiver)).Name)
                    .PutExtra("conversation_id", conversationId);
        }

        public static void ShowNotification(Context context)
        {
            Android.Util.Log.Info("Xamarin", "Sending Notifiation to android auto");

            PendingIntent readPendingIntent = PendingIntent.GetBroadcast(context,
                123, GetMessageReadIntent(123), PendingIntentFlags.UpdateCurrent);

            Android.Support.V4.App.RemoteInput remoteInput = new Android.Support.V4.App.RemoteInput.Builder("extra voice reply")
                .SetLabel("Car Notification")
                .Build();

            PendingIntent replyPendingIntent = PendingIntent.GetBroadcast(context,
                123, GetMessageReplyIntent(123), PendingIntentFlags.UpdateCurrent);

            NotificationCompat.CarExtender.UnreadConversation.Builder unreadConversationBuilder = new NotificationCompat.CarExtender.UnreadConversation.Builder("Hello android Auto")
                .SetLatestTimestamp(JavaSystem.CurrentTimeMillis())
                .SetReadPendingIntent(readPendingIntent)
                .SetReplyAction(replyPendingIntent, remoteInput);

            unreadConversationBuilder.AddMessage("This is the body for android auto");

            var builder = new NotificationCompat.Builder(context, "MyChannel")
                .SetAutoCancel(true)
                .SetContentTitle("Hello Android Auto")
                .SetSmallIcon(Resource.Drawable.abc_ic_menu_share_mtrl_alpha)
                .SetContentText($"this is the body")
                .Extend(new NotificationCompat.CarExtender()
                        .SetUnreadConversation(unreadConversationBuilder.Build()));


            var notificationManager = NotificationManagerCompat.From(context);
            notificationManager.Notify(123456, builder.Build());
        }
    }
}