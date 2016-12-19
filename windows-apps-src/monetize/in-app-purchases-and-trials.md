---
author: mcleanbyron
ms.assetid: F45E6F35-BC18-45C8-A8A5-193D528E2A4E
description: "UWP アプリのアプリ内購入と試用版を有効にする方法を説明します。"
title: "アプリ内購入と試用版"
translationtype: Human Translation
ms.sourcegitcommit: ffda100344b1264c18b93f096d8061570dd8edee
ms.openlocfilehash: 7783b6017a314ddb24509c55db8134a4c214430f

---

# <a name="in-app-purchases-and-trials"></a>アプリ内購入と試用版

Windows SDK に用意されている API を使用して、以下の機能を実装し、ユニバーサル Windows プラットフォーム (UWP) アプリによる収益を向上させることができます。

* **アプリ内購入**&nbsp;&nbsp; アプリが無料であるかどうかにかかわらず、コンテンツやアプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。

* **試用版機能**&nbsp;&nbsp;アプリを [Windows デベロッパー センター ダッシュボードで無料試用版](../publish/set-app-pricing-and-availability.md#free-trial)として構成した場合、試用期間中に一部の機能を除外または制限することによって、アプリの通常版を購入するようユーザーを促すことができます。 また、ユーザーがアプリを購入する前の試用期間中にだけバナーや透かしなどを表示する機能を有効にすることもできます。

この記事では、UWP アプリでのアプリ内購入と試用版のしくみについて、その概要を説明します。

<span id="choose-namespace" />
## <a name="choose-which-namespace-to-use"></a>使用する名前空間を選ぶ

UWP アプリにアプリ内購入機能や試用版機能を追加する際に使用できる名前空間は、2 つあります。どちらの名前空間を使用するかは、アプリのターゲットとなる Windows 10 のバージョンによって決まります。 これらの名前空間の API は同じ目的を果たしますが、その設計は大きく異なります。また、この 2 つの API 間にコードの互換性はありません。

* **[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx)**&nbsp;&nbsp;Windows 10 バージョン 1607 以降の場合、アプリはこの名前空間の API を使用して、アプリ内購入および試用版を実装することができます。 アプリのターゲットが Windows 10 バージョン 1607 以降である場合は、この名前空間のメンバーを使用することをお勧めします。 この名前空間は、ストアで管理されるコンシューマブルなアドオンなど、最新の種類のアドオンをサポートしており、Windows デベロッパー センターとストアで今後サポートされる製品および機能の種類と互換性を持つように設計されています。 この名前空間について詳しくは、この記事の「[Windows.Services.Store 名前空間の使用](#api_intro)」をご覧ください。

* **[Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx)**&nbsp;&nbsp;Windows 10 のすべてのバージョンでは、この名前空間にあるアプリ内購入と試用版向けの以前の API がサポートされています。 Windows 10 用 UWP アプリではこの名前空間を使用できますが、今後デベロッパー センターやストアでは、この名前空間は新しい種類の製品や機能をサポートするように更新されない可能性があります。 この名前空間について詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

<span id="concepts" />
## <a name="basic-concepts"></a>基本的な概念

このセクションでは、UWP アプリでのアプリ内購入と試用版に関する基本的な概念について説明します。 その概念のほとんどは、特に記載がない限り、**Windows.Services.Store** 名前空間と **Windows.ApplicationModel.Store** 名前空間の両方に適用されます。

ストアで提供されるアイテムはすべて、通常、*製品*と呼ばれます。 ほとんどの開発者が扱う製品の種類は、*アプリ*と*アドオン* (アプリ内製品または IAP とも呼ばれます) です。

アドオンとは、ユーザーがアプリのコンテキストで利用できる製品や機能のことを指します。 アプリでユーザーに提供する機能であればどのようなものでもアドオンに相当する可能性があります。たとえば、アプリやゲームで使用される通貨、ゲームの新しい地図や武器、広告を表示せずにアプリを使用できる機能などに加え、音楽やビデオなどのデジタル コンテンツを提供できるアプリなら、そのようなコンテンツのことも表します。 すべてのアプリとアドオンは、そのアプリやアドオンを使用する権利がユーザーにあるかどうかを示す関連付けられたライセンスを備えます。 アプリまたはアドオンを試用版として使用する権利がユーザーにある場合は、その試用版に関する追加情報もライセンスによって提供されます。

アプリでユーザーにアドオンを提供するには、[デベロッパー センター ダッシュボードでアプリのアドオンを定義します](../publish/iap-submissions.md)。これにより、そのアドオンがストアで認識されます。 その後で、アプリで **Windows.Services.Store** または **Windows.ApplicationModel.Store** 名前空間の API を使用して、アプリ内購入としてユーザーに販売するアドオンを提供することができます。

UWP アプリでは、次の種類のアドオンを提供できます。

| アドオンの種類 |  説明  |
|---------|-------------------|
| 永続的  |  [Windows デベロッパー センター ダッシュボード](../publish/enter-iap-properties.md)で指定した有効期間のあいだ保持されるアドオンです。 <p/><p/>既定では、永続的なアドオンの有効期限が切れることはありません。この場合、アドオンは 1 回のみ購入することができます。 アドオンで特定の期間を指定している場合、期限が切れた後、ユーザーはアドオンを再購入できます。 |
| 開発者により管理されるコンシューマブル  |  購入し、使用した後に再購入できるアドオンです。 この種類のアドオンは、多くの場合、アプリ内通貨に使用されます。 <p/><p/>この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量を追跡し、ユーザーによってすべてのアイテムが消費されたらアドオンの購入をフルフィルメント完了としてストアに報告する義務が開発者にあります。 以前のアドオン購入をフルフィルメント完了としてアプリで報告するまで、ユーザーがそのアドオンを再購入することはできません。 <p/><p/>たとえば、アドオンがゲーム内の 100 コインを表しており、ユーザーによって 10 コインが消費されている場合、アプリまたはサービスでは、ユーザーの 90 コインの残高を保持する必要があります。 ユーザーによって 100 コインすべてが消費されたら、アプリでそのアドオンをフルフィルメント完了として報告する必要があります。その後、ユーザーは 100 コイン アドオンを再購入できます。    |
| ストアで管理されるコンシューマブル  |  購入し、使用した後に再購入できるアドオンです。 この種類のアドオンは、多くの場合、アプリ内通貨に使用されます。<p/><p/>この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量はストアで追跡します。 ユーザーによりアイテムが消費されたら、そのアイテムをフルフィルメント完了としてストアに報告する義務が開発者にあり、ストアによってユーザーの残量が更新されます。 アプリでは、ユーザーのアイテムの現在の残量をいつでも照会できます。 ユーザーは、すべてのアイテムを消費したら、そのアドオンを再購入できます。  <p/><p/> たとえば、アドオンがゲーム内の 100 のコインの初期量を表しており、ユーザーによって 10 コインが消費された場合、そのアドオンの 10 ユニットがフルフィルメント完了したことをアプリでストアに報告すると、ストアにより残高が更新されます。 ユーザーは、100 コインすべてを消費した後、その 100 コインのアドオンを再購入できます。 <p/><p/>**注**&nbsp;&nbsp;ストアで管理されるコンシューマブルは Windows 10 バージョン 1607 以降で利用できます。 ストアで管理されるコンシューマブルを使用するには、アプリは Windows 10 バージョン 1607 以降をターゲットとし、**Windows.ApplicationModel.Store** 名前空間ではなく、**Windows.Services.Store** 名前空間の API を使用する必要があります。  |

<span />

>**注**&nbsp;&nbsp;パッケージで使用される永続的なアドオン (ダウンロード コンテンツまたは DLC とも呼ばれます) など、他の種類のアドオンが利用できるのは一部の開発者に限られており、このドキュメントでは説明しません。

<span id="api_intro" />
## <a name="using-the-windowsservicesstore-namespace"></a>Windows.Services.Store 名前空間の使用

この記事の残りの部分では、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使用してアプリ内購入と試用版を実装する方法について説明します。 この名前空間は Windows 10 バージョン 1607 以降をターゲットにしているアプリでのみ使用できます。可能であれば、このようなアプリでは [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間の代わりに、この Windows.Services.Store 名前空間を使用することをお勧めします。

**Windows.ApplicationModel.Store** 名前空間については、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

### <a name="get-started-with-the-storecontext-class"></a>StoreContext クラスの概要

**Windows.Services.Store** 名前空間のメイン エントリ ポイントは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスです。 このクラスには、現在のアプリとその利用可能なアドオンに関する情報の取得、現在のアプリまたはそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリまたはアドオンの購入、およびその他のタスクを行う際に使用できるメソッドが用意されています。 [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを取得するには、次のいずれかを実行します。

* シングル ユーザー アプリ (アプリを起動したユーザーのコンテキストのみで実行されるアプリ) では、[GetDefault](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getdefault.aspx) メソッドを使用して、**StoreContext** オブジェクトを取得します。このオブジェクトを使用すると、ユーザーの Windows ストア関連データへのアクセスおよび管理が可能になります。 ほとんどのユニバーサル Windows プラットフォーム アプリ (UWP) アプリはシングル ユーザー アプリです。

  > [!div class="tabbedCodeSnippets"]
  ```csharp
  Windows.Services.Store.StoreContext context = StoreContext.GetDefault();
  ```

* [マルチ ユーザー アプリ](../xbox-apps/multi-user-applications.md)では、[GetForUser](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getforuser.aspx) メソッドを使用して **StoreContext** オブジェクトを取得します。このオブジェクトを使用すると、アプリの使用中に Microsoft アカウントでサインインした特定のユーザーに関する Windows ストア関連のデータのアクセスや管理を行うことができます。 次の例は、利用可能な最初のユーザーの **StoreContext** オブジェクトを取得します。

  > [!div class="tabbedCodeSnippets"]
  ```csharp
  var users = await Windows.System.User.FindAllAsync();
  Windows.Services.Store.StoreContext context = StoreContext.GetForUser(users[0]);
  ```

>**注**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使用する Windows デスクトップ アプリケーションでは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを使用する前に、追加の手順を実行してこのオブジェクトを構成する必要があります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](#desktop)」をご覧ください。

[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成すると、メソッドを呼び出して、現在のアプリやアドオンに関するストア製品情報の取得、現在のアプリとそのアドオンに関するライセンス情報の取得、現在のユーザー向けのアプリやアドオンの購入、およびその他のタスクを実行できます。 この名前空間を使用して実行できる一般的なタスクについて詳しくは、次の記事をご覧ください。

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)

**Windows.Services.Store** 名前空間の使用方法を示すサンプル アプリについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

<span id="implement-iap" />
### <a name="implement-in-app-purchases"></a>アプリ内購入の実装

**Windows.Services.Store** 名前空間を使用して、アプリでアプリ内購入をユーザーに提供するには:

1. ユーザーが購入できるアドオンをアプリで提供する場合、[デベロッパー センター ダッシュ ボードで、アプリに関するアドオンの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/add-on-submissions)します。

2. [アプリで提供されるアプリやアドオンの製品情報を取得](get-product-info-for-apps-and-add-ons.md)してから、[ライセンスがアクティブになっているかどうかを判断](get-license-info-for-apps-and-add-ons.md)する (つまり、アプリやアドオンを使用するためのライセンスをユーザーが所有しているかどうかを判断する) ようにアプリのコードを記述します。 ライセンスがアクティブになっていない場合、ユーザーに販売するためのアプリやアドオンをアプリ内購入として提供する UI を表示します。

3. ユーザーがアプリやアドオンの購入を選んだ場合、製品を購入するための適切なメソッドを使用します。 ユーザーがアプリや永続的なアドオンを購入する場合は、「[アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)」のプロセスに従ってください。 ユーザーがコンシューマブルなアドオンを購入する場合は、「[コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)」指示に従ってください。

4. この記事に記載されている[テスト ガイダンス](#testing)に従って、実装をテストします。

<span id="implement-trial" />
### <a name="implement-trial-functionality"></a>試用版機能の実装

**Windows.Services.Store** 名前空間を使用して、アプリの試用版の機能を除外または制限するには:

1. [Windows デベロッパー センター ダッシュ ボードで、アプリを無料試用版として構成します](../publish/set-app-pricing-and-availability.md#free-trial)。

2. [アプリで提供されるアプリやアドオンの製品情報を取得](get-product-info-for-apps-and-add-ons.md)してから、[アプリに関連付けられているライセンスが試用版ライセンスになっているかどうかを判断](get-license-info-for-apps-and-add-ons.md)するようにアプリのコードを記述します。

3. 試用版である場合は、アプリの特定の機能を除外または制限します。ユーザーが完全なライセンスを購入した場合は、その機能を有効にします。 詳しくは、「[アプリの試用版の実装](implement-a-trial-version-of-your-app.md)」をご覧ください。

4. この記事に記載されている[テスト ガイダンス](#testing)に従って、実装をテストします。

<span id="testing" />
### <a name="test-your-implementation"></a>実装のテスト

**Windows.Services.Store** 名前空間には、テスト中にライセンス情報をシミュレートするために使用できるクラスが用意されていません。 代わりに、アプリをストアに公開し、そのアプリを開発用デバイスにダウンロードして、そのライセンスをテストに使用する必要があります。 この方法は、**Windows.ApplicationModel.Store** 名前空間を使用するアプリの場合とは異なります。このようなアプリでは、[CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスを使用して、テスト中にライセンス情報をシミュレートできます。

アプリで **Windows.Services.Store** 名前空間の API を使用してアプリとアドオンの情報にアクセスする場合は、次のプロセスに従ってコードをテストします。

1. アプリがまだ公開されておらず、ストアで利用できない場合、アプリが [Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最低限の要件を満たしていることを確認し、Windows デベロッパー センター ダッシュボードに[そのアプリを申請](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)します。その後で、アプリが認定プロセスに合格し、ストアに掲載されることを確認します。 必要に応じて、[ストアでアプリを非表示にする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability)ことができます。これにより、テスト中はユーザーがアプリを利用できなくなります。

2. 次に、以下の操作が完了していることを確認します。

  * [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラス、および **Windows.Services.Store** 名前空間にある他の関連する型を使用するアプリのコードを、[アプリ内購入](#implement-iap)や[試用版機能](#implement-trial)を実装するように記述します。

  * ユーザーが購入できるアドオンをアプリで提供する場合、[デベロッパー センター ダッシュ ボードで、アプリに関するアドオンの申請を作成](https://msdn.microsoft.com/windows/uwp/publish/add-on-submissions)します。

  * アプリの試用版で一部の機能を除外または制限する場合は、[Windows デベロッパー センター ダッシュ ボードで、アプリを無料試用版として構成します](../publish/set-app-pricing-and-availability.md#free-trial)。

3. プロジェクトを Visual Studio で開き、**[プロジェクト]** メニューをクリックし、**[ストア]** をポイントして、**[アプリケーションをストアと関連付ける]** をクリックします。 ウィザードの手順を完了し、テストに使用する Windows デベロッパー センター アカウントのアプリとアプリ プロジェクトを関連付けます。

  >**注**&nbsp;&nbsp;プロジェクトとストアのアプリを関連付けていない場合、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) メソッドにより、戻り値の **ExtendedError** プロパティがエラー コード値 0x803F6107 に設定されます。 この値は、ストアにそのアプリに関する情報がないことを示します。

4. まだ前の手順で指定したストアのアプリをインストールしていない場合は、アプリをインストールし、アプリを一度実行してから閉じます。 これにより、アプリの有効なライセンスが開発用デバイスにインストールされます。

5. Visual Studio で、プロジェクトの実行またはデバッグを開始します。 コードによって、ローカルのプロジェクトと関連付けたストア アプリからアプリおよびアドオンのデータが取得されます。 アプリを再インストールするように求められた場合は、その指示に従った後、プロジェクトを実行またはデバッグします。

<span id="receipts" />
### <a name="receipts-for-in-app-purchases"></a>アプリ内購入の受領通知

**Windows.Services.Store** 名前空間には、購入が成功した場合の取引の受領通知をアプリのコードで取得する際に使用できる API が用意されていません。 これは、**Windows.ApplicationModel.Store** 名前空間を使用するアプリの場合とは異なります。このようなアプリでは、[クライアント側の API を使用して、取引の受領通知を取得する](use-receipts-to-verify-product-purchases.md)ことができます。

**Windows.Services.Store** 名前空間を使用してアプリ内購入を実装し、特定のユーザーがアプリまたはアドオンを購入したかどうかを確認する必要がある場合は、[Windows ストア コレクション REST API](view-and-grant-products-from-a-service.md) の[製品を照会するためのメソッド](query-for-products.md)を使用できます。 このメソッドで返されるデータによって、指定されたユーザーが特定の製品に対する資格を持っているかどうかを確認し、ユーザーが購入した製品の取引に関するデータを取得することができます。 Windows ストア コレクション API では、Azure AD Authentication を使用してこの情報を取得します。

<span id="desktop" />
### <a name="using-the-storecontext-class-in-an-app-that-uses-the-desktop-bridge"></a>Desktop Bridge を使用するアプリでの StoreContext クラスの使用

[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使用するデスクトップ アプリケーションでは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスを使用してアプリ内購入と試用版を実装できます。 ただし、Win32 デスクトップ アプリケーション、またはレンダリング フレームワーク (WPF アプリケーションなど) に関連付けられているウィンドウ ハンドル (HWND) を含んだデスクトップ アプリケーションがある場合、アプリケーションでは、オブジェクトによって表示されるモーダル ダイアログのオーナー ウィンドウとなるアプリケーション ウィンドウを指定するように、**StoreContext** オブジェクトを構成する必要があります。

多くの **StoreContext** メンバー (および **StoreContext** オブジェクトを介してアクセスされる他の関連する型のメンバー) では、製品購入などのストアに関連する操作を行うために、モーダル ダイアログがユーザーに表示されます。 デスクトップ アプリケーションで、モーダル ダイアログのオーナー ウィンドウを指定するように **StoreContext** オブジェクトが構成されていない場合、このオブジェクトは不正確なデータまたはエラーを返します。

Desktop Bridge を使用するデスクトップ アプリケーションで **StoreContext** オブジェクトを構成するには、次の手順を実行します。

  1. アプリケーションが C# や Visual Basic などのマネージ言語で記述されている場合、次の例に示すように、アプリのコードで [ComImport](https://msdn.microsoft.com/library/system.runtime.interopservices.comimportattribute.aspx) 属性を使用して、[IInitializeWithWindow](https://msdn.microsoft.com/library/windows/desktop/hh706981.aspx) インターフェイスを宣言します。 この例では、コード ファイルに **System.Runtime.InteropServices** 名前空間の **using** ステートメントが指定されていることを前提としています。

    > [!div class="tabbedCodeSnippets"]
    ```csharp
    [ComImport]
    [Guid("3E68D4BD-7135-4D10-8018-9FB6D9F33FA1")]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    public interface IInitializeWithWindow
    {
        void Initialize(IntPtr hwnd);
    }
    ```

    アプリケーションが C++ などのネイティブ コードで記述されている場合は、**IInitializeWithWindow** インターフェイスをインポートする必要はありません。 コードに、shobjidl.h ヘッダー ファイルへの参照を追加するだけです。

  2. この記事で既に説明したように、[GetDefault](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getdefault.aspx) (または [GetForUser](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getforuser.aspx)) メソッドを使用して、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを取得します。次に、このオブジェクトを [IInitializeWithWindow](https://msdn.microsoft.com/library/windows/desktop/hh706981.aspx) オブジェクトにキャストします。 その後で、[Initialize](https://msdn.microsoft.com/library/windows/desktop/hh706982.aspx) メソッドを呼び出し、**StoreContext** メソッドによって表示されるモーダル ダイアログのオーナーにするウィンドウのハンドルを渡します。 次の例は、アプリのメイン ウィンドウのハンドルをメソッドに渡す方法を示しています。

    > [!div class="tabbedCodeSnippets"]
    ```csharp
    StoreContext context = StoreContext.GetDefault();
    IInitializeWithWindow initWindow = (IInitializeWithWindow)(object)context;
    initWindow.Initialize(System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle);
    ```

<span id="products-skus" />
### <a name="products-skus-and-availabilities"></a>製品、SKU、および可用性

ストア内のすべての製品には少なくとも 1 つの *SKU* があり、各 SKU ごとに少なくとも 1 つの*可用性*があります。 Windows デベロッパー センター ダッシュボードでは、ほとんどの場合、これらの概念は開発者から抽象化されており、多くの開発者はアプリまたはアドオンの SKU や可用性を定義することはありません。 ただし、**Windows.Services.Store** 名前空間のストア製品のオブジェクト モデルには SKU と可用性が含まれているため、これらの概念の基本的な知識があると役に立つことがあります。

| オブジェクトの種類 |  説明  |
|---------|-------------------|
| [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx)  |  このクラスは、アプリやアドオンなど、ストアで利用できるすべての製品の種類を表します。 このクラスには、製品のストア ID、ストア登録情報の画像と動画、価格情報などのデータにアクセスするために使用できるプロパティが用意されています。 また、製品を購入するために使用できるメソッドも提供されます。 |
| [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) |  このクラスは、製品の *SKU* を表します。 SKU によって、独自の説明や価格など、製品固有の詳細情報に基づいて特定のバージョンの製品が示されます。 各アプリまたはアドオンには既定の SKU があります。 ほとんどの開発者は、アプリの通常版と試用版を公開している場合を除いて (ストア カタログでは、通常版と試用版は同じアプリの別の SKU になります)、1 つのアプリに複数の SKU を用意することはありません。 <p/><p/> 一部の発行元は、独自の SKU を定義することができます。 たとえば、大規模なゲームの発行元の場合、赤い血が許可されない市場では緑の血が表示される SKU でゲームをリリースし、それ以外のすべての市場では赤い血が表示される別の SKU でゲームをリリースすることがあります。 または、デジタル ビデオ コンテンツを販売している発行元が、1 つのビデオに対して、高解像度版の SKU と通常解像度版の SKU という、2 つの SKU を公開する場合もあります。 <p/><p/> 各製品には、SKU にアクセスするために使用できる [Skus](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.skus.aspx) プロパティがあります。 |
| [StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx)  |  このクラスは、SKU の*可用性*を表します。 可用性によって、固有の価格情報に基づいて特定のバージョンの SKU が示されます。 各 SKU には、既定の可用性があります。 一部の発行元は独自の可用性を定義でき、特定の SKU にさまざまな価格オプションを導入できます。 <p/><p/> 各 SKU には、可用性にアクセスするために使用できる [Availabilities](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.availabilities.aspx) プロパティがあります。 ほとんどの開発者の場合、SKU ごとに 1 つの既定の可用性があります。  |

<span id="store_ids" />
### <a name="store-ids"></a>ストア ID

ストアのアプリとアドオンにはすべて、関連付けられた**ストア ID** があります。 **Windows.Services.Store** 名前空間の API の多くは、アプリまたはアドオンで操作を実行するためにストア ID を必要とします。 製品、SKU、および可用性のストア ID の形式はそれぞれ異なります。

| オブジェクトの種類 |  ストア ID の形式  |
|---------|-------------------|
| [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx)  |  ストア内の製品のストア ID は 12 文字の英数字文字列です。たとえば、```9NBLGGH4R315``` のようになります。 このストア ID は、アプリまたはアドオンの Windows デベロッパー センター ダッシュボード ページで利用でき、[StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトの [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.storeid.aspx) プロパティによって返されます。 この ID は、*製品ストア ID* と呼ばれることもあります。 |
| [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) |  SKU の場合、ストア ID の形式は ```<product Store ID>/xxxx``` のようになります。ここで、```xxxx``` は製品の SKU を識別する 4 文字の英数字文字列です。 たとえば、```9NBLGGH4R315/000N``` と記述します。 この ID は、[StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) オブジェクトの [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.storeid.aspx) プロパティによって返され、*SKU ストア ID* と呼ばれることもあります。 |
| [StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx)  |  可用性の場合、ストア ID の形式は ```<product Store ID>/xxxx/yyyyyyyyyyyy``` のようになります。ここで、```xxxx``` は製品の SKU を識別する 4 文字の英数字文字列で、```yyyyyyyyyyyy``` は SKU の可用性を識別する 12 文字の英数字文字列です。 たとえば、```9NBLGGH4R315/000N/4KW6QZD2VN6X``` と記述します。 この ID は、[StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) オブジェクトの [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.storeid.aspx) プロパティによって返され、*可用性ストア ID* と呼ばれることもあります。  |

## <a name="related-topics"></a>関連トピック

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)



<!--HONumber=Dec16_HO1-->


