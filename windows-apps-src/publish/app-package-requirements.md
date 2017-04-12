---
author: jnHs
Description: "Windows ストアに申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。"
title: "アプリ パッケージの要件"
ms.assetid: 651B82BA-9D0C-45AC-8997-88CD93DC903C
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: 59660de0adb6ff1247ea90f0ace3bcca35f19d1a
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="app-package-requirements"></a>アプリ パッケージの要件

Windows ストアに申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。

## <a name="before-you-build-your-apps-package-for-the-windows-store"></a>Windows ストアに向けてアプリのパッケージを構築する前に

[Windows アプリ認定キットでアプリをテスト](https://msdn.microsoft.com/library/windows/apps/mt186449) したことを確認してください。 また、さまざまな種類のハードウェアでアプリをテストすることをお勧めします。 アプリが認定され、Windows ストアから入手できるようになるまでの間、アプリをインストールして実行できるのは、開発者用ライセンスを持つコンピューター上のみになります。

## <a name="building-the-app-package-using-microsoft-visual-studio"></a>Microsoft Visual Studio を使ったアプリ パッケージのビルド

開発環境として Microsoft Visual Studio を使っている場合は、アプリ パッケージを迅速かつ簡単に作成するための組み込みツールが既に用意されています。 詳しくは、「[アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/mt270969)」をご覧ください。

> **注**  すべてのファイル名に ANSI を使っていることを確認してください。 


Visual Studio でパッケージを作るときは、必ず、開発者アカウントに関連付けられている同じアカウントでサインインしてください。 パッケージ マニフェストの一部には、お使いのアカウントに関連する固有の詳細情報が含まれています。 この情報は自動的に検出されて追加されます。

アプリのパッケージをビルドする場合、Visual Studio では .appx ファイルまたは .appxupload ファイル (または、Windows Phone 8.1 以前の場合は .xap ファイル) を作成することができます。 Windows 10 を対象とするアプリの場合は、常に .appxupload ファイルを [パッケージ](upload-app-packages.md) ページにアップロードします。 ストア用の UWP アプリのパッケージ化について詳しくは、「[Windows 10 用ユニバーサル Windows アプリのパッケージ化](http://go.microsoft.com/fwlink/p/?LinkId=620193 )」をご覧ください。

アプリのパッケージに、信頼された証明機関が発行する証明書で署名する必要はありません。

### <a name="app-bundles"></a>アプリ バンドル

アプリの対象が Windows 8.1、Windows Phone 8.1、およびそれ以降である場合は、Visual Studio でアプリ バンドル (.appxbundle) を生成することによって、ユーザーがダウンロードするアプリのサイズを小さくすることができます。 その利便性が発揮されるのは、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースを定義した場合などです。

> **注**  1 つのアプリ バンドルには、すべてのアーキテクチャ用のパッケージを含めることができます。 対象 OS ごとにバンドルを 1 つだけ申請する必要があります。


アプリ バンドルが使われている場合、ユーザーは、自分に関係したファイルだけをダウンロードすればよく、すべてのリソースをダウンロードする必要はありません。 アプリ バンドルについて詳しくは、「[アプリのパッケージ化](https://msdn.microsoft.com/library/windows/apps/mt270969)」と「[Windows 10 用ユニバーサル Windows アプリのパッケージ化](http://go.microsoft.com/fwlink/p/?LinkId=620193 )」をご覧ください。

## <a name="building-the-app-package-manually"></a>手動によるアプリ パッケージのビルド

パッケージの作成に Visual Studio を使わない場合は、[パッケージ マニフェストを手動で作成](https://msdn.microsoft.com/library/windows/apps/br211476) する必要があります。

マニフェストの詳細や要件については、[アプリ パッケージ マニフェスト](https://msdn.microsoft.com/library/windows/apps/br211474) に関するドキュメントをご覧ください。 認定に合格するには、マニフェストがパッケージ マニフェスト スキーマに従っている必要があります。

マニフェストには、アカウントとアプリに関するいくらかの具体的な情報を含める必要があります。 この情報は、ダッシュボードにあるアプリの概要ページの [**アプリの管理**] セクションで [アプリの ID の詳細情報を表示する](view-app-identity-details.md) ことで確認できます。

> **注**  マニフェスト内の値は、大文字と小文字が区別されます。 スペースや句読点なども一致する必要があります。 注意して入力し、間違いがないか確認してください。


アプリ バンドルには、特別なマニフェストが使われます。 アプリ バンドル マニフェストの詳細や要件については、[バンドル マニフェスト](https://msdn.microsoft.com/library/windows/apps/dn263089) に関するドキュメントをご覧ください。

> **ヒント**  [Windows アプリ認定キット](https://msdn.microsoft.com/library/windows/apps/mt186449)を実行してから、パッケージを提出してください。 これによって、認定や提出の失敗の原因となる可能性がある問題がマニフェストに含まれているかどうかを判断できます。


アプリに複数のパッケージがある場合、以下のアプリ マニフェストの要素は各パッケージで (ターゲット OS ごとに) 同じである必要があります。

-   [**Package/Capabilities**](https://msdn.microsoft.com/library/windows/apps/br211422)
-   [**Package/Dependencies**](https://msdn.microsoft.com/library/windows/apps/br211428)
-   [**Package/Resources**](https://msdn.microsoft.com/library/windows/apps/br211462)

## <a name="package-format-requirements"></a>パッケージの形式の要件

アプリのパッケージは、次の要件に準拠している必要があります。

| アプリ パッケージの性質 | 要件                                                          |
|----------------------|----------------------------------------------------------------------|
| パッケージのサイズ         | .appxbundle: バンドルあたり最大 25 GB <br>Windows 10 を対象とする .appx パッケージ: パッケージあたり最大 25 GB<br>Windows 8.1 を対象とする .appx パッケージ: パッケージあたり最大 8 GB <br> Windows 8 を対象とする .appx パッケージ: パッケージあたり最大 2 GB <br> Windows Phone 8.1 を対象とする .appx パッケージ: パッケージあたり最大 4 GB <br> .xap パッケージ: パッケージあたり最大 1 GB                                                                           |
| ブロック マップ ハッシュ     | SHA2-256 アルゴリズム                                                   |
 

## <a name="storemanifest-xml-file"></a>StoreManifest XML ファイル

StoreManifest.xml は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。 その目的は、Windows ストア デバイス アプリとしてアプリを宣言する機能や、パッケージ マニフェストの対象外となるデバイスに適用される要件を宣言する機能などを有効にすることです。 StoreManifest.xml はアプリ パッケージと共に提出し、アプリのメイン プロジェクトのルート フォルダーにあることが必要です。 詳しくは、「[StoreManifest スキーマ](https://msdn.microsoft.com/library/windows/apps/mt617325)」をご覧ください。

 

 




