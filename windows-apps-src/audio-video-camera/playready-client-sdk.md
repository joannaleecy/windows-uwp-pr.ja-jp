---
ms.assetid: DD8FFA8C-DFF0-41E3-8F7A-345C5A248FC2
description: このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。
title: PlayReady DRM
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 4fac02f892c66a1bcf0b08986ae00a3a162b44ca
ms.sourcegitcommit: d2517e522cacc5240f7dffd5bc1eaa278e3f7768
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/30/2018
ms.locfileid: "8335207"
---
# <a name="playready-drm"></a>PlayReady DRM



このトピックでは、ユニバーサル Windows プラットフォーム (UWP) アプリに PlayReady で保護されたメディア コンテンツを追加する方法について説明します。

PlayReady DRM を使うと、開発者はコンテンツ プロバイダーが定義したアクセス ルールを適用しながら、ユーザーに PlayReady コンテンツを提供することができる UWP アプリを作成できます。 このセクションでは、以前の Windows8.1 バージョンから windows 10 バージョンに加えられた変更をサポートするために、PlayReady UWP アプリを変更する方法と windows 10 用の Microsoft PlayReady DRM に加えられた変更について説明します。
 
| トピック                                                                     | 説明                                                                                                                                                                                                                                                                             |
|---------------------------------------------------------------------------|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [ハードウェア DRM](hardware-drm.md)                                           | このトピックでは、PlayReady ハードウェア ベースのデジタル著作権管理 (DRM) を UWP アプリに追加する方法の概要を示します。                                                                                                                                                                 |
| [PlayReady を使ったアダプティブ ストリーミング](adaptive-streaming-with-playready.md) | この記事では、ユニバーサル Windows プラットフォーム (UWP) アプリに、Microsoft PlayReady コンテンツ保護を使ったマルチメディア コンテンツのアダプティブ ストリーミングを追加する方法について説明します。 現在、この機能では、HTTP ライブ ストリーミング (HLS) と Dynamic Adaptive Streaming over HTTP (DASH) コンテンツの再生がサポートされています。 |

## <a name="whats-new-in-playready-drm"></a>PlayReady DRM の新機能

次の一覧は、新しい機能と windows 10 用の PlayReady DRM に加えられた変更について説明します。

-   追加されたハードウェア デジタル著作権管理 (HWDRM)。

    ハードウェア ベースのコンテンツ保護により、複数のデバイス プラットフォーム上で、高解像度 (HD) と超高解像度 (UHD) のコンテンツを安全に再生できます。 キー マテリアル (秘密キー、コンテンツ キー、これらのキーを派生またはロック解除するために使われるその他のキー マテリアルを含みます)、および暗号化解除された圧縮および非圧縮ビデオ サンプルは、ハードウェア セキュリティを利用して保護されます。 ハードウェア DRM の使用中は、HWDRM パイプラインは使用中の出力を常に判別できるため、不明な有効機能 (不明な再生/低解像度の不明な再生) も意味を持ちません。 詳しくは、「[ハードウェア DRM](hardware-drm.md)」をご覧ください。

-   PlayReady は AppX フレームワーク コンポーネントではなく、インボックス オペレーティング システム コンポーネントになりました。 名前空間は、**Microsoft.Media.PlayReadyClient** から [**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454) に変更されました。
-   PlayReady のエラー コードを定義する Windows.Media.Protection.PlayReadyErrors.h と Windows.Media.Protection.PlayReadyResults.h ヘッダーは、Windows ソフトウェア開発キット (Windows SDK) の一部になりました。
-   永続的でないライセンスの事前の取得を提供します。

    以前のバージョンの PlayReady DRM は、永続的でないライセンスの事前取得をサポートしませんでした。 この機能は、このバージョンに追加されました。 これにより、最初のフレームまでの時間を減らすことができます。 詳しくは、「[再生する前に永続的でないライセンスを事前に取得する](#proactively-acquire-a-non-persistent-license-before-playback)」をご覧ください。

-   1 つのメッセージで複数のライセンスを取得できるようにします。

    クライアント アプリが、1 つのライセンス取得メッセージで複数の永続的でないライセンスを取得できるようにします。 これにより、ユーザーがコンテンツ ライブラリを閲覧中に、複数のコンテンツのライセンスを取得して、最初のフレームまでの時間を短縮することができます。この結果、ユーザーが再生するコンテンツを選択したときに、ライセンス取得の遅延を回避できます。 さらに、複数のキー識別子 (KID) を含むコンテンツ ヘッダーを有効にして、オーディオとビデオのストリームを個別のキーに暗号化できます。これにより、カスタム ロジックと複数のライセンス取得要求を使って同じ結果を得る代わりに、単一ライセンスの取得で、コンテンツ ファイル内のすべてのストリームのすべてのライセンスを取得できます。

-   リアルタイムの有効期限のサポートや期間限定ライセンス (LDL) が追加されました。

    ライセンスにリアルタイムの有効期限を設定し、再生中に、有効期限が切れるライセンスから別の (有効な) ライセンスにスムーズに移行することができます。 1 つのメッセージで複数のライセンスの取得と組み合わせることにより、アプリは、ユーザーがコンテンツ ライブラリを閲覧中に、いくつかの LDL を非同期的に取得することができ、ユーザーが再生するコンテンツを選ぶと、期間の長いライセンスのみを取得することができます。 次に、再生はより迅速に開始し (ライセンスが既に利用できるため)、LDL の有効期限が切れるまでに、アプリはより長い期間のライセンスを取得するため、中断なく、コンテンツの最後までスムーズに再生を続行します。

-   永続的でないライセンス チェーンを追加しました。
-   永続的でないライセンスで、時間ベースの制限 (有効期限、最初のプレイ後の有効期限切れ、リアルタイムの有効期限を含む) のサポートを追加しました。
-   HDCP Type 1 (Windows 10 ではバージョン 2.2) ポリシーのサポートを追加しました。

    詳しくは、「[考慮事項](#things-to-consider)」をご覧ください。

-   Miracast が暗黙的な出力となりました。
-   セキュア ストップが追加されました。

    セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。 この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。

-   オーディオとビデオに関するライセンスの分離が追加されました。

    トラックを分離することによって、ビデオがオーディオにデコードされるのを防ぐことができます。これにより、さらに強力なコンテンツ保護が可能になります。 最新の標準では、オーディオ トラックと映像トラックに対して別々のキーが必要になります。

-   MaxResDecode が追加されました。

    この機能は、コンテンツの再生を最大解像度に制限するために追加されました (ライセンスではなく、より強力なキーを所有している場合にも制限を受けます)。 これは、複数のストリーム サイズが 1 つのキーでエンコードされる状況をサポートします。

PlayReady DRM に、次の新しいインターフェイス、クラス、列挙子が追加されました。

-   [**IPlayReadyLicenseAcquisitionServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986077) インターフェイス
-   [**IPlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986080) インターフェイス
-   [**IPlayReadySecureStopServiceRequest**](https://msdn.microsoft.com/library/windows/apps/dn986090) インターフェイス
-   [**PlayReadyLicenseSession**](https://msdn.microsoft.com/library/windows/apps/dn986309) クラス
-   [**PlayReadySecureStopIterable**](https://msdn.microsoft.com/library/windows/apps/dn986371) クラス
-   [**PlayReadySecureStopIterator**](https://msdn.microsoft.com/library/windows/apps/dn986375) クラス
-   [**PlayReadyHardwareDRMFeatures**](https://msdn.microsoft.com/library/windows/apps/dn986265) 列挙子

PlayReady DRM の新機能を利用する方法を示すために、新しいサンプルが作成されました。 サンプルは、[http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670) からダウンロードできます。

## <a name="things-to-consider"></a>考慮事項

-   PlayReady DRM は、HDCP Type 1 (HDCP バージョン 2.1 以降でサポートされます) をサポートするようになりました。 PlayReady は、デバイスが適用するライセンスで HDCP タイプ制限ポリシーを持っています。 Windows 10 では、このポリシーにより HDCP 2.2 以降がエンゲージされます。 この機能は、PlayReady Server v3.0 SDK ライセンスで有効にできます (サーバーは、HDCP タイプ制限 GUID を使って、ライセンスでこのポリシーを管理します)。 詳しくは、「[PlayReady の適合性と信頼性規則](http://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。
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

## <a name="output-protection"></a>出力保護

次のセクションでは、PlayReady ライセンスの出力保護ポリシーを用いて Windows 10 用の PlayReady DRM を使用する場合の動作について説明します。

PlayReady DRM でサポートされる出力保護レベルは、**Microsoft PlayReady の拡張可能なメディア使用権仕様**に記載されています。 このドキュメントは、PlayReady ライセンス製品に付属しているドキュメント パッケージに含まれています。

> [!NOTE]
> ライセンス サーバーで設定できる出力保護レベルの許容値は、[PlayReady の適合性規則](https://www.microsoft.com/playready/licensing/compliance/)に準拠します。

PlayReady DRM では、PlayReady の適合性規則で指定された出力コネクタ上でのみ出力保護ポリシーを使用してコンテンツを再生できます。 PlayReady の適合性規則で指定された出力コネクタの条件について詳しくは、[PlayReady の適合性と信頼性規則の定義済みの条件](https://www.microsoft.com/playready/licensing/compliance/)をご覧ください

このセクションは、主に Windows 10 用の PlayReady DRM と、一部の Windows クライアントでも利用できる Windows 10 用の PlayReady ハードウェア DRM を使用した出力保護シナリオについて扱います。 PlayReady HWDRM を使用すると、すべての出力保護は Windows TEE 実装内から適用されます ([ハードウェア DRM](hardware-drm.md) をご覧ください)。 このため、PlayReady SWDRM (ソフトウェア DRM) を使用する場合とは一部の動作が異なります。

* 未圧縮デジタル ビデオ用の出力保護レベル (OPL) 270 のサポート。Windows 10 用の PlayReady HWDRM では解像度の低下がサポートされず、HDCP (高帯域幅デジタル コンテンツ保護) がエンゲージされます。 HWDRM の高解像度コンテンツには、270 を超える OPL をお勧めします (ただし、必須ではありません)。 さらに、ライセンス (HDCP バージョン 2.2 以降) で HDCP タイプ制限を設定する必要があります。
* SWDRM とは異なり、HWDRM を使用すると、出力の保護は最も能力の低いモニターに基づいてすべてのモニターに適用されます。 たとえば、ユーザーが 2 台のモニターを接続していて、1 台が HDCP をサポートし、もう 1 台がサポートしていない場合、HDCP をサポートするモニターでコンテンツがレンダリングされているのみの場合でも、ライセンスに HDCP が必要な場合、再生は失敗します。 SWDRM では、HDCP をサポートされているモニターにレンダリングされているのみの場合、コンテンツは再生されます。
* コンテンツのキーとライセンスで、次の条件が満たされていない限り、HWDRM はクライアントで使用され、安全であることが保証されません。
    * ビデオのコンテンツ キーに使われるライセンスには、最低限のセキュリティ レベルとして 3000 が必要です。
    * オーディオは、ビデオとは異なるコンテンツ キーに暗号化される必要があります。また、オーディオに使われるライセンスには、最低限のセキュリティ レベルとして 2000 が必要です。 または、オーディオをプレーン テキストのままにすることもできます。
* すべての SWDRM のシナリオでは、オーディオやビデオのコンテンツ キーに使用される PlayReady ライセンスの最低限のセキュリティ レベルが 2000 以下である必要があります。

### <a name="output-protection-levels"></a>出力保護レベル

次の表では、PlayReady ライセンスのさまざまな OPL 間のマッピングと、Windows 10 用の PlayReady DRM でそれらを適用する方法の概要を示します。

#### <a name="video"></a>ビデオ

<table>
    <tr>
        <th rowspan="2">OPL</th>
        <th>圧縮デジタル ビデオ</th>
        <th colspan="2">未圧縮デジタル ビデオ</th>
        <th>アナログ テレビ</th>
    </tr>
    <tr>
        <th>任意</th>
        <th colspan="2">HDMI、DVI、DisplayPort、MHL</th>
        <th>コンポジット、コンポーネント</th>
    </tr>
    <tr>
        <th>100</th>
        <td rowspan="6">該当なし。\*</td>
        <td colspan="2">コンテンツが渡されます。</td>
        <td>コンテンツが渡されます。</td>
    </tr>
    <tr>
        <th>150</th>
        <td colspan="2" rowspan="2">該当なし。\*</td>
        <td>CGMS-A CopyNever がエンゲージされている場合、または CGMS-A をエンゲージできない場合に、コンテンツが渡されます。</td>
    </tr>
    <tr>
        <th>200</th>
        <td>CGMS-A CopyNever がエンゲージされている場合に、コンテンツが渡されます。</td>
    </tr>
    <tr>
        <th>250</th>
        <td colspan="2">HDCP に対するエンゲージを試みますが、結果にかかわらずコンテンツが渡されます。</td>
        <td rowspan="5">該当なし。\*</td>
    </tr>
    <tr>
        <th>270</th>
        <td><b>SWDRM</b>: HDCP のエンゲージを試みます。 HDCP をエンゲージできない場合、PC は 1 フレームあたりの有効な解像度を 520,000 ピクセルに制限し、コンテンツが渡されます。</td>
        <td><b>HWDRM</b>: HDCP を使用してコンテンツが渡されます。 HDCP をエンゲージできない場合、HDMI ポートと DVI ポートでの再生はブロックされます</td>
    </tr>
    <tr>
        <th>300</th>
        <td colspan="2">
            <p>
                **HDCP のタイプ制限が定義されていない場合:** HDCP でコンテンツを渡されます。 HDCP をエンゲージできない場合、HDMI ポートと DVI ポートでの再生はブロックされます。
            </p>
            <p>
                **HDCP のタイプ制限が定義されている場合**: HDCP 2.2 でコンテンツが渡され、コンテンツ ストリーム タイプが 1 に設定されます。 HDCP をエンゲージできない、またはコンテンツ ストリーム タイプを 1 に設定できない場合、HDMI ポートと DVI ポートでの再生はブロックされます。
            </p>
        </td>
    </tr>
    <tr>
        <th>400</th>
        <td rowspan="2">Windows 10 では、後続の OPL 値に関わらず、圧縮デジタル ビデオ コンテンツが出力に渡されることはありません。 圧縮デジタル ビデオ コンテンツについて詳しくは、<a href="https://www.microsoft.com/playready/licensing/compliance/">PlayReady 製品の適合規則</a>をご覧ください。</td>
        <td colspan="2" rowspan="2">該当なし。\*</td>
    </tr>
    <tr>
        <th>500</th>
    </tr>
</table>
<br/>

\* 出力保護レベルの値の中には、ライセンス サーバーによって設定できないものもあります。 詳しくは、「[PlayReady の適合性規則](https://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。

#### <a name="audio"></a>オーディオ

<table>
    <tr>
        <th rowspan="2">OPL</th>
        <th>圧縮デジタル オーディオ</th>
        <th>未圧縮デジタル オーディオ</th>
        <th>アナログまたは USB オーディオ</th>
    </tr>
    <tr>
        <th>HDMI、DisplayPort、MHL</th>
        <th>HDMI、DisplayPort、MHL</th>
        <th>任意</th>
    </tr>
    <tr>
        <th>100</th>
        <td rowspan="3">コンテンツが渡されます。</td>
        <td>コンテンツが渡されます。</td>
        <td rowspan="5">コンテンツが渡されます。</td>
    </tr>
    <tr>
        <th>150</th>
        <td rowspan="4">コンテンツは渡されません。</td>
    </tr>
    <tr>
        <th>200</th>
    </tr>
    <tr>
        <th>250</th>
        <td>HDMI、DisplayPort、または MHL で HDCP がエンゲージされている場合、または SCMS がエンゲージされて CopyNever に設定されている場合、コンテンツが渡されます。</td>
    </tr>
    <tr>
        <th>300</th>
        <td>HDMI、DisplayPort、または MHL で HDCP がエンゲージされている場合にコンテンツが渡されます。</td>
    </tr>
</table>
<br/>

### <a name="miracast"></a>Miracast

PlayReady DRM では、HDCP 2.0 以降がエンゲージされるとすぐに Miracast 出力を通じてコンテンツを再生できます。 ただし、Windows 10 では Miracast は*デジタル*出力と見なされます。 Miracast シナリオについて詳しくは、[PlayReady の適合規則](https://www.microsoft.com/playready/licensing/compliance/)をご覧ください。 次の表に、PlayReady ライセンスのさまざまな OPL 間のマッピングと、PlayReady DRM でそれらを Miracast 出力に適用する方法について、概要を示します。

<table>
    <tr>
        <th>OPL</th>
        <th>圧縮デジタル オーディオ</th>
        <th>未圧縮デジタル オーディオ</th>
        <th>圧縮デジタル ビデオ</th>
        <th>未圧縮デジタル ビデオ</th>
    </tr>
    <tr>
        <th>100</th>
        <td rowspan="4">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。 エンゲージできない場合はコンテンツが渡されません。</td>
        <td>HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。 エンゲージできない場合はコンテンツが渡されません。</td>
        <td rowspan="6">該当なし。\*</td>
        <td>HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。 エンゲージできない場合はコンテンツが渡されません。</td>
    </tr>
    <tr>
        <th>150</th>
        <td rowspan="3">コンテンツは渡されません。</td>
        <td rowspan="2">該当なし。\*</td>
    </tr>
    <tr>
        <th>200</th>
    </tr>
    <tr>
        <th>250</th>
        <td rowspan="2">HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。 エンゲージできない場合はコンテンツが渡されません。</td>
    </tr>
    <tr>
        <th>270</th>
        <td colspan="2">該当なし。\*</td>
    </tr>
    <tr>
        <th>300</th>
        <td>HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。 エンゲージできない場合はコンテンツが渡されません。</td>
        <td>コンテンツは渡されません。</td>
        <td>
            <p>
                **HDCP のタイプ制限が定義されていない場合:** HDCP 2.0 以降がエンゲージされている場合はコンテンツが渡されます。 エンゲージできない場合はコンテンツが渡されません。
            </p>
            <p>
                **HDCP のタイプ制限が定義されている場合:** HDCP 2.2 でコンテンツが渡され、コンテンツ ストリーム タイプが 1 に設定されます。 HDCP をエンゲージできない場合、またはコンテンツ ストリーム タイプを 1 に設定できない場合、コンテンツは渡されません。
            </p>        
        </td>
    </tr>
    <tr>
        <th>400</th>
        <td rowspan="2" colspan="2">該当なし。\*</td>
        <td rowspan="2">Windows 10 では、後続の OPL 値に関わらず、圧縮デジタル ビデオ コンテンツが出力に渡されることはありません。 圧縮デジタル ビデオ コンテンツについて詳しくは、<a href="https://www.microsoft.com/playready/licensing/compliance/">PlayReady 製品の適合規則</a>をご覧ください。</td>
        <td rowspan="2">該当なし。\*</td>
    </tr>
    <tr>
        <th>500</th>
    </tr>
</table>
<br/>

\* 出力保護レベルの値の中には、ライセンス サーバーによって設定できないものもあります。 詳しくは、「[PlayReady の適合性規則](https://www.microsoft.com/playready/licensing/compliance/)」をご覧ください。

### <a name="additional-explicit-output-restrictions"></a>その他の明示的な出力制限

次の表では、明示的なデジタル ビデオ出力保護の制限に関する Windows 10 用の PlayReady DRM の実装を説明します。

<table>
    <tr>
        <th>シナリオ</th>
        <th>GUID</th>
        <th>条件</th>
        <th>結果</th>
    </tr>
    <tr>
        <th>有効な解像度の最大のデコード サイズ</th>
        <td>9645E831-E01D-4FFF-8342-0A720E3E028F</td>
        <td>接続された出力: デジタル ビデオ出力、Miracast、HDMI、DVI など</td>
        <td>
            <p>
                次のいずれかに制限される場合にコンテンツが渡されます。  
            </p>
            <ul>
                <li>(a) フレームの幅が最大フレーム幅以下で (ピクセル単位)、フレームの高さが最大フレーム高以下 (ピクセル単位)</li>
                <li>(b) フレームの高さが最大フレーム幅以下で (ピクセル単位)、フレームの幅が最大フレーム高以下 (ピクセル単位)</li>
            </ul>                   
        </td>
    </tr>
    <tr>
        <th>HDCP タイプの制限</th>
        <td>ABB2C6F1-E663-4625-A945-972D17B231E7</td>
        <td>接続された出力: デジタル ビデオ出力、Miracast、HDMI、DVI など</td>
        <td>HDCP 2.2 でコンテンツが渡され、コンテンツ ストリーム タイプが 1 に設定されます。 HDCP 2.2 をエンゲージできない場合、またはコンテンツ ストリーム タイプを 1 に設定できない場合、コンテンツは渡されません。 未圧縮デジタル ビデオ出力の保護レベルに 271 以上の値が指定されている必要もあります。</td>
    </tr>
</table>
<br/>

次の表では、明示的なアナログ ビデオ出力保護の制限に関する Windows 10 用の PlayReady DRM の実装を説明します。

<table>
    <tr>
        <th>シナリオ</th>
        <th>GUID</th>
        <th>条件</th>
        <th colspan="2">結果</th>
    </tr>
    <tr>
        <th>アナログ コンピューター モニター</th>
        <td>D783A191-E083-4BAF-B2DA-E69F910B3772</td>
        <td>接続された出力: VGA、DVI&ndash;アナログなど</td>
        <td><b>SWDRM:</b> PC は有効な解像度を 1 フレームあたり 520,000 epx に制限し、コンテンツが渡されます。</td>
        <td><b>HWDRM:</b> コンテンツは渡されません。</td>
    </tr>
    <tr>
        <th>アナログ コンポーネント</th>
        <td>811C5110-46C8-4C6E-8163-C0482A15D47E</td>
        <td>接続された出力: コンポーネント</td>
        <td><b>SWDRM:</b> PC は有効な解像度を 1 フレームあたり 520,000 epx に制限し、コンテンツが渡されます。</td>
        <td><b>HWDRM:</b> コンテンツは渡されません。</td>
    </tr>
    <tr>
        <th rowspan="2">アナログ テレビ出力</th>
        <td>2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3</td>
        <td>アナログ テレビの OPL が 151 未満</td>
        <td colspan="2">CGMS-A がエンゲージされる必要があります。</td>
    </tr>
    <tr>
        <td>225CD36F-F132-49EF-BA8C-C91EA28E4369</td>
        <td>アナログ テレビ OPL は 101 未満で、ライセンスには 2098DE8D-7DDD-4BAB-96C6-32EBB6FABEA3 が含まれません。</td>
        <td colspan="2">CGMS-A のエンゲージが試行される必要はありますが、結果にかかわらずコンテンツが再生される可能性があります。</td>
    </tr>
    <tr>
        <th>自動ゲイン制御とカラー ストライプ</th>
        <td>C3FD11C6-F8B7-4D20-B008-1DB17D61F2DA</td>
        <td>520,000 ピクセル以下の解像度でコンテンツがアナログ TV 出力に渡される場合</td>
        <td colspan="2">解像度が 520,000 ピクセル未満のコンポーネント ビデオおよび PAL モードには自動ゲイン制御のみが設定され、解像度が 520,000 ピクセル未満の NTSC には自動ゲイン制御とカラー ストライプ情報が設定されます。これについては、適合規則のテーブル 3.5.7.3 に 記載されています。</td>
    </tr>
    <tr>
        <th>デジタルのみの出力</th>
        <td>760AE755-682A-41E0-B1B3-DCDF836A7306</td>
        <td>接続されている出力がアナログ</td>
        <td colspan="2">コンテンツは渡されません</td>
    </tr>
</table>
<br/>

> [!NOTE]
> "Mini DisplayPort to VGA" のようなアダプター ドングルを再生に使用する場合、Windows 10 ではその出力はデジタル ビデオ出力と見なされ、アナログ ビデオ ポリシーが適用されません。

次の表では、他の状況で再生を可能にする Windows 10 用の PlayReady DRM 実装について説明します。

<table>
    <tr>
        <th>シナリオ</th>
        <th>GUID</th>
        <th>条件</th>
        <th colspan="2">結果</th>
    </tr>
    <tr>
        <th>不明な出力</th>
        <td>786627D8-C2A6-44BE-8F88-08AE255B01A7</td>
        <td>出力を適切に特定できない場合、またはグラフィックス ドライバーで OPM を確立できない場合</td>
        <td><b>SWDRM:</b> コンテンツが渡されます。</td>
        <td><b>HWDRM:</b> コンテンツは渡されません。</td>
    </tr>
    <tr>
        <th>制限のある不明な出力</th>
        <td>B621D91F-EDCC-4035-8D4B-DC71760D43E9</td>
        <td>出力を適切に特定できない場合、またはグラフィックス ドライバーで OPM を確立できない場合</td>
        <td><b>SWDRM:</b> PC は有効な解像度を 1 フレームあたり 520,000 epx に制限し、コンテンツが渡されます。</td>
        <td><b>HWDRM:</b> コンテンツは渡されません。</td>
    </tr>
</table>
<br/>

## <a name="prerequisites"></a>前提条件

PlayReady で保護された UWP アプリの作成を開始する前に、次のソフトウェアがシステムにインストールされている必要があります。

-   Windows 10。
-   UWP アプリ用の PlayReady DRM の任意のサンプルをコンパイルするは場合、は、Microsoft Visual Studio2015 を使用する必要がありますか、後で、サンプルをコンパイルします。 Windows8.1 ストア アプリ用の PlayReady DRM のサンプルのいずれかをコンパイルするのに Microsoft Visual Studio2013 を引き続き使用できます。

<!--This is no longer available-->
<!--If you are planning to play back MPEG-2/H.262 content on your app, you must also download and install [Windows 8.1 Media Center Pack](http://go.microsoft.com/fwlink/p/?LinkId=626876).-->

## <a name="playready-uwp-app-migration-guide"></a>PlayReady UWP アプリの移行ガイド

このセクションには、既にある PlayReady Windows 8.x ストア アプリを windows 10 に移行する方法に関する情報が含まれます。

Windows 10 の PlayReady UWP アプリの名前空間は、 **Microsoft.Media.PlayReadyClient**から[**Windows.Media.Protection.PlayReady**](https://msdn.microsoft.com/library/windows/apps/dn986454)に変更されました。 つまり、コード内で以前の名前空間を探し、新しい名前空間に置き換える必要があります。 winmd ファイルは、引き続き参照されます。 Windows 10 オペレーティング システムで windows.media.winmd の一部です。 TH の Windows SDK の一部として、windows.winmd に含まれています。 winmd ファイルは、UWP では、windows.foundation.univeralappcontract.winmd で参照されます。

PlayReady で保護された高解像度 (HD) コンテンツ (1080p) および超高解像度 (UHD) コンテンツを再生するには、PlayReady ハードウェア DRM を実装する必要があります。 PlayReady ハードウェア DRM を実装する方法について詳しくは、「[ハードウェア DRM](hardware-drm.md)」をご覧ください。

一部のコンテンツは、ハードウェア DRM ではサポートされません。 ハードウェア DRM の無効化とソフトウェア DRM の有効化について詳しくは、「[ハードウェア DRM のオーバーライド](hardware-drm.md#override-hardware-drm)」をご覧ください。

メディア保護マネージャーについては、コードに次の設定を必ず含めてください (まだ含まれていない場合)。

```cs
var mediaProtectionManager = new Windows.Media.Protection.MediaProtectionManager();

mediaProtectionManager.Properties["Windows.Media.Protection.MediaProtectionSystemId"] = 
             '{F4637010-03C3-42CD-B932-B48ADF3A6A54}'
var cpsystems = new Windows.Foundation.Collections.PropertySet();
cpsystems["{F4637010-03C3-42CD-B932-B48ADF3A6A54}"] = 
                "Windows.Media.Protection.PlayReady.PlayReadyWinRTTrustedInput";
mediaProtectionManager.Properties["Windows.Media.Protection.MediaProtectionSystemIdMapping"] = cpsystems;

mediaProtectionManager.Properties["Windows.Media.Protection.MediaProtectionContainerGuid"] = 
                "{9A04F079-9840-4286-AB92-E65BE0885F95}";
```

## <a name="proactively-acquire-a-non-persistent-license-before-playback"></a>再生する前に永続的でないライセンスを事前に取得する

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
5.  再生のメディア ソースに再生セッションに結び付けます。 次に例を示します。

    ```cs
    licenseSession.configureMediaProtectionManager( mediaProtectionManager );
    videoPlayer.msSetMediaProtectionManager( mediaProtectionManager );
    ```
    
## <a name="query-for-protection-capabilities"></a>保護機能を照会する
Windows 10 Version 1703 以降では、デコード コーデック、解像度、出力保護 (HDCP) などの HW DRM 機能を照会できます。 クエリを実行するには、[**IsTypeSupported**](https://docs.microsoft.com/uwp/api/windows.media.protection.protectioncapabilities.istypesupported) メソッドを使います。このメソッドには、サポート状態を照会する機能を表す文字列と、クエリの適用先のキー システムを指定する文字列を指定します。 サポートされている文字列値の一覧については、API リファレンスの [**IsTypeSupported**](https://docs.microsoft.com/uwp/api/windows.media.protection.protectioncapabilities.istypesupported) のページをご覧ください。 次のコード例は、このメソッドの使用方法を示しています。  

    ```cs
    using namespace Windows::Media::Protection;

    ProtectionCapabilities^ sr = ref new ProtectionCapabilities();

    ProtectionCapabilityResult result = sr->IsTypeSupported(
    L"video/mp4; codecs=\"avc1.640028\"; features=\"decode-bpp=10,decode-fps=29.97,decode-res-x=1920,decode-res-y=1080\"",
    L"com.microsoft.playready");

    switch (result)
    {
        case ProtectionCapabilityResult::Probably:
        // Queue up UHD HW DRM video
        break;

        case ProtectionCapabilityResult::Maybe:
        // Check again after UI or poll for more info.
        break;

        case ProtectionCapabilityResult::NotSupported:
        // Do not queue up UHD HW DRM video.
        break;
    }
    ```
## <a name="add-secure-stop"></a>セキュア ストップを追加する

このセクションでは、UWP アプリにセキュア ストップを追加する方法を説明します。

セキュア ストップによって、特定のコンテンツについてのメディア再生が停止したメディア ストリーミング サービスに対して、PlayReady デバイスが確実にアサートするための手段が提供されます。 この機能により、メディア ストリーミング サービスは、特定のアカウントのさまざまなデバイスに対する使用制限を正しく適用し報告することができるようになります。

セキュア ストップのチャレンジを送信する主なシナリオが 2 つあります。

-   コンテンツの最後に達したか、ユーザーがメディア プレゼンテーションを途中で停止したため、メディア プレゼンテーションが停止した場合。
-   (システムまたはアプリのクラッシュなどにより) 前回のセッションが予期せずに終了した場合。 アプリは、起動時またはシャットダウン時に、未処理のセキュア ストップ セッションについて照会し、その他のメディア再生とは別にチャレンジを送信する必要があります。

セキュア ストップのサンプル実装については、[http://go.microsoft.com/fwlink/p/?linkid=331670&clcid=0x409](http://go.microsoft.com/fwlink/p/?linkid=331670) にある PlayReady サンプルの securestop.cs ファイルをご覧ください。

## <a name="use-playready-drm-on-xbox-one"></a>Xbox One での PlayReady DRM の使用

Xbox one の UWP アプリで PlayReady DRM を使用するには、を最初に、PlayReady を使用するための承認のためにアプリを公開することを使用している[パートナー センター](https://partner.microsoft.com/dashboard)のアカウントを登録する必要があります。 これは次の 2 つのいずれかの方法で行うことができます。

* Microsoft の連絡担当者を通じて許可を申請します。
* パートナー センター アカウントと会社名を送信することで、承認の適用[pronxbox@microsoft.com](mailto:pronxbox@microsoft.com)します。

許可を受信したら、追加の `<DeviceCapability>` をアプリ マニフェストに追加する必要があります。 アプリケーション マニフェスト デザイナーには現在利用できる設定がないため、これは手動で追加する必要があります。 構成するには、次の手順を実行します。

1. Visual Studio でプロジェクトを開き、**ソリューション エクスプローラー**を開いて **Package.appxmanifest** を右クリックします。
2. **[ファイルを開くアプリケーションの選択]** をクリックして **[XML (テキスト) エディター]** を選択し、**[OK]** をクリックします。
3. `<Capabilities>` タグの間に次の `<DeviceCapability>` を追加します。

    ```xml
    <DeviceCapability Name="6a7e5907-885c-4bcb-b40a-073c067bd3d5" />
    ```

4. ファイルを保存します。

最後に、Xbox One で PlayReady を使用する場合の最後の考慮事項として、開発キットでは、SL150 のみに使用が制限されています (SL2000 や SL3000 のコンテンツは再生できません)。 製品デバイスではセキュリティ レベルの高いコンテンツを再生できますが、開発キットでアプリをテストするには、SL150 のコンテンツを使用する必要があります。 このコンテンツのテストは、次のいずれかの方法で行うことができます。

* SL150 ライセンスを必要とするテスト コンテンツを選択して使用します。
* 特定の認証されたテスト アカウントのみが、特定のコンテンツについて SL150 ライセンスを取得できるようにロジックを実装します。

企業と製品に応じて最適なアプローチを使用してください。


## <a name="see-also"></a>関連項目
- [メディア再生](media-playback.md)




