---
Description: この記事では、ビデオ ストリームのカスタム効果を作成するための IBasicVideoEffect インターフェイスを実装する Windows ランタイム コンポーネントを作成する方法について説明します。
MS-HAID: dev\_audio\_vid\_camera.custom\_video\_effects
MSHAttr: PreferredLib:/library/windows/apps
Search.Product: eADQiWindows 10XVcnh
title: カスタムのビデオ特殊効果
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 40a6bd32-a756-400f-ba34-2c5f507262c0
ms.localizationpriority: medium
ms.openlocfilehash: 1e48febb3fb49a35fe256e58cf7c80b4abe93267
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57623087"
---
# <a name="custom-video-effects"></a><span data-ttu-id="7f6b6-104">カスタムのビデオ特殊効果</span><span class="sxs-lookup"><span data-stu-id="7f6b6-104">Custom video effects</span></span>




<span data-ttu-id="7f6b6-105">この記事では、ビデオ ストリームのカスタム効果を作成するための [**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) インターフェイスを実装する Windows ランタイム コンポーネントを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-105">This article describes how to create a Windows Runtime component that implements the [**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) interface to create custom effects for video streams.</span></span> <span data-ttu-id="7f6b6-106">カスタム効果は、デバイスのカメラへのアクセスを提供する [MediaCapture](https://msdn.microsoft.com/library/windows/apps/br241124)、メディア クリップから複雑なコンポジションを作成するための [**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646) など、さまざまな Windows ランタイム API で使うことができます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-106">Custom effects can be used with several different Windows Runtime APIs including [MediaCapture](https://msdn.microsoft.com/library/windows/apps/br241124), which provides access to a device's camera, and [**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646), which allows you to create complex compositions out of media clips.</span></span>

## <a name="add-a-custom-effect-to-your-app"></a><span data-ttu-id="7f6b6-107">アプリへのカスタム効果の追加</span><span class="sxs-lookup"><span data-stu-id="7f6b6-107">Add a custom effect to your app</span></span>


<span data-ttu-id="7f6b6-108">カスタムのビデオ特殊効果は、[**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) インターフェイスを実装するクラスで定義します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-108">A custom video effect is defined in a class that implements the [**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) interface.</span></span> <span data-ttu-id="7f6b6-109">このクラスは、アプリのプロジェクトに直接含めることはできません。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-109">This class can't be included directly in your app's project.</span></span> <span data-ttu-id="7f6b6-110">代わりに、Windows ランタイム コンポーネントを使ってビデオ特殊効果のクラスをホストする必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-110">Instead, you must use a Windows Runtime component to host your video effect class.</span></span>

<span data-ttu-id="7f6b6-111">**Windows ランタイム コンポーネント、ビデオ特殊効果の追加します。**</span><span class="sxs-lookup"><span data-stu-id="7f6b6-111">**Add a Windows Runtime component for your video effect**</span></span>

1.  <span data-ttu-id="7f6b6-112">Microsoft Visual Studio で、ソリューションを開き、**[ファイル]** メニューから **[追加]、[新しいプロジェクト]** の順にクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-112">In Microsoft Visual Studio, with your solution open, go to the **File** menu and select **Add-&gt;New Project**.</span></span>
2.  <span data-ttu-id="7f6b6-113">プロジェクトの種類として **[Windows ランタイム コンポーネント (ユニバーサル Windows)]** を選びます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-113">Select the **Windows Runtime Component (Universal Windows)** project type.</span></span>
3.  <span data-ttu-id="7f6b6-114">この例では、プロジェクトに *VideoEffectComponent* という名前を付けます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-114">For this example, name the project *VideoEffectComponent*.</span></span> <span data-ttu-id="7f6b6-115">この名前は後でコードで参照されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-115">This name will be referenced in code later.</span></span>
4.  <span data-ttu-id="7f6b6-116">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-116">Click **OK**.</span></span>
5.  <span data-ttu-id="7f6b6-117">プロジェクト テンプレートに基づいて、Class1.cs という名前のクラスが作成されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-117">The project template creates a class called Class1.cs.</span></span> <span data-ttu-id="7f6b6-118">**ソリューション エクスプローラー**で、Class1.cs のアイコンを右クリックし、**[名前の変更]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-118">In **Solution Explorer**, right-click the icon for Class1.cs and select **Rename**.</span></span>
6.  <span data-ttu-id="7f6b6-119">ファイル名を *ExampleVideoEffect.cs* に変更します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-119">Rename the file to *ExampleVideoEffect.cs*.</span></span> <span data-ttu-id="7f6b6-120">すべての参照を新しい名前に更新するかどうかを確認するメッセージが表示されたら、</span><span class="sxs-lookup"><span data-stu-id="7f6b6-120">Visual Studio will show a prompt asking if you want to update all references to the new name.</span></span> <span data-ttu-id="7f6b6-121">**[はい]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-121">Click **Yes**.</span></span>
7.  <span data-ttu-id="7f6b6-122">**ExampleVideoEffect.cs** を開き、クラス定義を更新して [**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) インターフェイスを実装します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-122">Open **ExampleVideoEffect.cs** and update the class definition to implement the [**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) interface.</span></span>

[!code-cs[ImplementIBasicVideoEffect](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetImplementIBasicVideoEffect)]


<span data-ttu-id="7f6b6-123">この記事の例で使うすべての型にアクセスできるように、効果のクラス ファイルに次の名前空間を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-123">You need to include the following namespaces in your effect class file in order to access all of the types used in the examples in this article.</span></span>

[!code-cs[EffectUsing](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetEffectUsing)]


## <a name="implement-the-ibasicvideoeffect-interface-using-software-processing"></a><span data-ttu-id="7f6b6-124">ソフトウェア処理を使用した IBasicVideoEffect インターフェイスの実装</span><span class="sxs-lookup"><span data-stu-id="7f6b6-124">Implement the IBasicVideoEffect interface using software processing</span></span>


<span data-ttu-id="7f6b6-125">ビデオ特殊効果では、[**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) インターフェイスのすべてのメソッドとプロパティを実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-125">Your video effect must implement all of the methods and properties of the [**IBasicVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn764788) interface.</span></span> <span data-ttu-id="7f6b6-126">このセクションでは、このインターフェイスの実装方法の説明として、ソフトウェア処理を使用した簡単な実装を示します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-126">This section walks you through a simple implementation of this interface that uses software processing.</span></span>

### <a name="close-method"></a><span data-ttu-id="7f6b6-127">Close メソッド</span><span class="sxs-lookup"><span data-stu-id="7f6b6-127">Close method</span></span>

<span data-ttu-id="7f6b6-128">[  **Close**](https://msdn.microsoft.com/library/windows/apps/dn764789) メソッドは、クラスで効果をシャットダウンする必要があるときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-128">The system will call the [**Close**](https://msdn.microsoft.com/library/windows/apps/dn764789) method on your class when the effect should shut down.</span></span> <span data-ttu-id="7f6b6-129">このメソッドを使って、作成したすべてのリソースを破棄する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-129">You should use this method to dispose of any resources you have created.</span></span> <span data-ttu-id="7f6b6-130">このメソッドの [**MediaEffectClosedReason**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.MediaEffectClosedReason) 引数により、効果が正常に終了されたかどうかがわかります。エラーが発生したり、必要なエンコード形式が効果でサポートされていないと、この引数で通知されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-130">The argument to the method is a [**MediaEffectClosedReason**](https://msdn.microsoft.com/library/windows/apps/Windows.Media.Effects.MediaEffectClosedReason) that lets you know whether the effect was closed normally, if an error occurred, or if the effect does not support the required encoding format.</span></span>

[!code-cs[Close](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetClose)]


### <a name="discardqueuedframes-method"></a><span data-ttu-id="7f6b6-131">DiscardQueuedFrames メソッド</span><span class="sxs-lookup"><span data-stu-id="7f6b6-131">DiscardQueuedFrames method</span></span>

<span data-ttu-id="7f6b6-132">[  **DiscardQueuedFrames**](https://msdn.microsoft.com/library/windows/apps/dn764790) メソッドは、効果をリセットする必要があるときに呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-132">The [**DiscardQueuedFrames**](https://msdn.microsoft.com/library/windows/apps/dn764790) method is called when your effect should reset.</span></span> <span data-ttu-id="7f6b6-133">典型的なシナリオとしては、現在のフレームの処理で使うために前に処理したフレームを保存している場合などが挙げられます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-133">A typical scenario for this is if your effect stores previously processed frames to use in processing the current frame.</span></span> <span data-ttu-id="7f6b6-134">このメソッドが呼び出されたときは、保存した一連のフレームを破棄する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-134">When this method is called, you should dispose of the set of previous frames you saved.</span></span> <span data-ttu-id="7f6b6-135">このメソッドでは、蓄積されたビデオ フレームだけでなく、前のフレームに関連するすべての状態をリセットできます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-135">This method can be used to reset any state related to previous frames, not only accumulated video frames.</span></span>


[!code-cs[DiscardQueuedFrames](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetDiscardQueuedFrames)]



### <a name="isreadonly-property"></a><span data-ttu-id="7f6b6-136">IsReadOnly プロパティ</span><span class="sxs-lookup"><span data-stu-id="7f6b6-136">IsReadOnly property</span></span>

<span data-ttu-id="7f6b6-137">[  **IsReadOnly**](https://msdn.microsoft.com/library/windows/apps/dn764792) プロパティは、効果の出力への書き込みを行うかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-137">The [**IsReadOnly**](https://msdn.microsoft.com/library/windows/apps/dn764792) property lets the system know if your effect will write to the output of the effect.</span></span> <span data-ttu-id="7f6b6-138">アプリでビデオ フレームを変更しない場合 (ビデオ フレームの分析のみを行う場合など) は、このプロパティを true に設定します。これにより、フレーム入力がフレーム出力に効率的にコピーされるようになります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-138">If your app does not modify the video frames (for example, an effect that only performs analysis of the video frames), you should set this property to true, which will cause the system to efficiently copy the frame input to the frame output for you.</span></span>

> [!TIP]
> <span data-ttu-id="7f6b6-139">[  **IsReadOnly**](https://msdn.microsoft.com/library/windows/apps/dn764792) プロパティを true に設定すると、入力フレームが出力フレームにコピーされてから [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) が呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-139">When the [**IsReadOnly**](https://msdn.microsoft.com/library/windows/apps/dn764792) property is set to true, the system copies the input frame to the output frame before [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) is called.</span></span> <span data-ttu-id="7f6b6-140">**IsReadOnly** プロパティを true に設定しても、**ProcessFrame** での効果の出力フレームに対する書き込みは制限されません。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-140">Setting the **IsReadOnly** property to true does not restrict you from writing to the effect's output frames in **ProcessFrame**.</span></span>


[!code-cs[IsReadOnly](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetIsReadOnly)]

### <a name="setencodingproperties-method"></a><span data-ttu-id="7f6b6-141">SetEncodingProperties メソッド</span><span class="sxs-lookup"><span data-stu-id="7f6b6-141">SetEncodingProperties method</span></span>

<span data-ttu-id="7f6b6-142">[  **SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) は、効果の対象となるビデオ ストリームのエンコード プロパティを示すために呼び出されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-142">The system calls [**SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) on your effect to let you know the encoding properties for the video stream upon which the effect is operating.</span></span> <span data-ttu-id="7f6b6-143">このメソッドは、ハードウェア レンダリングに使う Direct3D デバイスへの参照も提供します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-143">This method also provides a reference to the Direct3D device used for hardware rendering.</span></span> <span data-ttu-id="7f6b6-144">このデバイスの用途については、この後のハードウェア処理の例で説明します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-144">The usage of this device is shown in the hardware processing example later in this article.</span></span>

[!code-cs[SetEncodingProperties](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetSetEncodingProperties)]


### <a name="supportedencodingproperties-property"></a><span data-ttu-id="7f6b6-145">SupportedEncodingProperties プロパティ</span><span class="sxs-lookup"><span data-stu-id="7f6b6-145">SupportedEncodingProperties property</span></span>

<span data-ttu-id="7f6b6-146">[  **SupportedEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn764799) プロパティは、効果でサポートされるエンコード プロパティを確認するためにシステムでチェックされます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-146">The system checks the [**SupportedEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn764799) property to determine which encoding properties are supported by your effect.</span></span> <span data-ttu-id="7f6b6-147">効果で指定したプロパティを使ってビデオをエンコードできない場合、[**Close**](https://msdn.microsoft.com/library/windows/apps/dn764789) が呼び出され、効果がビデオ パイプラインから削除されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-147">Note that if the consumer of your effect can't encode video using the properties you specify, it will call [**Close**](https://msdn.microsoft.com/library/windows/apps/dn764789) on your effect and will remove your effect from the video pipeline.</span></span>


[!code-cs[SupportedEncodingProperties](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetSupportedEncodingProperties)]


> [!NOTE] 
> <span data-ttu-id="7f6b6-148">**SupportedEncodingProperties** から返される [**VideoEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701217) オブジェクトの一覧を空にすると、既定で ARGB32 エンコードが使われます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-148">If you return an empty list of [**VideoEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/hh701217) objects from **SupportedEncodingProperties**, the system will default to ARGB32 encoding.</span></span>

 

### <a name="supportedmemorytypes-property"></a><span data-ttu-id="7f6b6-149">SupportedMemoryTypes プロパティ</span><span class="sxs-lookup"><span data-stu-id="7f6b6-149">SupportedMemoryTypes property</span></span>

<span data-ttu-id="7f6b6-150">[  **SupportedMemoryTypes**](https://msdn.microsoft.com/library/windows/apps/dn764801) プロパティは、ソフトウェア メモリとハードウェア (GPU) メモリのどちらのビデオ フレームにアクセスするかを確認するためにシステムでチェックされます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-150">The system checks the [**SupportedMemoryTypes**](https://msdn.microsoft.com/library/windows/apps/dn764801) property to determine whether your effect will access video frames in software memory or in hardware (GPU) memory.</span></span> <span data-ttu-id="7f6b6-151">[  **MediaMemoryTypes.Cpu**](https://msdn.microsoft.com/library/windows/apps/dn764822) を指定すると、画像データを [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトに格納する入力フレームと出力フレームが渡されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-151">If you return [**MediaMemoryTypes.Cpu**](https://msdn.microsoft.com/library/windows/apps/dn764822), your effect will be passed input and output frames that contain image data in [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) objects.</span></span> <span data-ttu-id="7f6b6-152">**MediaMemoryTypes.Gpu** を指定すると、画像データを [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) オブジェクトに格納する入力フレームと出力フレームが渡されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-152">If you return **MediaMemoryTypes.Gpu**, your effect will be passed input and output frames that contain image data in [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) objects.</span></span>

[!code-cs[SupportedMemoryTypes](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetSupportedMemoryTypes)]


> [!NOTE]
> <span data-ttu-id="7f6b6-153">[  **MediaMemoryTypes.GpuAndCpu**](https://msdn.microsoft.com/library/windows/apps/dn764822) を指定すると、GPU とシステム メモリのどちらを使うかがパイプラインの効率に基づいて判断されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-153">If you specify [**MediaMemoryTypes.GpuAndCpu**](https://msdn.microsoft.com/library/windows/apps/dn764822), the system will use either GPU or system memory, whichever is more efficient for the pipeline.</span></span> <span data-ttu-id="7f6b6-154">この値を使う場合は、[**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) メソッドで [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) と [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) のどちらにデータが格納されたかをチェックし、それに応じてフレームを処理する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-154">When using this value, you must check in the [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) method to see whether the [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) or [**IDirect3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn965505) passed into the method contains data, and then process the frame accordingly.</span></span>

 

### <a name="timeindependent-property"></a><span data-ttu-id="7f6b6-155">TimeIndependent プロパティ</span><span class="sxs-lookup"><span data-stu-id="7f6b6-155">TimeIndependent property</span></span>

<span data-ttu-id="7f6b6-156">[  **TimeIndependent**](https://msdn.microsoft.com/library/windows/apps/dn764803) プロパティは、効果のタイミングを合わせる必要がないかどうかを示します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-156">The [**TimeIndependent**](https://msdn.microsoft.com/library/windows/apps/dn764803) property lets the system know if your effect does not require uniform timing.</span></span> <span data-ttu-id="7f6b6-157">true に設定すると、効果のパフォーマンスを高めるために最適化を使用できるようになります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-157">When set to true, the system can use optimizations that enhance effect performance.</span></span>

[!code-cs[TimeIndependent](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetTimeIndependent)]

### <a name="setproperties-method"></a><span data-ttu-id="7f6b6-158">SetProperties メソッド</span><span class="sxs-lookup"><span data-stu-id="7f6b6-158">SetProperties method</span></span>

<span data-ttu-id="7f6b6-159">[  **SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986) メソッドは、呼び出し元のアプリで効果のパラメーターを調整するために使われます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-159">The [**SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986) method allows the app that is using your effect to adjust effect parameters.</span></span> <span data-ttu-id="7f6b6-160">プロパティは、プロパティ名と値の [**IPropertySet**](https://msdn.microsoft.com/library/windows/apps/br226054) マップとして渡されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-160">Properties are passed as an [**IPropertySet**](https://msdn.microsoft.com/library/windows/apps/br226054) map of property names and values.</span></span>


[!code-cs[SetProperties](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetSetProperties)]


<span data-ttu-id="7f6b6-161">指定の値に基づいて各ビデオ フレームのピクセルを暗くする簡単な例を次に示します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-161">This simple example will dim the pixels in each video frame according to a specified value.</span></span> <span data-ttu-id="7f6b6-162">プロパティを宣言し、呼び出し元アプリで設定された値を TryGetValue で取得しています。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-162">A property is declared and TryGetValue is used to get the value set by the calling app.</span></span> <span data-ttu-id="7f6b6-163">値が設定されていない場合は、既定値の .5 が使われます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-163">If no value was set, a default value of .5 is used.</span></span>

[!code-cs[FadeValue](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetFadeValue)]


### <a name="processframe-method"></a><span data-ttu-id="7f6b6-164">ProcessFrame メソッド</span><span class="sxs-lookup"><span data-stu-id="7f6b6-164">ProcessFrame method</span></span>

<span data-ttu-id="7f6b6-165">[  **ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) メソッドは、ビデオの画像データを変更するためのメソッドです。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-165">The [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) method is where your effect modifies the image data of the video.</span></span> <span data-ttu-id="7f6b6-166">このメソッドはフレームごとに 1 回呼び出され、[**ProcessVideoFrameContext**](https://msdn.microsoft.com/library/windows/apps/dn764826) オブジェクトが渡されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-166">The method is called once per frame and is passed a [**ProcessVideoFrameContext**](https://msdn.microsoft.com/library/windows/apps/dn764826) object.</span></span> <span data-ttu-id="7f6b6-167">このオブジェクトには、処理対象の着信フレームを格納する入力 [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) オブジェクトと、ビデオ パイプラインの残りの部分に渡す画像データを書き込む出力 **VideoFrame** オブジェクトが含まれています。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-167">This object contains an input [**VideoFrame**](https://msdn.microsoft.com/library/windows/apps/dn930917) object that contains the incoming frame to be processed and an output **VideoFrame** object to which you write image data that will be passed on to rest of the video pipeline.</span></span> <span data-ttu-id="7f6b6-168">それらの **VideoFrame** オブジェクトのそれぞれに [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) プロパティと [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) プロパティがありますが、どちらを使用できるかは [**SupportedMemoryTypes**](https://msdn.microsoft.com/library/windows/apps/dn764801) で指定した値で決まります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-168">Each of these **VideoFrame** objects has a [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn930926) property and a [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) property, but which of these can be used is determined by the value you returned from the [**SupportedMemoryTypes**](https://msdn.microsoft.com/library/windows/apps/dn764801) property.</span></span>

<span data-ttu-id="7f6b6-169">ここでは、ソフトウェア処理を使用した **ProcessFrame** メソッドの簡単な実装例を示します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-169">This example shows a simple implementation of the **ProcessFrame** method using software processing.</span></span> <span data-ttu-id="7f6b6-170">[  **SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) オブジェクトの操作について詳しくは、「[イメージング](imaging.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-170">For more information about working with [**SoftwareBitmap**](https://msdn.microsoft.com/library/windows/apps/dn887358) objects, see [Imaging](imaging.md).</span></span> <span data-ttu-id="7f6b6-171">ハードウェア処理を使用した **ProcessFrame** の実装例については、この記事の後半で紹介します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-171">An example **ProcessFrame** implementation using hardware processing is shown later in this article.</span></span>

<span data-ttu-id="7f6b6-172">**SoftwareBitmap** のデータ バッファーにアクセスするには COM 相互運用機能が必要になるため、効果のクラス ファイルに **System.Runtime.InteropServices** 名前空間を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-172">Accessing the data buffer of a **SoftwareBitmap** requires COM interop, so you should include the **System.Runtime.InteropServices** namespace in your effect class file.</span></span>

[!code-cs[COMUsing](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetCOMUsing)]


<span data-ttu-id="7f6b6-173">効果の名前空間に次のコードを追加して、画像のバッファーにアクセスするためのインターフェイスをインポートします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-173">Add the following code inside the namespace for your effect to import the interface for accessing the image buffer.</span></span>

[!code-cs[COMImport](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetCOMImport)]


> [!NOTE]
> <span data-ttu-id="7f6b6-174">この手法では管理対象外のネイティブの画像バッファーにアクセスするため、アンセーフ コードを許可するようにプロジェクトを構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-174">Because this technique accesses a native, unmanaged image buffer, you will need to configure your project to allow unsafe code.</span></span>
> 1.  <span data-ttu-id="7f6b6-175">ソリューション エクスプローラーで、VideoEffectComponent プロジェクトを右クリックし、**[プロパティ]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-175">In Solution Explorer, right-click the VideoEffectComponent project and select **Properties**.</span></span>
> 2.  <span data-ttu-id="7f6b6-176">**[ビルド]** タブを選択します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-176">Select the **Build** tab.</span></span>
> 3.  <span data-ttu-id="7f6b6-177">**[アンセーフ コードの許可]** チェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-177">Select the **Allow unsafe code** check box.</span></span>

 

<span data-ttu-id="7f6b6-178">これで、**ProcessFrame** メソッドの実装を追加できます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-178">Now you can add the **ProcessFrame** method implementation.</span></span> <span data-ttu-id="7f6b6-179">最初に、入力と出力の両方のソフトウェア ビットマップから [**BitmapBuffer**](https://msdn.microsoft.com/library/windows/apps/dn887325) オブジェクトを取得します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-179">First, this method obtains a [**BitmapBuffer**](https://msdn.microsoft.com/library/windows/apps/dn887325) object from both the input and output software bitmaps.</span></span> <span data-ttu-id="7f6b6-180">出力フレームが書き込み用で、入力フレームが読み取り用です。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-180">Note that the output frame is opened for writing and the input for reading.</span></span> <span data-ttu-id="7f6b6-181">次に、[**CreateReference**](https://msdn.microsoft.com/library/windows/apps/dn949046) を呼び出して、各バッファーの [**IMemoryBufferReference**](https://msdn.microsoft.com/library/windows/apps/dn921671) を取得します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-181">Next, an [**IMemoryBufferReference**](https://msdn.microsoft.com/library/windows/apps/dn921671) is obtained for each buffer by calling [**CreateReference**](https://msdn.microsoft.com/library/windows/apps/dn949046).</span></span> <span data-ttu-id="7f6b6-182">その後、実際のデータ バッファーを取得するために、先ほど定義した COM 相互運用機能のインターフェイス (**IMemoryByteAccess**) として **IMemoryBufferReference** オブジェクトをキャストし、**GetBuffer** を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-182">Then, the actual data buffer is obtained by casting the **IMemoryBufferReference** objects as the COM interop interface defined above, **IMemoryByteAccess**, and then calling **GetBuffer**.</span></span>

<span data-ttu-id="7f6b6-183">これで、データ バッファーが取得され、入力バッファーからの読み取りと出力バッファーへの書き込みが可能になります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-183">Now that the data buffers have been obtained, you can read from the input buffer and write to the output buffer.</span></span> <span data-ttu-id="7f6b6-184">[  **GetPlaneDescription**](https://msdn.microsoft.com/library/windows/apps/dn887330) を呼び出して、バッファーのレイアウトを取得します。バッファーの幅、ストライド、初期オフセットについての情報が提供されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-184">The layout of the buffer is obtained by calling [**GetPlaneDescription**](https://msdn.microsoft.com/library/windows/apps/dn887330), which provides information on the width, stride, and initial offset of the buffer.</span></span> <span data-ttu-id="7f6b6-185">ピクセルあたりのビット数は、[**SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) メソッドで既に設定したエンコード プロパティで決まります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-185">The bits per pixel is determined by the encoding properties set previously with the [**SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) method.</span></span> <span data-ttu-id="7f6b6-186">バッファーの形式情報を使って、各ピクセルのバッファーへのインデックスを特定します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-186">The buffer format information is used to find the index into the buffer for each pixel.</span></span> <span data-ttu-id="7f6b6-187">ソース バッファーのピクセル値をターゲット バッファーにコピーし、そのカラー値にこの効果の FadeValue プロパティで定義した値を掛けます。これで、指定した値に応じてピクセルが暗くなります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-187">The pixel value from the source buffer is copied into the target buffer, with the color values being multiplied by the FadeValue property defined for this effect to dim them by the specified amount.</span></span>

[!code-cs[ProcessFrameSoftwareBitmap](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffect.cs#SnippetProcessFrameSoftwareBitmap)]


## <a name="implement-the-ibasicvideoeffect-interface-using-hardware-processing"></a><span data-ttu-id="7f6b6-188">ハードウェア処理を使用した IBasicVideoEffect インターフェイスの実装</span><span class="sxs-lookup"><span data-stu-id="7f6b6-188">Implement the IBasicVideoEffect interface using hardware processing</span></span>


<span data-ttu-id="7f6b6-189">カスタムのビデオ特殊効果をハードウェア (GPU) 処理を使って作成する場合も、方法は上記のソフトウェア処理を使った場合とほぼ同じです。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-189">Creating a custom video effect by using hardware (GPU) processing is almost identical to using software processing as described above.</span></span> <span data-ttu-id="7f6b6-190">このセクションでは、効果にハードウェア処理を使う場合のいくつかの違いについて説明します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-190">This section will show the few differences in an effect that uses hardware processing.</span></span> <span data-ttu-id="7f6b6-191">この例では、Win2D Windows ランタイム API を使います。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-191">This example uses the Win2D Windows Runtime API.</span></span> <span data-ttu-id="7f6b6-192">Win2D を使う方法について詳しくは、[Win2D のドキュメント](https://go.microsoft.com/fwlink/?LinkId=519078)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-192">For more information about using Win2D, see the [Win2D documentation](https://go.microsoft.com/fwlink/?LinkId=519078).</span></span>

<span data-ttu-id="7f6b6-193">次の手順に従って、この記事の最初に「**アプリへのカスタム効果の追加**」で作成したプロジェクトに Win2D NuGet パッケージを追加します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-193">Use the following steps to add the Win2D NuGet package to the project you created as described in the **Add a custom effect to your app** section at the beginning of this article.</span></span>

<span data-ttu-id="7f6b6-194">**効果プロジェクトに Win2D NuGet パッケージを追加するには**</span><span class="sxs-lookup"><span data-stu-id="7f6b6-194">**To add the Win2D NuGet package to your effect project**</span></span>

1.  <span data-ttu-id="7f6b6-195">**ソリューション エクスプローラー**で、**VideoEffectComponent** プロジェクトを右クリックし、**[NuGet パッケージの管理]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-195">In **Solution Explorer**, right-click the **VideoEffectComponent** project and select **Manage NuGet Packages**.</span></span>
2.  <span data-ttu-id="7f6b6-196">ウィンドウの上部で **[参照]** タブをクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-196">At the top of the window, select the **Browse** tab.</span></span>
3.  <span data-ttu-id="7f6b6-197">検索ボックスに **「Win2D」** と入力します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-197">In the search box, enter **Win2D**.</span></span>
4.  <span data-ttu-id="7f6b6-198">**[Win2D.uwp]** を選択し、右のウィンドウで **[インストール]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-198">Select **Win2D.uwp**, and then select **Install** in the right pane.</span></span>
5.  <span data-ttu-id="7f6b6-199">**[変更の確認]** ダイアログに、インストールするパッケージが表示されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-199">The **Review Changes** dialog shows you the package to be installed.</span></span> <span data-ttu-id="7f6b6-200">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-200">Click **OK**.</span></span>
6.  <span data-ttu-id="7f6b6-201">パッケージのライセンスに同意します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-201">Accept the package license.</span></span>

<span data-ttu-id="7f6b6-202">基本的なプロジェクトのセットアップに含まれる名前空間に加え、Win2D で提供される次の名前空間を含める必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-202">In addition to the namespaces included in the basic project setup, you will need to include the following namespaces provided by Win2D.</span></span>

[!code-cs[UsingWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetUsingWin2D)]


<span data-ttu-id="7f6b6-203">この効果では画像データの操作に GPU メモリを使うため、[**SupportedMemoryTypes**](https://msdn.microsoft.com/library/windows/apps/dn764801) プロパティで [**MediaMemoryTypes.Gpu**](https://msdn.microsoft.com/library/windows/apps/dn764822) を返します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-203">Because this effect will use GPU memory for operating on the image data, you should return [**MediaMemoryTypes.Gpu**](https://msdn.microsoft.com/library/windows/apps/dn764822) from the [**SupportedMemoryTypes**](https://msdn.microsoft.com/library/windows/apps/dn764801) property.</span></span>

[!code-cs[SupportedMemoryTypesWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetSupportedMemoryTypesWin2D)]


<span data-ttu-id="7f6b6-204">効果でサポートするエンコード プロパティを [**SupportedEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn764799) プロパティで設定します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-204">Set the encoding properties that your effect will support with the [**SupportedEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn764799) property.</span></span> <span data-ttu-id="7f6b6-205">Win2D を操作するときは、ARGB32 エンコードを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-205">When working with Win2D, you must use ARGB32 encoding.</span></span>

[!code-cs[SupportedEncodingPropertiesWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetSupportedEncodingPropertiesWin2D)]


<span data-ttu-id="7f6b6-206">[  **SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) メソッドを使って、メソッドに渡される [**IDirect3DDevice**](https://msdn.microsoft.com/library/windows/apps/dn895092) から新しい Win2D **CanvasDevice** オブジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-206">Use the [**SetEncodingProperties**](https://msdn.microsoft.com/library/windows/apps/dn919884) method to create a new Win2D **CanvasDevice** object from the [**IDirect3DDevice**](https://msdn.microsoft.com/library/windows/apps/dn895092) passed into the method.</span></span>

[!code-cs[SetEncodingPropertiesWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetSetEncodingPropertiesWin2D)]


<span data-ttu-id="7f6b6-207">[  **SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986) の実装は前述のソフトウェア処理の例と同じです。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-207">The [**SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986) implementation is identical to the previous software processing example.</span></span> <span data-ttu-id="7f6b6-208">この例では、**BlurAmount** プロパティを使って Win2D のぼかし効果を設定します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-208">This example uses a **BlurAmount** property to configure a Win2D blur effect.</span></span>

[!code-cs[SetPropertiesWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetSetPropertiesWin2D)]

[!code-cs[BlurAmountWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetBlurAmountWin2D)]


<span data-ttu-id="7f6b6-209">最後に、画像データを実際に処理する [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) メソッドを実装します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-209">The last step is to implement the [**ProcessFrame**](https://msdn.microsoft.com/library/windows/apps/dn764794) method that actually processes the image data.</span></span>

<span data-ttu-id="7f6b6-210">Win2D API を使って、入力フレームの [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) プロパティから **CanvasBitmap** を作成します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-210">Using Win2D APIs, a **CanvasBitmap** is created from the input frame's [**Direct3DSurface**](https://msdn.microsoft.com/library/windows/apps/dn930920) property.</span></span> <span data-ttu-id="7f6b6-211">出力フレームの **Direct3DSurface** から **CanvasRenderTarget** を作成し、このレンダー ターゲットから **CanvasDrawingSession** を作成します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-211">A **CanvasRenderTarget** is created from the output frame's **Direct3DSurface** and a **CanvasDrawingSession** is created from this render target.</span></span> <span data-ttu-id="7f6b6-212">新しい Win2D **GaussianBlurEffect** を初期化し、[**SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986) で **BlurAmount** プロパティを使って効果を公開します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-212">A new Win2D **GaussianBlurEffect** is initialized, using the **BlurAmount** property our effect exposes via [**SetProperties**](https://msdn.microsoft.com/library/windows/apps/br240986).</span></span> <span data-ttu-id="7f6b6-213">最後に、**CanvasDrawingSession.DrawImage** メソッドを呼び出して、入力ビットマップをレンダー ターゲットにぼかし効果を使って描画します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-213">Finally, the **CanvasDrawingSession.DrawImage** method is called to draw the input bitmap to the render target using the blur effect.</span></span>

[!code-cs[ProcessFrameWin2D](./code/VideoEffect_Win10/cs/VideoEffectComponent/ExampleVideoEffectWin2D.cs#SnippetProcessFrameWin2D)]


## <a name="adding-your-custom-effect-to-your-app"></a><span data-ttu-id="7f6b6-214">アプリへのカスタム効果の追加</span><span class="sxs-lookup"><span data-stu-id="7f6b6-214">Adding your custom effect to your app</span></span>


<span data-ttu-id="7f6b6-215">アプリからビデオ特殊効果を使うには、効果のプロジェクトへの参照をアプリに追加する必要があります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-215">To use your video effect from your app, you must add a reference to the effect project to your app.</span></span>

1.  <span data-ttu-id="7f6b6-216">ソリューション エクスプローラーで、アプリのプロジェクトの下にある **[参照設定]** を右クリックし、**[参照の追加]** を選択します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-216">In Solution Explorer, under your app project, right-click **References** and select **Add reference**.</span></span>
2.  <span data-ttu-id="7f6b6-217">**[プロジェクト]** タブを展開し、**[ソリューション]** を選択して、効果のプロジェクトの名前に対応するチェック ボックスをオンにします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-217">Expand the **Projects** tab, select **Solution**, and then select the check box for your effect project name.</span></span> <span data-ttu-id="7f6b6-218">この例では、*VideoEffectComponent* という名前です。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-218">For this example, the name is *VideoEffectComponent*.</span></span>
3.  <span data-ttu-id="7f6b6-219">**[OK]** をクリックします。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-219">Click **OK**.</span></span>

### <a name="add-your-custom-effect-to-a-camera-video-stream"></a><span data-ttu-id="7f6b6-220">カメラのビデオ ストリームへのカスタム効果の追加</span><span class="sxs-lookup"><span data-stu-id="7f6b6-220">Add your custom effect to a camera video stream</span></span>

<span data-ttu-id="7f6b6-221">「[シンプルなカメラ プレビューへのアクセス](simple-camera-preview-access.md)」の手順に従って、カメラからのシンプルなプレビュー ストリームを設定できます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-221">You can set up a simple preview stream from the camera by following the steps in the article [Simple camera preview access](simple-camera-preview-access.md).</span></span> <span data-ttu-id="7f6b6-222">この手順を実行すると、カメラのビデオ ストリームへのアクセスに使う初期化済みの [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) オブジェクトが得られます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-222">Following those steps will provide you with an initialized [**MediaCapture**](https://msdn.microsoft.com/library/windows/apps/br241124) object that is used to access the camera's video stream.</span></span>

<span data-ttu-id="7f6b6-223">カスタムのビデオ特殊効果をカメラ ストリームに追加するには、まず、新しい [**VideoEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608055) オブジェクトを作成し、効果の名前空間とクラスの名前を渡します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-223">To add your custom video effect to a camera stream, first create a new [**VideoEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608055) object, passing in the namespace and class name for your effect.</span></span> <span data-ttu-id="7f6b6-224">次に、**MediaCapture** オブジェクトの [**AddVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn878035) メソッドを呼び出して、指定したストリームに効果を追加します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-224">Next, call the **MediaCapture** object's [**AddVideoEffect**](https://msdn.microsoft.com/library/windows/apps/dn878035) method to add your effect to the specified stream.</span></span> <span data-ttu-id="7f6b6-225">この例では、[**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) 値を使って、効果をプレビュー ストリームに追加するように指定します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-225">This example uses the [**MediaStreamType.VideoPreview**](https://msdn.microsoft.com/library/windows/apps/br226640) value to specify that the effect should be added to the preview stream.</span></span> <span data-ttu-id="7f6b6-226">アプリがビデオ キャプチャをサポートしている場合は、**MediaStreamType.VideoRecord** を使ってキャプチャ ストリームに効果を追加することもできます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-226">If your app supports video capture, you could also use **MediaStreamType.VideoRecord** to add the effect to the capture stream.</span></span> <span data-ttu-id="7f6b6-227">**AddVideoEffect** から、カスタム効果を表す [**IMediaExtension**](https://msdn.microsoft.com/library/windows/apps/br240985) オブジェクトが返されます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-227">**AddVideoEffect** returns an [**IMediaExtension**](https://msdn.microsoft.com/library/windows/apps/br240985) object representing your custom effect.</span></span> <span data-ttu-id="7f6b6-228">効果の設定は SetProperties メソッドを使って設定できます。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-228">You can use the SetProperties method to set the configuration for your effect.</span></span>

<span data-ttu-id="7f6b6-229">効果が追加されると、[**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) が呼び出されてプレビュー ストリームが始まります。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-229">After the effect has been added, [**StartPreviewAsync**](https://msdn.microsoft.com/library/windows/apps/br226613) is called to start the preview stream.</span></span>

[!code-cs[AddVideoEffectAsync](./code/VideoEffect_Win10/cs/VideoEffect_Win10/MainPage.xaml.cs#SnippetAddVideoEffectAsync)]



### <a name="add-your-custom-effect-to-a-clip-in-a-mediacomposition"></a><span data-ttu-id="7f6b6-230">MediaComposition のクリップへのカスタム効果の追加</span><span class="sxs-lookup"><span data-stu-id="7f6b6-230">Add your custom effect to a clip in a MediaComposition</span></span>

<span data-ttu-id="7f6b6-231">ビデオ クリップからメディア コンポジションを作成する一般的なガイダンスについては、「[メディア コンポジションと編集](media-compositions-and-editing.md)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-231">For general guidance for creating media compositions from video clips, see [Media compositions and editing](media-compositions-and-editing.md).</span></span> <span data-ttu-id="7f6b6-232">次のコード スニペットは、カスタムのビデオ特殊効果を使ってシンプルなメディア コンポジションを作成する例を示しています。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-232">The following code snippet shows the creation of a simple media composition that uses a custom video effect.</span></span> <span data-ttu-id="7f6b6-233">[  **CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652607) を呼び出して [**MediaClip**](https://msdn.microsoft.com/library/windows/apps/dn652596) オブジェクトを作成し、ユーザーが [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847) で選択したビデオ ファイルを渡して新しい [**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646) にクリップを追加します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-233">A [**MediaClip**](https://msdn.microsoft.com/library/windows/apps/dn652596) object is created by calling [**CreateFromFileAsync**](https://msdn.microsoft.com/library/windows/apps/dn652607), passing in a video file that was selected by the user with a [**FileOpenPicker**](https://msdn.microsoft.com/library/windows/apps/br207847), and the clip is added to a new [**MediaComposition**](https://msdn.microsoft.com/library/windows/apps/dn652646).</span></span> <span data-ttu-id="7f6b6-234">次に、新しい [**VideoEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608055) オブジェクトを作成し、効果の名前空間とクラスの名前を渡します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-234">Next a new [**VideoEffectDefinition**](https://msdn.microsoft.com/library/windows/apps/dn608055) object is created, passing in the namespace and class name for your effect to the constructor.</span></span> <span data-ttu-id="7f6b6-235">最後に、**MediaClip** オブジェクトの [**VideoEffectDefinitions**](https://msdn.microsoft.com/library/windows/apps/dn652643) コレクションに効果の定義を追加します。</span><span class="sxs-lookup"><span data-stu-id="7f6b6-235">Finally, the effect definition is added to the [**VideoEffectDefinitions**](https://msdn.microsoft.com/library/windows/apps/dn652643) collection of the **MediaClip** object.</span></span>


[!code-cs[AddEffectToComposition](./code/VideoEffect_Win10/cs/VideoEffect_Win10/MainPage.xaml.cs#SnippetAddEffectToComposition)]


## <a name="related-topics"></a><span data-ttu-id="7f6b6-236">関連トピック</span><span class="sxs-lookup"><span data-stu-id="7f6b6-236">Related topics</span></span>
* [<span data-ttu-id="7f6b6-237">単純なカメラのプレビューへのアクセス</span><span class="sxs-lookup"><span data-stu-id="7f6b6-237">Simple camera preview access</span></span>](simple-camera-preview-access.md)
* [<span data-ttu-id="7f6b6-238">メディア コンポジションと編集</span><span class="sxs-lookup"><span data-stu-id="7f6b6-238">Media compositions and editing</span></span>](media-compositions-and-editing.md)
* [<span data-ttu-id="7f6b6-239">Win2D ドキュメント</span><span class="sxs-lookup"><span data-stu-id="7f6b6-239">Win2D documentation</span></span>](https://go.microsoft.com/fwlink/p/?LinkId=519078)
* [<span data-ttu-id="7f6b6-240">メディア再生</span><span class="sxs-lookup"><span data-stu-id="7f6b6-240">Media playback</span></span>](media-playback.md)