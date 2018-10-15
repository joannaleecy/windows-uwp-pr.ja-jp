---
author: drewbatgit
ms.assetid: A7E0DA1E-535A-459E-9A35-68A4150EE9F5
description: このトピックでは、PlayReady ハードウェア ベースのデジタル著作権管理 (DRM) をユニバーサル Windows プラットフォーム (UWP) アプリに追加する方法の概要を示します。
title: ハードウェア DRM
ms.author: drewbat
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 160a4ab0ff5bdc40ea46ff6d8fb9fd8e47f560e3
ms.sourcegitcommit: 106aec1e59ba41aae2ac00f909b81bf7121a6ef1
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/15/2018
ms.locfileid: "4611972"
---
# <a name="hardware-drm"></a>ハードウェア DRM


このトピックでは、PlayReady ハードウェア ベースのデジタル著作権管理 (DRM) をユニバーサル Windows プラットフォーム (UWP) アプリに追加する方法の概要を示します。

> [!NOTE] 
> ハードウェア ベースの PlayReady DRM は、Windows デバイスや Windows 以外のデバイスを含む多種多様なデバイス (テレビ セット、電話、タブレットなど) でサポートされます。 PlayReady ハードウェア DRM をサポートする Windows デバイスの場合、Windows 10 を実行しており、サポート対象のハードウェア構成を備えている必要があります。

最近では、価値の高いコンテンツをアプリで再生するためのアクセス許可を付与できるように、ハードウェア ベースの保護に移行するコンテンツ プロバイダーが多くなっています。 PlayReady がこのニーズを満たすために、暗号化コアのハードウェアの実装の強力なサポートが追加されました。 このサポートにより、複数のデバイス プラットフォーム上で、高解像度 (1080 p) と超高解像度 (UHD) のコンテンツを安全に再生できます。 キー マテリアル (秘密キー、コンテンツ キー、これらのキーを派生またはロック解除するために使われるその他のキー マテリアルを含みます)、および暗号化解除された圧縮および非圧縮ビデオ サンプルは、ハードウェア セキュリティを利用して保護されます。

## <a name="windows-tee-implementation"></a>Windows TEE 実装

このトピックでは、Windows 10 で信頼された実行環境 (TEE) を実装する方法の概要を簡単に示します。

Windows TEE 実装の詳細については、このドキュメントでは説明しません。 ただし、標準の移植キット TEE ポートと Windows ポートの違いについては、簡単に説明します。 Windows は OEM プロキシ レイヤーを実装し、Windows メディア ファンデーション サブシステムのユーザー モード ドライバーに、シリアル化された PRITEE 関数呼び出しを転送します。 これは最終的に Windows TrEE (信頼される実行環境) ドライバーまたは OEM のグラフィックス ドライバーにルーティングされます。 これらのいずれの方法についても、このドキュメントでは説明しません。 次の図は、Windows ポートのコンポーネントの一般的な操作を示しています。 Windows PlayReady TEE 実装を開発する場合は、<WMLA@Microsoft.com> にご連絡ください。

![Windows TEE コンポーネント図](images/windowsteecomponentdiagram720.jpg)

## <a name="considerations-for-using-hardware-drm"></a>ハードウェア DRM を使うための考慮事項

このトピックでは、ハードウェア DRM を使うように設計されたアプリを開発するときに考慮する必要がある事項について、簡単な一覧を使って説明します。 「[PlayReady DRM](playready-client-sdk.md#output-protection)」で説明されているように、Windows 10 用 PlayReady HWDRM では、すべての出力の保護は、出力の保護の動作に影響を与える Windows TEE 実装内から適用されます。

-   **未圧縮デジタル ビデオ向けの出力保護レベル (OPL) 270 のサポート:** Windows 10 用 PlayReady HWDRM では、解像度の低下をサポートしておらず、HDCP が強制的に使われます。 HWDRM の高解像度コンテンツには、270 を超える OPL をお勧めします (ただし、必須ではありません)。 また、HDCP タイプの制限をライセンスで設定することもお勧めします (Windows 10 では HDCP バージョン 2.2)。
-   **出力の保護は、ソフトウェア DRM (SWDRM) とは異なり、最も能力の低いモニターに基づいてすべてのモニターに適用されます。** たとえば、ユーザーが 2 台のモニターを接続していて、1 台のモニターが HDCP をサポートし、もう 1 台がサポートしていない場合、HDCP をサポートするモニターでコンテンツがレンダリングされているのみの場合でも、ライセンスに HDCP が必要な場合、再生は失敗します。 ソフトウェア DRM では、HDCP をサポートしているモニターにレンダリングされているのみの場合、コンテンツは再生されます。
-   コンテンツのキーとライセンスで、**次の条件が満たされていない限り、HWDRM がクライアントで使用されることと、安全であることが保証されません**。
    -   ビデオのコンテンツ キーに使われるライセンスには、最低限のセキュリティ レベルとして 3000 が必要です。
    -   オーディオは、ビデオとは異なるコンテンツ キーに暗号化される必要があります。また、オーディオに使われるライセンスには、最低限のセキュリティ レベルとして 2000 が必要です。 または、オーディオをプレーン テキストのままにしてくこともできます。
    
HWDRM を使うときは、次の項目も考慮してください。

-   保護されたメディア プロセス (PMP) はサポートされません。
-   Windows Media ビデオ (VC-1 とも呼ばれます) はサポートされません (「[ハードウェア DRM のオーバーライド](#override-hardware-drm)」をご覧ください)。
-   永続的なライセンスには、複数のグラフィックス処理装置 (GPU) はサポートされません。

複数の GPU を持つコンピューターで、永続的なライセンスを処理するには、次のシナリオについて考えてみます。

1.  顧客が、グラフィックス カードが搭載された新しいコンピューターを購入します。
2.  顧客は、ハードウェア DRM の使用中に永続的なライセンスを取得するアプリを使います。
3.  これで、永続的なライセンスがそのグラフィックス カードのハードウェア キーにバインドされます。
4.  次に、顧客は新しいグラフィックス カードを取り付けます。
5.  ハッシュされたデータ ストア (HDS) 内のすべてのライセンスは、搭載されたビデオ カードにバインドされますが、ユーザーは新たに取り付けられたグラフィックス カードを使って、保護されたコンテンツを再生したいと考えています。

ハードウェアでライセンスの暗号化を解除できないことが原因で再生エラーが発生するのを防ぐために、PlayReady は、見つかったグラフィックス カードごとに、個別 HDS を使います。 これにより、PlayReady は、通常は既にライセンスを持っているコンテンツのライセンスの取得を試みます (ソフトウェア DRM の場合、またはハードウェアの変更がない場合、PlayReady はライセンスを再取得する必要はありません)。 したがって、アプリが、ハードウェア DRM の使用中に永続的なライセンスを取得した場合、アプリは、エンド ユーザーがグラフィックス カードを取り付けた (または取り外した) 場合にそのライセンスが実質的に失われるケースに対応できる必要があります。 これは一般的なシナリオではないため、ハードウェアの変更後にコンテンツが再生されなくなった場合、クライアント/サーバー コードでハードウェアの変更を処理する方法の調査よりも、サポートへの問い合わせの対応が必要になることがあります。

## <a name="override-hardware-drm"></a>ハードウェア DRM のオーバーライド

このセクションでは、再生するコンテンツがハードウェア DRM (HWDRM) をサポートしていない場合に、ハードウェア DRM をオーバーライドする方法について説明します。

既定では、システムによってサポートされている場合は、ハードウェア DRM が使われます。 ただし、一部のコンテンツは、ハードウェア DRM ではサポートされません。 この 1 つの例として、Cocktail コンテンツがあります。 別の例として、H.264 と HEVC 以外のビデオ コーデックを使う任意のコンテンツがあります。 さらに別の例として、HEVC コンテンツがあります。ハードウェアによって、HEVC をサポートしているものと、そうでないものがあります。 そのため、コンテンツを再生する場合に、ハードウェア DRM が該当のシステムでこれをサポートしていない場合は、ハードウェア DRM を除外することができます。

次の例は、ハードウェア DRM の除外方法を示しています。 この操作は、切り替えの前にのみ行う必要があります。 また、メモリ内に PlayReady オブジェクトが存在していないことも確認してください。存在する場合は、動作が未定義になります。

```js
var applicationData = Windows.Storage.ApplicationData.current;
var localSettings = applicationData.localSettings.createContainer("PlayReady", Windows.Storage.ApplicationDataCreateDisposition.always);
localSettings.values["SoftwareOverride"] = 1;
```

ハードウェア DRM に切り替えるには、**SoftwareOverride** の値を **0** に設定します。

すべてのメディア再生で、**MediaProtectionManager** を次のように設定する必要があります。

```js
mediaProtectionManager.properties["Windows.Media.Protection.UseSoftwareProtectionLayer"] = true;
```

ハードウェア DRM を使用しているか、ソフトウェア DRM は、C:\\Users\\ を参照するよう指示する最善の方法&lt;ユーザー名&gt;\\AppData\\Local\\Packages\\&lt;アプリケーション名&gt;\\LocalCache\\PlayReady\\\*

-   mspr.hds ファイルがある場合は、ソフトウェア DRM を使っています。
-   他の \*.hds ファイルがある場合は、ハードウェア DRM を使っています。
-   PlayReady フォルダー全体を削除して、テストを再試行することもできます。

## <a name="detect-the-type-of-hardware-drm"></a>ハードウェア DRM の種類を検出する

このセクションでは、システムでサポートされているハードウェア DRM の種類を検出する方法について説明します。

[**PlayReadyStatics.CheckSupportedHardware**](https://msdn.microsoft.com/library/windows/apps/dn986441) メソッドを使って、システムが特定のハードウェア DRM 機能をサポートしているかどうかを判断できます。 次に例を示します。

```csharp
bool isFeatureSupported = PlayReadyStatics.CheckSupportedHardware(PlayReadyHardwareDRMFeatures.HEVC);
```

[**PlayReadyHardwareDRMFeatures**](https://msdn.microsoft.com/library/windows/apps/dn986265) 列挙体には、照会できるハードウェア DRM 機能の値の有効な一覧が含まれます。 ハードウェア DRM がサポートされているかどうかを判断するには、クエリで **HardwareDRM** メンバーを使います。 ハードウェアが高効率ビデオ コーディング (HEVC)/H.265 コーデックをサポートしているかどうかを判断するには、クエリで **HEVC** メンバーを使います。

[**PlayReadyStatics.PlayReadyCertificateSecurityLevel**](https://msdn.microsoft.com/library/windows/apps/windows.media.protection.playready.playreadystatics.playreadycertificatesecuritylevel.aspx) プロパティを使って、クライアント証明書のセキュリティ レベルを取得し、ハードウェア DRM がサポートされているかどうか判断することもできます。 返された証明書のセキュリティ レベルが 3000 以上でない限り、クライアントが個別化またはプロビジョニングされていないか (この場合、このプロパティは 0 を返します)、ハードウェア DRM が使われていません (この場合、このプロパティは 3000 未満の値を返します)。

### <a name="detecting-support-for-aes128cbc-hardware-drm"></a>AES128CBC ハードウェア DRM のサポートの検出
Windows 10、バージョン 1709 以降では、デバイス上での AES128CBC ハードウェア暗号化のサポート状況を検出できます。これには、**[PlayReadyStatics.CheckSupportedHardware](https://msdn.microsoft.com/library/windows/apps/dn986441)** を呼び出して、列挙値 [**PlayReadyHardwareDRMFeatures.Aes128Cbc**](https://msdn.microsoft.com/library/windows/apps/dn986265) を指定します。 以前のバージョンの Windows 10 では、この値を指定すると、例外がスローされます。 このため、**CheckSupportedHardware** を呼び出す前に、**[ApiInformation.IsApiContractPresent](https://docs.microsoft.com/uwp/api/windows.foundation.metadata.apiinformation.isapicontractpresent)** を呼び出して、メジャー コントラクト バージョン 5 を指定し、この列挙値が存在していることを確認します。

```csharp
bool supportsAes128Cbc = ApiInformation.IsApiContractPresent("Windows.Foundation.UniversalApiContract", 5);

if (supportsAes128Cbc)
{
    supportsAes128Cbc = PlayReadyStatics.CheckSupportedHardware(PlayReadyHardwareDRMFeatures.Aes128Cbc);
}
```

## <a name="see-also"></a>関連項目
- [PlayReady DRM](playready-client-sdk.md)
