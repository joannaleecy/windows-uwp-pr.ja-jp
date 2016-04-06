---
Description: アプリに画像を統合する方法について説明します。Image と ImageBrush という主要な 2 つの XAML クラスの API の使い方について取り上げています。
title: 画像とイメージ ブラシ
ms.assetid: CEA8780C-71A3-4168-A6E8-6361CDFB2FAF
label: 画像とイメージ ブラシ
template: detail.hbs
---
# 画像とイメージ ブラシ

画像を表示するには、**Image** オブジェクトまたは **ImageBrush** オブジェクトを使うことができます。 Image オブジェクトは、イメージのレンダリングに使います。ImageBrush オブジェクトは、特定のイメージを使って別のオブジェクトをペイントするために使います。 

<span class="sidebar_heading" style="font-weight: bold;">重要な API</span>

-   [**Image クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)
-   [**Source プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.source.aspx)
-   [**ImageBrush クラス**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imagebrush.aspx)
-   [**ImageSource プロパティ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imagebrush.imagesource.aspx)

## これらの要素は適切か。
**画像** 要素を使用して、アプリにスタンドアロンの画像を表示します。

**ImageBrush** を使用して、画像を別のオブジェクトに適用します。 ImageBrush の使用法には、テキストの装飾性を高める効果や、コントロールまたはレイアウト コンテナーのタイルの背景などがあります。 画像を拡大、配置、およびタイル貼りする方法を制御できるので、パターンやその他の効果を作成することができます。 

## 例



## 画像を作成する

### 画像
[
            **Image**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx) オブジェクトを使って画像を作成する方法を次の例に示します。


```XAML
<Image Width="200" Source="licorice.jpg" />
```

次に示すのは、レンダリングされた Image オブジェクトです。

![画像要素の例](images/Image_Licorice.jpg)

この例の [**Source**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.source.aspx) プロパティは、表示する画像がある場所を指定します。 ソースを設定するには、絶対 URL (http://contoso.com/myPicture.jpg など) を指定するか、アプリのパッケージ化構造を基準とする相対 URL を指定します。 この例では、プロジェクトのルート フォルダーに "licorice.jpg" 画像ファイルを入れ、この画像ファイルをコンテンツとして含めるプロジェクト設定を宣言しています。

### ImageBrush

[
            **ImageBrush**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imagebrush.aspx) オブジェクトを使うと、[**Brush**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.brush.aspx) オブジェクトを受け付ける領域を、画像を使ってペイントできます。 たとえば、[**Ellipse**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.ellipse.aspx) の [**Fill**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.shapes.shape.fill.aspx) プロパティまたは [**Canvas**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.canvas.aspx) の [**Background**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.control.background.aspx) プロパティの値に ImageBrush を使うことができます。

次の例は、ImageBrush を使って Ellipse をペイントする方法を示しています。

```XAML
<Ellipse Height="200" Width="300">
   <Ellipse.Fill>
     <ImageBrush ImageSource="licorice.jpg" />
   </Ellipse.Fill>
</Ellipse>
```

次に示すのは、ImageBrush でペイントされた Ellipse です。

![ImageBrush でペイントされた Ellipse (楕円)。](images/Image_ImageBrush_Ellipse.jpg)

### 画像を拡大する

**Image** の [**Width**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.width.aspx) 値または [**Height**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.frameworkelement.height.aspx) 値を設定しないと、**Source** で指定した画像の寸法で表示されます。 **Width** と **Height** を設定すると、画像を表示する領域を囲む四角形が作成されます。 この囲まれた領域に画像を描く方法は、[**Stretch**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.stretch.aspx) プロパティを使って指定できます。 Stretch プロパティには、[**Stretch**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.stretch.aspx) 列挙体で定義されている次の値を指定します。

-   **注**: 画像は拡大されず、出力領域全体に描かれません。 このストレッチの設定には注意してください。囲まれた領域よりもソース画像が大きいと、画像はクリップされます。ユーザーは意図的な [**クリップ**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.clip.aspx) で行うような制御をビューポートに対して行うことができないため、通常このことは望ましくありません。
-   **Uniform**: 画像は、出力領域の大きさに合わせて拡大されます。 ただし、コンテンツの縦横比は保たれます。 これは既定値です。
-   **UniformToFill**: 画像は拡大され、出力領域を完全に塗りつぶすように描かれますが、元の縦横比は保たれます。
-   **Fill**: 画像は、出力領域の大きさに合わせて拡大されます。 コンテンツの高さと幅は個々に拡大されるので、元の画像の縦横比は保たれません。 つまり、出力領域を完全に塗りつぶすために、画像がゆがむことがあります。

![ストレッチ設定の例。](images/Image_Stretch.jpg)

### 画像をトリミングする

[
            **Clip**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.clip.aspx) プロパティを使うと、画像出力から一定の領域をクリップできます。 Clip プロパティを [**Geometry**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.geometry.aspx) に設定します。 現在、四角形以外のクリップはサポートされていません。

画像のクリップ領域として [**RectangleGeometry**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.rectanglegeometry.aspx) を使う方法を次の例に示します。 この例では、高さ 200 の **Image** オブジェクトを定義します。 **RectangleGeometry** は、表示される画像の領域に長方形を定義します。 [
            **Rect**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.rectanglegeometry.rect.aspx) プロパティは "25,25,100,150" に設定されています。これは、四角形が "25,25" の位置から始まり、幅 100、高さ 150 になることを定義しています。 この長方形の領域の内部にだけ、画像が表示されます。

```xaml
<Image Source="licorice.jpg" Height="200">
    <Image.Clip>
        <RectangleGeometry Rect="25,25,100,150" />
    </Image.Clip>
</Image>
```

黒い背景の上にクリップされた画像を次に示します。

![RectangleGeometry によってトリミングされた Image オブジェクト。](images/Image_Cropped.jpg)

### 不透明度を適用する

画像が半透明でレンダリングされるように、画像に [**Opacity**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.uielement.opacity.aspx) を適用することができます。 不透明度の値は、0.0 (完全に透明) ～ 1.0 (完全に不透明) です。 不透明度 0.5 を Image に適用する方法を次の例に示します。

```xaml
<Image Height="200" Source="licorice.jpg" Opacity="0.5" />
```

次に示すのは、不透明度 0.5 と黒い背景でレンダリングされ、部分的に不透明になった画像です。

![不透明度 0.5 の Image オブジェクト。](images/Image_Opacity.jpg)

### 画像ファイルの形式

**Image** と **ImageBrush** は、次の画像ファイル形式を表示できます。

-   Joint Photographic Experts Group (JPEG)
-   ポータブル ネットワーク グラフィックス (PNG)
-   ビットマップ (BMP)
-   グラフィックス交換形式 (GIF)
-   Tagged Image File Format (TIFF)
-   JPEG XR
-   アイコン (ICO)

[
            **Image**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.aspx)、[**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.bitmapimage.aspx)、[**BitmapSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.bitmapsource.aspx) 用の API には、メディア形式のエンコードとデコードを行う専用のメソッドは用意されていません。 エンコード操作とデコード操作はすべてビルトインであり、せいぜいエンコードまたはデコードの局面が読み込みイベント用のイベント データの一部として現れる程度です。 アプリが画像の変換または操作を行うため、画像のエンコードまたはデコードに関連する特別の作業が必要となったときは、[**Windows.Graphics.Imaging**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.graphics.imaging.aspx) 名前空間に用意されている API を使ってください。 これらの API は、Windows の Windows Imaging Component (WIC) でもサポートされます。

アプリ リソースについて、およびアプリにイメージ ソースをパッケージ化する方法について詳しくは、「[アプリ リソースの定義](https://msdn.microsoft.com/library/windows/apps/xaml/hh965321)」をご覧ください。

### WriteableBitmap

[
            **WriteableBitmap**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.writeablebitmap.aspx) は、WIC からの基本的なファイルに基づくデコードを使わない、修正可能な [**BitmapSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.bitmapsource.aspx) を提供します。 画像を動的に変更し、更新後の画像を再レンダリングできます。 **WriteableBitmap** のバッファーの内容を定義するには、[**PixelBuffer**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.writeablebitmap.pixelbuffer.aspx) プロパティを使ってバッファーにアクセスし、ストリームまたは言語固有のバッファーの種類を使って入力します。 コード例については、「[**WriteableBitmap**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.writeablebitmap.aspx)」をご覧ください。

### RenderTargetBitmap

[
            **RenderTargetBitmap**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.rendertargetbitmap.aspx) クラスは、実行中のアプリから XAML UI ツリーをキャプチャして、ビットマップ画像ソースを表現することができます。 キャプチャした画像ソースは、アプリ内の他の部分に適用したり、リソース (つまり、ユーザーによって作成されたアプリ データ) として保存するなど、さまざまなシナリオに利用することができます。 特にお勧めする用途は、実行時における XAML ページのサムネイルをナビゲーション手段として利用することです。たとえば、[**Hub**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.hub.aspx) コントロールから画像形式のリンクを提供することができます。 キャプチャされた画像に表示されるコンテンツに関して、**RenderTargetBitmap** にはいくつか制限があります。 詳しくは、[**RenderTargetBitmap**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.rendertargetbitmap.aspx) の API リファレンス トピックをご覧ください。

### 画像ソースとスケーリング

画像ソースは、Windows がスケールするときにアプリで適切に表示されるように、複数の推奨サイズで作る必要があります。 **Image** の **Source** を指定する際には、現在のスケーリングに対応したリソースを自動的に示す名前付け規則を利用できます。 この名前付け規則の詳細や関連情報については、「[クイック スタート: ファイルまたは画像リソースの使用](https://msdn.microsoft.com/library/windows/apps/xaml/hh965325)」をご覧ください。

スケーリングの設計方法について詳しくは、「[レイアウトとスケーリングの UX ガイドライン](https://msdn.microsoft.com/library/windows/apps/dn611863)」をご覧ください。

### コードを使った Image と ImageBrush

コードを使うよりも、XAML を使って Image と ImageBrush 要素を指定する方が一般的です。 これは、これらの要素が XAML UI 定義の一部としてのデザイン ツールの出力結果である場合が多いためです。

コードを使って Image または ImageBrush を定義する場合は、既定のコンストラクターを使い、次に、関連するソースのプロパティ ([**Image.Source**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.controls.image.source.aspx) と [**ImageBrush.ImageSource**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imagebrush.imagesource.aspx)) を設定します。 ソースのプロパティは、コードを使って設定する場合、[**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.bitmapimage.aspx) (URI ではない) を必要と使用します。 ソースがストリームである場合は、[**SetSourceAsync**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.ui.xaml.media.imaging.bitmapsource.setsourceasync.aspx) メソッドを使って値を初期化します。 ソースが、**ms-appx**  スキームまたは **ms-resource** スキームを使うアプリ内のコンテンツを含む URI である場合は、URI を受け取る [**BitmapImage**](https://msdn.microsoft.com/library/windows/apps/xaml/br243238.aspx) コンストラクターを使います。 イメージ ソースが使えるようになるまで代替コンテンツを表示することが必要であるなど、イメージ ソースの取得やデコードについてタイミングの問題がある場合は、[**ImageOpened**](https://msdn.microsoft.com/library/windows/apps/windows.ui.xaml.media.imaging.bitmapimage.imageopened.aspx) イベントを処理することも検討してください。 コードの例については、「[XAML 画像のサンプルに関するページ](http://go.microsoft.com/fwlink/p/?linkid=238575)」をご覧ください。

> **注**&nbsp;&nbsp; コードを使って画像を確立すると、自動処理を使って、現在のスケール修飾子とカルチャ修飾子で非修飾リソースにアクセスしたり、カルチャとスケールの修飾子で [**ResourceManager**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.resources.core.resourcemanager.aspx) と [**ResourceMap**](https://msdn.microsoft.com/library/windows/apps/xaml/windows.applicationmodel.resources.core.resourcemap.aspx) を使って、リソースを直接取得したりできます。 詳しくは、「[リソース管理システム](https://msdn.microsoft.com/library/windows/apps/xaml/jj552947.aspx)」をご覧ください。

## 推奨事項


\[この記事には、ユニバーサル Windows プラットフォーム (UWP) アプリと Windows 10 に固有の情報が含まれています。 Windows 8.1 のガイダンスについては、[Windows 8.1 ガイドラインの PDF](https://go.microsoft.com/fwlink/p/?linkid=258743) ファイルをダウンロードしてください。\]

## 関連記事

**デザイナー向け**

**開発者向け (XAML)**


<!--HONumber=Mar16_HO1-->


