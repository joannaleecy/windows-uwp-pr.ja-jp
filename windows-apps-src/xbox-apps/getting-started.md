---
author: Mtoepke
title: "Xbox One の UWP アプリ開発の概要"
description: "UWP 開発のために PC と Xbox One を設定する方法。"
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 6e033ffa-502e-4daa-b5b2-6f853f68b66c
ms.openlocfilehash: 5b70e6376dbea0e3858a2a12542ff26dfe61ed20
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
#<a name="getting-started-with-uwp-app-development-on-xbox-one"></a>Xbox One の UWP アプリ開発の概要

ユニバーサル Windows プラットフォーム (UWP) 開発のために PC と Xbox One を設定する方法の手順に**注意深く**従います。 この設定の完了後に、Xbox One の開発者モードと UWP アプリの構築について詳しくは、「[Xbox One の UWP](index.md)」ページをご覧ください。 

## <a name="before-you-start"></a>開始前の作業
開始する前に、次の操作をする必要があります。
-    Windows 10 で PC を設定します。
-    Microsoft Visual Studio2015 Update3 をインストールします。
- Xbox One 本体上に少なくとも 5 GB の空き領域が必要です。

## <a name="setting-up-your-development-pc"></a>開発用 PC のセットアップ
1.    Visual Studio 2015 Update をインストールします。 既定のインストールには含まれていないため、**カスタム** インストールを選択し、**[ユニバーサル Windows アプリ開発ツール]** チェック ボックスをオンにします。 C++ 開発者の場合は、**カスタム インストール**と **C++** を選択してください。 詳しくは、「[開発環境のセットアップ](development-environment-setup.md)」をご覧ください。 

2.    最新の Windows 10 SDK をインストールします。 これは [https://developer.microsoft.com/windows/downloads/windows-10-sdk](https://developer.microsoft.com/windows/downloads/windows-10-sdk) から入手できます。

3.  開発用 PC の開発者モードを有効にします ([設定] / [更新とセキュリティ] / [開発者向け] / [開発者モード])。

## <a name="setting-up-your-xbox-one-console"></a>Xbox One 本体の設定
1.    Xbox One の開発者モードを有効にします。 アプリをダウンロードして、アクティブ化コードを取得し、デベロッパー センターのアカウントを使って、xboxactivate ページでそれを入力します。 詳しくは、「[Xbox One で開発者モードを有効にする](devkit-activation.md)」をご覧ください。 

2.    開発者モードのアクティブ化のアプリに移動し、**[切り替えと再起動]** を選択します。 これで Xbox One は開発者モードとなりました。
  
  > [!NOTE]
  > 市販のゲームやアプリは開発者モードでは実行できません。自分で作成するアプリまたはゲームを実行できます。 市販のゲームやアプリを実行するには、リテール モードに切り替えます。
    
  > [!NOTE]
  > 開発者モードでアプリを Xbox One に展開するには、ユーザーを本体にサインインさせる必要があります。 既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。 

## <a name="creating-your-first-project-in-visual-studio-2015"></a>Visual Studio 2015 の初めてのプロジェクトの作成

詳しくは、「[開発環境のセットアップ](development-environment-setup.md)」をご覧ください。

1.    **C# の場合**: 新しいユニバーサル Windows プロジェクトを作成し、プロジェクトのプロパティに移動して、**[デバッグ]** タブを選択し、**[ターゲット デバイス]** を **[リモート コンピューター]** に変更して、Xbox One コンソールの IP アドレスまたはホスト名を **[リモート コンピューター]** フィールドに入力し、**[認証モード]** のドロップダウン リストで **[ユニバーサル (暗号化されていないプロトコル)]** を選択します。   

    本体で Dev Home (ホーム画面の右側の大きなタイル) を開始すると、左上隅に Xbox One の IP アドレスが表示されます。 Dev Home について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。  

2.    **C++ と HTML/Javascript プロジェクトの場合**: 同様の手順を行いますが、プロジェクトのプロパティで **[デバッグ]** タブに移動し、デバッガーで **[リモート コンピューター]** を選択してドロップダウン リストを開き、**[コンピューター名]** フィールドに本体の IP アドレスまたはホスト名を入力して、**[認証の種類]** フィールドで **[ユニバーサル (暗号化されていないプロトコル)]** を選びます。
   
3.    F5 キーを押してアプリをビルドして、Xbox One での展開を開始します。
  
4.    初めてこれを行う際には、Visual Studio に Xbox One の PIN の入力を求められます。 Xbox One で Dev Home を開始して、**[Pair with Visual Studio]** ボタンを選択すると PIN を取得できます。
  
5.    ペアリングを行うと、アプリの展開が開始されます。 初めてこれを行う際には、(すべてのツールを Xbox にコピーする必要があるため) 少し時間がかかることがありますが、数分以上かかる場合には、何か問題がある場合があります。 上記のすべての手順を実行していることを確認します (特に **[認証モード]** を **[ユニバーサル]** に設定していることを確認します)。また Xbox One に有線接続していることを確認します。  

6. 用意ができました。 本体での初めてのアプリの実行をお楽しみください。  

## <a name="thats-it"></a>以上で作業は終了です。

![Hello World](images/getting-started-hello-world.png)

## <a name="see-also"></a>参照  
- [FAQ](frequently-asked-questions.md)  
- [既知の問題](known-issues.md)
- [Xbox One の UWP](index.md) 
