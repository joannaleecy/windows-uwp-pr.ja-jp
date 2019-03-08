---
title: Marble Maze、C++ と DirectX での UWP ゲームの開発
description: ドキュメントのこのセクションでは、DirectX と Visual C++ を使って 3D のユニバーサル Windows プラットフォーム (UWP) ゲームを作成する方法について説明します。
ms.assetid: 43f1977a-7e1d-614c-696e-7669dd8a9cc7
ms.date: 08/10/2017
ms.topic: article
keywords: Windows 10, UWP, ゲーム, サンプル, DirectX, 3D
ms.localizationpriority: medium
ms.openlocfilehash: 39f915ad9cf200a5c2c762976ab3c39c2ef85410
ms.sourcegitcommit: b034650b684a767274d5d88746faeea373c8e34f
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 03/06/2019
ms.locfileid: "57662467"
---
# <a name="developing-marble-maze-a-uwp-game-in-c-and-directx"></a><span data-ttu-id="61b43-104">Marble Maze、C++ と DirectX での UWP ゲームの開発</span><span class="sxs-lookup"><span data-stu-id="61b43-104">Developing Marble Maze, a UWP game in C++ and DirectX</span></span>




<span data-ttu-id="61b43-105">このトピックでは、DirectX と Visual C++ を使って 3D のユニバーサル Windows プラットフォーム (UWP) ゲームを作成する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-105">This topic describes how to use DirectX and Visual C++ to create a 3D Universal Windows Platform (UWP) game.</span></span> <span data-ttu-id="61b43-106">Marble Maze と呼ばれるこのゲームでは、タブレット、従来のデスクトップ、ノート PC などの、複数のフォーム ファクターを活用しています。</span><span class="sxs-lookup"><span data-stu-id="61b43-106">The game, called Marble Maze, embraces multiple form factors such as tablets as well as traditional desktop and laptop PCs.</span></span>

> [!NOTE]
> <span data-ttu-id="61b43-107">Marble Maze のソース コードをダウンロードするには、[GitHub のサンプル](https://go.microsoft.com/fwlink/?LinkId=624011)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61b43-107">To download the Marble Maze source code, see the [sample on GitHub](https://go.microsoft.com/fwlink/?LinkId=624011).</span></span>

> [!IMPORTANT]
> <span data-ttu-id="61b43-108">Marble Maze は、UWP ゲームを作成するためのベスト プラクティスと考えられる設計パターンを示しています。</span><span class="sxs-lookup"><span data-stu-id="61b43-108">Marble Maze illustrates design patterns that we consider to be best practices for creating UWP games.</span></span> <span data-ttu-id="61b43-109">各自のプラクティスと開発するゲームの固有の要件に適合するように、このゲームの実装の詳細を利用できます。</span><span class="sxs-lookup"><span data-stu-id="61b43-109">You can adapt many of the implementation details to fit your own practices and the unique requirements of the game you are developing.</span></span> <span data-ttu-id="61b43-110">各自のニーズに適合する別のテクニックやライブラリがある場合はそれを自由にお使いください </span><span class="sxs-lookup"><span data-stu-id="61b43-110">Feel free to use different techniques or libraries when those better suit your needs.</span></span> <span data-ttu-id="61b43-111">(ただし、常に確認コードが合格する、 [Windows アプリ認定キット](https://docs.microsoft.com/windows/uwp/debug-test-perf/windows-app-certification-kit))。ゲーム開発を成功に不可欠に実装を考慮すると部分が強調します、このドキュメントで。</span><span class="sxs-lookup"><span data-stu-id="61b43-111">(However, always ensure that your code passes the [Windows App Certification Kit](https://docs.microsoft.com/windows/uwp/debug-test-perf/windows-app-certification-kit).) When we consider an implementation used here to be essential for successful game development, we emphasize it in this documentation.</span></span>

 

## <a name="introducing-marble-maze"></a><span data-ttu-id="61b43-112">Marble Maze について</span><span class="sxs-lookup"><span data-stu-id="61b43-112">Introducing Marble Maze</span></span>


<span data-ttu-id="61b43-113">Marble Maze を選んだのは、それが比較的基本的なゲームであるにもかかわらず、大半のゲームで使われる多様な機能を備えているためです。</span><span class="sxs-lookup"><span data-stu-id="61b43-113">We chose Marble Maze because it is relatively basic, but still demonstrates the breadth of features that are found in most games.</span></span> <span data-ttu-id="61b43-114">Marble Maze は、グラフィックス、入力処理、オーディオの使用方法を示しています。</span><span class="sxs-lookup"><span data-stu-id="61b43-114">It shows how to use graphics, input handling, and audio.</span></span> <span data-ttu-id="61b43-115">さらに、規則やゴールなどのゲームのメカニズムも示します。</span><span class="sxs-lookup"><span data-stu-id="61b43-115">It also demonstrates game mechanics such as rules and goals.</span></span>

<span data-ttu-id="61b43-116">Marble Maze は、通常は穴がある箱と金属またはガラス製の大理石で構成される卓上版の迷路ゲームに似ています。</span><span class="sxs-lookup"><span data-stu-id="61b43-116">Marble Maze resembles the table-top labyrinth game that is typically constructed from a box that contains holes and a steel or glass marble.</span></span> <span data-ttu-id="61b43-117">Marble Maze のゴールは、卓上版と同じです。迷路を傾けて、大理石を迷路の入り口から出口まで、穴に落とさずにできるだけ短い時間で誘導することです。</span><span class="sxs-lookup"><span data-stu-id="61b43-117">The goal of Marble Maze is the same as the table-top version: tilt the maze to guide the marble from the start to the end of the maze in as little time as possible, without letting the marble fall into any of the holes.</span></span> <span data-ttu-id="61b43-118">Marble Maze には、チェックポイントという概念が追加されています。</span><span class="sxs-lookup"><span data-stu-id="61b43-118">Marble Maze adds the concept of checkpoints.</span></span> <span data-ttu-id="61b43-119">大理石が穴に落ちた場合、ゲームは、大理石が通過した最後のチェックポイントの場所から再開されます。</span><span class="sxs-lookup"><span data-stu-id="61b43-119">If the marble falls into a hole, the game is restarted at the last checkpoint location that the marble passed over.</span></span>

<span data-ttu-id="61b43-120">Marble Maze では、ユーザーは複数の方法でゲーム ボードを操作できます。</span><span class="sxs-lookup"><span data-stu-id="61b43-120">Marble Maze offers multiple ways for a user to interact with the game board.</span></span> <span data-ttu-id="61b43-121">タッチ対応または加速度計対応デバイスの場合は、これらのデバイスを使ってゲーム ボードを動かすことができます。</span><span class="sxs-lookup"><span data-stu-id="61b43-121">If you have a touch-enabled or accelerometer-enabled device, you can use those devices to move the game board.</span></span> <span data-ttu-id="61b43-122">Xbox One コントローラーまたはマウスを使って、ゲームのプレイを制御することもできます。</span><span class="sxs-lookup"><span data-stu-id="61b43-122">You can also use an Xbox One controller or a mouse to control game play.</span></span>

![Marble Maze ゲームのスクリーン ショット。](images/marblemaze-2.png)

## <a name="prerequisites"></a><span data-ttu-id="61b43-124">前提条件</span><span class="sxs-lookup"><span data-stu-id="61b43-124">Prerequisites</span></span>


-   <span data-ttu-id="61b43-125">Windows 10 Creators Update します。</span><span class="sxs-lookup"><span data-stu-id="61b43-125">Windows 10 Creators Update</span></span>
-   [<span data-ttu-id="61b43-126">Microsoft Visual Studio 2017</span><span class="sxs-lookup"><span data-stu-id="61b43-126">Microsoft Visual Studio 2017</span></span>](https://www.visualstudio.com/downloads/)
-   <span data-ttu-id="61b43-127">C++ プログラミングの知識</span><span class="sxs-lookup"><span data-stu-id="61b43-127">C++ programming knowledge</span></span>
-   <span data-ttu-id="61b43-128">DirectX と DirectX の用語に関する知識</span><span class="sxs-lookup"><span data-stu-id="61b43-128">Familiarity with DirectX and DirectX terminology</span></span>
-   <span data-ttu-id="61b43-129">COM に関する基本的な知識</span><span class="sxs-lookup"><span data-stu-id="61b43-129">Basic knowledge of COM</span></span>

## <a name="who-should-read-this"></a><span data-ttu-id="61b43-130">このドキュメントの対象読者</span><span class="sxs-lookup"><span data-stu-id="61b43-130">Who should read this?</span></span>


<span data-ttu-id="61b43-131">3D ゲームや Windows 10 用の他のグラフィックを多用するアプリケーションを作成したい場合は、これは。</span><span class="sxs-lookup"><span data-stu-id="61b43-131">If you’re interested in creating 3D games or other graphics-intensive applications for Windows 10, this is for you.</span></span> <span data-ttu-id="61b43-132">このドキュメントで説明する基本原則とプラクティスを活用して、各自の UWP ゲームを作成してください。</span><span class="sxs-lookup"><span data-stu-id="61b43-132">We hope you use the principles and practices that this documentation outlines to create your own UWP game.</span></span> <span data-ttu-id="61b43-133">C++ と DirectX のプログラミングの知識または強い興味があれば、このドキュメントを活用するのに役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="61b43-133">A background or strong interest in C++ and DirectX programming will help you get the most out of this documentation.</span></span> <span data-ttu-id="61b43-134">DirectX の経験がない場合でも、類似の 3D グラフィックスのプログラミング環境の経験があれば役に立ちます。</span><span class="sxs-lookup"><span data-stu-id="61b43-134">If you don't have experience with DirectX, you can still benefit if you have experience with similar 3D graphics programming environments.</span></span>

<span data-ttu-id="61b43-135">ドキュメント「[チュートリアル: DirectX によるシンプルな UWP ゲームの作成](tutorial--create-your-first-uwp-directx-game.md)」に、DirectX と C++ を使った基本的な 3D シューティング ゲームを実装するサンプルの説明があります。</span><span class="sxs-lookup"><span data-stu-id="61b43-135">The document [Walkthrough: create a simple UWP game with DirectX](tutorial--create-your-first-uwp-directx-game.md) describes another sample that implements a basic 3D shooting game by using DirectX and C++.</span></span>

## <a name="what-this-documentation-covers"></a><span data-ttu-id="61b43-136">このドキュメントの内容</span><span class="sxs-lookup"><span data-stu-id="61b43-136">What this documentation covers</span></span>


<span data-ttu-id="61b43-137">このドキュメントでは、以下の方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-137">This documentation teaches how to:</span></span>

-   <span data-ttu-id="61b43-138">Windows ランタイム API と DirectX を使って UWP ゲームを作成する。</span><span class="sxs-lookup"><span data-stu-id="61b43-138">Use the Windows Runtime API and DirectX to create a UWP game.</span></span>
-   <span data-ttu-id="61b43-139">[Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476080) と [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) を使って、モデル、テクスチャ、頂点シェーダー、ピクセル シェーダー、2D オーバーレイ等の視覚的なコンテンツを操作する。</span><span class="sxs-lookup"><span data-stu-id="61b43-139">Use [Direct3D](https://msdn.microsoft.com/library/windows/desktop/ff476080) and [Direct2D](https://msdn.microsoft.com/library/windows/desktop/dd370990) to work with visual content such as models, textures, vertex and pixel shaders, and 2D overlays.</span></span>
-   <span data-ttu-id="61b43-140">タッチ、加速度計、Xbox One コントローラーなどの入力メカニズムを統合する。</span><span class="sxs-lookup"><span data-stu-id="61b43-140">Integrate input mechanisms such as touch, accelerometer, and the Xbox One controller.</span></span>
-   <span data-ttu-id="61b43-141">[XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) を使って、音楽とサウンド エフェクトを組み込む。</span><span class="sxs-lookup"><span data-stu-id="61b43-141">Use [XAudio2](https://msdn.microsoft.com/library/windows/desktop/hh405049) to incorporate music and sound effects.</span></span>

## <a name="what-this-documentation-does-not-cover"></a><span data-ttu-id="61b43-142">このドキュメントで扱われていない内容</span><span class="sxs-lookup"><span data-stu-id="61b43-142">What this documentation does not cover</span></span>


<span data-ttu-id="61b43-143">このドキュメントでは、ゲーム開発の次の側面は扱いません。</span><span class="sxs-lookup"><span data-stu-id="61b43-143">This documentation does not cover the following aspects of game development.</span></span> <span data-ttu-id="61b43-144">これらの側面は、追加リソースで扱われます。</span><span class="sxs-lookup"><span data-stu-id="61b43-144">These aspects are followed by additional resources that cover them.</span></span>

-   <span data-ttu-id="61b43-145">3D ゲームの設計原則。</span><span class="sxs-lookup"><span data-stu-id="61b43-145">3D game design principles.</span></span>
-   <span data-ttu-id="61b43-146">C++ または DirectX プログラミングの基本。</span><span class="sxs-lookup"><span data-stu-id="61b43-146">C++ or DirectX programming basics.</span></span>
-   <span data-ttu-id="61b43-147">テクスチャ、モデル、オーディオなどのリソースを設計する方法。</span><span class="sxs-lookup"><span data-stu-id="61b43-147">How to design resources such as textures, models, or audio.</span></span>
-   <span data-ttu-id="61b43-148">ゲームの動作またはパフォーマンスに関する問題をトラブルシューティングする方法。</span><span class="sxs-lookup"><span data-stu-id="61b43-148">How to troubleshoot behavior or performance issues in your game.</span></span>
-   <span data-ttu-id="61b43-149">海外で使用できるようにゲームを準備する方法。</span><span class="sxs-lookup"><span data-stu-id="61b43-149">How to prepare your game for use in other parts of the world.</span></span>
-   <span data-ttu-id="61b43-150">ゲームを検証して Microsoft Store に公開する方法。</span><span class="sxs-lookup"><span data-stu-id="61b43-150">How to certify and publish your game to the Microsoft Store.</span></span>

<span data-ttu-id="61b43-151">Marble Maze では、[DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) ライブラリを使って、3D ジオメトリの操作と衝突などの物理計算を実行します。</span><span class="sxs-lookup"><span data-stu-id="61b43-151">Marble Maze also uses the [DirectXMath](https://msdn.microsoft.com/library/windows/desktop/hh437833) library to work with 3D geometry and perform physics calculations, such as collisions.</span></span> <span data-ttu-id="61b43-152">DirectXMath については、このセクションでは詳しく説明しません。</span><span class="sxs-lookup"><span data-stu-id="61b43-152">DirectXMath is not covered in-depth in this section.</span></span> <span data-ttu-id="61b43-153">Marble Maze での DirectXMath の使用方法については、ソース コードをご覧ください。</span><span class="sxs-lookup"><span data-stu-id="61b43-153">For details about how Marble Maze uses DirectXMath, refer to the source code.</span></span>

<span data-ttu-id="61b43-154">Marble Maze には再利用可能なコンポーネントがたくさん用意されていますが、それは完全なゲーム開発フレームワークではありません。</span><span class="sxs-lookup"><span data-stu-id="61b43-154">Although Marble Maze provides many reusable components, it is not a complete game development framework.</span></span> <span data-ttu-id="61b43-155">Marble Maze のコンポーネントをゲームで再利用できると見なされる場合は、このドキュメントでその点を強調しています。</span><span class="sxs-lookup"><span data-stu-id="61b43-155">When we consider a Marble Maze component to be reusable in your game, we emphasize it in the documentation.</span></span>

## <a name="next-steps"></a><span data-ttu-id="61b43-156">次のステップ</span><span class="sxs-lookup"><span data-stu-id="61b43-156">Next steps</span></span>


<span data-ttu-id="61b43-157">「[Marble Maze サンプルの基礎](marble-maze-sample-fundamentals.md)」で、Marble Maze の構造と、Marble Maze のソース コードが従っているコーディング ガイドラインとスタイル ガイドラインを確認することから始めることをお勧めします。</span><span class="sxs-lookup"><span data-stu-id="61b43-157">We recommend that you start with [Marble Maze sample fundamentals](marble-maze-sample-fundamentals.md) to learn about the Marble Maze structure and some of the coding and style guidelines that the Marble Maze source code follows.</span></span> <span data-ttu-id="61b43-158">次の表に、簡単に参照できるように、このセクションに含まれるドキュメントの概要を示します。</span><span class="sxs-lookup"><span data-stu-id="61b43-158">The following table outlines the documents in this section so that you can more easily refer to them.</span></span>

## <a name="in-this-section"></a><span data-ttu-id="61b43-159">このセクションの内容</span><span class="sxs-lookup"><span data-stu-id="61b43-159">In this section</span></span>


| <span data-ttu-id="61b43-160">タイトル</span><span class="sxs-lookup"><span data-stu-id="61b43-160">Title</span></span>                                                                                                                    | <span data-ttu-id="61b43-161">説明</span><span class="sxs-lookup"><span data-stu-id="61b43-161">Description</span></span>                                                                                                                                                                                                                                        |
|--------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|
| [<span data-ttu-id="61b43-162">Marble Maze サンプルの基礎</span><span class="sxs-lookup"><span data-stu-id="61b43-162">Marble Maze sample fundamentals</span></span>](marble-maze-sample-fundamentals.md)                                                   | <span data-ttu-id="61b43-163">ゲームの構造の概要と、ソース コードが従っているコーディング ガイドラインとスタイル ガイドラインの一部を示します。</span><span class="sxs-lookup"><span data-stu-id="61b43-163">Provides an overview of the game structure and some of the code and style guidelines that the source code follows.</span></span>                                                                                                                                 |
| [<span data-ttu-id="61b43-164">Marble Maze のアプリケーション構造</span><span class="sxs-lookup"><span data-stu-id="61b43-164">Marble Maze application structure</span></span>](marble-maze-application-structure.md)                                               | <span data-ttu-id="61b43-165">Marble Maze アプリケーション コードの構造と、DirectX UWP アプリの構造と従来のデスクトップ アプリケーションの構造の違いについて説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-165">Describes how the Marble Maze application code is structured and how the structure of a DirectX UWP app differs from that of a traditional desktop application.</span></span>                                                                                    |
| [<span data-ttu-id="61b43-166">Marble Maze サンプルへのビジュアル コンテンツの追加</span><span class="sxs-lookup"><span data-stu-id="61b43-166">Adding visual content to the Marble Maze sample</span></span>](adding-visual-content-to-the-marble-maze-sample.md)                   | <span data-ttu-id="61b43-167">Direct3D と Direct2D を使うときに留意する主なプラクティスについて説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-167">Describes some of the key practices to keep in mind when you work with Direct3D and Direct2D.</span></span> <span data-ttu-id="61b43-168">これらのプラクティスが Marble Maze の視覚的なコンテンツにどのように適用されるかについても説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-168">Also describes how Marble Maze applies these practices for visual content.</span></span>                                                                           |
| [<span data-ttu-id="61b43-169">入力および Marble Maze サンプルへの対話機能を追加します。</span><span class="sxs-lookup"><span data-stu-id="61b43-169">Adding input and interactivity to the Marble Maze sample</span></span>](adding-input-and-interactivity-to-the-marble-maze-sample.md) | <span data-ttu-id="61b43-170">ユーザーがメニュー間を移動し、ゲーム ボードを操作できるように、Marble Maze が加速度計入力、タッチ入力、Xbox One コントローラー入力を処理する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-170">Describes how Marble Maze works with accelerometer, touch, and Xbox One controller inputs to enable users to navigate menus and interact with the game board.</span></span> <span data-ttu-id="61b43-171">入力を操作するときに留意するベスト プラクティスについても説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-171">Also describes some of the best practices to keep in mind when you work with input.</span></span> |
| [<span data-ttu-id="61b43-172">Marble Maze サンプルへのオーディオの追加</span><span class="sxs-lookup"><span data-stu-id="61b43-172">Adding audio to the Marble Maze sample</span></span>](adding-audio-to-the-marble-maze-sample.md)                                     | <span data-ttu-id="61b43-173">Marble Maze でオーディオを操作して音楽とサウンド エフェクトをゲームのエクスペリエンスに追加する方法について説明します。</span><span class="sxs-lookup"><span data-stu-id="61b43-173">Describes how Marble Maze works with audio to add music and sound effects to the game experience.</span></span>                                                                                                                                                  |

 

 

 




