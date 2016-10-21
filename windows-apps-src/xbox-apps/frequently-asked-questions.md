---
author: Mtoepke
title: "よく寄せられる質問"
description: "Xbox の UWP についてのよく寄せられる質問。"
translationtype: Human Translation
ms.sourcegitcommit: 07e7ec6a5816d4b8d33322b2b1af05ffc3e1b820
ms.openlocfilehash: 38e5d48b2b0303b5f7d13fdaf6f71e1b3fa56978

---

# よく寄せられる質問

期待どおりに動作しない場合には、 このページのよく寄せられる質問を確認します。 また、「[既知の問題](known-issues.md)」と「[ユニバーサル Windows アプリの開発](https://social.msdn.microsoft.com/Forums/windowsapps/en-US/home?forum=wpdevelop)」のフォーラムも確認します。 

### 作成したゲームとアプリが動作しない

ゲームやアプリが動作しない場合、またストアや Live サービスにアクセスできない場合、開発者モードで実行している場合があります。 ホームを選択したときに画面の右側に、通常の Gold/Live コンテンツではなく、大きな Dev Home タイルが表示されている場合には、開発者モードで実行しています。 ゲームをプレイする場合には、Dev Home を開き、**[Leave developer mode] ** ボタンを使って、リテール モードに切り替えます。

### Visual Studio を使って Xbox One に接続できない

まず、リテール モードでなく、開発者モードで実行していることを確認します。 リテール モードでは、Xbox One に接続できません。 **[ホーム]** ボタンを押して、画面の右側に Dev Home タイルがあるかどうかを確認します。 Dev Home タイルがなく、Gold/Live コンテンツが表示されている場合には、リテール モードで実行されています。 開発者モードに切り替えるには、開発者モードのアクティブ化用アプリを実行する必要があります。

> [!NOTE]
> アプリを展開するには、ユーザーをサインインさせる必要があります。

詳しくは、このページの「[展開の失敗を修正する](#fixing-deployment-failures)」をご覧ください。

### リテール モードと開発者モードの切り替え方法

これらの状態について詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」の指示に従います。

### リテール モードと開発者モードのどちらで実行されているかを確認する方法

これらの状態について詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」の指示に従います。 

**[ホーム]** ボタンを押して、画面の右側を確認します。 開発者モードの場合は、右側にある Dev Home のタイルが表示されます。 リテール モードの場合は、通常の Gold/Live コンテンツが表示されます。

### 開発者モードをアクティブ化してもゲームやアプリは動作しますか

はい、開発者モードからリテール モードに切り替えて、ゲームをプレイできます。 詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。 

### ゲームやアプリ、保存した変更を失うことがありますか

開発者プログラムへの参加を停止しても、インストールしたゲームやアプリは失われません。 またオンラインでプレイした場合には、保存したゲームはすべて Live アカウントのクラウド プロファイルに保存されていますので、それを失うことはありません。

### 開発者プログラムへの参加を停止する方法

開発者プログラムへの参加を停止する方法について詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-deactivation.md)」をご覧ください。

### Xbox One を開発者モードにしたままで売却した場合に、 開発者モードを非アクティブ化する方法

Xbox One にアクセスできない場合には、Windows デベロッパー センターで非アクティブ化できます。 詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-deactivation.md#deactivate-your-console-through-windows-dev-center)」の「**Windows デベロッパー センターを使用したコンソールの非アクティブ化**」のセクションをご覧ください。

### Windows デベロッパー センターを使用して開発者プログラムを停止しましたが、まだ開発者モードのままです。 どうすればよいでしょうか。

Dev Home を開始し、**[Leave developer mode]** ボタンを選択します。 コンソールがリテール モードで再起動します。 

### 自分のアプリを公開できますか

[開発者アカウント](https://developer.microsoft.com/store/register)がある場合には、デベロッパー センターを使用して[アプリを公開](../publish/index.md)できます。 市販の Xbox One コンソールで作成されテストされた UWP アプリは、Windows で現在行われているものと同様の取り込み、レビュー、公開のプロセスが行われ、さらに Xbox One の標準を満たすための追加のレビューが行われます。

### 自分のゲームを公開できますか

UWP と Xbox One の開発者モードを使って、Xbox One でゲームの構築とテストを行えます。 UWP ゲームを公開するには、[ID@XBOX](http://www.xbox.com/Developers/id) で登録する必要があります。 
[ID@XBOX](http://www.xbox.com/Developers/id) では開発者は、ゲーム用の Xbox Live API のすべてにアクセスできます。これにはゲームスコア、達成度、デバイス間でのマルチ プレーヤーの活用、クラウドの保存など、Xbox One の Xbox Live のすべての機能が含まれます。 
さらに [ID@XBOX](http://www.xbox.com/Developers/id) は、ゲーム用の Xbox One 開発キットへのアクセスも提供します。これにより Xbox One のハードウェアの機能を最大限に活用できます。

### 標準的なゲーム エンジンは機能しますか

このリリースの「[既知の問題](known-issues.md)」ページを確認してください。

### Xbox One の UWP ゲームで利用可能な機能とシステム リソース 

詳しくは、「[Xbox One 上の UWP アプリとゲームのシステム リソース](system-resource-allocation.md)」をご覧ください。

### DirectX 12 の UWP ゲームを作成する場合、それは Xbox One の開発者モードで動作しますか

詳しくは、「[Xbox One 上の UWP アプリとゲームのシステム リソース](system-resource-allocation.md)」をご覧ください。

### Xbox では UWP API のすべてを利用できますか

このリリースの「[既知の問題](known-issues.md)」ページを確認してください。

### 展開の失敗を修正する

Visual Studio からアプリを展開できない場合、次の手順が問題の解決に役立つ場合があります。 それでも解決できない場合には、フォーラムに投稿してみます。

> [!NOTE]
> アプリを展開するには、ユーザーをサインインさせる必要があります。 0x87e10008 エラー メッセージが表示された場合は、ユーザーがサインインしているかどうかを確認し、もう一度サインインさせます。

Visual Studio が Xbox One に接続できない場合:

1. 開発者モードであることを確認します (このページで既に説明した方法を確認します)。
2. 開発用 PC が正しく設定されていることを確認します。 [Xbox One の UWP アプリ開発の概要](getting-started.md)の*すべての*指示に従いましたか。 

3. まだの場合、「[開発環境のセットアップ](development-environment-setup.md)」と「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をよくお読みください。

4. 開発用 PC から本体の IP アドレスに "ping" ができることを確認します。
  > [!NOTE]
  > 展開のパフォーマンスを最大限に引き出すために、本体には、有線接続を使用することをお勧めします。

5. **[デバッグ]** タブの [認証] ドロップダウン リストで [ユニバーサル (暗号化されていないプロトコル)] を使用していることを確認します。 詳しくは、「[開発環境のセットアップ](development-environment-setup.md)」をご覧ください。

<!--6. Make sure you are not hitting a PIN pairing issue; see "Visual Studio/Xbox PIN pairing failures" in the [Known Issues](known-issues.md) topic.-->

<!--
If Visual Studio can connect, but deployment is failing (for example you get this error message: "DEP0700 : Registration of the app failed.(0x80073cf9)"):

1. Make sure that your app is not installed by uninstalling it from the Collections app in the Xbox One shell. 

> **Note**&nbsp;&nbsp;Uninstalling your app from Windows Device Portal (WDP) will not resolve the issue.

2. If your issues persist, uninstall your app or game in the Collections app, leave Developer Mode, restart to Retail Mode, and then switch back to Developer Mode. 
This will clear Dev Storage.

3. If your issues persist, follow the steps above and then use **Reset and keep my games & apps** to delete any stored state on your Xbox One. 
Go to Settings > System > Console info & updates > Reset console, and select the **Reset and keep my games & apps** button.

> **Caution**&nbsp;&nbsp;Doing this will delete all saved settings on your Xbox One including wireless settings, user accounts and any game progress that has not been saved to cloud storage.

> **Caution**&nbsp;&nbsp;DO NOT select the **Reset and remove everything** button.
This will delete all of your games, apps, settings and content and deactivate Developer Mode.
-->

### HTML/JavaScript を使用したアプリを構築する場合に、ゲームパッドのナビゲーションを有効にする方法

TVHelpers は、JavaScript と XAML/C# のサンプルとライブラリです。JavaScript と C# による、Xbox One とテレビの優れたエクスペリエンスの構築をサポートします。 TVJS は Xbox One のための優れた UWP アプリの構築をサポートします。 TVJS には、自動コントローラー ナビゲーション、リッチ メディアの再生、検索などのサポートが含まれています。 ホストされた Web アプリで TVJS を使うと、パッケージ化された Web UWP アプリを使う場合のように容易に、すべての Windows ランタイム API にアクセスできます。

詳しくは、「[TVHelpers](https://github.com/Microsoft/TVHelpers) プロジェクトとプロジェクト [wiki](https://github.com/Microsoft/TVHelpers/wiki)」をご覧ください。

## 関連項目
- [Xbox One の UWP の既知の問題](known-issues.md)
- [Xbox One の UWP](index.md)



<!--HONumber=Aug16_HO5-->


