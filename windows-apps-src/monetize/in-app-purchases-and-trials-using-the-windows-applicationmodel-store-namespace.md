---
author: mcleanbyron
ms.assetid: 32572890-26E3-4FBB-985B-47D61FF7F387
description: "Windows 10 バージョン 1607 より前のリリースを対象とする UWP アプリでのアプリ内購入と試用版を有効にする方法を説明します。"
title: "Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版"
translationtype: Human Translation
ms.sourcegitcommit: 5f975d0a99539292e1ce91ca09dbd5fac11c4a49
ms.openlocfilehash: 649d082cddcf301fe602a5ab99637ad7bea67d49

---

# Windows.ApplicationModel.Store 名前空間を使用するアプリ内購入と試用版

Windows SDK に用意されている [Windows.ApplicationModel.Store](https://msdn.microsoft.com/library/windows/apps/windows.applicationmodel.store.aspx) 名前空間のメンバーを使して、ユニバーサル Windows プラットフォーム (UWP) アプリにアプリ内購入機能や試用版機能を追加し、アプリで収益を得たり、新しい機能を追加したりすることができます。 こうした API では、アプリのライセンス情報へのアクセスも提供されます。

>**注**&nbsp;&nbsp;アプリが Windows 10 バージョン 1607 以降のバージョンをターゲットにする場合は、**Windows.ApplicationModel.Store** 名前空間ではなく、[Windows.Services.Store](https://msdn.microsoft.com/library/windows/apps/windows.services.store.aspx) 名前空間を使用することをお勧めします。 **Windows.Services.Store** 名前空間は、ストアで管理されるコンシューマブルなアドオンなど、最新の種類のアドオンをサポートしており、Windows デベロッパー センターとストアで今後サポートされる製品および機能の種類と互換性を持つように設計されています。 **Windows.Services.Store** 名前空間は、パフォーマンスの向上も考えた作りになっています。 詳しくは、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

このセクションの記事では、いくつかの一般的なシナリオにおいて **Windows.ApplicationModel.Store** 名前空間のメンバーを使用するための詳しいガイダンスとコード例を示します。 UWP アプリのアプリ内での購入に関する概念の概要については、「[アプリ内購入と試用版](in-app-purchases-and-trials.md)」をご覧ください。

**Windows.ApplicationModel.Store** 名前空間を使用した試用版とアプリ内購入の実装方法を示す完全なサンプルについては、[ストア サンプル](https://github.com/Microsoft/Windows-universal-samples/tree/win10-1507/Samples/Store)をご覧ください。

## このセクションの内容


| トピック                                                                                                       | 説明                 |
|-------------------------------------------------------------------------------------------------------------|-----------------------------|
| [アプリ内製品購入の有効化](enable-in-app-product-purchases.md)      |  アプリが無料であるかどうかにかかわらず、コンテンツ、その他のアプリ、アプリの新機能 (ゲームの次のレベルのロック解除など) をアプリ内から直接販売できます。 ここでは、アプリ内で製品を販売できるようにする方法について説明します。  |
| [コンシューマブルなアプリ内製品購入の有効化](enable-consumable-in-app-product-purchases.md)      | ストアの商取引プラットフォームを使ってコンシューマブルなアプリ内製品 (購入、使用、再購入が可能なアイテム) をサポートすると、堅牢かつ信頼性の高いアプリ内購入エクスペリエンスを顧客に提供できます。 これは、購入して、特定のパワーアップを購入するために使うことができるゲーム内通貨 (ゴールド、コインなど) 用に特に便利です。 |
| [試用版での機能の除外または制限](exclude-or-limit-features-in-a-trial-version-of-your-app.md) | ユーザーがアプリを無料で使うことができる試用期間を設け、その期間中は一部の機能を除外または制限することで、アプリを通常版にアップグレードするようユーザーに促すことができます。 |
| [アプリ内製品の大規模なカタログの管理](manage-a-large-catalog-of-in-app-products.md)      |   アプリ内製品のカタログが大きくなる場合、カタログを管理するためにこのトピックで説明するプロセスを採用できます。    |
| [通知を使った製品購入の確認](use-receipts-to-verify-product-purchases.md)      |   製品購入が成功した各 Windows ストアのトランザクションでは、必要に応じてトランザクションの通知を返し、掲載製品と料金についての情報をユーザーに提供できます。 この情報は、ユーザーがアプリを購入したことや、Windows ストアからアプリ内製品の購入が行われたことをアプリで確認する必要がある場合などに役立ちます。 |



<!--HONumber=Aug16_HO5-->


