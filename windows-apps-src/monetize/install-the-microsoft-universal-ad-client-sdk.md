---
ms.assetid: 28C6D865-2A5C-4B64-82E3-49A862A36850
description: 広告メディエーター コントロールと開発者向け関連ツールは Microsoft ユニバーサル広告クライアント SDK に用意されています。
title: ユニバーサル広告クライアント SDK のインストール
---

# ユニバーサル広告クライアント SDK のインストール

\[ Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください \]

広告メディエーター コントロールと開発者向け関連ツールは Microsoft ユニバーサル広告クライアント SDK に用意されています。 この SDK は、Visual Studio 2013 や Visual Studio 2015 の拡張機能です。 SDK をインストールするには

1.  Visual Studio 2013 または Visual Studio 2015 のすべてのインスタンスを閉じて、広告メディエーター拡張機能または Microsoft Advertising SDK の以前のバージョンをアンインストールします。
2.  [Microsoft ユニバーサル広告クライアント SDK](http://go.microsoft.com/fwlink/p/?LinkId=518026) をダウンロードしてインストールします。 インストールには数分かかることがあります。 確実に処理が完了するまでお待ちください。
3.  Visual Studio を再起動します。

**注** Visual Studio 2015 の Microsoft ユニバーサル広告クライアント SDK をインストールするには、Visual Studio Tools for Universal Windows Apps のバージョン 1.1 以降がインストールされている必要があります。 Visual Studio Tools for Universal Windows Apps のこの更新について詳しくは、[リリース ノート](http://go.microsoft.com/fwlink/?LinkID=624516)をご覧ください。

## SDK の最新バージョンを使うように既存のプロジェクトを更新する

マイクロソフトでは定期的に、新しい広告仲介機能 (追加の広告ネットワークのサポートなど) を備えた Microsoft ユニバーサル広告クライアント SDK の新しいバージョンをリリースしています。 SDK の以前のバージョンを使っている既存のプロジェクトがあり、そのプロジェクトで最新バージョンを使う場合は、次の手順に従ってください。

1.  インストーラーの最新リリースを[ダウンロード](http://go.microsoft.com/fwlink/p/?LinkId=518026)して実行します。
2.  Visual Studio で既存の各プロジェクトを開き、再び「[広告ネットワークを構成する](add-and-use-the-ad-mediator-control.md#configure-ad-networks)」の手順に従って、アプリで使う各広告ネットワークを構成します。 このプロセスでは、広告ネットワークの各アセンブリの最新バージョンをインストールします。

Windows Phone 8 または Windows Phone 8.1 Silverlight プロジェクトがある場合は、次に示している追加の手順も実行して、広告メディエーター アセンブリの正しいバージョンがアプリで使われるようにします。

1.  Visual Studio でプロジェクトを開きます。
2.  **ソリューション エクスプローラー**で、**[参照設定]** を展開します。
3.  **[Microsoft.AdMediator.Core]** を右クリックし、**[プロパティ]** を選びます。
4.  **[特定バージョン]** プロパティを **[False]** に設定します。
5.  **[Microsoft.AdMediator.WindowsPhone8]** について手順 3. と 4. を繰り返します。

## 関連トピック

* [広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)
* [広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)
* [広告の仲介の実装のテスト](test-your-ad-mediation-implementation.md)
* [アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)
* [広告の仲介のトラブルシューティング](troubleshoot-ad-mediation.md)
 

 





<!--HONumber=Mar16_HO1-->


