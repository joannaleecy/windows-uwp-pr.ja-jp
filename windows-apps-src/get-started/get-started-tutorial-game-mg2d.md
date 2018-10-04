---
title: MonoGame 2D で UWP ゲームを作成する
description: C# と MonoGame で記述された Microsoft ストアのゲームのシンプルな UWP
author: muhsinking
ms.author: mukin
ms.date: 03/06/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: Windows 10, UWP
ms.assetid: 5d5f7af2-41a9-4749-ad16-4503c64bb80c
ms.localizationpriority: medium
ms.openlocfilehash: d38465ce02e0aedf854094ede75fc33701b226a6
ms.sourcegitcommit: 5c9a47b135c5f587214675e39c1ac058c0380f4c
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/04/2018
ms.locfileid: "4360383"
---
# <a name="create-a-uwp-game-in-monogame-2d"></a>MonoGame 2D で UWP ゲームを作成する

## <a name="a-simple-2d-uwp-game-for-the-microsoft-store-written-in-c-and-monogame"></a>C# と MonoGame で記述された Microsoft Store 向けのシンプルな 2D UWP ゲーム


![Walking Dino スプライト シート](images/JS2D_0.png)

## <a name="introduction"></a>はじめに

MonoGame は、軽量のゲーム開発フレームワークです。 このチュートリアルでは、コンテンツの読み込み、ストライプの描画、これらのアニメーション、ユーザー入力の処理など、MonoGame でのゲーム開発の基本事項について説明します。 衝突の検出や高 DPI 画面用のスケールアップなど、いくつかの高度な概念についても説明します。 このチュートリアルの所要時間は 30 ～ 60 分です。

## <a name="prerequisites"></a>前提条件
+   Windows 10 と Microsoft Visual Studio 2017。  [Visual Studio を備えた環境をセットアップする方法については、ここをクリックしてください](https://docs.microsoft.com/en-us/windows/uwp/get-started/get-set-up)。
+ .NET デスクトップ開発フレームワークです。 このインストールされていない場合は、Visual Studio インストーラーを再実行して、Visual Studio 2017 のインストールを変更することによって取得できます。
+   C# またはこれに類似するオブジェクト指向プログラミング言語に関する基本的な知識。 [C# によるチュートリアルについては、こちらをご覧ください](https://docs.microsoft.com/en-us/windows/uwp/get-started/create-a-hello-world-app-xaml-universal)。
+   オプションとして、クラス、メソッド、変数など、基本的なコンピューター サイエンスの概念に関する知識。

## <a name="why-monogame"></a>MonoGame を使用する理由
ゲームの開発環境には、今や十分すぎるほどの選択肢が存在します。 Unity などフル機能を備えたエンジンから DirectX など包括的で複雑なマルチメディア API まで、どこから始めるべきか迷います。 MonoGame は、複雑さのレベルがゲーム エンジンと DirectX などの基本 API の中間に分類されるツールのセットです。 MonoGame では、使いやすいコンテンツ パイプラインと、多様なプラットフォームで動作する軽量のゲームを作成するために必要なすべての機能が提供されています。 、すべての MonoGame のアプリは純粋な c# で記述され、Microsoft ストアやその他の同様の配布プラットフォームを通じて迅速に配布することができます。

## <a name="get-the-code"></a>コードを入手する
段階を追ってチュートリアルを進めるのではなく、MonoGame の動作を確認するには、[こちらをクリックして完成したアプリを入手してください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d)。

Visual Studio 2017 で、プロジェクトを開くし、サンプルを実行する、 **F5**キーを押します。 初めての実行時には、インストールに含まれていない NuGet パッケージを Visual Studio が取得する必要があるため、少し時間がかかることがあります。

これを行った場合は、MonoGame のセットアップに関する次のセクションをスキップして、順を追ったコードのウォークスルーに進むことができます。

**注:** このサンプルで作成するゲームは、完全なゲームではなく、おもしろい内容でもありません。 そのだけを目的では、MonoGame での 2D 開発のすべての主要な概念を示します。 このコードを基にして、より優れたゲームを作成することも、基礎を習得して 1 から始めることもできます。

## <a name="set-up-monogame-project"></a>MonoGame プロジェクトのセットアップ
1. [MonoGame.net](http://www.monogame.net/) から、**MonoGame 3.6** for Visual Studio をインストールします。

2. Visual Studio 2017 を起動します。

3. **[ファイル] -> [新規] -> [プロジェクト]** を開きます。

4. Visual C# プロジェクト テンプレートで、**[MonoGame]** と **[MonoGame Windows 10 Universal Project]** (MonoGame Windows 10 ユニバーサル プロジェクト) を選択します。

5. プロジェクトに「MonoGame2D」という名前を指定し、[OK] を選択します。 プロジェクトの作成時には多数のエラーがあるように見えますが、初めてプロジェクトを実行すると、不足していた NuGet パッケージがすべてインストールされ、エラーがなくなります。

6. ターゲット プラットフォームとして **[x86]** および **[ローカル コンピューター ]** を設定し、**F5** を押して、空のプロジェクトをビルド/実行します。 上の手順を実行した場合は、プロジェクトのビルドが終了した後、空の青いウィンドウが表示されます。

## <a name="method-overview"></a>メソッドの概要
プロジェクトを作成したので、**ソリューション エクスプローラー**から **Game1.cs** ファイルを開きます。 ゲーム ロジックの大部分は、ここに記述します。 新しい MonoGame プロジェクトを作成すると、多数の重要なメソッドがここに自動的に生成されます。 その内容を簡単に確認してみましょう。

**public Game1()** コンストラクター。 このチュートリアルでは、このメソッドをそのまま使用します。

**protected override void Initialize()** 使用するクラス変数は、ここですべて初期化します。 このメソッドは、ゲームの開始時に 1 回だけ呼び出されます。

**protected override void LoadContent()** このメソッドでは、ゲームの開始前にコンテンツ ( テクスチャ、オーディオ、フォントなど) をメモリに読み込みます。 Initialize と同様、アプリの起動時に 1 回だけ呼び出されます。

**protected override void UnloadContent()** このメソッドは、非コンテンツ マネージャーのコンテンツをアンロードするために使用されます。 ここでは使用しません。

**protected override void Update(GameTime gameTIme)** このメソッドは、ゲーム ループのすべてのサイクルで 1 回呼び出されます。 ここでは、ゲームで使用するあらゆるオブジェクトや変数の状態を更新します。 これには、オブジェクトの位置、速度、色などが含まれます。 ユーザー入力が処理される場所でもあります。 つまりこのメソッドでは、画面へのオブジェクトの描画を除いて、ゲーム ロジックのすべての部分が処理されます。
**protected override void Draw(GameTime gameTime)** ここでは、Update メソッドで指定された位置を使用して、オブジェクトが画面に描画されます。

## <a name="draw-a-sprite"></a>スプライトの描画
作成したばかりの MonoGame プロジェクトを実行し、美しい青空を確認しました。次は、地面を追加しましょう。
MonoGame では、2D アートが "スプライト" という形でアプリに追加されます。 スプライトは、単一のエンティティとして処理されるコンピューター グラフィックです。 スプライトの移動、拡大縮小、成形、アニメーション化、組み合わせなどを行うことで、思い描いたものを 2D 空間に作成することができます。

### <a name="1-download-a-texture"></a>1. テクスチャをダウンロードする
説明目的ですので、最初のスプライトは非常につまらないものです。 [こちらをクリックして、特徴のない緑色の四角形をダウンロードしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/grass.png)。

### <a name="2-add-the-texture-to-the-content-folder"></a>2. コンテンツ フォルダーにテクスチャを追加する
- **ソリューション エクスプローラー**を開きます。
- **[コンテンツ]** フォルダー内の **Content.mgcb** を右クリックし、**[プログラムから開く]** を選択します。 ポップアップ メニューから **[Monogame Pipeline]** (MonoGame パイプライン) を選択し、**[OK]** を選択します。
- 新しいウィンドウで **[コンテンツ]** 項目を右クリックし、**[追加] -> [既存の項目]** を選択します。
- ファイル ブラウザーで、緑色の四角形を見つけて選択します。
- 項目に「grass.png」という名前を指定し、**[追加]** を選択します。

### <a name="3-add-class-variables"></a>3. クラス変数を追加する
この画像をスプライトのテクスチャとして読み込むには、**Game1.cs** を開き、以下のクラス変数を追加します。

```CSharp
const float SKYRATIO = 2f/3f;
float screenWidth;
float screenHeight;
Texture2D grass;
```

SKYRATIO 変数は、シーン内の草地に対する空の割合 (この場合は 3 分の 2) を示します。 **screenWidth** と **screenHeight** では、アプリ ウィンドウのサイズを追跡し、**grass** には、緑色の四角形を格納します。

### <a name="4-initialize-class-variables-and-set-window-size"></a>4. クラス変数を初期化してウィンドウ サイズを設定する
**screenWidth** 変数と **screenHeight** 変数は初期化する必要があるため、このコードを **Initialize** メソッドに追加します。

```CSharp
ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;

screenHeight = (float)ApplicationView.GetForCurrentView().VisibleBounds.Height;
screenWidth = (float)ApplicationView.GetForCurrentView().VisibleBounds.Width;

this.IsMouseVisible = false;
```

画面の高さと幅を取得するほか、アプリのウィンドウ表示モードを **Fullscreen** に設定し、マウスを非表示にします。

### <a name="5-load-the-texture"></a>5. テクスチャを読み込む
テクスチャを grass 変数に読み込むには、以下を **LoadContent** メソッドに追加します。

```CSharp
grass = Content.Load<Texture2D>("grass");
```

### <a name="6-draw-the-sprite"></a>6. スプライトを描画する
四角形を描画するには、以下の行を追加、**Draw** メソッドに追加します。

```CSharp
GraphicsDevice.Clear(Color.CornflowerBlue);
spriteBatch.Begin();
spriteBatch.Draw(grass, new Rectangle(0, (int)(screenHeight * SKYRATIO),
  (int)screenWidth, (int)screenHeight), Color.White);
spriteBatch.End();
```

ここでは、**spriteBatch.Draw** メソッドを使用して、指定されたテクスチャを Rectangle オブジェクトの境界内に配置します。 **Rectangle** は、左上角および右下角の x 座標と y 座標で定義されます。 先ほど定義した変数 **screenWidth**、**screenHeight**、**SKYRATIO** を使用して、画面の下から 3 分の 1 まで緑色の四角形のテクスチャを描画します。 この時点でプログラムを実行すると、これまでの青い背景が、部分的に緑色の四角形で覆われます。

![緑色の四角形](images/monogame-tutorial-1.png)

## <a name="scale-to-high-dpi-screens"></a>高 DPI 画面へのスケーリング
Surface Pro や Surface Studio などで見られる高ピクセル密度モニターで Visual Studioを実行している場合、先ほどの緑色の四角形で、画面の下から 3 分の 1 までがきちんと覆われていないことがあります。 その場合は、画面の左下角が隠れない状態になります。 この問題を解決し、すべてのデバイスでゲームのエクスペリエンスを統一するには、画面のピクセル密度を基準として特定の値をスケーリングするメソッドを作成する必要があります。

```CSharp
public float ScaleToHighDPI(float f)
{
  DisplayInformation d = DisplayInformation.GetForCurrentView();
  f *= (float)d.RawPixelsPerViewPixel;
  return f;
}
```

次に、**Initialize** メソッド内の **screenHeight** および **screenWidth** の初期化を以下のコードに置き換えます。

```CSharp
screenHeight = ScaleToHighDPI((float)ApplicationView.GetForCurrentView().VisibleBounds.Height);
screenWidth = ScaleToHighDPI((float)ApplicationView.GetForCurrentView().VisibleBounds.Width);
```

この時点で、高 DPI 画面でアプリを実行すると、意図したとおりに画面の下から 3 分の 1 までが緑色の四角形で覆われます。

## <a name="build-the-spriteclass"></a>SpriteClass のビルド
スプライトのアニメーションを開始する前に、SpriteClass という新しいクラスを作成しましょう。このクラスを使用すると、スプライト処理に関する表面上の複雑さを軽減できます。

### <a name="1-create-a-new-class"></a>1. 新しいクラスを作成する
**ソリューション エクスプローラー**で、**[MonoGame2D (Universal Windows)]** (MonoGame2D (ユニバーサル Windows)) を右クリックし、**[追加] -> [クラス]** を選択します。 クラスに「SpriteClass.cs」という名前を指定し、**[追加]** を選択します。

### <a name="2-add-class-variables"></a>2. クラス変数を追加する
今作成したクラスに、以下のコードを追加します。

```CSharp
public Texture2D texture
{
  get;
}

public float x
{
  get;
  set;
}

public float y
{
  get;
  set;
}

public float angle
{
  get;
  set;
}

public float dX
{
  get;
  set;
}

public float dY
{
  get;
  set;
}

public float dA
{
  get;
  set;
}

public float scale
{
  get;
  set;
}
```

ここでは、スプライトの描画とアニメーション化に必要なクラス変数をセットアップします。 **x** 変数と **y** 変数は、平面上のスプライトの現在の位置を表し、**angle** 変数は、スプライトの現在の角度を度単位で表します (0 の場合は直立、90 の場合は時計回りに 90 度傾斜)。 このクラスでは **x** と **y** がスプライトの**中央**の座標を表している点に注意します (既定の起点は左上角)。 これにより、指定された起点を中心としてスプライトが回転するため、スプライトの回転が容易になり、回転モーションを統一できます。

その後に、**dX**、**dY**、**dA** があります。これらはそれぞれ、変数 **x**、**y**、**angle** の 1 秒あたりの変化レートです。

### <a name="3-create-a-constructor"></a>3. コンストラクターを作成する
**SpriteClass** のインスタンスを作成する場合は、**Game1.cs** からのグラフィックス デバイス、プロジェクト フォルダーを基準としたテクスチャのパス、元のサイズを基準としたテクスチャの倍率をコンストラクターに渡します。 残りのクラス変数は、ゲームを開始した後、Update メソッドで設定します。

```CSharp
public SpriteClass (GraphicsDevice graphicsDevice, string textureName, float scale)
{
  this.scale = scale;
  if (texture == null)
  {
    using (var stream = TitleContainer.OpenStream(textureName))
    {
      texture = Texture2D.FromStream(graphicsDevice, stream);
    }
  }
}
```

### <a name="4-update-and-draw"></a>4. 更新と描画
SpriteClass 宣言に追加する必要のあるメソッドが、あと 2 つあります。

```CSharp
public void Update (float elapsedTime)
{
  this.x += this.dX * elapsedTime;
  this.y += this.dY * elapsedTime;
  this.angle += this.dA * elapsedTime;
}

public void Draw (SpriteBatch spriteBatch)
{
  Vector2 spritePosition = new Vector2(this.x, this.y);
  spriteBatch.Draw(texture, spritePosition, null, Color.White, this.angle, new Vector2(texture.Width/2, texture.Height/2), new Vector2(scale, scale), SpriteEffects.None, 0f);
}
```

SpriteClass の **Update** メソッドは、Game1.cs の **Update** メソッドで呼び出され、スプライトの **x**、**y**、および **angle** の値をそれぞれの変化レートに基づいて更新するために使用されます。

**Draw** メソッドは、Game1.cs の **Draw** メソッドで呼び出され、ゲーム ウィンドウにスプライトを描画するために使用されます。

## <a name="user-input-and-animation"></a>ユーザー入力とアニメーション
これで SpriteClass を構築できたため、これを使用して 2 つの新しいゲーム オブジェクトを作成します。1 つ目は、プレイヤーが方向キーと Space キーで制御できるアバターです。 2 つ目は、プレイヤーが回避する必要があるオブジェクトです。

### <a name="1-get-the-textures"></a>1. テクスチャを入手する
プレイヤーのアバターには、Microsoft 独自のニンジャ キャットを使用します。ニンジャ キャットは、信頼できるティラノサウルスに乗っています。 [画像をダウンロードするには、こちらをクリックしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/ninja-cat-dino.png)。

次は、プレイヤーが避ける必要がある障害物を設定します。 ニンジャ キャットとティラノサウルスの両方が何より嫌うものは、 野菜を食べることです。 [画像をダウンロードするには、こちらをクリックしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/broccoli.png)。

緑色の四角形のときと同じように、これらの画像を **[MonoGame Pipeline]** (MonoGame パイプライン) 経由で **Content.mgcb** に追加し、それぞれ「ninja-cat-dino.png」および「broccoli.png」という名前を指定します。

### <a name="2-add-class-variables"></a>2. クラス変数を追加する
**Game1.cs** の一連のクラス変数に、以下のコードを追加します。

```CSharp
SpriteClass dino;
SpriteClass broccoli;

bool spaceDown;
bool gameStarted;

float broccoliSpeedMultiplier;
float gravitySpeed;
float dinoSpeedX;
float dinoJumpY;
float score;

Random random;
```

**dino** と **broccoli** は、SpriteClass 変数です。 **dino** はプレイヤーのアバターを保持し、**broccoli** はブロッコリの障害物を保持します。

**spaceDown** は、Space キーが押したまま (押してすぐ離していない) になっているかどうかを追跡します。

**gameStarted** は、ユーザーがゲームを開始したのが初めてかどうかを示します。

**broccoliSpeedMultiplier** は、障害物であるブロッコリが画面上を移動する速度を示します。

**gravitySpeed** は、プレイヤーのアバターがジャンプの後に下向きにどの程度加速するかを示します。

**dinoSpeedX** と **dinoJumpY** は、プレイヤーのアバターが移動およびジャンプする速度を示します。
score は、プレイヤーがかわした障害物の数を追跡します。

最後に、**random** は、障害物であるブロッコリの動作にランダム性を加えるために使用します。

### <a name="3-initialize-variables"></a>3. 変数を初期化する
次に、これらの変数を初期化する必要があります。 以下のコードを Initialize メソッドに追加します。

```CSharp
broccoliSpeedMultiplier = 0.5f;
spaceDown = false;
gameStarted = false;
score = 0;
random = new Random();
dinoSpeedX = ScaleToHighDPI(1000f);
dinoJumpY = ScaleToHighDPI(-1200f);
gravitySpeed = ScaleToHighDPI(30f);
```

下から 3 つの変数は、変化レートをピクセルで指定しているため、高 DPI デバイス用にはスケーリングが必要である点に注意してください。

### <a name="4-construct-spriteclasses"></a>4. SpriteClasses を作成する
SpriteClass オブジェクトは、**LoadContent** メソッドで作成します。 既にあるコードに、以下を追加します。

```CSharp
dino = new SpriteClass(GraphicsDevice, "Content/ninja-cat-dino.png", ScaleToHighDPI(1f));
broccoli = new SpriteClass(GraphicsDevice, "Content/broccoli.png", ScaleToHighDPI(0.2f));
```

ブロッコリの画像は、ゲームへの表示に適したサイズよりかなり大きいため、元のサイズの 0.2 倍に縮小します。

### <a name="5-program-obstacle-behavior"></a>5. 障害物の動作のプログラム
ブロッコリは画面の外で生成され、プレイヤーのアバターの方に向かうため、プレイヤーのアバターはブロッコリをかわす必要があります。 そのためには、このメソッドを **Game1.cs** クラスに追加します。

```CSharp
public void SpawnBroccoli()
{
  int direction = random.Next(1, 5);
  switch (direction)
  {
    case 1:
      broccoli.x = -100;
      broccoli.y = random.Next(0, (int)screenHeight);
      break;
    case 2:
      broccoli.y = -100;
      broccoli.x = random.Next(0, (int)screenWidth);
      break;
    case 3:
      broccoli.x = screenWidth + 100;
      broccoli.y = random.Next(0, (int)screenHeight);
      break;
    case 4:
      broccoli.y = screenHeight + 100;
      broccoli.x = random.Next(0, (int)screenWidth);
      break;
  }

  if (score % 5 == 0) broccoliSpeedMultiplier += 0.2f;

  broccoli.dX = (dino.x - broccoli.x) * broccoliSpeedMultiplier;
  broccoli.dY = (dino.y - broccoli.y) * broccoliSpeedMultiplier;
  broccoli.dA = 7f;
}
```

メソッドの最初の部分では、ランダム数を使用して、broccoli オブジェクトが生成される画面外の位置を指定しています。

2 番目の部分では、現在のスコアによってブロッコリの速度を決定しています。 プレイヤーがブロッコリを 5 個かわすごとに、速度が増します。

3 番目の部分では、broccoli スプライトによるモーションの方向を設定しています。 ブロッコリは、生成されると、プレイヤーのアバター (恐竜) の方に向います。 また、**dA** には 7f という値が設定されています。これにより、プレイヤーを追随する際にはブロッコリがスピンしながら空中を進むことになります。

### <a name="6-program-game-starting-state"></a>6. ゲームの開始状態のプログラム
キーボード入力の処理に進む前に、作成した 2 つのオブジェクトの初期ゲーム状態を設定するメソッドが必要です。 また、ゲームはアプリが実行されるとすぐに開始するのではなく、ユーザーが Space キーを押すことにより手動で開始できるようにします。 アニメーション化されたオブジェクトの初期状態を設定し、スコアをリセットする以下のコードを追加してください。

```CSharp
public void StartGame()
{
  dino.x = screenWidth / 2;
  dino.y = screenHeight * SKYRATIO;
  broccoliSpeedMultiplier = 0.5f;
  SpawnBroccoli();  
  score = 0;
}
```

### <a name="7-handle-keyboard-input"></a>7. キーボード入力を処理します。
次に、キーボード経由でユーザー入力を処理する新しいメソッドが必要です。 このメソッドを **Game1.cs** に追加します。

```CSharp
void KeyboardHandler()
{
  KeyboardState state = Keyboard.GetState();

  // Quit the game if Escape is pressed.
  if (state.IsKeyDown(Keys.Escape))
  {
    Exit();
  }

  // Start the game if Space is pressed.
  if (!gameStarted)
  {
    if (state.IsKeyDown(Keys.Space))
    {
      StartGame();
      gameStarted = true;
      spaceDown = true;
      gameOver = false;
    }
    return;
  }            
  // Jump if Space is pressed
  if (state.IsKeyDown(Keys.Space) || state.IsKeyDown(Keys.Up))
  {
    // Jump if the Space is pressed but not held and the dino is on the floor
    if (!spaceDown && dino.y >= screenHeight * SKYRATIO - 1) dino.dY = dinoJumpY;

    spaceDown = true;
  }
  else spaceDown = false;

  // Handle left and right
  if (state.IsKeyDown(Keys.Left)) dino.dX = dinoSpeedX * -1;

  else if (state.IsKeyDown(Keys.Right)) dino.dX = dinoSpeedX;
  else dino.dX = 0;
}
```

上のコードには、4 つの if ステートメントが含まれています。

1 つ目では、**Esc** キーが押されるとゲームを終了します。

2 つ目では、**Space** キーが押され、ゲームがまだ開始されていなければ、ゲームを開始します。

3 つ目では、**Space** が押されると **dY** プロパティを変更することで恐竜アバターをジャンプさせます。 ただしプレイヤーは、"地上" (dino.y = screenHeight * SKYRATIO) にいなければジャンプできません。また、Space キーが 1 回押されるのではなく押したままになっている場合もジャンプしません。 押したままになっている場合は、ゲームを開始する同じキープレスが認識され、ゲームが始まると同時に恐竜がジャンプできなくなります。

最後の if/else 句では、左または右の方向キーが押されているかどうかを確認し、押されている場合は、キーに応じて恐竜の **dX** プロパティを変更します。

**課題:** 上のキーボード処理メソッドで、方向キーと同様に、WASD 入力スキームも処理できますか?

### <a name="8-add-logic-to-the-update-method"></a>8. ロジックに Update メソッドを追加する
次に、これらすべての部分のロジックを **Game1.cs** の **Update** メソッドに追加する必要があります。

```CSharp
float elapsedTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
KeyboardHandler(); // Handle keyboard input
// Update animated SpriteClass objects based on their current rates of change
dino.Update(elapsedTime);
broccoli.Update(elapsedTime);

// Accelerate the dino downward each frame to simulate gravity.
dino.dY += gravitySpeed;

// Set game floor so the player does not fall through it
if (dino.y > screenHeight * SKYRATIO)
{
  dino.dY = 0;
  dino.y = screenHeight * SKYRATIO;
}

// Set game edges to prevent the player from moving offscreen
if (dino.x > screenWidth - dino.texture.Width/2)
{
  dino.x = screenWidth - dino.texture.Width/2;
  dino.dX = 0;
}
if (dino.x < 0 + dino.texture.Width/2)
{
  dino.x = 0 + dino.texture.Width/2;
  dino.dX = 0;
}

// If the broccoli goes offscreen, spawn a new one and iterate the score
if (broccoli.y > screenHeight+100 || broccoli.y < -100 || broccoli.x > screenWidth+100 || broccoli.x < -100)
{
  SpawnBroccoli();
  score++;
}
```

### <a name="9-draw-spriteclass-objects"></a>9. SpriteClass オブジェクトを描画する
最後に、**Game1.cs** の **Draw** メソッドに以下のコードを追加します (**spriteBatch.Draw** の最後の呼び出しの直後)。

```CSharp
broccoli.Draw(spriteBatch);
dino.Draw(spriteBatch);
```

MonoGame では、**spriteBatch.Draw** を新しく呼び出すと、その時点までの呼び出しを上書きして描画されます。 つまり、broccoli および dino スプライトはどちらも、既存の grass スプライトの上に描画されるため、どこにあっても grass スプライトに隠れることはありません。

ここでゲームを実行し、方向キーと Space キーを使用して、恐竜を動かしてみてください。 これまでの手順に従っていれば、ゲーム ウィンドウ内でアバターを移動できます。ブロッコリはさらに高速化します。

![プレイヤーのアバターと障害物](images/monogame-tutorial-2.png)

## <a name="render-text-with-spritefont"></a>SpriteFont によるテキストのレンダリング
上記のコードでは、プレイヤーのスコアを内部的に追跡できますが、実際にはプレイヤーに伝えていません。 また、アプリの起動時に表示される画面は、あまり直観的ではありません。プレイヤーには青と緑のウィンドウが見えますが、ゲームを開始するためには Space キーを押す必要があると知る方法がありません。

これらの問題をどちらも解決するために、**SpriteFonts** という新しい種類の MonoGame オブジェクトを使用します。

### <a name="1-create-spritefont-description-files"></a>1. SpriteFont 記述ファイルを作成する
**ソリューション エクスプローラー**で、**[コンテンツ]** フォルダーを見つけます。 このフォルダー内の **Content.mgcb** ファイルを右クリックし、**[プログラムから開く]** を選択します。 ポップアップ メニューから **[MonoGame Pipeline]** (MonoGame パイプライン) を選択し、**[OK]** をクリックします。 新しいウィンドウで **[コンテンツ]** 項目を右クリックし、**[追加] -> [新しいアイテム]** を選択します。 **[SpriteFont Description]** (SpriteFont 記述) を選択し、「Score」という名前を指定して、**[OK]** をクリックします。 次に、同じ手順を使って、別の SpriteFont 記述を「GameState」という名前で追加します。

### <a name="2-edit-descriptions"></a>2. 記述を編集する
**[MonoGame Pipeline]** (MonoGame パイプライン) の **[コンテンツ]** フォルダーを右クリックし、**[ファイルの場所を開く]** を選択します。 先ほど作成した SpriteFont 記述ファイルや、これまでに [コンテンツ] フォルダーに追加した画像がすべて含まれたフォルダーが表示されます。 MonoGame パイプライン ウィンドウを保存して閉じます。 **エクスプローラー**で、両方の記述ファイルをテキスト エディター (Visual Studio、NotePad++、Atom など) で開きます。

各記述には、SpriteFont を記述するさまざまな値が含まれています。 いくつか変更を行いましょう。

**Score.spritefont** で、**<Size>** の値を 12 から 36 に変更します。

**GameState.spritefont** で、**<Size>** の値を 12 から 72 に変更し、**<FontName>** の値を Arial から Agency に変更します。 Agency も、Windows 10 のコンピューターに標準で付属しているフォントです。画面にスタイルを加えるために、これを使用します。

### <a name="3-load-spritefonts"></a>3. SpriteFonts を読み込む
Visual Studio に戻って、まず、導入のスプラッシュ スクリーン用に新しいテクスチャを追加します。 [画像をダウンロードするには、こちらをクリックしてください](https://github.com/Microsoft/Windows-appsample-get-started-mg2d/blob/master/MonoGame2D/Content/start-splash.png)。

先ほどと同じように、[コンテンツ] を右クリックして **[追加] -> [既存の項目]** を選択することで、テクスチャをプロジェクトに追加します。 新しい項目に「start-splash.png」という名前を付けます。

次に、以下のクラス変数を **Game1.cs** に追加します。

```CSharp
Texture2D startGameSplash;
SpriteFont scoreFont;
SpriteFont stateFont;
```

次に、以下の行を **LoadContent** メソッドに追加します。

```CSharp
startGameSplash = Content.Load<Texture2D>("start-splash");
scoreFont = Content.Load<SpriteFont>("Score");
stateFont = Content.Load<SpriteFont>("GameState");
```

### <a name="4-draw-the-score"></a>4. スコアを描画する
**Game1.cs** の **Draw** メソッドに移動し、以下のコードを **spriteBatch.End();** の直前に追加します。

```CSharp
spriteBatch.DrawString(scoreFont, score.ToString(),
new Vector2(screenWidth - 100, 50), Color.Black);
```

上のコードでは、先ほど作成したスプライト記述 (Arial Size 36) を使用して、プレイヤーの現在のスコアを画面の右上付近に描画しています。

### <a name="5-draw-horizontally-centered-text"></a>5. テキストを水平方向で中央揃えにして描画する
ゲームを作成する場合は、水平方向または垂直方向で中央揃えにしてテキストを描画する機会が多数あります。 導入のテキストを水平方向で中央揃えにするには、以下のコードを **Draw**メソッドの **spriteBatch.End();** の直前に追加します。

```CSharp
if (!gameStarted)
{
  // Fill the screen with black before the game starts
  spriteBatch.Draw(startGameSplash, new Rectangle(0, 0,
  (int)screenWidth, (int)screenHeight), Color.White);

  String title = "VEGGIE JUMP";
  String pressSpace = "Press Space to start";

  // Measure the size of text in the given font
  Vector2 titleSize = stateFont.MeasureString(title);
  Vector2 pressSpaceSize = stateFont.MeasureString(pressSpace);

  // Draw the text horizontally centered
  spriteBatch.DrawString(stateFont, title,
  new Vector2(screenWidth / 2 - titleSize.X / 2, screenHeight / 3),
  Color.ForestGreen);
  spriteBatch.DrawString(stateFont, pressSpace,
  new Vector2(screenWidth / 2 - pressSpaceSize.X / 2,
  screenHeight / 2), Color.White);
  }
```

まず、描画するテキスト行に対して 1 つずつ、合計 2 つの String を作成します。 次に、**SpriteFont.MeasureString(String)** メソッドを使用して、各行の出力時の幅と高さを計測します。 これにより、サイズを **Vector2** オブジェクトとして取得できます。**X** プロパティには幅、**Y** プロパティには高さが格納されます。

最後に、1 行ずつ描画しています。 テキストを水平方向で中央揃えにするために、位置ベクトルの **X** 値として **screenWidth / 2 - textSize.X / 2** を指定しています。

**課題:** テキストを水平方向だけでなく垂直方向でも中央揃えにするには、上の手順をどのように変更しますか?

ゲームを実行してみましょう。 導入のスプラッシュ スクリーンは表示されますか?  ブロッコリが再生成されるたびに、スコア カウントが加算されますか?

![導入のスプラッシュ](images/monogame-tutorial-3.png)

## <a name="collision-detection"></a>衝突の検出
これで、プレイヤーを追随するブロッコリをセットアップし、新しいブロッコリが生成されるたびに加算されるスコアも用意できました。ただ、このままでは、実際にゲームに負ける方法がありません。 dino スプライトと broccoli スプライトが衝突したかどうかを知り、衝突した場合はゲーム オーバーを宣言する手段が必要です。

### <a name="1-rectangular-collision"></a>1. 四角形の衝突
ゲーム内での衝突を検出するためには、多くの場合、オブジェクトを単純化して数学的な複雑さを軽減します。 ここでは、プレイヤーのアバターとブロッコリの障害物の衝突を検出する目的で、これらをどちらも四角形として扱います。

**SpriteClass.cs** を開き、新しいクラス変数を追加します。

```CSharp
const float HITBOXSCALE = .5f;
```

この値は、衝突の検出がプレイヤーにとってどの程度 "寛容" であるかを表します。 この値を .5f にした場合、恐竜がブロッコリに衝突する四角形の境界 (多くの場合は "ヒットボックス" と呼ばれます) が、テクスチャのフルサイズの半分になります。 その結果、画像のどの部分も実際に触れているようには見えないのに 2 つのテクスチャの角が衝突する機会は少なくなります。 この値は、好みに応じて自由に調整してください。

次に、新しいメソッドを **SpriteClass.cs** に追加します。

```CSharp
public bool RectangleCollision(SpriteClass otherSprite)
{
  if (this.x + this.texture.Width * this.scale * HITBOXSCALE / 2 < otherSprite.x - otherSprite.texture.Width * otherSprite.scale / 2) return false;
  if (this.y + this.texture.Height * this.scale * HITBOXSCALE / 2 < otherSprite.y - otherSprite.texture.Height * otherSprite.scale / 2) return false;
  if (this.x - this.texture.Width * this.scale * HITBOXSCALE / 2 > otherSprite.x + otherSprite.texture.Width * otherSprite.scale / 2) return false;
  if (this.y - this.texture.Height * this.scale * HITBOXSCALE / 2 > otherSprite.y + otherSprite.texture.Height * otherSprite.scale / 2) return false;
  return true;
}
```

このメソッドでは、2 つの四角形オブジェクトが衝突したかどうかを検出します。 このアルゴリズムでは、四角形どうしの辺と辺の間に隙間があるかどうかをテストします。 隙間があれば、衝突していません。隙間がなければ、衝突しているということになります。

### <a name="2-load-new-textures"></a>2. 新しいテクスチャを読み込む

次は、**Game1.cs** を開き、2 つの新しいクラス変数を追加します。1 つはゲーム オーバーのスプライト テクスチャを格納し、もう 1 つはゲームの状態を追跡するためのブール値を格納します。

```CSharp
Texture2D gameOverTexture;
bool gameOver;
```

次に、**Initialize** メソッドで **gameOver** を初期化します。

```CSharp
gameOver = false;
```

最後に、**LoadContent** メソッドの **gameOverTexture** にテクスチャを読み込みます。

```CSharp
gameOverTexture = Content.Load<Texture2D>("game-over");
```

### <a name="3-implement-game-over-logic"></a>3."ゲーム オーバー" のロジックを実装する
以下のコードを **Update** メソッド (**KeyboardHandler** メソッドの呼び出し直後) に追加します。

```CSharp
if (gameOver)
{
  dino.dX = 0;
  dino.dY = 0;
  broccoli.dX = 0;
  broccoli.dY = 0;
  broccoli.dA = 0;
}
```

これにより、ゲームが終了したときにすべてのモーションが停止し、恐竜とブロッコリが現在の位置に固定されます。

次に、**Update** メソッドの最後 (**base.Update(gameTime)** の直前) に、以下の行を追加します。

```CSharp
if (dino.RectangleCollision(broccoli)) gameOver = true;
```

これにより、**SpriteClass** で作成した **RectangleCollision** メソッドが呼び出され、true が返された場合は、ゲーム オーバーのフラグが設定されます。

### <a name="4-add-user-input-for-resetting-the-game"></a>4. ゲームをリセットするためのユーザー入力を追加する
ユーザーが Enter キーを押してゲームをリセットできるように、以下のコードを **KeyboardHandler** メソッドに追加します。

```CSharp
if (gameOver && state.IsKeyDown(Keys.Enter))
{
  StartGame();
  gameOver = false;
}
```

### <a name="5-draw-game-over-splash-and-text"></a>5. ゲーム オーバーのスプラッシュとテキストを描画する
最後に、以下のコードを Draw メソッド内の **spriteBatch.Draw** の呼び出し (grass テクスチャを描画する) の直後に追加します。

```CSharp
if (gameOver)
{
  // Draw game over texture
  spriteBatch.Draw(gameOverTexture, new Vector2(screenWidth / 2 - gameOverTexture.Width / 2, screenHeight / 4 - gameOverTexture.Width / 2), Color.White);

  String pressEnter = "Press Enter to restart!";

  // Measure the size of text in the given font
  Vector2 pressEnterSize = stateFont.MeasureString(pressEnter);

  // Draw the text horizontally centered
  spriteBatch.DrawString(stateFont, pressEnter, new Vector2(screenWidth / 2 - pressEnterSize.X / 2, screenHeight - 200), Color.White);
}
```

前と同じメソッドを使用して (導入のスプラッシュと同じフォントを使用して)、テキストを水平方向で中央揃えにします。また、ウィンドウの上半分で、**gameOverTexture** も中央揃えにします。

これで、終わりです。 ゲームをもう一度実行してみてください。 これまでの手順に従っていれば、恐竜がブロッコリに衝突するとゲームが終了するようになっています。また、Enter キーを押してゲームを再起動するようにプレイヤーに求めるメッセージも表示されます。

![ゲーム オーバー](images/monogame-tutorial-4.png)

## <a name="publish-to-the-microsoft-store"></a>Microsoft Store への公開します。
UWP アプリとしては、このゲームを作成したためは、このプロジェクトを Microsoft Store に公開することもできます。 このプロセスにはいくつかの手順が必要になります。

Windows 開発者として[登録](https://developer.microsoft.com/en-us/store/register)する必要があります。

[アプリの申請チェックリスト](https://docs.microsoft.com/en-us/windows/uwp/publish/app-submissions)を使用する必要があります。

[認定](https://docs.microsoft.com/en-us/windows/uwp/publish/the-app-certification-process)を受けるために、アプリを提出する必要があります。

詳細については、 [UWP アプリの公開](https://developer.microsoft.com/en-us/store/publish-apps)を参照してください。
