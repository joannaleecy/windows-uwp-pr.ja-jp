---
title: ARM32 UWP アプリのトラブルシューティング
description: ARM で実行する際の ARM32 アプリの一般的な問題とその解決方法。
ms.date: 05/09/2018
ms.topic: article
keywords: windows 10 s, 常時接続, ARM での ARM32 アプリ, ARM 版 windows 10, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 6858f9add2430dc83d468b98d4147cc205dd372e
ms.sourcegitcommit: b11f305dbf7649c4b68550b666487c77ea30d98f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/27/2018
ms.locfileid: "7850591"
---
# <a name="troubleshooting-arm32-uwp-apps"></a><span data-ttu-id="8eb70-104">ARM32 UWP アプリのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="8eb70-104">Troubleshooting ARM32 UWP apps</span></span>
>[!IMPORTANT]
> <span data-ttu-id="8eb70-105">ARM64 SDK は、現在 Visual Studio 15.8 Preview 1 の一部として利用できます。</span><span class="sxs-lookup"><span data-stu-id="8eb70-105">The ARM64 SDK is now available as part of Visual Studio 15.8 Preview 1.</span></span> <span data-ttu-id="8eb70-106">アプリがフル ネイティブ速度で実行されるように、アプリを ARM64 に再コンパイルすることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="8eb70-106">We recommend that you recompile your app to ARM64 so that your app runs at full native speed.</span></span> <span data-ttu-id="8eb70-107">詳細については、「[ARM 開発での Windows 10 の Visual Studio サポートの初期プレビュー](https://blogs.windows.com/buildingapps/2018/05/08/visual-studio-support-for-windows-10-on-arm-development/)」に関するブログ記事を参照してください。</span><span class="sxs-lookup"><span data-stu-id="8eb70-107">For more info, see the [Early preview of Visual Studio support for Windows 10 on ARM development](https://blogs.windows.com/buildingapps/2018/05/08/visual-studio-support-for-windows-10-on-arm-development/) blog post.</span></span>

<span data-ttu-id="8eb70-108">ARM32 UWP アプリが ARM で正しく動作しない場合に役立つガイダンスを示します。</span><span class="sxs-lookup"><span data-stu-id="8eb70-108">If your ARM32 UWP app isn't working correctly on ARM, here's some guidance that may help.</span></span> 

## <a name="common-issues"></a><span data-ttu-id="8eb70-109">一般的な問題</span><span class="sxs-lookup"><span data-stu-id="8eb70-109">Common issues</span></span>
<span data-ttu-id="8eb70-110">ARM32 アプリをトラブルシューティングするときに念頭に置く必要のある一般的な問題を次に示します。</span><span class="sxs-lookup"><span data-stu-id="8eb70-110">Here are some common issues to keep in mind when troubleshooting ARM32 apps.</span></span>

### <a name="using-windows-10-mobile-only-apis-on-arm-based-processors"></a><span data-ttu-id="8eb70-111">ARM ベースのプロセッサでの Windows 10 Mobile 専用 API の使用</span><span class="sxs-lookup"><span data-stu-id="8eb70-111">Using Windows 10 Mobile-only APIs on ARM-based processors</span></span> 
<span data-ttu-id="8eb70-112">モバイル専用 API (**HardwareButtons** など) を使う場合、ARM32 アプリで問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8eb70-112">ARM32 apps may run into problems when using mobile-only APIs (for example, **HardwareButtons**).</span></span> <span data-ttu-id="8eb70-113">これを軽減するには、それらの API を呼び出す前に Windows 10 Mobile でアプリが実行されているかどうかを動的に検出します。</span><span class="sxs-lookup"><span data-stu-id="8eb70-113">To mitigate this, you can dynamically detect whether your app is running on Windows 10 Mobile before calling these APIs.</span></span> <span data-ttu-id="8eb70-114">[API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)に関するブログ投稿のガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="8eb70-114">Follow the guidance in the blog post, [Dynamically detecting features with API contracts](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/).</span></span>

### <a name="including-dependencies-not-supported-by-uwp-apps"></a><span data-ttu-id="8eb70-115">UWP アプリによりサポートされていない依存関係の追加</span><span class="sxs-lookup"><span data-stu-id="8eb70-115">Including dependencies not supported by UWP apps</span></span>
<span data-ttu-id="8eb70-116">Visual Studio と UWP SDK を使って適切にビルドされていないユニバーサル Windows プラットフォーム (UWP) アプリは、ARM64 システムで実行されている ARM32 アプリが使用できない OS コンポーネントに依存関係を持っていることがあります。</span><span class="sxs-lookup"><span data-stu-id="8eb70-116">Universal Windows Platform (UWP) apps that aren't properly built with Visual Studio and the UWP SDK may have dependencies on OS components that aren't available to ARM32 apps running on an ARM64 system.</span></span> <span data-ttu-id="8eb70-117">そのような依存関係の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="8eb70-117">Examples of these dependencies include:</span></span>

- <span data-ttu-id="8eb70-118">.NET Framework の一部が使用可能であることが期待される。</span><span class="sxs-lookup"><span data-stu-id="8eb70-118">Expecting parts of the .NET Framework to be available.</span></span>
- <span data-ttu-id="8eb70-119">UWP と互換性のないサード パーティの .NET コンポーネントを参照している。</span><span class="sxs-lookup"><span data-stu-id="8eb70-119">Referencing third-party .NET components that aren't compatible with UWP.</span></span>

<span data-ttu-id="8eb70-120">これらの問題を解決するには、使用できない依存関係を削除し、最新の Microsoft Visual Studio および UWP SDK バージョンを使ってアプリを再ビルドします。または、最後の手段として、Microsoft Store から ARM32 アプリを削除し、アプリの x86 バージョン (ある場合) がユーザーの PC にダウンロードされるようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="8eb70-120">These issues can be resolved by: removing the unavailable dependencies and rebuilding the app by using the latest Microsoft Visual Studio and UWP SDK versions; or as a last resort, removing the ARM32 app from the Microsoft Store, so that the x86 version of the app (if available) is downloaded to users’ PCs.</span></span> 

<span data-ttu-id="8eb70-121">UWP アプリに使用可能な .NET API について詳しくは、「[UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8eb70-121">For more info on .NET APIs available for UWP apps, see [.NET for UWP apps](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)</span></span>

### <a name="compiling-an-app-with-an-older-version-of-visual-studio-and-sdk"></a><span data-ttu-id="8eb70-122">以前のバージョンの Visual Studio と SDK を使ったアプリのコンパイル</span><span class="sxs-lookup"><span data-stu-id="8eb70-122">Compiling an app with an older version of Visual Studio and SDK</span></span>
<span data-ttu-id="8eb70-123">問題が発生した場合、最新バージョンの Microsoft Visual Studio と Windows SDK を使ってアプリをコンパイルしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="8eb70-123">If you're running into issues, be sure to use the latest versions of Microsoft Visual Studio and the Windows SDK to compile your app.</span></span> <span data-ttu-id="8eb70-124">以前のバージョンの Visual Studio と SDK でコンパイルされたアプリでは、以降のバージョンで修正された問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="8eb70-124">Apps compiled with an earlier version of Visual Studio and the SDK may have issues that have been fixed in later versions.</span></span>

## <a name="debugging"></a><span data-ttu-id="8eb70-125">デバッグ</span><span class="sxs-lookup"><span data-stu-id="8eb70-125">Debugging</span></span>
<span data-ttu-id="8eb70-126">ARM プラットフォーム用の ARM32 アプリを開発するために既存のツールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="8eb70-126">You can use existing tools for developing ARM32 apps for the ARM platform.</span></span> <span data-ttu-id="8eb70-127">便利なリソースを次に示します。</span><span class="sxs-lookup"><span data-stu-id="8eb70-127">Here are some helpful resources.</span></span>

- <span data-ttu-id="8eb70-128">Visual Studio 15.5 Preview 1 以降では、ユニバーサル認証モードを使った ARM32 アプリの実行がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="8eb70-128">Visual Studio 15.5 Preview 1 and later supports running ARM32 apps by using Universal Authentication mode.</span></span> <span data-ttu-id="8eb70-129">これにより、必要なリモート デバッグ ツールが自動的にブートストラップされます。</span><span class="sxs-lookup"><span data-stu-id="8eb70-129">This automatically bootstraps the necessary remote debugging tools.</span></span>
- <span data-ttu-id="8eb70-130">ARM でデバッグを行うためのツールと戦略について詳しくは、[ARM64 でのデバッグに関するページ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="8eb70-130">See [Debugging on ARM64](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64) to learn more about tools and strategies for debugging on ARM.</span></span>