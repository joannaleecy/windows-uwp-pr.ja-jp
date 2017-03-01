---
author: mcleanbyron
ms.assetid: 571697B7-6064-4C50-9A68-1374F2C3F931
description: "Windows.Services.Store 名前空間を使って、アプリの試用版の実装する方法について説明します。"
title: "アプリの試用版の実装"
keywords: "Windows 10, UWP, 試用版, アプリ内購入, IAP, Windows.Services.Store"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: dc5e67823521db455e12fa4b16d8204c20bff621
ms.lasthandoff: 02/07/2017

---

# <a name="implement-a-trial-version-of-your-app"></a>アプリの試用版の実装

試用期間中はアプリを無料で使用できるように、アプリを [Windows デベロッパー センター ダッシュボードで無料試用版](../publish/set-app-pricing-and-availability.md#free-trial)として構成した場合、試用期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。 どのような機能を制限するかをコーディング開始前に決め、完全なライセンスが購入されたときにだけその機能が正しく動作するようにアプリを設定します。 また、ユーザーがアプリを購入する前の試用期間中にだけバナーや透かしなどを表示する機能を有効にすることもできます。

Windows 10 バージョン 1607以降をターゲットとするアプリは、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間の　[StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) クラスのメンバーを使用して、アプリの試用ライセンスがユーザーにあるかどうかを判定したり、アプリの実行中にライセンスが変更されたときに通知を受け取ったりできます。

>**注**&nbsp;&nbsp;この記事は、Windows 10 バージョン 1607 以降をターゲットとするアプリに適用されます。 アプリが Windows 10 の以前のバージョンをターゲットする場合、**Windows.Services.Store** 名前空間の代わりに [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間を使う必要があります。 詳しくは、「[Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版](in-app-purchases-and-trials-using-the-windows-applicationmodel-store-namespace.md)」をご覧ください。

## <a name="guidelines-for-implementing-a-trial-version"></a>試用版を実装するためのガイドライン

アプリの現時点でのライセンスの状態は、[StoreAppLicense](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.aspx) クラスのプロパティとして保存されています。 通常は、次の手順で説明するように、ライセンスの状態に依存する関数を条件ブロック内に記述します。 このような機能について検討するときには、ライセンスがどの状態であっても動作するように実装できることを確認してください。

また、アプリの実行中にライセンスが変更された場合の処理方法を決めておきます。 試用版のアプリでもすべての機能を使うことができるようにしながら、購入版では表示されない広告バナーを表示することができます。 また、試用版アプリでは一部の機能を無効にしたり、ユーザーに購入を勧めるメッセージを表示したりすることもできます。

アプリの性質を考慮して、それに適した試用や有効期限の戦略を立ててください。 ゲームの試用版の場合は、ユーザーが遊べるゲーム コンテンツの量を制限するのが良い戦略でしょう。 ユーティリティの試用版の場合は、有効期限日の設定や、ユーザーが使いたがるような機能の制限を検討するとよいでしょう。

ゲーム以外の多くのアプリでは、ユーザーにアプリ全体を理解してもらうために、有効期限日を設定するのが適しています。 ここでは、有効期限に関するいくつかの一般的なシナリオと、その処理方法について説明します。

-   **アプリの実行中に試用ライセンスが期限切れになった**

    アプリの実行中に試用ライセンスが期限切れになった場合は、次の対処方法があります。

    -   何もしない。
    -   ユーザーにメッセージを表示する。
    -   閉じる。
    -   ユーザーにアプリの購入を促す。

    お勧めするのは、アプリの購入を促すメッセージを表示することです。ユーザーがアプリを購入したら、すべての機能を有効にして、そのまま使うことができるようにします。 購入しなかった場合は、アプリを閉じるか、アプリの購入が必要なことを一定の間隔で通知します。

-   **アプリの起動前に試用ライセンスが期限切れになった**

    ユーザーがアプリを起動する前に試用ライセンスが期限切れになった場合、アプリは起動しません。 ユーザーには、ストアからそのアプリを購入できることを伝えるダイアログ ボックスが表示されます。

-   **アプリの実行中にユーザーがアプリを購入した**

    アプリの実行中にユーザーがアプリを購入した場合は、次の対処方法があります。

    -   何もせず、アプリが再起動されるまでは試用モードを続ける。
    -   購入に対するお礼をする、またはメッセージを表示する。
    -   完全なライセンスがある場合に使うことができる機能を、通知なしで有効にする (または、試用版であることを示す表示を消す)。

アプリの動作でユーザーが驚くことがないように、無料試用版のアプリが試用期間中にどのように機能し、期間が過ぎるとどのようになるかを必ず説明してください。 アプリの説明について詳しくは、「[アプリの説明の作成](https://msdn.microsoft.com/library/windows/apps/mt148529)」をご覧ください。

## <a name="prerequisites"></a>前提条件

この例には、次の前提条件があります。
* Windows 10 バージョン 1607 以降をターゲットとするユニバーサル Windows プラットフォーム (UWP) アプリの Visual Studio プロジェクト。
* Windows デベロッパー センター ダッシュ ボードで、期限なしの[無料試用版](https://msdn.microsoft.com/windows/uwp/publish/set-app-pricing-and-availability)として構成したアプリを作成し、そのアプリがストアで公開されて入手可能になっている。 これは、ユーザーにリリースするアプリでも、[Windows アプリ認定キット](https://developer.microsoft.com/windows/develop/app-certification-kit)の最小要件を満たす、テスト目的でのみ使う基本的なアプリでもかまいません。 詳しくは、[テスト ガイダンス](in-app-purchases-and-trials.md#testing)をご覧ください。

この例のコードは、次の点を前提としています。
* コードは、```workingProgressRing``` という名前の [ProgressRing](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.progressring.aspx) と ```textBlock``` という名前の [TextBlock](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.textblock.aspx) を含む [Page](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.controls.page.aspx) のコンテキストで実行されます。 これらのオブジェクトは、それぞれ非同期操作が発生していることを示するためと、出力メッセージを表示するために使用されます。
* コード ファイルには、**Windows.Services.Store** 名前空間の **using** ステートメントがあります。
* アプリは、アプリを起動したユーザーのコンテキストでのみ動作するシングル ユーザー アプリです。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md#api_intro)」をご覧ください。

>**注:**&nbsp;&nbsp;[Desktop Bridge](https://developer.microsoft.com/windows/bridges/desktop) を使うデスクトップ アプリケーションがある場合、この例には示されていないコードを追加して [StoreContext](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.aspx) オブジェクトを構成することが必要になることがあります。 詳しくは、「[Desktop Bridge を使用するデスクトップ アプリケーションでの StoreContext クラスの使用](in-app-purchases-and-trials.md#desktop)」をご覧ください。

## <a name="code-example"></a>コードの例

アプリを初期化するときに、アプリの [StoreAppLicense](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storeapplicense.aspx) オブジェクトを取得し、アプリの実行中にライセンスが変更されたときに通知を受け取る [OfflineLicensesChanged](https://msdn.microsoft.com/library/windows/apps/windows.services.store.storecontext.offlinelicenseschanged.aspx) イベントを処理します。 アプリのライセンスが変更されるのは、たとえば、試用期間が終了したときや、ユーザーがストアを通じてアプリを購入したときです。 ライセンスが変更されるときに、新しいライセンスを入手し、必要に応じてアプリの機能を有効または無効にします。

この時点で、ユーザーがアプリを購入したら、ライセンスの状態が変わったことをユーザーに知らせることをお勧めします。 コーディングの方法上、必要であれば、ユーザーにアプリを再起動してもらわなければならないこともあります。 ただし、この移行は可能な限りスムーズで違和感のないようにする必要があります。

> [!div class="tabbedCodeSnippets"]
[!code-cs[ImplementTrial](./code/InAppPurchasesAndLicenses_RS1/cs/ImplementTrialPage.xaml.cs#ImplementTrial)]

完全なサンプル アプリケーションについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)をご覧ください。

## <a name="related-topics"></a>関連トピック

* [アプリ内購入と試用版](in-app-purchases-and-trials.md)
* [アプリとアドオンの製品情報の取得](get-product-info-for-apps-and-add-ons.md)
* [アプリとアドオンのライセンス情報の取得](get-license-info-for-apps-and-add-ons.md)
* [アプリとアドオンのアプリ内購入の有効化](enable-in-app-purchases-of-apps-and-add-ons.md)
* [コンシューマブルなアドオン購入の有効化](enable-consumable-add-on-purchases.md)
* [ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/master/Samples/Store)

