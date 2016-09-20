---
author: mtoepke
title: "ゲーム プログラミング用の Visual Studio ツール"
description: "Visual Studio で利用できる DirectX 固有のツールの概要。"
ms.assetid: 43137bfc-7876-70e0-515c-4722f68bd064
ms.sourcegitcommit: 6530fa257ea3735453a97eb5d916524e750e62fc
ms.openlocfilehash: 2202474f24e93aab32ec9f4e85e765616cbae056

---

# ゲーム プログラミング用の Visual Studio ツール


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

**要約**

-   [テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)
-   DirectX ゲーム プログラミング用の Visual Studio ツールの使用


Visual Studio Ultimate を使って、DirectX アプリを開発する場合は、画像、モデル、シェーダー リソースを作成、編集、プレビュー、エクスポートするための追加のツールを利用できます。 また、ビルド時のリソースの変換や、DirectX グラフィックス コードのデバッグに使うことができるツールもあります。

このトピックでは、こうしたグラフィックス ツールの概要について説明します。

## イメージ エディター


イメージ エディターは、DirectX で使うリッチ テクスチャと画像形式の種類を操作するのに使います。 イメージ エディターでは、次の形式をサポートしています。

-   .png
-   .jpg、.jpeg、.jpe、.jfif
-   .dds
-   .gif
-   .bmp
-   .dib
-   .tif、.tiff
-   .tga

ビルド時にこれらを .dds ファイルに変換するには、[ビルド カスタマイズ ファイル](#custom)を作成します。

詳しくは、「[テクスチャおよびイメージの使用](https://msdn.microsoft.com/library/windows/apps/hh873119.aspx)」をご覧ください。

> 
            **注**  イメージ エディターは、フル機能を備えた画像編集アプリを置き換えるものではありませんが、簡単な表示や編集シナリオの多くに適しています。

 

## モデル エディター


モデル エディターを使うと、基本的な 3D モデルをゼロから作成するや、フル機能を備えた 3D モデリング ツールで作成したもっと複雑な 3D モデルの表示や変更を行うことができます。 モデル エディターでは、DirectX アプリの開発で使われるいくつかの 3D モデル形式をサポートしています。 ビルド時に次のファイルを .cmo ファイルに変換する[ビルド カスタマイズ ファイル](#custom)を作成できます。

-   .fbx
-   .dae
-   .obj

エディターで照明を適用したモデルのスクリーンショットを次に示します。

![ティーポット](images/modeleditor.png)

詳しくは、「[3-D モデルの操作](https://msdn.microsoft.com/library/windows/apps/hh873114.aspx)」をご覧ください。

> 
            **注**  モデル エディターは、フル機能を備えたモデル編集アプリを置き換えるものではありませんが、簡単な表示や編集シナリオの多くに適しています。

 

## シェーダー デザイナー


HLSL でのプログラミングがわからない場合でも、シェーダー デザイナーを使うと、ゲームやアプリのカスタムの視覚効果を作成できます。

シェーダーはグラフとして視覚的に作成します。 各ノードには、その操作までの出力のプレビューが表示されます。 球体のプレビューでランバート照明を適用した例を次に示します。

![視覚シェーダー グラフ](images/shaderdesigner.png)

シェーダー エディターは、シェーダーを設計、編集、.dgsl 形式で保存するのに使います。 また、次の形式をエクスポートします。

-   .hlsl (ソース コード)
-   .cso (バイトコード)
-   .h (HLSL バイトコード配列)

ビルド時にこれらの形式を .cso ファイルに変換するには、[ビルド カスタマイズ ファイル](#custom)を作成します。

シェーダー エディターでエクスポートした HLSL コードの一部を次に示します。 これは、ランバート照明ノードのコードだけです。

```hlsl
//
// Lambert lighting function
//
float3 LambertLighting(
    float3 lightNormal,
    float3 surfaceNormal,
    float3 materialAmbient,
    float3 lightAmbient,
    float3 lightColor,
    float3 pixelColor
    )
{
    // Compute the amount of contribution per light.
    float diffuseAmount = saturate(dot(lightNormal, surfaceNormal));
    float3 diffuse = diffuseAmount * lightColor * pixelColor;

    // Combine ambient with diffuse.
    return saturate((materialAmbient * lightAmbient) + diffuse);
}
```

詳しくは、「[シェーダーの操作](https://msdn.microsoft.com/library/windows/apps/hh873117.aspx)」をご覧ください。

## 3D アセットのビルドのカスタマイズ


プロジェクトにビルドのカスタマイズを追加して、リソースを Visual Studio で利用できる形式に変換できます。 その後で、アプリにアセットを読み込み、他の DirectX アプリと同じように DirectX リソースを作成し、設定して、アセットを使うことができます。

ビルド カスタマイズを追加するには、**ソリューション エクスプローラー**でプロジェクトを右クリックし、**[ビルドのカスタマイズ]** をクリックします。 プロジェクトには次の種類のビルドのカスタマイズを追加できます。

-   入力として画像ファイルを受け取り、DirectDraw Surface (.dds) ファイルを出力するイメージ コンテンツ パイプライン。
-   メッシュ ファイル (.fbx など) を受け取り、.cmo メッシュ ファイルを出力するメッシュ コンテンツ パイプライン。
-   Visual Studio シェーダー エディターで作成した視覚シェーダー グラフ (.dgsl) を受け取り、コンパイル済みシェーダー出力 (.cso) ファイルを出力するシェーダー コンテンツ パイプライン。

詳しくは、「[ゲームまたはアプリケーションでの 3-D アセットの使用](https://msdn.microsoft.com/library/windows/apps/hh972446.aspx)」をご覧ください。

## DirectX グラフィックスのデバッグ


Visual Studio には、グラフィックス固有のデバッグ ツールが用意されています。 これらのツールを使って、次のような項目をデバッグします。

-   グラフィックス パイプライン。
-   イベント呼び出し履歴。
-   オブジェクト テーブル。
-   デバイスの状態。
-   シェーダーのバグ。
-   初期化されていないか、無効な定数バッファーとパラメーター。
-   DirectX バージョンの互換性。
-   制限されている Direct2D のサポート。
-   オペレーティング システムと SDK の要件。

詳しくは、「[DirectX グラフィックスのデバッグ](https://msdn.microsoft.com/library/windows/apps/hh315751.aspx)」をご覧ください。

> 
            **注:** この記事は、ユニバーサル Windows プラットフォーム (UWP) アプリを作成する Windows 10 開発者を対象としています。 Windows 8.x 用または Windows Phone 8.x 用の開発を行っている場合は、[アーカイブされているドキュメント](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください。

 

 

 







<!--HONumber=Jun16_HO4-->


