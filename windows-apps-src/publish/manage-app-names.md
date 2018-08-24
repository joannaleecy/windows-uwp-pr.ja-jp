---
author: jnHs
Description: View the names that you've reserved for your app, reserve additional names (for other languages or to change your app's name), and delete reserved names that you don't need anymore.
title: アプリ名の管理
ms.assetid: D95A6227-746E-4729-AE55-648A7102401C
ms.author: wdg-dev-content
ms.date: 8/07/2018
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10、uwp、アプリの名前、アプリの名前、アプリの更新プログラムの名前、ゲーム名、製品名を変更します。
ms.localizationpriority: medium
ms.openlocfilehash: f0d2c6f72e2f69f0b768af55f9bddeb9bb008027
ms.sourcegitcommit: c6d6f8b54253e79354f8db14e5cf3b113a3e5014
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/24/2018
ms.locfileid: "2829908"
---
# <a name="manage-app-names"></a>アプリ名の管理

すべてのアプリでは、用に予約した名前を表示する**アプリの名前を管理する**ことができます (その他の言語またはアプリの名前を変更するのには) 別の名前を予約し、不要な名前を削除します。 [Windows デベロッパー センターのダッシュ ボード](https://partner.microsoft.com/dashboard)でのこのページを検索するには、アプリのいずれかの左側のナビゲーション メニューで [**アプリの管理**] セクションを展開します。


## <a name="reserve-additional-names-for-your-app"></a>アプリの追加の名前の予約

同じアプリに使用する複数のアプリ名を予約できます。 これは、複数の言語でアプリを提供している場合、さまざまな言語の異なる名前を使用する場合に特に役立ちます。 次のように、アプリの名前を変更するために、新しい名前を予約できます。

新しいアプリ名を予約するには、**アプリの名前の管理**] ページの**より多くの名前の予約**] セクションで、テキスト ボックスを検索します。 予約する名前を入力し、**[利用可能か確認]** をクリックします。 名前が利用できる場合は、**[製品名の予約]** をクリックします。 次の手順を繰り返して、複数のアプリの名前を予約するには、必要な場合。

> [!NOTE]
> アプリ名の予約に関する詳細や、特定の名前が利用できない可能性がある理由については、「[名前の予約によるアプリの作成](create-your-app-by-reserving-a-name.md)」をご覧ください。


## <a name="delete-app-names"></a>アプリ名の削除

以前に予約した名前を使用しなくなった場合は、ここで削除することによって予約を解除できます。 この操作によって名前はすぐに他の開発者が予約して使うことができるようになるため、操作を行う前に確認してください。

アプリの予約済みの名前の 1 つを削除するには、使わなくなった名前を検索し、**[削除]** をクリックします。 確認のダイアログ ボックスで、もう一度 **[削除]** をクリックして確認します。

アプリが少なくとも 1 つの予約名を持つ必要があることを確認します。 完全に、ダッシュ ボード] からアプリを削除する (そのアプリ用に予約したすべての名前をリリース)、**アプリの概要**] ページから**このアプリを削除**] をクリックします。 進行中のアプリの申請がある場合、まずその申請を削除する必要があります。 既にストアにアプリを発行した場合は、削除できないことをダッシュ ボードから (ただし、[**概要**] ページの**表示/非表示の製品**機能を使用するには非表示にする) に注意してください。 


## <a name="rename-an-app-that-has-already-been-published"></a>公開済みアプリの名前の変更

既にストアで公開されているアプリの名前を変更する場合は、(前に説明した手順に従って) アプリの新しい名前を予約し、アプリの新しい申請を作成することによってアプリ名を変更できます。 

前の名前を置き換える新しい送信物に更新されたパッケージをアップロードして、アプリのパッケージを更新する必要があります。
- 最初に、手動または Visual Studio を使用して、新しい名前を使用する Package.StoreAssociation.xml ファイルを更新 (**プロジェクト > ストア >… ストアでアプリを関連付ける**)。詳しくは、 [Visual Studio で UWP アプリ パッケージ](../packaging/packaging-uwp-apps.md)を参照してください。
- アプリ マニフェストの [**Package/Properties/DisplayName**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-displayname) 要素を更新する必要があります。アプリの名前を含むすべてのグラフィックスとテキストを更新してください。 
  > [!IMPORTANT]
  > 必ず、アプリのマニフェストの **Package/Properties/DisplayName** を変更する前に、Package.StoreAssociation.xml ファイルを更新してください。そうしないと、エラーが発生する可能性があります。

新しい名前を使用するようストアの一覧を更新するには、[[ストア] ページを一覧表示](create-app-store-listings.md)言語に移動し、**製品名**のドロップダウン リストから名前を選びます。 必ず、説明と、メンション名の一覧のほかの部分を確認し、必要な場合は、更新を行います。

> [!NOTE]
> アプリの複数の言語でパッケージやストアの一覧がある場合は、パッケージを更新または更新する名前が必要なすべての言語の一覧を保存する必要があります。

新しい名前でアプリを公開すると、不要になったを使用する任意の古い名前を削除できます。

> [!TIP]
> 各アプリ用に予約している最初の名前を使用してダッシュ ボードが表示されます。 、アプリの名前を変更するのには上記の手順を実行して、新しい名前を使用してダッシュ ボードに表示させたい場合は、([**アプリの名前の管理**] ページで [**削除**] をクリック) して、元の名前を削除する必要があります。 

 

 




