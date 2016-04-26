---
label: Grid
template: detail.hbs
extraBodyClass: layout-grid
brief: With its rigorous hierarchies and geometry, the grid orients us. It tells us what’s important and what can wait. As people become comfortable with reductive, flat design, the grid can be more abstract, with fewer cues and signposts. The explicit grid starts to fade, leaving behind the elegant relationships between its elements.
---

# 基本単位

Windows のグリッドは、4 × 4 ピクセルの単位から構成されます。 これらは**有効ピクセル**であり、物理ピクセルではありません。 レイアウト内の要素は、常に 4 ピクセルの倍数で拡大する必要があります。 これにより、なじみのあるバランスと統一感を保つことができます。

![4 ピクセルのグリッドの表示](assets/grid/grid.png)

# 有効ピクセル

有効ピクセルは、仮想の測定単位です。 画面のピクセル密度 (インチあたりのドット、または DPI とも呼ばれます) に依存することなく、レイアウトのサイズや間隔を表すために使用されます。 有効ピクセルを使用すると、UI 要素の実際の体感的なサイズに集中することができ、さまざまな実行デバイスのピクセル密度を気にする必要がなくなります。

実際にレイアウトは物理ピクセルを使って行わないため、ほとんどの場合、有効ピクセルを短縮形で単に px と表記しています。

<video class="video-responsive" controls>
    <source src="assets/grid/epx.mp4" type="video/mp4" />
    Oops! Your browser doesn't seem to support this video. Sorry about that.
</video>

<aside class="aside-dev">
    <div class="aside-dev-title">
        Developer Notes
    </div>
    <div class="aside-dev-content">
            Although XAML doesn't specify units for its widths, heights, margins, and padding, they are all implicitly measured in effective pixels.
    </div>
</aside>

# タッチ ターゲット

48 × 48 ピクセルは、タッチを行う必要のある要素の、最適なサイズです。 ただし、サイズの制限があり、操作頻度の低い場合などには、さらに縮小して 44 × 44 ピクセルとすることも可能です。 高さを低くする必要がある場合には、別の選択肢として 32 × 120 ピクセルを使うこともできます。これはデスクトップまたは 2-in-1 の PC のみで使用します。

![48 × 48 ピクセルのタッチ ターゲットの表示](assets/grid/touch-target.png)


<!--HONumber=Mar16_HO4-->


