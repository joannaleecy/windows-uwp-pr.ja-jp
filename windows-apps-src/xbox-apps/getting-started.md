---
title: Xbox One の UWP アプリ開発の概要
description: UWP 開発のために PC と Xbox One を設定する方法。
ms.date: 10/12/2017
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: c94d27e87853b570268e3a39fe941c817b3eda6a
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57590977"
---
# <a name="getting-started-with-uwp-app-development-on-xbox-one"></a>Xbox One の UWP アプリ開発の概要

ユニバーサル Windows プラットフォーム (UWP) 開発のために PC と Xbox One を設定する方法の手順に**注意深く**従います。 この設定の完了後に、Xbox One の開発者モードと UWP アプリの構築について詳しくは、「[Xbox one の UWP](index.md)」ページをご覧ください。 

## <a name="before-you-start"></a>開始前の作業

開始する前に、次の操作をする必要があります。
-   インストールされた最新のバージョンの Windows 10 PC を設定します。
<!-- -  Install Microsoft Visual Studio 2015 Update 3 or Microsoft Visual Studio 2017.

    > [!NOTE]
    > Visual Studio 2017 is required if you are using the Windows 10, build 15063 SDK. -->

- Xbox One 本体上に少なくとも 5 GB の空き領域が必要です。

## <a name="setting-up-your-development-pc"></a>開発用 PC のセットアップ

1.  Visual Studio 2015 Update 3 または Visual Studio 2017 をインストールします。

    Visual Studio 2015 Update 3 をインストールする場合は選択するように**カスタム**インストールし、選択、**ユニバーサル Windows アプリ開発ツール**– チェック ボックスは既定値の一部をインストールします。 C++ 開発者の場合は、**カスタム インストール**と **C++** を選択してください。

    Visual Studio 2017 をインストールする場合、必ず**ユニバーサル Windows プラットフォーム開発**ワークロードを選択してください。 C++ の開発者の場合、**概要**、右側のペインで**ユニバーサル Windows プラットフォーム開発**を選択することを確認、 **C++ ユニバーサル Windows プラットフォーム ツール**チェック ボックスをオンします。 既定のインストールの一部ではありません。

    詳細については、次を参照してください。 [Xbox 開発環境で、UWP 設定](development-environment-setup.md)します。

2.  最新のインストール[Windows 10 SDK](https://developer.microsoft.com/windows/downloads/windows-10-sdk)します。

3.  開発用 PC の開発者モードを有効にする (**設定/更新とセキュリティ]、[開発者向け]、[開発者向けの機能を使用して/開発者モード**)。

これで開発用 PC の準備は完了です。次のビデオをご覧ください。続きのセクションでは、Xbox One を開発用に設定し、UWP アプリを作成して展開する方法について説明します。
</br>
</br>
<iframe src="https://channel9.msdn.com/Events/Xbox/App-Dev-on-Xbox/Get-started-with-App-Dev-on-Xbox/player#time=51s:paused" width="600" height="338"  allowFullScreen frameBorder="0"></iframe>

## <a name="setting-up-your-xbox-one-console"></a>Xbox One 本体の設定

1.  Xbox One の開発者モードを有効にします。 アプリをダウンロードして、アクティブ化コードを取得しに入力、 **Xbox One の管理コンソール**パートナー センターのアプリの開発者アカウントでページ。 詳しくは、「[Xbox One の開発者モードのアクティブ化](devkit-activation.md)」をご覧ください。 

2.  開く、**開発モードのアクティブ化**アプリと選択**スイッチと再起動**します。 これで Xbox One は開発者モードとなりました。
  
  > [!NOTE]
  > 市販のゲームやアプリは開発者モードでは実行できません。自分で作成するアプリまたはゲームを実行できます。 市販のゲームやアプリを実行するには、リテール モードに切り替えます。
    
  > [!NOTE]
  > 開発者モードでアプリを Xbox One に展開するには、ユーザーを本体にサインインさせる必要があります。 既存の Xbox Live アカウントを使用することも、開発者モードで本体の新しいアカウントを作成することもできます。 

## <a name="creating-your-first-project-in-visual-studio"></a>Visual Studio での最初のプロジェクトの作成

詳細についてを参照してください。 [Xbox 開発環境で、UWP 設定](development-environment-setup.md)します。

1.  **C#** :新しいユニバーサル Windows プロジェクトを作成し、**ソリューション エクスプ ローラー**プロジェクトを右クリックし、選択、**プロパティ**します。 選択、**デバッグ** タブで、変更**ターゲット デバイス**に**リモート コンピューター**、IP アドレスまたはホスト名に Xbox One、コンソールの入力、**リモート コンピューター**フィールド、および select**ユニバーサル (暗号化されていないプロトコル)** で、**認証モード**ドロップダウン リスト。   

    本体で Dev Home (ホーム画面の右側の大きなタイル) を開始すると、左上隅に Xbox One の IP アドレスが表示されます。 Dev Home について詳しくは、「[Xbox One ツールの概要](introduction-to-xbox-tools.md)」をご覧ください。  

2.  **C++ および Html/javascript プロジェクト**:ようなパスに従うC#プロジェクトでは、プロジェクトのプロパティに移動、**デバッグ**] タブで [**リモート マシン**をドロップダウン リストを開くデバッガー、IP アドレスまたはホスト名の入力コンソール、**マシン名**フィールド、および選択**ユニバーサル (暗号化されていないプロトコル)** で、**認証の種類**フィールド。

3. 選択**x64**上部のメニュー バーに緑色の再生ボタンの左側のドロップダウン リストから。
   
4.  F5 キーを押してアプリをビルドして、Xbox One での展開を開始します。
  
5.  初めてこれを行う際には、Visual Studio に Xbox One の PIN の入力を求められます。 Xbox One でホームの開発を開始しを選択すると、暗証番号 (pin) を取得できます、**を表示する Visual Studio のピン留め**ボタンをクリックします。
  
6.  ペアリングを行うと、アプリの展開が開始されます。 初めてこれを行う際には、(すべてのツールを Xbox にコピーする必要があるため) 少し時間がかかることがありますが、数分以上かかる場合には、何か問題がある場合があります。 上記のすべての手順を実行していることを確認します (特に **[認証モード]** を **[ユニバーサル]** に設定していることを確認します)。また Xbox One に有線接続していることを確認します。  

7. 用意ができました。 本体での初めてのアプリの実行をお楽しみください。  

## <a name="thats-it"></a>以上で作業は終了です。

![Hello World](images/getting-started-hello-world.png)

## <a name="see-also"></a>関連項目  
- [よく寄せられる質問](frequently-asked-questions.md)  
- [Xbox 開発者プログラムに UWP に関する既知の問題](known-issues.md)
- [Xbox One の UWP](index.md) 
