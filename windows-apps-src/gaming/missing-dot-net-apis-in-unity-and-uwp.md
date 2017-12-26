---
author: eliotcowley
title: "Unity や UWP で不足している .NET API"
description: "Unity で UWP ゲームを作成する際に不足している .NET API と、一般的な問題に対する回避策について説明します。"
ms.assetid: 28A8B061-5AE8-4CDA-B4AB-2EF0151E57C1
ms.author: elcowle
ms.date: 10/13/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、ゲーム、.NET、Unity"
localizationpriority: medium
ms.openlocfilehash: 2da10006a46b0e25b96fb70e9c8e7af061dd390c
ms.sourcegitcommit: 44a24b580feea0f188c7eae36e72e4a4f412802b
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2017
---
# <a name="missing-net-apis-in-unity-and-uwp"></a><span data-ttu-id="40dd4-104">Unity や UWP で不足している .NET API</span><span class="sxs-lookup"><span data-stu-id="40dd4-104">Missing .NET APIs in Unity and UWP</span></span>

<span data-ttu-id="40dd4-105">.NET を使用して UWP ゲームを作成する場合、Unity エディターで使用できる一部の API やスタンドアロン PC ゲーム用の一部の API が UWP 用に存在しないことがあります。</span><span class="sxs-lookup"><span data-stu-id="40dd4-105">When building a UWP game using .NET, you may find that some APIs that you might use in the Unity editor or for a standalone PC game are not present for UWP.</span></span> <span data-ttu-id="40dd4-106">これは、UWP アプリ用 .NET には、名前空間ごとに、フル バージョンの .NET Framework で提供される型のサブセットが含まれるためです。</span><span class="sxs-lookup"><span data-stu-id="40dd4-106">That's because .NET for UWP apps includes a subset of the types provided in the full .NET Framework for each namespace.</span></span>

<span data-ttu-id="40dd4-107">さらに、Unity の Mono など一部のゲーム エンジンは、UWP 用の .NET とは完全な互換性のない別の種類の .NET を使用しています。</span><span class="sxs-lookup"><span data-stu-id="40dd4-107">Additionally, some game engines use different flavors of .NET that aren't fully compatible with .NET for UWP, such as Unity's Mono.</span></span> <span data-ttu-id="40dd4-108">したがって、ゲームを作成する際に、エディターでは問題なく動作しても、UWP 用にビルドすると、"**型または名前空間の名前 'Formatters' は名前空間 'System.Runtime.Serialization' に存在しません (アセンブリ参照があることを確認してください)**" というエラーが出力される可能性があります。</span><span class="sxs-lookup"><span data-stu-id="40dd4-108">So when you're writing your game, everything might work fine in the editor, but when you go to build for UWP, you might get errors like this: **The type or namespace 'Formatters' does not exist in the namespace 'System.Runtime.Serialization' (are you missing an assembly reference?)**</span></span>

<span data-ttu-id="40dd4-109">幸いなことに、Unity では、これらの不足している API の一部を拡張メソッドや置換型として提供しています。詳しくは、[ユニバーサル Windows プラットフォームの .NET Scripting Backend で不足している .NET 型に関するページ](https://docs.unity3d.com/Manual/windowsstore-missingtypes.html)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-109">Fortunately, Unity provides some of these missing APIs as extension methods and replacement types, which are described in [Universal Windows Platform: Missing .NET Types on .NET Scripting Backend](https://docs.unity3d.com/Manual/windowsstore-missingtypes.html).</span></span> <span data-ttu-id="40dd4-110">ただし、必要な機能がここにない場合は、「[Windows ストア アプリ用 .NET の概要](https://msdn.microsoft.com/library/windows/apps/br230302)」で説明している方法に従って、WinRT または UWP 用 .NET の API を使用するようにコードを変換できます </span><span class="sxs-lookup"><span data-stu-id="40dd4-110">However, if the functionality you need is not here, [.NET for Windows 8.x apps overview](https://msdn.microsoft.com/library/windows/apps/br230302) discusses ways you can convert your code to use WinRT or .NET for UWP APIs.</span></span> <span data-ttu-id="40dd4-111">(このページでは、Windows 8 について説明していますが、Windows 10 の UWP アプリにも適用できます)。</span><span class="sxs-lookup"><span data-stu-id="40dd4-111">(It discusses Windows 8, but is applicable to Windows 10 UWP apps as well.)</span></span>

## <a name="net-standard"></a><span data-ttu-id="40dd4-112">.NET Standard</span><span class="sxs-lookup"><span data-stu-id="40dd4-112">.NET Standard</span></span>

<span data-ttu-id="40dd4-113">一部の API が動作しない理由を理解するには、.NET のさまざまな種類と、UWP での .NET の実装方法を理解しておく必要があります。</span><span class="sxs-lookup"><span data-stu-id="40dd4-113">To understand why some APIs might not be working, it's important to understand the different .NET flavors and how UWP implements .NET.</span></span> <span data-ttu-id="40dd4-114">[.NET Standard](https://docs.microsoft.com/dotnet/standard/net-standard) は、クロスプラットフォームに対応し、さまざまな種類の .NET を統一することを目的とした、.NET API の正式な仕様です。</span><span class="sxs-lookup"><span data-stu-id="40dd4-114">The [.NET Standard](https://docs.microsoft.com/dotnet/standard/net-standard) is a formal specification of .NET APIs that is meant to be cross-platform, and unify the different .NET flavors.</span></span> <span data-ttu-id="40dd4-115">.NET の各実装では、特定のバージョンの .NET Standard をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="40dd4-115">Each implementation of .NET supports a certain version of the .NET Standard.</span></span> <span data-ttu-id="40dd4-116">標準や実装の一覧表については、「[.NET 実装のサポート](https://docs.microsoft.com/dotnet/standard/net-standard#net-implementation-support)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-116">You can see a table of standards and implementations at [.NET implementation support](https://docs.microsoft.com/dotnet/standard/net-standard#net-implementation-support).</span></span>

<span data-ttu-id="40dd4-117">UWP SDK の各バージョンは、.NET Standard のさまざまなレベルに準拠しています。</span><span class="sxs-lookup"><span data-stu-id="40dd4-117">Each version of the UWP SDK conforms to a different level of .NET Standard.</span></span> <span data-ttu-id="40dd4-118">たとえば、16299 SDK (Fall Creators Update) では、.NET Standard 2.0 をサポートしています。</span><span class="sxs-lookup"><span data-stu-id="40dd4-118">For example, the 16299 SDK (the Fall Creators Update) supports .NET Standard 2.0.</span></span>

<span data-ttu-id="40dd4-119">ターゲットにしている UWP バージョンで特定の .NET API がサポートされるかどうかを確認する場合は、[.NET Standard API リファレンス](https://docs.microsoft.com/dotnet/api/index?view=netstandard-2.0)を参照して、そのバージョンの UWP でサポートされている .NET Standard のバージョンを選択します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-119">If you want to know if a certain .NET API is supported in the UWP version that you're targeting, you can check the [.NET Standard API Reference](https://docs.microsoft.com/dotnet/api/index?view=netstandard-2.0) and select the version of the .NET Standard that's supported by that version of UWP.</span></span>

## <a name="scripting-backend-configuration"></a><span data-ttu-id="40dd4-120">スクリプト バックエンドの構成</span><span class="sxs-lookup"><span data-stu-id="40dd4-120">Scripting backend configuration</span></span>

<span data-ttu-id="40dd4-121">UWP のビルドで問題が発生した場合に最初に行うことは、**[Player Settings] (プレーヤーの設定)** (**[File] (ファイル) > [Build Settings] (ビルド設定)**、**[Universal Windows Platform] (ユニバーサル Windows プラットフォーム)**、**[Player Settings] (プレーヤーの設定)** の順に選択) を確認することです。</span><span class="sxs-lookup"><span data-stu-id="40dd4-121">The first thing you should do if you're having trouble building for UWP is check the **Player Settings** (**File > Build Settings**, select **Universal Windows Platform**, and then **Player Settings**).</span></span> <span data-ttu-id="40dd4-122">**[Other Settings] (その他の設定) > [Configuration] (構成)** にある、最初の 3 つのドロップダウン リスト (**[Scripting Runtime Version] (スクリプト ランタイム バージョン)**、**[Scripting Backend] (スクリプト バックエンド)**、**[Api Compatibility Level] (API 互換性レベル)**) はいずれも考慮する必要がある重要な設定です。</span><span class="sxs-lookup"><span data-stu-id="40dd4-122">Under **Other Settings > Configuration**, the first three dropdowns (**Scripting Runtime Version**, **Scripting Backend**, and **Api Compatibility Level**) are all important settings to consider.</span></span>

<span data-ttu-id="40dd4-123">**[Scripting Runtime Version] (スクリプト ランタイム バージョン)** は、Unity スクリプト バックエンドが使用するもので、選択した .NET Framework サポートと (ほぼ) 同等のバージョンを取得できます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-123">The **Scripting Runtime Version** is what the Unity scripting backend uses which allows you to get the (roughly) equivalent version of .NET Framework support that you choose.</span></span> <span data-ttu-id="40dd4-124">ただし、そのバージョンの .NET Framework のすべての API がサポートされるわけではない点に注意してください。UWP がターゲットにしている .NET Standard のバージョンでサポートされている API のみがサポートされます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-124">However, keep in mind that not all APIs in that version of the .NET Framework will be supported, only those in the version of .NET Standard that your UWP is targeting.</span></span>

<span data-ttu-id="40dd4-125">新しい .NET リリースでは、通常、より多くの API が .NET Standard に追加され、スタンドアロンと UWP で同じコードを使用できるようになっている場合があります。</span><span class="sxs-lookup"><span data-stu-id="40dd4-125">Often with new .NET releases, more APIs are added to .NET Standard which might allow you to use the same code across standalone and UWP.</span></span> <span data-ttu-id="40dd4-126">たとえば、[System.Runtime.Serialization.Json](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.json) 名前空間は .NET Standard 2.0 で導入されました。</span><span class="sxs-lookup"><span data-stu-id="40dd4-126">For example, the [System.Runtime.Serialization.Json](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.json) namespace was introduced in .NET Standard 2.0.</span></span> <span data-ttu-id="40dd4-127">**[Scripting Runtime Version] (スクリプト ランタイム バージョン)** を **[.NET 3.5 Equivalent] (.NET 3.5 相当)** (以前のバージョンの .NET Standard をターゲットにする) に設定した場合、API を使用しようとしたときにエラーが表示されます。**[.NET 4.6 Equivalent] (.NET 4.6 相当)** (.NET Standard 2.0 をサポートする) に切り替えると、API は動作します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-127">If you set the **Scripting Runtime Version** to **.NET 3.5 Equivalent** (which targets an earlier version of the .NET Standard), you will get an error when trying to use the API; switch it to **.NET 4.6 Equivalent** (which supports .NET Standard 2.0), and the API will work.</span></span>

<span data-ttu-id="40dd4-128">**[Scripting Backend] (スクリプト バックエンド)** は、**[.NET]** または **[IL2CPP]** に設定できます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-128">The **Scripting Backend** can be **.NET** or **IL2CPP**.</span></span> <span data-ttu-id="40dd4-129">このトピックでは、.NET で発生する問題について説明しているため、**[.NET]** を選択していることを想定しています。</span><span class="sxs-lookup"><span data-stu-id="40dd4-129">For this topic, we assume you have chosen **.NET**, since that's where the problems discussed here arise.</span></span> <span data-ttu-id="40dd4-130">詳細については、[スクリプト バックエンドに関するページ](https://docs.unity3d.com/Manual/windowsstore-scriptingbackends.html)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-130">See [Scripting Backends](https://docs.unity3d.com/Manual/windowsstore-scriptingbackends.html) for more information.</span></span>

<span data-ttu-id="40dd4-131">最後に、**[Api Compatibility Level] (API 互換性レベル)** を、ゲームを実行する .NET のバージョンに設定します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-131">Finally, you should set the **Api Compatibility Level** to the version of .NET that you want your game to run on.</span></span> <span data-ttu-id="40dd4-132">これは、**[Scripting Runtime Version] (スクリプト ランタイム バージョン)** と一致している必要があります</span><span class="sxs-lookup"><span data-stu-id="40dd4-132">This should match the **Scripting Runtime Version**.</span></span>

<span data-ttu-id="40dd4-133">一般的に、**[Scripting Runtime Version] (スクリプト ランタイム バージョン)** と **[Api Compatibility Level] (API 互換性レベル)** については、.NET Framework との互換性を高め、より多くの .NET API を使用できるようにするために、利用可能な最新バージョンを選択してください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-133">In general, for **Scripting Runtime Version** and **Api Compatibility Level**, you should select the latest version available so as to have more compatibility with the .NET Framework, and thus allow you to use more .NET APIs.</span></span>

![構成: スクリプト ランタイム バージョン、スクリプト バックエンド、API 互換性レベル](images/missing-dot-net-apis-in-unity-1.png)

## <a name="platform-dependent-compilation"></a><span data-ttu-id="40dd4-135">プラットフォーム依存のコンパイル</span><span class="sxs-lookup"><span data-stu-id="40dd4-135">Platform-dependent compilation</span></span>

<span data-ttu-id="40dd4-136">UWP を含む複数のプラットフォーム用に Unity ゲームを作成する場合、ゲームが UWP として作成されたときにのみ、UWP 向けのコードが実行されるようにするために、プラットフォーム依存のコンパイルを使用できます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-136">If you're building your Unity game for multiple platforms, including UWP, you'll want to use platform-dependent compilation to make sure that code intended for UWP is only run when the game is built as a UWP.</span></span> <span data-ttu-id="40dd4-137">これにより、スタンドアロンのデスクトップやその他のプラットフォーム用にフル バージョンの .NET Framework を、UWP 用に WinRT API を使用でき、ビルド エラーが発生することはありません。</span><span class="sxs-lookup"><span data-stu-id="40dd4-137">This way, you can use the full .NET Framework for standalone desktop and other platforms, and WinRT APIs for UWP, without getting build errors.</span></span>

<span data-ttu-id="40dd4-138">UWP アプリとして実行する場合にのみコードをコンパイルするには、次のディレクティブを使用します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-138">Use the following directives to only compile code when running as a UWP app:</span></span>

```csharp
#if NETFX_CORE
    // Your UWP code here
#else
    // Your standard code here
#endif
```

> [!NOTE]
> `NETFX_CORE` <span data-ttu-id="40dd4-139">は、.NET スクリプト バックエンドに対して C# コードをコンパイルしているかどうかを確認することのみを目的としています。</span><span class="sxs-lookup"><span data-stu-id="40dd4-139">is only meant to check if you're compiling C# code against the .NET scripting backend.</span></span> <span data-ttu-id="40dd4-140">IL2CPP など、他のスクリプト バックエンドを使用している場合は、代わりに `UNITY_WSA_10_0` を使用します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-140">If you're using a different scripting backend, such as IL2CPP, use `UNITY_WSA_10_0` instead.</span></span>

<span data-ttu-id="40dd4-141">プラットフォーム依存のコンパイル ディレクティブの一覧については、[プラットフォーム依存のコンパイルに関するページ](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-141">For the full list of platform-dependent compilation directives, see [Platform dependent compilation](https://docs.unity3d.com/Manual/PlatformDependentCompilation.html).</span></span>

## <a name="common-issues-and-workarounds"></a><span data-ttu-id="40dd4-142">一般的な問題と回避方法</span><span class="sxs-lookup"><span data-stu-id="40dd4-142">Common issues and workarounds</span></span>

<span data-ttu-id="40dd4-143">次のシナリオでは、UWP のサブセットに .NET API がない場合に発生する可能性がある一般的な問題と、それらを回避する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-143">The following scenarios describe common issues that might arise where .NET APIs are missing from the UWP subset, and ways to get around them.</span></span>

### <a name="data-serialization-using-binaryformatter"></a><span data-ttu-id="40dd4-144">BinaryFormatter を使用したデータのシリアル化</span><span class="sxs-lookup"><span data-stu-id="40dd4-144">Data serialization using BinaryFormatter</span></span>

<span data-ttu-id="40dd4-145">ゲームでは、プレイヤーが簡単に操作ができないように、セーブ データをシリアル化するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="40dd4-145">It is common for games to serialize save data so that players can't easily manipulate it.</span></span> <span data-ttu-id="40dd4-146">ただし、オブジェクトをバイナリにシリアル化する [BinaryFormatter](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter) は、.NET Standard の以前のバージョン (2.0 よりも前) では使用できません。</span><span class="sxs-lookup"><span data-stu-id="40dd4-146">However, [BinaryFormatter](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.formatters.binary.binaryformatter), which serializes an object into binary, is not available in earlier versions of the .NET Standard (prior to 2.0).</span></span> <span data-ttu-id="40dd4-147">代わりに、[XmlSerializer](https://docs.microsoft.com/dotnet/api/system.xml.serialization.xmlserializer) または [DataContractJsonSerializer](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.json.datacontractjsonserializer) を使用することを検討してください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-147">Consider using [XmlSerializer](https://docs.microsoft.com/dotnet/api/system.xml.serialization.xmlserializer) or [DataContractJsonSerializer](https://docs.microsoft.com/dotnet/api/system.runtime.serialization.json.datacontractjsonserializer) instead.</span></span>

```csharp
private void Save()
{
    SaveData data = new SaveData(); // User-defined object to serialize

    DataContractJsonSerializer serializer = 
      new DataContractJsonSerializer(typeof(SaveData));

    FileStream stream = 
      new FileStream(Application.persistentDataPath, FileMode.CreateNew);

    serializer.WriteObject(stream, data);
    stream.Dispose();
}
```

### <a name="io-operations"></a><span data-ttu-id="40dd4-148">I/O 操作</span><span class="sxs-lookup"><span data-stu-id="40dd4-148">I/O operations</span></span>

<span data-ttu-id="40dd4-149">[System.IO](https://docs.microsoft.com/dotnet/api/system.io) 名前空間の一部の型 ([FileStream](https://docs.microsoft.com/dotnet/api/system.io.filestream) など) は、以前のバージョンの .NET Standard では使用できません。</span><span class="sxs-lookup"><span data-stu-id="40dd4-149">Some types in the [System.IO](https://docs.microsoft.com/dotnet/api/system.io) namespace, such as [FileStream](https://docs.microsoft.com/dotnet/api/system.io.filestream), are not available in earlier versions of the .NET Standard.</span></span> <span data-ttu-id="40dd4-150">ただし、Unity では、[Directory](https://docs.microsoft.com/dotnet/api/system.io.directory)、[File](https://docs.microsoft.com/dotnet/api/system.io.file)、および **FileStream** 型を提供しているため、ゲームでこれらを使用できます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-150">However, Unity does provide the [Directory](https://docs.microsoft.com/dotnet/api/system.io.directory), [File](https://docs.microsoft.com/dotnet/api/system.io.file), and **FileStream** types so you can use them in your game.</span></span>

<span data-ttu-id="40dd4-151">また、UWP アプリでのみ利用できる [Windows.Storage](https://docs.microsoft.com/uwp/api/Windows.Storage) API を使用することもできます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-151">Alternatively, you can use the [Windows.Storage](https://docs.microsoft.com/uwp/api/Windows.Storage) APIs, which are only available to UWP apps.</span></span> <span data-ttu-id="40dd4-152">ただし、これらの API では、アプリの書き込みは特定の記憶域に制限され、ファイル システム全体に自由にアクセスすることはできません。</span><span class="sxs-lookup"><span data-stu-id="40dd4-152">However, these APIs restrict the app to writing to their specific storage, and do not give it free access to the entire file system.</span></span> <span data-ttu-id="40dd4-153">詳しくは、「[ファイル、フォルダー、およびライブラリ](https://docs.microsoft.com/windows/uwp/files/)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="40dd4-153">See [Files, folders, and libraries](https://docs.microsoft.com/windows/uwp/files/) for more information.</span></span>

<span data-ttu-id="40dd4-154">重要な注意事項は、[Close](https://docs.microsoft.com/dotnet/api/system.io.stream.close) メソッドは、.NET Standard 2.0 以降でのみ利用できることです (ただし、Unity は拡張メソッドを提供しています)。</span><span class="sxs-lookup"><span data-stu-id="40dd4-154">One important note is that the [Close](https://docs.microsoft.com/dotnet/api/system.io.stream.close) method is only available in .NET Standard 2.0 and later (though Unity provides an extension method).</span></span> <span data-ttu-id="40dd4-155">代わりに、[Dispose](https://docs.microsoft.com/dotnet/api/system.io.stream.dispose) を使用します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-155">Use [Dispose](https://docs.microsoft.com/dotnet/api/system.io.stream.dispose) instead.</span></span>

### <a name="threading"></a><span data-ttu-id="40dd4-156">スレッド化</span><span class="sxs-lookup"><span data-stu-id="40dd4-156">Threading</span></span>

<span data-ttu-id="40dd4-157">[System.Threading](https://docs.microsoft.com/dotnet/api/system.threading) 名前空間の一部の型 ([ThreadPool](https://docs.microsoft.com/dotnet/api/system.threading.threadpool) など) は、以前のバージョンの .NET Standard では使用できません。</span><span class="sxs-lookup"><span data-stu-id="40dd4-157">Some types in the [System.Threading](https://docs.microsoft.com/dotnet/api/system.threading) namespaces, such as [ThreadPool](https://docs.microsoft.com/dotnet/api/system.threading.threadpool), are not available in earlier versions of the .NET Standard.</span></span> <span data-ttu-id="40dd4-158">このような場合は、代わりに [Windows.System.Threading](https://docs.microsoft.com/uwp/api/windows.system.threading) 名前空間を使用できます。</span><span class="sxs-lookup"><span data-stu-id="40dd4-158">In these cases, you can use the [Windows.System.Threading](https://docs.microsoft.com/uwp/api/windows.system.threading) namespace instead.</span></span>

<span data-ttu-id="40dd4-159">以下に、プラットフォーム依存のコンパイルを使用し、UWP と UWP 以外の両方のプラットフォーム用に準備して、Unity ゲームでスレッド化を処理する方法を示します。</span><span class="sxs-lookup"><span data-stu-id="40dd4-159">Here's how you could handle threading in a Unity game, using platform-dependent compilation to prepare for both UWP and non-UWP platforms:</span></span>

```csharp
private void UsingThreads()
{
#if NETFX_CORE
    Windows.System.Threading.ThreadPool.RunAsync(workItem => SomeMethod());
#else
    System.Threading.ThreadPool.QueueUserWorkItem(workItem => SomeMethod());
#endif
}
```

## <a name="see-also"></a><span data-ttu-id="40dd4-160">関連項目</span><span class="sxs-lookup"><span data-stu-id="40dd4-160">See also</span></span>

* [<span data-ttu-id="40dd4-161">ユニバーサル Windows プラットフォーム: .NET Scripting Backend で不足している .NET 型</span><span class="sxs-lookup"><span data-stu-id="40dd4-161">Universal Windows Platform: Missing .NET Types on .NET Scripting Backend</span></span>](https://docs.unity3d.com/Manual/windowsstore-missingtypes.html)
* [<span data-ttu-id="40dd4-162">UWP アプリ用の .NET の概要</span><span class="sxs-lookup"><span data-stu-id="40dd4-162">.NET for UWP apps overview</span></span>](https://msdn.microsoft.com/library/windows/apps/br230302)
* [<span data-ttu-id="40dd4-163">Unity UWP 移植ガイド</span><span class="sxs-lookup"><span data-stu-id="40dd4-163">Unity UWP porting guides</span></span>](https://unity3d.com/partners/microsoft/porting-guides)