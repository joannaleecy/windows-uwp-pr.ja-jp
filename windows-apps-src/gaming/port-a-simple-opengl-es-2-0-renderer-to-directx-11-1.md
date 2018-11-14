---
author: mtoepke
title: 簡単な OpenGL ES 2.0 レンダラーの Direct3D 11 への移植
description: 最初の移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。
ms.assetid: e7f6fa41-ab05-8a1e-a154-704834e72e6d
ms.author: mtoepke
ms.date: 02/08/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, OpenGL, Direct3D 11, 移植
ms.localizationpriority: medium
ms.openlocfilehash: e7541a8f54f64197c17acea5f1737e36b0e6f670
ms.sourcegitcommit: 4d88adfaf544a3dab05f4660e2f59bbe60311c00
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/13/2018
ms.locfileid: "6461150"
---
# <a name="port-a-simple-opengl-es-20-renderer-to-direct3d-11"></a>簡単な OpenGL ES 2.0 レンダラーの Direct3D 11 への移植



この移植作業では、基本から始めます。Visual Studio 2015 の DirectX 11 アプリ (ユニバーサル Windows) テンプレートに対応するように、頂点シェーディングされた回転する立方体の簡単なレンダラーを OpenGL ES 2.0 から Direct3D に移植します。 この移植プロセスでは、次について説明します。

-   一連の簡単な頂点バッファーを Direct3D の入力バッファーに移植する方法
-   uniform と attribute を定数バッファーに移植する方法
-   Direct3D のシェーダー オブジェクトを構成する方法
-   Direct3D のシェーダー開発で基本的な HLSL セマンティクスを使う方法
-   非常に簡単な GLSL を HLSL に移植する方法

このトピックは、新しい DirectX 11 プロジェクトを作成したところから始まります。 新しい DirectX 11 プロジェクトを作成する方法については、「[テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)」をご覧ください。

これらのリンクのどちらかから作成されたプロジェクトには [Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476345) インフラストラクチャ用のコードがすべて用意されているため、OpenGL ES 2.0 から Direct3D 11 にレンダラーを移植するプロセスをすぐに始めることができます。

このトピックでは、2 つのコード パスについて説明します。どちらも同じ基本的なグラフィックス タスクを実行します。頂点シェーディングされた回転する立方体をウィンドウに表示するというものです。 どちらの場合も、コードは次のプロセスに対応しています。

1.  ハードコードされたデータから立方体のメッシュを作成する。 このメッシュは頂点の一覧として表され、各頂点では位置、法線ベクトル、色ベクトルを処理します。 シェーディング パイプラインで処理するためにこのメッシュを頂点バッファーに配置します。
2.  立方体のメッシュを処理するシェーダー オブジェクトを作成する。 シェーダーは 2 つあります。1 つはラスタライズのために頂点を処理する頂点シェーダーで、もう 1 つはラスタライズ後に立方体の個々のピクセルに色を設定するフラグメント (ピクセル) シェーダーです。 これらのピクセルは、表示のためにレンダー ターゲットに書き込まれます。
3.  頂点シェーダーとフラグメント シェーダーでそれぞれ処理する頂点とピクセルに使われるシェーダー言語を構成する。
4.  レンダリングされた立方体を画面に表示する。

![OpenGL の単純な立方体](images/simple-opengl-cube.png)

このチュートリアルを終了すると、OpenGL ES 2.0 と Direct3D 11 の次の基本的な違いを理解できます。

-   頂点バッファーと頂点データの表現。
-   シェーダーを作成して構成するプロセス。
-   シェーダー言語と、シェーダー オブジェクトに対する入力と出力。
-   画面の描画動作。

このチュートリアルでは、次のように定義される簡単で一般的な OpenGL レンダラーの構造体を参照します。

``` syntax
typedef struct 
{
    GLfloat pos[3];        
    GLfloat rgba[4];
} Vertex;

typedef struct
{
  // Integer handle to the shader program object.
  GLuint programObject;

  // The vertex and index buffers
  GLuint vertexBuffer;
  GLuint indexBuffer;

  // Handle to the location of model-view-projection matrix uniform
  GLint  mvpLoc; 
   
  // Vertex and index data
  Vertex  *vertices;
  GLuint   *vertexIndices;
  int       numIndices;

  // Rotation angle used for animation
  GLfloat   angle;

  GLfloat  mvpMatrix[4][4]; // the model-view-projection matrix itself
} Renderer;
```

この構造体には、インスタンスが 1 つあり、頂点シェーディングされた非常に簡単なメッシュをレンダリングするために必要なコンポーネントがすべて含まれています。

> **注:** このトピックの OpenGL ES 2.0 コードは、Khronos Group によって提供される Windows API の実装に基づいてし、Windows C プログラミング構文を使用します。

 

## <a name="what-you-need-to-know"></a>理解しておく必要があること


### <a name="technologies"></a>テクノロジ

-   [Microsoft Visual C++](http://msdn.microsoft.com/library/vstudio/60k1461a.aspx)
-   OpenGL ES 2.0

### <a name="prerequisites"></a>前提条件

-   省略可能です。 「[DXGI と Direct3D の EGL コードの比較](moving-from-egl-to-dxgi.md)」をご覧ください。 このトピックを読むと、DirectX によって提供されるグラフィックス インターフェイスについて理解を深めることができます。

## <a name="span-idkeylinksstepsheadingspansteps"></a><span id="keylinks_steps_heading"></span>ステップ


<table>
<colgroup>
<col width="50%" />
<col width="50%" />
</colgroup>
<thead>
<tr class="header">
<th align="left">トピック</th>
<th align="left">説明</th>
</tr>
</thead>
<tbody>
<tr class="odd">
<td align="left"><p><a href="port-the-shader-config.md">シェーダー オブジェクトの移植</a></p></td>
<td align="left"><p>OpenGL ES 2.0 から簡単なレンダラーを移植する場合、最初の手順では、Direct3D 11 の対応する頂点シェーダー オブジェクトとフラグメント シェーダー オブジェクトを設定し、コンパイル後にメイン プログラムがシェーダー オブジェクトと通信できるようにします。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="port-the-vertex-buffers-and-data-config.md">頂点バッファーと頂点データの移植</a></p></td>
<td align="left"><p>この手順では、シェーダーが指定された順番で頂点を走査できるようにするインデックス バッファーとメッシュを格納する頂点バッファーを定義します。</p></td>
</tr>
<tr class="odd">
<td align="left"><p><a href="port-the-glsl.md">GLSL の移植</a></p></td>
<td align="left"><p>バッファーとシェーダー オブジェクトを作成して構成するコードが完成したら、それらのシェーダー内のコードを OpenGL ES 2.0 の GL シェーダー言語 (GLSL) から Direct3D 11 の上位レベル シェーダー言語 (HLSL) に移植します。</p></td>
</tr>
<tr class="even">
<td align="left"><p><a href="draw-to-the-screen.md">画面への描画</a></p></td>
<td align="left"><p>最後に、回転する立方体を画面に描画するコードを移植します。</p></td>
</tr>
</tbody>
</table>

 

## <a name="span-idadditionalresourcesspanadditional-resources"></a><span id="additional_resources"></span>その他の情報


-   [UWP DirectX ゲーム プログラミング環境の準備](prepare-your-dev-environment-for-windows-store-directx-game-development.md)
-   [テンプレートからの DirectX ゲーム プロジェクトの作成](user-interface.md)
-   [Direct3D 11 への OpenGL ES 2.0 のマッピング](map-concepts-and-infrastructure.md)

 

 




