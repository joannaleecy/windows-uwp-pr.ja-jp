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
keywords: windows 10, uwp, アプリの名前, アプリ名, アプリ名の更新、ゲームの名前, 製品名を変更します。
ms.localizationpriority: medium
ms.openlocfilehash: f0d2c6f72e2f69f0b768af55f9bddeb9bb008027
ms.sourcegitcommit: 3727445c1d6374401b867c78e4ff8b07d92b7adc
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/29/2018
ms.locfileid: "2910268"
---
# <a name="manage-app-names"></a>アプリ名の管理

すべてのアプリについて予約した名前を表示する**アプリ名の管理**では、(その他の言語またはアプリの名前を変更する) の追加の名前を予約し、名前は必要ありませんを削除します。 このページは、アプリの左側のナビゲーション メニューの [**アプリ管理**] セクションを展開することによって、 [Windows デベロッパー センター ダッシュ ボード](https://partner.microsoft.com/dashboard)で確認できます。


## <a name="reserve-additional-names-for-your-app"></a>アプリの追加の名前の予約

同じアプリに使用する複数のアプリ名を予約できます。 これは、複数の言語でアプリを提供している場合、さまざまな言語の異なる名前を使用する場合に特に役立ちます。 次の説明に従って、アプリの名前を変更するために、新しい名前を予約できます。

新しいアプリの名前を予約するには、**アプリ名の管理**ページの**他の名前を予約**] セクションで、テキスト ボックスを検索します。 予約する名前を入力し、**[利用可能か確認]** をクリックします。 名前が利用できる場合は、**[製品名の予約]** をクリックします。 必要な場合は、次の手順を繰り返して、複数のアプリ名を予約できます。

> [!NOTE]
> アプリ名の予約に関する詳細や、特定の名前が利用できない可能性がある理由については、「[名前の予約によるアプリの作成](create-your-app-by-reserving-a-name.md)」をご覧ください。


## <a name="delete-app-names"></a>アプリ名の削除

以前に予約した名前を使用しなくなった場合は、ここで削除することによって予約を解除できます。 この操作によって名前はすぐに他の開発者が予約して使うことができるようになるため、操作を行う前に確認してください。

アプリの予約済みの名前の 1 つを削除するには、使わなくなった名前を検索し、**[削除]** をクリックします。 確認のダイアログ ボックスで、もう一度 **[削除]** をクリックして確認します。

アプリが少なくとも 1 つの予約名を持つ必要がある注意してください。 完全にダッシュ ボードからアプリを削除する (とそのアプリについて予約したすべての名前を離す)、**アプリの概要**ページから**このアプリを削除**をクリックします。 進行中のアプリの申請がある場合、まずその申請を削除する必要があります。 場合は、ストアにアプリを既に公開した、削除することはできません、ダッシュ ボードから (ただし、**概要**ページで、**製品の表示/非表示**の機能を使用するには非表示にする) に注意してください。 


## <a name="rename-an-app-that-has-already-been-published"></a>公開済みアプリの名前の変更

既にストアで公開されているアプリの名前を変更する場合は、(前に説明した手順に従って) アプリの新しい名前を予約し、アプリの新しい申請を作成することによってアプリ名を変更できます。 

新しいで、以前の名前を置き換えるし、申請を更新されたパッケージをアップロードするアプリのパッケージを更新する必要があります。
- 最初に、手動または Visual Studio を使って、新しい名前を使用する、Package.StoreAssociation.xml ファイルを更新 (**プロジェクト > ストア >... ストアと関連付ける**)。詳しくは、 [Visual Studio で UWP アプリのパッケージ](../packaging/packaging-uwp-apps.md)を参照してください。
- アプリ マニフェストの [**Package/Properties/DisplayName**](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-displayname) 要素を更新する必要があります。アプリの名前を含むすべてのグラフィックスとテキストを更新してください。 
  > [!IMPORTANT]
  > 必ず、アプリのマニフェストの **Package/Properties/DisplayName** を変更する前に、Package.StoreAssociation.xml ファイルを更新してください。そうしないと、エラーが発生する可能性があります。

ストア登録情報を新しい名前を使うように更新するには、[ストア登録情報ページ](create-app-store-listings.md)のその言語に移動し、[**製品名**] ドロップダウンから名前を選択します。 必ずを説明し、名前のすべての参照用の登録情報の他の部分を確認し、必要な場合は、更新を行います。

> [!NOTE]
> アプリに複数の言語パッケージやストア登録情報が含まれる場合は、パッケージの更新や更新する名前が必要なすべての言語の登録情報を格納する必要があります。

新しい名前でアプリを公開すると、古い名前を使用する必要がなくなりましたを削除することができます。

> [!TIP]
> 各アプリに予約されている最初の名前を使用して、ダッシュ ボードが表示されます。 アプリの名前を変更する上記の手順に従った新しい名前を使用して、ダッシュ ボードで表示したい場合は、(**削除**ページをクリックして、**アプリ名の管理**) 元の名前を削除する必要があります。 

 

 




