---
Description: The Packages page is where you upload all of the package files (.xap, .appx, .appxupload, and/or .appxbundle) for the app that you're submitting. You can upload packages for any operating system that your app targets in this step.
title: Upload app packages
ms.assetid: B1BB810D-3EAA-4FB5-B03C-1F01AFB2DE36
---

# Upload app packages


The **Packages** page is where you upload all of the package files (.xap, .appx, .appxupload, and/or .appxbundle) for the app that you're submitting. You can upload packages for any operating system that your app targets in this step. When a customer downloads your app, the Store will look through all of your app's available packages and will automatically provide each customer with the package that works best for their device.

For details about what a package includes and how it must be structured, see [App package requirements](app-package-requirements.md). You'll also want to learn about [how version numbers may impact which packages are delivered to specific customers](package-version-numbering.md), and [how packages are distributed to different operating systems](guidance-for-app-package-management.md).

## Uploading packages to your submission


To upload packages, drag them into the upload field or click to browse your files. The **Packages** page will let you upload .xap, .appx, .appxupload, and/or .appxbundle files.

If you have created any [package flights](package-flights.md) for your app, you’ll see a drop-down with the option to copy packages from one of your package flights. Select the package flight that has the packages you want to pull in. You can then select any or all of its packages to include in this submission.

> **Important**  For Windows 10, you should always upload the .appxupload file here, not the .appx or .appxbundle. For more info about packaging UWP apps for the Store, see [Packaging Universal Windows apps for Windows 10](../packaging/packaging-uwp-apps.md).

If we detect issues with your packages while validating them, you'll need to remove the package, fix the issue, and then try uploading it again. For more info, see [Resolve package upload errors](resolve-package-upload-errors.md).

You may also see warnings to let you know about issues that may cause problems but won't block you from continuing with your submission.

## Package details


After your packages have been successfully uploaded, we'll list them, grouped by target operating system. The name, version, and architecture of the package will be displayed. For more info such as the supported languages, app capabilities, and file size for each package, click **Details**.

If you are using [Windows ad mediation](../monetize/use-ad-mediation-to-maximize-revenue.md), you'll also see a link to configure ad mediation for each package.

If you need to remove a package from your submission, click the **Remove** link at the bottom of each package's **Details** section.

## Removing redundant packages


If we detect that one or more of your packages is redundant, we'll display a warning suggesting that you remove the redundant packages from this submission. Often this happens when you have previously uploaded packages, and now you are providing higher-versioned packages that support the same set of customers. In this case, no customers would ever get the redundant package, because you now have a better (higher-versioned) package to support these customers.

When we detect that you have redundant packages, we'll provide an option to remove all of the redundant packages from this submission automatically. You can also remove packages from the submission individually if you prefer.

## Packages with Visual Studio Application Insights


We recommend that you use [Visual Studio Application Insights](http://go.microsoft.com/fwlink/?LinkId=615086) in your packages (or enable it by checking the box for “Show telemetry in the Windows Dev Center” when building your package) so that we can provide you with [app usage telemetry details](usage-report.md). If you didn’t configure Application Insights in Microsoft Visual Studio, when we detect that a package includes it, we'll display a message confirming that by submitting your package, you agree to enable app usage telemetry about your developer account. You can disable app usage telemetry at any time in your **Account settings**.

 

 






<!--HONumber=Mar16_HO5-->


