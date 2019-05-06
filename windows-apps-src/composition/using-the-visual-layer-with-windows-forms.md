---
title: Windows フォームでのビジュアル層の使用
description: 既存の Windows フォームのコンテンツと組み合わせてビジュアル層の Api を使用して、高度なアニメーションや効果を作成するための手法について説明します。
ms.date: 03/18/2019
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: eef07c1088315871b558464aff4b1719cdd63962
ms.sourcegitcommit: e63fbd7a63a7e8c03c52f4219f34513f4b2bb411
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/18/2019
ms.locfileid: "58174125"
---
# <a name="using-the-visual-layer-with-windows-forms"></a><span data-ttu-id="b2a95-104">Windows フォームでのビジュアル層の使用</span><span class="sxs-lookup"><span data-stu-id="b2a95-104">Using the Visual Layer with Windows Forms</span></span>

<span data-ttu-id="b2a95-105">Windows ランタイムの合成 Api を使用することができます (とも呼ばれる、[ビジュアル層](visual-layer.md)) で、Windows フォーム アプリで Windows 10 のユーザー用に光を最新のエクスペリエンスを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-105">You can use Windows Runtime Composition APIs (also called the [Visual layer](visual-layer.md)) in your Windows Forms apps to create modern experiences that light up for Windows 10 users.</span></span>

<span data-ttu-id="b2a95-106">このチュートリアルの完成したコードは GitHub で入手できます。[Windows フォーム HelloComposition サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/HelloComposition)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-106">The complete code for this tutorial is available on GitHub: [Windows Forms HelloComposition sample](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/HelloComposition).</span></span>

## <a name="prerequisites"></a><span data-ttu-id="b2a95-107">前提条件</span><span class="sxs-lookup"><span data-stu-id="b2a95-107">Prerequisites</span></span>

<span data-ttu-id="b2a95-108">UWP API をホストしているが、これらの前提条件です。</span><span class="sxs-lookup"><span data-stu-id="b2a95-108">The UWP hosting API has these prerequisites.</span></span>

- <span data-ttu-id="b2a95-109">Windows フォーム、UWP を使用してアプリ開発の知識があると仮定します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-109">We assume that you have some familiarity with app development using Windows Forms and UWP.</span></span> <span data-ttu-id="b2a95-110">For more info, see:</span><span class="sxs-lookup"><span data-stu-id="b2a95-110">For more info, see:</span></span>
  - [<span data-ttu-id="b2a95-111">Windows フォームの概要</span><span class="sxs-lookup"><span data-stu-id="b2a95-111">Getting Started with Windows Forms</span></span>](/dotnet/framework/winforms/getting-started-with-windows-forms)
  - [<span data-ttu-id="b2a95-112">Windows 10 アプリを概要します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-112">Get started with Windows 10 apps</span></span>](/windows/uwp/get-started/)
  - [<span data-ttu-id="b2a95-113">Windows 10 のデスクトップ アプリケーションを拡張します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-113">Enhance your desktop application for Windows 10</span></span>](/windows/uwp/porting/desktop-to-uwp-enhance)
- <span data-ttu-id="b2a95-114">.NET framework 4.7.2 以降</span><span class="sxs-lookup"><span data-stu-id="b2a95-114">.NET Framework 4.7.2 or later</span></span>
- <span data-ttu-id="b2a95-115">Windows 10 バージョン 1803 以降</span><span class="sxs-lookup"><span data-stu-id="b2a95-115">Windows 10 version 1803 or later</span></span>
- <span data-ttu-id="b2a95-116">Windows 10 SDK 17134 またはそれ以降</span><span class="sxs-lookup"><span data-stu-id="b2a95-116">Windows 10 SDK 17134 or later</span></span>

## <a name="how-to-use-composition-apis-in-windows-forms"></a><span data-ttu-id="b2a95-117">Windows フォームで合成 Api を使用する方法</span><span class="sxs-lookup"><span data-stu-id="b2a95-117">How to use Composition APIs in Windows Forms</span></span>

<span data-ttu-id="b2a95-118">このチュートリアルでは、単純な Windows フォームの UI を作成し、アニメーションの合成要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-118">In this tutorial, you create a simple Windows Forms UI and add animated Composition elements to it.</span></span> <span data-ttu-id="b2a95-119">Windows フォームと合成の両方のコンポーネントを単純に保持されますが、相互運用機能のコードは、コンポーネントの複雑さに関係なく同じです。</span><span class="sxs-lookup"><span data-stu-id="b2a95-119">Both the Windows Forms and Composition components are kept simple, but the interop code shown is the same regardless of the complexity of the components.</span></span> <span data-ttu-id="b2a95-120">次のような完成したアプリが表示されます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-120">The finished app looks like this.</span></span>

![実行中のアプリの UI](images/interop/wf-comp-interop-app-ui.png)

## <a name="create-a-windows-forms-project"></a><span data-ttu-id="b2a95-122">Windows フォーム プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-122">Create a Windows Forms project</span></span>

<span data-ttu-id="b2a95-123">最初の手順では、UI のアプリケーションの定義とメイン フォームが含まれている Windows フォーム アプリ プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-123">The first step is to create the Windows Forms app project, which includes an application definition and the main form for the UI.</span></span>

<span data-ttu-id="b2a95-124">ビジュアルで新しい Windows フォーム アプリケーション プロジェクトを作成するC#という_HelloComposition_:</span><span class="sxs-lookup"><span data-stu-id="b2a95-124">To create a new Windows Forms Application project in Visual C# named _HelloComposition_:</span></span>

1. <span data-ttu-id="b2a95-125">Visual Studio を開き、選択**ファイル** > **新規** > **プロジェクト**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-125">Open Visual Studio and select **File** > **New** > **Project**.</span></span><br/><span data-ttu-id="b2a95-126">**新しいプロジェクト**ダイアログ ボックスが開きます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-126">The **New Project** dialog opens.</span></span>
1. <span data-ttu-id="b2a95-127">下、**インストール済み**カテゴリで、展開、 **Visual C#** ノードをクリックして**Windows デスクトップ**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-127">Under the **Installed** category, expand the **Visual C#** node, and then select **Windows Desktop**.</span></span>
1. <span data-ttu-id="b2a95-128">選択、 **Windows フォーム アプリ (.NET Framework)** テンプレート。</span><span class="sxs-lookup"><span data-stu-id="b2a95-128">Select the **Windows Forms App (.NET Framework)** template.</span></span>
1. <span data-ttu-id="b2a95-129">名前を入力します_HelloComposition、_ フレームワークを選択します **.NET Framework 4.7.2**、 をクリックし、 **OK**。</span><span class="sxs-lookup"><span data-stu-id="b2a95-129">Enter the name _HelloComposition,_ select Framework **.NET Framework 4.7.2**, then click **OK**.</span></span>

<span data-ttu-id="b2a95-130">Visual Studio では、プロジェクトを作成し、Form1.cs という名前の既定アプリケーション ウィンドウのデザイナーを開きます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-130">Visual Studio creates the project and opens the designer for the default application window named Form1.cs.</span></span>

## <a name="configure-the-project-to-use-windows-runtime-apis"></a><span data-ttu-id="b2a95-131">Windows ランタイム Api を使用してプロジェクトを構成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-131">Configure the project to use Windows Runtime APIs</span></span>

<span data-ttu-id="b2a95-132">Windows ランタイム (WinRT)、Windows フォーム アプリで Api を使用するには、Windows ランタイムにアクセスする Visual Studio プロジェクトを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="b2a95-132">To use Windows Runtime (WinRT) APIs in your Windows Forms app, you need to configure your Visual Studio project to access the Windows Runtime.</span></span> <span data-ttu-id="b2a95-133">さらに、ベクターを使用するために必要な参照を追加する必要があるために、合成 Api でベクターは広範囲に使用されます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-133">In addition, vectors are used extensively by the Composition APIs, so you need to add the references required to use vectors.</span></span>

<span data-ttu-id="b2a95-134">NuGet パッケージのこれらのニーズの両方のアドレスを利用できます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-134">NuGet packages are available to address both of these needs.</span></span> <span data-ttu-id="b2a95-135">これらのパッケージをプロジェクトに必要な参照を追加するの最新バージョンをインストールします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-135">Install the latest versions of these packages to add the necessary references to your project.</span></span>  

- <span data-ttu-id="b2a95-136">[Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts) (PackageReference に既定のパッケージ管理形式のセットが必要)。</span><span class="sxs-lookup"><span data-stu-id="b2a95-136">[Microsoft.Windows.SDK.Contracts](https://www.nuget.org/packages/Microsoft.Windows.SDK.Contracts) (Requires default package management format set to PackageReference.)</span></span>
- [<span data-ttu-id="b2a95-137">System.Numerics.Vectors</span><span class="sxs-lookup"><span data-stu-id="b2a95-137">System.Numerics.Vectors</span></span>](https://www.nuget.org/packages/System.Numerics.Vectors/)

> [!NOTE]
> <span data-ttu-id="b2a95-138">NuGet パッケージを使用して、プロジェクトを構成することをお勧め、中には、必要な参照を手動で追加することができます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-138">While we recommend using the NuGet packages to configure your project, you can add the required references manually.</span></span> <span data-ttu-id="b2a95-139">詳細については、次を参照してください。 [Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-139">For more info, see [Enhance your desktop application for Windows 10](/windows/uwp/porting/desktop-to-uwp-enhance).</span></span> <span data-ttu-id="b2a95-140">次の表への参照を追加する必要のあるファイルを示します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-140">The following table shows the files that you need to add references to.</span></span>

|<span data-ttu-id="b2a95-141">ファイル</span><span class="sxs-lookup"><span data-stu-id="b2a95-141">File</span></span>|<span data-ttu-id="b2a95-142">Location</span><span class="sxs-lookup"><span data-stu-id="b2a95-142">Location</span></span>|
|--|--|
|<span data-ttu-id="b2a95-143">System.Runtime.WindowsRuntime</span><span class="sxs-lookup"><span data-stu-id="b2a95-143">System.Runtime.WindowsRuntime</span></span>|<span data-ttu-id="b2a95-144">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span><span class="sxs-lookup"><span data-stu-id="b2a95-144">C:\Windows\Microsoft.NET\Framework\v4.0.30319</span></span>|
|<span data-ttu-id="b2a95-145">Windows.Foundation.UniversalApiContract.winmd</span><span class="sxs-lookup"><span data-stu-id="b2a95-145">Windows.Foundation.UniversalApiContract.winmd</span></span>|<span data-ttu-id="b2a95-146">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="b2a95-146">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.UniversalApiContract\<*version*></span></span>|
|<span data-ttu-id="b2a95-147">Windows.Foundation.FoundationContract.winmd</span><span class="sxs-lookup"><span data-stu-id="b2a95-147">Windows.Foundation.FoundationContract.winmd</span></span>|<span data-ttu-id="b2a95-148">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span><span class="sxs-lookup"><span data-stu-id="b2a95-148">C:\Program Files (x86)\Windows Kits\10\References\<*sdk version*>\Windows.Foundation.FoundationContract\<*version*></span></span>|
|<span data-ttu-id="b2a95-149">System.Numerics.Vectors.dll</span><span class="sxs-lookup"><span data-stu-id="b2a95-149">System.Numerics.Vectors.dll</span></span>|<span data-ttu-id="b2a95-150">C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics.Vectors\v4.0_4.0.0.0__b03f5f7f11d50a3a</span><span class="sxs-lookup"><span data-stu-id="b2a95-150">C:\WINDOWS\Microsoft.Net\assembly\GAC_MSIL\System.Numerics.Vectors\v4.0_4.0.0.0__b03f5f7f11d50a3a</span></span>|
|<span data-ttu-id="b2a95-151">System.Numerics.dll</span><span class="sxs-lookup"><span data-stu-id="b2a95-151">System.Numerics.dll</span></span>|<span data-ttu-id="b2a95-152">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2</span><span class="sxs-lookup"><span data-stu-id="b2a95-152">C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.7.2</span></span>|

## <a name="create-a-custom-control-to-manage-interop"></a><span data-ttu-id="b2a95-153">相互運用機能を管理するカスタム コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-153">Create a custom control to manage interop</span></span>

<span data-ttu-id="b2a95-154">派生したカスタム コントロールを作成するビジュアル層で作成するコンテンツのホストに[コントロール](/dotnet/api/system.windows.forms.control)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-154">To host content you create with the visual layer, you create a custom control derived from [Control](/dotnet/api/system.windows.forms.control).</span></span> <span data-ttu-id="b2a95-155">このコントロールでは、ウィンドウにアクセスする[処理](/dotnet/api/system.windows.forms.control.handle)、ビジュアル層コンテンツのコンテナーを作成するために必要があります。</span><span class="sxs-lookup"><span data-stu-id="b2a95-155">This control gives you access to a window [Handle](/dotnet/api/system.windows.forms.control.handle), which you need in order to create the container for your visual layer content.</span></span>

<span data-ttu-id="b2a95-156">これは、合成 Api をホストするための構成の大部分を実行します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-156">This is where you do most of the configuration for hosting Composition APIs.</span></span> <span data-ttu-id="b2a95-157">このコントロールで使用する[プラットフォーム呼び出しサービス (PInvoke)](/cpp/dotnet/calling-native-functions-from-managed-code)と[COM 相互運用機能](/dotnet/api/system.runtime.interopservices.comimportattribute)合成 Api を Windows フォーム アプリに取り込む。</span><span class="sxs-lookup"><span data-stu-id="b2a95-157">In this control, you use [Platform Invocation Services (PInvoke)](/cpp/dotnet/calling-native-functions-from-managed-code) and [COM Interop](/dotnet/api/system.runtime.interopservices.comimportattribute) to bring Composition APIs into your Windows Forms app.</span></span> <span data-ttu-id="b2a95-158">PInvoke と COM 相互運用機能の詳細については、次を参照してください。[アンマネージ コードとの相互運用](/dotnet/framework/interop/index)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-158">For more info about PInvoke and COM Interop, see [Interoperating with unmanaged code](/dotnet/framework/interop/index).</span></span>

> [!TIP]
> <span data-ttu-id="b2a95-159">必要がある場合は、すべてのコードは、チュートリアルを使用すると適切な場所にいるかどうかを確認するチュートリアルの最後に完全なコードを確認します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-159">If you need to, check the complete code at the end of the tutorial to make sure all the code is in the right places as you work through the tutorial.</span></span>

1. <span data-ttu-id="b2a95-160">派生するプロジェクトに新しいカスタム コントロール ファイルを追加[コントロール](/dotnet/api/system.windows.forms.control)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-160">Add a new custom control file to your project that derives from [Control](/dotnet/api/system.windows.forms.control).</span></span>
    - <span data-ttu-id="b2a95-161">**ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="b2a95-161">In **Solution Explorer**, right click the  _HelloComposition_ project.</span></span>
    - <span data-ttu-id="b2a95-162">コンテキスト メニューで選択**追加** > **新しい項目.**.</span><span class="sxs-lookup"><span data-stu-id="b2a95-162">In the context menu, select **Add** > **New Item...**.</span></span>
    - <span data-ttu-id="b2a95-163">**新しい項目の追加**ダイアログ ボックスで、**カスタム コントロール**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-163">In the **Add New Item** dialog, select **Custom Control**.</span></span>
    - <span data-ttu-id="b2a95-164">コントロールに名前を_CompositionHost.cs_、 をクリックし、**追加**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-164">Name the control _CompositionHost.cs_, then click **Add**.</span></span> <span data-ttu-id="b2a95-165">CompositionHost.cs がデザイン ビューで開きます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-165">CompositionHost.cs opens in the Design view.</span></span>

1. <span data-ttu-id="b2a95-166">CompositionHost.cs のコード ビューに切り替え、クラスに次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-166">Switch to code view for CompositionHost.cs and add the following code to the class.</span></span>

    ```csharp
    // Add
    // using Windows.UI.Composition;

    IntPtr hwndHost;
    object dispatcherQueue;
    protected ContainerVisual containerVisual;
    protected Compositor compositor;

    private ICompositionTarget compositionTarget;

    public Visual Child
    {
        set
        {
            if (compositor == null)
            {
                InitComposition(hwndHost);
            }
            compositionTarget.Root = value;
        }
    }
    ```

1. <span data-ttu-id="b2a95-167">コンストラクターにコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-167">Add code to the constructor.</span></span>

    <span data-ttu-id="b2a95-168">コンストラクターで呼び出して、 _InitializeCoreDispatcher_と_InitComposition_メソッド。</span><span class="sxs-lookup"><span data-stu-id="b2a95-168">In the constructor, you call the _InitializeCoreDispatcher_ and _InitComposition_ methods.</span></span> <span data-ttu-id="b2a95-169">次の手順では、これらのメソッドを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-169">You create these methods in the next steps.</span></span>

    ```csharp
    public CompositionHost()
    {
        InitializeComponent();

        // Get the window handle.
        hwndHost = Handle;

        // Create dispatcher queue.
        dispatcherQueue = InitializeCoreDispatcher();

        // Build Composition tree of content.
        InitComposition(hwndHost);
    }

1. Initialize a thread with a [CoreDispatcher](/uwp/api/windows.ui.core.coredispatcher). The core dispatcher is responsible for processing window messages and dispatching events for WinRT APIs. New instances of **Compositor** must be created on a thread that has a CoreDispatcher.
    - Create a method named _InitializeCoreDispatcher_ and add code to set up the dispatcher queue.

    ```csharp
    // Add
    // using System.Runtime.InteropServices;

    private object InitializeCoreDispatcher()
    {
        DispatcherQueueOptions options = new DispatcherQueueOptions();
        options.apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA;
        options.threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT;
        options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));

        object queue = null;
        CreateDispatcherQueueController(options, out queue);
        return queue;
    }
    ```

    - <span data-ttu-id="b2a95-170">ディスパッチャー キューには、PInvoke 宣言が必要です。</span><span class="sxs-lookup"><span data-stu-id="b2a95-170">The dispatcher queue requires a PInvoke declaration.</span></span> <span data-ttu-id="b2a95-171">この宣言をクラスのコードの最後に配置します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-171">Place this declaration at the end of the code for the class.</span></span> <span data-ttu-id="b2a95-172">(私たち内に配置このコード クラスのコードの編成を保持する領域。)</span><span class="sxs-lookup"><span data-stu-id="b2a95-172">(We place this code inside a region to keep the class code tidy.)</span></span>

    ```csharp
    #region PInvoke declarations

    //typedef enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
    //{
    //    DQTAT_COM_NONE,
    //    DQTAT_COM_ASTA,
    //    DQTAT_COM_STA
    //};
    internal enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
    {
        DQTAT_COM_NONE = 0,
        DQTAT_COM_ASTA = 1,
        DQTAT_COM_STA = 2
    };

    //typedef enum DISPATCHERQUEUE_THREAD_TYPE
    //{
    //    DQTYPE_THREAD_DEDICATED,
    //    DQTYPE_THREAD_CURRENT
    //};
    internal enum DISPATCHERQUEUE_THREAD_TYPE
    {
        DQTYPE_THREAD_DEDICATED = 1,
        DQTYPE_THREAD_CURRENT = 2,
    };

    //struct DispatcherQueueOptions
    //{
    //    DWORD dwSize;
    //    DISPATCHERQUEUE_THREAD_TYPE threadType;
    //    DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
    //};
    [StructLayout(LayoutKind.Sequential)]
    internal struct DispatcherQueueOptions
    {
        public int dwSize;

        [MarshalAs(UnmanagedType.I4)]
        public DISPATCHERQUEUE_THREAD_TYPE threadType;

        [MarshalAs(UnmanagedType.I4)]
        public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
    };

    //HRESULT CreateDispatcherQueueController(
    //  DispatcherQueueOptions options,
    //  ABI::Windows::System::IDispatcherQueueController** dispatcherQueueController
    //);
    [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
    internal static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options,
                                            [MarshalAs(UnmanagedType.IUnknown)]
                                            out object dispatcherQueueController);

    #endregion PInvoke declarations
    ```

    <span data-ttu-id="b2a95-173">今すぐディスパッチャー キューの準備ができているし、初期化し、合成コンテンツの作成を開始できます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-173">You now have the dispatcher queue ready and can begin to initialize and create Composition content.</span></span>

1. <span data-ttu-id="b2a95-174">初期化、[コンポジター](/uwp/api/windows.ui.composition.compositor)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-174">Initialize the [Compositor](/uwp/api/windows.ui.composition.compositor).</span></span> <span data-ttu-id="b2a95-175">コンポジターがさまざまな型を作成するファクトリを[Windows.UI.Composition](/uwp/api/windows.ui.composition)ビジュアル層、効果のシステム、およびアニメーション システムにまたがる名前空間。</span><span class="sxs-lookup"><span data-stu-id="b2a95-175">The Compositor is a factory that creates a variety of types in the [Windows.UI.Composition](/uwp/api/windows.ui.composition) namespace spanning the visual layer, effects system, and animation system.</span></span> <span data-ttu-id="b2a95-176">コンポジター クラスには、ファクトリから作成されたオブジェクトの有効期間も管理します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-176">The Compositor class also manages the lifetime of objects created from the factory.</span></span>

    ```csharp
    private void InitComposition(IntPtr hwndHost)
    {
        ICompositorDesktopInterop interop;

        compositor = new Compositor();
        object iunknown = compositor as object;
        interop = (ICompositorDesktopInterop)iunknown;
        IntPtr raw;
        interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

        object rawObject = Marshal.GetObjectForIUnknown(raw);
        compositionTarget = (ICompositionTarget)rawObject;

        if (raw == null) { throw new Exception("QI Failed"); }

        containerVisual = compositor.CreateContainerVisual();
        Child = containerVisual;
    }
    ```

    - <span data-ttu-id="b2a95-177">**ICompositorDesktopInterop**と**ICompositionTarget** COM インポートが必要です。</span><span class="sxs-lookup"><span data-stu-id="b2a95-177">**ICompositorDesktopInterop** and **ICompositionTarget** require COM imports.</span></span> <span data-ttu-id="b2a95-178">このコードの後、 _CompositionHost_クラスが内部名前空間の宣言。</span><span class="sxs-lookup"><span data-stu-id="b2a95-178">Place this code after the _CompositionHost_ class, but inside the namespace declaration.</span></span>

    ```csharp
    #region COM Interop

    /*
    #undef INTERFACE
    #define INTERFACE ICompositorDesktopInterop
        DECLARE_INTERFACE_IID_(ICompositorDesktopInterop, IUnknown, "29E691FA-4567-4DCA-B319-D0F207EB6807")
        {
            IFACEMETHOD(CreateDesktopWindowTarget)(
                _In_ HWND hwndTarget,
                _In_ BOOL isTopmost,
                _COM_Outptr_ IDesktopWindowTarget * *result
                ) PURE;
        };
    */
    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }

    //[contract(Windows.Foundation.UniversalApiContract, 2.0)]
    //[exclusiveto(Windows.UI.Composition.CompositionTarget)]
    //[uuid(A1BEA8BA - D726 - 4663 - 8129 - 6B5E7927FFA6)]
    //interface ICompositionTarget : IInspectable
    //{
    //    [propget] HRESULT Root([out] [retval] Windows.UI.Composition.Visual** value);
    //    [propput] HRESULT Root([in] Windows.UI.Composition.Visual* value);
    //}

    [ComImport]
    [Guid("A1BEA8BA-D726-4663-8129-6B5E7927FFA6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface ICompositionTarget
    {
        Windows.UI.Composition.Visual Root
        {
            get;
            set;
        }
    }

    #endregion COM Interop
    ```

## <a name="create-a-custom-control-to-host-composition-elements"></a><span data-ttu-id="b2a95-179">コンポジションのホスト要素にカスタム コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-179">Create a custom control to host composition elements</span></span>

<span data-ttu-id="b2a95-180">生成および CompositionHost から派生した個別のコントロールに、合成要素を管理するコードを配置することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-180">It's a good idea to put the code that generates and manages your composition elements in a separate control that derives from CompositionHost.</span></span> <span data-ttu-id="b2a95-181">これにより、相互運用機能のコード再利用可能な CompositionHost クラスで作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-181">This keeps the interop code you created in the CompositionHost class reusable.</span></span>

<span data-ttu-id="b2a95-182">ここでは、CompositionHost から派生したカスタム コントロールを作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-182">Here, you create a custom control derived from CompositionHost.</span></span> <span data-ttu-id="b2a95-183">このコントロールは、フォームに追加することができますので、Visual Studio のツールボックスに追加されます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-183">This control is added to the Visual Studio toolbox so you can add it to your form.</span></span>

1. <span data-ttu-id="b2a95-184">CompositionHost から派生するプロジェクトに新しいカスタム コントロール ファイルを追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-184">Add a new custom control file to your project that derives from CompositionHost.</span></span>
    - <span data-ttu-id="b2a95-185">**ソリューション エクスプ ローラー**を右クリックして、 _HelloComposition_プロジェクト。</span><span class="sxs-lookup"><span data-stu-id="b2a95-185">In **Solution Explorer**, right click the  _HelloComposition_ project.</span></span>
    - <span data-ttu-id="b2a95-186">コンテキスト メニューで選択**追加** > **新しい項目.**.</span><span class="sxs-lookup"><span data-stu-id="b2a95-186">In the context menu, select **Add** > **New Item...**.</span></span>
    - <span data-ttu-id="b2a95-187">**新しい項目の追加**ダイアログ ボックスで、**カスタム コントロール**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-187">In the **Add New Item** dialog, select **Custom Control**.</span></span>
    - <span data-ttu-id="b2a95-188">コントロールに名前を_CompositionHostControl.cs_、 をクリックし、**追加**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-188">Name the control _CompositionHostControl.cs_, then click **Add**.</span></span> <span data-ttu-id="b2a95-189">CompositionHostControl.cs がデザイン ビューで開きます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-189">CompositionHostControl.cs opens in the Design view.</span></span>

1. <span data-ttu-id="b2a95-190">CompositionHostControl.cs デザイン ビューのプロパティ ウィンドウで、設定、 **BackColor**プロパティを**ControlLight**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-190">In the Properties pane for CompositionHostControl.cs design view, set the **BackColor** property to **ControlLight**.</span></span>

    <span data-ttu-id="b2a95-191">背景色の設定は省略可能です。</span><span class="sxs-lookup"><span data-stu-id="b2a95-191">Setting the background color is optional.</span></span> <span data-ttu-id="b2a95-192">以下に、カスタム コントロールをフォームの背景を表示できるようにします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-192">We do it here so you can see your custom control against the form background.</span></span>

1. <span data-ttu-id="b2a95-193">CompositionHostControl.cs のコード ビューに切り替え、CompositionHost から派生するクラスの宣言を更新します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-193">Switch to code view for CompositionHostControl.cs and update the class declaration to derive from CompositionHost.</span></span>

    ```csharp
    class CompositionHostControl : CompositionHost
    ```

1. <span data-ttu-id="b2a95-194">基本コンストラクターを呼び出すコンストラクターを更新します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-194">Update the constructor to call the base constructor.</span></span>

    ```csharp
    public CompositionHostControl() : base()
    {

    }
    ```

### <a name="add-composition-elements"></a><span data-ttu-id="b2a95-195">合成要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-195">Add composition elements</span></span>

<span data-ttu-id="b2a95-196">インプレース インフラストラクチャ、アプリの UI に合成コンテンツを追加できます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-196">With the infrastructure in place, you can now add Composition content to the app UI.</span></span>

<span data-ttu-id="b2a95-197">この例では、CompositionHostControl クラスを作成し、単純なアニメーション化するコードを追加する[SpriteVisual](/uwp/api/windows.ui.composition.spritevisual)します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-197">For this example, you add code to the CompositionHostControl class that creates and animates a simple [SpriteVisual](/uwp/api/windows.ui.composition.spritevisual).</span></span>

1. <span data-ttu-id="b2a95-198">合成要素を追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-198">Add a composition element.</span></span>

    <span data-ttu-id="b2a95-199">CompositionHostControl.cs では、CompositionHostControl クラスにこれらのメソッドを追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-199">In CompositionHostControl.cs, add these methods to the CompositionHostControl class.</span></span>

    ```csharp
    // Add
    // using Windows.UI.Composition;

    public void AddElement(float size, float offsetX, float offsetY)
    {
        var visual = compositor.CreateSpriteVisual();
        visual.Size = new Vector2(size, size); // Requires references
        visual.Brush = compositor.CreateColorBrush(GetRandomColor());
        visual.Offset = new Vector3(offsetX, offsetY, 0);
        containerVisual.Children.InsertAtTop(visual);

        AnimateSquare(visual, 3);
    }

    private void AnimateSquare(SpriteVisual visual, int delay)
    {
        float offsetX = (float)(visual.Offset.X);
        Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
        float bottom = Height - visual.Size.Y;
        animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
        animation.Duration = TimeSpan.FromSeconds(2);
        animation.DelayTime = TimeSpan.FromSeconds(delay);
        visual.StartAnimation("Offset", animation);
    }

    private Windows.UI.Color GetRandomColor()
    {
        Random random = new Random();
        byte r = (byte)random.Next(0, 255);
        byte g = (byte)random.Next(0, 255);
        byte b = (byte)random.Next(0, 255);
        return Windows.UI.Color.FromArgb(255, r, g, b);
    }
    ```

## <a name="add-the-control-to-your-form"></a><span data-ttu-id="b2a95-200">コントロールをフォームに追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-200">Add the control to your form</span></span>

<span data-ttu-id="b2a95-201">コンポジションのコンテンツをホストするカスタム コントロールがある場合は、できたは、アプリの UI を追加できます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-201">Now that you have a custom control to host Composition content, you can add it to the app UI.</span></span> <span data-ttu-id="b2a95-202">ここでは、前の手順で作成した CompositionHostControl のインスタンスを追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-202">Here, you add an instance of the CompositionHostControl you created in the previous step.</span></span> <span data-ttu-id="b2a95-203">Visual Studio のツールボックスに自動的に追加 CompositionHostControl **_プロジェクト名_コンポーネント**します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-203">CompositionHostControl is automatically added to the Visual Studio toolbox under **_project name_ Components**.</span></span>

1. <span data-ttu-id="b2a95-204">Form1.CS [デザイン] ビューでは、UI にボタンを追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-204">In Form1.CS design view, add a Button to the UI.</span></span>

    - <span data-ttu-id="b2a95-205">Form1 には、ツールボックスからボタンをドラッグします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-205">Drag a Button from the toolbox onto Form1.</span></span> <span data-ttu-id="b2a95-206">フォームの左上隅に配置します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-206">Place it in the upper left corner of the form.</span></span> <span data-ttu-id="b2a95-207">(コントロールの配置を確認するチュートリアルの開始時のイメージを参照してください)。</span><span class="sxs-lookup"><span data-stu-id="b2a95-207">(See the image at the start of the tutorial to check the placement of the controls.)</span></span>
    - <span data-ttu-id="b2a95-208">[プロパティ] ウィンドウで変更、**テキスト**プロパティから_button1_に_追加の合成要素_します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-208">In the Properties pane, change the **Text** property from _button1_ to _Add composition element_.</span></span>
    - <span data-ttu-id="b2a95-209">すべてのテキストが表示されるよう、ボタンのサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-209">Resize the Button so that all the text shows.</span></span>

    <span data-ttu-id="b2a95-210">(詳細については、次を参照してください。[方法。Windows フォームにコントロールを追加](/dotnet/framework/winforms/controls/how-to-add-controls-to-windows-forms))。</span><span class="sxs-lookup"><span data-stu-id="b2a95-210">(For more info, see [How to: Add Controls to Windows Forms](/dotnet/framework/winforms/controls/how-to-add-controls-to-windows-forms).)</span></span>

1. <span data-ttu-id="b2a95-211">UI に、CompositionHostControl を追加します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-211">Add a CompositionHostControl to the UI.</span></span>

    - <span data-ttu-id="b2a95-212">Form1 には、ツールボックスから、CompositionHostControl をドラッグします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-212">Drag a CompositionHostControl from the toolbox onto Form1.</span></span> <span data-ttu-id="b2a95-213">ボタンの右側に配置します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-213">Place it to the right of the Button.</span></span>
    - <span data-ttu-id="b2a95-214">フォームの残りの部分全体に表示されるので、CompositionHost のサイズを変更します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-214">Resize the CompositionHost so that it fills the remainder of the form.</span></span>

1. <span data-ttu-id="b2a95-215">ボタンのハンドルは、イベントをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-215">Handle the button click event.</span></span>

   - <span data-ttu-id="b2a95-216">プロパティ ペインで、イベントの表示を切り替える稲妻をクリックします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-216">In the Properties pane, click the lightning bolt to switch to the Events view.</span></span>
   - <span data-ttu-id="b2a95-217">イベントの一覧で、選択、**クリックして**イベントの種類*Button_Click*、Enter キーを押します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-217">In the events list, select the **Click** event, type *Button_Click*, and press Enter.</span></span>
   - <span data-ttu-id="b2a95-218">このコードは、Form1.cs で追加されます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-218">This code is added in Form1.cs:</span></span>

    ```csharp
    private void Button_Click(object sender, EventArgs e)
    {

    }
    ```

1. <span data-ttu-id="b2a95-219">ボタンにコードを追加する新しい要素を作成するイベント ハンドラーをクリックします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-219">Add code to the button click handler to create new elements.</span></span>

    - <span data-ttu-id="b2a95-220">Form1.cs のコードを追加、 *Button_Click*以前に作成したイベント ハンドラー。</span><span class="sxs-lookup"><span data-stu-id="b2a95-220">In Form1.cs, add code to the *Button_Click* event handler you created previously.</span></span> <span data-ttu-id="b2a95-221">このコードは呼び出して_CompositionHostControl1.AddElement_ランダムに生成されたサイズおよびオフセットを新しい要素を作成します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-221">This code calls _CompositionHostControl1.AddElement_ to create a new element with a randomly generated size and offset.</span></span> <span data-ttu-id="b2a95-222">(CompositionHostControl のインスタンスが自動的に名前付き_compositionHostControl1_ときにフォームにドラッグします)。</span><span class="sxs-lookup"><span data-stu-id="b2a95-222">(The instance of CompositionHostControl was automatically named _compositionHostControl1_ when you dragged it onto the form.)</span></span>

    ```csharp
    // Add
    // using System;

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Random random = new Random();
        float size = random.Next(50, 150);
        float offsetX = random.Next(0, (int)(compositionHostControl1.Width - size));
        float offsetY = random.Next(0, (int)(compositionHostControl1.Height/2 - size));
        compositionHostControl1.AddElement(size, offsetX, offsetY);
    }
    ```

<span data-ttu-id="b2a95-223">ビルドして、Windows フォーム アプリを実行することができますようになりました。</span><span class="sxs-lookup"><span data-stu-id="b2a95-223">You can now build and run your Windows Forms app.</span></span> <span data-ttu-id="b2a95-224">ボタンをクリックすると、UI に追加するアニメーションの正方形が表示されます。</span><span class="sxs-lookup"><span data-stu-id="b2a95-224">When you click the button, you should see animated squares added to the UI.</span></span>

## <a name="next-steps"></a><span data-ttu-id="b2a95-225">次のステップ</span><span class="sxs-lookup"><span data-stu-id="b2a95-225">Next steps</span></span>

<span data-ttu-id="b2a95-226">同じインフラストラクチャ上に構築するより詳細な例については、 [Windows フォームのビジュアル層の統合サンプル](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/VisualLayerIntegration)GitHub でします。</span><span class="sxs-lookup"><span data-stu-id="b2a95-226">For a more complete example that builds on the same infrastructure, see the [Windows Forms Visual layer integration sample](https://github.com/Microsoft/Windows.UI.Composition-Win32-Samples/tree/master/dotnet/WinForms/VisualLayerIntegration) on GitHub.</span></span>

## <a name="additional-resources"></a><span data-ttu-id="b2a95-227">その他の資料</span><span class="sxs-lookup"><span data-stu-id="b2a95-227">Additional resources</span></span>

- <span data-ttu-id="b2a95-228">[Windows フォームの概要](/dotnet/framework/winforms/getting-started-with-windows-forms)(.NET)</span><span class="sxs-lookup"><span data-stu-id="b2a95-228">[Getting Started with Windows Forms](/dotnet/framework/winforms/getting-started-with-windows-forms) (.NET)</span></span>
- <span data-ttu-id="b2a95-229">[アンマネージ コードと相互運用](/dotnet/framework/interop/)(.NET)</span><span class="sxs-lookup"><span data-stu-id="b2a95-229">[Interoperating with unmanaged code](/dotnet/framework/interop/) (.NET)</span></span>
- <span data-ttu-id="b2a95-230">[Windows 10 アプリの概要](/windows/uwp/get-started/)(UWP)</span><span class="sxs-lookup"><span data-stu-id="b2a95-230">[Get started with Windows 10 apps](/windows/uwp/get-started/) (UWP)</span></span>
- <span data-ttu-id="b2a95-231">[Windows 10 のデスクトップ アプリケーションの拡張](/windows/uwp/porting/desktop-to-uwp-enhance)(UWP)</span><span class="sxs-lookup"><span data-stu-id="b2a95-231">[Enhance your desktop application for Windows 10](/windows/uwp/porting/desktop-to-uwp-enhance) (UWP)</span></span>
- <span data-ttu-id="b2a95-232">[名前空間の Windows.UI.Composition](/uwp/api/windows.ui.composition) (UWP)</span><span class="sxs-lookup"><span data-stu-id="b2a95-232">[Windows.UI.Composition namespace](/uwp/api/windows.ui.composition) (UWP)</span></span>

## <a name="complete-code"></a><span data-ttu-id="b2a95-233">コードを完成させる</span><span class="sxs-lookup"><span data-stu-id="b2a95-233">Complete code</span></span>

<span data-ttu-id="b2a95-234">このチュートリアルの完全なコードを示します。</span><span class="sxs-lookup"><span data-stu-id="b2a95-234">Here's the complete code for this tutorial.</span></span>

### <a name="form1cs"></a><span data-ttu-id="b2a95-235">Form1.cs</span><span class="sxs-lookup"><span data-stu-id="b2a95-235">Form1.cs</span></span>

```csharp
using System;
using System.Windows.Forms;

namespace HelloComposition
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            float size = random.Next(50, 150);
            float offsetX = random.Next(0, (int)(compositionHostControl1.Width - size));
            float offsetY = random.Next(0, (int)(compositionHostControl1.Height/2 - size));
            compositionHostControl1.AddElement(size, offsetX, offsetY);
        }
    }
}
```

### <a name="compositionhostcontrolcs"></a><span data-ttu-id="b2a95-236">CompositionHostControl.cs</span><span class="sxs-lookup"><span data-stu-id="b2a95-236">CompositionHostControl.cs</span></span>

```csharp
using System;
using System.Numerics;
using Windows.UI.Composition;

namespace HelloComposition
{
    class CompositionHostControl : CompositionHost
    {
        public CompositionHostControl() : base()
        {

        }

        public void AddElement(float size, float offsetX, float offsetY)
        {
            var visual = compositor.CreateSpriteVisual();
            visual.Size = new Vector2(size, size); // Requires references
            visual.Brush = compositor.CreateColorBrush(GetRandomColor());
            visual.Offset = new Vector3(offsetX, offsetY, 0);
            containerVisual.Children.InsertAtTop(visual);

            AnimateSquare(visual, 3);
        }

        private void AnimateSquare(SpriteVisual visual, int delay)
        {
            float offsetX = (float)(visual.Offset.X);
            Vector3KeyFrameAnimation animation = compositor.CreateVector3KeyFrameAnimation();
            float bottom = Height - visual.Size.Y;
            animation.InsertKeyFrame(1f, new Vector3(offsetX, bottom, 0f));
            animation.Duration = TimeSpan.FromSeconds(2);
            animation.DelayTime = TimeSpan.FromSeconds(delay);
            visual.StartAnimation("Offset", animation);
        }

        private Windows.UI.Color GetRandomColor()
        {
            Random random = new Random();
            byte r = (byte)random.Next(0, 255);
            byte g = (byte)random.Next(0, 255);
            byte b = (byte)random.Next(0, 255);
            return Windows.UI.Color.FromArgb(255, r, g, b);
        }
    }
}
```

### <a name="compositionhostcs"></a><span data-ttu-id="b2a95-237">CompositionHost.cs</span><span class="sxs-lookup"><span data-stu-id="b2a95-237">CompositionHost.cs</span></span>

```csharp
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Windows.UI.Composition;

namespace HelloComposition
{
    public partial class CompositionHost : Control
    {
        IntPtr hwndHost;
        object dispatcherQueue;
        protected ContainerVisual containerVisual;
        protected Compositor compositor;
        private ICompositionTarget compositionTarget;

        public Visual Child
        {
            set
            {
                if (compositor == null)
                {
                    InitComposition(hwndHost);
                }
                compositionTarget.Root = value;
            }
        }

        public CompositionHost()
        {
            // Get the window handle.
            hwndHost = Handle;

            // Create dispatcher queue.
            dispatcherQueue = InitializeCoreDispatcher();

            // Build Composition tree of content.
            InitComposition(hwndHost);
        }

        private object InitializeCoreDispatcher()
        {
            DispatcherQueueOptions options = new DispatcherQueueOptions();
            options.apartmentType = DISPATCHERQUEUE_THREAD_APARTMENTTYPE.DQTAT_COM_STA;
            options.threadType = DISPATCHERQUEUE_THREAD_TYPE.DQTYPE_THREAD_CURRENT;
            options.dwSize = Marshal.SizeOf(typeof(DispatcherQueueOptions));

            object queue = null;
            CreateDispatcherQueueController(options, out queue);
            return queue;
        }

        private void InitComposition(IntPtr hwndHost)
        {
            ICompositorDesktopInterop interop;

            compositor = new Compositor();
            object iunknown = compositor as object;
            interop = (ICompositorDesktopInterop)iunknown;
            IntPtr raw;
            interop.CreateDesktopWindowTarget(hwndHost, true, out raw);

            object rawObject = Marshal.GetObjectForIUnknown(raw);
            compositionTarget = (ICompositionTarget)rawObject;

            if (raw == null) { throw new Exception("QI Failed"); }

            containerVisual = compositor.CreateContainerVisual();
            Child = containerVisual;
        }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        #region PInvoke declarations

        //typedef enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        //{
        //    DQTAT_COM_NONE,
        //    DQTAT_COM_ASTA,
        //    DQTAT_COM_STA
        //};
        internal enum DISPATCHERQUEUE_THREAD_APARTMENTTYPE
        {
            DQTAT_COM_NONE = 0,
            DQTAT_COM_ASTA = 1,
            DQTAT_COM_STA = 2
        };

        //typedef enum DISPATCHERQUEUE_THREAD_TYPE
        //{
        //    DQTYPE_THREAD_DEDICATED,
        //    DQTYPE_THREAD_CURRENT
        //};
        internal enum DISPATCHERQUEUE_THREAD_TYPE
        {
            DQTYPE_THREAD_DEDICATED = 1,
            DQTYPE_THREAD_CURRENT = 2,
        };

        //struct DispatcherQueueOptions
        //{
        //    DWORD dwSize;
        //    DISPATCHERQUEUE_THREAD_TYPE threadType;
        //    DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        //};
        [StructLayout(LayoutKind.Sequential)]
        internal struct DispatcherQueueOptions
        {
            public int dwSize;

            [MarshalAs(UnmanagedType.I4)]
            public DISPATCHERQUEUE_THREAD_TYPE threadType;

            [MarshalAs(UnmanagedType.I4)]
            public DISPATCHERQUEUE_THREAD_APARTMENTTYPE apartmentType;
        };

        //HRESULT CreateDispatcherQueueController(
        //  DispatcherQueueOptions options,
        //  ABI::Windows::System::IDispatcherQueueController** dispatcherQueueController
        //);
        [DllImport("coremessaging.dll", EntryPoint = "CreateDispatcherQueueController", CharSet = CharSet.Unicode)]
        internal static extern IntPtr CreateDispatcherQueueController(DispatcherQueueOptions options,
                                                 [MarshalAs(UnmanagedType.IUnknown)]
                                        out object dispatcherQueueController);

        #endregion PInvoke declarations
    }

    #region COM Interop

    /*
    #undef INTERFACE
    #define INTERFACE ICompositorDesktopInterop
        DECLARE_INTERFACE_IID_(ICompositorDesktopInterop, IUnknown, "29E691FA-4567-4DCA-B319-D0F207EB6807")
        {
            IFACEMETHOD(CreateDesktopWindowTarget)(
                _In_ HWND hwndTarget,
                _In_ BOOL isTopmost,
                _COM_Outptr_ IDesktopWindowTarget * *result
                ) PURE;
        };
    */
    [ComImport]
    [Guid("29E691FA-4567-4DCA-B319-D0F207EB6807")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface ICompositorDesktopInterop
    {
        void CreateDesktopWindowTarget(IntPtr hwndTarget, bool isTopmost, out IntPtr test);
    }

    //[contract(Windows.Foundation.UniversalApiContract, 2.0)]
    //[exclusiveto(Windows.UI.Composition.CompositionTarget)]
    //[uuid(A1BEA8BA - D726 - 4663 - 8129 - 6B5E7927FFA6)]
    //interface ICompositionTarget : IInspectable
    //{
    //    [propget] HRESULT Root([out] [retval] Windows.UI.Composition.Visual** value);
    //    [propput] HRESULT Root([in] Windows.UI.Composition.Visual* value);
    //}

    [ComImport]
    [Guid("A1BEA8BA-D726-4663-8129-6B5E7927FFA6")]
    [InterfaceType(ComInterfaceType.InterfaceIsIInspectable)]
    public interface ICompositionTarget
    {
        Windows.UI.Composition.Visual Root
        {
            get;
            set;
        }
    }
    #endregion COM Interop
}
```