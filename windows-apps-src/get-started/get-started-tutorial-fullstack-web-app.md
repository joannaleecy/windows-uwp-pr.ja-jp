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
# <a name="create-a-single-page-web-app-with-rest-api-backend"></a>REST API のバックエンドを使った単一ページの Web アプリを作成する

**よく使われるフルスタックの Web テクノロジを使用して Microsoft Store 用のホストされた Web アプリを構築する**

![単一ページの Web アプリである、簡単なメモリ ゲーム](images/fullstack.png)

2 つの部分から構成されるこのチュートリアルでは、モダンなフルスタックの Web 開発を簡単に紹介します。このチュートリアルでは、ブラウザーでも、Microsoft Store 用のホストされた Web アプリとしても動作する、簡単なメモリ ゲームを構築します。 パート 1 では、ゲームのバックエンドのためのシンプルな REST API サービスを構築します。 ゲーム ロジックをクラウドで API サービスとしてホストすることにより、ゲームの状態を保持することができ、ユーザーは異なるデバイスにわたって、ゲームの同じインスタンスのプレイを続けることができます。 パート 2 では、レスポンシブ レイアウトを使った単一ページの Web アプリとして、フロント エンド UI を構築します。

ここでは、サーバー側の開発のための [Node.js](https://nodejs.org/en/) ランタイムや [Express](http://expressjs.com/)、[Bootstrap](http://getbootstrap.com/) UI フレームワーク、RESTful API 構築のための [Pug](https://www.npmjs.com/package/pug) テンプレート エンジンや [Swagger](http://swagger.io/tools/) などの、よく使われる Web テクノロジを使用します。 さらに、クラウド ホスティングのための [Azure Portal](https://ms.portal.azure.com/) や、[Visual Studio Code](https://code.visualstudio.com/) エディターの操作についても扱います。

## <a name="prerequisites"></a>前提条件

コンピューター上に次のようなリソースがない場合には、リンクを使ってダウンロードしてください。

 - [Node.js](https://nodejs.org/en/download/) - Node を PATH に追加するオプションを必ず選択してください。

 - [Express ジェネレーター](http://expressjs.com/en/starter/generator.html)- Node のインストール後に、次のコマンドを実行して Express をインストールします。 `npm install express-generator -g`

 - [Visual Studio Code](https://code.visualstudio.com/)

最後のステップを完了して、API サービスとメモリ ゲーム アプリを Microsoft Azure でホスティングする場合には、[無料の Azure アカウントを作成](https://azure.microsoft.com/en-us/free/)する必要があります (既に作成していない場合)。

Azure の部分を行わない (または後で行う) 場合には、Azure のホスティングと、Microsoft Store 用のアプリのパッケージングについて説明している、パート 1 の最後のセクションとパート 2 を省略してください。 その場合には、構築した API サービスと Webアプリをローカル コンピューター上で実行できます (それぞれ `http://localhost:8000`、`http://localhost:3000` から実行できます)。

## <a name="part-i-build-a-rest-api-backend"></a>パート 1: REST API バックエンドの構築

最初に、簡単なメモリ ゲームの Web アプリを実現するための、メモリ ゲームの API を構築します。 [Swagger](http://swagger.io/) を使って API を定義し、手動テストのためのスキャフォールディング コードと Web UI を生成します。

このパートを省略して、[パート 2: 単一ページの Web アプリを構築する](#part-ii-build-a-single-page-web-appl)に直接進む場合には、[パート 1 の完成コード](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/backend)を利用できます。*README* の指示に沿って、ローカルでコードを実行するか、または *5. API サービスを Azure でホストして CORS を有効化する*を参照して Azure で実行します。

### <a name="game-overview"></a>ゲームの概要

*メモリ* ([*神経衰弱*](https://en.wikipedia.org/wiki/Concentration_(game))や[*ペルマニズム*](https://en.wikipedia.org/wiki/Pelmanism_(system))とも呼ばれます) は、トランプのカードのペアを使った、簡単なゲームです。 カードはテーブル上に裏向きで配置され、プレイヤーは一度に 2 枚のカードを開いて、一致しているかどうかを確認します。 一致するペアが見つかったら、その 2 枚のカードはゲームからクリアされます。それ以外の場合には、2 枚とも裏向きに戻します。 ゲームの目的は、できるだけ少ない回数で、すべてのカードのペアを見つけることです。

ここでは説明用のため、ゲームの構造を非常にシンプルにし、ゲームは 1 回のみで、1 人のプレイヤーとしています。 ただし、ゲーム ロジックを (クライアントでなく) サーバー側に配置し、ゲームの状態を保存できるようにします。これによって、異なるデバイスにわたって、同じゲームのプレイを続けることができます。

メモリ ゲームのデータ構造は、JavaScript オブジェクトの配列のみで構成されます。それぞれが 1 つのカードを表し、配列内のインデックスを持ち、これがカード ID として機能します。 サーバー上では、各カード オブジェクトが 1 つの値と **cleared** フラグを持ちます。 たとえば、2 組のペア (4 枚のカード) から成るゲーム ボードは、ランダムに生成されて、次のようにシリアル化されます。

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

ボードの配列がクライアントに渡されると、不正を防ぐために (たとえば、ブラウザーの F12 ツールを使って、HTTP 応答の本文を検査するなど)、value キーを配列から削除します。 **GET /game** REST エンドポイントを呼び出すクライアントに対して、新しい同じゲームは次のようになります。

```json
[{ "cleared":"false"},{ "cleared":"false"},{ "cleared":"false"},{ "cleared":"false"}]
```

エンドポイントについては、メモリ ゲーム サービスは、次の 3 つの REST API で構成されます。

#### <a name="post-new"></a>POST /new
指定されたサイズで (数字はペアの数を表します) 新しいゲーム ボードを初期化します。

| パラメーター | 説明 |
|-----------|-------------|
| int *size* |ゲーム ボードに含まれる、一致するペアの数。 例:  `http://memorygameapisample/new?size=2`|

| 応答 | 説明 |
|----------|-------------|
| 200 OK | 要求されたサイズの新しいメモリ ゲームの準備ができました。|
| 400 BAD REQUEST| 要求されたサイズは、許容範囲外です。|


#### <a name="get-game"></a>GET /game
メモリ ゲーム ボードの現在の状態を取得します。

*パラメーター: なし*

| 応答 | 説明 |
|----------|-------------|
| 200 OK | カード オブジェクトの JSON 配列を返します。 各カードには、ペアが既に見つかったことを示す、**cleared** プロパティがあります。 一致したカードは、その **value** も報告します。 例:  `[{"cleared":"false"},{"cleared":"false"},{"cleared":"true","value":1},{"cleared":"true","value":1}]`|

#### <a name="put-guess"></a>PUT /guess
表向きにするカードを指定し、前に表向きにしたカードとの一致を確認します。

| パラメーター | 説明 |
|-----------|-------------|
| int *card* | 表向きにするカードのカード ID (ゲーム ボード配列内のインデックス)。 完了した各「推測」は、指定された 2 枚のカード (つまり、有効で一意の *card* 値 を持つ、2 つの **/guess** の呼び出し) で構成されます。 例:  `http://memorygameapisample/guess?card=0`|

| 応答 | 説明 |
|----------|-------------|
| 200 OK | 指定されたカードの **id** と **value** を持つ JSON を返します。 例:  `[{"id":0,"value":1}]`|
| 400 BAD REQUEST |  指定されたカードでエラーが発生しました。 詳細は HTTP 応答の本文を参照してください。|

### <a name="1-spec-out-the-api-and-generate-code-stubs"></a>1. API を指定して、コード スタブを生成する

[Swagger](http://swagger.io/) を使って、メモリ ゲームの API の設計を、動作する Node.js サーバー コードに変換します。 次のようにして、[メモリ ゲーム API を Swagger メタデータとして](https://github.com/Microsoft/Windows-tutorials-web/blob/master/Single-Page-App-with-REST-API/backend/api.json)定義できます。 これを使って、サーバー コードのスタブを生成します。

1. 新しいフォルダー (たとえば、ローカルの *GitHub* ディレクトリ) を作成し、メモリ ゲーム API 定義を含む [**api.json**](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/api.json?token=ACEfklXAHTeLkHYaI5plV20QCGuqC31cks5ZFhVIwA%3D%3D) ファイルをダウンロードします。 フォルダー名にスペースが含まれていないことを確認します。

2. このフォルダーで好みのシェル ([または Visual Studio Code の統合ターミナル](https://code.visualstudio.com/docs/editor/integrated-terminal)) を開き、次の Node Package Manager (NPM) コマンドを実行して、[Yeoman](http://yeoman.io/) (yo) コード スキャフォールディング ツールおよび Swagger ジェネレーターをグローバル (**-g**) Node 環境にインストールします。

    ```
    npm install -g yo
    npm install -g generator-swaggerize
    ```

3. Swagger を使用して、サーバー スキャフォールディング コードを生成します。

    ```
    yo swaggerize
    ```

4. **Swaggerize** コマンドの質問のメッセージに応答します。
    - Swagger ドキュメントへのパス (またはURL): **api.json**
    - フレームワーク: **express**
    - プロジェクト名 (YourFolderNameHere): **[Enter]**

    他は適宜に応答します。これらの情報の多くは *package.json* ファイルに連絡先情報を指定するために使用され、作成したコードを NPM パッケージとして配布できます。

5. 最後に、新しいプロジェクトのすべての依存関係 (*package.json* に一覧表示されています) および [Swagger UI](http://swagger.io/swagger-ui/) サポートをインストールします。

    ```
    npm install
    npm install swaggerize-ui
    ```

    VS Code を開始し、[**ファイル**]  >  [**フォルダーを開く**] と選び、MemoryGameAPI ディレクトリに移動します。 これは、先ほど作成した Node.js API サーバーです。 これは、よく使われる [ExpressJS](http://expressjs.com/en/4x/api.html) Web アプリケーション フレームワークを使って、プロジェクトを構造化して実行します。

### <a name="2-customize-the-server-code-and-setup-debugging"></a>2. サーバー コードのカスタマイズとデバッグのセットアップ

プロジェクト ルートの *server.js* ファイルが、サーバーの「メイン」の機能を果たします。 そのファイルを VS Code で開き、そこに次のコードをコピーします。 生成されたコードを変更した行には、詳しい説明のコメントが入っています。

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

これでサーバーを実行する準備ができました。 Visual Studio Code で、Node のデバックを行うように設定します。 **デバッグ** パネル アイコン (Ctrl+Shift+D) を選び、次に歯車アイコンを選んで (launch.json を開く)、"configurations" を次のように変更します。

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

F5 キーを押してブラウザーを開き、[http://localhost:8000](http://localhost:8000) に移動します。 メモリ ゲーム API の Swagger UI のページが開きます。詳細を展開して、各メソッドのフィールドを入力します。 API の呼び出しを試すこともできますが、応答には ([Swagmock](https://www.npmjs.com/package/swagmock) モジュールが提供する) モックアップ データのみが含まれています。 次に、API が実際に動作するように、ゲーム ロジックを追加します。

### <a name="3-set-up-your-route-handlers"></a>3. ルート ハンドラーを設定する

Swagger ファイル (config\swagger.json) では、定義されている各 URL パスを (\handlers にある) ハンドラー ファイルにマッピングし、さらにそのパスに定義された各メソッド (**GET**、**POST** など) をハンドラー ファイル内の `operationId` (機能) にマッピングして、サーバーに対して、さまざまなクライアントの HTTP 要求を処理する方法を指示します。

プログラムのこのレイヤーには、さまざまなクライアント要求をデータ モデルに渡す前に、いくつかの入力チェックを追加します。 次をダウンロード (またはコピーして貼り付け) して利用できます。

 - この [game.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/game.js?token=ACEfkvhw6BUnkeSsZgnzVe086T5WLwjfks5ZFhW5wA%3D%3D) コードを **handlers\game.js** ファイルに使います
 - この [guess.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/guess.js?token=ACEfkswel02rHVr0e61bVsNdpv_i1Rtuks5ZFhXPwA%3D%3D) コードを **handlers\guess.js** ファイルに使います
 - この [new.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/handlers/new.js?token=ACEfkgk2QXJeRc0aaLzY5ulFsAR4Juidks5ZFhXawA%3D%3D) コードを **handlers\new.js** ファイルに使います

 それぞれの変更の詳細については、ファイル内のコメントを確認してください。ここでは、基本的な入力エラーの確認 (たとえば、新しいゲームのクライアント要求でペアの数が 1 より少ないなど) を行い、必要に応じてエラーメッセージを送信しています。 またハンドラーは、有効なクライアント要求を、(\data にある) 対応するデータ ファイルにルーティングして、さらに処理を行うようにします。 これらは次で行います。

### <a name="4-set-up-your-data-model"></a>4. データ モデルをセットアップする

プレースホルダーのモックデータ サービスを、実際のメモリ ゲーム ボードのデータ モデルに置き換えます。

プログラムのこのレイヤーは、メモリ カード自体を表し、ゲーム ロジックのほとんどを提供します。これには、新しいゲームのためのカードのシャッフル、一致したカードのペアの認識、ゲーム状態の記録などが含まれます。 次をコピーして貼り付けて利用できます。

 - この [game.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/game.js?token=ACEfksAceJNQmhF82aHjQTx78jILYKfCks5ZFhX4wA%3D%3D) コードを **data\game.js** ファイルに使います
 - この [guess.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/guess.js?token=ACEfkvY69Zr1AZQ4iXgfCgDxeinT21bBks5ZFhYBwA%3D%3D) コードを **data\guess.js** ファイルに使います
 - この [new.js](https://raw.githubusercontent.com/Microsoft/Windows-tutorials-web/master/Single-Page-App-with-REST-API/backend/data/new.js?token=ACEfkiqeDN0HjZ4-gIKRh3wfVZPSlEmgks5ZFhYPwA%3D%3D) コードを **data\new.js** ファイルに使います

ここでは簡単のため、ゲーム ボードを Node サーバーのグローバル変数 (`global.board`) に保存します。 同時に複数のプレイヤーによる複数のゲームをサポートする、実際に使えるメモリ ゲーム API サービスとするためには、クラウド ストレージ (Google [Cloud Datastore](https://cloud.google.com/datastore/) や Azure [DocumentDB](https://azure.microsoft.com/en-us/services/documentdb/) など) を使用します。

VS Code ですべての変更を保存したことを確認し、サーバーを再度起動 (VS Code で F5 キーを押すか、またはシェルから `npm start` を実行して、次に [http://localhost:8000](http://localhost:8000) に移動する) して、ゲームの API をテストします。

**Try it out!** ボタンを **/game**、**/guess**、**/new** のいずれかで押して、下の **Response Body** および **Response Code** の結果を確認し、予想どおりに動作していることを確認します。

次のように試してみます。 

1. 新しい `size=2` のゲームを作成します。

    ![Swagger UI から新しいメモリ ゲームを開始する](images/swagger_new.png)

2. いくつかの値を推測します。

    ![Swagger UI からカードを推測する](images/swagger_guess.png)

3. ゲームを進行しながら、ゲーム ボードを確認します。

    ![Swagger UI からゲームの状態を確認する](images/swagger_game.png)

すべての動作を確認したら、API サービスを Azure でホストします。 問題が発生した場合には、\data\game.js で、次の行をコメント アウトしてみます。

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

この変更により、**GET /game** メソッドは (クリアされていないものも含めて) すべてのカードの値を返します。 これは、メモリ ゲームのフロント エンドを構築する際のデバッグに役立ちます。

### <a name="5-optional-host-your-api-service-on-azure-and-enable-cors"></a>5. (省略可能) API サービスを Azure でホストして CORS を有効化する

次の Azure ドキュメントを参照して作業を行います。

 - [Azure Portal を使って、新しい *API アプリ*を登録する](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#createapiapp)
 - [API アプリの Git デプロイを設定する](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#deploy-the-api-with-git)
 - [API アプリ コードを Azure にデプロイする](https://docs.microsoft.com/azure/app-service/app-service-web-tutorial-rest-api#deploy-the-api-with-git)

アプリを登録する場合、*アプリ名*を他と異なるものにするようにします (*http://memorygameapi.azurewebsites.net* URL のバリエーションを要求する、他のアプリと名前が競合しないようにします)。

ここまでの作業を行って、Azure と Swagger UI が機能している場合、メモリ ゲームのバックエンドに必要な最後の手順が 1 つあります。 [Azure Portal](https://portal.azure.com) から、新しく作成した*アプリ サービス*を選び、**CORS** (クロス オリジン リソース共有) オプションを選択または検索します。 [**許可されたオリジン**] の下で、アスタリスク (`*`) を追加して、[**保存**] をクリックします。 これにより、ローカル マシンで開発を行いながら、メモリ ゲームのフロントエンドから、作成した API サービスへのクロス オリジンの呼び出しが可能となります。 メモリ ゲームのフロント エンドが完成し、Azure にデプロイしたら、このエントリを Web アプリの特定の URL で置き換えることができます。

### <a name="going-further"></a>追加情報

メモリ ゲーム API を実稼働アプリ用のバックエンド サービスとするためには、複数のプレイヤーとゲームをサポートするようにコードを拡張する必要があります。 そのためには、[認証](http://swagger.io/docs/specification/authentication/) (プレイヤーの ID を管理する)、[NoSQL データベース](https://docs.microsoft.com/en-us/azure/documentdb/) (ゲームとプレイヤーを管理する)、API の基本的な[単体テスト](https://apigee.com/about/blog/developer/swagger-test-templates-test-your-apis)について調べる必要があります。

そのために役立つ追加情報を次に示します。

 - [Visual Studio Code を使った Node.js の高度なデバッグ](https://code.visualstudio.com/docs/nodejs/nodejs-debugging)

 - [Azure Web + モバイル ドキュメント](https://docs.microsoft.com/en-us/azure/#pivot=services&panel=web)

 - [Azure DocumentDB ドキュメント](https://docs.microsoft.com/en-us/azure/documentdb/index)

## <a name="part-ii-build-a-single-page-web-application"></a>パート 2: 単一ページの web アプリケーションを構築します。

パート 1 では、[REST API バックエンド](#part-i-build-a-rest-api-backend)を構築 (または[ダウンロード](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/backend)) しました。次に、[Node](https://nodejs.org/en/)、[Express](http://expressjs.com/)、[Bootstrap](http://getbootstrap.com/) を使って、単一ページのメモリ ゲームのフロントエンドを作成します。

このチュートリアルのパート 2 では、次の内容を扱います。 

* [Node.js](https://nodejs.org/en/): ゲームをホストするサーバーの作成
* [jQuery](http://jquery.com/): JavaScript ライブラリ
* [Express](http://expressjs.com/): Web アプリケーション フレームワーク
* [Pug](https://pugjs.org/): (旧 Jade) テンプレート エンジン
* [Bootstrap](http://getbootstrap.com/): レスポンシブ レイアウト
* [Visual Studio Code](https://code.visualstudio.com/): コードの作成、マークダウン表示、デバッグ

### <a name="1-create-a-nodejs-application-by-using-express"></a>1. Express を使って Node.js アプリケーションを作成する

まず、Express を使って Node.js プロジェクトを作成します。

1. コマンド プロンプトを開き、ゲームの保存先のディレクトリに移動します。 
2. Express ジェネレーターを使い、テンプレート エンジン *Pug* を使用して、新しいアプリケーション *memory* を作成します。

    ```
    express --view=pug memory
    ```

3. memory ディレクトリで、package.json ファイルに示されている依存関係をインストールします。 package.json ファイルは、プロジェクトのルートに作成されます。 このファイルには、Node.js アプリに必要なモジュールが含まれています。  

    ```
    cd memory
    npm install
    ```

    このコマンドを実行すると、このアプリに必要なすべてのモジュールを含む、node_modules という名前のフォルダーが作成されます。 

4. アプリケーションを実行します。

    ```
    npm start
    ```

5. [http://localhost:3000/](http://localhost:3000/) に移動してアプリケーションを表示します。

    ![http://localhost:3000/ のスクリーンショット](./images/express.png)

6. memory\routes ディレクトリの index.js を編集して、Web アプリの既定のタイトルを変更します。 下記の行の `Express` を `Memory Game` (または任意のタイトル) に変更します。

    ``` javascript
    res.render('index', { title: 'Express' });
    ```

7. 新しいタイトルを表示するためアプリを更新するには、コマンド プロンプトで **Ctrl + C**、**Y** の順に押してアプリを停止し、`npm start` で再起動します。

### <a name="2-add-client-side-game-logic-code"></a>2. クライアント側のゲーム ロジック コードを追加する
チュートリアルのこの後半に必要なファイルは、[Start](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Start) フォルダーに含まれています。 途中で迷った場合には、[Final](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Final) フォルダーに完成したコードが含まれています。 

1. [Start](https://github.com/Microsoft/Windows-tutorials-web/tree/master/Single-Page-App-with-REST-API/frontend/Start) フォルダー内の scripts.js ファイルをコピーして、それを memory\public\javascripts に貼り付けます。 このファイルには、次のような、ゲームを実行するために必要なすべてのゲーム ロジックが含まれています。

    * 新しいゲームを作成/開始します。
    * サーバーに保存されているゲームを復元します。
    * ユーザーの選択に基づいて、ゲーム ボードとカードを描画します。
    * カードを反転します。

2. script.js で、まず `newGame()` 関数を変更します。 この関数は次の処理を行います。

    * ユーザーからのゲームのサイズの選択を処理します。
    * サーバーから [gameboard array](#part-i-build-a-rest-api-backend) をフェッチします。
    * `drawGameBoard()` 関数を呼び出し、画面にゲーム ボードを配置します。

    `newGame()` 内の `// Add code from Part 2.2 here` コメントの後に、次のコードを追加します。

    ``` javascript
    // extract game size selection from user
    var size = $("#selectGameSize").val();

    // parse game size value
    size = parseInt(size, 10);
    ```

    このコードは、`id="selectGameSize"` (これは後で作成します) を使って、ドロップダウン メニューから値を取得し、それを変数 (`size`) に保存します。  [`parseInt()`](https://developer.mozilla.org/en-US/docs/Web/JavaScript/Reference/Global_Objects/parseInt) 関数を使って、ドロップダウンからの文字列の値を解析して整数を返します。要求されたゲーム ボードの `size` をサーバーに渡します。 

    このチュートリアルのパート 1 で作成した [`/new`](#part-i-build-a-rest-api-backend) メソッドを使って、選択されたゲーム ボードのサイズをサーバーに投稿します。 このメソッドは、カードおよびカードが一致したかどうかを示す `true/false` 値を含む、単一の JSON 配列を返します。 

3. 次に、`restoreGame()` 関数に入力します。この関数は最後にプレイされたゲームを復元します。 簡単のため、このアプリでは最後にプレイされたゲームを常に読み込みます。 サーバーに保存されているゲームがない場合、ドロップ ダウン メニューを使用して新しいゲームを開始します。 

    次のコードをコピーして `restoreGame()` に貼り付けます。

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

    ゲームで、サーバーからゲームの状態をフェッチできるようになります。 この手順で使用されている [`/game`](#part-i-build-a-rest-api-backend) メソッドの詳細については、このチュートリアルの第 I 部を参照してください。 Azure (または別のサービス) を使用してバックエンド API をホストしている場合、上記の *localhost* を実稼働 URL に置き換えます。

4. 次に、`drawGameBoard()` 関数を作成します。  この関数は次の処理を行います。

    * ゲームのサイズを検出し、特定の CSS スタイルを適用します。
    * HTML でカードを生成します。
    * カードをページに追加します。

    次のコードをコピーして、*scripts.js * の `drawGameBoard()` 関数に貼り付けます。

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

5. 次に、`flipCard()` 関数を完成させます。  この関数では、チュートリアルのパート 1 で開発した [`/guess`](#part-i-build-a-rest-api-backend) メソッドを使って、選んだカードの値をサーバーから取得するなど、ゲーム ロジックの大部分の処理を行います。 REST API バックエンドをクラウドでホスティングしている場合には、*localhost* アドレスを運用 URL に忘れずに置換します。

    `flipCard()` 関数で、次のコードのコメントを解除します。

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
> Visual Studio Code を使っている場合は、コメントを解除するコードのすべての行を選択して、Crtl + K、U キーの順に押します。

次に、[`jQuery.ajax()`](http://api.jquery.com/jQuery.ajax/) と、パート 1 で作成した **PUT** [`/guess`](#part-i-build-a-rest-api-backend) メソッドを使用します。 

このコードは、次の順序で実行されます。

* ユーザーが選択した最初のカードの `id` が、selectedCards[] 配列の最初の値として追加されます":  `selectedCards[0]` 
* `selectedCards[0]` の値 (`id`) が [`/guess`](#part-i-build-a-rest-api-backend) メソッドを使ってサーバーに投稿されます
* サーバーが、そのカードの `value` (整数) を応答します
* `id` が次の値であるカードの裏に [Bootstrap glyphicon](http://getbootstrap.com/components/) が追加されます:  `selectedCards[0]`
* (サーバーからの) 最初のカードの `value` が `selectedCardsValues[]` 配列: `selectedCardsValues[0]` に保存されます 

ユーザーの 2 回目の推測も同じロジックに従います。 ユーザーが選択したカードが同じ ID である場合 (たとえば `selectedCards[0] == selectedCards[1]`)、カードは一致します。 一致したペアには CSS クラス `.matched` が追加され (緑色に変わり)、カードは反転されたまま残ります。

ここで、すべてのカードが一致し、ゲームが終了したかどうかを確認するロジックを追加します。 `flipCard()` 関数の中で `//check if the user won the game` コメントの下に、次の行を追加します。 

``` javascript
if (cardsFlipped == gameBoardSize) {
    setTimeout(function () {
        output = "<div id=\"playAgain\"><p>You Win!</p><input type=\"button\" onClick=\"location.reload()\" value=\"Play Again\" class=\"btn\" /></div>";
        $("#game-board").html(output);
    }, 1000);
}   
```

反転して一致したカードの数が、ゲーム ボードのサイズと等しい場合 (たとえば、`cardsFlipped == gameBoardSize`)、それ以上反転できるカードはなく、ゲームは終了です。 `div` に `id="game-board"` を使って簡単な HTML を追加して、ユーザーにゲームが終了したことと、もう一度プレイできることを伝えます。  

### <a name="3-create-the-user-interface"></a>3. ユーザー インターフェイスを作成する 
次に、すべてのコードを確認して、ユーザー インターフェイスを作成します。 このチュートリアルでは、テンプレート エンジン [Pug](https://pugjs.org/) (旧 Jade) を使用します。  *Pug* では HTML の記述時に、空白が意味を持つ、クリーンな構文を使います。 次に例を示します。 

```
body
    h1 Memory Game
    #container
        p We love tutorials!
```

上記は以下のようになります。

``` html
<body>
    <h1>Memory Game</h1>
    <div id="container">
        <p>We love tutorials!</p>
    </div>
</body>
```


1. memory\views の layout.pug ファイルを、提供された Start フォルダーの layout.pug ファイルで置き換えます。 layout.pug の中には、次へのリンクが含まれています。

    * Bootstrap
    * jQuery
    * カスタム CSS ファイル
    * 変更が完了した JavaScript ファイル

2. memory\views ディレクトリで index.pug という名前のファイルを開きます。
このファイルは、layout.pug ファイルを拡張し、ゲームのレンダリングを行います。 layout.pug の中に、次のコードを貼り付けます。

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
> Pug では空白が意味を持つことに注意してください。 すべてのインデントが正しいことを確認します。

### <a name="4-use-bootstraps-grid-system-to-create-a-responsive-layout"></a>4. Bootstrap のグリッドのシステムを使ってレスポンシブ レイアウトを作成する
Bootstrap の[グリッド システム](http://getbootstrap.com/css/#grid)は、デバイスのビューポートの変化にしたがって拡大縮小する、柔軟なグリッド システムです。 このゲームのカードは、次のような Bootstrap の定義済みのグリッド システム クラスをレイアウトに使用しています。
* `.container-fluid`柔軟なグリッド コンテナーを指定します
* `.row-fluid`: 柔軟な行を指定します
* `.col-xs-3`: 列数を指定します

Bootstrap のグリッド システムを使うと、モバイル デバイスのナビゲーション メニューに表示されるように、グリッド システムを 1 つの垂直列に折りたたむことができます。  しかし、このゲームでは常に列を保持するため、定義済みのクラス `.col-xs-3` を使い、常に横方向のグリッドを保持するようにします。 

このグリッド システムでは最大 12 列が可能です。 このゲームでは 4 列のみを使用するため、`.col-xs-3` クラスを使用します。 このクラスは、前述の利用可能な 12 列のうちの 3 列の幅にわたる、各列を必要とすることを指定します。 次の図は、このゲームで使われている、12 列のグリッドと 4 列のグリッドを示します。

![Bootstrap の 12 列と 4 列のグリッド](./images/grid.png)

1. scripts.js を開き、`drawGameBoard()` 関数を見つけます。  各カードの HTML を生成したコード ブロックで、`class="col-xs-3"` を持つ `div` 要素を見つけます。 

2. index.pug の中に、先述の定義済みの Bootstrap のクラスを追加して、柔軟なレイアウトを作成します。  index.pug を次のように変更します。

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

### <a name="5-add-a-card-flip-animation-with-css-transforms"></a>5. CSS 変換を使ってカードの反転のアニメーションを追加する
memory\public\stylesheets の style.css ファイルを、Start フォルダーの style.css ファイルで置き換えます。

[CSS 変換](https://docs.microsoft.com/en-us/microsoft-edge/dev-guide/css/transforms)を使って、反転モーションを追加し、カードにリアルな 3D の反転モーションを追加します。 ゲームのカードは次の HTML 構造を使用して作成され、(先述の `drawGameBoard()`関数により) プログラムによってゲーム ボードに追加されています。

``` html
<div class="flipContainer">
    <div class="cards">
        <div class="front"></div>
        <div class="back"></div>
    </div>
</div>
```

1. まず、アニメーションの親コンテナーに[視点](https://developer.mozilla.org/en-US/docs/Web/CSS/transform)を与えます (`.flipContainer`)。  これにより、子要素に深度の錯視が加わります。値が大きいほど、要素はユーザーがから離れて見えます。 style.css の `.flipContainer` クラスに、次の視点を追加します。

    ``` css
    perspective: 1000px; 
    ```

2. 次に、style.css の `.cards` クラスに以下のプロパティを追加します。 `.cards``div` は、カードの表または裏を示して、実際に反転アニメーションを行う要素です。 

    ``` css
    transform-style: preserve-3d;
    transition-duration: 1s;
    ```

    [`transform-style`](https://developer.mozilla.org/en-US/docs/Web/CSS/transform-style) プロパティは 3D レンダリングのコンテキストを確立します。`.cards` クラスの子 (`.front` および `.back`) は 3D 空間のメンバーです。 [`transition-duration`](https://developer.mozilla.org/en-US/docs/Web/CSS/transition-duration) プロパティを追加して、アニメーションを完了する時間を秒数で指定します。 

3.  [`transform`](https://developer.mozilla.org/en-US/docs/Web/CSS/transform) プロパティを使って、カードを Y 軸周りで回転させることができます。  次の CSS を `cards.flip` に追加します。

    ``` css
    transform: rotateY(180deg);
    ```

    `cards.flip` で定義されたスタイルは、`flipCard` 関数で [`.toggleClass()`](http://api.jquery.com/toggleClass/) を使って、オンとオフを切り替えることができます。 

    ``` javascript
    $(card).toggleClass("flip");
    ```

    これにより、ユーザーがカードをクリックすると、カードは 180° 回転します。

### <a name="6-test-and-play"></a>6. テストしてプレイする
いよいよ完成です。 Web アプリの作成が完了しました。 ではテストを行いましょう。 

1. memory ディレクトリでコマンド プロンプトを開き、次のコマンドを入力します。 `npm start`

2. ブラウザーで [http://localhost:3000/](http://localhost:3000/) に移動して、ゲームをプレイします。

3. エラーが発生した場合は、キーボードで F5 キーを押して、`Node.js` と入力すると、Visual Studio Code の Node.js デバッグ ツールを使用できます。 Visual Studio Code でのデバッグについて詳しくは、この[記事](http://code.visualstudio.com/docs/editor/debugging#_launch-configurations)をご覧ください。 

    コードを Final フォルダーに含まれているコードと比較することもできます。

4. ゲームを停止するには、コマンド プロンプトで、**Ctrl + C**、**Y** の順に入力します。 

### <a name="going-further"></a>追加情報

これで、作成したアプリを Azure (またはその他のクラウド ホスティング サービス) にデプロイして、モバイル、タブレット、デスクトップなどの、さまざまなフォーム ファクターのデバイスにわたってテストを行う準備ができました。 (さまざまなブラウザーでも忘れずにテストを行ってください) 実稼働のための準備ができたら、*ユニバーサル Windows プラットフォーム* (UWP) のための*ホストされた Web アプリ* (HWA) として、容易にパッケージ化し、Microsoft Store から配布することができます。

Microsoft Store に公開するための基本的な手順は次のとおりです。

 1. [Windows 開発者](https://developer.microsoft.com/en-us/store/register)アカウントを作成します。
 2. アプリの申請の[チェックリスト](https://docs.microsoft.com/en-us/windows/uwp/publish/app-submissions)を使用します。
 3. アプリを申請して[認定](https://msdn.microsoft.com/windows/uwp/publish/the-app-certification-process)を受けます。

そのために役立つ追加情報を次に示します。

 - [アプリケーション開発プロジェクトを Azure Websites にデプロイする](https://docs.microsoft.com/azure/cosmos-db/documentdb-nodejs-application#_Toc395783182)

 - [Web アプリケーションをユニバーサル Windows プラットフォーム (UWP) アプリに変換する](https://docs.microsoft.com/en-us/windows/uwp/porting/hwa-create-windows)

 - [Windows アプリを公開する](https://developer.microsoft.com/en-us/store/publish-apps)
