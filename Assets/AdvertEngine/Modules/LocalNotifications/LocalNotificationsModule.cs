using Assets.SimpleAndroidNotifications;
using System;
using UnityEngine;

public class LocalNotificationsModule : MonoBehaviour
{
    public static LocalNotificationsModule instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void ScheduleNotification(float delay, string title, string msg)
    {
        NotificationManager.Send(TimeSpan.FromSeconds(delay), title, msg, Color.white);
    }

    public void ScheduleNotification(float delay, string title, string msg, Color color)
    {
        NotificationManager.Send(TimeSpan.FromSeconds(delay), title, msg, color);
    }

    public void ScheduleNotification(float delay, string title, string msg, NotificationIcon icon)
    {
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(delay), title, msg, Color.white, icon);
    }

    public void ScheduleNotification(float delay, string title, string msg, Color color, NotificationIcon icon)
    {
        NotificationManager.SendWithAppIcon(TimeSpan.FromSeconds(delay), title, msg, color, icon);
    }

    public void CancelAll()
    {
        NotificationManager.CancelAll();
    }

    //-------------------------------Testing Function------------------------------------------------//
    public void ShowSimplistNotification()
    {
        ScheduleNotification(2, "Simplist title", "Simplist msg");
    }
    public void ShowSimpleNotificationWithColor()
    {
        ScheduleNotification(5, "Simple with color", "Simple with color notification msg", Color.red);
    }
    public void ShowSimpleNotificationWithIcon()
    {
        ScheduleNotification(10, "Simple with icon", "Simple with icon notification msg", NotificationIcon.Bell);
    }
    public void ShowSimpleNotificationWithIconAndColor()
    {
        ScheduleNotification(15, "Simple with icon and Color", "Simple with icon and color notification msg", Color.blue, NotificationIcon.Heart);
    }
    //-------------------------------Testing Function------------------------------------------------//
}
