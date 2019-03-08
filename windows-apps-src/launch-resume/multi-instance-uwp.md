---
title: マルチインスタンスのユニバーサル Windows アプリの作成
description: このトピックでは、マルチインスタンスをサポートする UWP アプリを記述する方法について説明します。
keywords: マルチインスタンス UWP
ms.date: 09/21/2018
ms.topic: article
ms.localizationpriority: medium
ms.openlocfilehash: 89ffa2f3480664131af6664988bd9fb31687fe32
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57600307"
---
# <a name="create-a-multi-instance-universal-windows-app"></a><span data-ttu-id="8daf9-104">マルチインスタンスのユニバーサル Windows アプリの作成</span><span class="sxs-lookup"><span data-stu-id="8daf9-104">Create a multi-instance Universal Windows App</span></span>

<span data-ttu-id="8daf9-105">このトピックでは、マルチインスタンスのユニバーサル Windows プラットフォーム (UWP) アプリを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-105">This topic describes how to create multi-instance Universal Windows Platform (UWP) apps.</span></span>

<span data-ttu-id="8daf9-106">Windows 10、バージョン 1803 (10.0; から17134 をビルドする)、UWP アプリは複数のインスタンスをサポートするためにオプトイン以降、します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-106">From Windows 10, version 1803 (10.0; Build 17134) onward, your UWP app can opt in to support multiple instances.</span></span> <span data-ttu-id="8daf9-107">マルチインスタンス UWP アプリのインスタンスが実行されていて、後続のライセンス認証要求が行われた場合、既存のインスタンスはアクティブ化されません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-107">If an instance of an multi-instance UWP app is running, and a subsequent activation request comes through, the platform will not activate the existing instance.</span></span> <span data-ttu-id="8daf9-108">代わりに、別のプロセスで実行される、新しいインスタンスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-108">Instead, it will create a new instance, running in a separate process.</span></span>

> [!IMPORTANT]
> <span data-ttu-id="8daf9-109">JavaScript アプリケーションでは、複数インスタンスがサポートされていますが、リダイレクトの複数インスタンスがないです。</span><span class="sxs-lookup"><span data-stu-id="8daf9-109">Multi-instancing is supported for JavaScript applications, but multi-instancing redirection is not.</span></span> <span data-ttu-id="8daf9-110">JavaScript アプリケーションでは、複数インスタンスのリダイレクトがサポートされていないため、 [ **AppInstance** ](/uwp/api/windows.applicationmodel.appinstance)クラスはこのようなアプリケーションに適していません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-110">Since multi-instancing redirection is not supported for JavaScript applications, the [**AppInstance**](/uwp/api/windows.applicationmodel.appinstance) class is not useful for such applications.</span></span>

## <a name="opt-in-to-multi-instance-behavior"></a><span data-ttu-id="8daf9-111">マルチ インスタンスの動作を選択します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-111">Opt in to multi-instance behavior</span></span>

<span data-ttu-id="8daf9-112">新しいマルチインスタンス アプリケーションを作成する場合は、[Visual Studio Marketplace](https://aka.ms/E2nzbv) から入手可能な **Multi-Instance App Project Templates.VSIX** をインストールします。</span><span class="sxs-lookup"><span data-stu-id="8daf9-112">If you are creating a new multi-instance application, you can install the **Multi-Instance App Project Templates.VSIX**, available from the [Visual Studio Marketplace](https://aka.ms/E2nzbv).</span></span> <span data-ttu-id="8daf9-113">テンプレートをインストールすると、**[Visual C#] > [Windows ユニバーサル]** の **[新しいプロジェクト]** ダイアログ (または **[他の言語] > [Visual C++] > [Windows ユニバーサル]**) で使用可能になります。</span><span class="sxs-lookup"><span data-stu-id="8daf9-113">Once you install the templates, they will be available in the **New Project** dialog under **Visual C# > Windows Universal** (or **Other Languages > Visual C++ > Windows Universal**).</span></span>

<span data-ttu-id="8daf9-114">2 つのテンプレートがインストールされます。**UWP アプリのマルチ インスタンス**、マルチ インスタンスのアプリを作成するため、テンプレートを提供して**マルチ インスタンスのリダイレクトの UWP アプリ**を起動する新しいインスタンスを作成できる追加のロジックを提供する、または選択的には既に起動しているインスタンスをアクティブにします。</span><span class="sxs-lookup"><span data-stu-id="8daf9-114">Two templates are installed: **Multi-Instance UWP app**, which provides the template for creating a multi-instance app, and **Multi-Instance Redirection UWP app**, which provides additional logic that you can build on to either launch a new instance or selectively activate an instance that has already been launched.</span></span> <span data-ttu-id="8daf9-115">例: おそらく、同じドキュメントの編集時に 1 つのインスタンスのみする、新しいインスタンスを起動するのではなく、フォア グラウンドがそのファイルをあるインスタンスを開くようにします。</span><span class="sxs-lookup"><span data-stu-id="8daf9-115">For example, perhaps you only want one instance at a time editing the same document, so you bring the instance that has that file open to the foreground rather than launching a new instance.</span></span>

<span data-ttu-id="8daf9-116">両方のテンプレートの追加`SupportsMultipleInstances`を`package.appxmanifest`ファイル。</span><span class="sxs-lookup"><span data-stu-id="8daf9-116">Both templates add `SupportsMultipleInstances` to the `package.appxmanifest` file.</span></span> <span data-ttu-id="8daf9-117">名前空間プレフィックスに注意してください`desktop4`と`iot2`: デスクトップを対象とする唯一のプロジェクトやモ ノのインターネット (IoT) プロジェクトでは、複数インスタンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="8daf9-117">Note the namespace prefix `desktop4` and `iot2`: only projects that target the desktop, or Internet of Things (IoT) projects, support multi-instancing.</span></span>

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

## <a name="multi-instance-activation-redirection"></a><span data-ttu-id="8daf9-118">マルチインスタンスアクティブ化のリダイレクト</span><span class="sxs-lookup"><span data-stu-id="8daf9-118">Multi-instance activation redirection</span></span>

 <span data-ttu-id="8daf9-119">UWP アプリのマルチインスタンス化のサポートは、単に複数のアプリ インスタンスを起動することを可能にするだけではありません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-119">Multi-instancing support for UWP apps goes beyond simply making it possible to launch multiple instances of the app.</span></span> <span data-ttu-id="8daf9-120">アプリの新しいインスタンスを起動するか、すでに実行しているインスタンスをアクティブにするかを選択する場合に、カスタマイズできます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-120">It allows for customization in cases where you want to select whether a new instance of your app is launched or an instance that is already running is activated.</span></span> <span data-ttu-id="8daf9-121">たとえば、既に別のインスタンスで編集中のファイルを編集するためにアプリが起動されている場合、そのファイルを編集している別のインスタンスを開くのではなく、そのインスタンスにアクティブ化をリダイレクトすることができます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-121">For example, if the app is launched to edit a file that is already being edited in another instance, you may want to redirect the activation to that instance instead of opening up another instance that  that is already editing the file.</span></span>

<span data-ttu-id="8daf9-122">動作の確認、UWP アプリのマルチ インスタンスの作成に関するこのビデオをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8daf9-122">To see it in action, watch this video about Creating multi-instance UWP apps.</span></span>

> [!VIDEO https://www.youtube.com/embed/clnnf4cigd0]

<span data-ttu-id="8daf9-123">**Multi-Instance Redirection UWP app** テンプレートは、上記のように `SupportsMultipleInstances` を package.appxmanifest ファイルに追加し、さらに `Main()` 関数を含むプロジェクトに **Program.cs** (または、テンプレートの C++ バージョンを使用している場合は **Program.cpp**) を追加します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-123">The **Multi-Instance Redirection UWP app** template adds `SupportsMultipleInstances` to the package.appxmanifest file as shown above, and also adds a **Program.cs** (or **Program.cpp**, if you are using the C++ version of the template) to your project that contains a `Main()` function.</span></span> <span data-ttu-id="8daf9-124">アクティブ化をリダイレクトするためのロジックは `Main` 関数にあります。</span><span class="sxs-lookup"><span data-stu-id="8daf9-124">The logic for redirecting activation goes in the `Main` function.</span></span> <span data-ttu-id="8daf9-125">テンプレートを**Program.cs**を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-125">The template for **Program.cs** is shown below.</span></span>

<span data-ttu-id="8daf9-126">[ **AppInstance.RecommendedInstance** ](/uwp/api/windows.applicationmodel.appinstance.recommendedinstance)プロパティは、1 つを使用する必要がある場合、このアクティブ化要求のシェルで提供される優先インスタンスを表します (または`null`かどうかではありません)。</span><span class="sxs-lookup"><span data-stu-id="8daf9-126">The [**AppInstance.RecommendedInstance**](/uwp/api/windows.applicationmodel.appinstance.recommendedinstance) property represents the shell-provided preferred instance for this activation request, if there is one (or `null` if there isn't one).</span></span> <span data-ttu-id="8daf9-127">シェルでは、基本設定を提供する場合、このインスタンスのライセンス認証をリダイレクトできます。 または選択した場合は無視できます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-127">If the shell provides a preference, then you can redirect activation to that instance, or you can ignore it if you choose.</span></span>

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

<span data-ttu-id="8daf9-128">`Main()` 実行する最初のものです。</span><span class="sxs-lookup"><span data-stu-id="8daf9-128">`Main()` is the first thing that runs.</span></span> <span data-ttu-id="8daf9-129">実行する前に[ **OnLaunched** ](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_)と[ **OnActivated**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnActivated_Windows_ApplicationModel_Activation_IActivatedEventArgs_)します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-129">It runs before [**OnLaunched**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnLaunched_Windows_ApplicationModel_Activation_LaunchActivatedEventArgs_) and [**OnActivated**](https://docs.microsoft.com/uwp/api/windows.ui.xaml.application#Windows_UI_Xaml_Application_OnActivated_Windows_ApplicationModel_Activation_IActivatedEventArgs_).</span></span> <span data-ttu-id="8daf9-130">これにより、アプリの他の初期化コードが実行される前に、これをアクティブ化するか別のインスタンスをアクティブ化するかを決定できます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-130">This allows you to determine whether to activate this, or another instance, before any other initialization code in your app runs.</span></span>

<span data-ttu-id="8daf9-131">上記のコードは、アプリケーションの既存のインスタンスまたは新しいインスタンスがアクティブになっているかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-131">The code above determines whether an existing, or new, instance of your application is activated.</span></span> <span data-ttu-id="8daf9-132">キーを使用して、アクティブ化する既存のインスタンスがあるかどうかを判断します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-132">A key is used to determine whether there is an existing instance that you want to activate.</span></span> <span data-ttu-id="8daf9-133">たとえば、アプリを起動して [ファイルのアクティブ化の処理](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/handle-file-activation) ができる場合は、ファイル名をキーとして使用できます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-133">For example, if your app can be launched to [Handle file activation](https://docs.microsoft.com/en-us/windows/uwp/launch-resume/handle-file-activation), you might use the file name as a key.</span></span> <span data-ttu-id="8daf9-134">次に、アプリのインスタンスがすでにそのキーに登録されているかどうかを確認し、新しいインスタンスを開く代わりにそれをアクティブにすることができます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-134">Then you can check whether an instance of your app is already registered with that key and activate it instead of opening a new instance.</span></span> <span data-ttu-id="8daf9-135">これは、コードの考え方です。 `var instance = AppInstance.FindOrRegisterInstanceForKey(key);`</span><span class="sxs-lookup"><span data-stu-id="8daf9-135">This is the idea behind the code: `var instance = AppInstance.FindOrRegisterInstanceForKey(key);`</span></span>

<span data-ttu-id="8daf9-136">キーに登録されているインスタンスが見つかった場合は、そのインスタンスがアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="8daf9-136">If an instance registered with the key is found, then that instance is activated.</span></span> <span data-ttu-id="8daf9-137">キーが見つからない場合は、現在のインスタンス (現在 `Main` を実行しているインスタンス) がそのアプリケーション オブジェクトを作成し、実行を開始します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-137">If the key is not found, then the current instance (the instance that is currently running `Main`) creates its application object  and starts running.</span></span>

## <a name="background-tasks-and-multi-instancing"></a><span data-ttu-id="8daf9-138">バックグラウンド タスクとマルチインスタンス</span><span class="sxs-lookup"><span data-stu-id="8daf9-138">Background tasks and multi-instancing</span></span>

- <span data-ttu-id="8daf9-139">アウトプロセスのバックグラウンド タスクは、マルチインスタンスをサポートします。</span><span class="sxs-lookup"><span data-stu-id="8daf9-139">Out-of-proc background tasks support multi-instancing.</span></span> <span data-ttu-id="8daf9-140">通常、新しいトリガーはバックグラウンド タスクの新しいインスタンスを生成します (ただし、技術的には複数のバックグラウンド タスクが同じホスト プロセスで実行される可能性があります)。</span><span class="sxs-lookup"><span data-stu-id="8daf9-140">Typically, each new trigger results in a new instance of the background task (although technically speaking multiple background tasks may run in same host process).</span></span> <span data-ttu-id="8daf9-141">それでも、バックグラウンド タスクの別のインスタンスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-141">Nevertheless, a different instance of the background task is created.</span></span>
- <span data-ttu-id="8daf9-142">インプロセスのバックグラウンド タスクは、マルチインスタンスをサポートしません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-142">In-proc background tasks do not support multi-instancing.</span></span>
- <span data-ttu-id="8daf9-143">バックグラウンドのオーディオ タスクは、マルチインスタンスをサポートしません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-143">Background audio tasks do not support multi-instancing.</span></span>
- <span data-ttu-id="8daf9-144">アプリがバックグラウンド タスクを登録すると、通常、タスクがすでに登録されているかどうかを確認し、削除または再登録するか、既存の登録を維持するために何もしません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-144">When an app registers a background task, it usually first checks to see if the task is already registered and then either deletes and re-registers it, or does nothing in order to keep the existing registration.</span></span> <span data-ttu-id="8daf9-145">これは、マルチインスタンス アプリの典型的な動作です。</span><span class="sxs-lookup"><span data-stu-id="8daf9-145">This is still the typical behavior with multi-instance apps.</span></span> <span data-ttu-id="8daf9-146">しかし、マルチインスタンス アプリでは、インスタンスごとに異なるバックグラウンド タスク名を登録することを選択する場合があります。</span><span class="sxs-lookup"><span data-stu-id="8daf9-146">However, a multi-instancing app may choose to register a different background task name on a per-instance basis.</span></span> <span data-ttu-id="8daf9-147">これにより、同じトリガーに対して複数の登録が行われ、トリガーが起動すると複数のバックグラウンド タスクのインスタンスがアクティブになります。</span><span class="sxs-lookup"><span data-stu-id="8daf9-147">This will result in multiple registrations for the same trigger, and multiple background task instances will be activated when the trigger fires.</span></span>
- <span data-ttu-id="8daf9-148">アプリ サービスは、すべての接続に対してアプリ サービス バックグラウンド タスクの別のインスタンスを起動します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-148">App-services launch a separate instance of the app-service background task for every connection.</span></span> <span data-ttu-id="8daf9-149">マルチインスタンス アプリの場合、これは変更されません。つまり、マルチインスタンス アプリの各インスタンスは、独自のアプリ サービス バックグラウンド タスクのインスタンスを取得します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-149">This remains unchanged for multi-instance apps, that is each instance of a multi-instance app will get its own instance of the  app-service background task.</span></span> 

## <a name="additional-considerations"></a><span data-ttu-id="8daf9-150">その他の考慮事項</span><span class="sxs-lookup"><span data-stu-id="8daf9-150">Additional considerations</span></span>

- <span data-ttu-id="8daf9-151">マルチ インスタンスは、デスクトップやモノのインターネット (IoT) プロジェクトをターゲットとする UWP アプリでサポートされています。</span><span class="sxs-lookup"><span data-stu-id="8daf9-151">Multi-instancing is supported by UWP apps that target desktop and Internet of Things (IoT) projects.</span></span>
- <span data-ttu-id="8daf9-152">競合状態や競合の問題を避けるため、マルチインスタンス アプリは、設定、アプリ ローカル ストレージ、その他のリソース (ユーザー ファイル、データストアなど) へのアクセスをパーティション化/同期化するための手順を実行する必要があります。これらのリソースは、複数のインスタンス間で共有できます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-152">To avoid race-conditions and contention issues, multi-instance apps need to take steps to partition/synchronize access to settings, app-local storage, and any other resource (such as user files, a data store, and so on) that can be shared among multiple instances.</span></span> <span data-ttu-id="8daf9-153">ミュー テックス、セマフォ、イベント、およびなどの標準的な同期機構を利用できます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-153">Standard synchronization mechanisms such as mutexes, semaphores, events, and so on, are available.</span></span>
- <span data-ttu-id="8daf9-154">アプリで、Package.appxmanifest ファイルに `SupportsMultipleInstances` がある場合、その拡張機能は `SupportsMultipleInstances` を宣言する必要はありません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-154">If the app has `SupportsMultipleInstances` in its Package.appxmanifest file, then its extensions do not need to declare `SupportsMultipleInstances`.</span></span> 
- <span data-ttu-id="8daf9-155">`SupportsMultipleInstances` をバックグラウンド タスクやアプリ サービス以外の拡張機能に追加し、その拡張機能をホストするアプリが Package.appxmanifest ファイルで `SupportsMultipleInstances` を宣言しない場合は、スキーマ エラーが生成されます。</span><span class="sxs-lookup"><span data-stu-id="8daf9-155">If you add `SupportsMultipleInstances` to any other extension, apart from background tasks or app-services, and the app that hosts the extension doesn't also declare `SupportsMultipleInstances` in its Package.appxmanifest file, then a schema error is generated.</span></span>
- <span data-ttu-id="8daf9-156">アプリが使用できる、 [ **ResourceGroup** ](https://docs.microsoft.com/windows/uwp/launch-resume/declare-background-tasks-in-the-application-manifest)同じホストに複数のバック グラウンド タスクをグループ化、マニフェストで宣言します。</span><span class="sxs-lookup"><span data-stu-id="8daf9-156">Apps can use the [**ResourceGroup**](https://docs.microsoft.com/windows/uwp/launch-resume/declare-background-tasks-in-the-application-manifest) declaration in their manifest to group multiple background tasks into the same host.</span></span> <span data-ttu-id="8daf9-157">これはマルチインスタンスと競合し、それぞれのアクティブ化は別々のホストに入ります。</span><span class="sxs-lookup"><span data-stu-id="8daf9-157">This conflicts with multi-instancing, where each activation goes into a separate host.</span></span> <span data-ttu-id="8daf9-158">したがって、アプリはマニフェストで `SupportsMultipleInstances` と `ResourceGroup` の両方を宣言することはできません。</span><span class="sxs-lookup"><span data-stu-id="8daf9-158">Therefore an app cannot declare both `SupportsMultipleInstances` and `ResourceGroup` in their manifest.</span></span>

## <a name="sample"></a><span data-ttu-id="8daf9-159">サンプル</span><span class="sxs-lookup"><span data-stu-id="8daf9-159">Sample</span></span>

<span data-ttu-id="8daf9-160">参照してください[マルチ インスタンス サンプル](https://aka.ms/Kcrqst)マルチ インスタンスのライセンス認証のリダイレクトの例についてはします。</span><span class="sxs-lookup"><span data-stu-id="8daf9-160">See [Multi-Instance sample](https://aka.ms/Kcrqst) for an example of multi-instance activation redirection.</span></span>

## <a name="see-also"></a><span data-ttu-id="8daf9-161">関連項目</span><span class="sxs-lookup"><span data-stu-id="8daf9-161">See also</span></span>

<span data-ttu-id="8daf9-162">[AppInstance.FindOrRegisterInstanceForKey](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_FindOrRegisterInstanceForKey_System_String_)
[AppInstance.GetActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_GetActivatedEventArgs)
[AppInstance.RedirectActivationTo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_RedirectActivationTo)
[アプリのアクティブ化の処理](https://docs.microsoft.com/windows/uwp/launch-resume/activate-an-app)</span><span class="sxs-lookup"><span data-stu-id="8daf9-162">[AppInstance.FindOrRegisterInstanceForKey](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_FindOrRegisterInstanceForKey_System_String_)
[AppInstance.GetActivatedEventArgs](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_GetActivatedEventArgs)
[AppInstance.RedirectActivationTo](https://docs.microsoft.com/uwp/api/windows.applicationmodel.appinstance#Windows_ApplicationModel_AppInstance_RedirectActivationTo)
[Handle app activation](https://docs.microsoft.com/windows/uwp/launch-resume/activate-an-app)</span></span>
