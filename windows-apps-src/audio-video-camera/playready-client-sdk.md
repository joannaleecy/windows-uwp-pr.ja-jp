---
author: eliotcowley
ms.assetid: DD8FFA8C-DFF0-41E3-8F7A-345C5A248FC2
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。
title: PlayReady DRM
---

# PlayReady DRM

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]


このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。

PlayReady DRM を使うと、開発者はコンテンツ プロバイダーが定義したアクセス ルールを適用しながら、ユーザーに PlayReady コンテンツを提供することができる UWP アプリを作成できます。 ここでは、Windows 10 用の Microsoft PlayReady DRM に加えられた変更と、PlayReady UWP アプリを変更して、以前の Windows 8.1 バージョンから Windows 10 バージョンに加えられた変更をサポートする方法について説明します。
 
| トピック                                                                     | 説明                                                                                                                                                                                                                                                                             |
|---------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [ハードウェア DRM](hardware-drm.md)                                           | このトピックでは、PlayReady ハードウェア ベースのデジタル著作権管理 (DRM) を UWP アプリに追加する方法の概要を示します。                                                                                                                                                                 |
| [PlayReady を使ったアダプティブ ストリーミング](adaptive-streaming-with-playready.md) | この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。 |

## PlayReady DRM の新機能

次に、Windows 10 用の PlayReady DRM に関する新機能や変更点について説明します。

-   追加されたハードウェア デジタル著作権管理 (DRM)。

    ハードウェア ベースのコンテンツ保護により、複数のデバイス プラットフォーム上で、高解像度 (HD) と超高解像度 (UHD) のコンテンツを安全に再生できます。 キー マテリアル (秘密キー、コンテンツ キー、これらのキーを派生またはロック解除するために使われるその他のキー マテリアルを含みます)、および暗号化解除された圧縮および非圧縮ビデオ サンプルは、ハードウェア セキュリティを利用して保護されます。 ハードウェア DRM の使用中は、HWDRM パイプラインは使用中の出力を判別できるため、不明な有効機能 (不明な再生/低解像度の不明な再生) は意味を持ちません。 詳しくは、「[ハードウェア DRM](hardware-drm.md)」をご覧ください。

-   PlayReady は AppX フレームワーク コンポーネントではなく、インボックス オペレーティング システム コンポーネントになりました。 名前空間は、**Microsoft.Media.PlayReadyClient** から [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454) に変更されました。
-   PlayReady のエラー コードを定義する Windows.Media.Protection.PlayReadyErrors.h と Windows.Media.Protection.PlayReadyResults.h ヘッダーは、Windows ソフトウェア開発キット (Windows SDK) の一部になりました。
-   永続的でないライセンスの事前の取得を提供します。

    以前のバージョンの PlayReady DRM は、永続的でないライセンスの事前取得をサポートしませんでした。 この機能は、このバージョンに追加されました。 これにより、最初のフレームまでの時間を減らすことができます。 詳しくは、「[再生する前に永続的でないライセンスを事前に取得する](#proactively_acquire_a_non_persistent_license_before_playback)」をご覧ください。

-   1 つのメッセージで複数のライセンスを取得できるようにします。

    クライアント アプリが、1 つのライセンス取得メッセージで複数の永続的でないライセンスを取得できるようにします。 これにより、ユーザーがコンテンツ ライブラリを閲覧中に、複数のコンテンツのライセンスを取得して、最初のフレームまでの時間を短縮することができます。この結果、ユーザーが再生するコンテンツを選択したときに、ライセンス取得の遅延を回避できます。 さらに、複数のキー識別子 (KID) を含むコンテンツ ヘッダーを有効にして、オーディオとビデオのストリームを個別のキーに暗号化できます。これにより、カスタム ロジックと複数のライセンス取得要求を使って同じ結果を得る代わりに、単一ライセンスの取得で、コンテンツ ファイル内のすべてのストリームのすべてのライセンスを取得できます。

-   リアルタイムの有効期限のサポートや期間限定ライセンス (LDL) が追加されました。

    ライセンスにリアルタイムの有効期限を設定し、再生中に、有効期限が切れるライセンスから別の (有効な) ライセンスにスムーズに移行することができます。 1 つのメッセージで複数のライセンスの取得と組み合わせることにより、アプリは、ユーザーがコンテンツ ライブラリを閲覧中に、いくつかの LDL を非同期的に取得することができ、ユーザーが再生するコンテンツを選ぶと、期間の長いライセンスのみを取得することができます。 次に、再生はより迅速に開始し (ライセンスが既に利用できるため)、LDL の有効期限が切れるまでに、アプリはより長い期間のライセンスを取得するため、中断なく、コンテンツの最後までスムーズに再生を続行します。

-   永続的でないライセンス チェーンを追加しました。
-   永続的でないライセンスで、時間ベースの制限 (有効期限、最初のプレイ後の有効期限切れ、リアルタイムの有効期限を含む) のサポートを追加しました。
-   HDCP Type 1 (バージョン 2.2) ポリシーのサポートを追加しました。

    詳しくは、「[考慮事項](#things_to_consider)」をご覧ください。

-   Miracast が暗黙的な出力となりました。
-   セキュア ストップが追加されました。

    セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。 この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。

-   オーディオとビデオに関するライセンスの分離が追加されました。

    トラックを分離することによって、ビデオがオーディオにデコードされるのを防ぐことができます。これにより、さらに強力なコンテンツ保護が可能になります。 最新の標準では、オーディオ トラックと映像トラックに対して別々のキーが必要になります。

-   MaxResDecode が追加されました。

    この機能は、コンテンツの再生を最大解像度に制限するために追加されました (ライセンスではなく、より強力なキーを所有している場合にも制限を受けます)。 これは、複数のストリーム サイズが 1 つのキーでエンコードされる状況をサポートします。

PlayReady DRM に、次の新しいインターフェイス、クラス、列挙子が追加されました。

-   [
              **IPlayReadyLicenseAcquisitionServiceRequest**
            ](https://msdn.microsoft.com/library/windows/apps/dn986077) インターフェイス
-   [
              **IPlayReadyLicenseSession**
            ](https://msdn.microsoft.com/library/windows/apps/dn986080) インターフェイス
-   [
              **IPlayReadySecureStopServiceRequest**
            ](https://msdn.microsoft.com/library/windows/apps/dn986090) インターフェイス
-   [
              **PlayReadyLicenseSession**
            ](https://msdn.microsoft.com/library/windows/apps/dn986309) クラス
-   [
              **PlayReadySecureStopIterable**
            ](https://msdn.microsoft.com/library/windows/apps/dn986371) クラス
-   [
              **PlayReadySecureStopIterator**
            ](https://msdn.microsoft.com/library/windows/apps/dn986375) クラス
-   [
              **PlayReadyHardwareDRMFeatures**
            ](https://msdn.microsoft.com/library/windows/apps/dn986265) 列挙子

PlayReady DRM の新機能を利用する方法を示すために、新しいサンプルが作成されました。 このサンプルは、[http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670) からダウンロードできます。

## 考慮事項

-   PlayReady DRM は、HDCP Type 1 (バージョン 2.2 以降) をサポートするようになりました。 PlayReady は、デバイスが適用するライセンスでポリシーを持っています。 この機能は、PlayReady Server v3.0 SDK ライセンスで有効にできます (サーバーは、再生の有効機能 **GUID** を使って、ライセンスでこのポリシーを管理します)。 詳しくは、「[PlayReady の適合性と信頼性規則](http://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。
-   Windows Media Video (VC-1 とも呼ばれます) はハードウェア DRM ではサポートされません (「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください)。
-   PlayReady DRM は、高効率ビデオ コーディング (HEVC/H.265) ビデオ圧縮規格をサポートしています。 アプリは、HEVC をサポートするには、コンテンツのスライス ヘッダーがクリア テキストのままになる、Common Encryption Scheme (CENC) バージョン 2 のコンテンツを使う必要があります。 詳しくは、「ISO/IEC 23001-7 情報テクノロジ -- MPEG システム テクノロジ -- パート 7: ISO ベース メディア ファイル形式ファイルの一般的な暗号化」をご覧ください。(仕様バージョン ISO/IEC 23001-7:2015 以降が必要です)。 また、すべて HWDRM のコンテンツで、CENC バージョン 2 を使うことをお勧めします。 さらに、ハードウェア DRM によって、HEVC をサポートするものとそうでないものがあります (「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください)。
-   新しい PlayReady 3.0 機能 (ハードウェア ベースのクライアント用の SL3000、1 つのライセンス取得メッセージでの永続的でない複数のライセンスの取得、永続的でないライセンスでの時間ベースの制限を含みますが、これらに限定されません) を活用するには、PlayReady サーバーが、Microsoft PlayReady サーバー ソフトウェア開発キット v3.0.2769 リリース バージョン以降である必要があります。
-   コンテンツ ライセンスで指定された、出力保護ポリシーによっては、接続されている出力がこれらの要件をサポートしていない場合、メディアの再生はエンド ユーザーに対して失敗する可能性があります。 次の表は、結果として発生する一般的なエラーを示しています。 詳しくは、「[PlayReady の適合性と信頼性規則](http://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。

| エラー                                                   | 値      | 説明                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                 |
|---------------------------------------------------------|------------|-------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| ERROR\_GRAPHICS\_OPM\_OUTPUT\_DOES\_NOT\_SUPPORT\_HDCP  | 0xC0262513 | ライセンスの出力保護ポリシーでは、モニターが HDCP をエンゲージする必要がありますが、HDCP をエンゲージできませんでした。                                                                                                                                                                                                                                                                                                                                                                                              |
| MF\_E\_POLICY\_UNSUPPORTED                              | 0xC00D7159 | ライセンスの出力保護ポリシーでは、モニターが HDCP Type 1 をエンゲージする必要がありますが、HDCP Type 1 をエンゲージできませんでした。                                                                                                                                                                                                                                                                                                                                                                                |
| DRM\_E\_TEE\_OUTPUT\_PROTECTION\_REQUIREMENTS\_NOT\_MET | 0x8004CD22 | このエラー コードは、ハードウェア DRM で実行されている場合にのみ発生します。 ライセンスの出力保護ポリシーでは、モニターが HDCP をエンゲージするか、コンテンツの実質的な解像度を減らす必要がありますが、ハードウェア DRM はコンテンツの解像度の減少をサポートしていないため、HDCP をエンゲージできず、コンテンツの実質的な解像度を減らすことができませんでした。 ソフトウェア DRM で、コンテンツは再生されます。 「[ハードウェア DRM を使うための考慮事項](hardware-drm.md#considerations-for-using-hardware-drm)」をご覧ください。 |
| ERROR\_GRAPHICS\_OPM\_NOT\_SUPPORTED                    | 0xc0262500 | グラフィックス ドライバーは、出力保護をサポートしていません。 たとえば、モニターが VGA 経由で接続されているか、デジタル出力用の適切なグラフィックス ドライバーがインストールされていません。 後者の場合、インストールされている一般的なドライバーは Microsoft ベーシック ディスプレイ アダプターであり、適切なグラフィックス ドライバーをインストールすることで、問題が解決されます。                                                                                                                                                  |

## 前提条件

PlayReady で保護された UWP アプリの作成を開始する前に、次のソフトウェアがシステムにインストールされている必要があります。

-   Windows 10。
-   UWP アプリ用の PlayReady DRM のサンプルをコンパイルする場合、サンプルをコンパイルするには Microsoft Visual Studio 2015 以降を使う必要があります。 引き続き、Microsoft Visual Studio 2013 を使って、Windows 8.1 ストア アプリ用の PlayReady DRM の任意のサンプルをコンパイルできます。

アプリで MPEG-2/H.262 コンテンツの再生を計画している場合は、[Windows 8.1 Media Center Pack](http://go.microsoft.com/fwlink/p/?LinkId=626876) をダウンロードしてインストールする必要もあります。

## PlayReady Windows ストア アプリの移行ガイド

このセクションには、既にある PlayReady Windows 8.x ストア アプリを Windows 10 に移行する方法についての情報が含まれています。

Windows 10 の PlayReady UWP アプリの名前空間は、**Microsoft.Media.PlayReadyClient** から [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454) に変更されました。 つまり、コード内で以前の名前空間を探し、新しい名前空間に置き換える必要があります。 winmd ファイルは、引き続き参照されます。 このファイルは、Windows 10 オペレーティング システムの windows.media.winmd の 1 つであり、 TH の Windows SDK の一部として、windows.winmd に含まれています。 winmd ファイルは、UWP では、windows.foundation.univeralappcontract.winmd で参照されます。

PlayReady で保護された高解像度 (HD) コンテンツ (1080p) および超高解像度 (UHD) コンテンツを再生するには、PlayReady ハードウェア DRM を実装する必要があります。 PlayReady ハードウェア DRM を実装する方法について詳しくは、「[ハードウェア DRM](hardware-drm.md)」をご覧ください。

一部のコンテンツは、ハードウェア DRM ではサポートされません。 ハードウェア DRM の無効化とソフトウェア DRM の有効化について詳しくは、「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください。

メディア保護マネージャーについては、コードに次の設定を必ず含めてください (まだ含まれていない場合)。

```cs
var mediaProtectionManager = new Windows.Media.Protection.MediaProtectionManager();

mediaProtectionManager.properties["Windows.Media.Protection.MediaProtectionSystemId"] = 
             '{F4637010-03C3-42CD-B932-B48ADF3A6A54}'
var cpsystems = new Windows.Foundation.Collections.PropertySet();
cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = 
                "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput";
mediaProtectionManager.properties["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;

mediaProtectionManager.properties["Windows.Media.Protection.MediaProtectionContainerGuid"] = 
                "{9A04F079-9840-4286-AB92-E65BE0885F95}";
```

## 再生する前に永続的でないライセンスを事前に取得する

このセクションでは、再生を開始する前に、永続的でないライセンスを事前に取得する方法について説明します。

以前のバージョンの PlayReady DRM では、永続的でないライセンスは、再生中のみ反応的に取得できました。 このバージョンでは、再生を開始する前に、永続的でないライセンスを事前に取得することができます。

1.  永続的でないライセンスを格納できる再生セッションを事前に作成します。 例:

    ```cs
    var cpsystems = new Windows.Foundation.Collections.PropertySet();       
    cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput"; // PlayReady

    var pmpSystemInfo = new Windows.Foundation.Collections.PropertySet();
    pmpSystemInfo["Windows.Media.Protection.MediaProtectionSystemId"] = "{F4637010-03C3-42CD-B932-B48ADF3A6A54}";
    pmpSystemInfo["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;
    var pmpServer = new Windows.Media.Protection.MediaProtectionPMPServer( pmpSystemInfo );
    ```

2.  その再生セッションをライセンス取得クラスに結び付けます。 例:

    ```cs
    var licenseSessionProperties = new Windows.Foundation.Collections.PropertySet();
    licenseSessionProperties["Windows.Media.Protection.MediaProtectionPMPServer"] = pmpServer;
    var licenseSession = new Windows.Media.Protection.PlayReady.PlayReadyLicenseSession( licenseSessionProperties );
    ```

3.  ライセンス サービス要求を作成します。 例:

    ```cs
    var laSR = licenseSession.CreateLAServiceRequest();
    ```

4.  手順 3. で作成したサービスの要求を使ってライセンスの取得を実行します。 ライセンスは、再生セッションに格納されます。
5.  再生のメディア ソースに再生セッションに結び付けます。 例:

    ```cs
    licenseSession.configureMediaProtectionManager( mediaProtectionManager );
    videoPlayer.msSetMediaProtectionManager( mediaProtectionManager );
    ```
    
## セキュア ストップの追加

このセクションでは、UWP アプリにセキュア ストップを追加する方法を説明します。

セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。 この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。

セキュア ストップのチャレンジを送信する主なシナリオが 2 つあります。

-   コンテンツの最後に達したか、ユーザーがメディア プレゼンテーションを途中で停止したため、メディア プレゼンテーションが停止した場合。
-   (システムまたはアプリのクラッシュなどにより) 前回のセッションが予期せずに終了した場合。 アプリは、起動時またはシャットダウン時に、未処理のセキュア ストップ セッションについて照会し、その他のメディア再生とは別にチャレンジを送信する必要があります。

セキュア ストップのサンプル実装については、[http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670) にある PlayReady サンプルの securestop.cs ファイルをご覧ください。

 

 






<!--HONumber=May16_HO2-->


