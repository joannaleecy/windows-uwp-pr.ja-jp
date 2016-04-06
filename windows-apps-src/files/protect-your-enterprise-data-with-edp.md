---
Description: 'This topic shows examples of the coding tasks needed to achieve some of the most common file-related enterprise data protection (EDP) scenarios.'
MS-HAID: 'dev\_files.protect\_your\_enterprise\_data\_with\_edp'
MSHAttr: 'PreferredLib:/library/windows/apps'
Search.Product: eADQiWindows 10XVcnh
title: 'Use enterprise data protection (EDP) to protect files'
---

# Use enterprise data protection (EDP) to protect files

__Note__ Enterprise data protection (EDP) policy cannot be applied on Windows 10, Version 1511 (build 10586) or earlier.

This topic shows examples of the coding tasks needed to achieve some of the most common file-related enterprise data protection (EDP) scenarios. For the full developer picture of how EDP relates to files, streams, the clipboard, networking, background tasks, and data protection under lock, see [enterprise data protection (EDP)](../enterprise/edp-hub.md).

**Note**  The [enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409) covers many of the same scenarios demonstrated in this topic.

## Prerequisites

-   **Get set up for EDP**

    See [Set up your computer for EDP](../enterprise/edp-hub.md#set-up-your-computer-for-EDP).

-   **Commit to building an enterprise-enlightened app**

    An app that autonomously ensures that enterprise data stays under the managing enterprise’s control is known as an enterprise-enlightened app. An enlightened app is more powerful, smart, flexible, and trusted than an unenlightened one. Your app announces to the system that it is enlightened by declaring the restricted **enterpriseDataPolicy** capability. There's more to being enlightened than setting a capability, though. To learn more, see [Enterprise-enlightened apps](../enterprise/edp-hub.md#enterprise-enlightened-apps).

-   **Understand async programming for Universal Windows Platform (UWP) apps**

    To learn about how to write asynchronous apps in C\# or Visual Basic, see [Call asynchronous APIs in C\# or Visual Basic](https://msdn.microsoft.com/library/windows/apps/mt187337). To learn about how to write asynchronous apps in C++, see [Asynchronous programming in C++](https://msdn.microsoft.com/library/windows/apps/mt187334).

## Your local folder path, and viewing protected files in File Explorer


You can create an app to host the code examples in this topic to try them out. The code examples write files to your app's local folder, and the exact location of that folder on disk is unique to your app. To determine the location of your app's local folder, you can add the following code.

```CSharp
// Put a breakpoint on the line after the line of code below. Use the value of localFolderPath
// in File Explorer to find the output file that the later code examples create.
string localFolderPath = ApplicationData.Current.LocalFolder.Path;
```

Once you have the path, you'll be able to use File Explorer to easily find the files that your app creates. That way, you'll be able to confirm that they're protected, and that they're protected to the correct identity.

In File Explorer, **Change folder and search options** and on the **View** tab, check **Show encrypted files in color**. Also, use File Explorer's **View** &gt; **Add columns** command to add the **Encrypted to** column so that you can see the enterprise identity that you're protecting your files to.

## Protect enterprise data in a new file (for an interactive app)


There are many ways enterprise data might enter your app, including from certain network endpoints, from files, from the clipboard, or from the share contract. Your app might create new enterprise data, too. Whatever the means by which your enlightened app comes by enterprise data, your app will need to be careful to protect the data to the managed enterprise identity when it persists the data to a new file.

The basic steps are to use a regular storage API to create the file, use an EDP API to protect the file to the enterprise identity, and then (again, using regular storage APIs) to write to the file. Be careful to protect the file before you write to it (as shown in the example below). You use the [**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) method to protect the file. And, as always, it only makes sense to protect to an identity if that identity is managed. For more info about why that's the case, and how your app can determine the identity of the enterprise it's running in, see [Confirming an identity is managed](../enterprise/edp-hub.md#confirming_an_identity_is_managed).

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void SaveEnterpriseDataToFile(string enterpriseData, string identity)
{
    // You should only protect to an identity that is managed.
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    StorageFile storageFile = storageFolder.CreateFileAsync("sample.txt",
        CreationCollisionOption.ReplaceExisting);

    // It's important to protect a file *before* writing enterprise data to it.
    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.ProtectAsync(storageFile, identity);

    // If the file is now protected, to the intended identity, then we can write to it.
    if (fileProtectionInfo.Identity == identity &&
        fileProtectionInfo.Status == FileProtectionStatus.Protected)
        await Windows.Storage.FileIO.WriteTextAsync(storageFile, enterpriseData);
}
```

## Protect enterprise data in a new file (for a background task)


The [**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) API that we used in the previous section is only appropriate for interactive apps. For a background task, your code can execute while under the lock screen. And the organization may be administering a secure "data protection under lock" (DPL) policy, where encryption keys required to access protected resources are temporarily removed from device memory when the device is locked. This prevents data leaks if the device is lost. The feature also removes keys associated with protected files when their handles are closed. It is, however, possible to create new protected files during the lock window (the time between the device being locked and unlocked) and access them while keeping the file handle open. **StorageFolder.CreateFileAsync** closes the handle when the file is created, so this algorithm can't be used.

1.  Create a new file using **StorageFolder.CreateFileAsync**.
2.  Encrypt using **FileProtectionManager.ProtectAsync**.
3.  Open the file and write to it.

Since Step 1 involves closing the file handle (and even if Step 1 didn’t close the handle, Step 2 would), Step 3 is not possible because encryption keys to access that file are no longer available.

To address this scenario, you can use [**FileProtectionManager.CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn705153) to create a protected file and return an **IRandomAccessStream** to it. This allows apps to make multiple writes to a file while keeping the file handle open.

The example code demonstrates a simplistic mail app writing out a new file when new mail is received. Mail apps must sync email when the device is locked. When this app receives new mail, it creates a new file using [**CreateProtectedAndOpenAsync**](https://msdn.microsoft.com/library/windows/apps/dn705153), retrieves an output stream, and writes the mail body to it.

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;
using Windows.Storage.Streams;

...

private async void SaveEnterpriseDataToFile(string enterpriseData, string identity)
{
    // You should only protect to an identity that is managed.
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;

    ProtectedFileCreateResult protectedFileCreateResult =
        await FileProtectionManager.CreateProtectedAndOpenAsync(storageFolder,
            "sample.txt", identity, CreationCollisionOption.ReplaceExisting);

    // It&#39;s important to successfully protect a file *before* writing enterprise data to it.
    if (protectedFileCreateResult.ProtectionInfo.Identity == identity &&
        protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.Protected)
    {
        using (IOutputStream outputStream =
            protectedFileCreateResult.Stream.GetOutputStreamAt(0))
        {
            using (DataWriter writer = new DataWriter(outputStream))
            {
                writer.WriteString(enterpriseData);
                await writer.StoreAsync();
                await writer.FlushAsync();
            }
        }
    }
    else if (protectedFileCreateResult.ProtectionInfo.Status == FileProtectionStatus.AccessSuspended)
    {
        // Perform any special processing for the access suspended case.
    }
}
```

## Protect a folder whose purpose is to contain enterprise data


If you want every item inside a folder to be protected, then you can do that, too. You can use [**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) to protect an empty folder. Then, any file or folder subsequently created inside the folder will also be protected. You can protect an existing folder, or you can create a new folder to protect (the example below creates a new folder). But, in either case, for protection to succeed, the folder must be empty at the time. If it isn't, then [**FileProtectionInfo.Status**](https://msdn.microsoft.com/library/windows/apps/dn705150) will contain a value of [**FileProtectionStatus.NotProtectable**](https://msdn.microsoft.com/library/windows/apps/dn279147).

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void CreateANewFolderAndProtectItAsync(string folderName, string identity)
{
    if (!ProtectionPolicyManager.IsIdentityManaged(identity)) return false;

    StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
    StorageFolder newStorageFolder =
        await storageFolder.CreateFolderAsync(folderName);

    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.ProtectAsync(newStorageFolder, identity);

    if (fileProtectionInfo.Identity != identity ||
        fileProtectionInfo.Status != FileProtectionStatus.Protected)
    {
        // Protection failed.
    }
}
```

## Copy protection from one file to another


In this scenario, a file already exists that you know is protected to the appropriate enterprise identity. You can replicate that protection onto another file very conveniently. You don't even need to know what the identity is: you only need to know that it's the right one.

To make a simple copy of a protected file, you can call [**StorageFile.CopyAsync**](https://msdn.microsoft.com/library/windows/apps/br227190). The resulting copy of the file will have the same protection as the original.

To protect an existing unprotected file before writing enterprise data to it, an alternative to calling [**FileProtectionManager.ProtectAsync**](https://msdn.microsoft.com/library/windows/apps/dn705157) (which we saw in an earlier scenario, and to which you need to pass a managed identity) is to call [**FileProtectionManager.CopyProtectionAsync**](https://msdn.microsoft.com/library/windows/apps/dn705152) as shown in the code example.

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void CopyProtectionFromOneFileToAnother
    (StorageFile sourceStorageFile, StorageFile targetStorageFile)
{
    bool copyResult = await
        FileProtectionManager.CopyProtectionAsync(sourceStorageFile, targetStorageFile);

    if (!copyResult)
    {
        // Copying failed. To diagnose, you could check the file's status.
        // (call FileProtectionManager.GetProtectionInfoAsync and
        // check FileProtectionInfo.Status).
    }
}
```

## Handle being denied access to a file you protected


In this scenario, your app attempts to access a file—which your app previously protected—and is denied access. You'll need to check the status of the file to see what went wrong. In this code example, the app calls the [**FileProtectionManager.GetProtectionInfoAsync**](https://msdn.microsoft.com/library/windows/apps/dn705154) API to query the status and determine whether the reason is because access to the file has now been revoked as a result of remote management.

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async System.Threading.Tasks.Task<bool> IsFileProtectionStatusRevoked
    (StorageFile storageFile)
{
    FileProtectionInfo fileProtectionInfo =
        await FileProtectionManager.GetProtectionInfoAsync(storageFile);

    if (fileProtectionInfo.Status == FileProtectionStatus.Revoked)
    {
        // Inform the user that their data has been revoked.
    }
    return fileProtectionInfo.Status == FileProtectionStatus.Revoked;
}
```

## Enable UI-policy enforcement based on a file’s protected identity


When your app is about to display the contents of a protected file (such as a PDF) on its UI, it must enable UI-policy enforcement based on the identity the file is protected to. You should query the protection information of the file and enable the system's UI-policy enforcement from the retrieved identity.

```CSharp
using Windows.Security.EnterpriseData;
using Windows.Storage;

...

private async void EnableUIPolicyFromFile(StorageFile storageFile)
{
    FileProtectionInfo fileProtectionInfo = 
        await FileProtectionManager.GetProtectionInfoAsync(storageFile);

    if (fileProtectionInfo.Status != FileProtectionStatus.Protected)
    {
        // No policy enforcement required, unless the file is inaccessible
        // (Revoked, ProtectedToOtherIdentity) in which case that should
        // be handled in an app-specific way.
        return;
    }

    ProtectionPolicyManager.TryApplyProcessUIPolicy(fileProtectionInfo.Identity);
}
```

**Note**  This article is for Windows 10 developers writing Universal Windows Platform (UWP) apps. If you’re developing for Windows 8.x or Windows Phone 8.x, see the [archived documentation](http://go.microsoft.com/fwlink/p/?linkid=619132).

 

## Related topics


[enterprise data protection (EDP) sample](http://go.microsoft.com/fwlink/p/?LinkId=620031&clcid=0x409)

[**Windows.Security.EnterpriseData namespace**](https://msdn.microsoft.com/library/windows/apps/dn279153)

 

 





<!--HONumber=Mar16_HO5-->


