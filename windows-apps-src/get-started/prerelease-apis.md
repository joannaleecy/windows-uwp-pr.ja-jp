---
author: drewbat
ms.assetid: 
title: "プレリリース版 API を使用した UWP アプリの開発"
description: "プレビュー版の UWP SDK に含まれているプレリリース版の API を使用する場合の利点と注意事項について説明します。"
ms.openlocfilehash: ede7e8d5e9cce39850edbdb70a715d76c78f0c01
ms.sourcegitcommit: 909d859a0f11981a8d1beac0da35f779786a6889
translationtype: HT
---
# <a name="developing-uwp-apps-with-pre-release-apis"></a>プレリリース版 API を使用した UWP アプリの開発

Microsoft ではユニバーサル Windows プラットフォーム (UWP) SDK のプレビュー リリースを公開しており、開発者は最終的なリリースの前に新しいプラットフォームの機能を使用できます。 これにより、いち早く機能をアプリに組み込むことができ、正式な RTM バージョンの SDK がリリースされた直後にアプリを公開することが容易になります。 プレリリース版の API を使用することにより、Microsoft にフィードバックを提供して、今後のリリースでのプラットフォームの方向性に影響を与えることもできます。

## <a name="important-limitations-on-the-use-of-pre-release-apis"></a>プレリリース版の API の使用に関する重要な制限事項
アプリでプレリリース版の API を使用する前に、次のような重要な影響に注意してください。 
* プレリリース版の API を使用するアプリは、API が正式に RTM リリースとして公開されるまで、Windows ストアに提出することはできません。 プレリリース版の開発コードを現在公開されているアプリのコードから分離しておくことを強くお勧めします。 
* プレビュー版の SDK を使用して開発したアプリは、プレリリース版の API を使用していない場合でもストアに提出することはできません。 プレビュー版のツールは、主要な開発に使用する運用環境のコンピューターとは別のコンピューターや VM にインストールしてください。 
* プレリリース版の API は、RTM の前に変更される可能性があります。 API がプレビュー版の SDK に含まれている場合、それによって実現される機能やシナリオは最終的な SDK にも含まれることが想定されています。 ただし、特定の API の名前、署名、動作が最終的なリリースの前に変更される場合があります。また、API が完全に削除される可能性もあります。 

## <a name="how-to-identify-a-prerelease-api"></a>プレリリース版の API を識別する方法 
UWP の API リファレンス ドキュメントで、プレリリース版である API には、次のようなテキストが示されています。 

この記事で説明しているプレリリース版の API や機能は、正式版がリリースされるまでに大幅に変更される可能性があります。 今すぐ開発やテストにこの機能を使用することはできますが、機能が正式にリリースされるまで、この機能を使用するアプリを Windows ストアに提出することはできません。 本書に記載された情報について、Microsoft は明示または黙示を問わずいかなる保証をするものでもありません。 プレリリース版の API を使った開発の詳細については、「プレリリース版 API を使用した UWP アプリの開発」をご覧ください。 

## <a name="get-the-latest-sdk-insider-preview"></a>最新の SDK Insider Preview の入手 
1. [Windows Insider Program にサインアップ](https://insider.windows.com/)して、SDK のプレビュー ビルドへのアクセスを取得します。 
3. 開発者プレビュー ツールをインストールする前に、[現在の SDK と Mobile エミュレーターのリリース ノート](http://go.microsoft.com/fwlink/?LinkId=829180)を確認してください。
4. [SDK Insider Preview](https://www.microsoft.com/en-us/software-download/windowsinsiderpreviewSDK) のインストール
5. [Windows Insider Preview コミュニティ フォーラム](http://go.microsoft.com/fwlink/p/?LinkId=507620)を確認してください。
