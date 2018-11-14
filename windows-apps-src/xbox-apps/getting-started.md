---
author: Mtoepke
title: Xbox One の UWP アプリ開発の概要
description: UWP 開発のために PC と Xbox One を設定する方法。
ms.author: scotmi
ms.date: 10/12/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4761b668877af6380ad176e56fb84410a4f509fc
ms.sourcegitcommit: 38f06f1714334273d865935d9afb80efffe97a17
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/09/2018
ms.locfileid: "6185022"
---
# <a name="getting-started-with-uwp-app-development-on-xbox-one"></a>Xbox One の UWP アプリ開発の概要

ユニバーサル Windows プラットフォーム (UWP) 開発のために PC と Xbox One を設定する方法の手順に**注意深く**従います。 この設定の完了後に、Xbox One の開発者モードと UWP アプリの構築について詳しくは、「[Xbox One の UWP](index.md)」ページをご覧ください。 

## <a name="before-you-start"></a>開始前の作業

開始する前に、次の操作をする必要があります。
-   最新バージョンの Windows 10 での PC を設定します。
<!-- -  Install Microsoft Visual Studio 2015 Update 3 or Microsoft Visual Studio 2017.

    > [!NOTE]
    > Visual Studio 2017 is required if you are using the Windows 10, build 15063 SDK. -->

- Xbox One 本体上に少なくとも 5 GB の空き領域が必要です。

## <a name="setting-up-your-development-pc"></a>開発用 PC のセットアップ

1.  Visual Studio 2015 Update 3 または Visual Studio 2017 をインストールします。

    Visual Studio 2015 Update 3 をインストールしている場合は、既定のインストールの一部ではないこと:**カスタム**インストールを選択して、**ユニバーサル Windows アプリ開発ツール**のチェック ボックスをオンを確認します。 C++ 開発者の場合は、**カスタム インストール**と **C++** を選択してください。

    Visual Studio 2017 をインストールする場合、必ず**ユニバーサル Windows プラットフォーム開発**ワークロードを選択してください。 場合 C++ 開発者が、右側の [**概要**] ウィンドウで、**ユニバーサル Windows プラットフォーム開発**、必ず**C++ ユニバーサル Windows プラットフォーム ツール**のチェック ボックスを選択すること。 既定のインストールの一部ではありません。

    詳細については、 [UWP Xbox の開発環境をセットアップ](development-environment-setup.md)を参照してください。

2.  最新の[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk)をインストールします。

3.  開発用 PC の開発者モードを有効にする (**設定/更新とセキュリティ]、[開発者開発者向け機能を使用して//開発者モード**)。

これで開発用 PC の準備は完了です。次のビデオをご覧ください。続きのセクションでは、Xbox One を開発用に設定し、UWP アプリを作成して展開する方法について説明します。
</br>
</br>
<iframe src="https://channel9.msdn.com/Events/Xbox/App-Dev-on-Xbox/Get-started-with-App-Dev-on-Xbox/player#time=51s:paused" width="600" height="338"  allowFullScreen frameBorder="0"></iframe>

## <a name="setting-up-your-xbox-one-console"></a>Xbox One 本体の設定

1.  Xbox One の開発者モードを有効にします。 アプリをダウンロード、アクティブ化コードを取得し、パートナー センターのアカウントで、 [Xbox One 本体の管理](https://partner.microsoft.com/xboxactivate)ページに入力します。 詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。 

2.  **開発者モードのアクティブ化用**アプリを開き、**切り替えと再起動**を選択します。 これで Xbox One は開発者モードとなりました。
  
  > [!NOTE]
  > 市販のゲームやアプリは開発者モードでは実行できません。自分で作成するアプリまたはゲームを実行できます。 市販のゲームやアプリを実行するには、リテール モードに切り替えます。
    
  > [!NOTE]
  > 開発者モードでアプリを Xbox One に展開するには、ユーザーを本体にサインインさせる必要があります。 既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。 

## <a name="creating-your-first-project-in-visual-studio"></a>Visual Studio での初めてのプロジェクトの作成

詳細については、 [UWP Xbox の開発環境をセットアップ](development-environment-setup.md)を参照してください。

1.  **C# の**: 新しいユニバーサル Windows プロジェクトを作成し、**ソリューション エクスプ ローラー**でプロジェクトを右クリックし、**プロパティ**を選択します。 [**デバッグ**] タブを選択して、**ターゲット デバイス**を**リモート コンピューター**に変更、**リモート コンピューター** ] フィールドに IP アドレスまたは Xbox One 本体のホスト名を入力、および、**で**ユニバーサル (暗号化されていないプロトコル)** を選択認証モード**ドロップダウン リスト。   

    本体で Dev Home (ホーム画面の右側の大きなタイル) を開始すると、左上隅に Xbox One の IP アドレスが表示されます。 Dev Home について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。  

2.  **C++ と Html/javascript プロジェクト**: と同様のパスを実行する c# プロジェクトの場合は、プロジェクトのプロパティで、[**デバッグ**] タブに移動、ドロップダウン リストを開き、IP アドレスまたはホスト名の入力をデバッガーで**リモート コンピューター**を選択します**コンピューター名**] と [**ユニバーサル (暗号化されていないプロトコル)** **認証の種類**のフィールドに本体です。

3. 上部のメニュー バーで、緑色の再生ボタンの左側のドロップダウン リストから**x64**を選びます。
   
4.  F5 キーを押してアプリをビルドして、Xbox One での展開を開始します。
  
5.  初めてこれを行う際には、Visual Studio に Xbox One の PIN の入力を求められます。 Xbox One で Dev Home を開始して、 **Visual Studio pin の表示**] ボタンを選択して、PIN を取得できます。
  
6.  ペアリングを行うと、アプリの展開が開始されます。 初めてこれを行う際には、(すべてのツールを Xbox にコピーする必要があるため) 少し時間がかかることがありますが、数分以上かかる場合には、何か問題がある場合があります。 上記のすべての手順を実行していることを確認します (特に **[認証モード]** を **[ユニバーサル]** に設定していることを確認します)。また Xbox One に有線接続していることを確認します。  

7. 用意ができました。 本体での初めてのアプリの実行をお楽しみください。  

## <a name="thats-it"></a>以上で作業は終了です。

![Hello World](images/getting-started-hello-world.png)

## <a name="see-also"></a>関連項目  
- [よく寄せられる質問](frequently-asked-questions.md)  
- [Xbox 開発者プログラムの UWP の既知の問題](known-issues.md)
- [Xbox One の UWP](index.md) 
