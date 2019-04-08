---
title: サイド ローディングされた UWP アプリのための Windows ランタイム コンポーネント ブローカー
description: このホワイト ペーパーでは、Windows 10 は、キーのビジネスに不可欠な運用を担う組織の既存のコードを使用するタッチ操作に .NET アプリでサポートされている企業を対象との機能について説明します。
ms.date: 02/08/2017
ms.topic: article
keywords: windows 10, uwp
ms.assetid: 81b3930c-6af9-406d-9d1e-8ee6a13ec38a
ms.localizationpriority: medium
ms.openlocfilehash: 9ebac70d56fcdf1bf717d763daf4ac1bd9c06d4b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57640087"
---
# <a name="brokered-windows-runtime-components-for-a-side-loaded-uwp-app"></a><span data-ttu-id="5bad7-104">サイド ローディングされた UWP アプリのための Windows ランタイム コンポーネント ブローカー</span><span class="sxs-lookup"><span data-stu-id="5bad7-104">Brokered Windows Runtime Components for a side-loaded UWP app</span></span>

<span data-ttu-id="5bad7-105">この記事では、キーのビジネスに不可欠な運用を担う組織の既存のコードを使用する .NET アプリのタッチ操作には、Windows 10 でサポートされている企業を対象との機能について説明します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-105">This article discusses an enterprise-targeted feature supported by Windows 10, which allows touch-friendly .NET apps to use the existing code responsible for key business-critical operations.</span></span>

## <a name="introduction"></a><span data-ttu-id="5bad7-106">概要</span><span class="sxs-lookup"><span data-stu-id="5bad7-106">Introduction</span></span>

><span data-ttu-id="5bad7-107">**注**  のこのホワイト ペーパーに付属するサンプル コードをダウンロードすることが [Visual Studio 2015 および 2017](https://aka.ms/brokeredsample)します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-107">**Note**  The sample code that accompanies this paper may be downloaded for [Visual Studio 2015 & 2017](https://aka.ms/brokeredsample).</span></span> <span data-ttu-id="5bad7-108">Windows ランタイム コンポーネントの仲介型の構築に Microsoft Visual Studio テンプレートは、ここでダウンロードできます。[ユニバーサル Windows アプリの Windows 10 を対象とする visual Studio 2015 のテンプレート](https://visualstudiogallery.msdn.microsoft.com/10be07b3-67ef-4e02-9243-01b78cd27935)</span><span class="sxs-lookup"><span data-stu-id="5bad7-108">The Microsoft Visual Studio template to build Brokered Windows Runtime Components can be downloaded here: [Visual Studio 2015 template targeting Universal Windows Apps for Windows 10](https://visualstudiogallery.msdn.microsoft.com/10be07b3-67ef-4e02-9243-01b78cd27935)</span></span>

<span data-ttu-id="5bad7-109">Windows にはと呼ばれる新しい機能が含まれています *サイドロード アプリケーション用の Windows ランタイム コンポーネントの仲介型*します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-109">Windows includes a new feature called *Brokered Windows Runtime Components for side-loaded applications*.</span></span> <span data-ttu-id="5bad7-110">既存のデスクトップ ソフトウェア資産を 1 つのプロセス (デスクトップ コンポーネント) 内で実行しつつ、UWP アプリからこのコードとやり取りできるようにする機能は、IPC (プロセス間通信) と呼ばれます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-110">We use the term IPC (inter-process communication) to describe the ability to run existing desktop software assets in one process (desktop component) while interacting with this code in a UWP App.</span></span> <span data-ttu-id="5bad7-111">これはエンタープライズ開発者には馴染みのあるモデルです。同様のマルチプロセス アーキテクチャは、データベース アプリケーションや、Windows で NT サービスを利用するアプリケーションでも使用されているためです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-111">This is a familiar model to enterprise developers as database applications and applications utilizing NT Services in Windows share a similar multi-process architecture.</span></span>

<span data-ttu-id="5bad7-112">アプリのサイドローディングは、この機能を構成する重要な要素です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-112">Side-loading of the app is a critical component of this feature.</span></span>
<span data-ttu-id="5bad7-113">エンタープライズ独自のアプリケーションは、一般的なコンシューマー向け Microsoft Store に公開することはできません。各企業には、セキュリティ、プライバシー、配布、セットアップ、サービス提供に関して固有の要件があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-113">Enterprise-specific applications have no place in the general consumer Microsoft Store and corporations have very specific requirements around security, privacy, distribution, setup, and servicing.</span></span> <span data-ttu-id="5bad7-114">したがって、サイドローディング モデルは、この機能を使うユーザーの要件であり、重要な実装の構成要素でもあります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-114">As such, the side-loading model is both a requirement of those who would use this feature and a critical implementation detail.</span></span>

<span data-ttu-id="5bad7-115">このアプリケーション アーキテクチャが主に対象としているのが、データ中心のアプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-115">Data-centric applications are a key target for this application architecture.</span></span> <span data-ttu-id="5bad7-116">たとえば SQL Server に格納されている既存のビジネス ルールは、デスクトップ コンポーネントの共通の構成要素になります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-116">It is envisioned that existing business rules ensconced, for example, in SQL Server, will be a common part of the desktop component.</span></span> <span data-ttu-id="5bad7-117">デスクトップ コンポーネントが提供できるのは、この種類の機能だけではありません。この機能に対する要求のほとんどが既存のデータとビジネス ロジックに関連していることは確かなことです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-117">This is certainly not the only type of functionality that can be proffered by the desktop component, but a large part of the demand for this feature is related to existing data and business logic.</span></span>

<span data-ttu-id="5bad7-118">.NET ランタイムおよび C の手に負えないものの侵入を最後に、指定された\#エンタープライズ開発では、この機能の言語は、.NET を使用して、UWP アプリとデスクトップ コンポーネント側の両方に重点を置いて開発されました。</span><span class="sxs-lookup"><span data-stu-id="5bad7-118">Lastly, given the overwhelming penetration of the .NET runtime and the C\# language in enterprise development, this feature was developed with an emphasis on using .NET for both the UWP app and the desktop component sides.</span></span> <span data-ttu-id="5bad7-119">付属のサンプルは C のみを示しますが他の言語とランタイムが可能ですが、UWP アプリ用、\#、し、.NET ランタイムに排他的に限定されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-119">While there are other languages and runtimes possible for the UWP app, the accompanying sample only illustrates C\#, and is restricted to the .NET runtime exclusively.</span></span>

## <a name="application-components"></a><span data-ttu-id="5bad7-120">アプリケーション コンポーネント</span><span class="sxs-lookup"><span data-stu-id="5bad7-120">Application components</span></span>

><span data-ttu-id="5bad7-121">**注**  この機能は、.NET の使用に排他的です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-121">**Note**  This feature is exclusively for the use of .NET.</span></span> <span data-ttu-id="5bad7-122">クライアント アプリとデスクトップ コンポーネントの両方が、.NET を使って作成されている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-122">Both client app and the desktop component must be authored using .NET.</span></span>

<span data-ttu-id="5bad7-123">**アプリケーション モデル**</span><span class="sxs-lookup"><span data-stu-id="5bad7-123">**Application model**</span></span>

<span data-ttu-id="5bad7-124">この機能は、MVVM (モデル ビュー ビュー モデル) と呼ばれる一般的なアプリケーション アーキテクチャを中心に構築されています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-124">This feature is built around the general application architecture known as MVVM (Model View View-Model).</span></span> <span data-ttu-id="5bad7-125">また、"モデル" は完全にデスクトップ コンポーネントに含まれると見なされます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-125">As such, it is assumed that the "model" is housed entirely in the desktop component.</span></span> <span data-ttu-id="5bad7-126">したがって、デスクトップ コンポーネントが "ヘッドレス" になる (UI が含まれない) ことは明らかです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-126">Therefore, it should be immediately obvious that the desktop component will be "headless" (i.e. contains no UI).</span></span> <span data-ttu-id="5bad7-127">ビューは、サイドロードされたエンタープライズ アプリケーションに完全に含まれます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-127">The view will be entirely contained in the side-loaded enterprise application.</span></span> <span data-ttu-id="5bad7-128">このアプリケーションを "ビュー モデル" 構造で構築しなければならないという要件はありませんが、このパターンを使うのが一般的とされます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-128">While there is no requirement that this application be built with the "view-model" construct, we anticipate that usage of this pattern will be common.</span></span>

<span data-ttu-id="5bad7-129">**デスクトップ コンポーネント**</span><span class="sxs-lookup"><span data-stu-id="5bad7-129">**Desktop component**</span></span>

<span data-ttu-id="5bad7-130">この機能のデスクトップ コンポーネントは、この機能の一部として導入された新しい種類のアプリケーションです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-130">The desktop component in this feature is a new application type being introduced as part of this feature.</span></span> <span data-ttu-id="5bad7-131">このデスクトップ コンポーネントは、C でのみ記述できます\#と Windows 10 用 .NET 4.6 以降をターゲットする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-131">This desktop component can only be written in C\# and must target .NET 4.6 or greater for Windows 10.</span></span> <span data-ttu-id="5bad7-132">プロジェクトの種類は、UWP をターゲットとする CLR のハイブリッドで、プロセス間通信の形式は UWP の型とクラスで構成されます。一方、デスクトップ コンポーネントは、.NET ランタイム クラス ライブラリのすべてを呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-132">The project type is a hybrid between the CLR targeting UWP as the inter-process communication format comprises UWP types and classes, while the desktop component is allowed to call all parts of the .NET runtime class library.</span></span> <span data-ttu-id="5bad7-133">Visual Studio プロジェクトに対する影響については、後で詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-133">The impact on the Visual Studio project will be described in detail later.</span></span> <span data-ttu-id="5bad7-134">このハイブリッド構成により、デスクトップ コンポーネントに構築されたアプリケーションとの間で UWP の型をマーシャリングしながら、デスクトップ CLR コードをデスクトップ コンポーネントの実装内で呼び出すことができます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-134">This hybrid configuration allows marshaling UWP types between the application built on the desktop components while allowing desktop CLR code to be called inside the desktop component implementation.</span></span>

<span data-ttu-id="5bad7-135">**コントラクト**</span><span class="sxs-lookup"><span data-stu-id="5bad7-135">**Contract**</span></span>

<span data-ttu-id="5bad7-136">サイドロード アプリケーションとデスクトップ コンポーネントの間のコントラクトは、UWP 型システムの観点から記述されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-136">The contract between the side-loaded application and the desktop component is described in terms of the UWP type system.</span></span> <span data-ttu-id="5bad7-137">1 つ以上の C を宣言する必要があります\#UWP を表すことのできるクラス。</span><span class="sxs-lookup"><span data-stu-id="5bad7-137">This involves declaring one or more C\# classes that can represent a UWP.</span></span> <span data-ttu-id="5bad7-138">MSDN のトピックを参照してください。 [C での Windows ランタイム コンポーネントの作成\#および Visual Basic](https://msdn.microsoft.com/library/br230301.aspx) C を使用して Windows ランタイム クラスの作成の特定の要件を\#します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-138">See MSDN topic [Creating Windows Runtime Components in C\# and Visual Basic](https://msdn.microsoft.com/library/br230301.aspx) for specific requirement of creating Windows Runtime Class using C\#.</span></span>

><span data-ttu-id="5bad7-139">**注**  デスクトップ コンポーネントとサイド ロードはアプリケーション間での Windows ランタイム コンポーネントのコントラクトでは、列挙型はサポートされていません。</span><span class="sxs-lookup"><span data-stu-id="5bad7-139">**Note**  Enums are not supported in the Windows Runtime Components Contract between desktop component and side-loaded application at this time.</span></span>

<span data-ttu-id="5bad7-140">**アプリケーションのサイドロード**</span><span class="sxs-lookup"><span data-stu-id="5bad7-140">**Side-loaded application**</span></span>

<span data-ttu-id="5bad7-141">サイドロード アプリケーションは、Microsoft Store 経由でインストールされるのではなくサイドロードされるという 1 点を除けば、あらゆる点で通常の UWP アプリと変わりません。</span><span class="sxs-lookup"><span data-stu-id="5bad7-141">The side-loaded application is a normal UWP app in every respect except one: it is side-loaded instead of installed via the Microsoft Store.</span></span> <span data-ttu-id="5bad7-142">インストール メカニズムのほとんどは同じであり、マニフェストとアプリケーションのパッケージも似ています (マニフェストには追加点が 1 つありますが、これについては後で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-142">Most of the installation mechanisms are identical: the manifest and application packaging are similar (one addition to the manifest is described in detail later).</span></span> <span data-ttu-id="5bad7-143">いったんサイドローディングを有効にしたら、簡単な PowerShell スクリプトで、必要な証明書とアプリケーション自体をインストールできます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-143">Once side-loading is enabled, a simple PowerShell script can install the necessary certificates and the application itself.</span></span> <span data-ttu-id="5bad7-144">一般的なベスト プラクティスとして、サイドロード アプリケーションでは、Visual Studio の [プロジェクト] メニューの [ストア] に含まれる WACK 認定テストを実行することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-144">It is the normal best practice that the side-loaded application passes the WACK certification test that is included in the Project / Store menu in Visual Studio</span></span>

><span data-ttu-id="5bad7-145">**注** サイドローディングできますで有効にする設定には、&gt;更新とセキュリティ -&gt;開発者向け。</span><span class="sxs-lookup"><span data-stu-id="5bad7-145">**Note** Side-loading can be turned on in Settings-&gt; Update & security -&gt; For developers.</span></span>

<span data-ttu-id="5bad7-146">重要な点として、Windows 10 に搭載されているアプリ ブローカー メカニズムは 32 ビット専用であることに注意が必要です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-146">One important point to note is that the App Broker mechanism shipped as part of Windows 10 is 32-bit only.</span></span> <span data-ttu-id="5bad7-147">デスクトップ コンポーネントは 32 ビットである必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-147">The desktop component must be 32-bit.</span></span>
<span data-ttu-id="5bad7-148">サイドロード アプリケーションは 64 ビットにできますが (64 ビットと 32 ビットの両方のプロキシが登録されている場合)、これは特殊なアプリケーションになります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-148">Side-loaded applications can be 64-bit (provided there is both a 64-bit and 32-bit proxies registered), but this will be atypical.</span></span> <span data-ttu-id="5bad7-149">C でのサイド ロード アプリケーションを構築\#自然"neutral"標準的な構成と、「32 ビットを優先」の既定を使用して、32 ビットのサイド ロード アプリケーションを作成します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-149">Building the side-loaded application in C\# using the normal "neutral" configuration and the "prefer 32-bit" default naturally creates 32-bit side-loaded applications.</span></span>

<span data-ttu-id="5bad7-150">**サーバーのインスタンス化および Appdomain**</span><span class="sxs-lookup"><span data-stu-id="5bad7-150">**Server instancing and AppDomains**</span></span>

<span data-ttu-id="5bad7-151">サイドロードされたアプリケーションはそれぞれ、アプリ ブローカー サーバーの独自のインスタンスを受け取ります (いわゆる "マルチインスタンス化" が行われます)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-151">Each sided-loaded application receives its own instance of an App Broker server (so-called "multi-instancing").</span></span> <span data-ttu-id="5bad7-152">サーバー コードは、1 つの AppDomain 内で実行されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-152">The server code runs inside of a single AppDomain.</span></span> <span data-ttu-id="5bad7-153">これにより、複数のバージョンのライブラリを個別のインスタンスで実行できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-153">This allows for having multiple version of libraries run in separate instances.</span></span> <span data-ttu-id="5bad7-154">たとえば、アプリケーション A には V1.1 のコンポーネントが必要で、アプリケーション B には V2 が必要であるとします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-154">For example, application A needs V1.1 of a component and application B needs V2.</span></span> <span data-ttu-id="5bad7-155">これを明確に区別するには、V1.1 コンポーネントと V2 コンポーネントをそれぞれ別のサーバー ディレクトリに分けて、各アプリケーションが、必要なバージョンをサポートするサーバーに接続するように指定します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-155">These are cleanly separated by having V1.1 and V2 components in separate server directories and pointing the application to whichever server supports the correct version desired.</span></span>

<span data-ttu-id="5bad7-156">サーバー コードの実装を複数のアプリ ブローカー サーバー インスタンスで共有するには、複数のアプリケーションが同じサーバー ディレクトリに接続するように指定します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-156">Server code implementation can be shared amongst multiple App Broker server instance by pointing multiple applications to the same server directory.</span></span> <span data-ttu-id="5bad7-157">それでもアプリ ブローカー サーバーのインスタンスは複数存在することになりますが、各インスタンスでは同じコードが実行されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-157">There will still be multiple instances of the App Broker server but they will be running identical code.</span></span> <span data-ttu-id="5bad7-158">1 つのアプリケーションで使われる実装コンポーネントはすべて、同じパスに存在する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-158">All implementation components used in a single application should be present in the same path.</span></span>

## <a name="defining-the-contract"></a><span data-ttu-id="5bad7-159">コントラクトの定義</span><span class="sxs-lookup"><span data-stu-id="5bad7-159">Defining the contract</span></span>

<span data-ttu-id="5bad7-160">この機能を使ってアプリケーションを作成するには、まず、サイドロード アプリケーションとデスクトップ コンポーネントの間のコントラクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-160">The first step in creating an application using this feature is to create the contract between the side-loaded application and the desktop component.</span></span> <span data-ttu-id="5bad7-161">これは、Windows ランタイム型だけを使用して行う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-161">This must be done exclusively using Windows Runtime types.</span></span>
<span data-ttu-id="5bad7-162">さいわい、これらは C を使用して宣言する簡単な\#クラス。</span><span class="sxs-lookup"><span data-stu-id="5bad7-162">Fortunately, these are easy to declare using C\# classes.</span></span> <span data-ttu-id="5bad7-163">ただし、このような通信を定義するときは、パフォーマンスについて考慮することが重要です。これについては後で説明します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-163">There are important performance considerations, however, when defining these conversations, which is covered in a later section.</span></span>

<span data-ttu-id="5bad7-164">コントラクトを定義する流れは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-164">The sequence to define the contract is introduced as following:</span></span>

<span data-ttu-id="5bad7-165">**手順 1:** Visual Studio で新しいクラス ライブラリを作成します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-165">**Step 1:** Create a new class library in Visual Studio.</span></span> <span data-ttu-id="5bad7-166">プロジェクトの作成時には、Windows ランタイム コンポーネント テンプレートではなく、クラス ライブラリ テンプレートを使います。</span><span class="sxs-lookup"><span data-stu-id="5bad7-166">Make sure to create the project using Class Library template not Windows Runtime Component template</span></span>

<span data-ttu-id="5bad7-167">この後には実装が続きますが、このセクションでは、プロセス間のコントラクトの定義についてのみ説明します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-167">An implementation obviously follows, but this section is only covering the definition of the inter-process contract.</span></span> <span data-ttu-id="5bad7-168">関連するサンプルには次のクラス (EnterpriseServer.cs) が含まれ、先頭部分は次のようになっています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-168">The accompanying sample includes the following class (EnterpriseServer.cs), the beginning shape of which looks like:</span></span>

```csharp
namespace Fabrikam
{
    public sealed class EnterpriseServer
    {

        public ILis<String> TestMethod(String input)
        {
            throw new NotImplementedException();
        }
        
        public IAsyncOperation<int> FindElementAsync(int input)
        {
            throw new NotImplementedException();
        }
        
        public string[] RetrieveData()
        {
            throw new NotImplementedException();
        }
        
        public event EventHandler<string> PeriodicEvent;
    }
}
```

<span data-ttu-id="5bad7-169">これにより、サイドロード アプリケーションからインスタンス化できる "EnterpriseServer" クラスが定義されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-169">This defines a class "EnterpriseServer" that can be instantiated from the side-loaded application.</span></span> <span data-ttu-id="5bad7-170">このクラスは、RuntimeClass で保障された機能を提供します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-170">This class provides the functionality promised in the RuntimeClass.</span></span> <span data-ttu-id="5bad7-171">RuntimeClass は、サイドロード アプリケーションに含める参照用の winmd を生成するために使用できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-171">The RuntimeClass can be used to generate the reference winmd that will be included in the side-loaded application.</span></span>

<span data-ttu-id="5bad7-172">**手順 2:** Windows ランタイム コンポーネントにプロジェクトの出力の種類を変更するには、手動でプロジェクト ファイルを編集します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-172">**Step 2:** Edit the project file manually to change the output type of project to Windows Runtime Component</span></span>

<span data-ttu-id="5bad7-173">これを Visual Studio で実行するには、新しく作成されたプロジェクトを右クリックし、[プロジェクトのアンロード] を選択します。もう一度右クリックし、[Edit EnterpriseServer.csproj の編集] を選択して、プロジェクト ファイル (XML ファイル) を編集用に開きます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-173">To do this in Visual Studio, right click on the newly created project and select “Unload Project”, then right click again and select “Edit EnterpriseServer.csproj” to open the project file, an XML file, for editing.</span></span>

<span data-ttu-id="5bad7-174">ファイルを開いたときに検索、 \<OutputType\>タグし、その値を"winmdobj"に変更します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-174">In the opened file, search for the \<OutputType\> tag and change its value to “winmdobj”.</span></span>

<span data-ttu-id="5bad7-175">**手順 3:** Windows「参照」を作成するビルド規則を作成するメタデータ ファイル (.winmd ファイル)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-175">**Step 3:** Create a build rule that creates a "reference" Windows metadata file (.winmd file).</span></span> <span data-ttu-id="5bad7-176">つまり、実装は含まれません。</span><span class="sxs-lookup"><span data-stu-id="5bad7-176">i.e. has no implementation.</span></span>

<span data-ttu-id="5bad7-177">**手順 4:**「実装」Windows メタデータ ファイルを作成、つまり、同じメタデータ情報も実装が含まれますビルド規則を作成します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-177">**Step 4:** Create a build rule that creates an "implementation" Windows metadata file, i.e. has the same metadata information, but also includes the implementation.</span></span>

<span data-ttu-id="5bad7-178">これは次のスクリプトによって実行されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-178">This will is done by the following scripts.</span></span> <span data-ttu-id="5bad7-179">プロジェクトの **[プロパティ]** > **[ビルド イベント]** で、ビルド後のイベントのコマンド ラインにこれらのスクリプトを追加します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-179">Add the scripts to the Post-build event command line, in project **Properties** > **Build Events**.</span></span>

> <span data-ttu-id="5bad7-180">**注** このスクリプトは、ターゲットとする Windows のバージョン (Windows 10) と、使用中の Visual Studio のバージョンによって異なります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-180">**Note** the script is different based on the version of Windows you are targeting (Windows 10) and the version of Visual Studio in use.</span></span>

<span data-ttu-id="5bad7-181">**Visual Studio 2015**</span><span class="sxs-lookup"><span data-stu-id="5bad7-181">**Visual Studio 2015**</span></span>
```cmd
    call "$(DevEnvDir)..\..\vc\vcvarsall.bat" x86 10.0.14393.0

    md "$(TargetDir)"\impl    md "$(TargetDir)"\reference

    erase "$(TargetDir)\impl\*.winmd"
    erase "$(TargetDir)\impl\*.pdb"
    rem erase "$(TargetDir)\reference\*.winmd"

    xcopy /y "$(TargetPath)" "$(TargetDir)impl"
    xcopy /y "$(TargetDir)*.pdb" "$(TargetDir)impl"

    winmdidl /nosystemdeclares /metadata_dir:C:\Windows\System32\Winmetadata "$(TargetPath)"

    midl /metadata_dir "%WindowsSdkDir%UnionMetadata" /iid "$(SolutionDir)BrokeredProxyStub\$(TargetName)_i.c" /env win32 /x86 /h   "$(SolutionDir)BrokeredProxyStub\$(TargetName).h" /winmd "$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(SolutionDir)BrokeredProxyStub\dlldata.c" /proxy "$(SolutionDir)BrokeredProxyStub\$(TargetName)_p.c"  "$(TargetName).idl"
    mdmerge -n 1 -i "$(ProjectDir)bin\$(ConfigurationName)" -o "$(TargetDir)reference" -metadata_dir "%WindowsSdkDir%UnionMetadata" -partial

    rem erase "$(TargetPath)"

```


<span data-ttu-id="5bad7-182">**Visual Studio 2017**</span><span class="sxs-lookup"><span data-stu-id="5bad7-182">**Visual Studio 2017**</span></span>
```cmd
    call "$(DevEnvDir)..\..\vc\auxiliary\build\vcvarsall.bat" x86 10.0.16299.0

    md "$(TargetDir)"\impl
    md "$(TargetDir)"\reference

    erase "$(TargetDir)\impl\*.winmd"
    erase "$(TargetDir)\impl\*.pdb"
    rem erase "$(TargetDir)\reference\*.winmd"

    xcopy /y "$(TargetPath)" "$(TargetDir)impl"
    xcopy /y "$(TargetDir)*.pdb" "$(TargetDir)impl"

    winmdidl /nosystemdeclares /metadata_dir:C:\Windows\System32\Winmetadata "$(TargetPath)"

    midl /metadata_dir "%WindowsSdkDir%UnionMetadata" /iid "$(SolutionDir)BrokeredProxyStub\$(TargetName)_i.c" /env win32 /x86 /h "$(SolutionDir)BrokeredProxyStub\$(TargetName).h" /winmd "$(TargetName).winmd" /W1 /char signed /nologo /winrt /dlldata "$(SolutionDir)BrokeredProxyStub\dlldata.c" /proxy "$(SolutionDir)BrokeredProxyStub\$(TargetName)_p.c"  "$(TargetName).idl"
    mdmerge -n 1 -i "$(ProjectDir)bin\$(ConfigurationName)" -o "$(TargetDir)reference" -metadata_dir "%WindowsSdkDir%UnionMetadata" -partial

    rem erase "$(TargetPath)"
```

<span data-ttu-id="5bad7-183">1 回の参照を **winmd** が作成されます (フォルダー、プロジェクトのターゲット フォルダーの下には、「参照」) では手の各サイド ロード アプリケーション プロジェクトが使用する (コピー) を実行し、参照されています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-183">Once the reference **winmd** is created (in folder “reference” under the project’s Target folder), it is hand carried (copied) to each consuming side-loaded application project and referenced.</span></span> <span data-ttu-id="5bad7-184">これについては、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-184">This will be described further in the next section.</span></span> <span data-ttu-id="5bad7-185">プロジェクトの構造上のビルド規則に組み込まれていることを確認します、実装および参照 **winmd** は混乱を避けるため、ビルドの階層でディレクトリに明確に分離します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-185">The project structure embodied in the build rules above ensure that the implementation and the reference **winmd** are in clearly segregated directories in the build hierarchy to avoid confusion.</span></span>

## <a name="side-loaded-applications-in-detail"></a><span data-ttu-id="5bad7-186">サイドロード アプリケーションの詳細</span><span class="sxs-lookup"><span data-stu-id="5bad7-186">Side-loaded applications in detail</span></span>
<span data-ttu-id="5bad7-187">既に説明したとおり、サイドロード アプリケーションは他の UWP アプリと同じようにビルドされますが、追加の作業が 1 つあります。つまり、サイドロード アプリケーションのマニフェストで、RuntimeClass の利用を宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-187">As stated previously, the side-loaded application is built like any other UWP app, but there is one additional detail: declaring the availability of the RuntimeClass (es) in the side-loaded application's manifest.</span></span> <span data-ttu-id="5bad7-188">これにより、アプリケーションでは、new 演算子を記述するだけでデスクトップ コンポーネントの機能にアクセスできるようになります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-188">This allows the application to simply write new to access the functionality in the desktop component.</span></span> <span data-ttu-id="5bad7-189"><Extension> セクション内の新しいマニフェスト エントリに、デスクトップ コンポーネントで実装される RuntimeClass とその場所に関する情報を記述します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-189">A new manifest entry in the <Extension> section describes the RuntimeClass implemented in the desktop component and information on where it is located.</span></span> <span data-ttu-id="5bad7-190">これらを宣言するアプリケーション マニフェスト内のコンテンツは、Windows 10 をターゲットとするアプリと同じです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-190">These declaration content in application’s manifest is the same for apps targeting Windows 10.</span></span> <span data-ttu-id="5bad7-191">次に、例を示します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-191">For example:</span></span>

```XML
<Extension Category="windows.activatableClass.inProcessServer">
    <InProcessServer>
        <Path>clrhost.dll</Path>
        <ActivatableClass ActivatableClassId="Fabrikam.EnterpriseServer" ThreadingModel="both">
            <ActivatableClassAttribute Name="DesktopApplicationPath" Type="string" Value="c:\test" />
        </ActivatableClass>
    </InProcessServer>
</Extension>
```

<span data-ttu-id="5bad7-192">カテゴリは inProcessServer です。outOfProcessServer カテゴリには、このアプリケーション構成に適用できないエントリが複数あるためです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-192">The category is inProcessServer because there are several entries in the outOfProcessServer category that are not applicable to this application configuration.</span></span> <span data-ttu-id="5bad7-193">なお、<Path>コンポーネントは clrhost.dll 常を含める必要が (ただしこれは **いない** 適用され、別の値を指定することは、未定義の方法では失敗)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-193">Note that the <Path> component must always contain clrhost.dll (however this is **not** enforced and specifying a different value will fail in undefined ways).</span></span>

<span data-ttu-id="5bad7-194"><ActivatableClass> セクションは、アプリ パッケージ内の Windows ランタイム コンポーネントによって優先される実際のインプロセス RuntimeClass と同じです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-194">The <ActivatableClass> section is the same as a true in-process RuntimeClass preferred by a Windows Runtime component in the app's package.</span></span> <span data-ttu-id="5bad7-195"><ActivatableClassAttribute> 新しい要素と属性名 ="DesktopApplicationPath"、種類 ="string"は必須およびインバリアントします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-195"><ActivatableClassAttribute> is a new element, and the attributes Name="DesktopApplicationPath" and Type="string" are mandatory and invariant.</span></span> <span data-ttu-id="5bad7-196">Value 属性では、デスクトップ コンポーネントの実装用の winmd の場所を指定します (詳しくは、次のセクションを参照)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-196">The Value attribute points to the location where the desktop component's implementation winmd resides (more detail on this in the next section).</span></span> <span data-ttu-id="5bad7-197">デスクトップ コンポーネントによって優先される各 RuntimeClass には、独自の <ActivatableClass> 要素ツリーが必要です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-197">Each RuntimeClass preferred by the desktop component should have its own <ActivatableClass> element tree.</span></span> <span data-ttu-id="5bad7-198">ActivatableClassId は、RuntimeClass の完全な名前空間修飾名と一致する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-198">The ActivatableClassId must match the fully namespace-qualified name of the RuntimeClass.</span></span>

<span data-ttu-id="5bad7-199">「コントラクトの定義」で説明したように、プロジェクトの参照先は、デスクトップ コンポーネントの参照用の winmd にする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-199">As mentioned in the section "Defining the contract", a project reference must be made to the desktop component's reference winmd.</span></span> <span data-ttu-id="5bad7-200">Visual Studio のプロジェクト システムでは、通常、同じ名前で 2 レベルのディレクトリ構造が作成されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-200">The Visual Studio project system normally creates a two level directory structure with the same name.</span></span> <span data-ttu-id="5bad7-201">サンプルでは EnterpriseIPCApplication\\EnterpriseIPCApplication します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-201">In the sample it is EnterpriseIPCApplication\\EnterpriseIPCApplication.</span></span> <span data-ttu-id="5bad7-202">参照**winmd** この 2 番目のレベルのディレクトリとし、ダイアログ ボックスを使用するプロジェクト参照を手動でコピーされます (をクリックして、 **参照..** ボタン) を見つけて、この参照**winmd**します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-202">The reference **winmd** is manually copied to this second level directory and then the Project References dialog is used (click the **Browse..** button) to locate and reference this **winmd**.</span></span> <span data-ttu-id="5bad7-203">完了すると、デスクトップ コンポーネントの最上位の名前空間 (たとえば Fabrikam) が、プロジェクトの [参照] 部分の最上位ノードとして表示されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-203">After this, the top level namespace of the desktop component (e.g. Fabrikam) should appear as a top level node in the References part of the project.</span></span>

><span data-ttu-id="5bad7-204">**注**を使用する非常に重要ですが、 **winmd を参照** サイドロード アプリケーションで。</span><span class="sxs-lookup"><span data-stu-id="5bad7-204">**Note** It is very important to use the **reference winmd** in the side-loaded application.</span></span> <span data-ttu-id="5bad7-205">誤って経由で実行する場合、 **実装 winmd** サイド ロード アプリのディレクトリとリファレンスを受け取ることになります「IStringable を見つけることができません」に関連したエラー。</span><span class="sxs-lookup"><span data-stu-id="5bad7-205">If you accidentally carry over the **implementation winmd** to the side-loaded app directory and reference it, you will likely receive an error related to "cannot find IStringable".</span></span> <span data-ttu-id="5bad7-206">これは、いずれかを確認する署名間違った **winmd** が参照されています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-206">This is one sure sign that the wrong **winmd** has been referenced.</span></span> <span data-ttu-id="5bad7-207">ビルド後ルールは、IPC サーバー アプリケーション (次のセクションで詳しく説明) 慎重に分離これら 2 つ **winmd** 別々 のディレクトリにします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-207">The post-build rules in the IPC server app (detailed in the next section) carefully segregate these two **winmd** into separate directories.</span></span>

<span data-ttu-id="5bad7-208">環境変数 (特に %programfiles%)使用できる<ActivatableClassAttribute Value="path">します。前述のように、ブローカー アプリのみをサポート 32 ビット %programfiles% は c: を解決するため\\Program Files (x86) 場合は、アプリケーションは 64 ビット OS で実行します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-208">Environment variables (especially %ProgramFiles%) can be used in <ActivatableClassAttribute Value="path"> .As noted earlier, the App Broker only supports 32-bit so %ProgramFiles% will resolve to C:\\Program Files (x86) if the application is run on a 64-bit OS.</span></span>

## <a name="desktop-ipc-server-detail"></a><span data-ttu-id="5bad7-209">デスクトップ IPC サーバーの詳細</span><span class="sxs-lookup"><span data-stu-id="5bad7-209">Desktop IPC server detail</span></span>

<span data-ttu-id="5bad7-210">前の 2 つのセクションは、クラスの宣言と参照を輸送するためのメカニズムについて説明します。 **winmd** サイドロード アプリケーション プロジェクトへです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-210">The previous two sections describe declaration of the class and the mechanics of transporting the reference **winmd** to the side-loaded application project.</span></span> <span data-ttu-id="5bad7-211">デスクトップ コンポーネント側の残りの作業は、ほとんどが実装にかかわるものです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-211">The bulk of the remaining work in the desktop component involves implementation.</span></span> <span data-ttu-id="5bad7-212">デスクトップ コンポーネントで肝心なのは、デスクトップ コードを呼び出せるようにするという点です (通常は、既にあるコード資産を再利用するのが目的)。このため、プロジェクトは、特別な方法で構成する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-212">Since the whole point of the desktop component is to be able to call desktop code (usually to re-utilize existing code assets), the project must be configured in a special way.</span></span>
<span data-ttu-id="5bad7-213">通常、.NET を使う Visual Studio プロジェクトでは、2 つの "プロファイル" のいずれかが使われます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-213">Normally, a Visual Studio project using .NET uses one of two "profiles".</span></span>
<span data-ttu-id="5bad7-214">1 つはデスクトップ用プロファイル (".NetFramework")、もう 1 つは CLR の UWP アプリ部分をターゲットとするプロファイル (".NetCore") です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-214">One is for desktop (".NetFramework") and one is targeting the UWP app portion of the CLR (".NetCore").</span></span> <span data-ttu-id="5bad7-215">この機能のデスクトップ コンポーネントは、この 2 つのハイブリッドです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-215">A desktop component in this feature is a hybrid between these two.</span></span> <span data-ttu-id="5bad7-216">その結果、参照セクションは、これら 2 つのプロファイルがうまく調和するように注意深く構成されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-216">As a result, the references section is very carefully constructed to blend these two profiles.</span></span>

<span data-ttu-id="5bad7-217">通常の UWP アプリ プロジェクトでは、Windows ランタイム API サーフェス全体が暗黙的に含まれるため、明示的なプロジェクト参照は含まれません。</span><span class="sxs-lookup"><span data-stu-id="5bad7-217">A normal UWP app project contains no explicit project references because the entirety of the Windows Runtime API surface is implicitly included.</span></span>
<span data-ttu-id="5bad7-218">通常は、他のプロジェクト間でのみ参照が行われます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-218">Normally only other inter-project references are made.</span></span> <span data-ttu-id="5bad7-219">これに対してデスクトップ コンポーネント プロジェクトには、きわめて特殊な一連の参照が含まれます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-219">However, a desktop component project has a very special set of references.</span></span> <span data-ttu-id="5bad7-220">開始として、"クラシック デスクトップ\\クラス ライブラリ"プロジェクトであるため、デスクトップ プロジェクトをします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-220">It starts life as a "Classic Desktop\\Class Library" project and therefore is a desktop project.</span></span> <span data-ttu-id="5bad7-221">Windows ランタイム API を明示的に参照 (への参照を使用して **winmd** ファイル) できるようにする必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-221">So explicit references to the Windows Runtime API (via references to **winmd** files) must be made.</span></span> <span data-ttu-id="5bad7-222">次に示すように、適切な参照を追加します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-222">Add proper references as shown below.</span></span>

```XML
<ItemGroup>
    <!-- These reference are added by VS automatically when you create a Class Library project-->
    <Reference Include="System" />
    <Reference Include="System.Core" />
    <Reference Include="System.Xml.Linq" />
    <Reference Include="System.Data.DataSetExtensions" />
    <Reference Include="Microsoft.CSharp" />
    <Reference Include="System.Data" />
    <Reference Include="System.Net.Http" />
<Reference Include="System.Xml" />
    <!-- These reference should be added manually by editing .csproj file-->

    <Reference Include="System.Runtime.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089, processorArchitecture=MSIL">
      <HintPath>$(MSBuildProgramFiles32)\Microsoft SDKs\NETCoreSDK\System.Runtime.WindowsRuntime\4.0.10\lib\netcore50\System.Runtime.WindowsRuntime.dll</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\UnionMetadata\Facade\Windows.WinMD</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Foundation.FoundationContract">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\References\Windows.Foundation.FoundationContract\1.0.0.0\Windows.Foundation.FoundationContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Foundation.UniversalApiContract">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\References\Windows.Foundation.UniversalApiContract\1.0.0.0\Windows.Foundation.UniversalApiContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Networking.Connectivity.WwanContract">
      <HintPath>$(MSBuildProgramFiles32)\Windows Kits\10\References\Windows.Networking.Connectivity.WwanContract\1.0.0.0\Windows.Networking.Connectivity.WwanContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.ActivatedEventsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.ActivatedEventsContract\1.0.0.0\Windows.ApplicationModel.Activation.ActivatedEventsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.ActivationCameraSettingsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.ActivationCameraSettingsContract\1.0.0.0\Windows.ApplicationModel.Activation.ActivationCameraSettingsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.ContactActivatedEventsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.ContactActivatedEventsContract\1.0.0.0\Windows.ApplicationModel.Activation.ContactActivatedEventsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Activation.WebUISearchActivatedEventsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Activation.WebUISearchActivatedEventsContract\1.0.0.0\Windows.ApplicationModel.Activation.WebUISearchActivatedEventsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Background.BackgroundAlarmApplicationContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Background.BackgroundAlarmApplicationContract\1.0.0.0\Windows.ApplicationModel.Background.BackgroundAlarmApplicationContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Calls.LockScreenCallContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Calls.LockScreenCallContract\1.0.0.0\Windows.ApplicationModel.Calls.LockScreenCallContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Resources.Management.ResourceIndexerContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Resources.Management.ResourceIndexerContract\1.0.0.0\Windows.ApplicationModel.Resources.Management.ResourceIndexerContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Search.Core.SearchCoreContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Search.Core.SearchCoreContract\1.0.0.0\Windows.ApplicationModel.Search.Core.SearchCoreContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Search.SearchContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Search.SearchContract\1.0.0.0\Windows.ApplicationModel.Search.SearchContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.ApplicationModel.Wallet.WalletContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.ApplicationModel.Wallet.WalletContract\1.0.0.0\Windows.ApplicationModel.Wallet.WalletContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Custom.CustomDeviceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Custom.CustomDeviceContract\1.0.0.0\Windows.Devices.Custom.CustomDeviceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Portable.PortableDeviceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Portable.PortableDeviceContract\1.0.0.0\Windows.Devices.Portable.PortableDeviceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Printers.Extensions.ExtensionsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Printers.Extensions.ExtensionsContract\1.0.0.0\Windows.Devices.Printers.Extensions.ExtensionsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Printers.PrintersContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Printers.PrintersContract\1.0.0.0\Windows.Devices.Printers.PrintersContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Scanners.ScannerDeviceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Scanners.ScannerDeviceContract\1.0.0.0\Windows.Devices.Scanners.ScannerDeviceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Devices.Sms.LegacySmsApiContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Devices.Sms.LegacySmsApiContract\1.0.0.0\Windows.Devices.Sms.LegacySmsApiContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Gaming.Preview.GamesEnumerationContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Gaming.Preview.GamesEnumerationContract\1.0.0.0\Windows.Gaming.Preview.GamesEnumerationContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Globalization.GlobalizationJapanesePhoneticAnalyzerContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Globalization.GlobalizationJapanesePhoneticAnalyzerContract\1.0.0.0\Windows.Globalization.GlobalizationJapanesePhoneticAnalyzerContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Graphics.Printing3D.Printing3DContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Graphics.Printing3D.Printing3DContract\1.0.0.0\Windows.Graphics.Printing3D.Printing3DContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Management.Deployment.Preview.DeploymentPreviewContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Management.Deployment.Preview.DeploymentPreviewContract\1.0.0.0\Windows.Management.Deployment.Preview.DeploymentPreviewContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Management.Workplace.WorkplaceSettingsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Management.Workplace.WorkplaceSettingsContract\1.0.0.0\Windows.Management.Workplace.WorkplaceSettingsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Capture.AppCaptureContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Capture.AppCaptureContract\1.0.0.0\Windows.Media.Capture.AppCaptureContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Capture.CameraCaptureUIContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Capture.CameraCaptureUIContract\1.0.0.0\Windows.Media.Capture.CameraCaptureUIContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Devices.CallControlContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Devices.CallControlContract\1.0.0.0\Windows.Media.Devices.CallControlContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.MediaControlContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.MediaControlContract\1.0.0.0\Windows.Media.MediaControlContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Playlists.PlaylistsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Playlists.PlaylistsContract\1.0.0.0\Windows.Media.Playlists.PlaylistsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Media.Protection.ProtectionRenewalContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Media.Protection.ProtectionRenewalContract\1.0.0.0\Windows.Media.Protection.ProtectionRenewalContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Networking.NetworkOperators.LegacyNetworkOperatorsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Networking.NetworkOperators.LegacyNetworkOperatorsContract\1.0.0.0\Windows.Networking.NetworkOperators.LegacyNetworkOperatorsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Networking.Sockets.ControlChannelTriggerContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Networking.Sockets.ControlChannelTriggerContract\1.0.0.0\Windows.Networking.Sockets.ControlChannelTriggerContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Security.EnterpriseData.EnterpriseDataContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Security.EnterpriseData.EnterpriseDataContract\1.0.0.0\Windows.Security.EnterpriseData.EnterpriseDataContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Security.ExchangeActiveSyncProvisioning.EasContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Security.ExchangeActiveSyncProvisioning.EasContract\1.0.0.0\Windows.Security.ExchangeActiveSyncProvisioning.EasContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Services.Maps.GuidanceContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Services.Maps.GuidanceContract\1.0.0.0\Windows.Services.Maps.GuidanceContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Services.Maps.LocalSearchContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Services.Maps.LocalSearchContract\1.0.0.0\Windows.Services.Maps.LocalSearchContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.Profile.SystemManufacturers.SystemManufacturersContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.Profile.SystemManufacturers.SystemManufacturersContract\1.0.0.0\Windows.System.Profile.SystemManufacturers.SystemManufacturersContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.Profile.ProfileHardwareTokenContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.Profile.ProfileHardwareTokenContract\1.0.0.0\Windows.System.Profile.ProfileHardwareTokenContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.Profile.ProfileRetailInfoContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.Profile.ProfileRetailInfoContract\1.0.0.0\Windows.System.Profile.ProfileRetailInfoContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.UserProfile.UserProfileContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.UserProfile.UserProfileContract\1.0.0.0\Windows.System.UserProfile.UserProfileContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.System.UserProfile.UserProfileLockScreenContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.System.UserProfile.UserProfileLockScreenContract\1.0.0.0\Windows.System.UserProfile.UserProfileLockScreenContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.ApplicationSettings.ApplicationsSettingsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.ApplicationSettings.ApplicationsSettingsContract\1.0.0.0\Windows.UI.ApplicationSettings.ApplicationsSettingsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.Core.AnimationMetrics.AnimationMetricsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.Core.AnimationMetrics.AnimationMetricsContract\1.0.0.0\Windows.UI.Core.AnimationMetrics.AnimationMetricsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.Core.CoreWindowDialogsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.Core.CoreWindowDialogsContract\1.0.0.0\Windows.UI.Core.CoreWindowDialogsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.UI.Xaml.Hosting.HostingContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.UI.Xaml.Hosting.HostingContract\1.0.0.0\Windows.UI.Xaml.Hosting.HostingContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
    <Reference Include="Windows.Web.Http.Diagnostics.HttpDiagnosticsContract">
      <HintPath>$(MsBuildProgramFiles32)\Windows Kits\10\References\Windows.Web.Http.Diagnostics.HttpDiagnosticsContract\1.0.0.0\Windows.Web.Http.Diagnostics.HttpDiagnosticsContract.winmd</HintPath>
      <Private>False</Private>
    </Reference>
</ItemGroup>
```

<span data-ttu-id="5bad7-223">上の参照では、このハイブリッド サーバーを適切に動作させるために欠かせない参照が慎重に組み合わされています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-223">The references above are a careful mix of eferences that are critical to the proper operation of this hybrid server.</span></span> <span data-ttu-id="5bad7-224">手順としては、(プロジェクトの OutputType を編集する手順で説明したように) .csproj ファイルを開き、これらの参照を必要に応じて追加します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-224">The protocol is to open the .csproj file (as described in how to edit the project OutputType) and add these references as necessary.</span></span>

<span data-ttu-id="5bad7-225">参照が適切に構成されたら、次は、サーバーの機能を実装する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-225">Once the references are properly configured, the next task is to implement the server's functionality.</span></span> <span data-ttu-id="5bad7-226">MSDN のトピックを参照してください。 [Windows ランタイム コンポーネントとの相互運用のためのベスト プラクティス (C を使用して UWP アプリ\##/vb/c C++ および XAML)](https://msdn.microsoft.com/library/windows/apps/hh750311.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-226">See the MSDN topic [Best practices for interoperability with Windows Runtime Components (UWP apps using C\#/VB/C++ and XAML)](https://msdn.microsoft.com/library/windows/apps/hh750311.aspx).</span></span>
<span data-ttu-id="5bad7-227">この作業では、実装の一部として、デスクトップ コードを呼び出すことができる Windows ランタイム コンポーネント dll を作成します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-227">The task is to create a Windows Runtime component dll that is able to call desktop code as part of its implementation.</span></span> <span data-ttu-id="5bad7-228">関連するサンプルには、Windows ランタイムで使われる主なパターンが含まれます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-228">The accompanying sample includes the major patterns used in Windows Runtime:</span></span>

-   <span data-ttu-id="5bad7-229">メソッド呼び出し</span><span class="sxs-lookup"><span data-stu-id="5bad7-229">Method calls</span></span>

-   <span data-ttu-id="5bad7-230">デスクトップ コンポーネントによる Windows ランタイム イベント ソース</span><span class="sxs-lookup"><span data-stu-id="5bad7-230">Windows Runtime Events sources by the desktop component</span></span>

-   <span data-ttu-id="5bad7-231">Windows ランタイムの非同期操作</span><span class="sxs-lookup"><span data-stu-id="5bad7-231">Windows Runtime Async operations</span></span>

-   <span data-ttu-id="5bad7-232">基本的な種類の配列を返す</span><span class="sxs-lookup"><span data-stu-id="5bad7-232">Returning arrays of basic types</span></span>

<span data-ttu-id="5bad7-233">**インストール**</span><span class="sxs-lookup"><span data-stu-id="5bad7-233">**Install**</span></span>

<span data-ttu-id="5bad7-234">アプリをインストールするには、実装をコピー **winmd** に関連付けられているサイドロード アプリケーションのマニフェストで指定された適切なディレクトリ:<ActivatableClassAttribute>の値"path"=。</span><span class="sxs-lookup"><span data-stu-id="5bad7-234">To install the app, copy the implementation **winmd** to the correct directory specified in the associated side-loaded application's manifest: <ActivatableClassAttribute>'s Value="path".</span></span> <span data-ttu-id="5bad7-235">また、関連付けられているすべてのサポート ファイルと、プロキシ/スタブ dll もコピーします (後者については後で詳しく説明します)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-235">Also copy any associated support files and the proxy/stub dll (this latter detail is covered below).</span></span> <span data-ttu-id="5bad7-236">実装のコピーが失敗する **winmd** サーバー ディレクトリの場所は、すべてのサイド ロード、RuntimeClass 上に新しいアプリケーションの呼び出し「クラスは登録されていません」エラーがスローされます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-236">Failing to copy the implementation **winmd** to the server directory location will cause all of the side-loaded application's calls to new on the RuntimeClass will throw a "class not registered" error.</span></span> <span data-ttu-id="5bad7-237">プロキシ/スタブをインストールできない (または登録できない) 場合は、すべての呼び出しが戻り値なしで失敗します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-237">Failure to install the proxy/stub (or failure to register) will cause all calls to fail with no return values.</span></span> <span data-ttu-id="5bad7-238">この後者のエラーが頻繁に **いない** 表示されている例外に関連付けられています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-238">This latter error is frequently **not** associated with visible exceptions.</span></span>
<span data-ttu-id="5bad7-239">この構成エラーが原因で発生する例外は、"無効なキャスト" を参照する可能性があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-239">If exceptions are observed due to this configuration error, they may refer to "invalid cast".</span></span>

<span data-ttu-id="5bad7-240">**サーバーの実装に関する考慮事項**</span><span class="sxs-lookup"><span data-stu-id="5bad7-240">**Server implementation considerations**</span></span>

<span data-ttu-id="5bad7-241">デスクトップ Windows ランタイム サーバーは、"ワーカー" または "タスク" に基づいていると考えることができます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-241">The desktop Windows Runtime server can be thought of as "worker" or "task" based.</span></span> <span data-ttu-id="5bad7-242">サーバーへのすべての呼び出しが UI スレッド以外で動作し、すべてのコードがマルチスレッドに対して安全である必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-242">Every call into the server operates on a non-UI thread and all code must be multi-thread aware and safe.</span></span> <span data-ttu-id="5bad7-243">また、サイドロード アプリケーションのどの部分が、サーバーの機能を呼び出してしているかも重要です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-243">Which part of the side-loaded application is calling the server's functionality is also important.</span></span> <span data-ttu-id="5bad7-244">サイドロード アプリケーションでは、実行に時間のかかるコードを UI スレッドから呼び出すことは必ず避けてください。</span><span class="sxs-lookup"><span data-stu-id="5bad7-244">It is critical to always avoid calling long-running code from any UI thread in the side-loaded application.</span></span> <span data-ttu-id="5bad7-245">それには、主に次の 2 つの方法があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-245">There are two main ways to accomplish this:</span></span>

1.  <span data-ttu-id="5bad7-246">UI スレッドからサーバーの機能を呼び出す場合、サーバーの公開サーフェス領域および実装では必ず非同期パターンを使います。</span><span class="sxs-lookup"><span data-stu-id="5bad7-246">If calling server functionality from a UI thread, always use an async pattern in the server's public surface area and implementation.</span></span>

2.  <span data-ttu-id="5bad7-247">サイドロード アプリケーションのバックグラウンド スレッドからサーバーの機能を呼び出します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-247">Call the server's functionality from a background thread in the side-loaded application.</span></span>

<span data-ttu-id="5bad7-248">**サーバーで Windows ランタイムの非同期**</span><span class="sxs-lookup"><span data-stu-id="5bad7-248">**Windows Runtime async in the server**</span></span>

<span data-ttu-id="5bad7-249">アプリケーション モデルのプロセス間通信の特性を考えると、サーバーを呼び出す場合のオーバーヘッドは、イン プロセスで占有的に実行されるコードよりも大きくなります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-249">Given the cross-process nature of the application model, calls to the server have more overhead than code that runs exclusively in-process.</span></span> <span data-ttu-id="5bad7-250">一般的に、インメモリの値を返す単純なプロパティを呼び出す操作はすばやく実行できて安全なのは、UI スレッドをブロックする心配がないからです。</span><span class="sxs-lookup"><span data-stu-id="5bad7-250">It is normally safe to call a simple property that returns an in-memory value because it will execute quickly enough that blocking the UI thread is not a concern.</span></span> <span data-ttu-id="5bad7-251">ただし、どのような種類でも I/O がかかわる呼び出しは (すべてのファイル処理やデータベース検索を含む)、UI スレッドの呼び出しをブロックする可能性があり、無応答が原因でアプリケーションが停止することがあります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-251">However, any call that involves I/O of any sort (this includes all file handling and database retrievals) can potentially block the calling UI thread and cause the application to be terminated due to unresponsiveness.</span></span> <span data-ttu-id="5bad7-252">さらに、オブジェクトに対するプロパティの呼び出しは、パフォーマンス上の理由から、アプリケーション アーキテクチャとしてはお勧めできません。</span><span class="sxs-lookup"><span data-stu-id="5bad7-252">In addition, property calls on objects are discouraged in this application architecture for performance reasons.</span></span>
<span data-ttu-id="5bad7-253">これについては、次のセクションで詳しく説明します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-253">This is covered in more depth in the following section.</span></span>

<span data-ttu-id="5bad7-254">適切に実装されたサーバーでは、通常、Windows ランタイム非同期パターンを使って、UI スレッドから直接行われた呼び出しが実装されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-254">A properly implemented server will normally implement calls made directly from UI threads via the Windows Runtime async pattern.</span></span> <span data-ttu-id="5bad7-255">これは、次のパターンに従って実装できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-255">This can be implemented by following this pattern.</span></span> <span data-ttu-id="5bad7-256">まずは、宣言です (ここでも、関連するサンプルから)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-256">First, the declaration (again, from the accompanying sample):</span></span>

```csharp
public IAsyncOperation<int> FindElementAsync(int input)
```

<span data-ttu-id="5bad7-257">これは整数を返す Windows ランタイム非同期操作を宣言します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-257">This declares a Windows Runtime async operation that returns an integer.</span></span>
<span data-ttu-id="5bad7-258">非同期操作の実装は、通常、次のような形になります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-258">The implementation of the async operation normally takes the form:</span></span>

```csharp
return Task<int>.Run( () =>
{
    int retval = ...
    // execute some potentially long-running code here 
}).AsAsyncOperation<int>();

```

><span data-ttu-id="5bad7-259">**注** この実装では、実行に時間がかかる可能性のある他の操作を待機するのが一般的です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-259">**Note** It is common to await some other potentially long running operations while writing the implementation.</span></span> <span data-ttu-id="5bad7-260">そうである場合、 **Task.Run** コードを宣言する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-260">If so, the **Task.Run** code needs to be declared:</span></span>

```csharp
return Task<int>.Run(async () =>
{
    int retval = ...
    // execute some potentially long-running code here 
    await ... // some other WinRT async operation or Task
}).AsAsyncOperation<int>();
```

<span data-ttu-id="5bad7-261">この非同期メソッドのクライアントは、他の Windows ランタイム非同期操作と同じようにこの操作を待つことができます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-261">Clients of this async method can await this operation like any other Windows Runtime aysnc operation.</span></span>

<span data-ttu-id="5bad7-262">**アプリケーションのバック グラウンド スレッドからサーバー機能を呼び出す**</span><span class="sxs-lookup"><span data-stu-id="5bad7-262">**Call server functionality from an application background thread**</span></span>

<span data-ttu-id="5bad7-263">通常、クライアントとサーバーは両方とも同じ組織によって作成されるため、サーバーへのすべての呼び出しをサイドロード アプリケーションのバックグラウンド スレッドから行うというプログラミング手法を採用できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-263">Since it is typical that both client and server will be written by the same organization, a programming practice can be adopted that all calls to the server will be made by a background thread in the side-loaded application.</span></span> <span data-ttu-id="5bad7-264">サーバーから 1 つ以上のバッチ データを収集する呼び出しは、バックグラウンド スレッドから直接行うことができます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-264">A direct call that collects one or more batches of data from the server can be made from a background thread.</span></span> <span data-ttu-id="5bad7-265">結果の取得が完了したら、アプリケーション プロセスのインメモリにあるバッチ データは、一般的に UI スレッドから直接取得できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-265">When the result(s) are completely retrieved, the batch of data that is in-memory in the application process can usually be directly retrieved from the UI thread.</span></span> <span data-ttu-id="5bad7-266">C\#オブジェクトは、当然ながら、バック グラウンドのスレッド間でアジャイルと UI スレッドはため、このような呼び出しパターンに特に便利です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-266">C\# objects are naturally agile between background threads and UI threads so are especially useful for this kind of calling pattern.</span></span>

## <a name="creating-and-deploying-the-windows-runtime-proxy"></a><span data-ttu-id="5bad7-267">Windows ランタイム プロキシの作成と展開</span><span class="sxs-lookup"><span data-stu-id="5bad7-267">Creating and deploying the Windows Runtime proxy</span></span>

<span data-ttu-id="5bad7-268">IPC アプローチには 2 つのプロセス間の Windows ランタイム インターフェイスのマーシャリングが伴うため、グローバルに登録された Windows ランタイム プロキシとスタブを使う必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-268">Since the IPC approach involves marshaling Windows Runtime interfaces between two processes, a globally registered Windows Runtime proxy and stub must be used.</span></span>

<span data-ttu-id="5bad7-269">**Visual Studio でのプロキシの作成**</span><span class="sxs-lookup"><span data-stu-id="5bad7-269">**Creating the proxy in Visual Studio**</span></span>

<span data-ttu-id="5bad7-270">作成および登録プロキシとスタブは、通常の UWP アプリ パッケージ内部で使用するプロセスは、トピックで説明されて [Windows ランタイム コンポーネントのイベントの発生](https://msdn.microsoft.com/library/windows/apps/dn169426.aspx)します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-270">The process for creating and registering proxies and stubs for use inside a regular UWP app package are described in the topic [Raising Events in Windows Runtime Components](https://msdn.microsoft.com/library/windows/apps/dn169426.aspx).</span></span>
<span data-ttu-id="5bad7-271">この記事で説明されている手順には、アプリケーション パッケージ内でのプロキシ/スタブの登録プロセスが含まれているため、次に示すプロセスよりも複雑です (グローバル登録とは異なります)。</span><span class="sxs-lookup"><span data-stu-id="5bad7-271">The steps described in this article are more complicated than the process described below because it involves registering the proxy/stub inside the application package (as opposed to registering it globally).</span></span>

<span data-ttu-id="5bad7-272">**手順 1:** デスクトップ コンポーネント プロジェクトのソリューションを使用して、Visual Studio でプロキシ/スタブ プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-272">**Step 1:** Using the solution for the desktop component project, create a Proxy/Stub project in Visual Studio:</span></span>

<span data-ttu-id="5bad7-273">**ソリューション > 追加 > プロジェクト > Visual C > Win32 コンソールの DLL の選択オプション。**</span><span class="sxs-lookup"><span data-stu-id="5bad7-273">**Solution > Add > Project > Visual C++ > Win32 Console Select DLL option.**</span></span>

<span data-ttu-id="5bad7-274">次の手順では、前提としています、サーバー コンポーネントと呼びます **MyWinRTComponent**します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-274">For the steps below, we assume the server component is called **MyWinRTComponent**.</span></span>

<span data-ttu-id="5bad7-275">**手順 3:** プロジェクトからすべての CPP/H ファイルを削除します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-275">**Step 3:** Delete all the CPP/H files from the project.</span></span>

<span data-ttu-id="5bad7-276">**手順 4:** 前のセクションでは、「コントラクトを定義する」には、実行するビルド後コマンドが含まれています。 **winmdidl.exe**、 **midl.exe**、 **mdmerge.exe**など。</span><span class="sxs-lookup"><span data-stu-id="5bad7-276">**Step 4:** The previous section "Defining the Contract" contains a Post-Build command that runs **winmdidl.exe**, **midl.exe**, **mdmerge.exe**, and so on.</span></span> <span data-ttu-id="5bad7-277">このビルド後のコマンドの midl 手順による出力の 1 つから、次の 4 つの重要な出力が生成されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-277">One of the outputs from the midl step of this post-build command generates four important outputs:</span></span>

<span data-ttu-id="5bad7-278">a) Dlldata.c</span><span class="sxs-lookup"><span data-stu-id="5bad7-278">a) Dlldata.c</span></span>

<span data-ttu-id="5bad7-279">b) ヘッダー ファイル (例: MyWinRTComponent.h)</span><span class="sxs-lookup"><span data-stu-id="5bad7-279">b) A header file (e.g. MyWinRTComponent.h)</span></span>

<span data-ttu-id="5bad7-280">c) A \* \_i.c ファイル (例: MyWinRTComponent\_i.c)</span><span class="sxs-lookup"><span data-stu-id="5bad7-280">c) A \*\_i.c file (e.g. MyWinRTComponent\_i.c)</span></span>

<span data-ttu-id="5bad7-281">d) A \* \_p.c ファイル (例: MyWinRTComponent\_p.c)</span><span class="sxs-lookup"><span data-stu-id="5bad7-281">d) A \*\_p.c file (e.g. MyWinRTComponent\_p.c)</span></span>

<span data-ttu-id="5bad7-282">**手順 5:** これら 4 つの生成されたファイルを"MyWinRTProxy"プロジェクトに追加します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-282">**Step 5:** Add these four generated files to the "MyWinRTProxy" project.</span></span>

<span data-ttu-id="5bad7-283">**手順 6:** Def ファイルを"MyWinRTProxy"プロジェクトに追加 **(プロジェクト > 新しい項目の追加 > コード > モジュール定義ファイル**) とする内容を更新します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-283">**Step 6:** Add a def file to "MyWinRTProxy" project **(Project > Add New Item > Code > Module-Definition File**) and update the contents to be:</span></span>

<span data-ttu-id="5bad7-284">LIBRARY MyWinRTComponent.Proxies.dll</span><span class="sxs-lookup"><span data-stu-id="5bad7-284">LIBRARY MyWinRTComponent.Proxies.dll</span></span>

<span data-ttu-id="5bad7-285">EXPORTS</span><span class="sxs-lookup"><span data-stu-id="5bad7-285">EXPORTS</span></span>

<span data-ttu-id="5bad7-286">DllCanUnloadNow PRIVATE</span><span class="sxs-lookup"><span data-stu-id="5bad7-286">DllCanUnloadNow PRIVATE</span></span>

<span data-ttu-id="5bad7-287">DllGetClassObject PRIVATE</span><span class="sxs-lookup"><span data-stu-id="5bad7-287">DllGetClassObject PRIVATE</span></span>

<span data-ttu-id="5bad7-288">DllRegisterServer PRIVATE</span><span class="sxs-lookup"><span data-stu-id="5bad7-288">DllRegisterServer PRIVATE</span></span>

<span data-ttu-id="5bad7-289">DllUnregisterServer PRIVATE</span><span class="sxs-lookup"><span data-stu-id="5bad7-289">DllUnregisterServer PRIVATE</span></span>

<span data-ttu-id="5bad7-290">**手順 7:**"MyWinRTProxy"プロジェクトのプロパティを開きます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-290">**Step 7:** Open properties for the "MyWinRTProxy" project:</span></span>

<span data-ttu-id="5bad7-291">**構成プロパティ > [全般] > ターゲット名。**</span><span class="sxs-lookup"><span data-stu-id="5bad7-291">**Comfiguration Properties > General > Target Name :**</span></span>

<span data-ttu-id="5bad7-292">MyWinRTComponent.Proxies</span><span class="sxs-lookup"><span data-stu-id="5bad7-292">MyWinRTComponent.Proxies</span></span>

<span data-ttu-id="5bad7-293">**[C/C++] > プリプロセッサの定義 > の追加**</span><span class="sxs-lookup"><span data-stu-id="5bad7-293">**C/C++ > Preprocessor Definitions > Add**</span></span>

<span data-ttu-id="5bad7-294">"WIN32;\_WINDOWS;登録\_プロキシ\_DLL"</span><span class="sxs-lookup"><span data-stu-id="5bad7-294">"WIN32;\_WINDOWS;REGISTER\_PROXY\_DLL"</span></span>

<span data-ttu-id="5bad7-295">**[C/C++] > プリコンパイル済みヘッダー。「プリコンパイル済みヘッダーを使用していない」を選択します。**</span><span class="sxs-lookup"><span data-stu-id="5bad7-295">**C/C++ > Precompiled Header : Select "Not Using Precompiled Header"**</span></span>

<span data-ttu-id="5bad7-296">**リンカー > [全般] > インポート ライブラリの無視します。[はい] を選択します。**</span><span class="sxs-lookup"><span data-stu-id="5bad7-296">**Linker > General > Ignore Import Library : Select "Yes"**</span></span>

<span data-ttu-id="5bad7-297">**リンカー > の入力 > 追加の依存関係。Rpcrt4.lib;runtimeobject.lib を追加します。**</span><span class="sxs-lookup"><span data-stu-id="5bad7-297">**Linker > Input > Additional Dependencies : Add rpcrt4.lib;runtimeobject.lib**</span></span>

<span data-ttu-id="5bad7-298">**リンカー > Windows メタデータ > Windows メタデータを生成します。[いいえ] を選択します。**</span><span class="sxs-lookup"><span data-stu-id="5bad7-298">**Linker > Windows Metadata > Generate Windows Metadata : Select "No"**</span></span>

<span data-ttu-id="5bad7-299">**手順 8:**"MyWinRTProxy"プロジェクトをビルドします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-299">**Step 8:** Build the "MyWinRTProxy" project.</span></span>

<span data-ttu-id="5bad7-300">**プロキシの展開**</span><span class="sxs-lookup"><span data-stu-id="5bad7-300">**Deploying the proxy**</span></span>

<span data-ttu-id="5bad7-301">プロキシは、グローバルに登録する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-301">The proxy must be globally registered.</span></span> <span data-ttu-id="5bad7-302">最も簡単にこれを行うには、インストール プロセスによってプロキシ dll の DllRegisterServer が呼び出されるようにします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-302">The simplest way to do this is to have your install process call DllRegisterServer on the proxy dll.</span></span> <span data-ttu-id="5bad7-303">この機能でサポートされるのは x86 用に構築されたサーバーだけなので (つまり 64 ビットはサポートされません)、最もシンプルな構成は、32 ビットのサーバー、32 ビットのプロキシ、32 ビットのサイドロード アプリケーションを使った構成となります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-303">Note that since the feature only supports servers built for x86 (i.e. no 64-bit support), the simplest configuration is to use a 32-bit server, a 32-bit proxy, and a 32-bit side-loaded application.</span></span> <span data-ttu-id="5bad7-304">プロキシは通常実装と共に配置 **winmd** デスクトップ コンポーネント。</span><span class="sxs-lookup"><span data-stu-id="5bad7-304">The proxy normally sits alongside the implementation **winmd** for the desktop component.</span></span>

<span data-ttu-id="5bad7-305">追加の構成手順を 1 つ実行する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-305">One additional configuration step must be performed.</span></span> <span data-ttu-id="5bad7-306">サイドロード プロセスでプロキシを読み込んで実行できるようにうするには、ディレクトリが ALL_APPLICATION_PACKAGES に対して "読み取りと実行" としてマークされている必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-306">In order for the side-loaded process to load and execute the proxy, the directory must be marked "read / execute" for ALL_APPLICATION_PACKAGES.</span></span> <span data-ttu-id="5bad7-307">使用してこれには、 **icacls.exe** コマンド ライン ツール。</span><span class="sxs-lookup"><span data-stu-id="5bad7-307">This is done via the **icacls.exe** command line tool.</span></span> <span data-ttu-id="5bad7-308">このコマンドを実行するディレクトリに、実装 **winmd** プロキシ/スタブの dll が存在して。</span><span class="sxs-lookup"><span data-stu-id="5bad7-308">This command should execute in the directory where the implementation **winmd** and proxy/stub dll resides:</span></span>

<span data-ttu-id="5bad7-309">*icacls します。/T/grant \*S-1-15-2-1:RX*</span><span class="sxs-lookup"><span data-stu-id="5bad7-309">*icacls . /T /grant \*S-1-15-2-1:RX*</span></span>

## <a name="patterns-and-performance"></a><span data-ttu-id="5bad7-310">パターンとパフォーマンス</span><span class="sxs-lookup"><span data-stu-id="5bad7-310">Patterns and performance</span></span>

<span data-ttu-id="5bad7-311">プロセス間のトランスポートのパフォーマンスを慎重に監視することは、非常に重要です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-311">It is very important that performance of the cross-process transport be carefully monitored.</span></span> <span data-ttu-id="5bad7-312">プロセス間の呼び出しのコストは、インプロセスの呼び出しの 2 倍以上です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-312">A cross-process call is at least twice as expensive than an in-process call.</span></span> <span data-ttu-id="5bad7-313">プロセス間で "頻繁な" 会話をしたり、ビットマップ イメージなどの大きなオブジェクトを繰り返し転送したりすると、アプリケーションのパフォーマンスが予想外に低下し、問題が生じることがあります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-313">Creating "chatty" conversations cross-process or performing repeated transfers of large objects like bitmap images, can cause unexpected and undesirable application performance.</span></span>

<span data-ttu-id="5bad7-314">次の点を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="5bad7-314">Here is a non-exhaustive list of things to consider:</span></span>

-   <span data-ttu-id="5bad7-315">アプリケーションの UI スレッドからサーバーへの同期メソッド呼び出しは常に避けます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-315">Synchronous method calls from application's UI thread to the server should always be avoided.</span></span> <span data-ttu-id="5bad7-316">メソッドをアプリケーションのバックグラウンド スレッドから呼び出し、必要に応じて CoreWindowDispatcher を使って、結果を UI スレッドに提供します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-316">Call the method from a background thread in the application and then use CoreWindowDispatcher to get the results onto the UI thread if necessary.</span></span>

-   <span data-ttu-id="5bad7-317">アプリケーションの UI スレッドからの非同期操作の呼び出しは安全ですが、次に説明するパフォーマンス上の問題を考慮してください。</span><span class="sxs-lookup"><span data-stu-id="5bad7-317">Calling async operations from an application UI thread is safe, but consider the performance problems discussed below.</span></span>

-   <span data-ttu-id="5bad7-318">結果のバルク転送により、プロセス間の対話が減ります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-318">Bulk transfer of results reduces cross-process chattiness.</span></span> <span data-ttu-id="5bad7-319">これは通常、Windows ランタイム配列を使って処理されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-319">This is normally performed by using the Windows Runtime Array construct.</span></span>

-   <span data-ttu-id="5bad7-320">返す *一覧<T>* 場所 *T* 非同期操作またはプロパティのフェッチのオブジェクトは、多数のプロセス間の頻繁な通信が発生します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-320">Returning *List<T>* where *T* is an object from an async operation or property fetch, will cause a lot of cross-process chattiness.</span></span> <span data-ttu-id="5bad7-321">たとえば、戻る、*一覧&lt;人&gt;* オブジェクト。</span><span class="sxs-lookup"><span data-stu-id="5bad7-321">For example, assume you return a*List&lt;People&gt;* objects.</span></span> <span data-ttu-id="5bad7-322">このとき、各反復パスがプロセス間呼び出しになります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-322">Each iteration pass will be a cross-process call.</span></span> <span data-ttu-id="5bad7-323">各 *人* 返されるオブジェクトは、プロキシと各メソッドの呼び出しで表されるまたはプロセス間呼び出しでその個々 のオブジェクトのプロパティになります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-323">Each *People* object returned is represented by a proxy and each call to a method or property on that individual object will result in a cross-process call.</span></span> <span data-ttu-id="5bad7-324">ように「無害」 *一覧&lt;人&gt;* オブジェクト、 *数* が大きい低速な呼び出しの数が多いと。</span><span class="sxs-lookup"><span data-stu-id="5bad7-324">So an "innocent" *List&lt;People&gt;* object where *Count* is large will cause a large number of slow calls.</span></span> <span data-ttu-id="5bad7-325">パフォーマンスを改善するには、コンテンツの構造体を配列に格納してバルク転送します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-325">Better performance results from bulk transfer of structs of the content in an array.</span></span> <span data-ttu-id="5bad7-326">例:</span><span class="sxs-lookup"><span data-stu-id="5bad7-326">For example:</span></span>

```csharp
struct PersonStruct
{
    String LastName;
    String FirstName;
    int Age;
   // etc.
}
```

<span data-ttu-id="5bad7-327">戻ります* PersonStruct\[\]* の代わりに *一覧&lt;PersonObject&gt;* します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-327">Then return* PersonStruct\[\]* instead of *List&lt;PersonObject&gt;*.</span></span>
<span data-ttu-id="5bad7-328">これにより、プロセス間の "ホップ" を 1 回に抑えてすべてのデータを取得できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-328">This gets all the data across in one cross-process "hop"</span></span>

<span data-ttu-id="5bad7-329">パフォーマンスに関する他のあらゆる考慮事項と同様に、ここでも測定とテストが重要になります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-329">As with all performance considerations, measurement and testing is critical.</span></span> <span data-ttu-id="5bad7-330">利用統計情報をさまざまな操作に挿入して、所要時間を判断することをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-330">Ideally telemetry should be inserted into the various operations to determine how long they take.</span></span> <span data-ttu-id="5bad7-331">範囲にわたって測定することが重要: たとえば、所要時間はどれが実際にすべてを使用する、 *人* サイドロード アプリケーションで特定のクエリのオブジェクトですか?</span><span class="sxs-lookup"><span data-stu-id="5bad7-331">It is important to measure across a range: for example, how long does it actually take to consume all the *People* objects for a particular query in the side-loaded application?</span></span>

<span data-ttu-id="5bad7-332">変数読み込みテストという手法もあります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-332">Another technique is variable load testing.</span></span> <span data-ttu-id="5bad7-333">これを行うには、パフォーマンス テストのフックを、変数遅延の負荷をサーバー処理に組み込むアプリケーションに挿入します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-333">This can be done by putting performance test hooks into the application that introduce variable delay loads into the server processing.</span></span> <span data-ttu-id="5bad7-334">これによりさまざまな負荷と、さまざまなサーバー パフォーマンスに対するアプリケーションの反応をシミュレートできます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-334">This can simulate various kinds of load and the application's reaction to varying server performance.</span></span>
<span data-ttu-id="5bad7-335">サンプルは、適切な非同期手法を使って時間の遅延をコードに挿入する方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="5bad7-335">The sample illustrates how to put time delays into code using proper async techniques.</span></span> <span data-ttu-id="5bad7-336">挿入する正確な遅延時間と、その意図的な負荷に含めるランダム化の範囲は、アプリケーションの設計と、そのアプリケーションが実行される予定の環境によって異なります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-336">The exact amount of delay to inject and the range of randomization to put into that artificial load will vary by application design and the anticipated environment in which the application will run.</span></span>

## <a name="development-process"></a><span data-ttu-id="5bad7-337">開発プロセス</span><span class="sxs-lookup"><span data-stu-id="5bad7-337">Development process</span></span>

<span data-ttu-id="5bad7-338">サーバーを変更するときは、以前に実行されていたインスタンスがいずれも実行されていないことを確認することが必要です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-338">When you make changes to the server, it is necessary to make sure any previously running instances are no longer running.</span></span> <span data-ttu-id="5bad7-339">COM は、最終的にはプロセスを清掃しますが、タイマーによる処理には時間がかかり、反復的な開発では効率的ではありません。</span><span class="sxs-lookup"><span data-stu-id="5bad7-339">COM will eventually scavenge the process, but the rundown timer takes longer than is efficient for iterative development.</span></span> <span data-ttu-id="5bad7-340">そのため、前に実行されているインスタンスを強制終了することは、開発中に通常の手順です。</span><span class="sxs-lookup"><span data-stu-id="5bad7-340">Thus, killing a previously running instance is a normal step during development.</span></span> <span data-ttu-id="5bad7-341">これには、どの dllhost のインスタンスがサーバーをホストしているかを開発者が追跡する必要があります。</span><span class="sxs-lookup"><span data-stu-id="5bad7-341">This requires that the developer keep track of which dllhost instance is hosting the server.</span></span>

<span data-ttu-id="5bad7-342">サーバー プロセスを見つけて強制終了するには、タスク マネージャーやその他のサード パーティ アプリを使うことができます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-342">The server process can be found and killed using Task Manager or other third party apps.</span></span> <span data-ttu-id="5bad7-343">コマンド ライン ツール **TaskList.exe **も含まれていて、柔軟な構文は、たとえば。</span><span class="sxs-lookup"><span data-stu-id="5bad7-343">The command line tool **TaskList.exe **is also included and has flexible syntax, for example:</span></span>

  
 | <span data-ttu-id="5bad7-344">**コマンド**</span><span class="sxs-lookup"><span data-stu-id="5bad7-344">**Command**</span></span> | <span data-ttu-id="5bad7-345">**操作**</span><span class="sxs-lookup"><span data-stu-id="5bad7-345">**Action**</span></span> |
 | ------------| ---------- |
 | <span data-ttu-id="5bad7-346">tasklist</span><span class="sxs-lookup"><span data-stu-id="5bad7-346">tasklist</span></span> | <span data-ttu-id="5bad7-347">実行中のすべてのプロセスをほぼ作成時刻の順序で一覧表示します。最後に作成されたプロセスは下の方に表示されます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-347">Lists all the running processes in approximate order of creation time, with the most recently created processes near the bottom.</span></span> |
 | <span data-ttu-id="5bad7-348">tasklist /FI "IMAGENAME eq dllhost.exe" /M</span><span class="sxs-lookup"><span data-stu-id="5bad7-348">tasklist /FI "IMAGENAME eq dllhost.exe" /M</span></span> | <span data-ttu-id="5bad7-349">すべての dllhost.exe インスタンスの情報を一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-349">Lists info on all the dllhost.exe instances.</span></span> <span data-ttu-id="5bad7-350">/M スイッチは、読み込み済みのモジュールを一覧表示します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-350">The /M switch lists the modules that they have loaded.</span></span> |
 | <span data-ttu-id="5bad7-351">tasklist /FI "PID eq 12564" /M</span><span class="sxs-lookup"><span data-stu-id="5bad7-351">tasklist /FI "PID eq 12564" /M</span></span> | <span data-ttu-id="5bad7-352">PID がわかっている場合に dllhost.exe を照会するには、このオプションを使用できます。</span><span class="sxs-lookup"><span data-stu-id="5bad7-352">You can use this option to query the dllhost.exe if you know its PID.</span></span> |

<span data-ttu-id="5bad7-353">ブローカー サーバーのモジュールの一覧が表示されるはず *clrhost.dll* 読み込まれたモジュールの一覧にします。</span><span class="sxs-lookup"><span data-stu-id="5bad7-353">The module list for a broker server should list *clrhost.dll* in its list of loaded modules.</span></span>

## <a name="resources"></a><span data-ttu-id="5bad7-354">参考資料</span><span class="sxs-lookup"><span data-stu-id="5bad7-354">Resources</span></span>

-   [<span data-ttu-id="5bad7-355">VS 2015 および Windows 10 用のプロジェクト テンプレートの仲介型の WinRT コンポーネント</span><span class="sxs-lookup"><span data-stu-id="5bad7-355">Brokered WinRT Component Project Templates for Windows 10 and VS 2015</span></span>](https://visualstudiogallery.msdn.microsoft.com/10be07b3-67ef-4e02-9243-01b78cd27935)

-   [<span data-ttu-id="5bad7-356">NorthwindRT は、WinRT コンポーネント サンプルの仲介型</span><span class="sxs-lookup"><span data-stu-id="5bad7-356">NorthwindRT Brokered WinRT Component Sample</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=397349)

-   [<span data-ttu-id="5bad7-357">Microsoft Store アプリを信頼できる配信</span><span class="sxs-lookup"><span data-stu-id="5bad7-357">Delivering reliable and trustworthy Microsoft Store apps</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=393644)

-   [<span data-ttu-id="5bad7-358">アプリ コントラクトと拡張機能 (Windows ストア アプリ)</span><span class="sxs-lookup"><span data-stu-id="5bad7-358">App contracts and extensions (Windows Store apps)</span></span>](https://msdn.microsoft.com/library/windows/apps/hh464906.aspx)

-   [<span data-ttu-id="5bad7-359">Windows 10 でアプリをサイドロードする方法</span><span class="sxs-lookup"><span data-stu-id="5bad7-359">How to sideload apps on Windows 10</span></span>](https://msdn.microsoft.com/windows/uwp/get-started/enable-your-device-for-development#GroupPolicy)

-   [<span data-ttu-id="5bad7-360">UWP アプリを企業に展開します。</span><span class="sxs-lookup"><span data-stu-id="5bad7-360">Deploying UWP apps to businesses</span></span>](https://go.microsoft.com/fwlink/p/?LinkID=264770)

