---
author: normesta
description: Windows.ApplicationModel.Appointments 名前空間を使うと、ユーザーのカレンダー アプリで予定の作成と管理を行うことができます。
title: 予定の管理
ms.assetid: 292E9249-07C3-4791-B32C-6EC153C2B538
ms.author: normesta
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, 予定, カレンダー
ms.localizationpriority: medium
ms.openlocfilehash: 345bbabb2bd80f0cbb8465941bec07c7172156e8
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5760106"
---
# <a name="manage-appointments"></a><span data-ttu-id="397c0-104">予定の管理</span><span class="sxs-lookup"><span data-stu-id="397c0-104">Manage appointments</span></span>



<span data-ttu-id="397c0-105">[**Windows.ApplicationModel.Appointments**](https://msdn.microsoft.com/library/windows/apps/Dn263359) 名前空間を使うと、ユーザーのカレンダー アプリで予定の作成と管理を行うことができます。</span><span class="sxs-lookup"><span data-stu-id="397c0-105">Through the [**Windows.ApplicationModel.Appointments**](https://msdn.microsoft.com/library/windows/apps/Dn263359) namespace, you can create and manage appointments in a user's calendar app.</span></span> <span data-ttu-id="397c0-106">ここでは、予定を作成してカレンダー アプリに追加し、カレンダー アプリで置換して、カレンダー アプリから削除する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="397c0-106">Here, we'll show you how to create an appointment, add it to a calendar app, replace it in the calendar app, and remove it from the calendar app.</span></span> <span data-ttu-id="397c0-107">さらに、カレンダー アプリの一定の期間を表示し、予定の繰り返しオブジェクトを作る方法も示します。</span><span class="sxs-lookup"><span data-stu-id="397c0-107">We'll also show how to display a time span for a calendar app and create an appointment-recurrence object.</span></span>

## <a name="create-an-appointment-and-apply-data-to-it"></a><span data-ttu-id="397c0-108">予定を作成してデータを適用する</span><span class="sxs-lookup"><span data-stu-id="397c0-108">Create an appointment and apply data to it</span></span>

<span data-ttu-id="397c0-109">[**Windows.ApplicationModel.Appointments.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn297221) オブジェクトを作成し、変数に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="397c0-109">Create a [**Windows.ApplicationModel.Appointments.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn297221) object and assign it to a variable.</span></span> <span data-ttu-id="397c0-110">次に、ユーザーが UI を通じて提供した予定のプロパティを **Appointment** に適用します。</span><span class="sxs-lookup"><span data-stu-id="397c0-110">Then, apply to the **Appointment** the appointment properties that were supplied through the UI by a user.</span></span>

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

    if (appointment.Subject.Length > 255)
    {
        isAppointmentValid = false;
        ResultTextBlock.Text = "The subject cannot be greater than 255 characters.";
    }

    // Location
    appointment.Location = LocationTextBox.Text;

    if (appointment.Location.Length > 32768)
    {
        isAppointmentValid = false;
        ResultTextBlock.Text = "The location cannot be greater than 32,768 characters.";
    }

    // Details
    appointment.Details = DetailsTextBox.Text;

    if (appointment.Details.Length > 1073741823)
    {
        isAppointmentValid = false;
        ResultTextBlock.Text = "The details cannot be greater than 1,073,741,823 characters.";
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
    if (UriTextBox.Text.Length > 0)
    {
        try
        {
            appointment.Uri = new System.Uri(UriTextBox.Text);
        }
        catch (Exception)
        {
            isAppointmentValid = false;
            ResultTextBlock.Text = "The Uri provided is invalid.";
        }
    }

    // Organizer
    // Note: Organizer can only be set if there are no invitees added to this appointment.
    if (OrganizerRadioButton.IsChecked.Value)
    {
        var organizer = new Windows.ApplicationModel.Appointments.AppointmentOrganizer();

        // Organizer Display Name
        organizer.DisplayName = OrganizerDisplayNameTextBox.Text;

        if (organizer.DisplayName.Length > 256)
        {
            isAppointmentValid = false;
            ResultTextBlock.Text = "The organizer display name cannot be greater than 256 characters.";
        }
        else
        {
            // Organizer Address (e.g. Email Address)
            organizer.Address = OrganizerAddressTextBox.Text;

            if (organizer.Address.Length > 321)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = "The organizer address cannot be greater than 321 characters.";
            }
            else if (organizer.Address.Length == 0)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = "The organizer address must be greater than 0 characters.";
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

        if (invitee.DisplayName.Length > 256)
        {
            isAppointmentValid = false;
            ResultTextBlock.Text = "The invitee display name cannot be greater than 256 characters.";
        }
        else
        {
            // Invitee Address (e.g. Email Address)
            invitee.Address = InviteeAddressTextBox.Text;

            if (invitee.Address.Length > 321)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = "The invitee address cannot be greater than 321 characters.";
            }
            else if (invitee.Address.Length == 0)
            {
                isAppointmentValid = false;
                ResultTextBlock.Text = "The invitee address must be greater than 0 characters.";
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
        ResultTextBlock.Text = "The appointment was created successfully and is valid.";
    }
}
```

## <a name="add-an-appointment-to-the-users-calendar"></a><span data-ttu-id="397c0-111">予定をユーザーのカレンダーに追加する</span><span class="sxs-lookup"><span data-stu-id="397c0-111">Add an appointment to the user's calendar</span></span>

<span data-ttu-id="397c0-112">[**Windows.ApplicationModel.Appointments.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn297221) オブジェクトを作成し、変数に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="397c0-112">Create a [**Windows.ApplicationModel.Appointments.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn297221) object and assign it to a variable.</span></span> <span data-ttu-id="397c0-113">次に、[**AppointmentManager.ShowAddAppointmentAsync(Appointment, Rect, Placement)**](https://msdn.microsoft.com/library/windows/apps/dn297261) メソッドを呼び出して、既定の予定プロバイダーの予定追加 UI を表示し、ユーザーが予定を追加できるようにします。</span><span class="sxs-lookup"><span data-stu-id="397c0-113">Then, call the [**AppointmentManager.ShowAddAppointmentAsync(Appointment, Rect, Placement)**](https://msdn.microsoft.com/library/windows/apps/dn297261) method to show the default appointments provider add-appointment UI, to enable the user to add an appointment.</span></span> <span data-ttu-id="397c0-114">ユーザーが **[追加]** をクリックした場合、このサンプルは **ShowAddAppointmentAsync** によって返された予定識別子を出力します。</span><span class="sxs-lookup"><span data-stu-id="397c0-114">If the user clicked **Add**, the sample prints the appointment identifier that **ShowAddAppointmentAsync** returned.</span></span>

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

<span data-ttu-id="397c0-115">**注:** 用 Windows Phone ストア アプリ、 [**ShowAddAppointment**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync)ように機能[**ShowEditNewAppointment**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showeditnewappointmentasync)予定を追加するために表示されるダイアログが編集可能なことにします。</span><span class="sxs-lookup"><span data-stu-id="397c0-115">**Note**For Windows Phone Store apps, [**ShowAddAppointment**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync) functions just like [**ShowEditNewAppointment**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showeditnewappointmentasync) in that the dialog displayed for adding the appointment is editable.</span></span>

## <a name="replace-an-appointment-in-the-users-calendar"></a><span data-ttu-id="397c0-116">ユーザーのカレンダーで予定を置換する</span><span class="sxs-lookup"><span data-stu-id="397c0-116">Replace an appointment in the user's calendar</span></span>

<span data-ttu-id="397c0-117">[**Windows.ApplicationModel.Appointments.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn297221) オブジェクトを作成し、変数に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="397c0-117">Create a [**Windows.ApplicationModel.Appointments.Appointment**](https://msdn.microsoft.com/library/windows/apps/Dn297221) object and assign it to a variable.</span></span> <span data-ttu-id="397c0-118">次に、該当する [**AppointmentManager.ShowReplaceAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showreplaceappointmentasync) メソッドを呼び出して、既定の予定プロバイダーの予定置換 UI を表示し、ユーザーが予定を置換できるようにします。</span><span class="sxs-lookup"><span data-stu-id="397c0-118">Then, call the appropriate [**AppointmentManager.ShowReplaceAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showreplaceappointmentasync) method to show the default appointments provider replace-appointment UI to enable the user to replace an appointment.</span></span> <span data-ttu-id="397c0-119">ユーザーは、置換する予定識別子も指定します。</span><span class="sxs-lookup"><span data-stu-id="397c0-119">The user also provides the appointment identifier that they want to replace.</span></span> <span data-ttu-id="397c0-120">この識別子は、[**AppointmentManager.ShowAddAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync) から返されたものです。</span><span class="sxs-lookup"><span data-stu-id="397c0-120">This identifier was returned from [**AppointmentManager.ShowAddAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync).</span></span> <span data-ttu-id="397c0-121">ユーザーが **[置換]** をクリックした場合、このサンプルは更新されたその予定識別子を出力します。</span><span class="sxs-lookup"><span data-stu-id="397c0-121">If the user clicked **Replace**, the sample prints that it updated that appointment identifier.</span></span>

```cs
private async void Replace-Click(object sender, RoutedEventArgs e)
{
    // The appointment id argument for ReplaceAppointmentAsync is typically retrieved from AddAppointmentAsync and stored in app data.
    String appointmentIdOfAppointmentToReplace = AppointmentIdTextBox.Text;

    if (String.IsNullOrEmpty(appointmentIdOfAppointmentToReplace))
    {
        ResultTextBlock.Text = "The appointment id cannot be empty";
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
            ResultTextBlock.Text = "Updated Appointment Id: " + updatedAppointmentId;
        }
        else
        {
            ResultTextBlock.Text = "Appointment not replaced.";
        }
    }
}
```

## <a name="remove-an-appointment-from-the-users-calendar"></a><span data-ttu-id="397c0-122">ユーザーのカレンダーから予定を削除する</span><span class="sxs-lookup"><span data-stu-id="397c0-122">Remove an appointment from the user's calendar</span></span>

<span data-ttu-id="397c0-123">該当する [**AppointmentManager.ShowRemoveAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showremoveappointmentasync) メソッドを呼び出して、既定の予定プロバイダーの予定削除 UI を表示し、ユーザーが予定を削除できるようにします。</span><span class="sxs-lookup"><span data-stu-id="397c0-123">Call the appropriate [**AppointmentManager.ShowRemoveAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showremoveappointmentasync) method to show the default appointments provider remove-appointment UI, to enable the user to remove an appointment.</span></span> <span data-ttu-id="397c0-124">ユーザーは、削除する予定識別子も指定します。</span><span class="sxs-lookup"><span data-stu-id="397c0-124">The user also provides the appointment identifier that they want to remove.</span></span> <span data-ttu-id="397c0-125">この識別子は、[**AppointmentManager.ShowAddAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync) から返されたものです。</span><span class="sxs-lookup"><span data-stu-id="397c0-125">This identifier was returned from [**AppointmentManager.ShowAddAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync).</span></span> <span data-ttu-id="397c0-126">ユーザーが **[削除]** をクリックした場合、このサンプルは、その予定識別子により指定された予定が削除されたことを出力します。</span><span class="sxs-lookup"><span data-stu-id="397c0-126">If the user clicked **Delete**, the sample prints that it removed the appointment specified by that appointment identifier.</span></span>

```cs
private async void Remove-Click(object sender, RoutedEventArgs e)
{
    // The appointment id argument for ShowRemoveAppointmentAsync is typically retrieved from AddAppointmentAsync and stored in app data.
    String appointmentId = AppointmentIdTextBox.Text;

    // The appointment id cannot be null or empty.
    if (String.IsNullOrEmpty(appointmentId))
    {
        ResultTextBlock.Text = "The appointment id cannot be empty";
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
            ResultTextBlock.Text = "Appointment removed";
        }
        else
        {
            ResultTextBlock.Text = "Appointment not removed";
        }
    }
}
```

## <a name="show-a-time-span-for-the-appointments-provider"></a><span data-ttu-id="397c0-127">予定プロバイダーの一定の期間を表示する</span><span class="sxs-lookup"><span data-stu-id="397c0-127">Show a time span for the appointments provider</span></span>

<span data-ttu-id="397c0-128">ユーザーが **[表示]** をクリックした場合、[**AppointmentManager.ShowTimeFrameAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showtimeframeasync) メソッドを呼び出して、既定の予定プロバイダーのプライマリ UI の一定期間を表示します。</span><span class="sxs-lookup"><span data-stu-id="397c0-128">Call the [**AppointmentManager.ShowTimeFrameAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showtimeframeasync) method to show a specific time span for the default appointments provider's primary UI if the user clicked **Show**.</span></span> <span data-ttu-id="397c0-129">このサンプルは、既定の予定プロバイダーが画面に表示されたことを出力します。</span><span class="sxs-lookup"><span data-stu-id="397c0-129">The sample prints that the default appointments provider appeared on screen.</span></span>

```cs
private async void Show-Click(object sender, RoutedEventArgs e)
{
    var dateToShow = new DateTimeOffset(2015, 6, 12, 18, 32, 0, 0, TimeSpan.FromHours(-8));
    var duration = TimeSpan.FromHours(1);
    await Windows.ApplicationModel.Appointments.AppointmentManager.ShowTimeFrameAsync(dateToShow, duration);
    ResultTextBlock.Text = "The default appointments provider should have appeared on screen.";
}
```

## <a name="create-an-appointment-recurrence-object-and-apply-data-to-it"></a><span data-ttu-id="397c0-130">予定の繰り返しオブジェクトを作成してデータを適用する</span><span class="sxs-lookup"><span data-stu-id="397c0-130">Create an appointment-recurrence object and apply data to it</span></span>

<span data-ttu-id="397c0-131">[**Windows.ApplicationModel.Appointments.AppointmentRecurrence**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentrecurrence) オブジェクトを作成し、変数に割り当てます。</span><span class="sxs-lookup"><span data-stu-id="397c0-131">Create an [**Windows.ApplicationModel.Appointments.AppointmentRecurrence**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentrecurrence) object and assign it to a variable.</span></span> <span data-ttu-id="397c0-132">次に、ユーザーが UI を通じて提供した繰り返しのプロパティを **AppointmentRecurrence** に適用します。</span><span class="sxs-lookup"><span data-stu-id="397c0-132">Then, apply to the **AppointmentRecurrence** the recurrence properties that were supplied through the UI by a user.</span></span>

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
         (recurrence.Unit == Windows.ApplicationModel.Appointments.AppointmentRecurrenceUnit.YearlyOnDay)) &&
        (recurrence.DaysOfWeek == Windows.ApplicationModel.Appointments.AppointmentDaysOfWeek.None))
    {
        isRecurrenceValid = false;
        ResultTextBlock.Text = "The recurrence specified is invalid. For Weekly, MonthlyOnDay or YearlyOnDay recurrence unit values, " +
                               "at least one day must be specified.";
    }

    // Month of the year
    recurrence.Month = (uint)MonthSlider.Value;

    // Day of the month
    recurrence.Day = (uint)DaySlider.Value;

    if (isRecurrenceValid)
    {
        ResultTextBlock.Text = "The recurrence specified was created successfully and is valid.";
    }
}
```

## <a name="add-a-new-editable-appointment"></a><span data-ttu-id="397c0-133">新しい編集可能な予定を追加する</span><span class="sxs-lookup"><span data-stu-id="397c0-133">Add a new editable appointment</span></span>

<span data-ttu-id="397c0-134">[**ShowEditNewAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showeditnewappointmentasync) の動作は、基本的には [**ShowAddAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync) と同じです。異なるのは、予定を追加するためのダイアログが編集可能である点です。ユーザーは、予定のデータを変更したうえで保存することができます。</span><span class="sxs-lookup"><span data-stu-id="397c0-134">[**ShowEditNewAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showeditnewappointmentasync) works just like [**ShowAddAppointmentAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showaddappointmentasync) except that the dialog for adding the appointment is editable so that the user can modify the appointment data before saving it.</span></span>

``` cs
private async void AddAndEdit-Click(object sender, RoutedEventArgs e)
{
    // Create an Appointment that should be added the user' s appointments provider app.
    var appointment = new Windows.ApplicationModel.Appointments.Appointment();

    appointment.StartTime = DateTime.Now + TimeSpan.FromDays(1);
    appointment.Duration = TimeSpan.FromHours(1);
    appointment.Location = "Meeting location";
    appointment.Subject = "Meeting subject";
    appointment.Details = "Meeting description";
    appointment.Reminder = TimeSpan.FromMinutes(15); // Remind me 15 minutes prior


    // ShowAddAppointmentAsync returns an appointment id if the appointment given was added to the user' s calendar.
    // This value should be stored in app data and roamed so that the appointment can be replaced or removed in the future.
    // An empty string return value indicates that the user canceled the operation before the appointment was added.
    String appointmentId =
        await Windows.ApplicationModel.Appointments.AppointmentManager.ShowEditNewAppointmentAsync(appointment);

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

## <a name="show-appointment-details"></a><span data-ttu-id="397c0-135">予定の詳しい情報を表示する</span><span class="sxs-lookup"><span data-stu-id="397c0-135">Show appointment details</span></span>

<span data-ttu-id="397c0-136">[**ShowAppointmentDetailsAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showappointmentdetailsasync) は、指定された予定の詳しい情報を表示するようにシステムに働きかけます。</span><span class="sxs-lookup"><span data-stu-id="397c0-136">[**ShowAppointmentDetailsAsync**](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.appointments.appointmentmanager.showappointmentdetailsasync) causes the system to show details for the specified appointment.</span></span> <span data-ttu-id="397c0-137">カレンダーを実装するアプリでは、所有下にあるカレンダー内の予定について詳しい情報を表示するときに、そのアプリをアクティブにするかどうかを選ぶことができます。</span><span class="sxs-lookup"><span data-stu-id="397c0-137">An app that implements app calendars may choose to be activated to show details for appointments in calendars it owns.</span></span> <span data-ttu-id="397c0-138">それ以外の場合、予定の詳しい情報がシステムによって表示されます。</span><span class="sxs-lookup"><span data-stu-id="397c0-138">Otherwise, the system will show the appointment details.</span></span> <span data-ttu-id="397c0-139">開始日を引数として受け取るメソッドのオーバーロードが用意されており、定期的に発生する予定について、詳しい情報をいつから表示するかを指定することができます。</span><span class="sxs-lookup"><span data-stu-id="397c0-139">An overload of the method that accepts a start date argument is provided to show details for an instance of a recurring appointment.</span></span>

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

## <a name="summary-and-next-steps"></a><span data-ttu-id="397c0-140">要約と次のステップ</span><span class="sxs-lookup"><span data-stu-id="397c0-140">Summary and next steps</span></span>

<span data-ttu-id="397c0-141">これで、予定を管理する方法の基本について理解できました。</span><span class="sxs-lookup"><span data-stu-id="397c0-141">Now you have a basic understanding of how to manage appointments.</span></span> <span data-ttu-id="397c0-142">予定を管理する方法のその他の例については、GitHub から[ユニバーサル Windows アプリのサンプル](http://go.microsoft.com/fwlink/p/?linkid=619979)をダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="397c0-142">Download the [Universal Windows app samples](http://go.microsoft.com/fwlink/p/?linkid=619979) from GitHub to see more examples of how to manage appointments.</span></span>

## <a name="related-topics"></a><span data-ttu-id="397c0-143">関連トピック</span><span class="sxs-lookup"><span data-stu-id="397c0-143">Related topics</span></span>

* [<span data-ttu-id="397c0-144">予定 API のサンプル</span><span class="sxs-lookup"><span data-stu-id="397c0-144">Appointments API sample</span></span>](http://go.microsoft.com/fwlink/p/?linkid=309836)
 

 
