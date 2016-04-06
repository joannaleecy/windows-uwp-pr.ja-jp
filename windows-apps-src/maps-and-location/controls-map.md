---
Description: マップ コントロールでは、地図および上空からの写真、方向、検索結果、トラフィックを表示できます。
title: マップのガイドライン
ms.assetid: 7B5B6BC9-D1EC-4978-8876-20B78EF44797
---

# マップのガイドライン


\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132) をご覧ください\]


マップ コントロールでは、地図、航空写真 3D ビュー、方向、検索結果、トラフィックを表示できます。 マップ上には、現在地、ルート、関心のあるポイントを表示できます。 また、航空写真 3D ビュー、Streetside ビュー、交通情報、乗り換え情報、周辺情報を表示することもできます。

![マップの例 (基本ビュー)](./images/win10fa/controls-maps-basic.jpg)

## 適切なコントロールの選択


アプリ固有の地理情報または一般的な地理情報を表示できるアプリ内でマップが必要な場合に、マップ コントロールを使います。 アプリにマップ コントロールを含めておくことで、ユーザーはアプリの外部に移動することなく情報を得ることができます。

**注:** その情報を得るためにユーザーがアプリの外部に移動してもかまわない場合は、Windows マップ アプリを利用することも検討してください。 アプリから Windows マップ アプリを起動し、特定の地図、ルート案内、検索結果を表示することができます。 詳しくは、「[Windows マップ アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228341)」をご覧ください。

## 例


次の例では、Streetside ビューを使用したマップを示しています。

![マップ コントロールの Streetside ビューの例](./images/win10fa/controls-maps-streetside.jpg)

 

次の例では、3D 航空写真を使用したマップを示しています。

![マップ コントロールの 3D ビューの例](./images/win10fa/controls-maps-3dview.jpg)

 

次の例では、3D 航空写真ビューと Streetside ビューの両方が含まれるアプリを示しています。

![3D マップ ビューと Streetside ビューを組み合わせた例](./images/win10fa/controls-maps-3dstreetview.png)


## 推奨事項


-   ユーザーが地理情報を表示するためにパンとズームを過度に使用しなくて済むように、十分な画面領域 (または画面全体) を使用してマップを表示します。

-   静的な情報ビューの提示をするためにのみマップを使う場合、小さなマップを使う方が適している場合があります。 小さく静的なマップを使う場合は、使いやすさを考えてサイズを決めます。画面上の領域を十分節約できる程度に小さく、判読しにくくならない程度に大きくします。

-   マップ シーンに関心のあるポイントを埋め込むには、[**MapElements**](https://msdn.microsoft.com/library/windows/apps/dn637034) を使います。その他の情報も、マップ シーンのオーバーレイとして表示される一時的な UI に表示できます。

## 関連トピック


* [2D、3D、Streetside ビューでの地図の表示](https://msdn.microsoft.com/library/windows/apps/mt219695)
* [関心のあるポイント (POI) の地図への表示](https://msdn.microsoft.com/library/windows/apps/mt219696)
* [Bing Maps Developer Center](https://www.bingmapsportal.com/)
* [UWP の地図サンプル](http://go.microsoft.com/fwlink/p/?LinkId=619977)
* [//Build 2015 のビデオ: Windows アプリでの電話、タブレット、PC で使用できるマップと位置情報の活用](https://channel9.msdn.com/Events/Build/2015/2-757)
* [Windows マップ アプリの起動](https://msdn.microsoft.com/library/windows/apps/mt228341)
 

 






<!--HONumber=Mar16_HO1-->


