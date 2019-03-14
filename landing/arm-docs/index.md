---
layout: LandingPage
description: このページでは、ARM64 win32 および UWP アプリの開発を開始するための情報を提供します。
title: ARM 版 Windows 10
author: msatranjr
ms.author: misatran
ms.date: 05/08/2018
ms.localizationpriority: medium
ms.topic: article
keywords: 'ARM 版 Windows 10, ARM, win32 ARM64 アプリの構築, ARM64 ドライバーの構築'
---

# <a name="windows-10-on-arm"></a>ARM 版 Windows 10
Windows 10 は、ARM プロセッサ搭載の PC で実行されます。 このページでは、プラットフォームについてさらに学習し、アプリの開発を開始するための情報を提供します。 ページの下部にあるリンクを使用して、フィードバックを提供することもお勧めします。

## <a name="introductory-videos"></a>入門ビデオ
ARM での Windows 10 の実行方法を視聴して学習します。

<ul class="cols cols3">
    <li>
        <a href="https://youtu.be/OZtVBDeVqCE"><img alt="Building ARM64 Win32 C++ apps video" src="./images/Arm64Scaled.png" /></a>
        <h3>ARM64 Win32 C++ アプリの構築</h3><p>Visual Studio 用の ARM64 ツールのインストール方法について学習します。 その後、新しい ARM 64 プロジェクトの作成およびコンパイル手順を確認します。</p>
    </li>
    <li>
        <a href="https://channel9.msdn.com/Events/Build/2018/BRK2438"><img alt="Build 2018 Windows 10 on ARM for developers" src="./images/buildVideoStillScaled.png" /></a>
        <h3>開発者向け ARM 版 2018 Windows 10 を構築する</h3><p>ARM 版 Windows 10 デバイス、x86 エミュレーション機能のしくみ、最後に ARM 版 Windows 10 向けアプリの提出と構築方法について学習します。 デスクトップと UWP 向け ARM64 アプリの構築方法をご覧いただけます。</p>
    </li>
    <li>
        <a href="https://channel9.msdn.com/Events/Ch9Live/Windows-Community-Standup/Kevin-Gallo-January-2018"><img alt="Community standup video featuring Kevin Gallo" src="./images/communityStandupStillScaled.png" /></a>
        <h3>Windows Community Standup と Kevin Gallo 氏</h3><p>ARM64 で Windows 10 を実行する方法についてよく理解し、このプラットフォームでのアプリとエクスペリエンスがどのようなものであるかを確認します。</p>
    </li>
</ul>

## <a name="understanding-windows-10-on-arm"></a>ARM 版 Windows 10 について
これらのリソースを確認することで、プラットフォームを理解します。

<ul class="cardsF panelContent cols cols2">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm" title="作業の開始" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="Get started icon" src="/media/common/i_get-started.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>ARM 版 Windows 10 での作業を開始する</h3>
                    <p class="x-hidden-focus">基本を理解するためのドキュメントを確認します。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm-x86-emulation" title="x86 エミュレーションに関するトピック" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                             <img class="cardImage" role="presentation" alt="x86 emulation icon" src="/media/common/i_advanced.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>x86 エミュレーションのしくみを学習する</h3>
                    <p class="x-hidden-focus">ARM 版 Windows 10 のこの主要な機能の全容を確認します。</p>
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

## <a name="developing-for-windows-10-on-arm"></a>ARM 版 Windows 10 の開発
まず、ARM 版 Windows 10 に合わせてアプリを調整し、そこで利用可能な機能を活用します。  

<ul class="cardsF panelContent cols cols3">
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="https://blogs.windows.com/buildingapps/?p=52087" title="ARM64 アプリの構築" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="Build ARM64 Win32 apps blog icon" src="/media/common/i_build.svg" data-linktype="external" />
                    </div>
                    </a>
                <div class="cardText">
                    <h3>SDK での ARM64 アプリの構築</h3>
                    <p class="x-hidden-focus">ARM 版 Windows 10 でネイティブに実行するために ARM64 としてアプリをコンパイルする手順について説明する、このブログ投稿を確認します。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm-troubleshooting-arm32" title="arm32 アプリのトラブルシューティング" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="UWP apps on ARM icon" src="/media/common/i_code-edit.svg" data-linktype="external" />
                    </div>
                </a>
                <div class="cardText">
                    <h3>ARM の UWP アプリ</h3>
                    <p class="x-hidden-focus">ユニバーサル Windows プラットフォーム (UWP) アプリを正しくに設定できるように、このガイダンスに従ってください。</p>                    
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
                    <p class="x-hidden-focus">ARM 版 Windows 10 でコードがスムーズに実行されるようにします。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows-hardware/drivers/develop/building-arm64-drivers" title="ARM64 ドライバーの構築" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="Building ARM64 drivers icon" src="/media/common/i_drivers.svg" data-linktype="external" />
                            </a>
                    </div>
                </a>
                <div class="cardText">
                    <h3>WDK を使った ARM64 ドライバーのビルド</h3>
                    <p class="x-hidden-focus">ARM64 用にドライバーを再コンパイルします。</p>
                </div>
            </div>
        </div>
    </li>
    <li>
        <div class="cardSize">
            <div class="cardPadding">
                <a class="card" href="/windows/uwp/porting/apps-on-arm-troubleshooting-x86" title="x86 アプリのトラブルシューティング" data-linktype="absolute-path">
                    <div class="cardImageOuter">
                            <img class="cardImage" role="presentation" alt="x86 apps on ARM icon" src="/media/common/i_code-blocks.svg" data-linktype="external" />
                            </a>
                    </div>
                </a>
                <div class="cardText">
                    <h3>ARM の x86 アプリ</h3>
                    <p class="x-hidden-focus">ARM 版 Windows 10 で最適に実行されるように x86 アプリを開発します。</p>
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

## <a name="let-us-know-if-you-have-feedback"></a>フィードバックがある場合はお知らせください
お客様自身および既存のお客様からのフィードバックを活かし、製品を継続的に改善しています。 アイデアがある場合や、問題が発生してお困りの場合、あるいは単にご自身のエクスペリエンスがいかにすばらしいかを共有したい場合は、これらのリンクが役立ちます。

<ul class="cardsM cols cols3">
<li>
        <a class="card" href="feedback-hub://?tabid=2&contextid=803" data-linktype="absolute-path">
            <img class="cardImage" role="presentation" alt="Feedback hub icon" src="/media/common/i_feedback.svg" data-linktype="external" />
            <div class="cardText">
                <h3>フィードバック Hub を使用する</h3>
                <p>何か足りないものがありますか。 すばらしいアイデアがありますか。 フィードバック Hub でお知らせください。</p>
            </div>
        </a>
    </li>
    <li>
        <a class="card" href="mailto:woafeedback@microsoft.com" data-linktype="absolute-path">
            <img class="cardImage" role="presentation" alt="Report a bug icon" src="/media/common/i_mail.svg" data-linktype="external" />
            <div class="cardText">
                <h3>バグを報告する</h3>
                <p>プラットフォームでバグが見つかりましたか。 詳細を含むメールを送信してください。</p>
            </div>
        </a>
    </li>
    <li>
        <a class="card" href="https://github.com/MicrosoftDocs/windows-uwp/tree/docs/landing/arm-docs" data-linktype="absolute-path">
            <img class="cardImage" role="presentation" alt="Give doc feedback icon" src="/media/common/i_form.svg" data-linktype="external" />
            <div class="cardText">
                <h3>ドキュメントについてフィードバックする</h3>
                <p>ドキュメントに問題がありましたか。 もっとわかりやすくしてほしい内容がありますか。 ドキュメント GitHub リポジトリで問題を作成してください。</p>
            </div>
        </a>
    </li>
</ul>