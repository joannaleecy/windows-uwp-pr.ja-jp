---
author: mcleanbyron
ms.assetid: 48a1ef86-8514-4af8-9c93-81e869d36de7
description: "JavaScript を使ってプログラムで **AdControl** を作成する方法について説明します。"
title: "JavaScript での AdControl の作成"
ms.author: mcleans
ms.date: 02/08/2017
ms.topic: article
ms.prod: windows
ms.technology: uwp
keywords: "Windows 10、UWP、広告、AdControl、javascript"
translationtype: Human Translation
ms.sourcegitcommit: c6b64cff1bbebc8ba69bc6e03d34b69f85e798fc
ms.openlocfilehash: d2ceafb9781ca2b9cd640e65d9bb420f0bf37928
ms.lasthandoff: 02/07/2017

---

# <a name="create-an-adcontrol-in-javascript"></a>JavaScript での AdControl の作成




この記事の例では、JavaScript を使ってプログラムで [AdControl](https://msdn.microsoft.com/library/windows/apps/microsoft.advertising.winrt.ui.adcontrol.aspx) を作成する方法について説明します。 この記事では、**AdControl** を使用するために必要なプロジェクトへの参照が既に追加していることを前提としています。 JavaScript ではなく HTML マークアップで **AdControl** を作成し初期化する方法の詳しいチュートリアルも含め、詳しくは「[HTML 5 および Javascript の AdControl](adcontrol-in-html-5-and-javascript.md)」をご覧ください。

## <a name="html-div-for-an-adcontrol"></a>AdControl 用の HTML の div

**AdControl** で広告を表示するには、対象の html ページに **div** を含める必要があります。 この **div** のコード例を次に示します。

> [!div class="tabbedCodeSnippets"]
``` html
<div id="myAd" style="position: absolute; top: 50px; left: 0px; width: 300px; height: 250px; z-index: 1"
    data-win-control="MicrosoftNSJS.Advertising.AdControl">
</div>
```

## <a name="javascript-for-creating-an-adcontrol"></a>AdControl を作成するための JavaScript

次の例では、HTML に **div** が既にあることを前提にしています。ID は **myAd** です。

**AdControl** を **app.onactivated** 関数でインスタンス化します。

> [!div class="tabbedCodeSnippets"]
[!code-javascript[AdControl](./code/AdvertisingSamples/AdControlSamples/js/main.js#DeclareAdControl)]

この例では、**myAdError**、**myAdRefreshed**、および **myAdEngagedChanged** という名前のイベント ハンドラー メソッドを既に宣言していることを前提としています。

>**注**&nbsp;&nbsp;この例の *applicationId* の値と *adUnitId* の値は、[テスト モードの値](test-mode-values.md)です。 申請のためにアプリを提出する前に、Windows デベロッパー センターから[実際の値にこれらの値を置き換える](set-up-ad-units-in-your-app.md)必要があります。

このコードで広告が表示されない場合は、**AdControl** を含む **div** に **position:relative** の属性を挿入してみてください。 これにより、**IFrame** の既定の設定が上書きされます。 この属性の値が原因でなければ、広告が正しく表示されるようになります。 新しい広告ユニットが利用可能になるまでに最大で 30 分かかる場合があることに注意してください。

## <a name="related-topics"></a>関連トピック

* [GitHub の広告サンプル](http://aka.ms/githubads)

 

 

