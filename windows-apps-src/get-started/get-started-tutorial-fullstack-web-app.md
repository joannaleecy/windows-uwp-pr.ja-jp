---
author: libbymc
title: REST API のバックエンドを使った単一ページの Web アプリを作成する
description: よく使われる Web テクノロジを使用して、Microsoft Store 用のホストされた Web アプリを構築する
keywords: ホストされた Web アプリ、HWA、REST API、単一ページ アプリ、SPA
ms.author: libbymc
ms.date: 05/10/2017
ms.topic: article
ms.prod: Microsoft Edge, Azure, Visual Studio Code
ms.technology: web
ms.localizationpriority: medium
ms.openlocfilehash: 42f11cbdd749a44c4ba0d8bc1a0397a4f2882257
ms.sourcegitcommit: 72835733ec429a5deb6a11da4112336746e5e9cf
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/19/2018
ms.locfileid: "5164116"
---
# <a name="create-a-single-page-web-app-with-rest-api-backend"></a><span data-ttu-id="c30b9-104">REST API のバックエンドを使った単一ページの Web アプリを作成する</span><span class="sxs-lookup"><span data-stu-id="c30b9-104">Create a single-page web app with REST API backend</span></span>

**<span data-ttu-id="c30b9-105">よく使われるフルスタックの Web テクノロジを使用して Microsoft Store 用のホストされた Web アプリを構築する</span><span class="sxs-lookup"><span data-stu-id="c30b9-105">Build a Hosted Web App for the Microsoft Store with popular fullstack web technologies</span></span>**

![単一ページの Web アプリである、簡単なメモリ ゲーム](images/fullstack.png)

<span data-ttu-id="c30b9-107">2 つの部分から構成されるこのチュートリアルでは、モダンなフルスタックの Web 開発を簡単に紹介します。このチュートリアルでは、ブラウザーでも、Microsoft Store 用のホストされた Web アプリとしても動作する、簡単なメモリ ゲームを構築します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-107">This two-part tutorial provides a quick tour of modern fullstack web development as you build a simple memory game that works both in the browser and as a Hosted Web App for the Microsoft Store.</span></span> <span data-ttu-id="c30b9-108">パート 1 では、ゲームのバックエンドのためのシンプルな REST API サービスを構築します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-108">In Part I you'll build a simple REST API service for the game's backend.</span></span> <span data-ttu-id="c30b9-109">ゲーム ロジックをクラウドで API サービスとしてホストすることにより、ゲームの状態を保持することができ、ユーザーは異なるデバイスにわたって、ゲームの同じインスタンスのプレイを続けることができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-109">By hosting the game logic in the cloud as an API service, you preserve the game state so your user can keep playing their same game instance across different devices.</span></span> <span data-ttu-id="c30b9-110">パート 2 では、レスポンシブ レイアウトを使った単一ページの Web アプリとして、フロント エンド UI を構築します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-110">In Part II you'll build the front-end UI as a single-page web app with responsive layout.</span></span>

<span data-ttu-id="c30b9-111">ここでは、サーバー側の開発のための [Node.js](https://nodejs.org/en/) ランタイムや [Express](http://expressjs.com/)、[Bootstrap](http://getbootstrap.com/) UI フレームワーク、RESTful API 構築のための [Pug](https://www.npmjs.com/package/pug) テンプレート エンジンや [Swagger](http://swagger.io/tools/) などの、よく使われる Web テクノロジを使用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-111">We'll be using some of the most popular web technologies, including the [Node.js](https://nodejs.org/en/) runtime and [Express](http://expressjs.com/) for server-side development, the [Bootstrap](http://getbootstrap.com/) UI framework, the [Pug](https://www.npmjs.com/package/pug) template engine, and [Swagger](http://swagger.io/tools/) for building RESTful APIs.</span></span> <span data-ttu-id="c30b9-112">さらに、クラウド ホスティングのための [Azure Portal](https://ms.portal.azure.com/) や、[Visual Studio Code](https://code.visualstudio.com/) エディターの操作についても扱います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-112">You'll also gain experience with the [Azure Portal](https://ms.portal.azure.com/) for cloud hosting and working with the [Visual Studio Code](https://code.visualstudio.com/) editor.</span></span>

## <a name="prerequisites"></a><span data-ttu-id="c30b9-113">前提条件</span><span class="sxs-lookup"><span data-stu-id="c30b9-113">Prerequisites</span></span>

<span data-ttu-id="c30b9-114">コンピューター上に次のようなリソースがない場合には、リンクを使ってダウンロードしてください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-114">If you don't already have these resources on your machine, follow these download links:</span></span>

 - <span data-ttu-id="c30b9-115">[Node.js](https://nodejs.org/en/download/) - Node を PATH に追加するオプションを必ず選択してください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-115">[Node.js](https://nodejs.org/en/download/) - Be sure to select the option to add Node to your PATH.</span></span>

 - <span data-ttu-id="c30b9-116">[Express ジェネレーター](http://expressjs.com/en/starter/generator.html)- Node のインストール後に、次のコマンドを実行して Express をインストールします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-116">[Express generator](http://expressjs.com/en/starter/generator.html)- After you install Node, install Express by running</span></span> `npm install express-generator -g`

 - [<span data-ttu-id="c30b9-117">Visual Studio Code</span><span class="sxs-lookup"><span data-stu-id="c30b9-117">Visual Studio Code</span></span>](https://code.visualstudio.com/)

<span data-ttu-id="c30b9-118">最後のステップを完了して、API サービスとメモリ ゲーム アプリを Microsoft Azure でホスティングする場合には、[無料の Azure アカウントを作成](https://azure.microsoft.com/en-us/free/)する必要があります (既に作成していない場合)。</span><span class="sxs-lookup"><span data-stu-id="c30b9-118">If you want to complete the final steps of hosting your API service and memory game app on Microsoft Azure, you'll need to [create a free Azure account](https://azure.microsoft.com/en-us/free/) if you haven't already done so.</span></span>

<span data-ttu-id="c30b9-119">Azure の部分を行わない (または後で行う) 場合には、Azure のホスティングと、Microsoft Store 用のアプリのパッケージングについて説明している、パート 1 の最後のセクションとパート 2 を省略してください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-119">If you decide to bail on (or postpone) the Azure part, simply skip the final sections of parts I and II, which cover Azure hosting and packaging your app for the Microsoft Store.</span></span> <span data-ttu-id="c30b9-120">その場合には、構築した API サービスと Webアプリをローカル コンピューター上で実行できます (それぞれ `http://localhost:8000`、`http://localhost:3000` から実行できます)。</span><span class="sxs-lookup"><span data-stu-id="c30b9-120">The API service and web app you build will still run locally (from `http://localhost:8000` and `http://localhost:3000`, respectively) on your machine.</span></span>

## <a name="part-i-build-a-rest-api-backend"></a><span data-ttu-id="c30b9-121">パート 1: REST API バックエンドの構築</span><span class="sxs-lookup"><span data-stu-id="c30b9-121">Part I: Build a REST API backend</span></span>

<span data-ttu-id="c30b9-122">最初に、簡単なメモリ ゲームの Web アプリを実現するための、メモリ ゲームの API を構築します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-122">We'll first build a simple memory game API to power our memory game web app.</span></span> <span data-ttu-id="c30b9-123">[Swagger](http://swagger.io/) を使って API を定義し、手動テストのためのスキャフォールディング コードと Web UI を生成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-123">We'll use [Swagger](http://swagger.io/) to define our API and generate scaffolding code and a web UI for manual testing.</span></span>

<span data-ttu-id="c30b9-124">このパートを省略して、[パート 2: 単一ページの Web アプリを構築する](#part-ii-build-a-single-page-web-appl)に直接進む場合には、[パート 1 の完成コード](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/backend)を利用できます。*README* の指示に沿って、ローカルでコードを実行するか、または *5. API サービスを Azure でホストして CORS を有効化する*を参照して Azure で実行します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-124">If you'd like to skip this part and move straight to [Part II: Build a single-page web application](#part-ii-build-a-single-page-web-appl), here's the [finished code for Part I](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/backend). Follow the *README* instructions to get the code up and running locally, or see *5. Host your API service on Azure and enable CORS* to run it from Azure.</span></span>

### <a name="game-overview"></a><span data-ttu-id="c30b9-125">ゲームの概要</span><span class="sxs-lookup"><span data-stu-id="c30b9-125">Game overview</span></span>

<span data-ttu-id="c30b9-126">*メモリ* ([*神経衰弱*](https://en.wikipedia.org/wiki/Concentration_(game))や[*ペルマニズム*](https://en.wikipedia.org/wiki/Pelmanism_(system))とも呼ばれます) は、トランプのカードのペアを使った、簡単なゲームです。</span><span class="sxs-lookup"><span data-stu-id="c30b9-126">*Memory* (also known as [*Concentration*](https://en.wikipedia.org/wiki/Concentration_(game)) and [*Pelmanism*](https://en.wikipedia.org/wiki/Pelmanism_(system))), is a simple game consisting of a deck of card pairs.</span></span> <span data-ttu-id="c30b9-127">カードはテーブル上に裏向きで配置され、プレイヤーは一度に 2 枚のカードを開いて、一致しているかどうかを確認します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-127">The cards are placed face-down on the table, and the player inspects the card values, two at a time, looking for matches.</span></span> <span data-ttu-id="c30b9-128">一致するペアが見つかったら、その 2 枚のカードはゲームからクリアされます。それ以外の場合には、2 枚とも裏向きに戻します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-128">After each turn the cards are again placed face-down, unless a matching pair is found, in which case those two cards are cleared from the game.</span></span> <span data-ttu-id="c30b9-129">ゲームの目的は、できるだけ少ない回数で、すべてのカードのペアを見つけることです。</span><span class="sxs-lookup"><span data-stu-id="c30b9-129">The game objective is to find all card pairs in the fewest amount of turns.</span></span>

<span data-ttu-id="c30b9-130">ここでは説明用のため、ゲームの構造を非常にシンプルにし、ゲームは 1 回のみで、1 人のプレイヤーとしています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-130">For instructional purposes, the game structure we'll use is very simple: it's single game, single player.</span></span> <span data-ttu-id="c30b9-131">ただし、ゲーム ロジックを (クライアントでなく) サーバー側に配置し、ゲームの状態を保存できるようにします。これによって、異なるデバイスにわたって、同じゲームのプレイを続けることができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-131">However, the game logic is server-side (rather than on the client) to preserve the game state, so that you could keep playing the same game across different devices.</span></span>

<span data-ttu-id="c30b9-132">メモリ ゲームのデータ構造は、JavaScript オブジェクトの配列のみで構成されます。それぞれが 1 つのカードを表し、配列内のインデックスを持ち、これがカード ID として機能します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-132">The data structure for a memory game consists simply of an array of JavaScript objects, each representing a single card, with indices in the array acting as card IDs.</span></span> <span data-ttu-id="c30b9-133">サーバー上では、各カード オブジェクトが 1 つの値と **cleared** フラグを持ちます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-133">On the server, each card object has a value and a **cleared** flag.</span></span> <span data-ttu-id="c30b9-134">たとえば、2 組のペア (4 枚のカード) から成るゲーム ボードは、ランダムに生成されて、次のようにシリアル化されます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-134">For example, a board of 2-matches (4 cards) might be randomly generated and serialized like this.</span></span>

```json
[
    { "cleared":"false",
        "value":"0",
    },
    { "cleared":"false",
        "value":"1",
    },
    { "cleared":"false",
        "value":"1",
    },
    { "cleared":"false",
        "value":"0",
    }
]
```

<span data-ttu-id="c30b9-135">ボードの配列がクライアントに渡されると、不正を防ぐために (たとえば、ブラウザーの F12 ツールを使って、HTTP 応答の本文を検査するなど)、value キーを配列から削除します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-135">When the board array is passed to the client, value keys are removed from the array to prevent cheating (for example, inspecting the HTTP response body by using F12 browser tools).</span></span> <span data-ttu-id="c30b9-136">**GET /game** REST エンドポイントを呼び出すクライアントに対して、新しい同じゲームは次のようになります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-136">Here's how that same new game would look to a client calling the **GET /game** REST endpoint:</span></span>

```json
[{ "cleared":"false"},{ "cleared":"false"},{ "cleared":"false"},{ "cleared":"false"}]
```

<span data-ttu-id="c30b9-137">エンドポイントについては、メモリ ゲーム サービスは、次の 3 つの REST API で構成されます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-137">Speaking of endpoints, the memory game service will consist of three REST APIs.</span></span>

#### <a name="post-new"></a><span data-ttu-id="c30b9-138">POST /new</span><span class="sxs-lookup"><span data-stu-id="c30b9-138">POST /new</span></span>
<span data-ttu-id="c30b9-139">指定されたサイズで (数字はペアの数を表します) 新しいゲーム ボードを初期化します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-139">Initializes a new game board of the specified size (# of matches).</span></span>

| <span data-ttu-id="c30b9-140">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c30b9-140">Parameter</span></span> | <span data-ttu-id="c30b9-141">説明</span><span class="sxs-lookup"><span data-stu-id="c30b9-141">Description</span></span> |
|-----------|-------------|
| <span data-ttu-id="c30b9-142">int *size*</span><span class="sxs-lookup"><span data-stu-id="c30b9-142">int *size*</span></span> |<span data-ttu-id="c30b9-143">ゲーム ボードに含まれる、一致するペアの数。</span><span class="sxs-lookup"><span data-stu-id="c30b9-143">Number of matching pairs to be shuffled into the game "board".</span></span> <span data-ttu-id="c30b9-144">例: </span><span class="sxs-lookup"><span data-stu-id="c30b9-144">Example:</span></span> `http://memorygameapisample/new?size=2`|

| <span data-ttu-id="c30b9-145">応答</span><span class="sxs-lookup"><span data-stu-id="c30b9-145">Response</span></span> | <span data-ttu-id="c30b9-146">説明</span><span class="sxs-lookup"><span data-stu-id="c30b9-146">Description</span></span> |
|----------|-------------|
| <span data-ttu-id="c30b9-147">200 OK</span><span class="sxs-lookup"><span data-stu-id="c30b9-147">200 OK</span></span> | <span data-ttu-id="c30b9-148">要求されたサイズの新しいメモリ ゲームの準備ができました。</span><span class="sxs-lookup"><span data-stu-id="c30b9-148">New memory game of requested size is ready.</span></span>|
| <span data-ttu-id="c30b9-149">400 BAD REQUEST</span><span class="sxs-lookup"><span data-stu-id="c30b9-149">400 BAD REQUEST</span></span>| <span data-ttu-id="c30b9-150">要求されたサイズは、許容範囲外です。</span><span class="sxs-lookup"><span data-stu-id="c30b9-150">Requested size is outside of acceptable range.</span></span>|


#### <a name="get-game"></a><span data-ttu-id="c30b9-151">GET /game</span><span class="sxs-lookup"><span data-stu-id="c30b9-151">GET /game</span></span>
<span data-ttu-id="c30b9-152">メモリ ゲーム ボードの現在の状態を取得します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-152">Retrieves the current state of the memory game board.</span></span>

*<span data-ttu-id="c30b9-153">パラメーター: なし</span><span class="sxs-lookup"><span data-stu-id="c30b9-153">No parameters</span></span>*

| <span data-ttu-id="c30b9-154">応答</span><span class="sxs-lookup"><span data-stu-id="c30b9-154">Response</span></span> | <span data-ttu-id="c30b9-155">説明</span><span class="sxs-lookup"><span data-stu-id="c30b9-155">Description</span></span> |
|----------|-------------|
| <span data-ttu-id="c30b9-156">200 OK</span><span class="sxs-lookup"><span data-stu-id="c30b9-156">200 OK</span></span> | <span data-ttu-id="c30b9-157">カード オブジェクトの JSON 配列を返します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-157">Returns JSON array of card objects.</span></span> <span data-ttu-id="c30b9-158">各カードには、ペアが既に見つかったことを示す、**cleared** プロパティがあります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-158">Each card has a **cleared** property indicating whether its match has already been found.</span></span> <span data-ttu-id="c30b9-159">一致したカードは、その **value** も報告します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-159">Matched cards also report their **value**.</span></span> <span data-ttu-id="c30b9-160">例: </span><span class="sxs-lookup"><span data-stu-id="c30b9-160">Example:</span></span> `[{"cleared":"false"},{"cleared":"false"},{"cleared":"true","value":1},{"cleared":"true","value":1}]`|

#### <a name="put-guess"></a><span data-ttu-id="c30b9-161">PUT /guess</span><span class="sxs-lookup"><span data-stu-id="c30b9-161">PUT /guess</span></span>
<span data-ttu-id="c30b9-162">表向きにするカードを指定し、前に表向きにしたカードとの一致を確認します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-162">Specifies a card to reveal and checks for a match to the previously revealed card.</span></span>

| <span data-ttu-id="c30b9-163">パラメーター</span><span class="sxs-lookup"><span data-stu-id="c30b9-163">Parameter</span></span> | <span data-ttu-id="c30b9-164">説明</span><span class="sxs-lookup"><span data-stu-id="c30b9-164">Description</span></span> |
|-----------|-------------|
| <span data-ttu-id="c30b9-165">int *card*</span><span class="sxs-lookup"><span data-stu-id="c30b9-165">int *card*</span></span> | <span data-ttu-id="c30b9-166">表向きにするカードのカード ID (ゲーム ボード配列内のインデックス)。</span><span class="sxs-lookup"><span data-stu-id="c30b9-166">Card ID (index in game board array) of the card to reveal.</span></span> <span data-ttu-id="c30b9-167">完了した各「推測」は、指定された 2 枚のカード (つまり、有効で一意の *card* 値 を持つ、2 つの **/guess** の呼び出し) で構成されます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-167">Each complete "guess" consists of two specified cards (i.e., two calls to **/guess** with valid and unique *card* values).</span></span> <span data-ttu-id="c30b9-168">例: </span><span class="sxs-lookup"><span data-stu-id="c30b9-168">Example:</span></span> `http://memorygameapisample/guess?card=0`|

| <span data-ttu-id="c30b9-169">応答</span><span class="sxs-lookup"><span data-stu-id="c30b9-169">Response</span></span> | <span data-ttu-id="c30b9-170">説明</span><span class="sxs-lookup"><span data-stu-id="c30b9-170">Description</span></span> |
|----------|-------------|
| <span data-ttu-id="c30b9-171">200 OK</span><span class="sxs-lookup"><span data-stu-id="c30b9-171">200 OK</span></span> | <span data-ttu-id="c30b9-172">指定されたカードの **id** と **value** を持つ JSON を返します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-172">Returns JSON with the **id** and **value** of the specified card.</span></span> <span data-ttu-id="c30b9-173">例: </span><span class="sxs-lookup"><span data-stu-id="c30b9-173">Example:</span></span> `[{"id":0,"value":1}]`|
| <span data-ttu-id="c30b9-174">400 BAD REQUEST</span><span class="sxs-lookup"><span data-stu-id="c30b9-174">400 BAD REQUEST</span></span> |  <span data-ttu-id="c30b9-175">指定されたカードでエラーが発生しました。</span><span class="sxs-lookup"><span data-stu-id="c30b9-175">Error with the specified card.</span></span> <span data-ttu-id="c30b9-176">詳細は HTTP 応答の本文を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-176">See HTTP response body for further details.</span></span>|

### <a name="1-spec-out-the-api-and-generate-code-stubs"></a><span data-ttu-id="c30b9-177">1. API を指定して、コード スタブを生成する</span><span class="sxs-lookup"><span data-stu-id="c30b9-177">1. Spec out the API and generate code stubs</span></span>

<span data-ttu-id="c30b9-178">[Swagger](http://swagger.io/) を使って、メモリ ゲームの API の設計を、動作する Node.js サーバー コードに変換します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-178">We'll use [Swagger](http://swagger.io/) to transform the design of our memory game API into working Node.js server code.</span></span> <span data-ttu-id="c30b9-179">次のようにして、[メモリ ゲーム API を Swagger メタデータとして](https://github.com/Microsoft/Windows-tutorials-web/blob/master/Single-Page-App-with-REST-API/backend/api.json)定義できます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-179">Here's how you might define our [memory game APIs as Swagger metadata](https://github.com/Microsoft/Windows-tutorials-web/blob/master/Single-Page-App-with-REST-API/backend/api.json).</span></span> <span data-ttu-id="c30b9-180">これを使って、サーバー コードのスタブを生成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-180">We'll use this to generate server code stubs.</span></span>

1. <span data-ttu-id="c30b9-181">新しいフォルダー (たとえば、ローカルの *GitHub* ディレクトリ) を作成し、メモリ ゲーム API 定義を含む [**api.json**](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/api.json?token=ACEfklXAHTeLkHYaI5plV20QCGuqC31cks5ZFhVIwA%3D%3D) ファイルをダウンロードします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-181">Create a new folder (in your local *GitHub* directory, for example), and download the [**api.json**](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/api.json?token=ACEfklXAHTeLkHYaI5plV20QCGuqC31cks5ZFhVIwA%3D%3D) file containing our memory game API definitions.</span></span> <span data-ttu-id="c30b9-182">フォルダー名にスペースが含まれていないことを確認します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-182">Make sure your folder name doesn't contain any spaces.</span></span>

2. <span data-ttu-id="c30b9-183">このフォルダーで好みのシェル ([または Visual Studio Code の統合ターミナル](https://code.visualstudio.com/docs/editor/integrated-terminal)) を開き、次の Node Package Manager (NPM) コマンドを実行して、[Yeoman](http://yeoman.io/) (yo) コード スキャフォールディング ツールおよび Swagger ジェネレーターをグローバル (**-g**) Node 環境にインストールします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-183">Open your favorite shell ([or use Visual Studio Code's integrated terminal!](https://code.visualstudio.com/docs/editor/integrated-terminal)) to that folder and run the following Node Package Manager (NPM) command to install the [Yeoman](http://yeoman.io/) (yo) code-scaffolding tool and Swagger generator for your global (**-g**) Node environment:</span></span>

    ```
    npm install -g yo
    npm install -g generator-swaggerize
    ```

3. <span data-ttu-id="c30b9-184">Swagger を使用して、サーバー スキャフォールディング コードを生成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-184">Now we can generate the server scaffolding code by using Swagger:</span></span>

    ```
    yo swaggerize
    ```

4. <span data-ttu-id="c30b9-185">**Swaggerize** コマンドの質問のメッセージに応答します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-185">The **swaggerize** command will ask you several questions.</span></span>
    - <span data-ttu-id="c30b9-186">Swagger ドキュメントへのパス (またはURL): **api.json**</span><span class="sxs-lookup"><span data-stu-id="c30b9-186">Path (or URL) to swagger document: **api.json**</span></span>
    - <span data-ttu-id="c30b9-187">フレームワーク: **express**</span><span class="sxs-lookup"><span data-stu-id="c30b9-187">Framework: **express**</span></span>
    - <span data-ttu-id="c30b9-188">プロジェクト名 (YourFolderNameHere): **[Enter]**</span><span class="sxs-lookup"><span data-stu-id="c30b9-188">What would you like to call this project (YourFolderNameHere): **[enter]**</span></span>

    <span data-ttu-id="c30b9-189">他は適宜に応答します。これらの情報の多くは *package.json* ファイルに連絡先情報を指定するために使用され、作成したコードを NPM パッケージとして配布できます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-189">Answer everything else as you like; the information is mostly to supply the *package.json* file with your contact info so you can distribute your code as an NPM package.</span></span>

5. <span data-ttu-id="c30b9-190">最後に、新しいプロジェクトのすべての依存関係 (*package.json* に一覧表示されています) および [Swagger UI](http://swagger.io/swagger-ui/) サポートをインストールします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-190">Finally, install all the dependencies (listed in *package.json*) for your new project and [Swagger UI](http://swagger.io/swagger-ui/) support.</span></span>

    ```
    npm install
    npm install swaggerize-ui
    ```

    <span data-ttu-id="c30b9-191">VS Code を開始し、[**ファイル**]  >  [**フォルダーを開く**] と選び、MemoryGameAPI ディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-191">Now start VS Code and **File** > **Open Folder...**, and move to the MemoryGameAPI directory.</span></span> <span data-ttu-id="c30b9-192">これは、先ほど作成した Node.js API サーバーです。</span><span class="sxs-lookup"><span data-stu-id="c30b9-192">This is the Node.js API server you just created!</span></span> <span data-ttu-id="c30b9-193">これは、よく使われる [ExpressJS](http://expressjs.com/en/4x/api.html) Web アプリケーション フレームワークを使って、プロジェクトを構造化して実行します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-193">It uses the popular [ExpressJS](http://expressjs.com/en/4x/api.html) web application framework to structure and run your project.</span></span>

### <a name="2-customize-the-server-code-and-setup-debugging"></a><span data-ttu-id="c30b9-194">2. サーバー コードのカスタマイズとデバッグのセットアップ</span><span class="sxs-lookup"><span data-stu-id="c30b9-194">2. Customize the server code and setup debugging</span></span>

<span data-ttu-id="c30b9-195">プロジェクト ルートの *server.js* ファイルが、サーバーの「メイン」の機能を果たします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-195">The *server.js* file in your project root acts as the "main" function of your server.</span></span> <span data-ttu-id="c30b9-196">そのファイルを VS Code で開き、そこに次のコードをコピーします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-196">Open it in VS Code and copy the following into it.</span></span> <span data-ttu-id="c30b9-197">生成されたコードを変更した行には、詳しい説明のコメントが入っています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-197">The lines modified from the generated code are commented with further explanation.</span></span>

```javascript
'use strict';

var port = process.env.PORT || 8000; // Better flexibility than hardcoding the port

var Http = require('http');
var Express = require('express');
var BodyParser = require('body-parser');
var Swaggerize = require('swaggerize-express');
var SwaggerUi = require('swaggerize-ui'); // Provides UI for testing our API
var Path = require('path');

var App = Express();
var Server = Http.createServer(App);

App.use(function(req, res, next) {  // Enable cross origin resource sharing (for app frontend)
    res.header('Access-Control-Allow-Origin', '*');
    res.header('Access-Control-Allow-Methods', 'GET,PUT,POST,OPTIONS');
    res.header('Access-Control-Allow-Headers', 'Content-Type, Authorization, Content-Length, X-Requested-With');

    // Prevents CORS preflight request (for PUT game_guess) from redirecting
    if ('OPTIONS' == req.method) {
      res.send(200);
    }
    else {
      next(); // Passes control to next (Swagger) handler
    }
});

App.use(BodyParser.json());
App.use(BodyParser.urlencoded({
    extended: true
}));

App.use(Swaggerize({
    api: Path.resolve('./config/swagger.json'),
    handlers: Path.resolve('./handlers'),
    docspath: '/swagger'   //  Hooks up the testing UI
}));

App.use('/', SwaggerUi({    // Serves the testing UI from our base URL
  docs: '/swagger'          //
}));

Server.listen(port, function () {  // Starts server with our modfied port settings
 });
```

<span data-ttu-id="c30b9-198">これでサーバーを実行する準備ができました。</span><span class="sxs-lookup"><span data-stu-id="c30b9-198">With that, it's time to run your server!</span></span> <span data-ttu-id="c30b9-199">Visual Studio Code で、Node のデバックを行うように設定します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-199">Let's set up Visual Studio Code for Node debugging while we're at it.</span></span> <span data-ttu-id="c30b9-200">**デバッグ** パネル アイコン (Ctrl+Shift+D) を選び、次に歯車アイコンを選んで (launch.json を開く)、"configurations" を次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-200">Select on the **Debug** panel icon (Ctrl+Shift+D) and then the gear icon (Open launch.json), and modify "configurations" to this:</span></span>

```json
"configurations": [
    {
        "type": "node",
        "request": "launch",
        "name": "Launch Program",
        "program": "${workspaceRoot}/server.js"
    }
]
```

<span data-ttu-id="c30b9-201">F5 キーを押してブラウザーを開き、[http://localhost:8000](http://localhost:8000) に移動します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-201">Now press F5 and open your browser to [http://localhost:8000](http://localhost:8000).</span></span> <span data-ttu-id="c30b9-202">メモリ ゲーム API の Swagger UI のページが開きます。詳細を展開して、各メソッドのフィールドを入力します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-202">The page should open to the Swagger UI for our memory game API, and from there you can expand the details and input fields for each of the methods.</span></span> <span data-ttu-id="c30b9-203">API の呼び出しを試すこともできますが、応答には ([Swagmock](https://www.npmjs.com/package/swagmock) モジュールが提供する) モックアップ データのみが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-203">You can even try calling the APIs, although their responses will contain only mocked-up data (provided by the [Swagmock](https://www.npmjs.com/package/swagmock) module).</span></span> <span data-ttu-id="c30b9-204">次に、API が実際に動作するように、ゲーム ロジックを追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-204">It's time to add our game logic to make these APIs real.</span></span>

### <a name="3-set-up-your-route-handlers"></a><span data-ttu-id="c30b9-205">3. ルート ハンドラーを設定する</span><span class="sxs-lookup"><span data-stu-id="c30b9-205">3. Set up your route handlers</span></span>

<span data-ttu-id="c30b9-206">Swagger ファイル (config\swagger.json) では、定義されている各 URL パスを (\handlers にある) ハンドラー ファイルにマッピングし、さらにそのパスに定義された各メソッド (**GET**、**POST** など) をハンドラー ファイル内の `operationId` (機能) にマッピングして、サーバーに対して、さまざまなクライアントの HTTP 要求を処理する方法を指示します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-206">The Swagger file (config\swagger.json) instructs our server how to handle various client HTTP requests by mapping each URL path it defines to a handler file (in \handlers), and each method defined for that path (e.g., **GET**, **POST**) to an `operationId` (function) within that handler file.</span></span>

<span data-ttu-id="c30b9-207">プログラムのこのレイヤーには、さまざまなクライアント要求をデータ モデルに渡す前に、いくつかの入力チェックを追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-207">In this layer of our program we'll add some input checking before passing the various client requests to our data model.</span></span> <span data-ttu-id="c30b9-208">次をダウンロード (またはコピーして貼り付け) して利用できます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-208">Download (or copy and paste):</span></span>

 - <span data-ttu-id="c30b9-209">この [game.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/game.js?token=ACEfkvhw6BUnkeSsZgnzVe086T5WLwjfks5ZFhW5wA%3D%3D) コードを **handlers\game.js** ファイルに使います</span><span class="sxs-lookup"><span data-stu-id="c30b9-209">This [game.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/game.js?token=ACEfkvhw6BUnkeSsZgnzVe086T5WLwjfks5ZFhW5wA%3D%3D) code to your **handlers\game.js** file</span></span>
 - <span data-ttu-id="c30b9-210">この [guess.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/guess.js?token=ACEfkswel02rHVr0e61bVsNdpv_i1Rtuks5ZFhXPwA%3D%3D) コードを **handlers\guess.js** ファイルに使います</span><span class="sxs-lookup"><span data-stu-id="c30b9-210">This [guess.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/guess.js?token=ACEfkswel02rHVr0e61bVsNdpv_i1Rtuks5ZFhXPwA%3D%3D) code to your **handlers\guess.js** file</span></span>
 - <span data-ttu-id="c30b9-211">この [new.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/new.js?token=ACEfkgk2QXJeRc0aaLzY5ulFsAR4Juidks5ZFhXawA%3D%3D) コードを **handlers\new.js** ファイルに使います</span><span class="sxs-lookup"><span data-stu-id="c30b9-211">This [new.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/new.js?token=ACEfkgk2QXJeRc0aaLzY5ulFsAR4Juidks5ZFhXawA%3D%3D) code to your **handlers\new.js** file</span></span>

 <span data-ttu-id="c30b9-212">それぞれの変更の詳細については、ファイル内のコメントを確認してください。ここでは、基本的な入力エラーの確認 (たとえば、新しいゲームのクライアント要求でペアの数が 1 より少ないなど) を行い、必要に応じてエラーメッセージを送信しています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-212">You can skim the comments in those files for more details about the changes, but in essence they check for basic input errors (for example, the client requests a new game with less than one match) and send descriptive error messages as needed.</span></span> <span data-ttu-id="c30b9-213">またハンドラーは、有効なクライアント要求を、(\data にある) 対応するデータ ファイルにルーティングして、さらに処理を行うようにします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-213">The handlers also route valid client requests through to their corresponding data files (in \data) for further processing.</span></span> <span data-ttu-id="c30b9-214">これらは次で行います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-214">Let's work on those next.</span></span>

### <a name="4-set-up-your-data-model"></a><span data-ttu-id="c30b9-215">4. データ モデルをセットアップする</span><span class="sxs-lookup"><span data-stu-id="c30b9-215">4. Set up your data model</span></span>

<span data-ttu-id="c30b9-216">プレースホルダーのモックデータ サービスを、実際のメモリ ゲーム ボードのデータ モデルに置き換えます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-216">It's time to swap out the placeholder data-mocking service with a real data model of our memory game board.</span></span>

<span data-ttu-id="c30b9-217">プログラムのこのレイヤーは、メモリ カード自体を表し、ゲーム ロジックのほとんどを提供します。これには、新しいゲームのためのカードのシャッフル、一致したカードのペアの認識、ゲーム状態の記録などが含まれます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-217">This layer of our program represents the memory cards themselves and provides the bulk of the game logic, including "shuffling" the deck for a new game, identifying pairs of matched cards, and keeping track of game state.</span></span> <span data-ttu-id="c30b9-218">次をコピーして貼り付けて利用できます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-218">Copy and paste:</span></span>

 - <span data-ttu-id="c30b9-219">この [game.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/game.js?token=ACEfksAceJNQmhF82aHjQTx78jILYKfCks5ZFhX4wA%3D%3D) コードを **data\game.js** ファイルに使います</span><span class="sxs-lookup"><span data-stu-id="c30b9-219">This [game.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/game.js?token=ACEfksAceJNQmhF82aHjQTx78jILYKfCks5ZFhX4wA%3D%3D) code to your **data\game.js** file</span></span>
 - <span data-ttu-id="c30b9-220">この [guess.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/guess.js?token=ACEfkvY69Zr1AZQ4iXgfCgDxeinT21bBks5ZFhYBwA%3D%3D) コードを **data\guess.js** ファイルに使います</span><span class="sxs-lookup"><span data-stu-id="c30b9-220">This [guess.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/guess.js?token=ACEfkvY69Zr1AZQ4iXgfCgDxeinT21bBks5ZFhYBwA%3D%3D) code to your **data\guess.js** file</span></span>
 - <span data-ttu-id="c30b9-221">この [new.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/new.js?token=ACEfkiqeDN0HjZ4-gIKRh3wfVZPSlEmgks5ZFhYPwA%3D%3D) コードを **data\new.js** ファイルに使います</span><span class="sxs-lookup"><span data-stu-id="c30b9-221">This [new.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/new.js?token=ACEfkiqeDN0HjZ4-gIKRh3wfVZPSlEmgks5ZFhYPwA%3D%3D) code to your **data\new.js** file</span></span>

<span data-ttu-id="c30b9-222">ここでは簡単のため、ゲーム ボードを Node サーバーのグローバル変数 (`global.board`) に保存します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-222">For simplicity, we're storing our game board in a global variable (`global.board`) on our Node server.</span></span> <span data-ttu-id="c30b9-223">同時に複数のプレイヤーによる複数のゲームをサポートする、実際に使えるメモリ ゲーム API サービスとするためには、クラウド ストレージ (Google [Cloud Datastore](https://cloud.google.com/datastore/) や Azure [DocumentDB](https://azure.microsoft.com/en-us/services/documentdb/) など) を使用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-223">But realistically you'd use cloud storage (like Google [Cloud Datastore](https://cloud.google.com/datastore/) or Azure [DocumentDB](https://azure.microsoft.com/en-us/services/documentdb/)) to make this into a viable memory-game API service that concurrently supports multiple games and players.</span></span>

<span data-ttu-id="c30b9-224">VS Code ですべての変更を保存したことを確認し、サーバーを再度起動 (VS Code で F5 キーを押すか、またはシェルから `npm start` を実行して、次に [http://localhost:8000](http://localhost:8000) に移動する) して、ゲームの API をテストします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-224">Make sure you've saved all the changes in VS Code, fire up your server again (F5 in VS Code or `npm start` from shell, and then browse to [http://localhost:8000](http://localhost:8000)) to test out the game API.</span></span>

<span data-ttu-id="c30b9-225">**Try it out!** ボタンを</span><span class="sxs-lookup"><span data-stu-id="c30b9-225">Each time you press the **Try it out!**</span></span> <span data-ttu-id="c30b9-226">**/game**、**/guess**、**/new** のいずれかで押して、下の **Response Body** および **Response Code** の結果を確認し、予想どおりに動作していることを確認します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-226">button on one of the **/game**, **/guess**, or **/new** operations, check the resulting **Response Body** and **Response Code** below to verify that everything's working as expected.</span></span>

<span data-ttu-id="c30b9-227">次のように試してみます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-227">Try:</span></span> 

1. <span data-ttu-id="c30b9-228">新しい `size=2` のゲームを作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-228">Creating a new `size=2` game.</span></span>

    ![Swagger UI から新しいメモリ ゲームを開始する](images/swagger_new.png)

2. <span data-ttu-id="c30b9-230">いくつかの値を推測します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-230">Guessing a couple of values.</span></span>

    ![Swagger UI からカードを推測する](images/swagger_guess.png)

3. <span data-ttu-id="c30b9-232">ゲームを進行しながら、ゲーム ボードを確認します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-232">Checking the game board as the game progresses.</span></span>

    ![Swagger UI からゲームの状態を確認する](images/swagger_game.png)

<span data-ttu-id="c30b9-234">すべての動作を確認したら、API サービスを Azure でホストします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-234">If everything looks good, your API service is ready to host on Azure!</span></span> <span data-ttu-id="c30b9-235">問題が発生した場合には、\data\game.js で、次の行をコメント アウトしてみます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-235">If you're running into problems, try commenting out the following lines in \data\game.js.</span></span>

```javascript
for (var i=0; i < board.length; i++){
    var card = {};
    card.cleared = board[i].cleared;

    // Only reveal cleared card values
    //if ("true" == card.cleared) {        // To debug the board, comment out this line
        card.value = board[i].value;
    //}                                    // And this line
    currentBoardState.push(card);
}
```

<span data-ttu-id="c30b9-236">この変更により、**GET /game** メソッドは (クリアされていないものも含めて) すべてのカードの値を返します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-236">With this change, the **GET /game** method will return all the card values (including the ones that haven't been cleared).</span></span> <span data-ttu-id="c30b9-237">これは、メモリ ゲームのフロント エンドを構築する際のデバッグに役立ちます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-237">This is a useful debug hack to keep in place as you build the front-end for the memory game.</span></span>

### <a name="5-optional-host-your-api-service-on-azure-and-enable-cors"></a><span data-ttu-id="c30b9-238">5. (省略可能) API サービスを Azure でホストして CORS を有効化する</span><span class="sxs-lookup"><span data-stu-id="c30b9-238">5. (Optional) Host your API service on Azure and enable CORS</span></span>

<span data-ttu-id="c30b9-239">次の Azure ドキュメントを参照して作業を行います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-239">The Azure docs will walk you through:</span></span>

 - [<span data-ttu-id="c30b9-240">Azure Portal を使って、新しい *API アプリ*を登録する</span><span class="sxs-lookup"><span data-stu-id="c30b9-240">Registering a new *API App* with Azure Portal</span></span>](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#createapiapp)
 - <span data-ttu-id="c30b9-241">[API アプリの Git デプロイを設定する](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#deploy-the-api-with-git)</span><span class="sxs-lookup"><span data-stu-id="c30b9-241">[Setting up Git deployment for your API app](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#deploy-the-api-with-git), and</span></span>
 - [<span data-ttu-id="c30b9-242">API アプリ コードを Azure にデプロイする</span><span class="sxs-lookup"><span data-stu-id="c30b9-242">Deploying your API app code to Azure</span></span>](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#deploy-the-api-with-git)

<span data-ttu-id="c30b9-243">アプリを登録する場合、*アプリ名*を他と異なるものにするようにします (*http://memorygameapi.azurewebsites.net* URL のバリエーションを要求する、他のアプリと名前が競合しないようにします)。</span><span class="sxs-lookup"><span data-stu-id="c30b9-243">When registering your app, try to differentiate your *App name* (to avoid naming collisions with others requesting variations on the *http://memorygameapi.azurewebsites.net* URL).</span></span>

<span data-ttu-id="c30b9-244">ここまでの作業を行って、Azure と Swagger UI が機能している場合、メモリ ゲームのバックエンドに必要な最後の手順が 1 つあります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-244">If you've made it this far and Azure is now serving up your swagger UI, there's just one final step to the memory game backend.</span></span> <span data-ttu-id="c30b9-245">[Azure Portal](https://portal.azure.com) から、新しく作成した*アプリ サービス*を選び、**CORS** (クロス オリジン リソース共有) オプションを選択または検索します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-245">From [Azure Portal](https://portal.azure.com), select your newly created *App Service* and then select or search for the **CORS** (Cross-Origin Resource Sharing) option.</span></span> <span data-ttu-id="c30b9-246">[**許可されたオリジン**] の下で、アスタリスク (`*`) を追加して、[**保存**] をクリックします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-246">Under **Allowed Origins**, add an asterisk (`*`) and click **Save**.</span></span> <span data-ttu-id="c30b9-247">これにより、ローカル マシンで開発を行いながら、メモリ ゲームのフロントエンドから、作成した API サービスへのクロス オリジンの呼び出しが可能となります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-247">This lets you make cross-origin calls to your API service from your memory-game front-end as you develop it on your local machine.</span></span> <span data-ttu-id="c30b9-248">メモリ ゲームのフロント エンドが完成し、Azure にデプロイしたら、このエントリを Web アプリの特定の URL で置き換えることができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-248">Once you finalize the memory-game front-end and deploy that to Azure, you can replace this entry with the specific URL of your web app.</span></span>

### <a name="going-further"></a><span data-ttu-id="c30b9-249">追加情報</span><span class="sxs-lookup"><span data-stu-id="c30b9-249">Going further</span></span>

<span data-ttu-id="c30b9-250">メモリ ゲーム API を実稼働アプリ用のバックエンド サービスとするためには、複数のプレイヤーとゲームをサポートするようにコードを拡張する必要があります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-250">To make the memory game API a viable back-end service for a production app, you'll want to extend the code to support multiple players and games.</span></span> <span data-ttu-id="c30b9-251">そのためには、[認証](http://swagger.io/docs/specification/authentication/) (プレイヤーの ID を管理する)、[NoSQL データベース](https://docs.microsoft.com/en-us/azure/documentdb/) (ゲームとプレイヤーを管理する)、API の基本的な[単体テスト](https://apigee.com/about/blog/developer/swagger-test-templates-test-your-apis)について調べる必要があります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-251">For that you'll probably need to plumb in [authentication](http://swagger.io/docs/specification/authentication/) (for managing player identities), a [NoSQL database](https://docs.microsoft.com/en-us/azure/documentdb/) (for tracking games and players), and some basic [unit testing](https://apigee.com/about/blog/developer/swagger-test-templates-test-your-apis) for your API.</span></span>

<span data-ttu-id="c30b9-252">そのために役立つ追加情報を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-252">Here are some useful resources for going further:</span></span>

 - [<span data-ttu-id="c30b9-253">Visual Studio Code を使った Node.js の高度なデバッグ</span><span class="sxs-lookup"><span data-stu-id="c30b9-253">Advanced Node.js debugging with Visual Studio Code</span></span>](https://code.visualstudio.com/docs/nodejs/nodejs-debugging)

 - [<span data-ttu-id="c30b9-254">Azure Web + モバイル ドキュメント</span><span class="sxs-lookup"><span data-stu-id="c30b9-254">Azure Web + Mobile docs</span></span>](https://docs.microsoft.com/en-us/azure/#pivot=services&panel=web)

 - [<span data-ttu-id="c30b9-255">Azure DocumentDB ドキュメント</span><span class="sxs-lookup"><span data-stu-id="c30b9-255">Azure DocumentDB docs</span></span>](https://docs.microsoft.com/en-us/azure/documentdb/index)

## <a name="part-ii-build-a-single-page-web-application"></a><span data-ttu-id="c30b9-256">パート 2: 単一ページの web アプリケーションを構築します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-256">Part II: Build a single-page web application</span></span>

<span data-ttu-id="c30b9-257">パート 1 では、[REST API バックエンド](#part-i-build-a-rest-api-backend)を構築 (または[ダウンロード](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/backend)) しました。次に、[Node](https://nodejs.org/en/)、[Express](http://expressjs.com/)、[Bootstrap](http://getbootstrap.com/) を使って、単一ページのメモリ ゲームのフロントエンドを作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-257">Now that you've built (or [downloaded](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/backend)) the [REST API backend](#part-i-build-a-rest-api-backend) from Part I,  you're ready to create the single-page memory game front-end with [Node](https://nodejs.org/en/), [Express](http://expressjs.com/), and [Bootstrap](http://getbootstrap.com/).</span></span>

<span data-ttu-id="c30b9-258">このチュートリアルのパート 2 では、次の内容を扱います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-258">Part II of this tutorial will give you experience with:</span></span> 

* <span data-ttu-id="c30b9-259">[Node.js](https://nodejs.org/en/): ゲームをホストするサーバーの作成</span><span class="sxs-lookup"><span data-stu-id="c30b9-259">[Node.js](https://nodejs.org/en/): to create the server hosting your game</span></span>
* <span data-ttu-id="c30b9-260">[jQuery](http://jquery.com/): JavaScript ライブラリ</span><span class="sxs-lookup"><span data-stu-id="c30b9-260">[jQuery](http://jquery.com/): a JavaScript library</span></span>
* <span data-ttu-id="c30b9-261">[Express](http://expressjs.com/): Web アプリケーション フレームワーク</span><span class="sxs-lookup"><span data-stu-id="c30b9-261">[Express](http://expressjs.com/): for the web application framework</span></span>
* <span data-ttu-id="c30b9-262">[Pug](https://pugjs.org/): (旧 Jade) テンプレート エンジン</span><span class="sxs-lookup"><span data-stu-id="c30b9-262">[Pug](https://pugjs.org/): (formerly Jade) for the templating engine</span></span>
* <span data-ttu-id="c30b9-263">[Bootstrap](http://getbootstrap.com/): レスポンシブ レイアウト</span><span class="sxs-lookup"><span data-stu-id="c30b9-263">[Bootstrap](http://getbootstrap.com/): for the responsive layout</span></span>
* <span data-ttu-id="c30b9-264">[Visual Studio Code](https://code.visualstudio.com/): コードの作成、マークダウン表示、デバッグ</span><span class="sxs-lookup"><span data-stu-id="c30b9-264">[Visual Studio Code](https://code.visualstudio.com/): for code authoring, markdown viewing, and debugging</span></span>

### <a name="1-create-a-nodejs-application-by-using-express"></a><span data-ttu-id="c30b9-265">1. Express を使って Node.js アプリケーションを作成する</span><span class="sxs-lookup"><span data-stu-id="c30b9-265">1. Create a Node.js application by using Express</span></span>

<span data-ttu-id="c30b9-266">まず、Express を使って Node.js プロジェクトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-266">Let's start by creating the Node.js project using Express.</span></span>

1. <span data-ttu-id="c30b9-267">コマンド プロンプトを開き、ゲームの保存先のディレクトリに移動します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-267">Open a command prompt and navigate to the directory where you want to store your game.</span></span> 
2. <span data-ttu-id="c30b9-268">Express ジェネレーターを使い、テンプレート エンジン *Pug* を使用して、新しいアプリケーション *memory* を作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-268">Use the Express generator to create a new application called *memory* using the templating engine, *Pug*.</span></span>

    ```
    express --view=pug memory
    ```

3. <span data-ttu-id="c30b9-269">memory ディレクトリで、package.json ファイルに示されている依存関係をインストールします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-269">In the memory directory, install the dependencies listed in the package.json file.</span></span> <span data-ttu-id="c30b9-270">package.json ファイルは、プロジェクトのルートに作成されます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-270">The package.json file is created in the root of your project.</span></span> <span data-ttu-id="c30b9-271">このファイルには、Node.js アプリに必要なモジュールが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-271">This file contains the modules that are required for your Node.js app.</span></span>  

    ```
    cd memory
    npm install
    ```

    <span data-ttu-id="c30b9-272">このコマンドを実行すると、このアプリに必要なすべてのモジュールを含む、node_modules という名前のフォルダーが作成されます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-272">After running this command, you should see a folder called node_modules that contains all of the modules needed for this app.</span></span> 

4. <span data-ttu-id="c30b9-273">アプリケーションを実行します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-273">Now, run your application.</span></span>

    ```
    npm start
    ```

5. <span data-ttu-id="c30b9-274">[http://localhost:3000/](http://localhost:3000/) に移動してアプリケーションを表示します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-274">View your application by going to [http://localhost:3000/](http://localhost:3000/).</span></span>

    ![http://localhost:3000/ のスクリーンショット](./images/express.png)

6. <span data-ttu-id="c30b9-276">memory\routes ディレクトリの index.js を編集して、Web アプリの既定のタイトルを変更します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-276">Change the default title of your web app by editing index.js in the memory\routes directory.</span></span> <span data-ttu-id="c30b9-277">下記の行の `Express` を `Memory Game` (または任意のタイトル) に変更します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-277">Change `Express` in the line below to `Memory Game` (or another title of your choosing).</span></span>

    ``` javascript
    res.render('index', { title: 'Express' });
    ```

7. <span data-ttu-id="c30b9-278">新しいタイトルを表示するためアプリを更新するには、コマンド プロンプトで **Ctrl + C**、**Y** の順に押してアプリを停止し、`npm start` で再起動します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-278">To refresh the app to see your new title, stop your app by pressing **Crtl + C**, **Y** in the command prompt, and then restart it with `npm start`.</span></span>

### <a name="2-add-client-side-game-logic-code"></a><span data-ttu-id="c30b9-279">2. クライアント側のゲーム ロジック コードを追加する</span><span class="sxs-lookup"><span data-stu-id="c30b9-279">2. Add client-side game logic code</span></span>
<span data-ttu-id="c30b9-280">チュートリアルのこの後半に必要なファイルは、[Start](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Start) フォルダーに含まれています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-280">You can find the files you need for this half of the tutorial in the [Start](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Start) folder.</span></span> <span data-ttu-id="c30b9-281">途中で迷った場合には、[Final](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Final) フォルダーに完成したコードが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-281">If you get lost, the finished code is available in the [Final](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Final) folder.</span></span> 

1. <span data-ttu-id="c30b9-282">[Start](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Start) フォルダー内の scripts.js ファイルをコピーして、それを memory\public\javascripts に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-282">Copy the scripts.js file inside of the [Start](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Start) folder and paste it in memory\public\javascripts.</span></span> <span data-ttu-id="c30b9-283">このファイルには、次のような、ゲームを実行するために必要なすべてのゲーム ロジックが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-283">This file contains all the game logic needed to run the game, including:</span></span>

    * <span data-ttu-id="c30b9-284">新しいゲームを作成/開始します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-284">Creating/starting a new game.</span></span>
    * <span data-ttu-id="c30b9-285">サーバーに保存されているゲームを復元します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-285">Restoring a game stored on the server.</span></span>
    * <span data-ttu-id="c30b9-286">ユーザーの選択に基づいて、ゲーム ボードとカードを描画します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-286">Drawing the game board and cards based on user selection.</span></span>
    * <span data-ttu-id="c30b9-287">カードを反転します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-287">Flipping the cards.</span></span>

2. <span data-ttu-id="c30b9-288">script.js で、まず `newGame()` 関数を変更します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-288">In script.js, let's start by modifying the `newGame()` function.</span></span> <span data-ttu-id="c30b9-289">この関数は次の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-289">This function:</span></span>

    * <span data-ttu-id="c30b9-290">ユーザーからのゲームのサイズの選択を処理します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-290">Handles the size of the game selection from the user.</span></span>
    * <span data-ttu-id="c30b9-291">サーバーから [gameboard array](#part-i-build-a-rest-api-backend) をフェッチします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-291">Fetches the [gameboard array](#part-i-build-a-rest-api-backend) from the server.</span></span>
    * <span data-ttu-id="c30b9-292">`drawGameBoard()` 関数を呼び出し、画面にゲーム ボードを配置します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-292">Calls the `drawGameBoard()` function to place the game board to the screen.</span></span>

    <span data-ttu-id="c30b9-293">`newGame()` 内の `// Add code from Part 2.2 here` コメントの後に、次のコードを追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-293">Add the following code inside of `newGame()` after the `// Add code from Part 2.2 here` comment.</span></span>

    ``` javascript
    // extract game size selection from user
    var size = $("#selectGameSize").val();

    // parse game size value
    size = parseInt(size, 10);
    ```

    <span data-ttu-id="c30b9-294">このコードは、`id="selectGameSize"` (これは後で作成します) を使って、ドロップダウン メニューから値を取得し、それを変数 (`size`) に保存します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-294">This code retrieves the value from the dropdown menu with `id="selectGameSize"` (which we will create later) and stores it in a variable (`size`).</span></span>  <span data-ttu-id="c30b9-295">[`parseInt()`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/parseInt) 関数を使って、ドロップダウンからの文字列の値を解析して整数を返します。要求されたゲーム ボードの `size` をサーバーに渡します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-295">We use the [`parseInt()`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/parseInt) function to parse the string value from the dropdown to return an integer, so we can pass the `size` of the requested game board to the server.</span></span> 

    <span data-ttu-id="c30b9-296">このチュートリアルのパート 1 で作成した [`/new`](#part-i-build-a-rest-api-backend) メソッドを使って、選択されたゲーム ボードのサイズをサーバーに投稿します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-296">We use the [`/new`](#part-i-build-a-rest-api-backend) method created in Part I of this tutorial to post the chosen size of the game board to the server.</span></span> <span data-ttu-id="c30b9-297">このメソッドは、カードおよびカードが一致したかどうかを示す `true/false` 値を含む、単一の JSON 配列を返します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-297">The method returns a single JSON array of cards and `true/false` values indicating whether the cards have been matched.</span></span> 

3. <span data-ttu-id="c30b9-298">次に、`restoreGame()` 関数に入力します。この関数は最後にプレイされたゲームを復元します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-298">Next, fill in the `restoreGame()` function that restores the last game played.</span></span> <span data-ttu-id="c30b9-299">簡単のため、このアプリでは最後にプレイされたゲームを常に読み込みます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-299">For simplicity's sake, the app always loads the last game played.</span></span> <span data-ttu-id="c30b9-300">サーバーに保存されているゲームがない場合、ドロップ ダウン メニューを使用して新しいゲームを開始します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-300">If there is not a game stored on the server, use the drop-down menu to start a new game.</span></span> 

    <span data-ttu-id="c30b9-301">次のコードをコピーして `restoreGame()` に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-301">Copy and paste this code into `restoreGame()`.</span></span>

   ``` javascript 
   // reset the game
   gameBoardSize = 0;
   cardsFlipped = 0;

   // fetch the game state from the server 
   $.get("http://localhost:8000/game", function (response) {
       // store game board size
       gameBoardSize = response.length;

       // draw the game board
       drawGameBoard(response);
   });
   ```

    <span data-ttu-id="c30b9-302">ゲームで、サーバーからゲームの状態をフェッチできるようになります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-302">The game will now fetch the game state from the server.</span></span> <span data-ttu-id="c30b9-303">この手順で使用されている [`/game`](#part-i-build-a-rest-api-backend) メソッドの詳細については、このチュートリアルの第 I 部を参照してください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-303">For more information about the [`/game`](#part-i-build-a-rest-api-backend) method being used in this step, see Part I of this tutorial.</span></span> <span data-ttu-id="c30b9-304">Azure (または別のサービス) を使用してバックエンド API をホストしている場合、上記の *localhost* を実稼働 URL に置き換えます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-304">If you are using Azure (or another service) to host the backend API, replace the *localhost* address above with your production URL.</span></span>

4. <span data-ttu-id="c30b9-305">次に、`drawGameBoard()` 関数を作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-305">Now we want to create the `drawGameBoard()` function.</span></span>  <span data-ttu-id="c30b9-306">この関数は次の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-306">This function:</span></span>

    * <span data-ttu-id="c30b9-307">ゲームのサイズを検出し、特定の CSS スタイルを適用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-307">Detects the size of the game and applies specific CSS styles.</span></span>
    * <span data-ttu-id="c30b9-308">HTML でカードを生成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-308">Generates the cards in HTML.</span></span>
    * <span data-ttu-id="c30b9-309">カードをページに追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-309">Adds the cards to the page.</span></span>

    <span data-ttu-id="c30b9-310">次のコードをコピーして、\*scripts.js \* の `drawGameBoard()` 関数に貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-310">Copy and paste this code into the `drawGameBoard()` function in *scripts.js*:</span></span>

    ``` javascript
    // create output
    var output = "";
    // detect board size CSS class
    var css = "";
    switch (board.length / 4) {
        case 1:
            css = "rows1";
            break;
        case 2:
            css = "rows2";
            break;
        case 3:
            css = "rows3";
            break;
        case 4:
            css = "rows4";
            break;   
    }
    // generate HTML for each card and append to the output
    for (var i = 0; i < board.length; i++) {
        if (board[i].cleared == "true") {
            // if the card has been cleared apply the .flip class
            output += "<div class=\"flipContainer col-xs-3 " + css + "\"><div class=\"cards flip matched\" id=\"" + i + "\" onClick=\"flipCard(this)\">\
                <div class=\"front\"><span class=\"glyphicon glyphicon-question-sign\"></span></div>\
                <div class=\"back\">" + lookUpGlyphicon(board[i].value) + "</div>\
                </div></div>";
        } else {
            output += "<div class=\"flipContainer col-xs-3 " + css + "\"><div class=\"cards\" id=\"" + i + "\" onClick=\"flipCard(this)\">\
                <div class=\"front\"><span class=\"glyphicon glyphicon-question-sign\"></span></div>\
                <div class=\"back\"></div>\
                </div></div>";
        }
    }
    // place the output on the page
    $("#game-board").html(output);
    ```

5. <span data-ttu-id="c30b9-311">次に、`flipCard()` 関数を完成させます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-311">Next, we need to complete the `flipCard()` function.</span></span>  <span data-ttu-id="c30b9-312">この関数では、チュートリアルのパート 1 で開発した [`/guess`](#part-i-build-a-rest-api-backend) メソッドを使って、選んだカードの値をサーバーから取得するなど、ゲーム ロジックの大部分の処理を行います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-312">This function handles the majority of the game logic, including getting the values of the selected cards from the server by using the [`/guess`](#part-i-build-a-rest-api-backend) method developed in Part I of the tutorial.</span></span> <span data-ttu-id="c30b9-313">REST API バックエンドをクラウドでホスティングしている場合には、*localhost* アドレスを運用 URL に忘れずに置換します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-313">Don't forget to replace the *localhost* address with your production URL if you are cloud hosting the REST API backend.</span></span>

    <span data-ttu-id="c30b9-314">`flipCard()` 関数で、次のコードのコメントを解除します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-314">In the `flipCard()` function, uncomment this code:</span></span>

    ``` javascript
    // post this guess to the server and get this card's value
    $.ajax({
        url: "http://localhost:8000/guess?card=" + selectedCards[0],
        type: 'PUT',
        success: function (response) {
            // display first card value
            $("#" + selectedCards[0] + " .back").html(lookUpGlyphicon(response[0].value));

            // store the first card value
            selectedCardsValues.push(response[0].value);
        }
    });
    ```

> [!TIP] 
> <span data-ttu-id="c30b9-315">Visual Studio Code を使っている場合は、コメントを解除するコードのすべての行を選択して、Crtl + K、U キーの順に押します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-315">If you're using Visual Studio Code, select all the lines of code you wish to uncomment, and press Crtl + K, U</span></span>

<span data-ttu-id="c30b9-316">次に、[`jQuery.ajax()`](http://api.jquery.com/jQuery.ajax/) と、パート 1 で作成した **PUT** [`/guess`](#part-i-build-a-rest-api-backend) メソッドを使用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-316">Here we use [`jQuery.ajax()`](http://api.jquery.com/jQuery.ajax/) and the **PUT** [`/guess`](#part-i-build-a-rest-api-backend) method created in Part I.</span></span> 

<span data-ttu-id="c30b9-317">このコードは、次の順序で実行されます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-317">This code executes in the following order.</span></span>

* <span data-ttu-id="c30b9-318">ユーザーが選択した最初のカードの `id` が、selectedCards[] 配列の最初の値として追加されます": </span><span class="sxs-lookup"><span data-stu-id="c30b9-318">The `id` of the first card the user selected is added as the first value to the selectedCards[] array:</span></span> `selectedCards[0]` 
* <span data-ttu-id="c30b9-319">`selectedCards[0]` の値 (`id`) が [`/guess`](#part-i-build-a-rest-api-backend) メソッドを使ってサーバーに投稿されます</span><span class="sxs-lookup"><span data-stu-id="c30b9-319">The value (`id`) in `selectedCards[0]` is posted to the server using the [`/guess`](#part-i-build-a-rest-api-backend) method</span></span>
* <span data-ttu-id="c30b9-320">サーバーが、そのカードの `value` (整数) を応答します</span><span class="sxs-lookup"><span data-stu-id="c30b9-320">The server responds with the `value` of that card (an integer)</span></span>
* <span data-ttu-id="c30b9-321">`id` が次の値であるカードの裏に [Bootstrap glyphicon](http://getbootstrap.com/components/) が追加されます: </span><span class="sxs-lookup"><span data-stu-id="c30b9-321">A [Bootstrap glyphicon](http://getbootstrap.com/components/) is added to the back of the card whose `id` is</span></span> `selectedCards[0]`
* <span data-ttu-id="c30b9-322">(サーバーからの) 最初のカードの `value` が `selectedCardsValues[]` 配列: `selectedCardsValues[0]` に保存されます</span><span class="sxs-lookup"><span data-stu-id="c30b9-322">The first card's `value` (from the server) is stored in the `selectedCardsValues[]` array: `selectedCardsValues[0]`.</span></span> 

<span data-ttu-id="c30b9-323">ユーザーの 2 回目の推測も同じロジックに従います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-323">The user's second guess follows the same logic.</span></span> <span data-ttu-id="c30b9-324">ユーザーが選択したカードが同じ ID である場合 (たとえば `selectedCards[0] == selectedCards[1]`)、カードは一致します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-324">If the cards that the user selected have the same IDs, (for example, `selectedCards[0] == selectedCards[1]`), the cards are a match!</span></span> <span data-ttu-id="c30b9-325">一致したペアには CSS クラス `.matched` が追加され (緑色に変わり)、カードは反転されたまま残ります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-325">The CSS class `.matched` is added to the matched cards (turning them green) and the cards remained flipped.</span></span>

<span data-ttu-id="c30b9-326">ここで、すべてのカードが一致し、ゲームが終了したかどうかを確認するロジックを追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-326">Now we need to add logic to check whether the user matched all of the cards and won the game.</span></span> <span data-ttu-id="c30b9-327">`flipCard()` 関数の中で `//check if the user won the game` コメントの下に、次の行を追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-327">Inside of the `flipCard()` function, add the following lines of code under the `//check if the user won the game` comment.</span></span> 

``` javascript
if (cardsFlipped == gameBoardSize) {
    setTimeout(function () {
        output = "<div id=\"playAgain\"><p>You Win!</p><input type=\"button\" onClick=\"location.reload()\" value=\"Play Again\" class=\"btn\" /></div>";
        $("#game-board").html(output);
    }, 1000);
}   
```

<span data-ttu-id="c30b9-328">反転して一致したカードの数が、ゲーム ボードのサイズと等しい場合 (たとえば、`cardsFlipped == gameBoardSize`)、それ以上反転できるカードはなく、ゲームは終了です。</span><span class="sxs-lookup"><span data-stu-id="c30b9-328">If the number of cards flipped matches the size of the game board (for example, `cardsFlipped == gameBoardSize`), there are no more cards to flip and the user has won the game.</span></span> <span data-ttu-id="c30b9-329">`div` に `id="game-board"` を使って簡単な HTML を追加して、ユーザーにゲームが終了したことと、もう一度プレイできることを伝えます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-329">We'll add some simple HTML to the `div` with `id="game-board"` to let the user know they won and can play again.</span></span>  

### <a name="3-create-the-user-interface"></a><span data-ttu-id="c30b9-330">3. ユーザー インターフェイスを作成する</span><span class="sxs-lookup"><span data-stu-id="c30b9-330">3. Create the user interface</span></span> 
<span data-ttu-id="c30b9-331">次に、すべてのコードを確認して、ユーザー インターフェイスを作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-331">Now let's see all this code in action by creating the user interface.</span></span> <span data-ttu-id="c30b9-332">このチュートリアルでは、テンプレート エンジン [Pug](https://pugjs.org/) (旧 Jade) を使用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-332">In this tutorial, we use the templating engine [Pug](https://pugjs.org/) (formally Jade).</span></span>  <span data-ttu-id="c30b9-333">*Pug* では HTML の記述時に、空白が意味を持つ、クリーンな構文を使います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-333">*Pug* is clean, whitespace-sensitive syntax for writing HTML.</span></span> <span data-ttu-id="c30b9-334">次に例を示します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-334">Here's an example.</span></span> 

```
body
    h1 Memory Game
    #container
        p We love tutorials!
```

<span data-ttu-id="c30b9-335">上記は以下のようになります。</span><span class="sxs-lookup"><span data-stu-id="c30b9-335">becomes</span></span>

``` html
<body>
    <h1>Memory Game</h1>
    <div id="container">
        <p>We love tutorials!</p>
    </div>
</body>
```


1. <span data-ttu-id="c30b9-336">memory\views の layout.pug ファイルを、提供された Start フォルダーの layout.pug ファイルで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-336">Replace the layout.pug file in memory\views with the provided layout.pug file in the Start folder.</span></span> <span data-ttu-id="c30b9-337">layout.pug の中には、次へのリンクが含まれています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-337">Inside of layout.pug, you'll see links to:</span></span>

    * <span data-ttu-id="c30b9-338">Bootstrap</span><span class="sxs-lookup"><span data-stu-id="c30b9-338">Bootstrap</span></span>
    * <span data-ttu-id="c30b9-339">jQuery</span><span class="sxs-lookup"><span data-stu-id="c30b9-339">jQuery</span></span>
    * <span data-ttu-id="c30b9-340">カスタム CSS ファイル</span><span class="sxs-lookup"><span data-stu-id="c30b9-340">A custom CSS file</span></span>
    * <span data-ttu-id="c30b9-341">変更が完了した JavaScript ファイル</span><span class="sxs-lookup"><span data-stu-id="c30b9-341">The JavaScript file we just finished modifying</span></span>

2. <span data-ttu-id="c30b9-342">memory\views ディレクトリで index.pug という名前のファイルを開きます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-342">Open the file named index.pug in the directory memory\views.</span></span>
<span data-ttu-id="c30b9-343">このファイルは、layout.pug ファイルを拡張し、ゲームのレンダリングを行います。</span><span class="sxs-lookup"><span data-stu-id="c30b9-343">This file extends the layout.pug file and will render our game.</span></span> <span data-ttu-id="c30b9-344">layout.pug の中に、次のコードを貼り付けます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-344">Inside of layout.pug, paste the following lines of code:</span></span>

    ```
    extends layout
    block content  
        div
            form(method="GET")
            select(id="selectGameSize" class="form-control" onchange="newGame()")
                option(value="0") New Game
                option(value="2") 2 Matches
                option(value="4") 4 Matches
                option(value="6") 6 Matches
                option(value="8") 8 Matches         
            #game-board
                script restoreGame();
    ```

> [!TIP] 
> <span data-ttu-id="c30b9-345">Pug では空白が意味を持つことに注意してください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-345">Remember: Pug is whitespace sensitive.</span></span> <span data-ttu-id="c30b9-346">すべてのインデントが正しいことを確認します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-346">Make sure all of your indentations are correct!</span></span>

### <a name="4-use-bootstraps-grid-system-to-create-a-responsive-layout"></a><span data-ttu-id="c30b9-347">4. Bootstrap のグリッドのシステムを使ってレスポンシブ レイアウトを作成する</span><span class="sxs-lookup"><span data-stu-id="c30b9-347">4. Use Bootstrap's grid system to create a responsive layout</span></span>
<span data-ttu-id="c30b9-348">Bootstrap の[グリッド システム](http://getbootstrap.com/css/#grid)は、デバイスのビューポートの変化にしたがって拡大縮小する、柔軟なグリッド システムです。</span><span class="sxs-lookup"><span data-stu-id="c30b9-348">Bootstrap's [grid system](http://getbootstrap.com/css/#grid) is a fluid grid system that scales a grid as a device's viewport changes.</span></span> <span data-ttu-id="c30b9-349">このゲームのカードは、次のような Bootstrap の定義済みのグリッド システム クラスをレイアウトに使用しています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-349">The cards in this game use Bootstrap's predefined grid system classes for the layout, including:</span></span>
* `.container-fluid`<span data-ttu-id="c30b9-350">柔軟なグリッド コンテナーを指定します</span><span class="sxs-lookup"><span data-stu-id="c30b9-350">: specifies the fluid container for the grid</span></span>
* `.row-fluid`<span data-ttu-id="c30b9-351">: 柔軟な行を指定します</span><span class="sxs-lookup"><span data-stu-id="c30b9-351">: specifies the fluid rows</span></span>
* `.col-xs-3`<span data-ttu-id="c30b9-352">: 列数を指定します</span><span class="sxs-lookup"><span data-stu-id="c30b9-352">: specifies the number of columns</span></span>

<span data-ttu-id="c30b9-353">Bootstrap のグリッド システムを使うと、モバイル デバイスのナビゲーション メニューに表示されるように、グリッド システムを 1 つの垂直列に折りたたむことができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-353">Bootstrap's grid system allows a grid system to collapse into one vertical column, like you would see on a navigation menu on a mobile device.</span></span>  <span data-ttu-id="c30b9-354">しかし、このゲームでは常に列を保持するため、定義済みのクラス `.col-xs-3` を使い、常に横方向のグリッドを保持するようにします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-354">However, because we want our game always to have columns, we use the predefined class `.col-xs-3`, which keeps the grid horizontal at all times.</span></span> 

<span data-ttu-id="c30b9-355">このグリッド システムでは最大 12 列が可能です。</span><span class="sxs-lookup"><span data-stu-id="c30b9-355">The grid system allows up to 12 columns.</span></span> <span data-ttu-id="c30b9-356">このゲームでは 4 列のみを使用するため、`.col-xs-3` クラスを使用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-356">Since we only want 4 columns in our game, we use the class `.col-xs-3`.</span></span> <span data-ttu-id="c30b9-357">このクラスは、前述の利用可能な 12 列のうちの 3 列の幅にわたる、各列を必要とすることを指定します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-357">This class specifies that we need each of our columns to span the width of 3 of the 12 available columns mentioned before.</span></span> <span data-ttu-id="c30b9-358">次の図は、このゲームで使われている、12 列のグリッドと 4 列のグリッドを示します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-358">This image shows a 12-column grid and a 4-column grid, like the one used in this game.</span></span>

![Bootstrap の 12 列と 4 列のグリッド](./images/grid.png)

1. <span data-ttu-id="c30b9-360">scripts.js を開き、`drawGameBoard()` 関数を見つけます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-360">Open scripts.js and find the `drawGameBoard()` function.</span></span>  <span data-ttu-id="c30b9-361">各カードの HTML を生成したコード ブロックで、`class="col-xs-3"` を持つ `div` 要素を見つけます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-361">In the block of code where we generate the HTML for each card, can you spot the `div` element with `class="col-xs-3"`?</span></span> 

2. <span data-ttu-id="c30b9-362">index.pug の中に、先述の定義済みの Bootstrap のクラスを追加して、柔軟なレイアウトを作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-362">Inside of index.pug, let's add the predefined Bootstrap classes mentioned previously to create our fluid layout.</span></span>  <span data-ttu-id="c30b9-363">index.pug を次のように変更します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-363">Change index.pug to the following.</span></span>

    ```
    extends layout

    block content   

        .container-fluid
            form(method="GET")
            select(id="selectGameSize" class="form-control" onchange="newGame()")
                option(value="0") New Game
                option(value="2") 2 Matches
                option(value="4") 4 Matches
                option(value="6") 6 Matches
                option(value="8") 8 Matches         
            #game-board.row-fluid 
                script restoreGame();
    ```

### <a name="5-add-a-card-flip-animation-with-css-transforms"></a><span data-ttu-id="c30b9-364">5. CSS 変換を使ってカードの反転のアニメーションを追加する</span><span class="sxs-lookup"><span data-stu-id="c30b9-364">5. Add a card-flip animation with CSS Transforms</span></span>
<span data-ttu-id="c30b9-365">memory\public\stylesheets の style.css ファイルを、Start フォルダーの style.css ファイルで置き換えます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-365">Replace the style.css file in memory\public\stylesheets with the style.css file from the Start folder.</span></span>

<span data-ttu-id="c30b9-366">[CSS 変換](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide/css/transforms)を使って、反転モーションを追加し、カードにリアルな 3D の反転モーションを追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-366">Adding a flip motion using [CSS Transforms](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide/css/transforms) gives the cards a realistic, 3D flipping motion.</span></span> <span data-ttu-id="c30b9-367">ゲームのカードは次の HTML 構造を使用して作成され、(先述の `drawGameBoard()`関数により) プログラムによってゲーム ボードに追加されています。</span><span class="sxs-lookup"><span data-stu-id="c30b9-367">The cards in the game are created by using the following HTML structure and programmatically added to the game board (in the `drawGameBoard()` function shown previously).</span></span>

``` html
<div class="flipContainer">
    <div class="cards">
        <div class="front"></div>
        <div class="back"></div>
    </div>
</div>
```

1. <span data-ttu-id="c30b9-368">まず、アニメーションの親コンテナーに[視点](https://developer.mozilla.org/en-US/docs/Web/CSS/transform)を与えます (`.flipContainer`)。</span><span class="sxs-lookup"><span data-stu-id="c30b9-368">To start, give [perspective](https://developer.mozilla.org/en-US/docs/Web/CSS/transform) to the parent container of the animation (`.flipContainer`).</span></span>  <span data-ttu-id="c30b9-369">これにより、子要素に深度の錯視が加わります。値が大きいほど、要素はユーザーがから離れて見えます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-369">This gives the illusion of depth for its child elements: the higher the value, the farther away from the user the element will appear.</span></span> <span data-ttu-id="c30b9-370">style.css の `.flipContainer` クラスに、次の視点を追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-370">Let's add the following perspective to the `.flipContainer` class in style.css.</span></span>

    ``` css
    perspective: 1000px; 
    ```

2. <span data-ttu-id="c30b9-371">次に、style.css の `.cards` クラスに以下のプロパティを追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-371">Now add the following properties to the `.cards` class in style.css.</span></span> <span data-ttu-id="c30b9-372">`.cards``div` は、カードの表または裏を示して、実際に反転アニメーションを行う要素です。</span><span class="sxs-lookup"><span data-stu-id="c30b9-372">The `.cards` `div` is the element that will actually be doing the flipping animation, showing either the front or the back of the card.</span></span> 

    ``` css
    transform-style: preserve-3d;
    transition-duration: 1s;
    ```

    <span data-ttu-id="c30b9-373">[`transform-style`](https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style) プロパティは 3D レンダリングのコンテキストを確立します。`.cards` クラスの子 (`.front` および `.back`) は 3D 空間のメンバーです。</span><span class="sxs-lookup"><span data-stu-id="c30b9-373">The [`transform-style`](https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style) property establishes a 3D-rendering context, and the children of the `.cards` class (`.front` and `.back` are members of the 3D space.</span></span> <span data-ttu-id="c30b9-374">[`transition-duration`](https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duration) プロパティを追加して、アニメーションを完了する時間を秒数で指定します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-374">Adding the [`transition-duration`](https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duration) property specifies the number of seconds for the animation to finish.</span></span> 

3.  <span data-ttu-id="c30b9-375">[`transform`](https://developer.mozilla.org/en-US/docs/Web/CSS/transform) プロパティを使って、カードを Y 軸周りで回転させることができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-375">Using the [`transform`](https://developer.mozilla.org/en-US/docs/Web/CSS/transform) property, we can rotate the card around the Y-axis.</span></span>  <span data-ttu-id="c30b9-376">次の CSS を `cards.flip` に追加します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-376">Add the following CSS to `cards.flip`.</span></span>

    ``` css
    transform: rotateY(180deg);
    ```

    <span data-ttu-id="c30b9-377">`cards.flip` で定義されたスタイルは、`flipCard` 関数で [`.toggleClass()`](http://api.jquery.com/toggleClass/) を使って、オンとオフを切り替えることができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-377">The style defined in `cards.flip` is toggled on and off in the `flipCard` function by using [`.toggleClass()`](http://api.jquery.com/toggleClass/).</span></span> 

    ``` javascript
    $(card).toggleClass("flip");
    ```

    <span data-ttu-id="c30b9-378">これにより、ユーザーがカードをクリックすると、カードは 180° 回転します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-378">Now when a user clicks on a card, the card is rotated 180 degrees.</span></span>

### <a name="6-test-and-play"></a><span data-ttu-id="c30b9-379">6. テストしてプレイする</span><span class="sxs-lookup"><span data-stu-id="c30b9-379">6. Test and play</span></span>
<span data-ttu-id="c30b9-380">いよいよ完成です。</span><span class="sxs-lookup"><span data-stu-id="c30b9-380">Congratulations!</span></span> <span data-ttu-id="c30b9-381">Web アプリの作成が完了しました。</span><span class="sxs-lookup"><span data-stu-id="c30b9-381">You've finished creating the web app!</span></span> <span data-ttu-id="c30b9-382">ではテストを行いましょう。</span><span class="sxs-lookup"><span data-stu-id="c30b9-382">Let's test it.</span></span> 

1. <span data-ttu-id="c30b9-383">memory ディレクトリでコマンド プロンプトを開き、次のコマンドを入力します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-383">Open a command prompt in your memory directory and enter the following command:</span></span> `npm start`

2. <span data-ttu-id="c30b9-384">ブラウザーで [http://localhost:3000/](http://localhost:3000/) に移動して、ゲームをプレイします。</span><span class="sxs-lookup"><span data-stu-id="c30b9-384">In your browser, go to [http://localhost:3000/](http://localhost:3000/) and play a game!</span></span>

3. <span data-ttu-id="c30b9-385">エラーが発生した場合は、キーボードで F5 キーを押して、`Node.js` と入力すると、Visual Studio Code の Node.js デバッグ ツールを使用できます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-385">If you encounter any errors, you can use Visual Studio Code's Node.js debugging tools by pressing F5 on your keyboard and typing `Node.js`.</span></span> <span data-ttu-id="c30b9-386">Visual Studio Code でのデバッグについて詳しくは、この[記事](http://code.visualstudio.com/docs/editor/debugging#_launch-configurations)をご覧ください。</span><span class="sxs-lookup"><span data-stu-id="c30b9-386">For more information about debugging in Visual Studio Code, check out this [article](http://code.visualstudio.com/docs/editor/debugging#_launch-configurations).</span></span> 

    <span data-ttu-id="c30b9-387">コードを Final フォルダーに含まれているコードと比較することもできます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-387">You can also compare your code to the code provided in the Final folder.</span></span>

4. <span data-ttu-id="c30b9-388">ゲームを停止するには、コマンド プロンプトで、**Ctrl + C**、**Y** の順に入力します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-388">To stop the game, in the command prompt type: **Ctrl + C**, **Y**.</span></span> 

### <a name="going-further"></a><span data-ttu-id="c30b9-389">追加情報</span><span class="sxs-lookup"><span data-stu-id="c30b9-389">Going further</span></span>

<span data-ttu-id="c30b9-390">これで、作成したアプリを Azure (またはその他のクラウド ホスティング サービス) にデプロイして、モバイル、タブレット、デスクトップなどの、さまざまなフォーム ファクターのデバイスにわたってテストを行う準備ができました。</span><span class="sxs-lookup"><span data-stu-id="c30b9-390">You can now deploy your app to Azure (or any other cloud hosting service) for testing across different device form factors, such as mobile, tablet, and desktop.</span></span> <span data-ttu-id="c30b9-391">(さまざまなブラウザーでも忘れずにテストを行ってください) 実稼働のための準備ができたら、*ユニバーサル Windows プラットフォーム* (UWP) のための*ホストされた Web アプリ* (HWA) として、容易にパッケージ化し、Microsoft Store から配布することができます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-391">(Don't forgot to test across different browsers too!) Once your app is ready for production, you can easily package it as a *Hosted Web App* (HWA) for the *Universal Windows Platform* (UWP) and distribute it from the Microsoft Store.</span></span>

<span data-ttu-id="c30b9-392">Microsoft Store に公開するための基本的な手順は次のとおりです。</span><span class="sxs-lookup"><span data-stu-id="c30b9-392">The basic steps for publishing to the Microsoft Store are:</span></span>

 1. <span data-ttu-id="c30b9-393">[Windows 開発者](https://developer.microsoft.com/en-us/store/register)アカウントを作成します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-393">Create a [Windows Developer](https://developer.microsoft.com/en-us/store/register) account</span></span>
 2. <span data-ttu-id="c30b9-394">アプリの申請の[チェックリスト](https://docs.microsoft.com/en-us/windows/uwp/publish/app-submissions)を使用します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-394">Use the app submission [checklist](https://docs.microsoft.com/en-us/windows/uwp/publish/app-submissions)</span></span>
 3. <span data-ttu-id="c30b9-395">アプリを申請して[認定](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)を受けます。</span><span class="sxs-lookup"><span data-stu-id="c30b9-395">Submit your app for [certification](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)</span></span>

<span data-ttu-id="c30b9-396">そのために役立つ追加情報を次に示します。</span><span class="sxs-lookup"><span data-stu-id="c30b9-396">Here are some useful resources for going further:</span></span>

 - [<span data-ttu-id="c30b9-397">アプリケーション開発プロジェクトを Azure Websites にデプロイする</span><span class="sxs-lookup"><span data-stu-id="c30b9-397">Deploy your application development project to Azure Websites</span></span>](https://docs.microsoft.com/azure/cosmos-db/documentdb-nodejs-application#_Toc395783182)

 - [<span data-ttu-id="c30b9-398">Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換する</span><span class="sxs-lookup"><span data-stu-id="c30b9-398">Convert your web application to a Universal Windows Platform (UWP) app</span></span>](https://docs.microsoft.com/en-us/windows/uwp/porting/hwa-create-windows)

 - [<span data-ttu-id="c30b9-399">Windows アプリを公開する</span><span class="sxs-lookup"><span data-stu-id="c30b9-399">Publish Windows apps</span></span>](https://developer.microsoft.com/en-us/store/publish-apps)
