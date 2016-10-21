---
author: DelfCo
ms.assetid: 2CC2E526-DACB-4008-9539-DA3D0C190290
description: "UWP 開発者が利用できるネットワーク テクノロジの概要と、アプリに適したテクノロジを選ぶヒントを説明します。"
title: "アプリに適したネットワーク テクノロジ"
translationtype: Human Translation
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: fc7793926275dd732ee6c814c9e65a6b656654d2


---

# アプリに適したネットワーク テクノロジ

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

UWP 開発者が利用できるネットワーク テクノロジの概要と、アプリに適したテクノロジを選ぶヒントを説明します。

## ソケット

別のデバイスとの通信を独自のプロトコルで実行する場合は、[ソケット](sockets.md)を使います。

ユニバーサル Windows プラットフォーム (UWP) 開発者は、[**Windows.Networking.Sockets**](https://msdn.microsoft.com/library/windows/apps/br226960) と [Winsock](https://msdn.microsoft.com/library/windows/desktop/ms740673) という 2 つのソケットの実装を利用できます。 新しいコードを記述するなら、Windows.Networking.Sockets には、UWP 開発者向けに設計された最新の API であるという利点があります。 クロスプラット フォームのネットワーク ライブラリや既存の Winsock コードを使う場合、または Winsock API の方が適している場合は、Winsock を使います。

### ソケットを使う状況

-   どちらのソケットの実装でも、選択したプロトコル (TCP または UDP) を使って他のデバイスと通信できます。

-   これまでの経験と使う可能性がある既存のコードに基づいて、ニーズに最も適したソケット API を選びます。

### ソケットを使わない状況

-   ソケットを使う独自の HTTP(S) スタックを実装しないでください。 別のデバイスとの通信を独自のプロトコルで実行する場合は、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) を使います。
-   WebSocket ([**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) クラスと [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) クラス) が通信ニーズ (Web サーバーに対する TCP) を満たす場合は、時間と開発リソースを費やしてソケットを使う同様の機能を実装する代わりに、これらのクラスを使うことを検討しましょう。

## WebSocket

[WebSocket](websockets.md) プロトコルは、クライアントとサーバー間の高速でセキュリティ保護された双方向通信を Web 経由で行うためのメカニズムを定義します。 データはすぐに、全二重の 1 つのソケット接続によって転送され、両方のエンドポイントでメッセージの送受信をリアルタイムで実行できます。 WebSocket は、ソーシャル ネットワークでの即時の通知と最新情報 (ゲームの結果) の表示をセキュリティで保護すると同時に高速にデータ転送する必要があるリアルタイム ゲームでの使用に適しています。 UWP 開発者は、[**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) クラスと [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) クラスを使うことで Websocket プロトコルをサポートするサーバーに接続できます。

### Websocket を使う状況

-   デバイスとサーバー間で継続的にデータを送受信する場合。

### Websocket を使わない状況

-   データを送受信する頻度が低い場合は、WebSocket 接続を確立して維持するよりも、個別の HTTP 要求をデバイスからサーバーに発行する方が単純である可能性があります。
-   WebSocket は、データ量が非常に大きい状況には適していない可能性があります。 WebSocket の採用を決定する前に、データ フローをモデル化し、WebSocket 経由のトラフィックをシミュレートすることをお勧めします。

## HttpClient

HTTP(S) を使って Web サービスまたは Web サーバーと通信する場合は、[HttpClient](httpclient.md) (とその他の [**Windows.Web.Http**](https://msdn.microsoft.com/library/windows/apps/dn279692) 名前空間 API) を使います。

### HttpClient を使う状況

-   HTTP(S) を使って Web サービスと通信する場合。
-   少数の小さなファイルをアップロードまたはダウンロードする場合。
-   WebSocket ([**StreamWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226923) クラスと [**MessageWebSocket**](https://msdn.microsoft.com/library/windows/apps/br226842) クラス) が通信ニーズ (Web サーバーに対する TCP) を満たし、対象の Web サーバーが WebSocket をサポートする場合は、時間と開発リソースを費やして HttpClient を使う同様の機能を実装する代わりに、これらのクラスを使うことを検討しましょう。
-   ネットワーク経由でコンテンツをストリーミングする場合。

### HttpClient を使わない状況

-   大きなファイルまたは多数のファイルを転送する場合は、代わりにバック グラウンド転送を使うことを検討してください。
-   接続の種類に基づいてアップロードとダウンロードの制限を厳しくできるようにする場合や、進行状況を保存して中断後にアップロードとダウンロードを再開する場合は、バック グラウンド転送を使う必要があります。
-   2 つのデバイス間で通信するときに、どちらかのデバイスが HTTP(S) サーバーとして機能するように設計されていない場合は、ソケットを使用する必要があります。 独自の HTTP サーバーを実装し、そのサーバーと [HttpClient](httpclient.md) を使って通信しないでください。

## バックグラウンド転送

ネットワーク経由でファイルを確実に転送する場合は、[バックグラウンド転送 API](background-transfers.md) を使います。 バックグラウンド転送 API には、アプリの一時停止中はバックグラウンドで実行され、アプリの終了後も実行が続行される高度なアップロード機能とダウンロード機能があります。 この API は、ネットワークの状態を監視し、接続が失われたときに転送の中断と再開を自動的に実行します。転送ではデータ センサーとバッテリー セーバーにも対応し、ダウンロード アクティビティは現在の接続とデバイスのバッテリー状態に基づいて調整されます。 アプリがモバイル デバイスやバッテリー駆動デバイスで実行されている場合、これらの機能は不可欠です。 この API は、アップロード HTTP(S) を使った大きなファイルのアップロードとダウンロードに適しています。 FTP もサポートされますが、その対象はダウンロードのみです。

Windows10 の新しい機能であるバックグラウンド転送は、ファイル転送の完了時に後処理をトリガーして、ローカル カタログの更新や他のアプリのアクティブ化、ダウンロードの完了をユーザーに通知する機能です。

### バックグラウンド転送を使う状況

-   大きなファイルまたは多数のファイルを確実に転送するには、バックグラウンド転送を使います。
-   ファイル転送をバックグラウンド タスクで後処理する場合は、バックグラウンド転送とバックグラウンド転送完了グループを使います。
-   ネットワークの中断後に進行中の転送を再開できるようにする場合は、バックグラウンド転送を使います。
-   従量課金制のデータ プランを利用しているなど、ネットワークの状態に基づいて転送の動作を変更できるようにする場合は、バックグラウンド転送を使います。

### バックグラウンド転送を使わない状況

-   少数の小さなファイルを転送し、転送の完了時に後処理が必要ない場合は、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) の PUT メソッドまたは POST メソッドを使うことを検討しましょう。
-   データをストリーミングして、着信したらローカルで利用する場合は、[**HttpClient**](https://msdn.microsoft.com/library/windows/apps/dn298639) を使います。

## その他のネットワークに関連するテクノロジ

### 接続の品質

[**Windows.Networking.Connectivity**](https://msdn.microsoft.com/library/windows/apps/br207308) API により、ネットワーク接続、コスト、使用状況の情報にアクセスできます。 この API の使い方について詳しくは、「[ネットワーク接続状態へのアクセスとネットワーク コストの管理](https://msdn.microsoft.com/library/windows/apps/hh452983)」をご覧ください。

### DNS サービス検出

[**Windows.Networking.ServiceDiscovery.Dnssd**](https://msdn.microsoft.com/library/windows/apps/dn895183) API により、IETF [RFC 2782](http://go.microsoft.com/fwlink/?LinkId=524158) に記述された DNS-SD プロトコルを使うネットワーク上の他のデバイスにネットワーク サービスをアドバタイズできます。

### Bluetooth 通信

[**Windows.Devices.Bluetooth**](https://msdn.microsoft.com/library/windows/apps/dn263413) API により、他のデバイスに Bluetooth 接続でデータを転送できます。 詳しくは、「 [RFCOMM によるファイルの送受信](https://msdn.microsoft.com/library/windows/apps/mt270289)」をご覧ください。

### プッシュ通知 (WNS)

[**Windows.Networking.PushNotifications**](https://msdn.microsoft.com/library/windows/apps/br241307) API により、Windows プッシュ通知サービス (WNS) を使ってネットワーク経由のプッシュ通知が受信できます。 この API の使い方について詳しくは、「[Windows プッシュ通知サービス (WNS) の概要](https://msdn.microsoft.com/library/windows/apps/mt187203)」をご覧ください。

### 近距離無線通信

[**Windows.Networking.Proximity**](https://msdn.microsoft.com/library/windows/apps/br241250) API により、プロキシミティまたはデバイスのタップを使うアプリについては近距離無線通信でデータを簡単に転送できます。 この API の使い方について詳しくは、「[近接通信とタップのサポート](https://msdn.microsoft.com/library/windows/apps/hh465229)」をご覧ください。

### RSS/Atom フィード

[**Windows.Web.Syndication**](https://msdn.microsoft.com/library/windows/apps/br243632) API により、RSS 形式と Atom 形式の配信フィードを管理できます。 この API の使用について詳しくは、「[RSS/Atom フィード](web-feeds.md)」をご覧ください。

### Wi-Fi の列挙と接続の制御

[**Windows.Devices.WiFi**](https://msdn.microsoft.com/library/windows/apps/dn975224) API により、Wi-Fi アダプターを列挙し、利用可能な Wi-Fi ネットワークをスキャンして、アダプターをネットワークに接続できます。

### 無線制御

[**Windows.Devices.Radios**](https://msdn.microsoft.com/library/windows/apps/dn996447) API により、Wi-Fi と Bluetooth を含む無線をローカル デバイスで検出して制御できます。

### Wi-Fi Direct

[**Windows.Devices.WiFiDirect**](https://msdn.microsoft.com/library/windows/apps/dn297687) API により、他のローカル デバイスに Wi-Fi Direct で接続して、アドホックのローカル無線ネットワークを作成できます。

### Wi-Fi Direct サービス

[**Windows.Devices.WiFiDirect.Services**](https://msdn.microsoft.com/library/windows/apps/dn996481) API により、Wi-Fi Direct サービスを用意し、それらのサービスに接続できます。 Wi-Fi Direct サービスは、Wi-Fi Direct アドホック ネットワーク上のあるデバイス (サービス公表者) が Wi-Fi Direct 接続経由で別のデバイス (サービス探求者) に機能を提供する方法です。

### 携帯電話会社

Windows 10 では、これまではデバイスの製造元と携帯電話会社に対してのみ公開されていた API が幅広い開発者を対象として公開されています。 これらの API は公開されましたが、アプリを発行する前に Microsoft の承認を得る必要がある特定のアプリの機能による管理の対象でもあります。 これらの API の実際の使用は、引き続き、主にデバイスの製造元と携帯電話会社によって制限されます。

### ネットワーク操作

[**Windows.Networking.NetworkOperators**](https://msdn.microsoft.com/library/windows/apps/br241148) API は主に、電話の構成とプロビジョニングを処理します。 このため、この API を制御する機能を使う権限は、デバイスの製造元と通信事業者に限られています。

### SMS

[**Windows.Devices.Sms**](https://msdn.microsoft.com/library/windows/apps/br206567) 名前空間は、SMS と関連メッセージを低レベルのエンティティとして処理します。 これは、携帯電話会社がアプリ向けの SMS で使うために提供されるもので、ほとんどのアプリ開発者の使用が許可されることはない機能によって制御されます。 メッセージを処理するアプリを記述する場合は、代わりに [**Windows.ApplicationModel.Chat**](https://msdn.microsoft.com/library/windows/apps/dn642321) API を使います。この API は、SMS メッセージだけではなく、リアルタイム チャット アプリなどの他のソースからのメッセージも処理するように設計されているため、よりリッチなチャット/メッセージング エクスペリエンスを提供できます。




<!--HONumber=Aug16_HO3-->


