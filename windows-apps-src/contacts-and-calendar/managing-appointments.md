---
xxxxxxxxxxx: Xxxxxxx xxx Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxxx xxxxxxxxx, xxx xxx xxxxxx xxx xxxxxx xxxxxxxxxxxx xx x xxxx'x xxxxxxxx xxx.
xxxxx: Xxxxxx xxxxxxxxxxxx
xx.xxxxxxx: YYYXYYYY-YYXY-YYYY-XYYX-YXXYYYXYXYYY
---

# Xxxxxx xxxxxxxxxxxx

\[ Xxxxxxx xxx XXX xxxx xx Xxxxxxx YY. Xxx Xxxxxxx Y.x xxxxxxxx, xxx xxx [xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619132) \]


Xxxxxxx xxx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn263359) xxxxxxxxx, xxx xxx xxxxxx xxx xxxxxx xxxxxxxxxxxx xx x xxxx'x xxxxxxxx xxx. Xxxx, xx'xx xxxx xxx xxx xx xxxxxx xx xxxxxxxxxxx, xxx xx xx x xxxxxxxx xxx, xxxxxxx xx xx xxx xxxxxxxx xxx, xxx xxxxxx xx xxxx xxx xxxxxxxx xxx. Xx'xx xxxx xxxx xxx xx xxxxxxx x xxxx xxxx xxx x xxxxxxxx xxx xxx xxxxxx xx xxxxxxxxxxx-xxxxxxxxxx xxxxxx.

## Xxxxxx xx xxxxxxxxxxx xxx xxxxx xxxx xx xx

Xxxxxx x [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221) xxxxxx xxx xxxxxx xx xx x xxxxxxxx. Xxxx, xxxxx xx xxx **Xxxxxxxxxxx** xxx xxxxxxxxxxx xxxxxxxxxx xxxx xxxx xxxxxxxx xxxxxxx xxx XX xx x xxxx.

```cs
private void Create-Click(object sender, RoutedEventArgs e)
{
    bool isAppointmentValid = true;
    var appointment = new Windows.ApplicationModel.Appointments.Appointment();

    // StartTime
    var date = StartTimeDatePicker.Date;
    var time = StartTimeTimePicker.Time;
    var timeZoneOffset = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now);
    var startTime = new DateTimeOffset(date.Year, date.Month, date.Day, time.Hours, time.Minutes, 0, timeZoneOffset);
    appointment.StartTime = startTime;

    // Subject
    appointment.Subject = SubjectTextBox.Text;

    if (appointment.Subject.Length &gt; 255)
    {
        isAppointmentValid = false;
        ResultTextBlock.Text = &quot;The subject cannot be greater than 255 characters.&quot;;
    }

    // Location
    appointment.Location = LocationTextBox.Text;

    if (appointment.Location.Length &gt; 32768)
    {
        isAppointmentValid = false;
        ResultTextBlock.Text = &quot;The location cannot be greater than 32,768 characters.&quot;;
    }

    // Details
    appointment.Details = DetailsTextBox.Text;

    if (appointment.Details.Length &gt; 1073741823)
    {
        isAppointmentValid = false;
        ResultTextBlock.Text = &quot;The details cannot be greater than 1,073,741,823 characters.&quot;;
    }

    // Duration
    if (DurationComboBox.SelectedIndex == 0)
    {
        // 30 minute duration is selected
        appointment.Duration = TimeSpan.FromMinutes(30);
    }
    else
    {
        // 1 hour duration is selected
        appointment.Duration = TimeSpan.FromHours(1);
    }

    // All Day
    appointment.AllDay = AllDayCheckBox.IsChecked.Value;

    // Reminder
    if (ReminderCheckBox.IsChecked.Value)
    {
        switch (ReminderComboBox.SelectedIndex)
        {
            case 0:
                appointment.Reminder = TimeSpan.FromMinutes(15);
                break;
            case 1:
                appointment.Reminder = TimeSpan.FromHours(1);
                break;
            case 2:
                appointment.Reminder = TimeSpan.FromDays(1);
                break;
        }
    }

    //Busy Status
    switch (BusyStatusComboBox.SelectedIndex)
    {
        case 0:
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.Busy;
            break;
        case 1:
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.Tentative;
            break;
        case 2:
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.Free;
            break;
        case 3:
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.OutOfOffice;
            break;
        case 4:
            appointment.BusyStatus = Windows.ApplicationModel.Appointments.AppointmentBusyStatus.WorkingElsewhere;
            break;
    }

    // Sensitivity
    switch (SensitivityComboBox.SelectedIndex)
    {
        case 0:
            appointment.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Public;
            break;
        case 1:
            appointment.Sensitivity = Windows.ApplicationModel.Appointments.AppointmentSensitivity.Private;
            break;
    }

    // Uri
    if (UriTextBox.Text.Length &gt; 0)
    {
        try
        {
            appointment.Uri = new System.Uri(UriTextBox.Text);
        }
        catch (Exception)
        {
            isAppointmentValid = false;
            ResultTextBlock.Text = &quot;The Uri provided is invalid.&quot;;
        }
    }

    // Organizer
    // Note: Organizer can only be set if there are no invitees added to this appointment.
    if (OrganizerRadioButton.IsChecked.Value)
    {
        var organizer = new Windows.ApplicationModel.Appointments.AppointmentOrganizer();

        // Organizer Display Name
        organizer.DisplayName = OrganizerDisplayNameTextBox.Text;

        if (organizer.DisplayName.Length &gt; 256)
        {
            isAppointmentValid = false;
            ResultTextBlock.Text = &quot;The organizer display name cannot be greater than 256 characters.&quot;;
        }
        else
        {
            // Organizer Address (e.g. Email Address)
            organizer.Address = OrganizerAddressTextBox.Text;

            if (organizer.Address.Length &gt; 321)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = &quot;The organizer address cannot be greater than 321 characters.&quot;;
            }
            else if (organizer.Address.Length == 0)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = &quot;The organizer address must be greater than 0 characters.&quot;;
            }
            else
            {
                appointment.Organizer = organizer;
            }
        }
    }

    // Invitees
    // Note: If the size of the Invitees list is not zero, then an Organizer cannot be set.
    if (InviteeRadioButton.IsChecked.Value)
    {
        var invitee = new Windows.ApplicationModel.Appointments.AppointmentInvitee();

        // Invitee Display Name
        invitee.DisplayName = InviteeDisplayNameTextBox.Text;

        if (invitee.DisplayName.Length &gt; 256)
        {
            isAppointmentValid = false;
            ResultTextBlock.Text = &quot;The invitee display name cannot be greater than 256 characters.&quot;;
        }
        else
        {
            // Invitee Address (e.g. Email Address)
            invitee.Address = InviteeAddressTextBox.Text;

            if (invitee.Address.Length &gt; 321)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = &quot;The invitee address cannot be greater than 321 characters.&quot;;
            }
            else if (invitee.Address.Length == 0)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = &quot;The invitee address must be greater than 0 characters.&quot;;
            }
            else
            {
                // Invitee Role
                switch (RoleComboBox.SelectedIndex)
                {
                    case 0:
                        invitee.Role = Windows.ApplicationModel.Appointments.AppointmentParticipantRole.RequiredAttendee;
                        break;
                    case 1:
                        invitee.Role = Windows.ApplicationModel.Appointments.AppointmentParticipantRole.OptionalAttendee;
                        break;
                    case 2:
                        invitee.Role = Windows.ApplicationModel.Appointments.AppointmentParticipantRole.Resource;
                        break;
                }

                // Invitee Response
                switch (ResponseComboBox.SelectedIndex)
                {
                    case 0:
                        invitee.Response = Windows.ApplicationModel.Appointments.AppointmentParticipantResponse.None;
                        break;
                    case 1:
                        invitee.Response = Windows.ApplicationModel.Appointments.AppointmentParticipantResponse.Tentative;
                        break;
                    case 2:
                        invitee.Response = Windows.ApplicationModel.Appointments.AppointmentParticipantResponse.Accepted;
                        break;
                    case 3:
                        invitee.Response = Windows.ApplicationModel.Appointments.AppointmentParticipantResponse.Declined;
                        break;
                    case 4:
                        invitee.Response = Windows.ApplicationModel.Appointments.AppointmentParticipantResponse.Unknown;
                        break;
                }

                appointment.Invitees.Add(invitee);
            }
        }
    }

    if (isAppointmentValid)
    {
        ResultTextBlock.Text = &quot;The appointment was created successfully and is valid.&quot;;
    }
}
```

## Xxx xx xxxxxxxxxxx xx xxx xxxx'x xxxxxxxx

Xxxxxx x [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221) xxxxxx xxx xxxxxx xx xx x xxxxxxxx. Xxxx, xxxx xxx [**XxxxxxxxxxxXxxxxxx.XxxxXxxXxxxxxxxxxxXxxxx(Xxxxxxxxxxx, Xxxx, Xxxxxxxxx)**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showaddappointmentasync-253292089) xxxxxx xx xxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxxx xxx-xxxxxxxxxxx XX, xx xxxxxx xxx xxxx xx xxx xx xxxxxxxxxxx. Xx xxx xxxx xxxxxxx **Xxx**, xxx xxxxxx xxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxx **XxxxXxxXxxxxxxxxxxXxxxx** xxxxxxxx.

```cs
private async void Add-Click(object sender, RoutedEventArgs e)
{
    // Create an Appointment that should be added the user's appointments provider app.
    var appointment = new Windows.ApplicationModel.Appointments.Appointment();

    // Get the selection rect of the button pressed to add this appointment
    var rect = GetElementRect(sender as FrameworkElement);

    // ShowAddAppointmentAsync returns an appointment id if the appointment given was added to the user's calendar.
    // This value should be stored in app data and roamed so that the appointment can be replaced or removed in the future.
    // An empty string return value indicates that the user canceled the operation before the appointment was added.
    String appointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAddAppointmentAsync(
                           appointment, rect, Windows.UI.Popups.Placement.Default);
    if (appointmentId != String.Empty)
    {
        ResultTextBlock.Text = "Appointment Id: " + appointmentId;
    }
    else
    {
        ResultTextBlock.Text = "Appointment not added.";
    }
}
```

**Xxxx**  Xxx Xxxxxxx Xxxxx Xxxxx xxxx, [**XxxxXxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showaddappointmentasync) xxxxxxxxx xxxx xxxx [**XxxxXxxxXxxXxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showeditnewappointmentasync) xx xxxx xxx xxxxxx xxxxxxxxx xxx xxxxxx xxx xxxxxxxxxxx xx xxxxxxxx.

## Xxxxxxx xx xxxxxxxxxxx xx xxx xxxx'x xxxxxxxx

Xxxxxx x [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxxx.Xxxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221) xxxxxx xxx xxxxxx xx xx x xxxxxxxx. Xxxx, xxxx xxx xxxxxxxxxxx [**XxxxxxxxxxxXxxxxxx.XxxxXxxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showreplaceappointmentasync) xxxxxx xx xxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxxx xxxxxxx-xxxxxxxxxxx XX xx xxxxxx xxx xxxx xx xxxxxxx xx xxxxxxxxxxx. Xxx xxxx xxxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxx xxxx xxxx xx xxxxxxx. Xxxx xxxxxxxxxx xxx xxxxxxxx xxxx [**XxxxxxxxxxxXxxxxxx.XxxxXxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showaddappointmentasync). Xx xxx xxxx xxxxxxx **Xxxxxxx**, xxx xxxxxx xxxxxx xxxx xx xxxxxxx xxxx xxxxxxxxxxx xxxxxxxxxx.

```cs
private async void Replace-Click(object sender, RoutedEventArgs e)
{
    // The appointment id argument for ReplaceAppointmentAsync is typically retrieved from AddAppointmentAsync and stored in app data.
    String appointmentIdOfAppointmentToReplace = AppointmentIdTextBox.Text;

    if (String.IsNullOrEmpty(appointmentIdOfAppointmentToReplace))
    {
        ResultTextBlock.Text = &quot;The appointment id cannot be empty&quot;;
    }
    else
    {
        // The Appointment argument for ReplaceAppointmentAsync should contain all of the Appointment' s properties including those that may have changed.
        var appointment = new Windows.ApplicationModel.Appointments.Appointment();

        // Get the selection rect of the button pressed to replace this appointment
        var rect = GetElementRect(sender as FrameworkElement);

        // ReplaceAppointmentAsync returns an updated appointment id when the appointment was successfully replaced.
        // The updated id may or may not be the same as the original one retrieved from AddAppointmentAsync.
        // An optional instance start time can be provided to indicate that a specific instance on that date should be replaced
        // in the case of a recurring appointment.
        // If the appointment id returned is an empty string, that indicates that the appointment was not replaced.
        String updatedAppointmentId;
        if (InstanceStartDateCheckBox.IsChecked.Value)
        {
            // Replace a specific instance starting on the date provided.
            var instanceStartDate = InstanceStartDateDatePicker.Date;
            updatedAppointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowReplaceAppointmentAsync(
                                   appointmentIdOfAppointmentToReplace, appointment, rect, Windows.UI.Popups.Placement.Default, instanceStartDate);
        }
        else
        {
            // Replace an appointment that occurs only once or in the case of a recurring appointment, replace the entire series.
            updatedAppointmentId = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowReplaceAppointmentAsync(
                                   appointmentIdOfAppointmentToReplace, appointment, rect, Windows.UI.Popups.Placement.Default);
        }

        if (updatedAppointmentId != String.Empty)
        {
            ResultTextBlock.Text = &quot;Updated Appointment Id: &quot; + updatedAppointmentId;
        }
        else
        {
            ResultTextBlock.Text = &quot;Appointment not replaced.&quot;;
        }
    }
}
```

## Xxxxxx xx xxxxxxxxxxx xxxx xxx xxxx'x xxxxxxxx

Xxxx xxx xxxxxxxxxxx [**XxxxxxxxxxxXxxxxxx.XxxxXxxxxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showremoveappointmentasync) xxxxxx xx xxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxxx xxxxxx-xxxxxxxxxxx XX, xx xxxxxx xxx xxxx xx xxxxxx xx xxxxxxxxxxx. Xxx xxxx xxxx xxxxxxxx xxx xxxxxxxxxxx xxxxxxxxxx xxxx xxxx xxxx xx xxxxxx. Xxxx xxxxxxxxxx xxx xxxxxxxx xxxx [**XxxxxxxxxxxXxxxxxx.XxxxXxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showaddappointmentasync). Xx xxx xxxx xxxxxxx **Xxxxxx**, xxx xxxxxx xxxxxx xxxx xx xxxxxxx xxx xxxxxxxxxxx xxxxxxxxx xx xxxx xxxxxxxxxxx xxxxxxxxxx.

```cs
private async void Remove-Click(object sender, RoutedEventArgs e)
{
    // The appointment id argument for ShowRemoveAppointmentAsync is typically retrieved from AddAppointmentAsync and stored in app data.
    String appointmentId = AppointmentIdTextBox.Text;

    // The appointment id cannot be null or empty.
    if (String.IsNullOrEmpty(appointmentId))
    {
        ResultTextBlock.Text = &quot;The appointment id cannot be empty&quot;;
    }
    else
    {
        // Get the selection rect of the button pressed to remove this appointment
        var rect = GetElementRect(sender as FrameworkElement);

        // ShowRemoveAppointmentAsync returns a boolean indicating whether or not the appointment related to the appointment id given was removed.
        // An optional instance start time can be provided to indicate that a specific instance on that date should be removed
        // in the case of a recurring appointment.
        bool removed;
        if (InstanceStartDateCheckBox.IsChecked.Value)
        {
            // Remove a specific instance starting on the date provided.
            var instanceStartDate = InstanceStartDateDatePicker.Date;
            removed = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowRemoveAppointmentAsync(
                      appointmentId, rect, Windows.UI.Popups.Placement.Default, instanceStartDate);
        }
        else
        {
            // Remove an appointment that occurs only once or in the case of a recurring appointment, replace the entire series.
            removed = await Windows.ApplicationModel.Appointments.AppointmentManager.ShowRemoveAppointmentAsync(
                      appointmentId, rect, Windows.UI.Popups.Placement.Default);
        }

        if (removed)
        {
            ResultTextBlock.Text = &quot;Appointment removed&quot;;
        }
        else
        {
            ResultTextBlock.Text = &quot;Appointment not removed&quot;;
        }
    }
}
```

## Xxxx x xxxx xxxx xxx xxx xxxxxxxxxxxx xxxxxxxx

Xxxx xxx [**XxxxxxxxxxxXxxxxxx.XxxxXxxxXxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showtimeframeasync) xxxxxx xx xxxx x xxxxxxxx xxxx xxxx xxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxxx'x xxxxxxx XX xx xxx xxxx xxxxxxx **Xxxx**. Xxx xxxxxx xxxxxx xxxx xxx xxxxxxx xxxxxxxxxxxx xxxxxxxx xxxxxxxx xx xxxxxx.

```cs 
private async void Show-Click(object sender, RoutedEventArgs e)
{
    var dateToShow = new DateTimeOffset(2015, 6, 12, 18, 32, 0, 0, TimeSpan.FromHours(-8));
    var duration = TimeSpan.FromHours(1);
    await Windows.ApplicationModel.Appointments.AppointmentManager.ShowTimeFrameAsync(dateToShow, duration);
    ResultTextBlock.Text = &quot;The default appointments provider should have appeared on screen.&quot;;
}
```

## Xxxxxx xx xxxxxxxxxxx-xxxxxxxxxx xxxxxx xxx xxxxx xxxx xx xx

Xxxxxx xx [**Xxxxxxx.XxxxxxxxxxxXxxxx.Xxxxxxxxxxxx.XxxxxxxxxxxXxxxxxxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221recurrence) xxxxxx xxx xxxxxx xx xx x xxxxxxxx. Xxxx, xxxxx xx xxx **XxxxxxxxxxxXxxxxxxxxx** xxx xxxxxxxxxx xxxxxxxxxx xxxx xxxx xxxxxxxx xxxxxxx xxx XX xx x xxxx.

```cs
private void Create-Click(object sender, RoutedEventArgs e)
{
    bool isRecurrenceValid = true;
    var recurrence = new Windows.ApplicationModel.Appointments.AppointmentRecurrence();

    // Unit
    switch (UnitComboBox.SelectedIndex)
    {
        case 0:
            recurrence.Unit = Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.Daily;
            break;
        case 1:
            recurrence.Unit = Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.Weekly;
            break;
        case 2:
            recurrence.Unit = Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.Monthly;
            break;
        case 3:
            recurrence.Unit = Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.MonthlyOnDay;
            break;
        case 4:
            recurrence.Unit = Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.Yearly;
            break;
        case 5:
            recurrence.Unit = Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.YearlyOnDay;
            break;
    }

    // Occurrences
    // Note: Occurrences and Until properties are mutually exclusive.
    if (OccurrencesRadioButton.IsChecked.Value)
    {
        recurrence.Occurrences = (uint)OccurrencesSlider.Value;
    }

    // Until
    // Note: Until and Occurrences properties are mutually exclusive.
    if (UntilRadioButton.IsChecked.Value)
    {
        recurrence.Until = UntilDatePicker.Date;
    }

    // Interval
    recurrence.Interval = (uint)IntervalSlider.Value;

    // Week of the month
    switch (WeekOfMonthComboBox.SelectedIndex)
    {
        case 0:
            recurrence.WeekOfMonth = Windows.ApplicationModel.Appointments.AppointmentWeekOfMonth.First;
            break;
        case 1:
            recurrence.WeekOfMonth = Windows.ApplicationModel.Appointments.AppointmentWeekOfMonth.Second;
            break;
        case 2:
            recurrence.WeekOfMonth = Windows.ApplicationModel.Appointments.AppointmentWeekOfMonth.Third;
            break;
        case 3:
            recurrence.WeekOfMonth = Windows.ApplicationModel.Appointments.AppointmentWeekOfMonth.Fourth;
            break;
        case 4:
            recurrence.WeekOfMonth = Windows.ApplicationModel.Appointments.AppointmentWeekOfMonth.Last;
            break;
    }

    // Days of the Week
    // Note: For Weekly, MonthlyOnDay or YearlyOnDay recurrence unit values, at least one day must be specified.
    if (SundayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Sunday; }
    if (MondayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Monday; }
    if (TuesdayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Tuesday; }
    if (WednesdayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Wednesday; }
    if (ThursdayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Thursday; }
    if (FridayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Friday; }
    if (SaturdayCheckBox.IsChecked.Value) { recurrence.DaysOfWeek |= Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.Saturday; }

    if (((recurrence.Unit == Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.Weekly) ||
         (recurrence.Unit == Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.MonthlyOnDay) ||
         (recurrence.Unit == Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.YearlyOnDay)) &amp;&amp;
        (recurrence.DaysOfWeek == Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.None))
    {
        isRecurrenceValid = false;
        ResultTextBlock.Text = &quot;The recurrence specified is invalid. For Weekly, MonthlyOnDay or YearlyOnDay recurrence unit values, 
                                at least one day must be specified.&quot;;
    }

    // Month of the year
    recurrence.Month = (uint)MonthSlider.Value;

    // Day of the month
    recurrence.Day = (uint)DaySlider.Value;

    if (isRecurrenceValid)
    {
        ResultTextBlock.Text = &quot;The recurrence specified was created successfully and is valid.&quot;;
    }
}
```

## Xxx x xxx xxxxxxxx xxxxxxxxxxx

[
            **XxxxXxxxXxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showeditnewappointmentasync) xxxxx xxxx xxxx [**XxxxXxxXxxxxxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showaddappointmentasync) xxxxxx xxxx xxx xxxxxx xxx xxxxxx xxx xxxxxxxxxxx xx xxxxxxxx xx xxxx xxx xxxx xxx xxxxxx xxx xxxxxxxxxxx xxxx xxxxxx xxxxxx xx.

``` cs
private async void AddAndEdit-Click(object sender, RoutedEventArgs e)
{
    // Create an Appointment that should be added the user' s appointments provider app.
    var appointment = new Windows.ApplicationModel.Appointments.Appointment();

    appointment.StartTime = DateTime.Now + TimeSpan.FromDays(1);
    appointment.Duration = TimeSpan.FromHours(1);
    appointment.Location = &quot;Meeting location&quot;;
    appointment.Subject = &quot;Meeting subject&quot;;
    appointment.Details = &quot;Meeting description&quot;;
    appointment.Reminder = TimeSpan.FromMinutes(15); // Remind me 15 minutes prior


    // ShowAddAppointmentAsync returns an appointment id if the appointment given was added to the user' s calendar.
    // This value should be stored in app data and roamed so that the appointment can be replaced or removed in the future.
    // An empty string return value indicates that the user canceled the operation before the appointment was added.
    String appointmentId =
        await Windows.ApplicationModel.Appointments.AppointmentManager.ShowEditNewAppointmentAsync(appointment);
    
    if (appointmentId != String.Empty)
    {
        ResultTextBlock.Text = &quot;Appointment Id: &quot; + appointmentId;
    }
    else
    {
        ResultTextBlock.Text = &quot;Appointment not added.&quot;;
    }
}
```

## Xxxx xxxxxxxxxxx xxxxxxx

[
            **XxxxXxxxxxxxxxxXxxxxxxXxxxx**](https://msdn.microsoft.com/library/windows/apps/Dn297221manager-showappointmentdetailsasync) xxxxxx xxx xxxxxx xx xxxx xxxxxxx xxx xxx xxxxxxxxx xxxxxxxxxxx. Xx xxx xxxx xxxxxxxxxx xxx xxxxxxxxx xxx xxxxxx xx xx xxxxxxxxx xx xxxx xxxxxxx xxx xxxxxxxxxxxx xx xxxxxxxxx xx xxxx. Xxxxxxxxx, xxx xxxxxx xxxx xxxx xxx xxxxxxxxxxx xxxxxxx. Xx xxxxxxxx xx xxx xxxxxx xxxx xxxxxxx x xxxxx xxxx xxxxxxxx xx xxxxxxxx xx xxxx xxxxxxx xxx xx xxxxxxxx xx x xxxxxxxxx xxxxxxxxxxx.

```cs
private async void ShowAppointmentDetails-Click(object sender, RoutedEventArgs e)
{

    if (instanceStartTime == null)
    {
        await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAppointmentDetailsAsync(
            currentAppointment.LocalId);
    }
    else
    {
        // Specify a start time to show an instance of a recurring appointment
        await Windows.ApplicationModel.Appointments.AppointmentManager.ShowAppointmentDetailsAsync(
            currentAppointment.LocalId, instanceStartTime);
    }

}
```

## Xxxxxxx xxx xxxx xxxxx

Xxx xxx xxxx x xxxxx xxxxxxxxxxxxx xx xxx xx xxxxxx xxxxxxxxxxxx. Xxxxxxxx xxx [Xxxxxxxxx Xxxxxxx xxx xxxxxxx](http://go.microsoft.com/fwlink/p/?linkid=619979) xxxx XxxXxx xx xxx xxxx xxxxxxxx xx xxx xx xxxxxx xxxxxxxxxxxx.

## Xxxxxxx xxxxxx

* [Xxxxxxxxxxxx XXX xxxxxx](http://go.microsoft.com/fwlink/p/?linkid=309836)
 

 




<!--HONumber=Mar16_HO1-->
