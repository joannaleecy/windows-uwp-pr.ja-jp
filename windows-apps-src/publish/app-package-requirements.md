---
Description: Microsoft Store に申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。
title: アプリ パッケージの要件
ms.assetid: 651B82BA-9D0C-45AC-8997-88CD93DC903C
ms.date: 10/31/2018
ms.topic: article
keywords: windows 10, uwp, パッケージ要件, パッケージ, パッケージ形式, サポートされているバージョン, 提出
ms.localizationpriority: medium
ms.openlocfilehash: 1c04ac5aa12fc67cf911d575540b05f96753519b
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57625247"
---
# <a name="app-package-requirements"></a>アプリ パッケージの要件

Microsoft Store に申請するために、次のガイドラインに従ってアプリのパッケージを準備してください。

## <a name="before-you-build-your-apps-package-for-the-microsoft-store"></a>Microsoft Store に向けてアプリのパッケージを構築する前に

[Windows アプリ認定キットでアプリをテスト](../debug-test-perf/windows-app-certification-kit.md) したことを確認してください。 また、さまざまな種類のハードウェアでアプリをテストすることをお勧めします。 アプリが認定され、Microsoft Store から入手できるようになるまでの間、アプリをインストールして実行できるのは、開発者用ライセンスを持つコンピューター上のみになります。

## <a name="building-the-app-package-using-microsoft-visual-studio"></a>Microsoft Visual Studio を使ったアプリ パッケージのビルド

開発環境として Microsoft Visual Studio を使っている場合は、アプリ パッケージを迅速かつ簡単に作成するための組み込みツールが既に用意されています。 詳しくは、「[アプリのパッケージ化](../packaging/index.md)」をご覧ください。

> [!NOTE]
> すべてのファイル名に ANSI を使っていることを確認してください。 

Visual Studio でパッケージを作るときは、必ず、開発者アカウントに関連付けられている同じアカウントでサインインしてください。 パッケージ マニフェストの一部には、お使いのアカウントに関連する固有の詳細情報が含まれています。 この情報は自動的に検出されて追加されます。 マニフェストにこの追加情報が追加されていない場合、パッケージのアップロードでエラーが発生する可能性があります。 

アプリの UWP パッケージをビルドするときに Visual Studio は、.msix または appx ファイル、または .msixupload または .appxupload ファイルを作成できます。 UWP アプリはお勧めしますで .msixupload または .appxupload ファイルを常にアップロードすること、[パッケージ](upload-app-packages.md)ページ。 Microsoft Store 用の UWP アプリのパッケージ化について詳しくは、「[Visual Studio での UWP アプリのパッケージ化](../packaging/packaging-uwp-apps.md)」をご覧ください。

アプリのパッケージに、信頼された証明機関が発行する証明書で署名する必要はありません。


### <a name="app-bundles"></a>アプリ バンドル

UWP アプリでは、Visual Studio は (.msixbundle または .appxbundle)、ユーザーがダウンロードするアプリのサイズを小さく、アプリ バンドルを生成できます。 その利便性が発揮されるのは、言語固有のアセットや多様な画像倍率のアセット、特定バージョンの Microsoft DirectX に適用されるリソースを定義した場合などです。

> [!NOTE]
> 1 つのアプリ バンドルには、すべてのアーキテクチャ、パッケージを含めることができます。

アプリ バンドルが使われている場合、ユーザーは、自分に関係したファイルだけをダウンロードすればよく、すべてのリソースをダウンロードする必要はありません。 アプリ バンドルについて詳しくは、「[アプリのパッケージ化](../packaging/index.md)」と「[Visual Studio で UWP アプリをパッケージ化する](../packaging/packaging-uwp-apps.md)」をご覧ください。


## <a name="building-the-app-package-manually"></a>手動によるアプリ パッケージのビルド

パッケージの作成に Visual Studio を使わない場合は、[パッケージ マニフェストを手動で作成](https://docs.microsoft.com/uwp/schemas/appxpackage/how-to-create-a-package-manifest-manually) する必要があります。

マニフェストの詳細や要件については、[アプリ パッケージ マニフェスト](https://docs.microsoft.com/uwp/schemas/appxpackage/appx-package-manifest) に関するドキュメントをご覧ください。 認定に合格するには、マニフェストがパッケージ マニフェスト スキーマに従っている必要があります。

マニフェストには、アカウントとアプリに関するいくらかの具体的な情報を含める必要があります。 この情報は、ダッシュボードにあるアプリの概要ページの **[アプリの管理]** セクションで [アプリの ID の詳細情報を表示する](view-app-identity-details.md) ことで確認できます。

> [!NOTE]
> マニフェストの値は大文字小文字を区別します。 スペースや句読点なども一致する必要があります。 注意して入力し、間違いがないか確認してください。


アプリケーション バンドル (.msixbundle または .appxbundle) は、異なるマニフェストを使用します。 アプリ バンドル マニフェストの詳細や要件については、[バンドル マニフェスト](https://docs.microsoft.com/uwp/schemas/bundlemanifestschema/bundle-manifest)に関するドキュメントをご覧ください。 .Msixbundle または .appxbundle では、含まれている各パッケージのマニフェストする必要がありますを使用した同じ要素と属性を除く、 **ProcessorArchitecture**の属性、 [Identity](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-identity)要素。

> [!TIP]
> 必ず実行して、 [Windows アプリ認定キット](../debug-test-perf/windows-app-certification-kit.md)パッケージを送信する前にします。 これによって、認定や提出の失敗の原因となる可能性がある問題がマニフェストに含まれているかどうかを判断できます。


## <a name="package-format-requirements"></a>パッケージの形式の要件

アプリのパッケージは、次の要件に準拠している必要があります。

| アプリ パッケージの性質 | 要件                                                          |
|----------------------|----------------------------------------------------------------------|
| パッケージのサイズ         | .msixbundle または .appxbundle:バンドルあたり 25 GB の最大数 <br>Windows 10 を対象とする .msix または .appx パッケージ:パッケージあたり 25 GB の最大数<br>.appx パッケージ、Windows 8.1 を対象とします。1 つのパッケージは最大 8 GB <br> .appx パッケージの対象とする Windows 8。1 つのパッケージは最大 2 GB <br> Windows Phone 8.1 を対象とする .appx パッケージ:1 つのパッケージは最大 4 GB <br> .xap パッケージ:1 つのパッケージは最大 1 GB                                                                           |
| ブロック マップ ハッシュ     | SHA2-256 アルゴリズム                                                   |

> [!IMPORTANT]
> 2018 年 10 月 31 日の時点で、新しく作成された製品が Windows 8.x/Windows を対象とするパッケージを含めることはできません Phone 8.x 以前のバージョン。 詳細については、「この[ブログの投稿](https://blogs.windows.com/buildingapps/2018/08/20/important-dates-regarding-apps-with-windows-phone-8-x-and-earlier-and-windows-8-8-1-packages-submitted-to-microsoft-store/#SzKghBbqDMlmAO4c.97)します。

## <a name="supported-versions"></a>サポートされているバージョン

UWP アプリの場合、すべてのパッケージは Microsoft Store によりサポートされている Windows 10 のバージョンをターゲットとする必要があります。 パッケージがサポートするバージョンは、アプリ マニフェストの [TargetDeviceFamily](https://docs.microsoft.com/uwp/schemas/appxpackage/uapmanifestschema/element-targetdevicefamily) 要素の **MinVersion** 属性と **MaxVersionTested** 属性で指定されています。

現時点でサポートされているバージョンの範囲は以下のとおりです。 
- 最小:10.0.10240.0
- 最大:10.0.17763.1


## <a name="storemanifest-xml-file"></a>StoreManifest XML ファイル

StoreManifest.xml は、必要に応じてアプリ パッケージに含めることのできる構成ファイルです。 その目的は、Microsoft Store デバイス アプリとしてアプリを宣言する機能や、パッケージ マニフェストの対象外となるデバイスに適用される要件を宣言する機能などを有効にすることです。 使用する場合、StoreManifest.xml はアプリ パッケージが送信され、アプリのメイン プロジェクトのルート フォルダーにある必要があります。 詳しくは、「[StoreManifest スキーマ](https://docs.microsoft.com/uwp/schemas/storemanifest/store-manifest-schema-portal)」をご覧ください。

 

 




