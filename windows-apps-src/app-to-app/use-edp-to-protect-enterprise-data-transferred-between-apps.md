---
Description: 'This topic shows examples of the coding tasks needed to achieve some of the most common data-transfer-related enterprise data protection (EDP) scenarios.'
MS-HAID: 'dev\_app\_to\_app.use\_edp\_to\_protect\_enterprise\_data\_transferred\_between\_apps'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: Use EDP to protect enterprise data transferred between apps
---

# Use EDP to protect enterprise data transferred between apps

__Note__ Enterprise data protection (EDP) policy cannot be applied on Windows 10, Version 1511 (build 10586) or earlier.

This topic shows examples of the coding tasks needed to achieve some of the most common data-transfer-related enterprise data protection (EDP) scenarios. For the full developer picture of how EDP relates to files, streams, the clipboard, networking, background tasks, and data protection under lock, see [enterprise data protection (EDP)](../enterprise/edp-hub.md).

**Note**  The [enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409) covers many of the same scenarios demonstrated in this topic.

## Prerequisites


-   **Get set up for EDP**

    See [Set up your computer for EDP](../enterprise/edp-hub.md#set-up-your-computer-for-EDP).

-   **Commit to building an enterprise-enlightened app**

    An app that autonomously ensures that enterprise data stays under the managing enterprise’s control is known as an enterprise-enlightened app. An enlightened app is more powerful, smart, flexible, and trusted than an unenlightened one. Your app announces to the system that it is enlightened by declaring the restricted **enterpriseDataPolicy** capability. There's more to being enlightened than setting a capability, though. To learn more, see [Enterprise-enlightened apps](../enterprise/edp-hub.md#enterprise-enlightened-apps).

-   **Understand async programming for Universal Windows Platform (UWP) apps**

    To learn about how to write asynchronous apps in C\# or Visual Basic, see [Call asynchronous APIs in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337). To learn about how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).

## Simple clipboard source


In this scenario, your app is a notepad-type app that handles both personal and enterprise files. Here, your app needn’t change its copy-paste logic at all; it just has to call [**ProtectionPolicyManager.TryApplyProcessUIPolicy**](https://msdn.microsoft.com/library/windows/apps/dn705791) whenever the user opens and displays content from an enterprise document. Once the content is displayed in your app's UI, the user might then copy it to paste into a different app, which is why setting UI policy is important. That way, the operating system can apply the currently-set policy to a paste operation involving protected data. Similarly, it's important to clear UI policy as soon as it's no longer needed so that the user is once again free to copy-paste personal data. **TryApplyProcessUIPolicy** returns false if its identity argument is not being managed by an enterprise policy.

```CSharp
using Windows.Security.EnterpriseData;

...

private void OnFileLoaded(FileProtectionInfo fileProtectionInfo, string contentsOfFile)
{
    if (fileProtectionInfo.Status == FileProtectionStatus.Protected)
    {
        bool isIdentityManaged = ProtectionPolicyManager.TryApplyProcessUIPolicy
            (fileProtectionInfo.Identity);
        if (isIdentityManaged)
        {
            // UI policy is now in effect for the file's identity.
        }
        else
        {
            // Enterprise policy is not in effect, because the file&#39;s identity
            // is not managed. In this case, we have a file protected to an
            // unmanaged identity, which is not a valid situation.
            // We still have to call ClearProcessUIPolicy if we want to clear the policy.
            ProtectionPolicyManager.ClearProcessUIPolicy();
        }
    }
    else
    {
        // In case we applied the policy for the previous file, now we need to clear it.
        ProtectionPolicyManager.ClearProcessUIPolicy();
    }
    // Code goes here to display "contentsOfFile" in your UI. Ready for copy-paste...
}
```

## Simple clipboard target


In this scenario, your app is an email app that handles both personal and corporate accounts. The user tries to paste data into an email reply using their personal account. In this case, before your app retrieves the contents, it has to just make a call to [**DataPackage.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706636). If we already have access, then that method returns at once. But, if we don't have access, then the method causes a dialog to be shown which request consent from the user and "unlocks" the data package if consent is granted. This is to give the user the chance to cancel a paste operation made by mistake.

```CSharp
using Windows.ApplicationModel.DataTransfer;

...

private async void OnPasteSimple()
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        // In case we don't already have acccess, request consent from the user
        // for us to access the clipboard data.
        await dataPackageView.RequestAccessAsync();

        try
        {
            string contentsOfClipboard = await dataPackageView.GetTextAsync();
            // Code goes here to insert the text into the email...
        }
        catch (Exception)
        {
            // Code goes here to handle the exception retrieving text from the clipboard.
        }
    }
    else
    {
        // The value on the clipboard is not in the text format.
    }
}
```

## Clipboard target is a neutral, empty document


In this scenario, your app is a word-processing app. After creating a new document, as long as the document remains empty, your app treats the document as neutral—neither enterprise nor personal. Your user then pastes enterprise data into this neutral-context document. Since the document is in a neutral context, we could actually just switch the document into an enterprise context and avoid calling [**DataPackage.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706636) altogether (since showing the dialog isn't necessary in that case). So, if the data is protected, then we just switch to an enterprise context and paste the data.

```CSharp
using Windows.ApplicationModel.DataTransfer;

...

private async void OnPasteWithApplyPolicy()
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        // If the data has no enterprise identity, then we already have access.
        if (!string.IsNullOrEmpty(dataPackageView.Properties.EnterpriseId))
        {
            ProtectionPolicyEvaluationResult policyResult =
                await dataPackageView.RequestAccessAsync(dataPackageView.Properties.EnterpriseId);
            if (this.isNewEmptyDocument &amp;&amp;
                policyResult == ProtectionPolicyEvaluationResult.Allowed)
            {
                // If this is a new and empty document, and we're allowed to access
                // the data, then we can avoid popping the consent dialog.
                bool isIdentityManaged = ProtectionPolicyManager.TryApplyProcessUIPolicy(dataPackageView.Properties.EnterpriseId);
                // You can use "isIdentityManaged", but it's not necessary.
            }
            else
            {
                // In this case, we can't optimize the workflow, so we just
                // request consent from the user in this case.
                await dataPackageView.RequestAccessAsync();
            }
        }

        try
        {
            string contentsOfClipboard = await dataPackageView.GetTextAsync();
            // Code goes here to insert the text into the email...
        }
        catch (Exception)
        {
            // Code goes here to handle the exception retrieving text from the clipboard.
        }
    }
    else
    {
        // The value on the clipboard is not in the text format.
    }
}
```

## Clipboard source with explicit enterprise identity


In this scenario, your app is a word-processing app. It uses a background thread to commit copy operations by the user. The user copies some data from an enterprise file, and immediately switches to a personal file, at which point the app's global context becomes personal. At this point—because the global state has changed and should not be used—the app’s background thread must explicitly tell the clipboard that the incoming data is enterprise. This is done by setting the [**DataPackagePropertySet.EnterpriseId**](https://msdn.microsoft.com/library/windows/apps/dn913861) property.

```CSharp
using Windows.ApplicationModel.DataTransfer;

...

private void CopyToClipboard(string stringToCopy, string identity)
{
    // Copy the string to the clipboard.
    var dataPackage = new DataPackage();
    dataPackage.SetText(stringToCopy);
    dataPackage.Properties.EnterpriseId = identity;
    Clipboard.SetContent(dataPackage);
}
```

## Tag specific window with enterprise identity


In this scenario, your app is a word-processing app that handles multiple documents in different windows, some of which are enterprise and others that are personal. The app wants to ensure that any data being pasted into a personal document’s window is correctly vetted (that is, denied or consented if it’s enterprise data) and that any outgoing data from an enterprise document’s window is correctly marked. You do this by setting the [**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) property.

```CSharp
using Windows.Security.EnterpriseData;

...

private void TagCurrentViewWithEnterpriseId(string identity)
{
    ProtectionPolicyManager.GetForCurrentView().Identity = identity;
}
```

## Tag outgoing drag object with enterprise identity


Your app has a personal window open with some draggable enterprise content. The user begins to drag some of this content, and your app needs to ensure that the content is marked as enterprise. This scenario doesn’t involve any new APIs. For this scenario, your app will set the [**DataPackagePropertySet.EnterpriseId**](https://msdn.microsoft.com/library/windows/apps/dn913861) property (see [Clipboard source with explicit enterprise identity scenario](#clipboard_source_explicit_id) above).

## Queries received drag object for its enterprise identity


Your app has a new and empty document open, which is assumed to be neutral as long as it's empty, and the user drag-drops some content into the document. The app must now determine the enterprise identity of the object in order to change the state of the document accordingly. For this scenario, your app will get the **EnterpriseId** property from the data package by reading [**DataPackagePropertySet.EnterpriseId**](https://msdn.microsoft.com/library/windows/apps/dn913861) (see [Clipboard source with explicit enterprise identity scenario](#clipboard_source_explicit_id) above).

## Your app as a Share contract source


When you support the Share contract in your app, to set up a share source, set the enterprise identity context in the [**DataPackage**](https://msdn.microsoft.com/library/windows/apps/br205873) as shown in this code example.

**Note**  This code example depends on you having already set the identity on the protection policy manager object for your current view (see [Tag specific window with enterprise identity](#tag_window_with_id)); otherwise, the [**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) property will contain the empty string.



```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.Security.EnterpriseData;

...

private void OnShareSourceOperation(object sender, RoutedEventArgs e)
{
    // Register the current page as a share source (or you could do this earlier in your app).
    DataTransferManager.GetForCurrentView().DataRequested += OnDataRequested;
    DataTransferManager.ShowShareUI();
}

private void OnDataRequested(DataTransferManager sender, DataRequestedEventArgs args)
{
    if (!string.IsNullOrEmpty(this.shareSourceContent))
    {
        var protectionPolicyManager = ProtectionPolicyManager.GetForCurrentView();
        DataPackage requestData = args.Request.Data;
        requestData.Properties.Title = this.shareSourceTitle;
        requestData.Properties.EnterpriseId = protectionPolicyManager.Identity;
        requestData.SetText(this.shareSourceContent);
    }
}
```

## Your app as a Share contract target


This code example continues our policy that as long as the file we're working with is empty. Then, we're free to switch contexts as appropriate for incoming data, and avoid popping consent UI where possible. So, when your app receives data as a Share contract target, it should call [**ProtectionPolicyManager.TryApplyProcessUIPolicy**](https://msdn.microsoft.com/library/windows/apps/dn705791) if there is no existing content; otherwise, it should call [**DataPackage.RequestAccessAsync**](https://msdn.microsoft.com/library/windows/apps/dn706636). The code example shows how.

```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.ApplicationModel.DataTransfer.ShareTarget;

...

string identity = "microsoft.com";

protected override async void OnShareTargetActivated(ShareTargetActivatedEventArgs args)
{
    ShareOperation shareOperation = args.ShareOperation;
    if (shareOperation.Data.Contains(StandardDataFormats.Text))
    {
        // If the data has no enterprise identity, then we already have access.
        if (!string.IsNullOrEmpty(shareOperation.Data.Properties.EnterpriseId))
        {
            ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult =
                await ProtectionPolicyManager.RequestAccessAsync
                    (shareOperation.Data.Properties.EnterpriseId, identity);
            if (this.isNewEmptyDocument && protectionPolicyEvaluationResult ==
                ProtectionPolicyEvaluationResult.Allowed)
            {
                // If this is a new and empty document, and we&#39;re allowed to access
                // the data, then we can avoid popping the consent dialog.
                bool isIdentityManaged = ProtectionPolicyManager.TryApplyProcessUIPolicy
                    (shareOperation.Data.Properties.EnterpriseId);
                // You can use "isIdentityManaged", but it';s not necessary.
            }
            else
            {
                // In this case, we can't optimize the workflow, so we just
                // request consent from the user in this case.
                protectionPolicyEvaluationResult = await shareOperation.Data.RequestAccessAsync();
            }
        }

        try
        {
            // Get the text from the share operation...
            App.shareTargetContent = await shareOperation.Data.GetTextAsync();
        }
        catch (Exception)
        {
            // Code goes here to handle the exception retrieving text from the share operation.
        }
    }
    else
    {
        // The value in the share operation is not in the text format.
    }
}
```

## Query copy-paste policy passively


In this scenario, your app enables paste UI only when data is on the clipboard. For this feature, you can use the [**ProtectionPolicyManager.CheckAccess**](https://msdn.microsoft.com/library/windows/apps/dn705783) method, which allows a passive check of policy.

**Note**  This code example depends on you having already set the identity on the protection policy manager object for your current view (see [Tag specific window with enterprise identity](#tag_window_with_id)); otherwise, the [**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) property will contain the empty string.



```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.Security.EnterpriseData;

...

private bool IsClipboardPeekAllowedAsync()
{
    ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult = ProtectionPolicyEvaluationResult.Blocked;
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        protectionPolicyEvaluationResult =
            ProtectionPolicyManager.CheckAccess(dataPackageView.Properties.EnterpriseId,
                ProtectionPolicyManager.GetForCurrentView().Identity);
    }

    // Since this is a convenience feature to allow a peek of clipboard content,
    // if state is Blocked or ConsentRequired, do not show peek if this helper
    // method returns false.
    return (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed);
}
```

## Request access for copy-paste operation


This scenario shows how to check access for a paste operation.

**Note**  This code example depends on you having already set the identity on the protection policy manager object for your current view (see [Tag specific window with enterprise identity](#tag_window_with_id)); otherwise, the [**ProtectionPolicyManager.Identity**](https://msdn.microsoft.com/library/windows/apps/dn705785) property will contain the empty string.



```CSharp
using Windows.ApplicationModel.DataTransfer;
using Windows.Security.EnterpriseData;

...

private async void OnPasteWithRequestAccess()
{
    DataPackageView dataPackageView = Clipboard.GetContent();
    if (dataPackageView.Contains(StandardDataFormats.Text))
    {
        ProtectionPolicyEvaluationResult protectionPolicyEvaluationResult =
            ProtectionPolicyManager.CheckAccess(dataPackageView.Properties.EnterpriseId,
                ProtectionPolicyManager.GetForCurrentView().Identity);

        if (protectionPolicyEvaluationResult == ProtectionPolicyEvaluationResult.Allowed)
        {
            try
            {
                string contentsOfClipboard = await dataPackageView.GetTextAsync();
                // Code goes here to insert the text into the app...
                this.fileContentsTextBox.Text = contentsOfClipboard;
            }
            catch (Exception)
            {
                // Code goes here to handle the exception retrieving text from the clipboard.
            }
        }
        else
        {
            // Paste from the enterprise context is not allowed by policy.
        }
    }
    else
    {
        // The value on the clipboard is not in the text format.
    }
}
```

**Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).



## Related topics


[enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData namespace**](https://msdn.microsoft.com/library/windows/apps/dn279153)







<!--HONumber=Mar16_HO5-->


