---
title: Visual Studio を使ったアプリ インストーラー ファイルの作成
description: Visual Studio を使い、.appinstaller ファイルを使って自動更新を有効にする方法について説明します。
ms.date: 5/2/2018
ms.topic: article
keywords: Windows 10, uwp, アプリ インストーラー, AppInstaller, サイドローディング
ms.localizationpriority: medium
ms.openlocfilehash: 5c7055748eb8905341d9f90c47e6141c9c9c599e
ms.sourcegitcommit: b5c9c18e70625ab770946b8243f3465ee1013184
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/28/2018
ms.locfileid: "7978009"
---
# <a name="create-an-app-installer-file-with-visual-studio"></a>Visual Studio を使ったアプリ インストーラー ファイルの作成

Windows 10 バージョン 1804 と Visual Studio 2017 Update 15.7 以降では、`.appinstaller` ファイルを使って自動更新を受け取るようにサイドローディングされるアプリを構成できます。 Visual Studio では、このような更新の有効がサポートされています。

## <a name="app-installer-file-location"></a>アプリ インストーラー ファイルの場所
`.appinstaller`ファイルは、HTTP エンドポイントや UNC 共有フォルダーなどの共有の場所にホストでき、インストールするアプリ パッケージを見つけるためのパスが含まれています。 ユーザーは、共有の場所からアプリをインストールし、新しい更新プログラムの定期的なチェックを有効にします。 


### <a name="configure-the-project-to-target-the-correct-windows-version"></a>適切な Windows バージョンをターゲットとするプロジェクトの構成

`TargetPlatformMinVersion` プロパティは、プロジェクトを作成するときに構成するか、後でプロジェクトのプロパティから変更できます。 

>[!IMPORTANT]
> アプリ インストーラー ファイルは、`TargetPlatformMinVersion` が Windows 10 バージョン 1804 以上の場合にのみ生成されます。


### <a name="create-packages"></a>パッケージの作成

サイドローディングを通じてアプリを配布するには、アプリ パッケージ (.appx/.msix) またはアプリ バンドル (.appxbundle/.msixbundle) を作成し、共有の場所に公開する必要があります。

これを行うには、Visual Studio で**アプリ パッケージの作成**ウィザードを使って手順に従います。

1. プロジェクトを右クリックし、**[Microsoft Store]**  ->  **[アプリ パッケージの作成]** の順に選択します。  

![コンテキスト メニューと [アプリ パッケージの作成] へのナビゲーション](images/packaging-screen2.jpg)   

**アプリ パッケージの作成**ウィザードが表示されます。

2. **[I want to create packages for sideloading]** (サイドローディング用のパッケージを作成する) と **[自動更新を有効にする]** をオンにします。  

![[パッケージの作成] ダイアログ ウィンドウ](images/select-sideloading.png)  

**[自動更新を有効にする]** は、プロジェクトの `TargetPlatformMinVersion` が正しいバージョンの Windows 10 に設定されている場合のみオンになります。

3. **[パッケージの選択と構成]** ダイアログ ボックスでは、サポートされているアーキテクチャ構成を選択できます。 バンドルを選択した場合、単一のインストーラーが生成されますが、バンドルではなくアーキテクチャごとに 1 つのパッケージが必要な場合、アーキテクチャごとにも 1 つのインストーラー ファイルが生成されます。  どのアーキテクチャを選べばよいかわからない場合や、各種デバイスにより使用されるアーキテクチャについて詳しく調べる場合は、「[アプリ パッケージのアーキテクチャ](device-architecture.md)」をご覧ください。

4. バージョンの番号付けやパッケージの出力場所など、他の詳細情報を構成します。

![[アプリ パッケージの作成] ウィンドウのパッケージ構成画面](images/packaging-screen5.jpg)  

5. 手順 2 で **[自動更新を有効にする]** をオンにした場合、**[更新設定の構成]** ダイアログ ボックスが表示されます。 ここでは、**[インストールの URL]** と更新チェックの頻度を指定できます。

![[更新設定の構成] ウィンドウの公開場所の構成画面](images/sideloading-screen.png)  

6. アプリが正常にパッケージ化されると、ダイアログ ボックスにアプリ パッケージを含む出力フォルダーの場所が表示されます。 出力フォルダーには、アプリの宣伝に使用できる HTML ページなど、アプリのサイドローディングに必要なすべてのファイルが含まれています。

### <a name="publish-packages"></a>パッケージの公開

アプリケーションを利用可能にするには、生成されたファイルを指定した場所に公開する必要があります。

#### <a name="publish-to-shared-folders-unc"></a>共有フォルダー (UNC) への公開

汎用名前付け規則 (UNC) 共有フォルダーを使ってパッケージを公開する場合、アプリ パッケージの出力フォルダーとインストールの URL (詳しくは手順 6 を参照) を同じパスに構成します。 ウィザードにより、適切な場所にファイルが生成され、ユーザーは同じパスからアプリと今後の更新プログラムの両方を取得します。

#### <a name="publish-to-a-web-location-http"></a>Web 上の場所 (HTTP) への公開

Web 上の場所に公開するには、Web サーバーにコンテンツを公開するためのアクセス権が必要です。最終的な URL がウィザードで定義されたインストールの URL と一致することを確認してください (詳しくは手順 6 を参照)。 通常、ファイル転送プロトコル (FTP) または SSH ファイル転送プロトコル (SFTP) を使ってファイルをアップロードしますが、Web プロバイダーによっては MSDeploy、SSH、Blob ストレージなどの他の公開方法が用意されています。

Web サーバーを構成するには、使うファイルの種類に使用される MIME タイプを確認する必要があります。 この例では、インターネット インフォメーション サービス (IIS) の `web.config` です。

```xml
<configuration>
  <system.webServer>
    <staticContent>
      <mimeMap fileExtension=".appx" mimeType="application/vns.ms-appx" />
      <mimeMap fileExtension=".appxbundle" mimeType="application/vns.ms-appx" />
      <mimeMap fileExtension=".appinstaller" mimeType="application/xml" />
    </staticContent>  
  </system.webServer>  
</configuration>
```




















