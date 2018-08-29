---
author: PatrickFarley
title: アプリからの 3D 印刷
description: ユニバーサル Windows アプリに 3D 印刷機能を追加する方法について説明します。 このトピックでは、3D モデルが印刷可能であり、正しい形式になっていることを確認した後で 3D 印刷ダイアログを起動する方法について説明します。
ms.assetid: D78C4867-4B44-4B58-A82F-EDA59822119C
ms.author: pafarley
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, 3dprinting、3d 印刷
ms.localizationpriority: medium
ms.openlocfilehash: ae573fe87e6821555509467336e9a425fb082811
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2905587"
---
# <a name="3d-printing-from-your-app"></a><span data-ttu-id="d8a32-105">アプリからの 3D 印刷</span><span class="sxs-lookup"><span data-stu-id="d8a32-105">3D printing from your app</span></span>

**<span data-ttu-id="d8a32-106">重要な API</span><span class="sxs-lookup"><span data-stu-id="d8a32-106">Important APIs</span></span>**

-   [**<span data-ttu-id="d8a32-107">Windows.Graphics.Printing3D</span><span class="sxs-lookup"><span data-stu-id="d8a32-107">Windows.Graphics.Printing3D</span></span>**](https://msdn.microsoft.com/library/windows/apps/dn998169)

<span data-ttu-id="d8a32-108">ユニバーサル Windows アプリに 3D 印刷機能を追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-108">Learn how to add 3D printing functionality to your Universal Windows app.</span></span> <span data-ttu-id="d8a32-109">このトピックでは、アプリに 3D 形状データを読み込んだ後、その 3D モデルが印刷可能であり、正しい形式になっていることを確認してから 3D 印刷ダイアログを起動する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-109">This topic covers how to load 3D geometry data into your app and launch the 3D print dialog after ensuring your 3D model is printable and in the correct format.</span></span> <span data-ttu-id="d8a32-110">以下の手順の実例については、[3D 印刷の UWP サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d8a32-110">For a working example of these procedures, see the [3D printing UWP sample](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting).</span></span>

> [!NOTE]
> <span data-ttu-id="d8a32-111">このガイドのサンプル コードでは、簡潔にするためにエラー レポートと処理が大幅に簡略化されています。</span><span class="sxs-lookup"><span data-stu-id="d8a32-111">In the sample code in this guide, error reporting and handling is greatly simplified for the sake of simplicity.</span></span>

## <a name="setup"></a><span data-ttu-id="d8a32-112">セットアップ</span><span class="sxs-lookup"><span data-stu-id="d8a32-112">Setup</span></span>


<span data-ttu-id="d8a32-113">3D 印刷機能を搭載するアプリケーション クラスで、[**Windows.Graphics.Printing3D**](https://msdn.microsoft.com/library/windows/apps/dn998169) 名前空間を追加します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-113">In your application class that is to have 3D print functionality, add the [**Windows.Graphics.Printing3D**](https://msdn.microsoft.com/library/windows/apps/dn998169) namespace.</span></span>

[!code-cs[3DPrintNamespace](./code/3dprinthowto/cs/MainPage.xaml.cs#Snippet3DPrintNamespace)]

<span data-ttu-id="d8a32-114">このガイドでは、次の追加の名前空間を使います。</span><span class="sxs-lookup"><span data-stu-id="d8a32-114">The following additional namespaces will be used in this guide.</span></span>

[!code-cs[OtherNamespaces](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetOtherNamespaces)]

<span data-ttu-id="d8a32-115">次に、有用なメンバー フィールドをクラスに追加します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-115">Next, give your class helpful member fields.</span></span> <span data-ttu-id="d8a32-116">プリンター ドライバーに渡す印刷タスクを表すために、[**Print3DTask**](https://msdn.microsoft.com/library/windows/apps/dn998044) オブジェクトを宣言します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-116">Declare a [**Print3DTask**](https://msdn.microsoft.com/library/windows/apps/dn998044) object to represent the printing task that is to be passed to the print driver.</span></span> <span data-ttu-id="d8a32-117">アプリに読み込まれる元の 3D データ ファイルを保持するために、[**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) オブジェクトを宣言します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-117">Declare a [**StorageFile**](https://msdn.microsoft.com/library/windows/apps/br227171) object to hold the original 3D data file that will be loaded into the app.</span></span> <span data-ttu-id="d8a32-118">必要なすべてのメタデータが含まれた、印刷準備が完了した 3D モデルを表す [**Printing3D3MFPackage**](https://msdn.microsoft.com/library/windows/apps/dn998063) オブジェクトを宣言します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-118">Declare a [**Printing3D3MFPackage**](https://msdn.microsoft.com/library/windows/apps/dn998063) object, which represents a print-ready 3D model with all necessary metadata.</span></span>

[!code-cs[DeclareVars](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetDeclareVars)]

## <a name="create-a-simple-ui"></a><span data-ttu-id="d8a32-119">シンプルな UI の作成</span><span class="sxs-lookup"><span data-stu-id="d8a32-119">Create a simple UI</span></span>

<span data-ttu-id="d8a32-120">このサンプルでは、プログラム メモリにファイルを読み込む読み込みボタン、必要に応じてファイルを変更する修正ボタン、印刷ジョブを開始する印刷ボタンの 3 つのユーザー コントロールを使います。</span><span class="sxs-lookup"><span data-stu-id="d8a32-120">This sample features three user controls: a Load button which will bring a file into program memory, a Fix button which will modify the file as necessary, and a Print button which will initiate the print job.</span></span> <span data-ttu-id="d8a32-121">次のコードで、これらのボタン (クリック イベント ハンドラー付き) を .cs クラスの対応する XAML ファイルに作成します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-121">The following code creates these buttons (with their on-click event handlers) in your .cs class' corresponding XAML file.</span></span>

[!code-xml[Buttons](./code/3dprinthowto/cs/MainPage.xaml#SnippetButtons)]

<span data-ttu-id="d8a32-122">UI フィードバック用に **TextBlock** を追加します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-122">Add a **TextBlock** for UI feedback.</span></span>

[!code-xml[OutputText](./code/3dprinthowto/cs/MainPage.xaml#SnippetOutputText)]



## <a name="get-the-3d-data"></a><span data-ttu-id="d8a32-123">3D データの取得</span><span class="sxs-lookup"><span data-stu-id="d8a32-123">Get the 3D data</span></span>


<span data-ttu-id="d8a32-124">アプリでは、さまざまな方法で、3D 形状データを取得することができます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-124">The method by which your app acquires 3D geometry data will vary.</span></span> <span data-ttu-id="d8a32-125">たとえば、3D スキャンからデータを取得したり、Web リソースからのモデル データをダウンロードしたり、数式やユーザー入力を使ってプログラムによって 3D メッシュを生成したりできます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-125">Your app may retrieve data from a 3D scan, download model data from a web resource, or generate a 3D mesh programmatically using mathematical formulas or user input.</span></span> <span data-ttu-id="d8a32-126">ここでは簡単にするために、3D データ ファイル (一般的なファイルの種類のいずれか) をデバイスのストレージからプログラム メモリに読み込む方法を示します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-126">For the sake of simplicity, this guide will show how to load a 3D data file (of any of several common file types) into program memory from device storage.</span></span> <span data-ttu-id="d8a32-127">[3D Builder モデル ライブラリ](https://developer.microsoft.com/windows/hardware/3d-builder-model-library)には幅広いモデルが用意されており、デバイスに簡単にダウンロードできます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-127">The [3D Builder model library](https://developer.microsoft.com/windows/hardware/3d-builder-model-library) provides a variety of models that you can easily download to your device.</span></span>

<span data-ttu-id="d8a32-128">`OnLoadClick` メソッドで、[**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) クラスを使って、1 つのファイルをアプリのメモリに読み込みます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-128">In your `OnLoadClick` method, use the [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) class to load a single file into your app's memory.</span></span>

[!code-cs[FileLoad](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetFileLoad)]

## <a name="use-3d-builder-to-convert-to-3d-manufacturing-format-3mf"></a><span data-ttu-id="d8a32-129">3D Builder による 3D Manufacturing Format (.3mf) への変換</span><span class="sxs-lookup"><span data-stu-id="d8a32-129">Use 3D Builder to convert to 3D Manufacturing Format (.3mf)</span></span>

<span data-ttu-id="d8a32-130">これで、3D データ ファイルをアプリのメモリに読み込むことができます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-130">At this point, you are able to load a 3D data file into your app's memory.</span></span> <span data-ttu-id="d8a32-131">ただし、3D 形状データには、さまざまな形式がありますが、すべてが 3D 印刷に効率的であるわけではありません。</span><span class="sxs-lookup"><span data-stu-id="d8a32-131">However, 3D geometry data can come in many different formats, and not all are efficient for 3D printing.</span></span> <span data-ttu-id="d8a32-132">Windows 10 では、すべての 3D 印刷タスクについて 3D Manufacturing Format (.3mf) というファイル形式を使います。</span><span class="sxs-lookup"><span data-stu-id="d8a32-132">Windows 10 uses the 3D Manufacturing Format (.3mf) file type for all 3D printing tasks.</span></span>

> [!NOTE]  
> <span data-ttu-id="d8a32-133">.3mf ファイル形式には、このチュートリアルで扱っている機能以外にも多くの機能が用意されています。</span><span class="sxs-lookup"><span data-stu-id="d8a32-133">The .3mf file type offers more functionality than is covered in this tutorial.</span></span> <span data-ttu-id="d8a32-134">3MF と 3D 製品のプロデューサーおよびコンシューマー向けに用意されたその機能について詳しくは、[3MF の仕様](http://3mf.io/what-is-3mf/3mf-specification/)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d8a32-134">To learn more about 3MF and the features it provides to producers and consumers of 3D products, see the [3MF Specification](http://3mf.io/what-is-3mf/3mf-specification/).</span></span> <span data-ttu-id="d8a32-135">Windows 10 API を使ってこれらの機能を利用する方法については、「[3MF パッケージの生成](https://msdn.microsoft.com/windows/uwp/devices-sensors/generate-3mf)」チュートリアルをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="d8a32-135">To learn how to utilize these features with Windows 10 APIs, see the [Generate a 3MF package](https://msdn.microsoft.com/windows/uwp/devices-sensors/generate-3mf) tutorial.</span></span>

<span data-ttu-id="d8a32-136">[3D Builder](https://www.microsoft.com/store/apps/3d-builder/9wzdncrfj3t6) アプリでは、一般的なほとんどの 3D 形式のファイルを開くことができ、それらを .3mf ファイル形式で保存することができます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-136">The [3D Builder](https://www.microsoft.com/store/apps/3d-builder/9wzdncrfj3t6) app can open files of most popular 3D formats and save them as .3mf files.</span></span> <span data-ttu-id="d8a32-137">この例では、ファイルの種類が異なる場合に、簡単な解決策として、3D Builder アプリを開き、インポートしたデータを .3mf ファイルとして保存し再度読み込むようユーザーに求めます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-137">In this example, where the file type could vary, a very simple solution is to open the 3D Builder app and prompt the user to save the imported data as a .3mf file and then reload it.</span></span>

> [!NOTE]  
> <span data-ttu-id="d8a32-138">
3D Builder には、ファイル形式の変換以外にも、モデルを編集したり色データを追加したりといった、印刷に固有の操作を行うための簡単なツールが用意されているため、多くの場合、3D 印刷を処理するアプリに統合するだけの価値があります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-138">In addition to converting file formats, 3D Builder provides simple tools to edit your models, add color data, and perform other print-specific operations, so it is often worth integrating into an app that deals with 3D printing.</span></span>

[!code-cs[FileCheck](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetFileCheck)]

## <a name="repair-model-data-for-3d-printing"></a><span data-ttu-id="d8a32-139">3D 印刷可能なモデル データへの修復</span><span class="sxs-lookup"><span data-stu-id="d8a32-139">Repair model data for 3D printing</span></span>

<span data-ttu-id="d8a32-140">.3mf 形式であっても、すべての 3D モデル データが印刷可能なわけではありません。</span><span class="sxs-lookup"><span data-stu-id="d8a32-140">Not all 3D model data is printable, even in the .3mf type.</span></span> <span data-ttu-id="d8a32-141">どこを埋めて何を空洞のままにするかをプリンターに正しく判断させるには、印刷する (各) モデルが 1 つのシームレスなメッシュであること、モデルの面の法線が外側を向いていること、またモデルがマニホールド形状であることが必要条件となります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-141">In order for the printer to correctly determine what space to fill and what to leave empty, the model(s) to be printed must (each) be a single seamless mesh, have outward-facing surface normals, and have manifold geometry.</span></span> <span data-ttu-id="d8a32-142">これらの問題は、さまざまな形で現れることがあり、図形が複雑な場合は、見つけるのが難しいことがあります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-142">Issues in these areas can arise in a variety of different forms and can be hard to spot in complex shapes.</span></span> <span data-ttu-id="d8a32-143">ただし、最新のソフトウェア ソリューションは、多くの場合、元データの形状を印刷可能な 3D 図形に変換するのに十分な機能を備えています。</span><span class="sxs-lookup"><span data-stu-id="d8a32-143">However, modern software solutions are often adequate for converting raw geometry to printable 3D shapes.</span></span> <span data-ttu-id="d8a32-144">これはモデルの*修復*と呼ばれ、`OnFixClick` メソッドで行われます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-144">This is known as *repairing* the model and will be done in the `OnFixClick` method.</span></span>

<span data-ttu-id="d8a32-145">[**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731) を実装し、[**Printing3DModel**](https://msdn.microsoft.com/library/windows/apps/mt203679) オブジェクトを生成します。これを行うには、3D データ ファイルを変換する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-145">The 3D data file must be converted to implement [**IRandomAccessStream**](https://msdn.microsoft.com/library/windows/apps/br241731), which can then be used to generate a [**Printing3DModel**](https://msdn.microsoft.com/library/windows/apps/mt203679) object.</span></span>

[!code-cs[RepairModel](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetRepairModel)]

<span data-ttu-id="d8a32-146">これで、**Printing3DModel** オブジェクトを印刷できる状態に修復できました。</span><span class="sxs-lookup"><span data-stu-id="d8a32-146">The **Printing3DModel** object is now repaired and printable.</span></span> <span data-ttu-id="d8a32-147">[**SaveModelToPackageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3d3mfpackage.savemodeltopackageasync) を使って、クラスを作成したときに宣言した **Printing3D3MFPackage** オブジェクトにモデルを割り当てます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-147">Use [**SaveModelToPackageAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.printing3d3mfpackage.savemodeltopackageasync) to assign the model to the **Printing3D3MFPackage** object that you declared when creating the class.</span></span>

[!code-cs[SaveModel](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetSaveModel)]

## <a name="execute-printing-task-create-a-taskrequested-handler"></a><span data-ttu-id="d8a32-148">印刷タスクの実行: TaskRequested ハンドラーの作成</span><span class="sxs-lookup"><span data-stu-id="d8a32-148">Execute printing task: create a TaskRequested handler</span></span>


<span data-ttu-id="d8a32-149">3D 印刷ダイアログをユーザーに表示してユーザーが印刷を開始したときに、アプリが目的のパラメーターを 3D 印刷パイプラインに渡す必要があります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-149">Later on, when the 3D print dialog is displayed to the user and the user elects to begin printing, your app will need to pass in the desired parameters to the 3D print pipeline.</span></span> <span data-ttu-id="d8a32-150">3D 印刷 API によって、**[TaskRequested](https://docs.microsoft.com/uwp/api/Windows.Graphics.Printing3D.Print3DManager.TaskRequested)** イベントが発生します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-150">The 3D print API will raise the **[TaskRequested](https://docs.microsoft.com/uwp/api/Windows.Graphics.Printing3D.Print3DManager.TaskRequested)** event.</span></span> <span data-ttu-id="d8a32-151">このイベントを適切に処理するメソッドを記述する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-151">You must write a method to handle this event appropriately.</span></span> <span data-ttu-id="d8a32-152">通常どおり、ハンドラー メソッドはイベントと同じ型である必要があります。**TaskRequested** イベントには、パラメーター [**Print3DManager**](https://msdn.microsoft.com/library/windows/apps/dn998029) (センダー オブジェクトへの参照) と [**Print3DTaskRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn998051) オブジェクト (ほとんどの関連情報を保持するオブジェクト) があります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-152">As always, the handler method must be of the same type as its event: The **TaskRequested** event has parameters [**Print3DManager**](https://msdn.microsoft.com/library/windows/apps/dn998029) (a reference to its sender object) and a [**Print3DTaskRequestedEventArgs**](https://msdn.microsoft.com/library/windows/apps/dn998051) object, which holds most of the relevant information.</span></span>

[!code-cs[MyTaskTitle](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetMyTaskTitle)]

<span data-ttu-id="d8a32-153">このメソッドの主な目的は、*args* パラメーターを使って、**Printing3D3MFPackage** をパイプラインに送信することです。</span><span class="sxs-lookup"><span data-stu-id="d8a32-153">The core purpose of this method is to use the *args* parameter to send a **Printing3D3MFPackage** down the pipeline.</span></span> <span data-ttu-id="d8a32-154">**Print3DTaskRequestedEventArgs** 型には、[**Request**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtaskrequestedeventargs.request.aspx) という 1 つのプロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-154">The **Print3DTaskRequestedEventArgs** type has one property: [**Request**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtaskrequestedeventargs.request.aspx).</span></span> <span data-ttu-id="d8a32-155">その型は [**Print3DTaskRequest**](https://msdn.microsoft.com/library/windows/apps/dn998050) で、1 つの印刷ジョブ要求を表します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-155">It is of the type [**Print3DTaskRequest**](https://msdn.microsoft.com/library/windows/apps/dn998050) and represents one print job request.</span></span> <span data-ttu-id="d8a32-156">そのメソッドである [**CreateTask**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtaskrequest.createtask.aspx) を使って、プログラムは印刷ジョブに関する適切な情報を送信します。このメソッドは、3D 印刷パイプラインに送信された **Print3DTask** オブジェクトへの参照を返します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-156">Its method [**CreateTask**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtaskrequest.createtask.aspx) allows the program to submit the correct information for your print job, and it returns a reference to the **Print3DTask** object which was sent down the 3D print pipeline.</span></span>

<span data-ttu-id="d8a32-157">**CreateTask** には、印刷ジョブ名を表す string、使うプリンターの ID を表す string、および [**Print3DTaskSourceRequestedHandler**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtasksourcerequestedhandler.aspx) デリゲートという入力パラメーターがあります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-157">**CreateTask** has the following input parameters: a string for the print job name, a string for the ID of the printer to use, and a [**Print3DTaskSourceRequestedHandler**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtasksourcerequestedhandler.aspx) delegate.</span></span> <span data-ttu-id="d8a32-158">このデリゲートは、**3DTaskSourceRequested** イベントが発生したときに自動的に呼び出されます (これは API によって行われます)。</span><span class="sxs-lookup"><span data-stu-id="d8a32-158">The delegate is automatically invoked when the **3DTaskSourceRequested** event is raised (this is done by the API itself).</span></span> <span data-ttu-id="d8a32-159">重要なのは、印刷ジョブが開始されたときにこのデリゲートが呼び出され、適切な 3D 印刷パッケージを提供する役割を果たすということです。</span><span class="sxs-lookup"><span data-stu-id="d8a32-159">The important thing to note is that this delegate is invoked when a print job is initiated, and it is responsible for providing the right 3D print package.</span></span>

<span data-ttu-id="d8a32-160">**Print3DTaskSourceRequestedHandler** は、送信するデータを提供する [**Print3DTaskSourceRequestedArgs**](https://msdn.microsoft.com/library/windows/apps/dn998056) オブジェクトという 1 つのパラメーターを取ります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-160">**Print3DTaskSourceRequestedHandler** takes one parameter, a [**Print3DTaskSourceRequestedArgs**](https://msdn.microsoft.com/library/windows/apps/dn998056) object which provides the data to be sent.</span></span> <span data-ttu-id="d8a32-161">このクラスの 1 つのパブリック メソッドである [**SetSource**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtasksourcerequestedargs.setsource.aspx) が、印刷するパッケージを受け取ります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-161">The one public method of this class, [**SetSource**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dtasksourcerequestedargs.setsource.aspx), accepts the package to be printed.</span></span> <span data-ttu-id="d8a32-162">次のように、**Print3DTaskSourceRequestedHandler** デリゲートを実装します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-162">Implement a **Print3DTaskSourceRequestedHandler** delegate as follows.</span></span>

[!code-cs[SourceHandler](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetSourceHandler)]

<span data-ttu-id="d8a32-163">次に、新しく定義したデリゲート `sourceHandler` を使って、**CreateTask** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-163">Next, call **CreateTask**, using the newly-defined delegate, `sourceHandler`.</span></span>

[!code-cs[CreateTask](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetCreateTask)]

<span data-ttu-id="d8a32-164">返された **Print3DTask** が、最初に宣言したクラス変数に割り当てられます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-164">The returned **Print3DTask** is assigned to the class variable declared in the beginning.</span></span> <span data-ttu-id="d8a32-165">これで、必要に応じてこの参照を使い、タスクによってスローされた特定のイベントを処理できるようになりました。</span><span class="sxs-lookup"><span data-stu-id="d8a32-165">You can now (optionally) use this reference to handle certain events thrown by the task.</span></span>

[!code-cs[Optional](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetOptional)]

> [!NOTE]  
> <span data-ttu-id="d8a32-166">これらのイベントに `Task_Submitting` および `Task_Completed` メソッドを登録するには、それらを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-166">You must implement a `Task_Submitting` and `Task_Completed` method if you wish to register them to these events.</span></span>

## <a name="execute-printing-task-open-3d-print-dialog"></a><span data-ttu-id="d8a32-167">印刷タスクの実行: 3D 印刷ダイアログを開く</span><span class="sxs-lookup"><span data-stu-id="d8a32-167">Execute printing task: open 3D print dialog</span></span>


<span data-ttu-id="d8a32-168">最後に 3D 印刷ダイアログを起動する短いコードが必要になります。</span><span class="sxs-lookup"><span data-stu-id="d8a32-168">The final piece of code needed is that which launches the 3D print dialog.</span></span> <span data-ttu-id="d8a32-169">従来の印刷ダイアログ ウィンドウと同じように、3D 印刷ダイアログでも、最後に使った印刷オプションがいくつか表示され、ユーザーは使うプリンターを (USB かネットワーク接続かに関係なく) 選択することができます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-169">Like a conventional printing dialog window, the 3D print dialog provides a number of last-minute printing options and allows the user to choose which printer to use (whether connected by USB or the network).</span></span>

<span data-ttu-id="d8a32-170">`MyTaskRequested` メソッドを **TaskRequested** イベントに登録します。</span><span class="sxs-lookup"><span data-stu-id="d8a32-170">Register your `MyTaskRequested` method with the **TaskRequested** event.</span></span>

[!code-cs[RegisterMyTaskRequested](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetRegisterMyTaskRequested)]

<span data-ttu-id="d8a32-171">**TaskRequested** イベント ハンドラーを登録したら、メソッド [**ShowPrintUIAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dmanager.showprintuiasync.aspx) を呼び出して、現在のアプリケーション ウィンドウに 3D 印刷ダイアログを表示することができます。</span><span class="sxs-lookup"><span data-stu-id="d8a32-171">After registering your **TaskRequested** event handler, you can invoke the method [**ShowPrintUIAsync**](https://msdn.microsoft.com/library/windows/apps/windows.graphics.printing3d.print3dmanager.showprintuiasync.aspx), which brings up the 3D print dialog in the current application window.</span></span>

[!code-cs[ShowDialog](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetShowDialog)]

<span data-ttu-id="d8a32-172">最後に、アプリにコントロールが戻ったら、イベント ハンドラーの登録を解除することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="d8a32-172">Finally, it is a good practice to de-register your event handlers once your app resumes control.</span></span>  

[!code-cs[DeregisterMyTaskRequested](./code/3dprinthowto/cs/MainPage.xaml.cs#SnippetDeregisterMyTaskRequested)]

## <a name="related-topics"></a><span data-ttu-id="d8a32-173">関連トピック</span><span class="sxs-lookup"><span data-stu-id="d8a32-173">Related topics</span></span>

[<span data-ttu-id="d8a32-174">3MF パッケージの生成</span><span class="sxs-lookup"><span data-stu-id="d8a32-174">Generate a 3MF package</span></span>](https://msdn.microsoft.com/windows/uwp/devices-sensors/generate-3mf)  
[<span data-ttu-id="d8a32-175">3D 印刷の UWP サンプル</span><span class="sxs-lookup"><span data-stu-id="d8a32-175">3D printing UWP sample</span></span>](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/3DPrinting)
 

 
