---
author: mcleanbyron
ms.assetid: cc24ba75-a185-4488-b70c-fd4078bc4206
description: Learn how to use the AdScheduler class to add advertisements to video content.
title: Add advertisements to video content in HTML 5 and JavaScript
---

# Add advertisements to video content in HTML 5 and JavaScript


This walkthrough shows how to use the [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) class to add advertisements to video content in a Universal Windows Platform (UWP) app that was written using JavaScript with HTML.

>**Note**&nbsp;&nbsp;This feature is currently supported only for UWP apps that was written using JavaScript with HTML.

[AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) works with both progressive and streaming media, and uses IAB standard Video Ad Serving Template (VAST) 2.0/3.0 and VMAP payload formats. By using standards, [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) is agnostic to the ad service with which it interacts.

Advertising for video content differs based upon whether the program is under ten minutes (short form), or over ten minutes (long form). Although the latter is more complicated to set up on the service, there is actually no difference in how one writes the client side code. If the [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) receives a VAST payload with a single ad instead of a manifest, it is treated as if the manifest called for a single pre-roll ad (one break at time 00:00).

## Prerequisites

* Install the [Microsoft Store Services SDK](http://aka.ms/store-em-sdk) with Visual Studio 2015.

* Your project must use the [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) control to serve the video content in which the ads will be scheduled. This control is available in the [TVHelpers](https://github.com/Microsoft/TVHelpers) collection of libraries available from Microsoft on GitHub.

  The following example shows how to declare a [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) in HTML markup. Typically, this markup belongs in the `<body>` section in the default.html file (or another html file as appropriate for your project).
  ``` html
  <div id="MediaPlayerDiv" data-win-control="TVJS.MediaPlayer">
    <video src="URL to your content">
    </video>
  </div>
  ```

  The following example shows how to establish a [MediaPlayer](https://github.com/Microsoft/TVHelpers/wiki/MediaPlayer-Overview) in JavaScript code.
  ``` javascript
  var mediaPlayerDiv = document.createElement("div");
  document.body.appendChild(mediaPlayerDiv);

  var videoElement = document.createElement("video");
  videoElement.src = "<URL to your content>";
  mediaPlayerDiv.appendChild(videoElement);

  var mediaPlayer = new TVJS.MediaPlayer(mediaPlayerDiv);
  ```

## How to use the AdScheduler class in your code

1. In Visual Studio, open your project or create a new project.

2. If your project targets **Any CPU**, update your project to use an architecture-specific build output (for example, **x86**). If your project targets **Any CPU**, you will not be able to successfully add a reference to the Microsoft advertising library in the following steps. For more information, see [Reference errors caused by targeting Any CPU in your project](known-issues-for-the-advertising-libraries.md#reference_errors).

3. Add a reference to the **Microsoft Advertising SDK for JavaScript** library to your project.

  a. From the **Solution Explorer** window, right click **References**, and select **Add Reference…**

  b. In **Reference Manager**, expand **Universal Windows**, click **Extensions**, and then select the check box next to **Microsoft Advertising SDK for JavaScript** (Version 10.0).

  c. In **Reference Manager**, click OK.

4.  Add the AdScheduler.js file to your project:

  a.  In Visual Studio, click **Project** and **Manage NuGet Packages**.

  b.  In the search box, type **Microsoft.StoreServices.VideoAdScheduler** and install the Microsoft.StoreServices.VideoAdScheduler package. The AdScheduler.js file is added to the ../js subdirectory in your project.

5.  Open the default.html file (or other html file as appropriate for your project). In the `<head>` section, after the project’s JavaScript references of default.css and default.js, add the reference to ad.js and adscheduler.js.

    ``` html
    <script src="//Microsoft.Advertising.JavaScript/ad.js"></script>
    <script src="/js/adscheduler.js"></script>
    ```

    > **Note**   This line must be placed in the `<head>` section after the include of default.js; otherwise, you will encounter an error when you build your project.

6.  In the default.js file in your project, add code that creates a new [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) object. Pass in the **MediaPlayer** that hosts your video content. The code must be placed so that it runs after [WinJS.UI.processAll](https://msdn.microsoft.com/library/windows/apps/hh440975.aspx).

    ``` javascript
    var myMediaPlayer = document.getElementById("MediaPlayerDiv");
    var myAdScheduler = new MicrosoftNSJS.Advertising.AdScheduler(myMediaPlayer);
    ```

7.  Use the [requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) or [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx) methods to request an ad schedule from the server and insert it into the **MediaPlayer** timeline, and then play the video media.

  * If you are a Microsoft partner who has received permission to request an ad schedule from the Microsoft ad server, use [requestSchedule](https://msdn.microsoft.com/library/windows/apps/mt732208.aspx) and specify the application ID and ad unit ID that were provided to you by your Microsoft representative. This method takes the form of a **Promise**, which is an asynchronous construct where two function pointers are passed to handle the success and failure cases, respectively. For more information, see [Asynchronous patterns in UWP using JavaScript](https://msdn.microsoft.com/windows/uwp/threading-async/asynchronous-programming-universal-windows-platform-apps#asynchronous-patterns-in-uwp-using-javascript).

      ``` javascript
  myAdScheduler.requestSchedule("your application ID", "your ad unit ID").then(
        function promiseSuccessHandler(schedule) {
           // Success: play the video content with the scheduled ads.
           myMediaPlayer.tvControl.play();
        },
        function promiseErrorHandler(err) {
           // Error: play the video content without the ads.
           myMediaPlayer.tvControl.play();
        });
  ```

  * To request an ad schedule from a non-Microsoft ad server, use [requestScheduleByUrl](https://msdn.microsoft.com/library/windows/apps/mt732210.aspx), and pass in the server URL. This method also takes the form of a **Promise**.

      ``` javascript
  myAdScheduler.requestScheduleByUrl("your URL").then(
        function promiseSuccessHandler(schedule) {
            // Success: play the video content with the scheduled ads.
            myMediaPlayer.winControl.play();
        },
        function promiseErrorHandler(evt) {
            // Error: play the video content without the ads.
             myMediaPlayer.winControl.play();
        });
  ```

  >**Note**&nbsp;&nbsp;You must call **play** even if the function fails, because the [AdScheduler](https://msdn.microsoft.com/library/windows/apps/mt732197.aspx) will tell the **MediaPlayer** to skip the ad(s) and move straight to the content. You may have a different business requirement, such as inserting a built-in ad if an ad can't be successfully fetched remotely.

8.  During playback, additional events exist that let your app track progress and/or errors which may occur after the initial ad matching process. The following code shows some of these events.
  * [onPodStart](https://msdn.microsoft.com/library/windows/apps/mt732206.aspx):

      ```javascript
      // Raised when an ad pod starts. Make the countdown timer visible.
      myAdScheduler.onPodStart = function (sender, data) {
          myCounterDiv.style.visibility= "visible";
      }  
      ```

  * [onPodEnd](https://msdn.microsoft.com/library/windows/apps/mt732205.aspx):

      ```javascript
      // Raised when an ad pod ends. Hide the countdown timer.
      myAdScheduler.onPodEnd = function (sender, data) {
          myCounterDiv.style.visibility= "hidden";
      }
      ```

  * [onPodCountdown](https://msdn.microsoft.com/library/windows/apps/mt732204.aspx):

      ```javascript
      // Raised when an ad is playing and indicates how many seconds remain in the current pod of ads. This is useful when the app wants to show a visual countdown until the video content resumes.
      myAdScheduler.onPodCountdown = function (sender, data) {
            myCounterText     = "Content resumes in: " +
            Math.ceil(data.remainingPodTime) + " seconds.";
      }  
      ```

  * [onAdProgress](https://msdn.microsoft.com/library/windows/apps/mt732201.aspx):

      ```javascript
      // Raised during each quartile of progress through the ad clip.
      myAdScheduler.onAdProgress = function (sender, data) {
      }
      ```

  * [onAllComplete](https://msdn.microsoft.com/library/windows/apps/mt732202.aspx):

      ```javascript
      // Raised when the ads and content are complete.
      myAdScheduler.onAllComplete = function (sender) {
      }
      ```

  * [onErrorOccurred](https://msdn.microsoft.com/library/windows/apps/mt732203.aspx):

      ```javascript
      // Raised when an error occurs during playback after successfully scheduling.
      myAdScheduler.onErrorOccurred = function (sender, data) {
      }
      ```
