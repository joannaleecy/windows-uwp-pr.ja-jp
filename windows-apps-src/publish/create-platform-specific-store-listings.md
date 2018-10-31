---
author: jnHs
Description: If you've provided packages targeting different operating systems, you have the option to customize parts of your Store listing for different targeted operating systems.
title: プラットフォーム固有の Store 登録情報の作成
ms.assetid: 5BE66BE2-669C-49E0-8915-60F1027EF94A
ms.author: wdg-dev-content
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, カスタマイズ, 登録情報, 説明, 以前
ms.localizationpriority: medium
ms.openlocfilehash: c2bc58540f49afb8b24eaa58150132fea1d27f84
ms.sourcegitcommit: ca96031debe1e76d4501621a7680079244ef1c60
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/31/2018
ms.locfileid: "5836844"
---
# <a name="create-platform-specific-store-listings"></a>プラットフォーム固有の Store 登録情報の作成


以前の OS バージョンのユーザーのストア登録情報の一部をカスタマイズするオプションがある場合は、さまざまなオペレーティング システムをターゲットとするパッケージが以前に公開されたアプリに、(Windows 8.x 以前や Windows Phone 8.x またはそれ以前)。 

Windows 10 (Xbox を含む) のユーザーでは、既定の[Store 登録情報](create-app-store-listings.md)が常に表示します。 1 つまたは複数の以前の OS バージョンをサポートするパッケージを使用したアプリを既に公開している場合を除き、プラットフォーム固有のストア登録情報を作成するオプションは表示されません。 

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成した製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳しくは、この[ブログ記事](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)を参照してください。

1 つの OS バージョンでのみ表示される機能について説明したりするか、(デバイスの種類の無関係に) 特定の OS に固有のスクリーン ショットを提供する場合、プラットフォーム固有のストア登録情報が役に立ちます。

> [!NOTE]
> ある言語でプラットフォーム固有の Store 登録情報を作成しても、アプリがサポートする他の言語でプラットフォーム固有の Store 登録情報が作成されることはありません。 プラットフォーム固有のストア登録情報は、言語ごとに別個に作成する必要があります。 [インポートおよびエクスポートのストア登録情報データ](import-and-export-store-listings.md)プラットフォーム固有の登録情報にアクセスできないことにも注意してください。


## <a name="creating-a-platform-specific-store-listing"></a>プラットフォーム固有のストア登録情報の作成

以前に公開されたアプリには、以前の OS バージョンをサポートするパッケージが含まれている場合、 **Store 登録情報**ページの上部付近には ((Windows 8.x 以前や Windows Phone 8.x 以前)、する選択**でプラットフォーム固有のアプリのストア登録情報を作成できます**. このオプションを選択すると、申請でサポートされているターゲット OS のバージョンを選択するよう求められます。 以前の OS バージョンのすべてのプラットフォーム固有のストア登録情報は、アプリが対象と既に作成したら、もう 1 つの項目を選択することはできません。

取り込まれます、適用可能なテキストと画像の既定のストアに入力した登録情報、作業の開始点として (Windows 10) の既定のストア登録情報を使用することができます。その後ことができますか保存する前に変更を加えます。 必要に応じて、完全に空のストア登録情報から始めることもできます。

**[続行]** をクリックすると、作成したプラットフォーム固有の Store 登録情報を表示するセクションが **[Store 登録情報]** ページに追加されます。 このセクションには、**[説明]** (必須)、**[今回のバージョンでの新機能]**、**[スクリーンショット]**、**[アプリ タイル アイコン]**、**[アプリの機能]**、**[追加のシステム要件]** を指定する独自のフィールド セットが表示されます。 既定のストア登録情報と同じ情報であっても、カスタムのストア登録情報で情報を表示するすべてのフィールドに情報を入力してください。 これらのフィールドのいずれかを空白のままにした場合、カスタムの Store 登録情報の該当するフィールドには情報が表示されません。

> [!IMPORTANT]
> Store 登録情報の [[追加情報]](create-app-store-listings.md#additional-information) セクションのフィールドを別の OS バージョン用にカスタマイズすることはできません。
> 
> さらに、既定の [[Store 登録情報]](create-app-store-listings.md) ページのフィールドの一部は Windows 10 のユーザーにしか適用されないため、プラットフォーム固有の Store 登録情報の作成時には、同じオプションがすべて表示されるわけではありません。 たとえば、トレーラーは Windows 10 バージョン 1607 以降のユーザーにしか表示されないため、プラットフォーム固有の Store 登録情報にトレーラーを追加することはできません。 

特定の OS バージョンのユーザーに対して変更を加える必要に応じて、プラットフォーム固有の登録情報を編集する続行することができます。


## <a name="removing-a-platform-specific-store-listing"></a>プラットフォーム固有のストア登録情報の削除

プラットフォーム固有の Store 登録情報を作成した後、そのオペレーティング システムではユーザーに既定の Store 登録情報を表示することにした場合は、その登録情報の横にある **[削除]** リンクを選択します。

それらのユーザーに既定の Store 登録情報を表示することを確認したら、**[OK]** を選択します。 プラットフォーム固有の Store 登録情報 (登録されていたすべての言語について) 削除すると、その OS バージョンのユーザーには既定の Store 登録情報が表示されます。 考えが変わった場合は、上記の手順に従ってそのオペレーティング システム用の別のプラットフォーム固有の Store 登録情報を作成できます。
 

 




