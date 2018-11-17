---
layout: LandingPage
description: このページは、ARM64 win32 および UWP アプリの開発を開始するための情報を提供します。
title: ARM 版 Windows 10
author: msatranjr
ms.author: misatran
ms.date: 05/08/2018
ms.localizationpriority: medium
ms.topic: article
keywords: ARM、ARM、ARM64 の win32 アプリの構築、ARM64 ドライバーのビルドで Windows 10
ms.openlocfilehash: 83f2a0d03040a682e6965558174294fe27e21bfb
ms.sourcegitcommit: 3257416aebb5a7b1515e107866806f8bd57845a8
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 11/17/2018
ms.locfileid: "7166099"
---
# <a name="windows-10-on-arm"></a>ARM 版 Windows 10
Windows 10 は、ARM プロセッサを搭載する Pc で実行されます。 このページは、プラットフォームについて詳しくは、アプリの開発を開始するための情報を提供します。 また、ページの下部にあるリンクを使用して、フィードバックをお勧めします。

## <a name="introductory-videos"></a>別の入門ビデオ
観察し、Windows 10 が ARM で実行する方法について説明します。

<ul class="cols cols3">
    <li>
        <a href="https://youtu.be/OZtVBDeVqCE"><img alt="Building ARM64 Win32 C++ apps video" src="./images/Arm64Scaled.png" /></a>
        <h3>ARM64 Win32 C++ アプリの構築</h3><p>Visual Studio の ARM64 ツールをインストールする方法について説明します。 について説明しますを作成して、新しい ARM 64 プロジェクトのコンパイルの手順を実行します。</p>
    </li>
    <li>
        <a href="https://channel9.msdn.com/Events/Build/2018/BRK2438"><img alt="Build 2018 Windows 10 on ARM for developers" src="./images/buildVideoStillScaled.png" /></a>
        <h3>開発者向けの ARM でビルド 2018 Windows 10</h3><p>については、Windows 10 on ARM デバイス、どの魔法のような x86 エミュレーションのしくみと、最後に提出し、ARM での Windows 10 のアプリを構築する方法。 デスクトップと UWP のアプリを ARM64 を構築する方法表示されます。</p>
    </li>
    <li>
        <a href="https://channel9.msdn.com/Events/Ch9Live/Windows-Community-Standup/Kevin-Gallo-January-2018"><img alt="Community standup video featuring Kevin Gallo" src="./images/communityStandupStillScaled.png" /></a>
        <h3>Windows コミュニティ スタンド Kevin Gallo</h3><p>ARM64 での Windows 10 を実行する方法の詳細についての理解を取得し、アプリとこのプラットフォームでのエクスペリエンスの感覚を取得します。</p>
    </li>
</ul>

## <a name="understanding-windows-10-on-arm"></a>ARM での Windows 10 の概要
これらのリソースを見て、プラットフォームを理解して取得します。

<ul class="cardsF panelContent cols cols2">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm" title="概要" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="Get started icon" src="/media/common/i_get-started.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>Arm 版 Windows 10 を概要します。</h3>
                    <p class="x-hidden-focus">基本を理解するドキュメントを確認します。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm-x86-emulation" title="トピックの x86 エミュレーション" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                             <img class="cardImage" role="presentation" alt="x86 emulation icon" src="/media/common/i_advanced.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>学習方法 x86 エミュレーションのしくみ</h3>
                    <p class="x-hidden-focus">この arm 版 Windows 10 の主な機能についてすべてをについて説明します。</p>
                </div>
            </div>
        </div>
    </li>
    <!--<li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="https://blogs.msdn.microsoft.com/harip/" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="" src="/media/common/i_blog.svg?branch=master" data-linktype="external" />
                            </a>
                    </div>
                </a>
                <div class="cardText">
                    <h3>Read the Kernel blog</h3>
                    <p class="x-hidden-focus">Get a deep understanding of the Windows by reading articles that are written by the creators of the kernel.</p>
                </div>
            </div>
        </div>
    </li>-->
</ul>

## <a name="developing-for-windows-10-on-arm"></a>Arm 版 Windows 10 用の開発
ARM での Windows 10 にアプリの調整を起動し、活用利用可能な機能があります。  

<ul class="cardsF panelContent cols cols3">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="https://blogs.windows.com/buildingapps/?p=52087" title="ARM64 アプリの開発" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="Build ARM64 Win32 apps blog icon" src="/media/common/i_build.svg" data-linktype="external" />
                    </div>
                    </a>
                <div class="cardText">
                    <h3>Sdk ARM64 アプリの構築</h3>
                    <p class="x-hidden-focus">この場所を説明します ARM64 arm 版 Windows 10 でネイティブに実行すると、アプリをコンパイルするブログの投稿を確認します。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm-troubleshooting-arm32" title="Arm32 アプリのトラブルシューティング" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="UWP apps on ARM icon" src="/media/common/i_code-edit.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>ARM での UWP アプリ</h3>
                    <p class="x-hidden-focus">成功した場合に、ユニバーサル Windows プラットフォーム (UWP) アプリを設定するには、このガイダンスに従ってください。</p>                    
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows-hardware/drivers/debugger/debugging-arm64" title="ARM64 アプリのデバッグ" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                             <img class="cardImage" role="presentation" alt="Debugging on ARM icon" src="/media/common/i_debug.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>ARM でのデバッグ</h3>
                    <p class="x-hidden-focus">Arm 版 Windows 10 でスムーズに実行されているコードを取得します。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows-hardware/drivers/develop/building-arm64-drivers" title="ARM64 ドライバーのビルド" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="Building ARM64 drivers icon" src="/media/common/i_drivers.svg" data-linktype="external" />
                            </a>
                    </div>
                </a>
                <div class="cardText">
                    <h3>WDK を使った ARM64 ドライバーのビルド</h3>
                    <p class="x-hidden-focus">ARM64 用ドライバーを再コンパイルします。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm-troubleshooting-x86" title="トラブルシューティングの x86 アプリ" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="x86 apps on ARM icon" src="/media/common/i_code-blocks.svg" data-linktype="external" />
                            </a>
                    </div>
                </a>
                <div class="cardText">
                    <h3>x86 ARM でのアプリ</h3>
                    <p class="x-hidden-focus">開発 x86 アプリが arm 版 Windows 10 での最高を実行します。</p>
                </div>
            </div>
        </div>
    </li>
</ul>

<!--## Other videos
<ul class="cols cols4">
<li>
        <a href="#"><img alt="" src="./images/dummyStillScaled.png" /></a>
            <p>TBD</p>    
    </li>
<li>
        <a href="#"><img alt="" src="./images/dummyStillScaled.png" /></a>
            <p>TBD</p>    
    </li>
<li>
        <a href="#"><img alt="" src="./images/dummyStillScaled.png" /></a>
            <p>TBD</p>    
    </li>
<li>
        <a href="#"><img alt="" src="./images/dummyStillScaled.png" /></a>
            <p>TBD</p>    
    </li>
</ul>-->

## <a name="let-us-know-if-you-have-feedback"></a>知らせフィードバックがあるかどうか
継続的にして、既存のお客様からフィードバックを活用することによって、製品を向上しますがします。 把握している、問題に保持されているか、単にどの適切に共有する場合、エクスペリエンスは、これらのリンクを支援します。

<ul class="cardsM cols cols3">
<li>
        <a class="card" href="feedback-hub://?tabid=2&contextid=803" data-linktype="absolute-path">
            <img class="cardImage" role="presentation" alt="Feedback hub icon" src="/media/common/i_feedback.svg" data-linktype="external" />
            <div class="cardText">
                <h3>フィードバック hub を使用します。</h3>
                <p>でしたられなかったものかどうか。 優れたアイデアがあるかどうか。 フィードバック Hub で知らせします。</p>
            </div>
        </a>
    </li>
    <li>
        <a class="card" href="mailto:woafeedback@microsoft.com" data-linktype="absolute-path">
            <img class="cardImage" role="presentation" alt="Report a bug icon" src="/media/common/i_mail.svg" data-linktype="external" />
            <div class="cardText">
                <h3>バグを報告します。</h3>
                <p>このプラットフォームでバグを発見するかどうか。 詳細をマイクロソフトにメールを送信します。</p>
            </div>
        </a>
    </li>
    <li>
        <a class="card" href="https://github.com/MicrosoftDocs/windows-uwp/tree/docs/landing/arm-docs" data-linktype="absolute-path">
            <img class="cardImage" role="presentation" alt="Give doc feedback icon" src="/media/common/i_form.svg" data-linktype="external" />
            <div class="cardText">
                <h3>フィードバックのドキュメント</h3>
                <p>このドキュメントで問題が見つかったがあるかどうか。 何か明確にごしますか。 ドキュメントの GitHub リポジトリで懸案事項を作成します。</p>
            </div>
        </a>
    </li>
</ul>