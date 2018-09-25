---
author: jnHs
Description: If you've provided packages targeting different operating systems, you have the option to customize parts of your Store listing for different targeted operating systems.
title: プラットフォーム固有の Store 登録情報の作成
ms.assetid: 5BE66BE2-669C-49E0-8915-60F1027EF94A
ms.author: wdg-dev-content
ms.date: 3/13/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, カスタマイズ, 登録情報, 説明, 以前
ms.localizationpriority: medium
ms.openlocfilehash: 6f30a825cc7aec1b6f7dbf5cff0ea1c17c43ffd7
ms.sourcegitcommit: 232543fba1fb30bb1489b053310ed6bd4b8f15d5
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 09/25/2018
ms.locfileid: "4178863"
---
# <a name="create-platform-specific-store-listings"></a>プラットフォーム固有の Store 登録情報の作成


アプリに別のオペレーティング システムを対象とするパッケージがある場合は、以前のバージョンの OS (Windows 8.x 以前または Windows Phone 8.x 以前) のユーザー向けに Store 登録情報の一部をカスタマイズするオプションがあります。 

> [!IMPORTANT]
> Windows 10 のユーザーには、既定の [Store 登録情報](create-app-store-listings.md)が常に表示されます。 既に 1 つまたは複数の以前のバージョンの OS をサポートするパッケージをアップロードしている場合を除き、プラットフォーム固有の Store 登録情報を作成するオプションは表示されません。 

プラットフォーム固有のストア登録情報は、すべてのユーザーに同じストア登録情報を表示するのではなく、ある OS バージョンでのみ表示される機能について説明したり、(デバイスの種類とは無関係に) 特定の OS に固有のスクリーンショットを指定したりする場合に役立ちます。

> [!NOTE]
> ある言語でプラットフォーム固有の Store 登録情報を作成しても、アプリがサポートする他の言語でプラットフォーム固有の Store 登録情報が作成されることはありません。 プラットフォーム固有の Store 登録情報は、言語ごとに別個に作成する必要があります。 また、プラットフォーム固有の登録情報用に、Store 登録情報のデータをインポートおよびエクスポートできないことにも注意してください。


## <a name="creating-a-platform-specific-store-listing"></a>プラットフォーム固有の Store 登録情報の作成

アプリが以前の OS バージョン (Windows 8.x 以前または Windows Phone 8.x 以前) をサポートする場合、**[Store 登録情報]** ページの上部で、**プラットフォーム固有のアプリの Store 登録情報を作成**するためのリンクを選択できます。 

> [!TIP]
> プラットフォーム固有の Store 登録情報を作成するオプションは、パッケージをアップロードするまで表示されません。

このオプションを選択すると、申請でサポートされているターゲット OS のバージョンを選択するよう求められます。 アプリがターゲットとするすべての OS バージョンに対して既にプラットフォーム固有の Store 登録情報が作成されている場合は、それ以上選択することはできません。 Windows 10 のユーザーにはアプリの既定の Store 登録情報が常に表示されるため、Windows 10 は選択肢の一覧に含まれません。

作業の開始点として、既定の Store 登録情報を使うことができます。この場合、既定の Store 登録情報に入力されている適用可能なテキストと画像が取り込まれ、保存前に自由に変更できます。 必要に応じて、完全に空のストア登録情報から始めることもできます。

**[続行]** をクリックすると、作成したプラットフォーム固有の Store 登録情報を表示するセクションが **[Store 登録情報]** ページに追加されます。 このセクションには、**[説明]** (必須)、**[今回のバージョンでの新機能]**、**[スクリーンショット]**、**[アプリ タイル アイコン]**、**[アプリの機能]**、**[追加のシステム要件]** を指定する独自のフィールド セットが表示されます。 既定のストア登録情報と同じ情報であっても、カスタムのストア登録情報で情報を表示するすべてのフィールドに情報を入力してください。 これらのフィールドのいずれかを空白のままにした場合、カスタムの Store 登録情報の該当するフィールドには情報が表示されません。


> [!IMPORTANT]
> Store 登録情報の [[追加情報]](create-app-store-listings.md#additional-information) セクションのフィールドを別の OS バージョン用にカスタマイズすることはできません。
> 
> さらに、既定の [[Store 登録情報]](create-app-store-listings.md) ページのフィールドの一部は Windows 10 のユーザーにしか適用されないため、プラットフォーム固有の Store 登録情報の作成時には、同じオプションがすべて表示されるわけではありません。 たとえば、トレーラーは Windows 10 バージョン 1607 以降のユーザーにしか表示されないため、プラットフォーム固有の Store 登録情報にトレーラーを追加することはできません。 


## <a name="removing-a-platform-specific-store-listing"></a>プラットフォーム固有の Store 登録情報の削除

プラットフォーム固有の Store 登録情報を作成した後、そのオペレーティング システムではユーザーに既定の Store 登録情報を表示することにした場合は、その登録情報の横にある **[削除]** リンクを選択します。

それらのユーザーに既定の Store 登録情報を表示することを確認したら、**[OK]** を選択します。 プラットフォーム固有の Store 登録情報 (登録されていたすべての言語について) 削除すると、その OS バージョンのユーザーには既定の Store 登録情報が表示されます。 考えが変わった場合は、上記の手順に従ってそのオペレーティング システム用の別のプラットフォーム固有の Store 登録情報を作成できます。

 

 




