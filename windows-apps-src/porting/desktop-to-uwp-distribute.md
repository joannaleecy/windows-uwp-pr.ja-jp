---
author: normesta
Description: "Desktop to UWP Bridge を使用して変換した UWP アプリを配布する"
Search.Product: eADQiWindows 10XVcnh
title: "Desktop to UWP Bridge での配布"
ms.author: normesta
ms.date: 03/09/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: edff3787-cecb-4054-9a2d-1fbefa79efc4
ms.openlocfilehash: ee38bd22b6d4737cf5bb64eb489365e3f83efd53
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="desktop-to-uwp-bridge-distribute"></a>Desktop to UWP Bridge: 配布

変換済みのアプリを展開する主な方法としては、Windows ストア、サイドローディング、ルーズ ファイルの登録の 3 種類があります。  

## <a name="windows-store"></a>Windows ストア

Windows ストアは、お客様がアプリを取得する場合に最も便利な方法です。 始めるには、まず「[Desktop Bridge を活用して、既存のアプリやゲームを Windows ストアに移行しましょう](https://developer.microsoft.com/windows/projects/campaigns/desktop-bridge)」のフォームに記入してください。 Microsoft から、オンボード プロセスを開始するためのご連絡があります。

アプリやゲームを Windows ストアに公開するには、そのアプリやゲームの開発者または発行元である必要があります。 このため、開発者または発行元であるかどうかを Microsoft が検証できるように、URL 以下で URL として申請する Web サイトに名前とメール アドレスが合致していることを確認してください。

## <a name="sideloading"></a>サイドローディング

サイドローディングは、複数のコンピューターに展開するための簡単な手段です。 特に、配布エクスペリエンスに対するきめ細かい制御を要し、ストア証明書の使用が望ましくないエンタープライズ/基幹業務 (LOB) のシナリオでは特に便利です。

アプリをサイドローディングで展開する前に、証明書でアプリに署名する必要があります。 証明書の作成方法の詳細については、「[Windows アプリ パッケージに署名する](https://msdn.microsoft.com/windows/uwp/porting/desktop-to-uwp-run-desktop-app-converter#deploy-your-converted-appx)」をご覧ください。

ここでは、以前に作成した証明書をインポートする方法を説明します。 証明書は、直接 CERTUTIL を使ってインポートするか、または顧客と同じように、署名済みの Windows アプリ パッケージからインストールすることができます。

CERTUTIL を使って証明書をインストールするには、管理者のコマンド プロンプトから次のコマンドを実行します。

```cmd
Certutil -addStore TrustedPeople <testcert.cer>
```

顧客が行うように、Windows アプリ パッケージから証明書をインポートするには、次のようにします。

1.    ファイル エクスプローラーで、テスト証明書で署名した Windows アプリ パッケージを右クリックして、コンテンツメニューから **[プロパティ]** を選択します。
2.    [**デジタル署名**] タブをクリックまたはタップします。
3.    証明書をクリックまたはタップして、[**詳細**] を選択します。
4.    [**証明書の表示**] をクリックまたはタップします。
5.    [**証明書のインストール**] をクリックまたはタップします。
6.    [**ストアの場所**] グループで、[**ローカル マシン**] を選択します。
7.    [**次へ**] と [**OK**] をクリックまたはタップして、UAC ダイアログ ボックスを確認します。
8.    証明書のインポート ウィザードの次の画面で、選択されているオプションを [**証明書をすべて次のストアに配置する**] に変更します。
9.    **[参照]** をクリックまたはタップします。 [証明書ストアの選択] ウィンドウで下へスクロールし、**[信頼されたユーザー]** を選択してから、**[OK]** をクリックまたはタップします。
10.    **[次へ]** をクリックまたはタップします。 新しい画面が表示されます。 **[完了]** をクリックまたはタップします。
11.    確認のダイアログ ボックスが表示されます。 確認のダイアログ ボックスが表示されたら、**[OK]** をクリックします。 別のダイアログが表示され、証明書に問題があることが示された場合は、証明書のトラブルシューティングを行う必要があります。

注: Windows で証明書を信頼するには、証明書を **[証明書 (ローカル コンピューター)] > [信頼されたルート証明機関] > [証明書]** ノードまたは **[証明書 (ローカル コンピューター)] > [信頼されたユーザー] > [証明書]** ノードのどちらかに配置します。 これら 2 つの場所にある証明書だけが、ローカル コンピューターのコンテキストで証明書の信頼性を検証できます。 それ以外の場合、次の文字列のようなエラー メッセージが表示されます。

```CMD
"Add-AppxPackage : Deployment failed with HRESULT: 0x800B0109, A certificate chain processed,
but terminated in a rootcertificate which is not trusted by the trust provider.
(Exception from HRESULT: 0x800B0109) error 0x800B0109: The root certificate of the signature
in the app package must be trusted."
```

証明書が信頼されると、2 つの方法でパッケージをインストールできます。PowerShell を使用するか、または Windows アプリ パッケージ ファイルをダブルクリックしてインストールします。  PowerShell を使ってインストールするには、次のコマンドレットを実行します。

```powershell
Add-AppxPackage <MyApp>.appx
```

### <a name="loose-file-registration"></a>ルーズ ファイルの登録

ルーズ ファイルの登録は、ファイルがディスク上の容易にアクセス可能な場所に配置されており、署名や証明書を必要としない場合に、デバッグのために役立ちます。  

開発中にアプリを展開するには、次の PowerShell コマンドレットを実行します。

```Add-AppxPackage –Register AppxManifest.xml```

アプリの .exe または .dll ファイルを更新するには、パッケージ内の既存のファイルを新しいファイルに置き換え、AppxManifest.xml のバージョン番号を増やして、上記のコマンドをもう一度実行します。

次の点に注意してください。

* 変換済みのアプリをインストールするドライブは、NTFS 形式にフォーマットしておく必要があります。
* 変換済みのアプリは、常に、対話ユーザーとして実行されます。
