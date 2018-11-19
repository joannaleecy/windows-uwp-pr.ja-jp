---
author: payzer
title: Xbox ベスト プラクティス
description: Xbox 用のアプリを最適化する方法を説明します。
ms.author: wdg-dev-content
ms.date: 10/12/2017
ms.topic: article
keywords: Windows 10, UWP
ms.localizationpriority: medium
ms.openlocfilehash: 604e6dc5381a36d4dbda70e3435e5cd6fa44cc04
ms.sourcegitcommit: ed0304b8a214c03b8aab74b8ef12c9f82b8e3c5f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/19/2018
ms.locfileid: "7281108"
---
# <a name="xbox-best-practices"></a>Xbox ベスト プラクティス

既定では、すべての UWP アプリは何もしなくても Xbox One で動きます。 ただし、アプリを引き立たせ、ユーザーを楽しませて、Xbox に最適なアプリ エクスペリエンスを備えるには、以下のようにする必要があります。
  > [!NOTE]
  > 始める前に、「[Xbox およびテレビ向け設計](../design/devices/designing-for-tv.md)」で示されている設計ガイドラインを確認します。   

## <a name="to-build-the-best-experiences-for-xbox-one"></a>Xbox One 向けの最適なエクスペリエンスを構築するには

### <a name="do-turn-off-mouse-mode"></a>*行うこと:* マウス モードをオフにします

Xbox ユーザーは、それぞれのコント ローラーを好みます。 コントローラー入力用に最適化するには、[マウス モードを無効](how-to-disable-mouse-mode.md)にし、方向ナビゲーション ([X-Y フォーカス](../design/devices/designing-for-tv.md#xy-focus-navigation-and-interaction)とも呼ばれます) を有効にします。 フォーカスのトラップとアクセスできない UI に注意します。

### <a name="do-draw-a-focus-rectangle-that-is-appropriate-for-a-10-foot-experience"></a>*行うこと:* 10 フィート エクスペリエンス向けの適切なフォーカス用の四角形を描画します

ほとんどの Xbox ユーザーは室内でテレビに向かって座っているので、標準的なフォーカス用の四角形では 10 フィート離れた場所からでは見えにくいことに留意してください。 入力フォーカスのある UI 要素がユーザーに常にはっきり見えるようにするには、[フォーカス表示](../design/devices/designing-for-tv.md#focus-visual)のガイドラインに従ってください。 XAML では、アプリが Xbox で動いているときは何もしなくてもそのように動作しますが、HTML アプリの場合はカスタム CSS スタイルを使用する必要があります。

### <a name="do-integrate-with-the-systemmediatransportcontrols-class"></a>*行うこと:* SystemMediaTransportControls クラスと統合します

Xbox のユーザーは、Xbox メディア リモコン Cortana (特に、"再生" と "一時停止" の音声コマンド) および Xbox SmartGlass を使用してメディア アプリを操作するのを好みます。 これらの機能を自作しないでアプリに組み込むには、[SystemMediaTransportControls](https://msdn.microsoft.com/library/windows/apps/windows.media.systemmediatransportcontrols.aspx) クラスを使用する必要があります。このクラスは、Xbox メディア コントロールに自動的に含まれます。 アプリでカスタム メディア コントロールを使用する場合は、**SystemMediaTransportControls** クラスと統合してユーザーにこれらの機能を提供します。 バックグラウンド音楽アプリを作成している場合は、**SystemMediaTransportControls** クラスと統合して、バックグラウンド音楽コントロールが Xbox のマルチタスク タブで正しく動作するようにします。

<!-- ### *Do:* Use adaptive UI to account for snapped apps
One of the unique features of Xbox One is that users can snap apps such as Cortana next to any other app, so your app should respond gracefully when it runs in *fill mode*. Implement [adaptive UI](../get-started/universal-application-platform-guide.md#design-adaptive-ui-with-adaptive-panels) and make sure to test your app during development by snapping an app next to it. -->

### <a name="consider-draw-to-the-edge-of-the-screen"></a>*考慮すること:* 画面の端に描画するようにします

多くのテレビでは画面の端が切れるので、アプリの重要なコンテンツはすべて、[テレビのセーフ エリア](../design/devices/designing-for-tv.md#tv-safe-area)の内側に表示する必要があります。 UWP は*オーバースキャン*を使用してコンテンツをテレビのセーフ エリアの内側に維持しますが、この既定の動作ではアプリの周囲に目立つ境界線が描画されることがあります。 最善のエクスペリエンスを提供するには、既定の動作を無効にして、「[画面の端に UI を描画する方法](turn-off-overscan.md)」の指示に従ってください。
> [!IMPORTANT]
  > オーバースキャンを無効にした場合、対話要素とテキストをテレビのセーフ エリア内に収める処理はアプリで行う必要があります。 

### <a name="consider-use-tv-safe-colors"></a>*考慮すること:* テレビ セーフ カラーを使用します

テレビでは、コンピューター モニターほど極端な色の輝度は処理されません。 不自然な縞模様や色あせた画像が表示されないように、アプリでは高輝度の色を使わないようにする必要があります。 また、テレビの間の違いに留意してください。テレビによって色の表現が大きく異なる場合があります。** 読み取りに[色](../design/devices/designing-for-tv.md#colors)の全員に適切に表示する方法について説明しました。

### <a name="remember-you-can-disable-scaling"></a>*憶えておくこと:* スケーリングを無効にできます

UWP アプリは、コントロールやフォントなどの UI 要素がすべてのデバイスで読みやすいように自動的にスケーリングされます。 XAML を使用するアプリは 200% に、HTML を使用するアプリは 150% にスケーリングされます。 Xbox でのアプリの表示をさらに細かく制御する場合は、既定の倍率を無効にして、HDTV (1920 x 1080) の実際のピクセル サイズを使用します。 Xbox で適切に表示されるようにアプリを調整する方法については、「[スケーリングを無効にする方法](disable-scaling.md)」および「[有効ピクセルとスケーリング](../design/basics/design-and-ui-intro.md#effective-pixels-and-scaling)」をご覧ください。

これらのプラクティスが適用された UWP アプリを見てみるには、次のビデオをチェックしてください。
</br>
</br>
<iframe src="https://channel9.msdn.com/Blogs/One-Dev-Minute/Tailoring-your-UWP-app-for-Xbox/player" width="960" height="540" allowFullScreen frameBorder="0"></iframe>

## <a name="channel-9"></a>Channel 9

[Channel 9](https://channel9.msdn.com/) の以下の講演は、Xbox でのすばらしいアプリの開発に関する優れたソースです。

- [Xbox 向けの優れたユニバーサル Windows プラットフォーム (UWP) アプリの開発](https://channel9.msdn.com/Events/Build/2016/B883)
- [アプリを Xbox One とテレビに対応させる](https://channel9.msdn.com/Events/Build/2016/T651-R1)
- [UWP の開発 1: アダプティブ UI の作成](https://channel9.msdn.com/Events/Build/2016/L724-R1)
- [ブラウザーに留まらない Web アプリ: クロスプラットフォームとクロス デバイスの遭遇](https://channel9.msdn.com/Events/Build/2016/B888)

## <a name="app-dev-on-xbox"></a>App Dev on Xbox

**App Dev on Xbox**イベントは、Xbox でアプリを構築する新しい開発者向けの適切な開始点です。

* [記録されたセッションを視聴します。](https://developer.microsoft.com/windows/projects/campaigns/app-dev-on-xbox-event#WatchNow)
* [ブログの投稿を読み取る](https://developer.microsoft.com/windows/projects/campaigns/app-dev-on-xbox-event#BlogSeries)

## <a name="see-also"></a>関連項目

- [Xbox One の UWP](index.md)
- [Xbox およびテレビ向け設計](../design/devices/designing-for-tv.md)
