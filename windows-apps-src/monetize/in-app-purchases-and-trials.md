---
ms.assetid: F45E6F35-BC18-45C8-A8A5-193D528E2A4E
description: UWP アプリのアプリ内購入と試用版を有効にする方法を説明します。
title: アプリ内購入と試用版
ms.date: 05/09/2018
ms.topic: article
keywords: Windows 10, UWP, アプリ内購入, IAP, アドオン, 試用版, コンシューマブル, 永続的, サブスクリプション
ms.localizationpriority: medium
ms.openlocfilehash: 9891205d4fdc8110cb727fb5caabbff6c5f4f948
ms.sourcegitcommit: b4c502d69a13340f6e3c887aa3c26ef2aeee9cee
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/03/2018
ms.locfileid: "8484276"
---
# <a name="in-app-purchases-and-trials"></a>アプリ内購入と試用版

Windows SDK に用意されている API を使用して、以下の機能を実装し、ユニバーサル Windows プラットフォーム (UWP) アプリによる収益を向上させることができます。

* **アプリ内購入**&nbsp;&nbsp; アプリが無料であるかどうかにかかわらず、コンテンツやアプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。

* **試用版機能**&nbsp;&nbsp;かどうかは[アプリをパートナー センターで無料試用版として構成](../publish/set-app-pricing-and-availability.md#free-trial)すると、するように仕向けるを除外または、試用期間中に一部の機能を制限することによって、アプリの通常版を購入する顧客です。 また、顧客がアプリを購入する前の試用期間中にだけバナーや透かしなどが表示されるようにもできます。

この記事では、UWP アプリでのアプリ内購入と試用版のしくみについて、その概要を説明します。

<span id="choose-namespace" />

## <a name="choose-which-namespace-to-use"></a>使用する名前空間を選ぶ

UWP アプリにアプリ内購入機能や試用版機能を追加する際に使用できる名前空間は、2 つあります。どちらの名前空間を使用するかは、アプリのターゲットとなる Windows 10 のバージョンによって決まります。 これらの名前空間の API は同じ目的を果たしますが、その設計は大きく異なります。また、この 2 つの API 間にコードの互換性はありません。

* **[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx)**&nbsp;&nbsp;Windows 10 バージョン 1607 以降の場合、アプリはこの名前空間の API を使用して、アプリ内購入および試用版を実装することができます。 Visual Studio でアプリ プロジェクトのターゲットが **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降である場合は、この名前空間のメンバーを使用することをお勧めします。 この名前空間では、ストアで管理されるコンシューマブルなアドオンなど、最新のアドオン種類をサポートし、今後の製品とパートナー センターとストアでサポートされる機能の種類に対応するのには設計されています。 この名前空間について詳しくは、この記事の「[Windows.Services.Store 名前空間を使用するアプリ内購入と試用版](#api_intro)」をご覧ください。

* **[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx)**&nbsp;&nbsp;Windows 10 のすべてのバージョンでは、この名前空間にあるアプリ内購入と試用版向けの以前の API がサポートされています。 **Windows.ApplicationModel.Store** 名前空間については、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

> [!IMPORTANT]
> **Windows.ApplicationModel.Store** 名前空間は今後更新されず、新機能も追加されないため、アプリでは、可能であれば代わりに **Windows.Services.Store** 名前空間を使うことをお勧めします。 [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用する Windows デスクトップ アプリケーションで、またはアプリまたはパートナー センターで開発サンド ボックスを使用するゲーム、 **Windows.ApplicationModel.Store**名前空間がサポートされていません (たとえば、このような場合にゲームのいずれかのXbox Live と統合)。

<span id="concepts" />

## <a name="basic-concepts"></a>基本的な概念

ストアで提供されるアイテムはすべて、通常、*製品*と呼ばれます。 ほとんどの開発者が扱う製品の種類は、*アプリ*と*アドオン*のみです。

アドオンとは、ユーザーがアプリのコンテキストで利用できる製品や機能のことです。たとえば、アプリやゲームで使用される通貨、ゲームの新しい地図や武器、広告を表示せずにアプリを使用できる機能などに加え、音楽やビデオなどのデジタル コンテンツを提供できるアプリなら、そのようなコンテンツのことも表します。 すべてのアプリとアドオンは、そのアプリやアドオンを使用する権利がユーザーにあるかどうかを示す関連付けられたライセンスを備えます。 アプリまたはアドオンを試用版として使用する権利がユーザーにある場合は、その試用版に関する追加情報もライセンスによって提供されます。

アドオンをアプリでユーザーに提供するには、必要があります[パートナー センターでのアプリのアドオンを定義](../publish/add-on-submissions.md)ので、ストアで認識されます。 その後で、アプリで **Windows.Services.Store** または **Windows.ApplicationModel.Store** 名前空間の API を使用して、アプリ内購入としてユーザーに販売するアドオンを提供することができます。

UWP アプリでは、次の種類のアドオンを提供できます。

| アドオンの種類 |  説明  |
|---------|-------------------|
| 永続的  |  その[パートナー センターで指定](../publish/enter-iap-properties.md)有効期間のあいだ保持されるアドオンです。 <p/><p/>既定では、永続的なアドオンの有効期限が切れることはありません。この場合、アドオンは 1 回のみ購入することができます。 アドオンで特定の期間を指定している場合、期限が切れた後、ユーザーはアドオンを再購入できます。 |
| 開発者により管理されるコンシューマブル  |  購入して使用し、消費した後でもう一度購入可能なアドオンです。 アドオンが表すユーザーのアイテムの残量の追跡は開発者が行います。<p/><p/>ユーザーがアドオンに関連付けられたアイテムを消費したら、ユーザーの残量を保持し、ユーザーによってすべてのアイテムが消費されたらアドオンの購入をフルフィルメント完了として Microsoft Store に報告する義務が開発者にあります。 以前のアドオン購入をフルフィルメント完了としてアプリで報告するまで、ユーザーがそのアドオンを再購入することはできません。 <p/><p/>たとえば、アドオンがゲーム内の 100 コインを表しており、ユーザーによって 10 コインが消費されている場合、アプリまたはサービスでは、ユーザーの 90 コインの残高を保持する必要があります。 ユーザーによって 100 コインすべてが消費されたら、アプリでそのアドオンをフルフィルメント完了として報告する必要があります。その後、ユーザーは 100 コイン アドオンを再購入できます。    |
| Microsoft Store で管理されるコンシューマブル  |  購入し、使用した後にいつでも再購入できるアドオンです。 アドオンが表すユーザーのアイテムの残量は Microsoft Store で追跡します。<p/><p/>アドオンに関連付けられたアイテムがユーザーにより消費されたら、そのアイテムをフルフィルメント完了として Microsoft Store に報告する義務が開発者にあり、Microsoft Store によってユーザーの残量が更新されます。 ユーザーは、必要な回数だけアドオンを購入できます (最初にアイテムを使用する必要はありません)。 アプリでは、ユーザーのアイテムの現在の残量をいつでも照会できます。 <p/><p/> たとえば、アドオンがゲーム内の 100 のコインの初期量を表しており、ユーザーによって 50 コインが消費された場合、そのアドオンの 50 ユニットがフルフィルメント完了したことをアプリで Microsoft Store に報告すると、Microsoft Store により残高が更新されます。 ユーザーがアドオンを再購入して 100 個以上のコインを獲得した場合、合計で 150 個のコインを手にします。 <p/><p/>**注:**&nbsp;&nbsp;Microsoft Store で管理されるコンシューマブルを使用するには、Visual Studio でアプリが **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降をターゲットとし、**Windows.ApplicationModel.Store** 名前空間ではなく、**Windows.Services.Store** 名前空間を使用する必要があります。  |
| サブスクリプション | アドオンを使い続けるために定期的な間隔でユーザーが継続的に課金する永続的なアドオンです。 ユーザーはいつでもサブスクリプションをキャンセルして、それ以降の課金を取り消すことができます。 <p/><p/>**注**&nbsp;&nbsp;サブスクリプション アドオンを使用するには、Visual Studio でアプリが **Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降をターゲットとし、**Windows.ApplicationModel.Store** 名前空間ではなく、**Windows.Services.Store** 名前空間を使用する必要があります。  |

<span />

> [!NOTE]
> パッケージで使用される永続的なアドオン (ダウンロード コンテンツまたは DLC とも呼ばれます) など、他の種類のアドオンが利用できるのは一部の開発者に限られており、このドキュメントでは説明しません。

<span id="api_intro" />

## <a name="in-app-purchases-and-trials-using-the-windowsservicesstore-namespace"></a>Windows.Services.Store 名前空間を使用するアプリ内購入と試用版

このセクションでは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の重要なタスクと概念の概要について説明します。 この名前空間は、Visual Studio で**Windows 10 Anniversary Edition (10.0、ビルド 14393)** 以降 (これは Windows 10 バージョン 1607 に対応) をターゲットとするアプリでのみ利用可能です。 可能であれば、アプリで [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間ではなく、**Windows.Services.Store** 名前空間を使用することをお勧めします。 **Windows.ApplicationModel.Store** 名前空間については、[この記事](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)をご覧ください。

**このセクションの内容**

* [ビデオ](#video)
* [StoreContext クラスの概要](#get-started-storecontext)
* [アプリ内購入の実装](#implement-iap)
* [試用版機能の実装](#implement-trial)
* [アプリ内購入や試用版の実装のテスト](#testing)
* [アプリ内購入の受領通知](#receipts)
* [デスクトップ ブリッジでの StoreContext クラスの使用](#desktop)
* [製品、SKU、および可用性](#products-skus)
* [ストア ID](#store-ids)

<span id="video" />

### <a name="video"></a>ビデオ

[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使用してアプリにアプリ内購入を実装する方法の概要については、次のビデオをご覧ください。
<br/>
<br/>
> [!VIDEO https://channel9.msdn.com/Blogs/One-Dev-Minute/Adding-In-App-Purchases-to-Your-UWP-App/player]

<span id="get-started-storecontext" />

### <a name="get-started-with-the-storecontext-class"></a>StoreContext クラスの概要

**Windows.Services.Store** 名前空間のメイン エントリ ポイントは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスです。 このクラスには、現在のアプリとその利用可能なアドオンに関する情報の取得、現在のアプリまたはそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリまたはアドオンの購入、およびその他のタスクを行う際に使用できるメソッドが用意されています。 [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを取得するには、次のいずれかを実行します。

* シングル ユーザー アプリ (アプリを起動したユーザーのコンテキストのみで実行されるアプリ) では、静的な [GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getdefault) メソッドを使って **StoreContext** オブジェクトを取得します。このオブジェクトをうと、ユーザーの Microsoft Store 関連のデータにアクセスできます。 ほとんどのユニバーサル Windows プラットフォーム アプリ (UWP) アプリはシングル ユーザー アプリです。

  ```csharp
  Windows.Services.Store.StoreContext context = StoreContext.GetDefault();
  ```

* [マルチユーザー アプリ](../xbox-apps/multi-user-applications.md)では、静的な [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getforuser) メソッドを使って **StoreContext** オブジェクトを取得します。このオブジェクトを使うと、アプリの使用中に Microsoft アカウントでサインインしていた特定のユーザーに関する Microsoft Store 関連のデータにアクセスできます。 次の例は、利用可能な最初のユーザーの **StoreContext** オブジェクトを取得します。

  ```csharp
  var users = await Windows.System.User.FindAllAsync();
  Windows.Services.Store.StoreContext context = StoreContext.GetForUser(users[0]);
  ```

> [!NOTE]
> [デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop) を使用する Windows デスクトップ アプリケーションでは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを使用する前に、追加の手順を実行してこのオブジェクトを構成する必要があります。 詳しくは、[このセクション](#desktop)をご覧ください。

[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成すると、このオブジェクトのメソッドを呼び出して、現在のアプリやアドオンに関するストア製品情報の取得、現在のアプリとそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリやアドオンの購入、およびその他のタスクを実行できます。 このオブジェクトを使用して実行できる一般的なタスクについて詳しくは、次の記事をご覧ください。

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリのサブスクリプション アドオンの有効化](enable-subscription-add-ons-for-your-app.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)

**StoreContext** および **Windows.Services.Store** 名前空間にある他の型を使用する方法を示すサンプル アプリについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

<span id="implement-iap" />

### <a name="implement-in-app-purchases"></a>アプリ内購入の実装

**Windows.Services.Store** 名前空間を使用して、アプリでアプリ内購入をユーザーに提供するには:

1. 場合は、アプリは、ユーザーが購入すると、[パートナー センターでのアプリのアドオンの申請を作成する](https://msdn.microsoft.com/windows/uwp/publish/add-on-submissions)アドオンを提供します。

2. [アプリで提供されるアプリやアドオンの製品情報を取得](get-product-info-for-apps-and-add-ons.md)してから、[ライセンスがアクティブになっているかどうかを判断](get-license-info-for-apps-and-add-ons.md)する (つまり、アプリやアドオンを使用するためのライセンスをユーザーが所有しているかどうかを判断する) ようにアプリのコードを記述します。 ライセンスがアクティブになっていない場合、ユーザーに販売するためのアプリやアドオンをアプリ内購入として提供する UI を表示します。

3. ユーザーがアプリやアドオンの購入を選んだ場合、製品を購入するための適切なメソッドを使用します。

    * ユーザーがアプリや永続的なアドオンを購入する場合は、「[アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)」の指示に従ってください。
    * ユーザーがコンシューマブルなアドオンを購入する場合は、「[コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)」の指示に従ってください。
    * ユーザーがサブスクリプション アドオンを購入する場合は、「[アプリのサブスクリプション アドオンの有効化](enable-subscription-add-ons-for-your-app.md)」の指示に従ってください。

4. この記事に記載されている[テスト ガイダンス](#testing)に従って、実装をテストします。

<span id="implement-trial" />

### <a name="implement-trial-functionality"></a>試用版機能の実装

**Windows.Services.Store** 名前空間を使用して、アプリの試用版の機能を除外または制限するには:

1. [パートナー センターで無料試用版としてアプリを構成](../publish/set-app-pricing-and-availability.md#free-trial)します。

2. [アプリで提供されるアプリやアドオンの製品情報を取得](get-product-info-for-apps-and-add-ons.md)してから、[アプリに関連付けられているライセンスが試用版ライセンスになっているかどうかを判断](get-license-info-for-apps-and-add-ons.md)するようにアプリのコードを記述します。

3. 試用版である場合は、アプリの特定の機能を除外または制限します。ユーザーが完全なライセンスを購入した場合は、その機能を有効にします。 詳細とコード例については、「[アプリの試用版の実装](implement-a-trial-version-of-your-app.md)」をご覧ください。

4. この記事に記載されている[テスト ガイダンス](#testing)に従って、実装をテストします。

<span id="testing" />

### <a name="test-your-in-app-purchase-or-trial-implementation"></a>アプリ内購入や試用版の実装のテスト

アプリで **Windows.Services.Store** 名前空間の API を使用してアプリ内購入や試用版機能を実装する場合は、アプリを Store に公開してからそのアプリを開発デバイスにダウンロードし、そのライセンスを使用してテストを行う必要があります。 コードをテストするには次のプロセスに従います。

1. アプリがまだ公開されてストア内でない場合は、アプリがパートナー センターで、[アプリの提出](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)を、 [Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たしていることを確認し、アプリが認定プロセスを通過かどうかを確認します。 テスト中に[ストアでアプリを検索できないようにアプリを構成する](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability)ことも可能です。 [パッケージ フライト](../publish/package-flights.md)の適切な構成に注意してください。 正しく構成されているパッケージをフライト可能性がありますできませんをダウンロードします。

2. 次に、以下の操作が完了していることを確認します。

    * [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラス、および **Windows.Services.Store** 名前空間にある他の関連する型を使用するアプリのコードを、[アプリ内購入](#implement-iap)や[試用版機能](#implement-trial)を実装するように記述します。
    * 場合は、アプリは、[パートナー センターでのアプリのアドオンの申請を作成する](https://msdn.microsoft.com/windows/uwp/publish/add-on-submissions)ユーザーが購入できるアドオンを提供します。
    * 除外または[パートナー センターで無料試用版としてのアプリの構成](../publish/set-app-pricing-and-availability.md#free-trial)アプリの試用版で一部の機能を制限する場合。

3. プロジェクトを Visual Studio で開き、**[プロジェクト]** メニューをクリックし、**[ストア]** をポイントして、**[アプリケーションをストアと関連付ける]** をクリックします。 パートナー センター アカウントを使用してテストするアプリとアプリ プロジェクトを関連付けますウィザードの指示を完了します。
    > [!NOTE]
    > プロジェクトとストアのアプリを関連付けていない場合、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) メソッドにより、戻り値の **ExtendedError** プロパティがエラー コード値 0x803F6107 に設定されます。 この値は、ストアにそのアプリに関する情報がないことを示します。
4. まだ前の手順で指定したストアのアプリをインストールしていない場合は、アプリをインストールし、アプリを一度実行してから閉じます。 これにより、アプリの有効なライセンスが開発用デバイスにインストールされます。

5. Visual Studio で、プロジェクトの実行またはデバッグを開始します。 コードによって、ローカルのプロジェクトと関連付けたストア アプリからアプリおよびアドオンのデータが取得されます。 アプリを再インストールするように求められた場合は、その指示に従った後、プロジェクトを実行またはデバッグします。
    > [!NOTE]
    > 上記の手順を実行すると、ストアに新しいアプリ パッケージを提出しなくても、引き続きアプリのコードを更新し、更新されたプロジェクトを開発用コンピューターでデバッグできます。 テストで使用するローカル ライセンスを取得するため、開発用コンピューターにストア バージョンのアプリを 1 度だけダウンロードする必要があります。 テストが完了し、ユーザーがアプリのアプリ内購入や試用版に関連する機能を利用できるようにするには、ストアに新しいアプリ パッケージを申請するだけで済みます。

アプリで **Windows.ApplicationModel.Store** 名前空間を使用している場合は、アプリで [CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスを使用することで、アプリをストアに提出する前に、ライセンス情報をテスト中にシミュレートできます。 詳しくは、「[CurrentApp クラスと CurrentAppSimulator クラスの概要] (in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md#get-started-with-the-currentapp-and-currentappsimulator-classes)」をご覧ください。  

> [!NOTE]
> **Windows.Services.Store** 名前空間には、テスト中にライセンス情報をシミュレートするために使用できるクラスが用意されていません。 **Windows.Services.Store** 名前空間を使用してアプリ内購入または試用版を実装する場合は、上記のように、アプリをストアに公開してからそのアプリを開発デバイスにダウンロードし、そのライセンスを使用してテストを行う必要があります。

<span id="receipts" />

### <a name="receipts-for-in-app-purchases"></a>アプリ内購入の受領通知

**Windows.Services.Store** 名前空間には、購入が成功した場合の取引の受領通知をアプリのコードで取得する際に使用できる API が用意されていません。 これは、**Windows.ApplicationModel.Store** 名前空間を使用するアプリの場合とは異なります。このようなアプリでは、[クライアント側の API を使用して、取引の受領通知を取得する](use-receipts-to-verify-product-purchases.md)ことができます。

**Windows.Services.Store** 名前空間を使ってアプリ内購入を実装しているとき、特定のユーザーがアプリまたはアドオンを購入したかどうかを確認する必要がある場合は、[Microsoft Store コレクション REST API](view-and-grant-products-from-a-service.md) の[製品の照会メソッド](query-for-products.md)を使用できます。 このメソッドで返されるデータによって、指定されたユーザーが特定の製品に対する資格を持っているかどうかを確認し、ユーザーが購入した製品の取引に関するデータを取得することができます。 Microsoft Store コレクション API では、Azure AD Authentication を使ってこの情報を取得します。

<span id="desktop" />

### <a name="using-the-storecontext-class-with-the-desktop-bridge"></a>デスクトップ ブリッジでの StoreContext クラスの使用

[デスクトップ ブリッジ](https://developer.microsoft.com/windows/bridges/desktop)を使用するデスクトップ アプリケーションでは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスを使用してアプリ内購入と試用版を実装できます。 ただし、Win32 デスクトップ アプリケーション、またはレンダリング フレームワーク (WPF アプリケーションなど) に関連付けられているウィンドウ ハンドル (HWND) を含んだデスクトップ アプリケーションがある場合、アプリケーションでは、オブジェクトによって表示されるモーダル ダイアログのオーナー ウィンドウとなるアプリケーション ウィンドウを指定するように、**StoreContext** オブジェクトを構成する必要があります。

多くの **StoreContext** メンバー (および **StoreContext** オブジェクトを介してアクセスされる他の関連する型のメンバー) では、製品購入などのストアに関連する操作を行うために、モーダル ダイアログがユーザーに表示されます。 デスクトップ アプリケーションで、モーダル ダイアログのオーナー ウィンドウを指定するように **StoreContext** オブジェクトが構成されていない場合、このオブジェクトは不正確なデータまたはエラーを返します。

デスクトップ ブリッジを使用するデスクトップ アプリケーションで **StoreContext** オブジェクトを構成するには、次の手順を実行します。

1. 次のいずれかを実行して、アプリで [IInitializeWithWindow](https://msdn.microsoft.com/library/windows/desktop/hh706981.aspx) インターフェイスにアクセスできるようにします。

    * アプリケーションが C# や Visual Basic などのマネージ言語で記述されている場合、次の C# の例に示すように、アプリのコードで [ComImport](https://msdn.microsoft.com/library/system.runtime.interopservices.comimportattribute.aspx) 属性を使用して、**IInitializeWithWindow** インターフェイスを宣言します。 この例では、コード ファイルに **System.Runtime.InteropServices** 名前空間の **using** ステートメントが指定されていることを前提としています。

        ```csharp
        [ComImport]
        [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface IInitializeWithWindow
        {
            void Initialize(IntPtr hwnd);
        }
        ```

    * アプリケーションが C++ で記述されている場合、コードに shobjidl.h ヘッダー ファイルへの参照を追加します。 このヘッダー ファイルには、**IInitializeWithWindow** インターフェイスの宣言が含まれています。

2. この記事で既に説明したように、[GetDefault](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getdefault) メソッド ([マルチ ユーザー アプリ](../xbox-apps/multi-user-applications.md)の場合は [GetForUser](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getforuser) メソッド) を使用して、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを取得します。次に、このオブジェクトを [IInitializeWithWindow](https://msdn.microsoft.com/library/windows/desktop/hh706981.aspx) オブジェクトにキャストします。 その後で、[IInitializeWithWindow.Initialize](https://msdn.microsoft.com/library/windows/desktop/hh706982.aspx) メソッドを呼び出し、**StoreContext** メソッドによって表示されるモーダル ダイアログのオーナーにするウィンドウのハンドルを渡します。 次の C# の例は、アプリのメイン ウィンドウのハンドルをメソッドに渡す方法を示しています。
    ```csharp
    StoreContext context = StoreContext.GetDefault();
    IInitializeWithWindow initWindow = (IInitializeWithWindow)(object)context;
    initWindow.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
    ```

<span id="products-skus" />

### <a name="products-skus-and-availabilities"></a>製品、SKU、および可用性

ストア内のすべての製品には少なくとも 1 つの *SKU* があり、各 SKU ごとに少なくとも 1 つの*可用性*があります。 これらの概念はパートナー センターで、ほとんどの開発者から抽象化し、Sku や可用性アプリまたはアドオンのほとんどの開発者が定義されることはありません。 ただし、**Windows.Services.Store** 名前空間のストア製品のオブジェクト モデルには SKU と可用性が含まれているため、シナリオによっては、これらの概念の基本的な知識があると役に立つことがあります。

| オブジェクト |  説明  |
|---------|-------------------|
| 製品  |  *製品*は、アプリやアドオンなど、ストアで利用できるすべての製品の種類を指します。 <p/><p/> ストアの各製品には対応する [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトがあります。 このクラスには、製品のストア ID、ストア登録情報の画像と動画、価格情報などのデータにアクセスするために使用できるプロパティが用意されています。 また、製品を購入するために使用できるメソッドも提供されます。 |
| SKU |  *SKU* によって、独自の説明や価格など、製品固有の詳細情報に基づいて特定のバージョンの製品が示されます。 各アプリまたはアドオンには既定の SKU があります。 ほとんどの開発者は、アプリの通常版と試用版を公開している場合を除いて (ストア カタログでは、通常版と試用版は同じアプリの別の SKU になります)、1 つのアプリに複数の SKU を用意することはありません。 <p/><p/> 一部の発行元は、独自の SKU を定義することができます。 たとえば、大規模なゲームの発行元の場合、赤い血が許可されない市場では緑の血が表示される SKU でゲームをリリースし、それ以外のすべての市場では赤い血が表示される別の SKU でゲームをリリースすることがあります。 または、デジタル ビデオ コンテンツを販売している発行元が、1 つのビデオに対して、高解像度版の SKU と通常解像度版の SKU という、2 つの SKU を公開する場合もあります。 <p/><p/> ストアの各 SKU には対応する [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) オブジェクトがあります。 すべての [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) には、製品の SKU にアクセスするために使用できる [Skus](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.skus) プロパティがあります。 |
| 可用性  |  *可用性*によって、固有の価格情報に基づいて特定のバージョンの SKU が示されます。 各 SKU には、既定の可用性があります。 一部の発行元は独自の可用性を定義でき、特定の SKU にさまざまな価格オプションを導入できます。 <p/><p/> ストアの各可用性には対応する [StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) オブジェクトがあります。 すべての [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) には、SKU の可用性にアクセスするために使用できる [Availabilities](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.availabilities) プロパティがあります。 ほとんどの開発者の場合、SKU ごとに 1 つの既定の可用性があります。  |

<span id="store_ids" />

### <a name="store-ids"></a>ストア ID

アプリやアドオンなど、ストアのすべての製品には関連付けられた**ストア ID** があります (これは*製品ストア ID* と呼ばれることもあります)。 多くの API は、アプリまたはアドオンで操作を実行するためにストア ID を必要とします。

ストア内の製品のストア ID は 12 文字の英数字文字列です。たとえば、```9NBLGGH4R315``` のようになります。 ストア内の製品のストア ID は、次のようにさまざまな方法で取得できます。

* パートナー センターで、アプリの[アプリ id] ページ](../publish/view-app-identity-details.md)で、ストア ID を取得できます。
* アドオンの場合、追加の概要ページでは、パートナー センターのストア ID を取得できます。
* 製品の場合、その製品を表す [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトの [StoreId](https://docs.microsoft.com/uwp/api/windows.services.store.storeproduct.storeid) プロパティを使用するにより、ストア ID をプログラムで取得することもできます。

製品の SKU と可用性の場合は、その SKU と可用性にも形式の異なる固有のストア ID が用意されています。

| オブジェクト |  ストア ID の形式  |
|---------|-------------------|
| SKU |  SKU の場合、ストア ID の形式は ```<product Store ID>/xxxx``` のようになります。ここで、```xxxx``` は製品の SKU を識別する 4 文字の英数字文字列です。 たとえば、```9NBLGGH4R315/000N``` と記述します。 この ID は、[StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) オブジェクトの [StoreId](https://docs.microsoft.com/uwp/api/windows.services.store.storesku.storeid) プロパティによって返され、*SKU ストア ID* と呼ばれることもあります。 |
| 可用性  |  可用性の場合、ストア ID の形式は ```<product Store ID>/xxxx/yyyyyyyyyyyy``` のようになります。ここで、```xxxx``` は製品の SKU を識別する 4 文字の英数字文字列で、```yyyyyyyyyyyy``` は SKU の可用性を識別する 12 文字の英数字文字列です。 たとえば、```9NBLGGH4R315/000N/4KW6QZD2VN6X``` と記述します。 この ID は、[StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) オブジェクトの [StoreId](https://docs.microsoft.com/uwp/api/windows.services.store.storeavailability.storeid) プロパティによって返され、*可用性ストア ID* と呼ばれることもあります。  |

<span id="product-ids" />

## <a name="how-to-use-product-ids-for-add-ons-in-your-code"></a>コードでアドオンの製品 ID を使用する方法

アプリのコンテキストでユーザーにアドオンを利用できるようにする場合は、する必要があります[一意の製品 ID を入力して](../publish/set-your-add-on-product-id.md#product-id)アドオンのとパートナー センターでの[アドオンの申請を作成](../publish/add-on-submissions.md)します。 この製品 ID を使用することでコード内でアドオンを参照できます。ただし、製品 ID を使用できる特定のシナリオは、アプリのアプリ内購入に使用する名前空間によって異なります。

> [!NOTE]
> パートナー センターでアドオン用に入力する製品 ID とは異なります、追加の[ストア ID です](#store-ids)。 ストア ID は、パートナー センターによって生成されます。

### <a name="apps-that-use-the-windowsservicesstore-namespace"></a>Windows.Services.Store 名前空間を使うアプリ

アプリで **Windows.Services.Store** 名前空間を使用している場合、製品 ID を使用することで、アドオンを表す [StoreProduct](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct) や、アドオンのライセンスを表す [StoreLicense](https://docs.microsoft.com/uwp/api/windows.services.store.storelicense) を簡単に識別できます。 製品 ID は、[StoreProduct.InAppOfferToken](https://docs.microsoft.com/uwp/api/Windows.Services.Store.StoreProduct.InAppOfferToken) プロパティおよび [StoreLicense.InAppOfferToken](https://docs.microsoft.com/uwp/api/windows.services.store.storelicense.InAppOfferToken) プロパティにより公開されます。

> [!NOTE]
> 製品 ID はコードでアドオンを識別する便利な方法ですが、**Windows.Services.Store** 名前空間のほとんどの操作では、製品 ID の代わりにアドオンの[ストア ID](#store-ids) を使用します。 たとえば、アプリの 1 つ以上の既知のアドオンをプログラムで取得するには、アドオンの (製品 ID ではなく) ストア ID を [GetStoreProductsAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.getstoreproductsasync) メソッドに渡します。 同様に、コンシューマブルなアドオンをフルフィルメント完了として報告するには、アドオンの (製品 ID ではなく) ストア ID を [ReportConsumableFulfillmentAsync](https://docs.microsoft.com/uwp/api/windows.services.store.storecontext.reportconsumablefulfillmentasync) メソッドに渡します。

### <a name="apps-that-use-the-windowsapplicationmodelstore-namespace"></a>Windows.ApplicationModel.Store 名前空間を使うアプリ

アプリは、 **Windows.ApplicationModel.Store**名前空間を使用している場合は、ほとんどの操作には、パートナー センターでアドオンに割り当てた製品 ID を使用する必要があります。 例:

* アドオンを表す [ProductListing](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting) や、アドオンのライセンスを表す [ProductLicense](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlicense) を識別するには、製品 ID を使用します。 製品 ID は、[ProductListing.ProductId](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlisting.ProductId) プロパティおよび [ProductLicense.ProductId](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.productlicense.ProductId) プロパティにより公開されます。

* ユーザーのアドオンを購入する場合は [RequestProductPurchaseAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.requestproductpurchaseasync) メソッドを使用して製品 ID を指定します。 詳しくは、「[アプリ内製品購入の有効化](enable-in-app-product-purchases.md)」をご覧ください。

* コンシューマブルなアドオンをフルフィルメント完了として報告する場合は [ReportConsumableFulfillmentAsync](https://docs.microsoft.com/uwp/api/windows.applicationmodel.store.currentapp.reportconsumablefulfillmentasync) メソッドを使用して製品 ID を指定します。 詳しくは、「[コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)」をご覧ください。

## <a name="related-topics"></a>関連トピック

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリのサブスクリプション アドオンの有効化](enable-subscription-add-ons-for-your-app.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [Microsoft Store の操作のエラー コード](error-codes-for-store-operations.md)
* [Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)
