---
title: スプラッシュ画面の追加
description: Microsoft Visual Studio を使ってアプリのスプラッシュ画面の画像と背景色を設定します。
ms.assetid: 41F53046-8AB7-4782-9E90-964D744B7D66
ms.date: 05/08/2018
ms.topic: article
keywords: windows 10, uwp
ms.localizationpriority: medium
ms.openlocfilehash: 882ee548754b9fa498697a8d75a12a23f86fc9de
ms.sourcegitcommit: 49d58bc66c1c9f2a4f81473bcb25af79e2b1088d
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 12/11/2018
ms.locfileid: "8924508"
---
# <a name="add-a-splash-screen"></a>スプラッシュ画面の追加

Microsoft Visual Studio を使ってアプリのスプラッシュ画面の画像と背景色を設定します。

## <a name="set-the-splash-screen-image-and-background-color-in-visual-studio"></a>Visual Studio でスプラッシュ画面の画像と背景色を設定する

Visual Studio テンプレートを使ってアプリを作成すると、既定の画像がプロジェクトに追加され、スプラッシュ画面の画像として設定されます。 スプラッシュ画面の既定の背景色は既定で薄い灰色に設定されます。 アプリのスプラッシュ画面の既定の画像や色を変更する場合は、次の手順を実行します。

1. Visual Studio で既にあるユニバーサル Windows プラットフォーム (UWP) アプリ プロジェクトを開きます。
2. **ソリューション エクスプ ローラー**から "Package.appxmanifest" ファイルを開きます。 メニュー バーから **[プロジェクト]** &gt; **[ストア]** &gt; **[アプリケーション マニフェストの編集]** を選んで、このファイルを開くこともできます。
3. **[ビジュアル資産]** タブを開き、[Package.appxmanifest] ウィンドウの左側にある **[すべてのビジュアル資産]** ウィンドウから **[スプラッシュ画面]** を選びます。 初めてスプラッシュ画面を変更する場合は、**[スプラッシュ画面]** に "Assets\\SplashScreen.png" というパスが表示されます。

    次のスクリーン ショットは、Visual Studio での [Package.appxmanifest] ウィンドウを示しています。 プロジェクトの種類に応じて、表示されるビジュアル資産が若干異なります。

    ![Visual Studio 2017 で表示される [package.appxmanifest] ウィンドウのスクリーン ショット](images/appmanifest.png)

    テキスト エディターで "Package.appxmanifest" を開くと、[**VisualElements 要素**](https://msdn.microsoft.com/library/windows/apps/br211471) の子として [**SplashScreen 要素**](https://msdn.microsoft.com/library/windows/apps/br211467) が表示されます。 マニフェスト ファイル内の既定のスプラッシュ画面のマークアップはテキスト エディターで次のようになります。

    ```xml
    <uap:SplashScreen Image="Assets\SplashScreen.png" />
    ```

4. UWP アプリ用の新しいスプラッシュ画面の画像を選ぶには、**[スケーリングされた資産]** で **[1240 x 600 px]** ラベルの横にある省略記号のボタンをクリックします。 スプラッシュ画面の画像に使う 1240 × 600 ピクセルの画像 (.png、.jpg、または .jpeg) を選びます。

    **重要な**選択するスプラッシュ画面の画像は、1 x スケール ファクターを使った 620 x 300 ピクセルである必要があります。 また、スプラッシュ画面を設計するときは、画面より小さく、中央に表示されることに注意してください。 Windows Phone ストア アプリのスプラッシュ画面のように画面全体に表示されるわけではありません。

5. 新しい Windows Phone ストア アプリ用スプラッシュ画面の画像を選ぶには、**[スケーリングされた資産]** で **[1152 x 1920 px]** ラベルの横にある省略記号のボタンをクリックします。 スプラッシュ画面の画像に使う 1152 × 1920 ピクセルの画像 (.png、.jpg、または .jpeg) を選びます。

    **重要な**スプラッシュ画面の画像を選択する必要があります 1152 x 1920 ピクセル、2.4 倍スケール ファクターの適切なサイズです。 提供する資産がこれだけである場合は、1.4 倍と等倍の倍率にスケール ダウンされます。

6. **[スプラッシュ画面]** セクションの **[背景色]** で、スプラッシュ画面の画像と共に表示される背景色を設定します。 色の名前を指定することも、'\#' と色を表す 16 進数を指定することもできます。 利用可能な色の名前の一覧については、「[**SplashScreen 要素**](https://msdn.microsoft.com/library/windows/apps/br211467)」をご覧ください。 スプラッシュ画面の背景色の設定は省略できます。 UWP アプリの色を指定しない場合は、スプラッシュ画面の背景色が既定で、薄い灰色 (16 進数 \#464646) に設定されます。 これは、**[タイル]** の既定の背景色 (**[ビジュアル資産]** タブの **[タイル イメージとロゴ]** セクションの **[背景色]** を参照) と同じ色です。 Windows Phone の色を指定しないか、「透明」に設定した場合は、スプラッシュ画面の背景色が透明になります。

## <a name="summary-and-next-steps"></a>要約と次のステップ

アプリの読み込みに時間がかかる場合は、追加スプラッシュ画面の追加を検討してください。 手順については、「[カスタマイズしたスプラッシュ画面の作成](create-a-customized-splash-screen.md)」を参照してください。

## <a name="related-topics"></a>関連トピック

* [カスタマイズしたスプラッシュ スクリーンの作成](create-a-customized-splash-screen.md)
* [パッケージ マニフェスト スキーマ リファレンス: SplashScreen 要素](https://msdn.microsoft.com/library/windows/apps/br211467)
* [Windows.ApplicationModel.Activation.SplashScreen クラス](https://msdn.microsoft.com/library/windows/apps/br224763)