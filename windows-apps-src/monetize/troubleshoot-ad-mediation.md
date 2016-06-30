---
author: mcleanbyron
Description: "広告の仲介に関連した、開発に関するいくつかの一般的な問題に対する解決策を以下に示します。"
title: "広告の仲介のトラブルシューティング"
ms.assetid: 8728DE4F-E050-4217-93D3-588DD3280A3A
translationtype: Human Translation
ms.sourcegitcommit: 10dcf3c2b8ea530b94e9c17ada80aaa98e9418fe
ms.openlocfilehash: f32dc28c9b199c11a1932639f49ab4c29d3e1e8f

---

# 広告の仲介のトラブルシューティング


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

広告の仲介に関連した、開発に関するいくつかの一般的な問題に対する解決策を以下に示します。

**デザイン サーフェイスに AdMediatorControl を追加できない**  
C# または Visual Basic と XAML を使ったユニバーサル Windows プラットフォーム (UWP)、Windows 8.1、または Windows Phone 8.1 プロジェクトで、最初に **AdMediatorControl** コントロールをデザイナーにドラッグしたときに、Visual Studio によって、必要な広告メディエーター アセンブリ参照がプロジェクトに追加されますが、コントロールはまだデザイナーに追加されていません。 コントロールを追加するには、Visual Studio によって表示されるメッセージで [OK] をクリックし、デザイナーが更新されるまで数秒待ちます。その後、もう一度コントロールをデザイナーにドラッグします。

それでもコントロールをデザイナーに正常に追加できない場合は、プロジェクトのターゲットが **[Any CPU]** (任意の CPU) ではなく、アプリに該当するプロセッサ アーキテクチャ (たとえば、**[x86]**) であることを確認します。 プロジェクトのビルド プラットフォームのターゲットを **[Any CPU]** にしている場合、このコントロールをデザイナーに追加できません。

*
              *Microsoft から広告を提供しているときに、AdMediatorControl によって "&lt;*width*
            &gt; x &lt;*height*&gt; はサポートされていません" というエラーが表示される** Microsoft Advertising は、[Interactive Advertising Bureau (IAB) が推奨する特定の広告サイズ](add-and-use-the-ad-mediator-control.md#supported-ad-sizes-for-microsoft-advertising)のみをサポートします。状況によっては、デザイナーまたは XAML で、広告メディエーターのコントロールの幅と高さをサポートされている広告サイズのいずれかに設定した場合でも、拡大縮小や丸めの問題によって、広告の仲介フレームワークに広告が提供されない可能性があります。この問題を回避するには、コード内で Microsoft Advertising のオプションのパラメーター **Width** と **Height** に、サポートされている広告サイズのいずれかを割り当てます。

次のコード例では、Microsoft Advertising のオプション パラメーター **Width** と **Height** に 728 x 90 を割り当てる方法を示しています。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Width"] = 728;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.MicrosoftAdvertising]["Height"] = 90;
```

**広告の仲介に広告ネットワーク用の場所 (緯度と経度) が含まれない**  
アプリで位置情報機能を有効にした場合、広告メディエーター コントロールは自動的に、緯度と経度の座標を取得し、それらをサポートする広告ネットワークに提供します。

**Smaato 広告コントロールが正しく配置されない**  
オプション パラメーターを使って、SDK コントロールに値を設定してみてください。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Margin"] = new Thickness(0, -20, 0, 0);
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Width"] = 50d;
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.Smaato]["Height"] = 320d;
```

**AdDuplex 広告コントロールが正しいサイズで表示されない (250 × 250 で表示される)**  
広告の仲介はサイズの値を設定しないため、オプション パラメーターの **Size** を使ってサイズを変更する必要があります。 たとえば、次のように指定します。

```CSharp
myAdMediatorControl.AdSdkOptionalParameters[AdSdkNames.AdDuplex]["Size"] = "160x600";
```

**「Something is covering the ad control」(何かが広告コントロールを覆っています) というエラーが発生する**  
アプリ内の広告が何らかの方法で隠されている場合、AdDuplex は必ずエラーを表示します。 このエラーに対する[解決策をお読みください](http://blog.adduplex.com/2014/01/solving-something-is-covering-ad.mdl)。

**「2 つのファイルの間で競合が見つかりました」というエラーが発生する**  
アプリ内の別の場所で Microsoft Advertising アセンブリを参照しています。 広告の仲介はアプリ内で排他的に動作するようにデザインされており、Microsoft Advertising アセンブリに対する他の参照が使われている場合は機能しません。 Microsoft Advertising の参照を手動で削除し、Microsoft Store Engagement and Monetization SDK を再インストールして、エラーをクリアします。

**AdMediator.config ファイル RefreshRate 値を変更した後、予期しない動作が発生する**

Visual Studio の **[接続済みサービスの追加]** ダイアログ ボックスで、**Ad Mediator** コンポーネントを実行することによって広告ネットワークを構成すると、既定の構成情報はプロジェクト内の AdMediator.config ファイルに保存されます。 このファイルを直接変更することは想定されていません。 代わりに、Windows デベロッパー センター ダッシュボードにアプリ パッケージをアップロードした後、[アプリの広告の仲介の設定を構成する](submit-your-app-and-configure-ad-mediation.md)ときに、この情報 (新しい広告のリフレッシュ レートなど) を変更できます。

AdMediator.config ファイル内の **RefreshRate** 値を変更する場合は、この値にリフレッシュ レートを秒単位で表す 30 ～ 120 の整数を含める必要があることに注意してください。 この値を 30 より小さい整数や 120 より大きい整数に設定した場合、広告の仲介のフレームワークでは自動的に 60 秒のリフレッシュ レートが使用されます。

## 関連トピック

* [広告ネットワークの選択と管理](select-and-manage-your-ad-networks.md)
* [広告の仲介コントロールの追加と使用](add-and-use-the-ad-mediator-control.md)
* [広告の仲介の実装のテスト](test-your-ad-mediation-implementation.md)
* [アプリの提出と広告の仲介の構成](submit-your-app-and-configure-ad-mediation.md)
 

 



<!--HONumber=Jun16_HO4-->


