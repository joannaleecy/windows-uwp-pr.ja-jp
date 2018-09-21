---
author: TylerMSFT
title: マルチインスタンスのユニバーサル Windows アプリの作成
description: このトピックでは、マルチインスタンスをサポートする UWP アプリを記述する方法について説明します。
keywords: マルチインスタンス UWP
ms.author: twhitney
ms.date: 09/19/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
ms.localizationpriority: medium
ms.openlocfilehash: 9302ed0375739153eb95ac2b54c1ed396b14daee
ms.sourcegitcommit: 5dda01da4702cbc49c799c750efe0e430b699502
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/21/2018
ms.locfileid: "4113236"
---
# <a name="create-a-multi-instance-universal-windows-app"></a><span data-ttu-id="cd359-104">マルチインスタンスのユニバーサル Windows アプリの作成</span><span class="sxs-lookup"><span data-stu-id="cd359-104">Create a multi-instance Universal Windows App</span></span>

<span data-ttu-id="cd359-105">このトピックでは、マルチインスタンスのユニバーサル Windows プラットフォーム (UWP) アプリを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="cd359-105">This topic describes how to create multi-instance Universal Windows Platform (UWP) apps.</span></span>

<span data-ttu-id="cd359-106">Windows 10、バージョン 1803 (10.0; からビルド 17134)、UWP アプリは複数のインスタンスをサポートするためにオプトイン以降、します。</span><span class="sxs-lookup"><span data-stu-id="cd359-106">From Windows 10, version 1803 (10.0; Build 17134) onward, your UWP app can opt in to support multiple instances.</span></span> <span data-ttu-id="cd359-107">マルチインスタンス UWP アプリのインスタンスが実行されていて、後続のライセンス認証要求が行われた場合、既存のインスタンスはアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="cd359-107">If an instance of an multi-instance UWP app is running, and a subsequent activation request comes through, the platform will not activate the existing instance.</span></span> <span data-ttu-id="cd359-108">代わりに、別のプロセスで実行される、新しいインスタンスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="cd359-108">Instead, it will create a new instance, running in a separate process.</span></span>

## <a name="opt-in-to-multi-instance-behavior"></a><span data-ttu-id="cd359-109">マルチ インスタンスの動作にオプトインします。</span><span class="sxs-lookup"><span data-stu-id="cd359-109">Opt in to multi-instance behavior</span></span>

<span data-ttu-id="cd359-110">新しいマルチインスタンス アプリケーションを作成する場合は、[Visual Studio Marketplace](https://aka.ms/E2nzbv) から入手可能な **Multi-Instance App Project Templates.VSIX** をインストールします。</span><span class="sxs-lookup"><span data-stu-id="cd359-110">If you are creating a new multi-instance application, you can install the **Multi-Instance App Project Templates.VSIX**, available from the [Visual Studio Marketplace](https://aka.ms/E2nzbv).</span></span> <span data-ttu-id="cd359-111">テンプレートをインストールすると、**[Visual C#] > [Windows ユニバーサル]** の **[新しいプロジェクト]** ダイアログ (または **[他の言語] > [Visual C++] > [Windows ユニバーサル]**) で使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="cd359-111">Once you install the templates, they will be available in the **New Project** dialog under **Visual C# > Windows Universal** (or **Other Languages > Visual C++ > Windows Universal**).</span></span>

<span data-ttu-id="cd359-112">2 つのテンプレートがインストールされます。**Multi-Instance UWP app** は、マルチインスタンス アプリを作成するためのテンプレートを提供します。**Multi-Instance Redirection UWP app** は、新しいインスタンスを起動するか、すでに起動されているインスタンスを選択的にアクティブ化するために構築する追加ロジックを提供します。</span><span class="sxs-lookup"><span data-stu-id="cd359-112">Two templates are installed: **Multi-Instance UWP app**, which provides the template for creating a multi-instance app, and **Multi-Instance Redirection UWP app**, which provides additional logic that you can build on to either launch a new instance or selectively activate an instance that has already been launched.</span></span> <span data-ttu-id="cd359-113">たとえば、一度に 1 つのインスタンスのみを同じドキュメントを編集する場合は、新しいインスタンスを起動するのではなく、そのファイルを開いているインスタンスをフォアグラウンドにします。</span><span class="sxs-lookup"><span data-stu-id="cd359-113">For example, perhaps you only want once instance at a time editing the same document, so you bring the instance that has that file open to the foreground rather than launching a new instance.</span></span>

<span data-ttu-id="cd359-114">どちらのテンプレートの追加`SupportsMultipleInstances`を`package.appxmanifest`ファイル。</span><span class="sxs-lookup"><span data-stu-id="cd359-114">Both templates add `SupportsMultipleInstances` to the `package.appxmanifest` file.</span></span> <span data-ttu-id="cd359-115">名前空間のプレフィックスに注意してください`desktop4`と`iot2`: デスクトップをターゲットとする唯一のプロジェクトまたはモ ノのインターネット (IoT) プロジェクトでは、マルチ インスタンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="cd359-115">Note the namespace prefix `desktop4` and `iot2`: only projects that target the desktop, or Internet of Things (IoT) projects, support multi-instancing.</span></span>

```xml
<Package
  ...
  xmlns:desktop4="http://schemas.microsoft.com/appx/manifest/desktop/windows10/4"
  xmlns:iot2="http://schemas.microsoft.com/appx/manifest/iot/windows10/2"  
  IgnorableNamespaces="uap mp desktop4 iot2">
  ...
  <Applications>
    <Application Id="App"
      ...
      desktop4:SupportsMultipleInstances="true"
      iot2:SupportsMultipleInstances="true">
      ...
    </Application>
  </Applications>
   ...
</Package>
```

## <a name="multi-instance-activation-redirection"></a><span data-ttu-id="cd359-116">マルチインスタンスアクティブ化のリダイレクト</span><span class="sxs-lookup"><span data-stu-id="cd359-116">Multi-instance activation redirection</span></span>

 <span data-ttu-id="cd359-117">UWP アプリのマルチインスタンス化のサポートは、単に複数のアプリ インスタンスを起動することを可能にするだけではありません。</span><span class="sxs-lookup"><span data-stu-id="cd359-117">Multi-instancing support for UWP apps goes beyond simply making it possible to launch multiple instances of the app.</span></span> <span data-ttu-id="cd359-118">アプリの新しいインスタンスを起動するか、すでに実行しているインスタンスをアクティブにするかを選択する場合に、カスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="cd359-118">It allows for customization in cases where you want to select whether a new instance of your app is launched or an instance that is already running is activated.</span></span> <span data-ttu-id="cd359-119">たとえば、既に別のインスタンスで編集中のファイルを編集するためにアプリが起動されている場合、そのファイルを編集している別のインスタンスを開くのではなく、そのインスタンスにアクティブ化をリダイレクトすることができます。</span><span class="sxs-lookup"><span data-stu-id="cd359-119">For example, if the app is launched to edit a file that is already being edited in another instance, you may want to redirect the activation to that instance instead of opening up another instance that  that is already editing the file.</span></span>

<span data-ttu-id="cd359-120">アクションの表示は、マルチ インスタンス UWP アプリの作成に関するこのビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="cd359-120">To see it in action, watch this video about Creating multi-instance UWP apps.</span></span>

> [!VIDEO https://www.youtube.com/embed/clnnf4cigd0]

<span data-ttu-id="cd359-121">**Multi-Instance Redirection UWP app** テンプレートは、上記のように `SupportsMultipleInstances` を package.appxmanifest ファイルに追加し、さらに `Main()` 関数を含むプロジェクトに **Program.cs** (または、テンプレートの C++ バージョンを使用している場合は **Program.cpp**) を追加します。</span><span class="sxs-lookup"><span data-stu-id="cd359-121">The **Multi-Instance Redirection UWP app** template adds `SupportsMultipleInstances` to the package.appxmanifest file as shown above, and also adds a **Program.cs** (or **Program.cpp**, if you are using the C++ version of the template) to your project that contains a `Main()` function.</span></span> <span data-ttu-id="cd359-122">アクティブ化をリダイレクトするためのロジックは `Main` 関数にあります。</span><span class="sxs-lookup"><span data-stu-id="cd359-122">The logic for redirecting activation goes in the `Main` function.</span></span> <span data-ttu-id="cd359-123">**Program.cs**用のテンプレートは、次に示します。</span><span class="sxs-lookup"><span data-stu-id="cd359-123">The template for **Program.cs** is shown below.</span></span>

<span data-ttu-id="cd359-124">[AppInstance.RecommendedInstance](/uwp/api/windows.applicationmodel.appinstance.recommendedinstance)を表すこのライセンス認証要求のシェルが提供する、推奨されるインスタンスが存在する場合 (または`null`かどうかではありません)。</span><span class="sxs-lookup"><span data-stu-id="cd359-124">The [AppInstance.RecommendedInstance](/uwp/api/windows.applicationmodel.appinstance.recommendedinstance) property represents the shell-provided preferred instance for this activation request, if there is one (or `null` if there isn't one).</span></span> <span data-ttu-id="cd359-125">シェルは、基本設定を提供する場合することができることができますのアクティブ化そのインスタンスにしたり、リダイレクトを選択した場合に無視することができます。</span><span class="sxs-lookup"><span data-stu-id="cd359-125">If the shell provides a preference, then you can can redirect activation to that instance, or you can ignore it if you choose.</span></span>

``` csharp
public static class Program
{
    // This example code shows how you could implement the required Main method to
    // support multi-instance redirection. The minimum requirement is to call
    // Application.Start with a new App object. Beyond that, you may delete the
    // rest of the example code and replace it with your custom code if you wish.

    static void Main(string[] args)
    {
        // First, we'll get our activation event args, which are typically richer
        // than the incoming command-line args. We can use these in our app-defined
        // logic for generating the key for this instance.
        IActivatedEventArgs activatedArgs = AppInstance.GetActivatedEventArgs();

        // If the Windows shell indicates a recommended instance, then
        // the app can choose to redirect this activation to that instance instead.
        if (AppInstance.RecommendedInstance != null)
        {
            AppInstance.RecommendedInstance.RedirectActivationTo();
        }
        else
        {
            // Define a key for this instance, based on some app-specific logic.
            // If the key is always unique, then the app will never redirect.
            // If the key is always non-unique, then the app will always redirect
            // to the first instance. In practice, the app should produce a key
            // that is sometimes unique and sometimes not, depending on its own needs.
            string key = Guid.NewGuid().ToString(); // always unique.
                                                    //string key = "Some-App-Defined-Key"; // never unique.
            var instance = AppInstance.FindOrRegisterInstanceForKey(key);
            if (instance.IsCurrentInstance)
            {
                // If we successfully registered this instance, we can now just
                // go ahead and do normal XAML initialization.
                global::Windows.UI.Xaml.Application.Start((p) => new App());
            }
            else
            {
                // Some other instance has registered for this key, so we'll 
                // redirect this activation to that instance instead.
                instance.RedirectActivationTo();
            }
        }
    }
}
```

`Main()` <span data-ttu-id="cd359-126">これは実行する最初のものです。</span><span class="sxs-lookup"><span data-stu-id="cd359-126">is the first thing that runs.</span></span> <span data-ttu-id="cd359-127">[OnLaunched()](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) と [OnActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnActivated_Windows_ApplicationModel_Activation_IActivatedEventArgs_) の前に実行します。</span><span class="sxs-lookup"><span data-stu-id="cd359-127">It runs before [OnLaunched()](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) and [OnActivated](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnActivated_Windows_ApplicationModel_Activation_IActivatedEventArgs_).</span></span> <span data-ttu-id="cd359-128">これにより、アプリの他の初期化コードが実行される前に、これをアクティブ化するか別のインスタンスをアクティブ化するかを決定できます。</span><span class="sxs-lookup"><span data-stu-id="cd359-128">This allows you to determine whether to activate this, or another instance, before any other initialization code in your app runs.</span></span>

<span data-ttu-id="cd359-129">上記のコードは、アプリケーションの既存のインスタンスまたは新しいインスタンスがアクティブになっているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="cd359-129">The code above determines whether an existing, or new, instance of your application is activated.</span></span> <span data-ttu-id="cd359-130">キーを使用して、アクティブ化する既存のインスタンスがあるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="cd359-130">A key is used to determine whether there is an existing instance that you want to activate.</span></span> <span data-ttu-id="cd359-131">たとえば、アプリを起動して [ファイルのアクティブ化の処理](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/handle-file-activation) ができる場合は、ファイル名をキーとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="cd359-131">For example, if your app can be launched to [Handle file activation](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/handle-file-activation), you might use the file name as a key.</span></span> <span data-ttu-id="cd359-132">次に、アプリのインスタンスがすでにそのキーに登録されているかどうかを確認し、新しいインスタンスを開く代わりにそれをアクティブにすることができます。</span><span class="sxs-lookup"><span data-stu-id="cd359-132">Then you can check whether an instance of your app is already registered with that key and activate it instead of opening a new instance.</span></span> <span data-ttu-id="cd359-133">これはコード ビハインド アイデアです。</span><span class="sxs-lookup"><span data-stu-id="cd359-133">This is the idea behind the code:</span></span> `var instance = AppInstance.FindOrRegisterInstanceForKey(key);`

<span data-ttu-id="cd359-134">キーに登録されているインスタンスが見つかった場合は、そのインスタンスがアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="cd359-134">If an instance registered with the key is found, then that instance is activated.</span></span> <span data-ttu-id="cd359-135">キーが見つからない場合は、現在のインスタンス (現在 `Main` を実行しているインスタンス) がそのアプリケーション オブジェクトを作成し、実行を開始します。</span><span class="sxs-lookup"><span data-stu-id="cd359-135">If the key is not found, then the current instance (the instance that is currently running `Main`) creates its application object  and starts running.</span></span>

## <a name="background-tasks-and-multi-instancing"></a><span data-ttu-id="cd359-136">バックグラウンド タスクとマルチインスタンス</span><span class="sxs-lookup"><span data-stu-id="cd359-136">Background tasks and multi-instancing</span></span>

- <span data-ttu-id="cd359-137">アウトプロセスのバックグラウンド タスクは、マルチインスタンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="cd359-137">Out-of-proc background tasks support multi-instancing.</span></span> <span data-ttu-id="cd359-138">通常、新しいトリガーはバックグラウンド タスクの新しいインスタンスを生成します (ただし、技術的には複数のバックグラウンド タスクが同じホスト プロセスで実行される可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="cd359-138">Typically, each new trigger results in a new instance of the background task (although technically speaking multiple background tasks may run in same host process).</span></span> <span data-ttu-id="cd359-139">それでも、バックグラウンド タスクの別のインスタンスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="cd359-139">Nevertheless, a different instance of the background task is created.</span></span>
- <span data-ttu-id="cd359-140">インプロセスのバックグラウンド タスクは、マルチインスタンスをサポートしません。</span><span class="sxs-lookup"><span data-stu-id="cd359-140">In-proc background tasks do not support multi-instancing.</span></span>
- <span data-ttu-id="cd359-141">バックグラウンドのオーディオ タスクは、マルチインスタンスをサポートしません。</span><span class="sxs-lookup"><span data-stu-id="cd359-141">Background audio tasks do not support multi-instancing.</span></span>
- <span data-ttu-id="cd359-142">アプリがバックグラウンド タスクを登録すると、通常、タスクがすでに登録されているかどうかを確認し、削除または再登録するか、既存の登録を維持するために何もしません。</span><span class="sxs-lookup"><span data-stu-id="cd359-142">When an app registers a background task, it usually first checks to see if the task is already registered and then either deletes and re-registers it, or does nothing in order to keep the existing registration.</span></span> <span data-ttu-id="cd359-143">これは、マルチインスタンス アプリの典型的な動作です。</span><span class="sxs-lookup"><span data-stu-id="cd359-143">This is still the typical behavior with multi-instance apps.</span></span> <span data-ttu-id="cd359-144">しかし、マルチインスタンス アプリでは、インスタンスごとに異なるバックグラウンド タスク名を登録することを選択する場合があります。</span><span class="sxs-lookup"><span data-stu-id="cd359-144">However, a multi-instancing app may choose to register a different background task name on a per-instance basis.</span></span> <span data-ttu-id="cd359-145">これにより、同じトリガーに対して複数の登録が行われ、トリガーが起動すると複数のバックグラウンド タスクのインスタンスがアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="cd359-145">This will result in multiple registrations for the same trigger, and multiple background task instances will be activated when the trigger fires.</span></span>
- <span data-ttu-id="cd359-146">アプリ サービスは、すべての接続に対してアプリ サービス バックグラウンド タスクの別のインスタンスを起動します。</span><span class="sxs-lookup"><span data-stu-id="cd359-146">App-services launch a separate instance of the app-service background task for every connection.</span></span> <span data-ttu-id="cd359-147">マルチインスタンス アプリの場合、これは変更されません。つまり、マルチインスタンス アプリの各インスタンスは、独自のアプリ サービス バックグラウンド タスクのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="cd359-147">This remains unchanged for multi-instance apps, that is each instance of a multi-instance app will get its own instance of the  app-service background task.</span></span> 

## <a name="additional-considerations"></a><span data-ttu-id="cd359-148">その他の考慮事項</span><span class="sxs-lookup"><span data-stu-id="cd359-148">Additional considerations</span></span>

- <span data-ttu-id="cd359-149">マルチ インスタンスは、デスクトップやモノのインターネット (IoT) プロジェクトをターゲットとする UWP アプリでサポートされています。</span><span class="sxs-lookup"><span data-stu-id="cd359-149">Multi-instancing is supported by UWP apps that target desktop and Internet of Things (IoT) projects.</span></span>
- <span data-ttu-id="cd359-150">競合状態や競合の問題を避けるため、マルチインスタンス アプリは、設定、アプリ ローカル ストレージ、その他のリソース (ユーザー ファイル、データストアなど) へのアクセスをパーティション化/同期化するための手順を実行する必要があります。これらのリソースは、複数のインスタンス間で共有できます。</span><span class="sxs-lookup"><span data-stu-id="cd359-150">To avoid race-conditions and contention issues, multi-instance apps need to take steps to partition/synchronize access to settings, app-local storage, and any other resource (such as user files, a data store, and so on) that can be shared among multiple instances.</span></span> <span data-ttu-id="cd359-151">ミューテックス、セマフォ、イベントなどの標準的な同期メカニズムが使用可能です。</span><span class="sxs-lookup"><span data-stu-id="cd359-151">Standard synchronization mechanisms such as mutexes, semaphores, events, and and so on, are available.</span></span>
- <span data-ttu-id="cd359-152">アプリで、Package.appxmanifest ファイルに `SupportsMultipleInstances` がある場合、その拡張機能は `SupportsMultipleInstances` を宣言する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="cd359-152">If the app has `SupportsMultipleInstances` in its Package.appxmanifest file, then its extensions do not need to declare `SupportsMultipleInstances`.</span></span> 
- <span data-ttu-id="cd359-153">`SupportsMultipleInstances` をバックグラウンド タスクやアプリ サービス以外の拡張機能に追加し、その拡張機能をホストするアプリが Package.appxmanifest ファイルで `SupportsMultipleInstances` を宣言しない場合は、スキーマ エラーが生成されます。</span><span class="sxs-lookup"><span data-stu-id="cd359-153">If you add `SupportsMultipleInstances` to any other extension, apart from background tasks or app-services, and the app that hosts the extension doesn't also declare `SupportsMultipleInstances` in its Package.appxmanifest file, then a schema error is generated.</span></span>
- <span data-ttu-id="cd359-154">アプリは、マニフェストに [ResourceGroup](https://docs.microsoft.com/windows/uwp/launch-resume/declare-background-tasks-in-the-application-manifest) 宣言を使用して、複数のバックグラウンド タスクを同じホストにグループ化することができます。</span><span class="sxs-lookup"><span data-stu-id="cd359-154">Apps can use the [ResourceGroup](https://docs.microsoft.com/windows/uwp/launch-resume/declare-background-tasks-in-the-application-manifest) declaration in their manifest to group multiple background tasks into the same host.</span></span> <span data-ttu-id="cd359-155">これはマルチインスタンスと競合し、それぞれのアクティブ化は別々のホストに入ります。</span><span class="sxs-lookup"><span data-stu-id="cd359-155">This conflicts with multi-instancing, where each activation goes into a separate host.</span></span> <span data-ttu-id="cd359-156">したがって、アプリはマニフェストで `SupportsMultipleInstances` と `ResourceGroup` の両方を宣言することはできません。</span><span class="sxs-lookup"><span data-stu-id="cd359-156">Therefore an app cannot declare both `SupportsMultipleInstances` and `ResourceGroup` in their manifest.</span></span>

## <a name="sample"></a><span data-ttu-id="cd359-157">サンプル</span><span class="sxs-lookup"><span data-stu-id="cd359-157">Sample</span></span>

<span data-ttu-id="cd359-158">マルチ インスタンス化のリダイレクトの例については、[マルチ インスタンスのサンプル](https://aka.ms/Kcrqst)を参照してください。</span><span class="sxs-lookup"><span data-stu-id="cd359-158">See [Multi-Instance sample](https://aka.ms/Kcrqst) for an example of multi-instance activation redirection.</span></span>

## <a name="see-also"></a><span data-ttu-id="cd359-159">関連項目</span><span class="sxs-lookup"><span data-stu-id="cd359-159">See also</span></span>

<span data-ttu-id="cd359-160">[AppInstance.FindOrRegisterInstanceForKey](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_FindOrRegisterInstanceForKey_System_String_)
[AppInstance.GetActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_GetActivatedEventArgs)
[AppInstance.RedirectActivationTo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_RedirectActivationTo)
[アプリのアクティブ化の処理](https://docs.microsoft.com/windows/uwp/launch-resume/activate-an-app)</span><span class="sxs-lookup"><span data-stu-id="cd359-160">[AppInstance.FindOrRegisterInstanceForKey](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_FindOrRegisterInstanceForKey_System_String_)
[AppInstance.GetActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_GetActivatedEventArgs)
[AppInstance.RedirectActivationTo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_RedirectActivationTo)
[Handle app activation](https://docs.microsoft.com/windows/uwp/launch-resume/activate-an-app)</span></span>