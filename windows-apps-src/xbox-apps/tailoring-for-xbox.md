---
author: payzer
title: "Xbox ベスト プラクティス"
description: "Xbox 用のアプリを最適化する方法を説明します。"
ms.author: wdg-dev-content
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.openlocfilehash: fb896ed67b79e97b504be0253081a4c29ee5fcc9
ms.sourcegitcommit: de6bc8acec2cd5ebc36bb21b2ce1a9980c3e78b2
ms.translationtype: HT
ms.contentlocale: ja-JP
ms.lasthandoff: 08/17/2017
---
# <a name="xbox-best-practices"></a>Xbox ベスト プラクティス
既定では、すべての UWP アプリは何もしなくても Xbox One で動きます。 ただし、アプリを引き立たせ、ユーザーを楽しませて、Xbox に最適なアプリ エクスペリエンスを備えるには、以下のようにする必要があります。
  > [!NOTE]
  > 始める前に、「[Xbox およびテレビ向け設計](../input-and-devices/designing-for-tv.md)」で示されている設計ガイドラインを確認します。   


## <a name="to-build-the-best-experiences-for-xbox-one"></a>Xbox One 向けの最適なエクスペリエンスを構築するには

### <a name="do-turn-off-mouse-mode"></a>*行うこと:* マウス モードをオフにします
Xbox ユーザーはコントローラーを好みます。 コントローラー入力用に最適化するには、[マウス モードを無効](how-to-disable-mouse-mode.md)にし、方向ナビゲーション ([X-Y フォーカス](../input-and-devices/designing-for-tv.md#xy-focus-navigation-and-interaction)とも呼ばれます) を有効にします。 フォーカス トラップとアクセスできない UI に注意してください。

### <a name="do-draw-a-focus-rectangle-that-is-appropriate-for-a-10-foot-experience"></a>*行うこと:* 10 フィート エクスペリエンス向けの適切なフォーカス用の四角形を描画します
ほとんどの Xbox ユーザーは室内でテレビに向かって座っているので、標準的なフォーカス用の四角形では 10 フィート離れた場所からでは見えにくいことに留意してください。 入力フォーカスのある UI 要素がユーザーに常にはっきり見えるようにするには、[フォーカス表示](../input-and-devices/designing-for-tv.md#focus-visual)のガイドラインに従ってください。 XAML では、アプリが Xbox で動いているときは何もしなくてもそのように動作しますが、HTML アプリの場合はカスタム CSS スタイルを使用する必要があります。

### <a name="do-integrate-with-the-systemmediatransportcontrols-class"></a>*行うこと:* SystemMediaTransportControls クラスと統合します 
Xbox のユーザーは、Xbox メディア リモコン Cortana (特に、"再生" と "一時停止" の音声コマンド) および Xbox SmartGlass を使用してメディア アプリを操作するのを好みます。 これらの機能を自作しないでアプリに組み込むには、[SystemMediaTransportControls](https://msdn.microsoft.com/en-us/library/windows/apps/windows.media.systemmediatransportcontrols.aspx) クラスを使用する必要があります。このクラスは、Xbox メディア コントロールに自動的に含まれます。 アプリでカスタム メディア コントロールを使用する場合は、**SystemMediaTransportControls** クラスと統合してユーザーにこれらの機能を提供します。 バックグラウンド音楽アプリを作成している場合は、**SystemMediaTransportControls** クラスと統合して、バックグラウンド音楽コントロールが Xbox のマルチタスク タブで正しく動作するようにします。

### <a name="do-use-adaptive-ui-to-account-for-snapped-apps"></a>*行うこと:* アダプティブ UI を使用してスナップ アプリに対応します
Xbox One だけにある機能の 1 つは、ユーザーが Cortana などのアプリを他のアプリの横にスナップできる機能です。したがって、*フィル モード*で動作しているアプリはこの操作に正しく対応する必要があります。 そのためには、[アダプティブ UI](../get-started/universal-application-platform-guide.md#design-adaptive-ui-with-adaptive-panels) を実装し、開発中に他のアプリを隣にスナップして動作をテストする必要があります。

### <a name="consider-draw-to-the-edge-of-the-screen"></a>*考慮すること:* 画面の端に描画するようにします
多くのテレビでは画面の端が切れるので、アプリの重要なコンテンツはすべて、[テレビのセーフ エリア](../input-and-devices/designing-for-tv.md#tv-safe-area)の内側に表示する必要があります。 UWP は*オーバースキャン*を使用してコンテンツをテレビのセーフ エリアの内側に維持しますが、この既定の動作ではアプリの周囲に目立つ境界線が描画されることがあります。 最善のエクスペリエンスを提供するには、既定の動作を無効にして、「[画面の端に UI を描画する方法](turn-off-overscan.md)」の指示に従ってください。
> [!IMPORTANT]
  > オーバースキャンを無効にした場合、対話要素とテキストをテレビのセーフ エリア内に収める処理はアプリで行う必要があります。 

### <a name="consider-use-tv-safe-colors"></a>*考慮すること:* テレビ セーフ カラーを使用します 
テレビでは、コンピューター モニターほど極端な色の輝度は処理されません。 不自然な縞模様や色あせた画像が表示されないように、アプリでは高輝度の色を使わないようにする必要があります。 また、テレビの間の違いに留意してください。テレビによって色の表現が大きく異なる場合があります。** 「Xbox およびテレビ向け設計」の「[カラー](../input-and-devices/designing-for-tv.md#colors)」を読み、アプリの表示がすべてのユーザーに対して適切になるようにする方法を理解してください。

### <a name="remember-you-can-disable-scaling"></a>*憶えておくこと:* スケーリングを無効にできます
UWP アプリは、コントロールやフォントなどの UI 要素がすべてのデバイスで読みやすいように自動的にスケーリングされます。 XAML を使用するアプリは 200% に、HTML を使用するアプリは 150% にスケーリングされます。 Xbox でのアプリの表示をさらに細かく制御する場合は、既定の倍率を無効にして、HDTV (1920 x 1080) の実際のピクセル サイズを使用します。 Xbox で適切に表示されるようにアプリを調整する方法については、「[スケーリングを無効にする方法](disable-scaling.md)」と「[有効ピクセルとスケーリング](../layout/design-and-ui-intro.md#effective-pixels-and-scaling)」をご覧ください。


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


## <a name="see-also"></a>関連項目
- [Xbox One の UWP](index.md)

