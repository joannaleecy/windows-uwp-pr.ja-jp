---
title: Windows Hello コンパニオン (IoT) デバイスを使った Windows のロック解除
description: Windows Hello コンパニオン デバイスは、ユーザー認証のエクスペリエンスを強化するために、Windows 10 のデスクトップと組み合わせて使用できるデバイスです。 Windows Hello コンパニオン デバイス フレームワークを使用すると、コンパニオン デバイスは、生体認証を利用できない場合 (たとえば、Windows 10 のデスクトップに顔認証のカメラまたは指紋リーダーのデバイスがない場合など) でも、Windows Hello のための優れたエクスペリエンスを提供できます。
author: msatranjr
ms.author: misatran
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: windows 10, uwp, セキュリティ
ms.assetid: 89f3d331-20cd-457b-83e8-1a22aaab2658
ms.localizationpriority: medium
ms.openlocfilehash: ac2e29d5219809058edee2d7a92c2e2475d9752e
ms.sourcegitcommit: c4d3115348c8b54fcc92aae8e18fdabc3deb301d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/22/2018
ms.locfileid: "5408947"
---
# <a name="windows-unlock-with-windows-hello-companion-iot-devices"></a>Windows Hello コンパニオン (IoT) デバイスを使った Windows のロック解除

Windows Hello コンパニオン デバイスは、ユーザー認証のエクスペリエンスを強化するために、Windows 10 のデスクトップと組み合わせて使用できるデバイスです。 Windows Hello コンパニオン デバイス フレームワークを使用すると、コンパニオン デバイスは、生体認証を利用できない場合 (たとえば、Windows 10 のデスクトップに顔認証のカメラまたは指紋リーダーのデバイスがない場合など) でも、Windows Hello のための優れたエクスペリエンスを提供できます。

> **注:** Windows Hello コンパニオン デバイス フレームワークは特別な機能です。すべてのアプリ開発者が利用できるわけではありません。 このフレームワークを使用するには、アプリが Microsoft によって明確にプロビジョニングされ、制限された *secondaryAuthenticationFactor* 機能がアプリ マニフェストに含まれている必要があります。 承認を得るには、[cdfonboard@microsoft.com](mailto:cdfonboard@microsoft.com) にお問い合わせください。

## <a name="introduction"></a>はじめに

> 概要については、Channel 9 で Build 2016 の「[Windows Unlock with IoT Devices](https://channel9.msdn.com/Events/Build/2016/P491)」をご覧ください。

> コード サンプルについては、[Windows Hello コンパニオン デバイス フレームワークの GitHub リポジトリ](https://github.com/Microsoft/companion-device-framework)をご覧ください。

### <a name="use-cases"></a>使用事例

さまざまな方法で Windows Hello コンパニオン デバイス フレームワークを使用して、コンパニオン デバイスによる優れた Windows のロック解除エクスペリエンスを構築できます。 たとえば、ユーザーは、次のことを実行できます。

- コンパニオン デバイスを USB 経由で PC に接続し、コンパニオン デバイスのボタンにタッチすると、PC のロックが自動的に解除されます。
- PC と Bluetooth でペアリング済みの電話を携帯します。 PC の Space キーを押すと、電話が通知を受信します。 通知を承認するだけで、PC のロックが解除されます。
- NFC リーダーにコンパニオン デバイスをタップすると、PC のロックがすぐに解除されます。
- ユーザーの認証を完了しているフィットネス バンドを装着します。 PC に近づいて特別なジェスチャ (拍手など) を実行すると、PC のロックが解除されます。

### <a name="biometric-enabled-windows-hello-companion-devices"></a>生体認証対応 Windows Hello コンパニオン デバイス

コンパニオン デバイスが生体認証をサポートしている場合は、Windows Hello コンパニオン デバイス フレームワークよりも [Windows 生体認証フレームワーク](https://msdn.microsoft.com/library/windows/hardware/mt608302(v=vs.85).aspx)の方が効果的なことがあります。 適切なアプローチについては、[cdfonboard@microsoft.com](mailto:cdfonboard@microsoft.com) にお問い合わせください。

### <a name="components-of-the-solution"></a>ソリューションのコンポーネント

次の図は、ソリューションのコンポーネントと、各コンポーネントの作成元を示しています。

![フレームワークの概要](images/companion-device-1.png)

Windows Hello コンパニオン デバイス フレームワークは、Windows で実行されるサービスとして実装されます (この記事では Companion Authentication Service と呼びます)。 このサービスは、Windows Hello コンパニオン デバイスに保存される HMAC キーによって保護する必要があるロック解除トークンを生成します。 これにより、ロック解除トークンにアクセスするには、Windows Hello コンパニオン デバイスが必ず必要になります。 組 (PC、Windows ユーザー) ごとに、一意のロック解除トークンがあります。

Windows Hello コンパニオン デバイス フレームワークとの統合には、以下が必要です。

- コンパニオン デバイス用の[ユニバーサル Windows プラットフォーム (UWP)](https://msdn.microsoft.com/windows/uwp/get-started/universal-application-platform-guide) Windows Hello コンパニオン デバイス アプリ。Windows アプリ ストアからダウンロードできます。 
- 2 つの 256 ビットの HMAC キーを Windows Hello コンパニオン デバイス上に作成し、HMAC を (SHA-256 を使用して) 生成する能力。
- 適切に構成された Windows 10 デスクトップのセキュリティ設定。 Companion Authentication Service では、Windows Hello コンパニオン デバイスが接続される前に PIN が設定されている必要があります。 ユーザーは、[設定]、[アカウント]、[サインイン オプション] の順に移動して、PIN を設定する必要があります。

上記の要件に加え、Windows Hello コンパニオン デバイス アプリは、次のことに対して責任を負います。

- 初回登録のユーザー エクスペリエンスとブランディング、およびその後の Windows Hello コンパニオン デバイスの登録解除。
- バック グラウンドで実行、Windows Hello コンパニオン デバイスの検出、Windows Hello コンパニオン デバイスおよび Companion Authentication Service との通信。
- エラー処理

通常、コンパニオン デバイスには、フィットネス バンドの初回の設定などを実行するための初期セットアップ用のアプリが付属します。 このドキュメントに記載されている機能は、そのアプリの一部にすることができ、別のアプリは必要ありません。  

### <a name="user-signals"></a>ユーザー シグナル

各 Windows Hello コンパニオン デバイスは、3 種類のユーザー シグナルをサポートするアプリと組み合わせる必要があります。 これらのシグナルは、操作またはジェスチャの形を取ることができます。

- **インテント シグナル**: ユーザーがロックを解除する意図があることを提示できるようにします (例: Windows Hello コンパニオン デバイス上のボタンを押す)。 インテント シグナルは、**Windows Hello コンパニオン デバイス**側で収集する必要があります。
- **ユーザー プレゼンス シグナル**: ユーザーがそばにいることを証明します。 Windows Hello コンパニオン デバイスを使用して PC のロックを解除するには、その前に PIN (PC の PIN と混同しないでください) が必要になることがあります。または、ボタンの押下が必要な場合があります。
- **曖昧性解消シグナル**: Windows Hello コンパニオン デバイスで複数のオプションを使用できるときに、ユーザーがどの Windows 10 デスクトップのロックを解除するかを明確にします。

任意の数のユーザー シグナルを 1 つに組み合わせることができます。 ユーザー プレゼンス シグナルとインテント シグナルは、毎回の使用時に必要です。

### <a name="registration-and-future-communication-between-a-pc-and-windows-hello-companion-devices"></a>登録および登録後の PC と Windows Hello コンパニオン デバイス間の通信

Windows Hello コンパニオン デバイスは、Windows Hello コンパニオン デバイス フレームワークに接続する前に、フレームワークに登録する必要があります。 登録エクスペリエンスは、Windows Hello コンパニオン デバイス アプリがすべて管理します。

Windows Hello コンパニオン デバイスと Windows 10 デスクトップ デバイスは、1 対多の関係にできます (つまり、1 台のコンパニオン デバイスを、多数の Windows 10 デスクトップ デバイスで使用できます)。 ただし、各 Windows Hello コンパニオン デバイスは、Windows 10 デスクトップ デバイスごとに 1 人のユーザーのみが使用できます。   

Windows Hello コンパニオン デバイスは、PC と通信する前に、使用するトランスポートに関して合意する必要があります。 その選択肢は Windows Hello コンパニオン デバイス アプリに任されています。Windows Hello コンパニオン デバイス フレームワークによって、Windows Hello コンパニオン デバイスと Windows 10 デスクトップ デバイス側の Windows Hello コンパニオン デバイス アプリの間で使用される、トランスポートの種類 (USB、NFC、WiFi、BT、BLE など) またはプロトコルが制限されることはありません。 ただし、トランスポート層のセキュリティに関する考慮事項が、このドキュメントの「セキュリティ要件」セクションに示されています。 これらの要件に対応する責任は、デバイス プロバイダーの側にあります。 フレームワークがこれらに対応することはありません。


## <a name="user-interaction-model"></a>ユーザー インタラクション モデル

### <a name="windows-hello-companion-device-app-discovery-installation-and-first-time-registration"></a>Windows Hello コンパニオン デバイス アプリの検出、インストール、および初回登録

一般的なユーザー ワークフローは次のようになります。

- ユーザーは、Windows Hello コンパニオン デバイスを使用してロックを解除する各 Windows 10 デスクトップ デバイスで PIN を設定します。
- ユーザーは、Windows 10 デスクトップ デバイスで Windows Hello コンパニオン デバイス アプリを実行して、自分の Windows Hello コンパニオン デバイスを Windows 10 デスクトップ デバイスに登録します。

注意事項:

- Windows Hello コンパニオン デバイス アプリの検出、ダウンロード、および起動は効率化し、可能な場合は自動化することをお勧めします (たとえば、Windows Hello コンパニオン デバイスを Windows 10 デスクトップ デバイス側の NFC リーダーでタップしたときに、アプリを自動的にダウンロードできるようにします)。 ただし、これは、Windows Hello コンパニオン デバイスと Windows Hello コンパニオン デバイス アプリの責任で実行する必要があります。
- エンタープライズ環境では、MDM によって Windows Hello コンパニオン デバイス アプリを展開できます。
- 登録の一部として発生するエラー メッセージの表示は、Windows Hello コンパニオン デバイス アプリが担当します。

### <a name="registration-and-de-registration-protocol"></a>登録/登録解除プロトコル

次の図は、登録時の Windows Hello コンパニオン デバイスと Companion Authentication Service の対話方法を示しています。  

![登録フロー](images/companion-device-2.png)

このプロトコルでは、2 つのキーが使用されます。

- デバイス キー (**devicekey**): PC が Windows のロックを解除するために必要なロック解除トークンを保護するために使用されます。
- 認証キー (**authkey**): Windows Hello コンパニオン デバイスと Companion Authentication Service を相互認証するために使用されます。

デバイス キーと認証キーは、登録時に Windows Hello コンパニオン デバイス アプリと Windows Hello コンパニオン デバイスの間で交換されます。 このため、Windows Hello コンパニオン デバイス アプリと Windows Hello コンパニオン デバイスは、セキュリティで保護されたトランスポートを使用してキーを保護する必要があります。

また、上の図では、Windows Hello コンパニオン デバイスで 2 つの HMAC キーが生成されていますが、これらをアプリで生成して Windows Hello コンパニオン デバイスに送信して保存することもできます。

### <a name="starting-authentication-flows"></a>認証開始フロー

ユーザーが Windows Hello コンパニオン デバイス フレームワークを使用して Windows 10 デスクトップへのサインインを開始する (つまりインテント シグナルを提供する) 方法は 2 つあります。

- ノート PC のカバーを開くか、PC で Space キーを押すか画面をスワイプする。
- Windows Hello コンパニオン デバイス側でジェスチャまたはアクションを実行する。

どちらで始めるかは、Windows Hello コンパニオン デバイス側が選択します。 Windows Hello コンパニオン デバイス フレームワークは、オプション 1 が発生したら、それをコンパニオン デバイス アプリに通知します。 オプション 2 では、Windows Hello コンパニオン デバイス アプリがコンパニオン デバイスにクエリを行って、そのイベントがキャプチャされたかどうかを確認する必要があります。 これにより、Windows Hello コンパニオン デバイスがインテント シグナルを収集した後、必ずロック解除が成功します。

### <a name="windows-hello-companion-device-credential-provider"></a>Windows Hello コンパニオン デバイス資格情報プロバイダー

Windows 10 には、すべての Windows Hello コンパニオン デバイスを処理する新しい資格情報プロバイダーがあります。

トリガーのアクティブ化によるコンパニオン デバイスのバックグラウンド タスクの起動は、Windows Hello コンパニオン デバイス資格情報プロバイダーが担当します。 トリガーは、PC が起動され、ロック画面が表示されたときに、1 回目の設定が行われます。 2 回目は、PC がログオン UI に移行し、Windows Hello コンパニオン デバイス資格情報プロバイダー タイルが選択された時点です。

Windows Hello コンパニオン デバイス アプリのヘルパー ライブラリが、ロック画面の状態の変化をリッスンし、Windows Hello コンパニオン デバイスのバック グラウンド タスクに対応するイベントを送信します。

複数の Windows Hello コンパニオン デバイスのバックグラウンド タスクがある場合は、最初に認証処理を終了したバックンド タスクが PC のロックを解除します。 コンパニオン デバイス認証サービスは、残りの認証呼び出しを無視します。

Windows Hello コンパニオン デバイス側のエクスペリエンスは、Windows Hello コンパニオン デバイス アプリが処理と管理を行います。 Windows Hello コンパニオン デバイス フレームワークは、ユーザー エクスペリエンスのこの部分を制御しません。 具体的には、コンパニオン認証プロバイダーは、ログオン UI の状態の変化 (ロック画面が今表示されたことや、ユーザーが Space キーを押してロック画面を消したばかりであることなど) を Windows Hello コンパニオン デバイス アプリに (そのバックグラウンド アプリ経由で) 通知します。その周辺のエクスペリエンス (ユーザーが Space キーを押したときのロック画面の消去や、USB 上のデバイス検索の開始など) の構築は、Windows Hello コンパニオン デバイス アプリが担当します。

Windows Hello コンパニオン デバイス フレームワークには、Windows Hello コンパニオン デバイス アプリが選択できる (ローカライズされた) テキストとエラー メッセージが多数用意されています。 これらは、ロック画面の上部 (またはログオン UI) に表示されます。 詳細については、メッセージとエラーの処理に関するセクションを参照してください。

### <a name="authentication-protocol"></a>認証プロトコル

トリガーによって開始された Windows Hello コンパニオン デバイス アプリに関連付けられたバックグラウンド タスクは、Companion Authentication Service によって計算された HMAC 値を検証し、2 つの HMAC 値の計算を支援するように、Windows Hello コンパニオン デバイスに依頼する必要があります。
- サービス HMAC = HMAC (認証キー, サービス nonce || デバイス nonce || セッション nonce) を検証する。
- nonce を使用してデバイス キーの HMAC を計算する。
- Companion Authentication Service によって生成された nonce が連結された最初の HMAC 値を持つ認証キーの HMAC を計算する。

2 番目の計算値は、サービスがデバイスを認証し、さらにトランスポート チャネルでのリプレイ攻撃を防ぐために使用されます。

![登録フロー](images/companion-device-3.png)

## <a name="lifecycle-management"></a>ライフサイクルの管理

### <a name="register-once-use-everywhere"></a>一度登録すればどこでも使える

バックエンド サーバーなしで、ユーザーは、自分の Windows Hello コンパニオン デバイスを、各 Windows 10 デスクトップ デバイスに個別に登録する必要があります。

コンパニオン デバイス ベンダーや OEM は、ユーザーの Windows 10 デスクトップやモバイル デバイスの登録状態をローミングする Web サービスを実装できます。 詳細については、ローミング、無効化、およびフィルター サービスに関するセクションをご覧ください。

### <a name="pin-management"></a>PIN 管理

コンパニオン デバイスを使用する前に、Windows 10 デスクトップ デバイスに PIN を設定する必要があります。 これにより、ユーザーの Windows Hello コンパニオン デバイスが動作しない場合のバックアップが保証されます。 PIN は、Windows によって管理されるものであり、アプリがまったく認識しないものです。 これを変更するには、ユーザーは、[設定]、[アカウント]、[サインイン オプション] の順に移動します。

### <a name="management-and-policy"></a>管理とポリシー

ユーザーは、Windows 10 デスクトップ デバイス上の Windows Hello コンパニオン デバイス アプリを実行することで、Windows 10 デスクトップから Windows Hello コンパニオン デバイスを削除できます。

企業では、Windows Hello コンパニオン デバイス フレームワークを制御するためのオプションは 2 つあります。

- 機能を有効または無効にする
- Windows AppLocker を使用して、許可される Windows Hello コンパニオン デバイスのホワイトリストを定義する

Windows Hello コンパニオン デバイス フレームワークでは、使用可能なコンパニオン デバイスのインベントリを保持するための一元管理や、許可される Windows Hello コンパニオン デバイスの種類のフィルター処理 (たとえば、シリアル番号が X ～ Y の範囲にあるデバイスのみを許可する) がサポートされません。 ただし、アプリ開発者は、このような機能を提供するサービスを構築できます。 詳細については、ローミング、無効化、およびフィルター サービスに関するセクションをご覧ください。

### <a name="revocation"></a>無効化

Windows Hello コンパニオン デバイス フレームワークでは、特定の Windows 10 デスクトップ デバイスからリモートでコンパニオン デバイスを削除できません。 代わりに、ユーザーが、Windows 10 デスクトップで実行されている Windows Hello コンパニオン デバイス アプリを介して、Windows Hello コンパニオン デバイスを削除することができます。

ただし、コンパニオン デバイス ベンダーは、リモート無効化機能を提供するサービスを構築できます。 詳細については、ローミング、無効化、およびフィルター サービスに関するセクションを参照してください。

### <a name="roaming-and-filter-services"></a>ローミングとフィルター サービス

コンパニオン デバイス ベンダーは、次のシナリオで使用できる Web サービスを実装できます。

- 企業向けのフィルター サービス: 企業は、エンタープライズ環境で動作できる一連の Windows Hello コンパニオン デバイスを、特定のベンダーから選ばれた数台に制限することができます。 たとえば、10,000 台のモデル Y コンパニオン デバイスをベンダー X に発注した Contoso 社は、それらのデバイスのみが Contoso ドメインで動作し、ベンダー X の他のデバイス モデルは動作しないことを保証できます。
- インベントリ: 企業は、エンタープライズ環境で使用される既存のコンパニオン デバイスの一覧を確認できます。
- リアルタイムの無効化: 従業員からコンパニオン デバイスの紛失や盗難があったことが報告された場合に、Web サービスを使用してそのデバイスを無効にできます。
- ローミング: ユーザーは、自分のコンパニオン デバイスを 1 回登録するだけで、自分のすべての Windows 10 デスクトップとモバイルで機能させることができます。

これらの機能を実装するには、登録時と使用時に Web サービスを確認する Windows Hello コンパニオン デバイス アプリが必要です。 Windows Hello コンパニオン デバイス アプリは、Web サービスの確認を 1 日に 1 回のみ要求するようなキャッシュされたログオン シナリオ用に最適化できます (無効化時間が最大 1 日遅くなります)。  

## <a name="windows-hello-companion-device-framework-api-model"></a>Windows Hello コンパニオン デバイス フレームワーク API モデル

### <a name="overview"></a>概要

Windows Hello コンパニオン デバイス アプリには、デバイスの登録と登録解除を行う UI を持つフォアグラウンド アプリと、認証を処理するバックグラウンド タスクという 2 つのコンポーネントを含める必要があります。

全体的な API フローは次のようになります。

1. Windows Hello コンパニオン デバイスを登録する
    * デバイスが近くにあることを確認し、その機能のクエリを実行する (必要な場合)
    * 2 つの HMAC キーを生成する (コンパニオン デバイス側またはアプリ側のどちらかで実行)
    * RequestStartRegisteringDeviceAsync を呼び出す
    * FinishRegisteringDeviceAsync を呼び出す
    * Windows Hello コンパニオン デバイス アプリに HMAC キーが保存されていること (サポートされている場合)、および Windows Hello コンパニオン デバイス アプリによってそのコピーが破棄されていることを確認する
2. バックグラウンド タスクを登録する
3. バック グラウンド タスクで適切なイベントが発生するまで待機する
    * WaitingForUserConfirmation: Windows Hello コンパニオン デバイス側でのユーザーの操作/ジェスチャーによって認証フローを開始する必要がある場合は、このイベントを待つ
    * CollectingCredential: Windows Hello コンパニオン デバイスが、PC 側でのユーザーの操作/ジェスチャー (Space キーを押すことなど) に依存して認証フローを開始する場合は、このイベントを待つ
    * その他のトリガー (スマートカードなど): 現在の認証状態のクエリを実行して、適切な API を呼び出す。
4. エラー メッセージや次に必要な手順について、ShowNotificationMessageAsync を呼び出してユーザーに通知する。 この API は、インテント シグナルが収集された後でのみ呼び出します
5. ロックを解除する
    * インテント シグナルとユーザー プレゼンス シグナルが収集されたことを確認する
    * StartAuthenticationAsync を呼び出す
    * コンパニオン デバイスと通信して、必要な HMAC 操作を実行する
    * FinishAuthenticationAsync を呼び出す
6. ユーザーの要求に応じて (ユーザーが Windows Hello コンパニオン デバイスを紛失した場合など)、Windows Hello コンパニオン デバイスの登録を解除する
    * FindAllRegisteredDeviceInfoAsync を使用してログインしているユーザーの Windows Hello コンパニオン デバイスを列挙する
    * UnregisterDeviceAsync を使用してデバイスの登録を解除する

### <a name="registration-and-de-registration"></a>登録と登録解除

登録には、Companion Authentication Service への 2 つの API 呼び出し (RequestStartRegisteringDeviceAsync と FinishRegisteringDeviceAsync) が必要です。

これらの呼び出しを行う前に、Windows Hello コンパニオン デバイス アプリは、Windows Hello コンパニオン デバイスが使用可能であることを確認する必要があります。 Windows Hello コンパニオン デバイスが HMAC キー (認証キーとデバイス キー) の生成を担当する場合、Windows Hello コンパニオン デバイス アプリは、上記の 2 つの呼び出しを行う前に、それを生成するようコンパニオン デバイスに依頼する必要があります。 Windows Hello コンパニオン デバイス アプリが HMAC キーの生成を担当する場合は、上記の 2 つの呼び出しを行う前にそれを実行する必要があります。

さらに、Windows Hello コンパニオン デバイス アプリは、最初の API 呼び出し (RequestStartRegisteringDeviceAsync) の一部としてデバイスの機能を決定し、それを API 呼び出しの一部として渡すための準備を行う必要があります (Windows Hello コンパニオン デバイスが HMAC キーのセキュア ストレージをサポートしているかどうかなどを渡します)。 同じ Windows Hello コンパニオン デバイス アプリを使用して、同じコンパニオン デバイスの複数のバージョンとその機能変更を管理する場合 (また、デバイス クエリで管理の対象を決定する必要がある場合)、最初の API 呼び出しを行う前に、そのクエリを実行することをお勧めします。   

最初の API (RequestStartRegisteringDeviceAsync) は、2 番目の API (FinishRegisteringDeviceAsync) で使用されるハンドルを返します。 登録のための最初の呼び出しは、PIN プロンプトを起動して、ユーザーが存在していることを確認します。 PIN が設定されていない場合、この呼び出しは失敗します。 Windows Hello コンパニオン デバイス アプリは、KeyCredentialManager.IsSupportedAsync 呼び出しにより、PIN が設定されているかどうかのクエリを実行することもできます。 ポリシーによって Windows Hello コンパニオン デバイスの使用が無効になっている場合も、RequestStartRegisteringDeviceAsync 呼び出しが失敗することがあります。

最初の呼び出しの結果は、SecondaryAuthenticationFactorRegistrationStatus 列挙型で返されます。

```C#
{
    Failed = 0,         // Something went wrong in the underlying components
    Started,            // First call succeeded
    CanceledByUser,     // User cancelled PIN prompt
    PinSetupRequired,   // PIN is not set up
    DisabledByPolicy,   // Companion device framework or this app is disabled
}
```

2 番目の呼び出し (FinishRegisteringDeviceAsync) によって登録が終了します。 登録プロセスの一部として、Windows Hello コンパニオン デバイス アプリは、Companion Authentication Service を使用してコンパニオン デバイスの構成データを保存できます。 このデータには 4 K というサイズ制限があります。 このデータは、Windows Hello コンパニオン デバイス アプリが認証時に使用できます。 このデータは、たとえば、Windows Hello コンパニオン デバイスに接続するときに MAC アドレスのように使用できます。また、Windows Hello コンパニオン デバイスにストレージがないときに、PC をストレージ用として使用することをコンパニオン デバイスが望んだ場合、構成データを使用できます。 データの一部として保存される機密性の高いデータは、Windows Hello コンパニオン デバイスだけが知っているキーを使用して暗号化する必要があることに注意してください。 また、構成データが Windows サービスによって保存されるのであれば、Windows Hello コンパニオン デバイス アプリは、ユーザー プロファイルを通してそれを使用できます。

Windows Hello コンパニオン デバイス アプリは、AbortRegisteringDeviceAsync を呼び出して登録をキャンセルし、エラー コードを渡すことができます。 Companion Authentication Service は、エラーを利用統計情報で記録します。 この呼び出しが適切な例として、Windows Hello コンパニオン デバイスで問題が発生し、登録を終了できなかった場合があります (HMAC キーが保存できなかった、BT 接続が失われた場合など)。

Windows Hello コンパニオン デバイス アプリには、ユーザーが (Windows Hello コンパニオン デバイスを紛失した場合や、新しいバージョンを購入した場合などに) Windows 10 デスクトップから Windows Hello コンパニオン デバイスの登録を解除するためのオプションが必要です。 ユーザーがそのオプションを選択したとき、Windows Hello コンパニオン デバイス アプリは、UnregisterDeviceAsync を呼び出す必要があります。 Windows Hello コンパニオン デバイス アプリからのこの呼び出しによって、コンパニオン デバイス認証サービスは、呼び出し元アプリの特定のデバイス ID とアプリ ID に対応するすべてのデータ (HMAC キーを含む) を PC 側から削除します。 この API 呼び出しは、Windows Hello コンパニオン デバイス アプリまたはコンパニオン デバイス側からは HMAC キーを削除しません。 その実装は、Windows Hello コンパニオン デバイス アプリに任されています。

登録フェーズと登録解除フェーズ中に発生したエラー メッセージの表示は、Windows Hello コンパニオン デバイス アプリが担当します。

```C#
using System;
using Windows.Security.Authentication.Identity.Provider;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using Windows.UI.Popups;

namespace SecondaryAuthFactorSample
{
    public class DeviceRegistration
    {

        public void async OnRegisterButtonClick()
        {
            //
            // Pseudo function, the deviceId should be retrieved by the application from the device
            //
            string deviceId = await ReadSerialNumberFromDevice();

            IBuffer deviceKey = CryptographicBuffer.GenerateRandom(256/8);
            IBuffer mutualAuthenticationKey = CryptographicBuffer.GenerateRandom(256/8);

            SecondaryAuthenticationFactorRegistration registrationResult =
                await SecondaryAuthenticationFactorRegistration.RequestStartRegisteringDeviceAsync(
                    deviceId,  // deviceId: max 40 wide characters. For example, serial number of the device
                    SecondaryAuthenticationFactorDeviceCapabilities.SecureStorage |
                        SecondaryAuthenticationFactorDeviceCapabilities.HMacSha256 |
                        SecondaryAuthenticationFactorDeviceCapabilities.StoreKeys,
                    "My test device 1", // deviceFriendlyName: max 64 wide characters. For example: John's card
                    "SAMPLE-001", // deviceModelNumber: max 32 wide characters. The app should read the model number from device.
                    deviceKey,
                    mutualAuthenticationKey);

            switch(registerResult.Status)
            {
            case SecondaryAuthenticationFactorRegistrationStatus.Started:
                //
                // Pseudo function:
                // The app needs to retrieve the value from device and set into opaqueBlob
                //
                IBuffer deviceConfigData = ReadConfigurationDataFromDevice();

                if (deviceConfigData != null)
                {
                    await registrationResult.Registration.FinishRegisteringDeviceAsync(deviceConfigData); //config data limited to 4096 bytes
                    MessageDialog dialog = new MessageDialog("The device is registered correctly.");
                    await dialog.ShowAsync();
                }
                else
                {
                    await registrationResult.Registration.AbortRegisteringDeviceAsync("Failed to connect to the device");
                    MessageDialog dialog = new MessageDialog("Failed to connect to the device.");
                    await dialog.ShowAsync();
                }
                break;

            case SecondaryAuthenticationFactorRegistrationStatus.CanceledByUser:
                MessageDialog dialog = new MessageDialog("You didn't enter your PIN.");
                await dialog.ShowAsync();
                break;

            case SecondaryAuthenticationFactorRegistrationStatus.PinSetupRequired:
                MessageDialog dialog = new MessageDialog("Please setup PIN in settings.");
                await dialog.ShowAsync();
                break;

            case SecondaryAuthenticationFactorRegistrationStatus.DisabledByPolicy:
                MessageDialog dialog = new MessageDialog("Your enterprise prevents using this device to sign in.");
                await dialog.ShowAsync();
                break;
            }
        }

        public void async UpdateDeviceList()
        {
            IReadOnlyList<SecondaryAuthenticationFactorInfo> deviceInfoList =
                await SecondaryAuthenticationFactorRegistration.FindAllRegisteredDeviceInfoAsync(
                    SecondaryAuthenticationFactorDeviceFindScope.User);

            if (deviceInfoList.Count > 0)
            {
                foreach (SecondaryAuthenticationFactorInfo deviceInfo in deviceInfoList)
                {
                    //
                    // Add deviceInfo.FriendlyName and deviceInfo.DeviceId into a combo box
                    //
                }
            }
        }

        public void async OnUnregisterButtonClick()
        {
            string deviceId;
            //
            // Read the deviceId from the selected item in the combo box
            //
            await SecondaryAuthenticationFactorRegistration.UnregisterDeviceAsync(deviceId);
        }
    }
}
```

### <a name="authentication"></a>認証

認証には、Companion Authentication Service への 2 つの API 呼び出し (StartAuthenticationAsync と FinishAuthencationAsync) が必要です。

最初の開始 API は、2 番目の API で使用されるハンドルを返します。  最初の呼び出しは、特に nonce を返します。他のデータと連結されるこの nonce は、Windows Hello コンパニオン デバイスに保存されるデバイス キーを HMAC 処理するために必要です。 2 番目の呼び出しは、デバイス キーの HMAC の結果を返し、認証の成功で終了できます (つまり、ユーザーにデスクトップが表示されます)。

最初の開始 API (StartAuthenticationAsync) は、初回登録後、ポリシーによってその Windows Hello コンパニオン デバイスが無効になっている場合は失敗します。 API 呼び出しは、WaitingForUserConfirmation 状態または CollectingCredential 状態以外のときに行われた場合も失敗します (詳しくは、このセクションで後述します)。 さらに、未登録のコンパニオン デバイス アプリがそれを呼び出した場合も失敗します。 SecondaryAuthenticationFactorAuthenticationStatus 列挙型は、可能な結果を要約します。

```C#
{
    Failed = 0,                     // Something went wrong in the underlying components
    Started,
    UnknownDevice,                  // Companion device app is not registered with framework
    DisabledByPolicy,               // Policy disabled this device after registration
    InvalidAuthenticationStage,     // Companion device framework is not currently accepting
                                    // incoming authentication requests
}
```

2 番目の API 呼び出し (FinishAuthencationAsync) は、最初の呼び出しで提供された nonce の有効期限 (20 秒) が終了した場合は失敗します。 SecondaryAuthenticationFactorFinishAuthenticationStatus 列挙型では、可能な結果をキャプチャします。

```C#
{
    Failed = 0,     // Something went wrong in the underlying components
    Completed,      // Success
    NonceExpired,   // Nonce is expired
}
```

2 つの API 呼び出し (StartAuthenticationAsync と FinishAuthencationAsync) のタイミングは、Windows Hello コンパニオン デバイスがインテント シグナル、ユーザー プレゼンス シグナル、および曖昧性解消シグナル (詳しくは、「ユーザー シグナル」を参照) を収集する方法と合わせる必要があります。 たとえば、2 番目の呼び出しは、インテント シグナルを入手した後で送信します。 つまり、ユーザーがロック解除の意図を示していない場合、PC のロックは解除すべきではありません。 具体的に言えば、Bluetooth の近接性を使用して PC のロックを解除する場合は、明確なインテント シグナルを収集する必要があります。そうしないと、ユーザーがキッチンに行く途中で PC の近くを通ったときに PC のロックが解除されます。 また、最初の呼び出しから返される nonce には時間制限 (20 秒) があり、一定期間後に有効期限が切れます。 このため、最初の呼び出しは、Windows Hello コンパニオン デバイスが確実に存在することをコンパニオン デバイス アプリが認識した (たとえば、コンパニオン デバイスが USB ポートに挿入されたり、NFC リーダーにタップされた) ときにのみ実行する必要があります。 Bluetooth の場合は、PC 側のバッテリーや、Windows Hello コンパニオン デバイスの存在を確認している時点で進行中の他の Bluetooth アクティビティへの影響を回避することを考慮する必要があります。 さらに、(たとえば PIN の入力による) ユーザー プレゼンス シグナルを提供する必要がある場合は、最初の認証呼び出しは、そのシグナルが収集された後でのみ実行することをお勧めします。

Windows Hello コンパニオン デバイス フレームワークは、ユーザーが認証フローのどこにいるかの全体像を提供することによって、Windows Hello コンパニオン デバイス アプリが十分な情報に基づいて上記 2 つの呼び出しをいつ実行するかを決定できるようにしています。 Windows Hello コンパニオン デバイス フレームワークは、ロック状態変化通知をアプリのバックグラウンド タスクに提供することで、この機能を実現しています。

![コンパニオン デバイス フロー](images/companion-device-4.png)

これらの状態の詳細を次に示します。

| 状態                         | 説明                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                               |
|----------------------------   |-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------    |
| WaitingForUserConfirmation    | この状態変化通知イベントは、ロック画面から移動した場合に発生します (例: ユーザーが Windows + L キーを押下)。 この状態のときは、デバイスが見つからないことに関連するすべてのエラー メッセージを要求しないことをお勧めします。 一般に、メッセージの表示は、インテント シグナルが入手されるときにのみ実行することをお勧めします。 コンパニオン デバイスがインテント シグナル (NFC リーダーのタップ、コンパニオン デバイスのボタンの押下、拍手などの特定のジェスチャなど) を収集する場合、Windows Hello コンパニオン デバイス アプリは、認証するための最初の API 呼び出しを、この状態のときに実行する必要があり、Windows Hello コンパニオン デバイス アプリのバックグラウンド タスクは、インテント シグナルが検出されたことをコンパニオン デバイスから受信します。 Windows Hello コンパニオン デバイス アプリが PC に依存して認証フローを開始する場合 (ユーザーによるロック画面のスワイプや Space キーの押下)、その Windows Hello コンパニオン デバイス アプリは、次の状態 (CollectingCredential) になるまで待機する必要があります。     |
| CollectingCredential          | この状態変化通知イベントは、ユーザーがノート PC のカバーを開いた、キーボードのいずれかのキーを押した、またはスワイプしてロック解除画面に移ったときに発生します。 Windows Hello コンパニオン デバイスが上記のアクションに依存してインテント シグナルの収集を開始する場合、Windows Hello コンパニオン デバイス アプリは (ユーザーが PC のロック解除を望んでいるかどうかを確認するコンパニオン デバイス上のポップアップなどで) その収集を開始する必要があります。 Windows Hello コンパニオン デバイス アプリがコンパニオン デバイスにユーザー プレゼンス シグナルを提供すること (Windows Hello コンパニオン デバイスで PIN を入力するなど) をユーザーに要求する場合は、ここでエラー事例を提供することをお勧めします。                                                                                                                                                                                                                                                                                                                                            |
| SuspendingAuthentication      | Windows Hello コンパニオン デバイス アプリがこの状態を受信した場合は、Companion Authentication Service が認証要求の受け入れを停止したことを意味します。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                            |
| CredentialCollected           | これは、別の Windows Hello コンパニオン デバイス アプリから 2 番目の API の呼び出しがあり、何が送信されたかを Companion Authentication Service が検証していることを意味します。 この時点で、Companion Authentication Service は、現在送信されたものが検証に合格しない限り、他の認証要求を受け入れません。 Windows Hello コンパニオン デバイス アプリは、次の状態になるまで現在の状態を維持する必要があります。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                   |
| CredentialAuthenticated       | これは、送信された資格情報が機能したことを意味します。 credentialAuthenticated には、成功した Windows Hello コンパニオン デバイスのデバイス ID が含まれます。 Windows Hello コンパニオン デバイス アプリは、それに関連付けられているデバイスが勝者であるかどうかを確認する必要があります。 そうでない場合、Windows Hello コンパニオン デバイス アプリは、認証後フローの表示 (コンパニオン デバイス上の成功メッセージなど。デバイスのバイブレーションも考えられます) を回避する必要があります。 送信された資格情報が機能しなかった場合、状態は CollectingCredential に変化します。                                                                                                                                                                                                                                                                                                                                                                                       |
| StoppingAuthentication        | 認証が成功し、ユーザーにデスクトップが表示されます。 この時点で、バックグラウンド タスクを終了します。 バックグラウンド タスクを終了する前に、明示的に StageEvent ハンドラーの登録を解除します。 これは、バックグラウンド タスクをすばやく終了する場合に役立ちます。                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                       |



Windows Hello コンパニオン デバイス アプリは、最初の 2 つの状態のときにのみ、2 つの認証 API を呼び出す必要があります。 Windows Hello コンパニオン デバイス アプリがチェックする必要があるのは、このイベントがどのシナリオで発生しているかです。 ロック解除とロック解除後という 2 つの可能性があります。 現時点では、ロック解除のみがサポートされます。 今後のリリース後で、ロック解除後のシナリオがサポートされる可能性があります。 SecondaryAuthenticationFactorAuthenticationScenario 列挙型は、これら 2 つのオプションをキャプチャします。

```C#
{
    SignIn = 0,         // Running under lock screen mode
    CredentialPrompt,   // Running post unlock
}
```

完全なコード例:

```C#
using System;
using Windows.Security.Authentication.Identity.Provider;
using Windows.Storage.Streams;
using Windows.Security.Cryptography;
using System.Threading;
using Windows.ApplicationModel.Background;

namespace SecondaryAuthFactorSample
{
    public sealed class AuthenticationTask : IBackgroundTask
    {
        private string _deviceId;
        private static AutoResetEvent _exitTaskEvent = new AutoResetEvent(false);
        private static IBackgroundTaskInstance _taskInstance;
        private BackgroundTaskDeferral _deferral;

        private void Authenticate()
        {
            int retryCount = 0;

            while (retryCount < 3)
            {
                //
                // Pseudo code, the svcAuthNonce should be passed to device or generated from device
                //
                IBuffer svcAuthNonce = CryptographicBuffer.GenerateRandom(256/8);

                SecondaryAuthenticationFactorAuthenticationResult authResult = await
                    SecondaryAuthenticationFactorAuthentication.StartAuthenticationAsync(
                        _deviceId,
                        svcAuthNonce);
                if (authResult.Status != SecondaryAuthenticationFactorAuthenticationStatus.Started)
                {
                    SecondaryAuthenticationFactorAuthenticationMessage message;
                    switch (authResult.Status)
                    {
                        case SecondaryAuthenticationFactorAuthenticationStatus.DisabledByPolicy:
                            message = SecondaryAuthenticationFactorAuthenticationMessage.DisabledByPolicy;
                            break;
                        case SecondaryAuthenticationFactorAuthenticationStatus.InvalidAuthenticationStage:
                            // The task might need to wait for a SecondaryAuthenticationFactorAuthenticationStageChangedEvent
                            break;
                        default:
                            return;
                    }

                    // Show error message. Limited to 512 characters wide
                    await SecondaryAuthenticationFactorAuthentication.ShowNotificationMessageAsync(null, message);
                    return;
                }

                //
                // Pseudo function:
                // The device calculates and returns sessionHmac and deviceHmac
                //
                await GetHmacsFromDevice(
                    authResult.Authentication.ServiceAuthenticationHmac,
                    authResult.Authentication.DeviceNonce,
                    authResult.Authentication.SessionNonce,
                    out deviceHmac,
                    out sessionHmac);
                if (sessionHmac == null ||
                    deviceHmac == null)
                {
                    await authResult.Authentication.AbortAuthenticationAsync(
                        "Failed to read data from device");
                    return;
                }

                SecondaryAuthenticationFactorFinishAuthenticationStatus status =
                    await authResult.Authentication.FinishAuthencationAsync(deviceHmac, sessionHmac);
                if (status == SecondaryAuthenticationFactorFinishAuthenticationStatus.NonceExpired)
                {
                    retryCount++;
                    continue;
                }
                else if (status == SecondaryAuthenticationFactorFinishAuthenticationStatus.Completed)
                {
                    // The credential data is collected and ready for unlock
                    return;
                }
            }
        }

        public void OnAuthenticationStageChanged(
            object sender,
            SecondaryAuthenticationFactorAuthenticationStageChangedEventArgs args)
        {
            // The application should check the args.StageInfo.Stage to determine what to do in next. Note that args.StageInfo.Scenario will have the scenario information (SignIn vs CredentialPrompt).

            switch(args.StageInfo.Stage)
            {
            case SecondaryAuthenticationFactorAuthenticationStage.WaitingForUserConfirmation:
                // Show welcome message
                await SecondaryAuthenticationFactorAuthentication.ShowNotificationMessageAsync(
                    null,
                    SecondaryAuthenticationFactorAuthenticationMessage.WelcomeMessageSwipeUp);
                break;

            case SecondaryAuthenticationFactorAuthenticationStage.CollectingCredential:
                // Authenticate device
                Authenticate();
                break;

            case SecondaryAuthenticationFactorAuthenticationStage.CredentialAuthenticated:
                if (args.StageInfo.DeviceId = _deviceId)
                {
                    // Show notification on device about PC unlock
                }
                break;

            case SecondaryAuthenticationFactorAuthenticationStage.StoppingAuthentication:
                // Quit from background task
                _exitTaskEvent.Set();
                break;
            }

            Debug.WriteLine("Authentication Stage = " + args.StageInfo.AuthenticationStage.ToString());
        }

        //
        // The Run method is the entry point of a background task.
        //
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            _taskInstance = taskInstance;
            _deferral = taskInstance.GetDeferral();

            // Register canceled event for this task
            taskInstance.Canceled += TaskInstanceCanceled;

            // Find all device registred by this application
            IReadOnlyList<SecondaryAuthenticationFactorInfo> deviceInfoList =
                await SecondaryAuthenticationFactorRegistration.FindAllRegisteredDeviceInfoAsync(
                    SecondaryAuthenticationFactorDeviceFindScope.AllUsers);

            if (deviceInfoList.Count == 0)
            {
                // Quit the task silently
                return;
            }
            _deviceId = deviceInfoList[0].DeviceId;
            Debug.WriteLine("Use first device '" + _deviceId + "' in the list to signin");

            // Register AuthenticationStageChanged event
            SecondaryAuthenticationFactorRegistration.AuthenticationStageChanged += OnAuthenticationStageChanged;

            // Wait the task exit event
            _exitTaskEvent.WaitOne();

            _deferral.Complete();
        }

        void TaskInstanceCanceled(IBackgroundTaskInstance sender, BackgroundTaskCancellationReason reason)
        {
            _exitTaskEvent.Set();
        }
    }
}
```

### <a name="register-a-background-task"></a>バックグラウンド タスクの登録

Windows Hello コンパニオン デバイス アプリは、最初のコンパニオン デバイスを登録するときに、デバイスとコンパニオン デバイス認証サービス間で認証情報を渡すバックグラウンド タスク コンポーネントも同時に登録する必要があります。

```C#
using System;
using Windows.Security.Authentication.Identity.Provider;
using Windows.Storage.Streams;
using Windows.ApplicationModel.Background;

namespace SecondaryAuthFactorSample
{
    public class BackgroundTaskManager
    {
        // Register background task
        public static async Task<IBackgroundTaskRegistration> GetOrRegisterBackgroundTaskAsync(
            string bgTaskName,
            string taskEntryPoint)
        {
            // Check if there's an existing background task already registered
            var bgTask = (from t in BackgroundTaskRegistration.AllTasks
                          where t.Value.Name.Equals(bgTaskName)
                          select t.Value).SingleOrDefault();
            if (bgTask == null)
            {
                BackgroundAccessStatus status =
                    BackgroundExecutionManager.RequestAccessAsync().AsTask().GetAwaiter().GetResult();

                if (status == BackgroundAccessStatus.Denied)
                {
                    Debug.WriteLine("Background Execution is denied.");
                    return null;
                }

                var taskBuilder = new BackgroundTaskBuilder();
                taskBuilder.Name = bgTaskName;
                taskBuilder.TaskEntryPoint = taskEntryPoint;
                taskBuilder.SetTrigger(new SecondaryAuthenticationFactorAuthenticationTrigger());
                bgTask = taskBuilder.Register();
                // Background task is registered
            }

            bgTask.Completed += BgTask_Completed;
            bgTask.Progress += BgTask_Progress;

            return bgTask;
        }
    }
}
```

### <a name="errors-and-messages"></a>エラーとメッセージ

サインインの成功または失敗のユーザーへのフィードバックは、Windows Hello コンパニオン デバイス フレームワークが担当します。 Windows Hello コンパニオン デバイス フレームワークには、Windows Hello コンパニオン デバイス アプリが選択できる (ローカライズされた) テキストとエラー メッセージが多数用意されています。 これらは、ログオン UI に表示されます。

![コンパニオン デバイス エラー](images/companion-device-5.png)

Windows Hello コンパニオン デバイス アプリは、ShowNotificationMessageAsync を使用して、ログオン UI の一部としてユーザーにメッセージを表示できます。 この API は、インテント シグナルを入手できるときに呼び出します。 インテント シグナルは常に Windows Hello コンパニオン デバイス側で収集する必要があることに注意してください。

メッセージには、ガイダンスとエラーの 2 種類があります。

ガイダンス メッセージは、ロック解除プロセスの開始方法をユーザーに表示することを目的としています。 これらのメッセージは、初回のデバイス登録時にユーザーに対して 1 回のみ表示され、その後ロック画面に表示されることはありません。 ロック画面の下には引き続き表示されています。

エラー メッセージは常に表示されます。また、インテント シグナルが提供された後に表示されます。 ユーザーにメッセージを表示する前にインテント シグナルを収集する必要があるときに、ユーザーがいずれかの Windows Hello コンパニオン デバイスのみを使用して意図を表明するのであれば、複数の Windows Hello コンパニオン デバイスがエラー メッセージを表示するために競争するような状況は発生しません。 このため、Windows Hello コンパニオン デバイス フレームワークでは、キューの管理は行われません。 呼び出し元がエラー メッセージを要求すると、エラー メッセージは 5 秒間表示され、その 5 秒間はエラー メッセージに対するその他のすべての要求は破棄されます。 5 秒経過した後、別の呼び出し元がエラー メッセージを表示する機会が発生します。 これにより、任意の呼び出し元がエラー チャネルを停滞させることが禁止されます。

ガイダンス メッセージとエラー メッセージを次に示します。 デバイス名は、コンパニオン デバイス アプリによって、ShowNotificationMessageAsync の一部として渡されるパラメーターです。

**ガイダンス**

- "Swipe up or press space bar to sign in with *device name*." (デバイス名にサインインするには、上にスワイプするか Space キーを押してください。)
- "Setting up your companion device.  Please wait or use another sign-in option." (コンパニオン デバイスをセットアップしています。しばらく待機するか、別のサインイン オプションを使用してください。)
- "サインインするには、*デバイス名* を NFC リーダーにタップしてください。"
- "*デバイス名* を探しています..."
- "サインインするには、*デバイス名* を USB ポートに差し込んでください。"

**エラー**

- "*デバイス名* にサインインする方法を確認してください。"
- "*デバイス名* を使用してサインインするには、Bluetooth をオンにしてください。"
- "*デバイス名* を使用してサインインするには、NFC をオンにしてください。"
- "*デバイス名* を使用してサインインするには、Wi-Fi ネットワークに接続してください。"
- "*デバイス名* をもう一度タップしてください。"
- "*デバイス名* によるサインインは会社が無効にしています。 別のサインイン オプションを使用してください。"
- "サインインするには、*デバイス名* をタップしてください。"
- "サインインするには、*デバイス名* の上に指を置いてください。"
- "サインインするには、*デバイス名* を指でスワイプしてください。"
- "*デバイス名* にサインインできませんでした。 別のサインイン オプションを使用してください。"
- "Something went wrong.  Use another sign-in option, and then set up *device name* again." (問題が発生しました。別のサインイン オプションを使用し、*デバイス名* をもう一度設定してください。)
- "やり直してください。"
- "Say your Spoken Passphrase into *device name*." (*デバイス名* に音声パスフレーズを言ってください。)
- "*デバイス名* にサインインする準備ができています。"
- "最初は別のサインイン オプションを使用してください。その後、*デバイス名*を使用してサインインできます。"

### <a name="enumerating-registered-devices"></a>登録されているデバイスの列挙

Windows Hello コンパニオン デバイス アプリは、登録されているコンパニオン デバイスの一覧を、FindAllRegisteredDeviceInfoAsync 呼び出しで列挙できます。 この API は、SecondaryAuthenticationFactorDeviceFindScope 列挙型で定義される 2 種類のクエリをサポートします。

```C#
{
    User = 0,
    AllUsers,
}
```

最初のスコープは、ログオン ユーザーのデバイスの一覧を返します。 2 番目は、その PC 上のすべてのユーザーの一覧を返します。 最初のスコープは、他のユーザーの Windows Hello コンパニオン デバイスの登録が解除されないように、登録解除時に使用する必要があります。 2 番目は、認証時または登録時に使用する必要があります。登録時のこの列挙は、同じ Windows Hello コンパニオン デバイスが 2 回登録されることを防ぎます。

このチェックは、アプリが実行しなくても、PC により実行されるため、同じ Windows Hello コンパニオン デバイスが 2 回以上登録されることはありません。 認証時の AllUsers スコープの使用は、Windows Hello コンパニオン デバイス アプリがユーザー切り替えフローをサポートするために役立ちます。このフローでは、ユーザー B がログインしているときにユーザー A をログオンします (両方のユーザーが Windows Hello コンパニオン デバイス アプリをインストール済みであり、ユーザー A が自分のコンパニオン デバイスを PC に登録済みであり、PC がロック画面 (またはログオン画面) を表示している必要があります)。

## <a name="security-requirements"></a>セキュリティ要件

Companion Authentication Service は、次のセキュリティ保護を提供します。

- 中間ユーザーまたはアプリ コンテナーとして実行される Windows 10 デスクトップ デバイス上のマルウェアが、Windows Hello コンパニオン デバイスを使用して、PC 上の (Windows Hello の一部として保存されている) ユーザーの資格情報キーに無許可でアクセスすることはできません。
- Windows 10 デスクトップ デバイスの悪意のあるユーザーが、その Windows 10 デスクトップ デバイスの別のユーザーに属する Windows Hello コンパニオン デバイスを使用して、(同じ Windows 10 デスクトップ デバイス上の) 別のユーザーの資格情報キーに無許可でアクセスすることはできません。
- Windows Hello コンパニオン デバイス上のマルウェアが、Windows 10 デスクトップデバイス上のユーザー資格情報キーに無許可でアクセスすることはできません。Windows Hello コンパニオン デバイス フレームワーク専用に開発された機能やコードを利用することもできません。
- 悪意のあるユーザーが、Windows Hello コンパニオン デバイスと Windows 10 デスクトップ デバイス間のトラフィックをキャプチャし、後で再生リプレイすることで Windows 10 デスクトップ デバイスのロックを解除することはできません。 プロトコルでの nonce、認証キー、および HMAC の使用によって、リプレイ攻撃からの防御が保証されます。
- ルージュ PC 上のマルウェアまたは悪意のあるユーザーが、Windows Hello コンパニオン デバイスを使用して、正規ユーザーの PC にアクセスすることはできません。 これは、Companion Authentication Service と Windows Hello コンパニオン デバイスの間のプロトコルで認証キーと HMAC を使用することで、相互認証を通して実現されます。

上記に列挙したセキュリティ保護を実現するために重要なのは、HMAC キーを不正アクセスから保護するとともに、ユーザー プレゼンスを検証することです。 具体的には、次の要件を満たす必要があります。

- Windows Hello コンパニオン デバイスの複製に対する防御を提供する
- 登録時に PC に HMAC キーを送信するときに、傍受に対する防御を提供する
- ユーザー プレゼンス シグナルを入手できることを確認する
