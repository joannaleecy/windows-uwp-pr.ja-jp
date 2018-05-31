---
title: ARM32 UWP アプリのトラブルシューティング
author: msatranjr
description: ARM で実行する際の ARM32 アプリの一般的な問題とその解決方法。
ms.author: misatran
ms.date: 01/18/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10 s, 常時接続, ARM での ARM32 アプリ, ARM 版 windows 10, トラブルシューティング
ms.localizationpriority: medium
ms.openlocfilehash: 71d92ec26311514e0eebdfa4a1dab39e86ce72fc
ms.sourcegitcommit: 11edca90aaf7856c762e68903483079d30ad3877
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 02/19/2018
ms.locfileid: "1595160"
---
# <a name="troubleshooting-arm32-uwp-apps"></a><span data-ttu-id="bb3e8-104">ARM32 UWP アプリのトラブルシューティング</span><span class="sxs-lookup"><span data-stu-id="bb3e8-104">Troubleshooting ARM32 UWP apps</span></span>
<span data-ttu-id="bb3e8-105">ARM32 UWP アプリが ARM で正しく動作しない場合に役立つガイダンスを示します。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-105">If your ARM32 UWP app isn't working correctly on ARM, here's some guidance that may help.</span></span> 

## <a name="common-issues"></a><span data-ttu-id="bb3e8-106">一般的な問題</span><span class="sxs-lookup"><span data-stu-id="bb3e8-106">Common issues</span></span>
<span data-ttu-id="bb3e8-107">ARM32 アプリをトラブルシューティングするときに念頭に置く必要のある一般的な問題を次に示します。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-107">Here are some common issues to keep in mind when troubleshooting ARM32 apps.</span></span>

### <a name="using-windows-10-mobile-only-apis-on-arm-based-processors"></a><span data-ttu-id="bb3e8-108">ARM ベースのプロセッサでの Windows 10 Mobile 専用 API の使用</span><span class="sxs-lookup"><span data-stu-id="bb3e8-108">Using Windows 10 Mobile-only APIs on ARM-based processors</span></span> 
<span data-ttu-id="bb3e8-109">モバイル専用 API (**HardwareButtons** など) を使う場合、ARM32 アプリで問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-109">ARM32 apps may run into problems when using mobile-only APIs (for example, **HardwareButtons**).</span></span> <span data-ttu-id="bb3e8-110">これを軽減するには、それらの API を呼び出す前に Windows 10 Mobile でアプリが実行されているかどうかを動的に検出します。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-110">To mitigate this, you can dynamically detect whether your app is running on Windows 10 Mobile before calling these APIs.</span></span> <span data-ttu-id="bb3e8-111">[API コントラクトを使った機能の動的な検出](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/)に関するブログ投稿のガイダンスに従います。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-111">Follow the guidance in the blog post, [Dynamically detecting features with API contracts](https://blogs.windows.com/buildingapps/2015/09/15/dynamically-detecting-features-with-api-contracts-10-by-10/).</span></span>

### <a name="including-dependencies-not-supported-by-uwp-apps"></a><span data-ttu-id="bb3e8-112">UWP アプリによりサポートされていない依存関係の追加</span><span class="sxs-lookup"><span data-stu-id="bb3e8-112">Including dependencies not supported by UWP apps</span></span>
<span data-ttu-id="bb3e8-113">Visual Studio と UWP SDK を使って適切にビルドされていないユニバーサル Windows プラットフォーム (UWP) アプリは、ARM64 システムで実行されている ARM32 アプリが使用できない OS コンポーネントに依存関係を持っていることがあります。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-113">Universal Windows Platform (UWP) apps that aren't properly built with Visual Studio and the UWP SDK may have dependencies on OS components that aren't available to ARM32 apps running on an ARM64 system.</span></span> <span data-ttu-id="bb3e8-114">そのような依存関係の例は、次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-114">Examples of these dependencies include:</span></span>

- <span data-ttu-id="bb3e8-115">.NET Framework の一部が使用可能であることが期待される。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-115">Expecting parts of the .NET Framework to be available.</span></span>
- <span data-ttu-id="bb3e8-116">UWP と互換性のないサード パーティの .NET コンポーネントを参照している。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-116">Referencing third-party .NET components that aren't compatible with UWP.</span></span>

<span data-ttu-id="bb3e8-117">これらの問題を解決するには、使用できない依存関係を削除し、最新の Microsoft Visual Studio および UWP SDK バージョンを使ってアプリを再ビルドします。または、最後の手段として、Microsoft Store から ARM32 アプリを削除し、アプリの x86 バージョン (ある場合) がユーザーの PC にダウンロードされるようにすることもできます。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-117">These issues can be resolved by: removing the unavailable dependencies and rebuilding the app by using the latest Microsoft Visual Studio and UWP SDK versions; or as a last resort, removing the ARM32 app from the Microsoft Store, so that the x86 version of the app (if available) is downloaded to users’ PCs.</span></span> 

<span data-ttu-id="bb3e8-118">UWP アプリに使用可能な .NET API について詳しくは、「[UWP アプリの .NET](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)」をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-118">For more info on .NET APIs available for UWP apps, see [.NET for UWP apps](https://msdn.microsoft.com/library/windows/apps/mt185501.aspx)</span></span>

### <a name="compiling-an-app-with-an-older-version-of-visual-studio-and-sdk"></a><span data-ttu-id="bb3e8-119">以前のバージョンの Visual Studio と SDK を使ったアプリのコンパイル</span><span class="sxs-lookup"><span data-stu-id="bb3e8-119">Compiling an app with an older version of Visual Studio and SDK</span></span>
<span data-ttu-id="bb3e8-120">問題が発生した場合、最新バージョンの Microsoft Visual Studio と Windows SDK を使ってアプリをコンパイルしていることを確認します。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-120">If you're running into issues, be sure to use the latest versions of Microsoft Visual Studio and the Windows SDK to compile your app.</span></span> <span data-ttu-id="bb3e8-121">以前のバージョンの Visual Studio と SDK でコンパイルされたアプリでは、以降のバージョンで修正された問題が発生する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-121">Apps compiled with an earlier version of Visual Studio and the SDK may have issues that have been fixed in later versions.</span></span>

## <a name="debugging"></a><span data-ttu-id="bb3e8-122">デバッグ</span><span class="sxs-lookup"><span data-stu-id="bb3e8-122">Debugging</span></span>
<span data-ttu-id="bb3e8-123">ARM プラットフォーム用の ARM32 アプリを開発するために既存のツールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-123">You can use existing tools for developing ARM32 apps for the ARM platform.</span></span> <span data-ttu-id="bb3e8-124">便利なリソースを次に示します。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-124">Here are some helpful resources.</span></span>

- <span data-ttu-id="bb3e8-125">Visual Studio 15.5 Preview 1 以降では、ユニバーサル認証モードを使った ARM32 アプリの実行がサポートされます。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-125">Visual Studio 15.5 Preview 1 and later supports running ARM32 apps by using Universal Authentication mode.</span></span> <span data-ttu-id="bb3e8-126">これにより、必要なリモート デバッグ ツールが自動的にブートストラップされます。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-126">This automatically bootstraps the necessary remote debugging tools.</span></span>
- <span data-ttu-id="bb3e8-127">ARM でデバッグを行うためのツールと戦略について詳しくは、[ARM64 でのデバッグに関するページ](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="bb3e8-127">See [Debugging on ARM64](https://docs.microsoft.com/en-us/windows-hardware/drivers/debugger/debugging-arm64) to learn more about tools and strategies for debugging on ARM.</span></span>