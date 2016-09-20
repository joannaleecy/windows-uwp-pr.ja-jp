---
author: mcleanbyron
ms.assetid: F45E6F35-BC18-45C8-A8A5-193D528E2A4E
description: "UWP アプリのアプリ内購入と試用版を有効にする方法を説明します。"
title: "アプリ内購入と試用版"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 99143d48a5f2155b0a47008574d0a78243dea925

---

# アプリ内購入と試用版

Windows SDK に用意されている API を使して、ユニバーサル Windows プラットフォーム (UWP) アプリにアプリ内購入機能や試用版機能を追加し、アプリで収益を得たり、新しい機能を追加したりすることができます。 こうした API では、アプリのライセンス情報へのアクセスも提供されます。

このようなシナリオを対象に、Windows 10 には次のように 2 つの異なる API 群が用意されています。

* Windows 10 のすべてのバージョンで、アプリ内購入およびライセンス情報用の [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間の API がサポートされています。

* Windows 10 バージョン 1607 以降では、アプリ内購入およびライセンス情報用の [Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の代替 API が用意されています。  

これらの名前空間の API は同じ目的を果たしますが、その設計は大きく異なります。また、この 2 つの API 間にコードの互換性はありません。 アプリのターゲットが Windows 10 バージョン 1607 以降である場合は、**Windows.Services.Store** 空間を使用することをお勧めします。 この名前空間は、ストアで管理されるコンシューマブルなアドオンなど、最新の種類のアドオンをサポートしており、Windows デベロッパー センターとストアで今後サポートされる製品および機能の種類と互換性を持つように設計されています。 **Windows.Services.Store** 名前空間はパフォーマンスも向上しています。

この記事では、UWP アプリのアプリ内購入を紹介し、Windows 10 バージョン 1607 以降で利用できる **Windows.Services.Store** 名前空間の概要を示します。 **Windows.ApplicationModel.Store** 名前空間のメンバーの使用については、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。


## UWP アプリのアプリ内購入の概要

このセクションでは、ストアの UWP アプリでアプリ内購入と試用版が機能するしくみについて、中心となる概念を説明します。 その概念のほとんどは、**Windows.Services.Store** 名前空間と **Windows.ApplicationModel.Store** 名前空間の両方に適用されます。

ストアで提供されるアイテムはすべて、通常、*製品*と呼ばれます。 ほとんどの開発者が扱う製品の種類は、*アプリ*と*アドオン* (アプリ内製品または IAP とも呼ばれます) です。 アドオンとは、ユーザーがアプリのコンテキストで利用できる製品や機能のことを指します。 アプリでユーザーに提供する機能であればどのようなものでもアドオンに相当する可能性があります。たとえば、アプリやゲームで使用される通貨、ゲームの新しい地図や武器、広告を表示せずにアプリを使用できる機能などに加え、音楽やビデオなどのデジタル コンテンツを提供できるアプリなら、そのようなコンテンツのことも表します。

すべてのアプリとアドオンは、そのアプリやアドオンを使用する権利がユーザーにあるかどうかを示す関連付けられたライセンスを備えます。 アプリまたはアドオンを試用版として使用する権利がユーザーにある場合は、その試用版に関する追加情報もライセンスによって提供されます。

アプリでユーザーにアドオンを提供するにはまず、[デベロッパー センター ダッシュボードでアプリのアドオンを定義します](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)。 次に、アドオンが表す機能を使用するためのライセンスをユーザーが持っているかどうかを判別するアプリのコードと、ライセンスがない場合に、アドオンをアプリ内購入としてユーザーに販売するためのコードを記述します。 Windows 10 バージョン 1607 以降をターゲットにしているアプリで **Windows.Services.Store** 名前空間を使用する関連タスクを示した例については、次の記事をご覧ください。

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)

**Windows.ApplicationModel.Store** 名前空間を使用する関連タスクを示した例については、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」

すべての開発者が、次の種類のアドオンを作成できます。

| アドオンの種類 |  説明  |
|---------|-------------------|
| 永続的  |  [Windows デベロッパー センター ダッシュボード](https://msdn.microsoft.com/windows/uwp/publish/enter-iap-properties)で指定した有効期間のあいだ保持されるアドオンです。 <p/><p/>既定では、永続的なアドオンの有効期限が切れることはありません。この場合、アドオンは 1 回のみ購入することができます。 アドオンで特定の期間を指定している場合、期限が切れた後、ユーザーはアドオンを再購入できます。  |
| 開発者により管理されるコンシューマブル  |  購入し、使用した後に再購入できるアドオンです。 この種類のアドオンはアプリ内通貨に使用されるのが一般的です。 <p/><p/>この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量を追跡し、ユーザーによってすべてのアイテムが消費されたらアドオンの購入をフルフィルメント完了としてストアに報告する義務が開発者にあります。 以前のアドオン購入をフルフィルメント完了としてアプリで報告するまで、ユーザーがそのアドオンを再購入することはできません。 <p/><p/>たとえば、アドオンがゲーム内の 100 コインを表しており、ユーザーによって 10 コインが消費されている場合、アプリまたはサービスでは、ユーザーの 90 コインの残高を保持する必要があります。 ユーザーによって 100 コインすべてが消費されたら、アプリでそのアドオンをフルフィルメント完了として報告する必要があります。その後、ユーザーは 100 コイン アドオンを再購入できます。    |
| ストアで管理されるコンシューマブル  |  購入し、使用した後に再購入できるアドオンです。 この種類のアドオンはアプリ内通貨に使用されるのが一般的です。<p/><p/>この種類のコンシューマブルでは、アドオンが表すユーザーのアイテムの残量はストアで追跡します。 ユーザーによりアイテムが消費されたら、そのアイテムをフルフィルメント完了としてストアに報告する義務が開発者にあり、ストアによってユーザーの残量が更新されます。 アプリでは、ユーザーのアイテムの現在の残量をいつでも照会できます。 ユーザーは、すべてのアイテムを消費したら、そのアドオンを再購入できます。  <p/><p/> たとえば、アドオンがゲーム内の 100 のコインの初期量を表しており、ユーザーによって 10 コインが消費された場合、そのアドオンの 10 ユニットがフルフィルメント完了したことをアプリでストアに報告すると、ストアにより残高が更新されます。 ユーザーは、100 コインすべてを消費した後、その 100 コインのアドオンを再購入できます。 <p/><p/> **ストアで管理されるコンシューマブルは Windows 10 バージョン 1607 以降で利用できます。 Windows デベロッパー センター ダッシュボードでストアで管理されるコンシューマブルを作成する機能は、近日公開される予定です。**  |

<span />

>**注**&nbsp;&nbsp;パッケージで使用される永続的なアドオン (ダウンロード コンテンツまたは DLC とも呼ばれます) など、他の種類のアドオンが利用できるのは一部の開発者に限られており、このドキュメントでは説明しません。

<span id="api_intro" />
## Windows.Services.Store 名前空間の概要

**Windows.Services.Store** 名前空間のメイン エントリ ポイントは、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスです。 このクラスには、現在のアプリとその利用可能なアドオンに関する情報の取得、現在のユーザー向けのアプリまたはアドオンの購入、現在のアプリまたはそのアドオンに関するライセンス情報の取得などのタスクを行うために使えるメソッドが用意されています。 [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを取得するには、次のいずれかを実行します。

* シングル ユーザー アプリ (アプリを起動したユーザーのコンテキストのみで実行されるアプリ) では、[GetDefault](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getdefault.aspx) メソッドを使用して、**StoreContext** オブジェクトを取得します。このオブジェクトを使用すると、ユーザーの Windows ストア関連データへのアクセスおよび管理が可能になります。 ほとんどのユニバーサル Windows プラットフォーム アプリ (UWP) アプリはシングル ユーザー アプリです。

  ```csharp
  Windows.Services.Store.StoreContext context = StoreContext.GetDefault();
  ```

* マルチ ユーザー アプリでは、[GetForUser](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.getforuser.aspx) メソッドを使用して **StoreContext** オブジェクトを取得します。このオブジェクトを使用すると、アプリの使用中に Microsoft アカウントでサインインした特定のユーザーの Windows ストア関連データへのアクセスおよび管理が可能になります。 マルチ ユーザー アプリについて詳しくは、「[マルチ ユーザー アプリケーションの概要](https://msdn.microsoft.com/windows/uwp/xbox-apps/multi-user-applications)」をご覧ください。 次の例は、利用可能な最初のユーザーの **StoreContext** オブジェクトを取得します。

  ```csharp
  var users = await Windows.System.User.FindAllAsync();
  Windows.Services.Store.StoreContext context = StoreContext.GetForUser(users[0]);
  ```

[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを取得した後、メソッドを呼び出して、現在のユーザー向けのアプリまたはアドオンを購入するなどのタスクを行うことができます。 詳しくは、次の記事をご覧ください。

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)

**Windows.Services.Store** 名前空間を使用した試用版とアプリ内購入の実装方法を示す完全なサンプルについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

<span />
### 製品、SKU、および可用性のオブジェクト モデル

ストア内のすべての製品には少なくとも 1 つの *SKU* があり、各 SKU ごとに少なくとも 1 つの*可用性*があります。 Windows デベロッパー センター ダッシュボードでは、ほとんどの場合、これらの概念は開発者から抽象化されており、多くの開発者はアプリまたはアドオンの SKU や可用性を定義することはありません。 ただし、**Windows.Services.Store** 名前空間のストア製品のオブジェクト モデルには SKU と可用性が含まれているため、これらの概念の基本的な知識があると役に立つことがあります。

| オブジェクトの種類 |  説明  |
|---------|-------------------|
| 製品  |  [StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) クラスは、アプリやアドオンを含め、ストアで利用できる製品の種類を表します。 このクラスには、製品のストア ID、ストア登録情報の画像と動画、価格情報などのデータにアクセスするために使用できるプロパティが用意されています。 また、製品を購入するために使用できるメソッドも提供されます。 |
| SKU |  [StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) クラスは、製品の *SKU* を表します。 SKU は、独自の説明や価格など、一意の製品の詳細を備えた特定バージョンの製品です。 各アプリまたはアドオンには既定の SKU があります。 ほとんどの開発者は、アプリの通常版と試用版を公開している場合を除いて (ストア カタログでは、通常版と試用版は同じアプリの別の SKU になります)、1 つのアプリに複数の SKU を用意することはありません。 <p/><p/> 一部の発行元は、独自の SKU を定義することができます。 たとえば、大規模なゲームの発行元の場合、赤い血が許可されない市場では緑の血が表示される SKU でゲームをリリースし、それ以外のすべての市場では赤い血が表示される別の SKU でゲームをリリースすることがあります。 または、デジタル ビデオ コンテンツを販売している発行元が、1 つのビデオに対して、高解像度版の SKU と通常解像度版の SKU という、2 つの SKU を公開する場合もあります。 <p/><p/> 各製品には、SKU にアクセスするために使用できる [Skus](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.skus.aspx) プロパティがあります。 |
| 可用性  |  [StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) クラスは、SKU の*可用性*を表します。 可用性は、一意の独自の価格情報を備えた SKU の特定のバージョンです。 各 SKU には、既定の可用性があります。 一部の発行元は独自の可用性を定義でき、特定の SKU にさまざまな価格オプションを導入できます。 <p/><p/> 各 SKU には、可用性にアクセスするために使用できる [Availabilities](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.availabilities.aspx) プロパティがあります。 ほとんどの開発者の場合、SKU ごとに 1 つの既定の可用性があります。  |

<span id="store_ids" />
### ストア ID

ストアのアプリとアドオンにはすべて、関連付けられた**ストア ID** があります。 **Windows.Services.Store** 名前空間の API の多くは、アプリまたはアドオンで操作を実行するためにストア ID を必要とします。 製品、SKU、および可用性のストア ID の形式はそれぞれ異なります。

| オブジェクトの種類 |  ストア ID の形式  |
|---------|-------------------|
| 製品  |  ストア内の製品のストア ID は 12 文字の英数字文字列です。たとえば、```9NBLGGH4R315``` のようになります。 このストア ID は、アプリまたはアドオンの Windows デベロッパー センター ダッシュボード ページで利用でき、[StoreProduct](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.aspx) オブジェクトの [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeproduct.storeid.aspx) プロパティによって返されます。 この ID は、*製品ストア ID* と呼ばれることもあります。 |
| SKU |  SKU の場合、ストア ID の形式は ```<product Store ID>/xxxx``` のようになります。ここで、```xxxx``` は製品の SKU を識別する 4 文字の英数字文字列です。 たとえば、```9NBLGGH4R315/000N``` と記述します。 この ID は、[StoreSku](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.aspx) オブジェクトの [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storesku.storeid.aspx) プロパティによって返され、*SKU ストア ID* と呼ばれることもあります。 |
| 可用性  |  可用性の場合、ストア ID の形式は ```<product Store ID>/xxxx/yyyyyyyyyyyy``` のようになります。ここで、```xxxx``` は製品の SKU を識別する 4 文字の英数字文字列で、```yyyyyyyyyyyy``` は SKU の可用性を識別する 12 文字の英数字文字列です。 たとえば、```9NBLGGH4R315/000N/4KW6QZD2VN6X``` と記述します。 この ID は、[StoreAvailability](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.aspx) オブジェクトの [StoreId](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeavailability.storeid.aspx) プロパティによって返され、*可用性ストア ID* と呼ばれることもあります。  |

<span id="testing" />
### Windows.Services.Store 名前空間を使用するアプリのテスト

**Windows.Services.Store** 名前空間には、テスト中にライセンス情報をシミュレートするために使用できるクラスが用意されていません。 代わりに、アプリをストアに公開し、そのアプリを開発用デバイスにダウンロードして、そのライセンスをテストに使用する必要があります。 これは、**Windows.ApplicationModel.Store** 名前空間を使用するアプリとは異なるエクスペリエンスになります。このようなアプリでは、[CurrentAppSimulator](https://msdn.microsoft.com/library/windows/apps/hh779766) クラスを使用して、テスト中にライセンス情報をシミュレートできるためです。

アプリで **Windows.Services.Store** 名前空間の API を使用してアプリとアドオンの情報にアクセスする場合は、次のプロセスに従ってコードをテストします。

1. アプリが公開済みでストアで利用でき、アプリを更新して **Windows.Services.Store** 名前空間の API を使用することを考えている場合は、すぐに開始できます。 アプリのアドオンを提供することを考えている場合は、デベロッパー センター ダッシュボードで[アプリのアドオンを定義](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)していることを確認します。

  ストアで利用できる公開済みのアプリがまだない場合は、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最低限の要件を満たしている基本的なアプリを構築し、Windows デベロッパー センター ダッシュボードに[そのアプリを申請](https://msdn.microsoft.com/windows/uwp/publish/app-submissions)します。 アプリのアドオンを提供する場合は、[アプリのアドオンを定義](https://msdn.microsoft.com/windows/uwp/publish/iap-submissions)していることを確認します。 必要に応じて、テスト中は[ストアのアプリを非表示にする](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability)ことができます。

2. [現在のアプリで利用できるアドオンを取得する](get-product-info-for-apps-and-add-ons.md)、[アプリまたはアドオンを購入する](enable-in-app-purchases-of-apps-and-add-ons.md)、[アプリのライセンス情報を取得する](get-license-info-for-apps-and-add-ons.md)などのタスクを実行するために、**Windows.Services.Store** 名前空間のいずれかの [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) メソッドを使用するアプリのコードを記述します。 その他の例については、以下の「関連トピック」セクションをご覧ください。

3. Visual Studio で、**[プロジェクト]** メニューをクリックし、**[ストア]** にポイントして、**[アプリケーションをストアと関連付ける]** をクリックします。 ウィザードの手順を完了し、テストに使用する Windows デベロッパー センター アカウントのアプリとアプリ プロジェクトを関連付けます。

  >**注**&nbsp;&nbsp;プロジェクトとストアのアプリを関連付けていない場合、[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) メソッドにより、戻り値の **ExtendedError** プロパティがエラー コード値 0x803F6107 に設定されます。 この値は、ストアにそのアプリに関する情報がないことを示します。

4. まだ前の手順で指定したストアのアプリをインストールしていない場合は、アプリをインストールし、アプリを一度実行してから閉じます。 これにより、アプリの有効なライセンスが開発用デバイスにインストールされます。

5. Visual Studio で、プロジェクトの実行またはデバッグを開始します。 コードによって、ローカルのプロジェクトと関連付けたストア アプリからアプリおよびアドオンのデータが取得されます。 アプリを再インストールするように求められた場合は、その指示に従った後、プロジェクトを実行またはデバッグします。

## 関連トピック

* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [アプリの試用版の実装](implement-a-trial-version-of-your-app.md)
* [Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)



<!--HONumber=Aug16_HO5-->


