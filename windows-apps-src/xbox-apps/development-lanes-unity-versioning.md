---
author: JordanEllis6809
title: "Unity - UWP プロジェクトのバージョン管理"
description: "UWP プロジェクトをバージョン管理します。"
translationtype: Human Translation
ms.sourcegitcommit: a1b759b00e35092323b8c4634907dd5c0fffa68c
ms.openlocfilehash: 3b796c31e6b284cea628ba68a34799cf9317ee2e

---

# Unity: UWP プロジェクトのバージョン管理

ユニバーサル Windows プラットフォーム (UWP) を使って Xbox 用の Unity ゲームをまだ構築していない場合には、  まず「[Xbox の UWP への Unity ゲームの移行](development-lanes-unity.md)」をご覧ください。

生成された UWP ディレクトリの一部をバージョン管理に追加することにはいくつかの理由があり、依存関係 (たとえば、Xbox Live SDK) の追加もその 1 つです。  このチュートリアルでは、このシナリオを例として使用しますが、プロジェクトの個別のニーズを解決する際にも活用できます。

***免責事項: ここでは、バージョン管理のソリューションとして Git を使用しています。  使用するソリューションが異なる場合は、説明されている概念を参考にしてください。***

サンプルのゲーム ***ScrapyardPhoenix*** のディレクトリが現在どのようになっているかを、確認のため以下に示します。

![ビルドの保存先フォルダー](images/build-destination.png)

また、UWP ディレクトリは次のようになっています。

![UWP VS ソリューション](images/uwp-vs-solution.png)

このディレクトリで、注目する必要があるのは ***ScrapyardPhoenix*** (お客様のゲームの名前をここに挿入) フォルダーのみです。  他の要素はバージョン管理ではすべて無視できます。

***.gitignore ファイルについて詳しくは、  「[gitignore](https://git-scm.com/docs/gitignore)」をご覧ください。***

    ##################################################################
    # The original .gitignore file can be found at
    # https://github.com/github/gitignore/blob/master/Unity.gitignore
    ##################################################################

    # standard ignores for a Unity Project
    ...

    # ignore the whole UWP directory
    /UWP/**

    # except we want to keep... (this line will be modified and removed further down)
    !/UWP/ScrapyardPhoenix/

ここでは、**UWP/ScrapyardPhoenix** フォルダー内のいくつかのファイルやフォルダーを選択してバージョン管理に追加します。  最初に、フォルダーの内容全体を詳しく見てみましょう。

![UWP ビルド ディレクトリ](images/uwp-build-directory.png)  

## フォルダー  

`Assets` | ***含める*** | Windows ストアの画像が格納されています  
`Data`   | ***無視*** | Unity でプロジェクト (シーン、シェーダー、スクリプト、プレハブなど) のコンパイル先となる場所です  
`Dependencies` | ***含める*** | このフォルダーは、UWP のすべての依存関係 (たとえば、XboxLiveSDK.dll) を格納するために作成したフォルダーです  
`Properties` | ***含める*** | 開発者が変更できる高度な設定が格納されています  
`Unprocessed` | ***無視*** | Unity の `.dll` ファイルと `.pdb` ファイルが格納されています  

## ファイル  

`App.cs` | ***含める*** | UWP アプリケーションのエントリ ポイントであり、他のソース ファイルを使って、変更、拡張することができます  
`Package.appxmanifest` | ***含める*** | AppX のパッケージ マニフェストです  
`project.json` | ***含める*** | `*.csproj` が依存する NuGet パッケージを記述します。  
`ScrapyardPhoenix.csproj` | ***含める*** | UWP ビルド ターゲットを記述します。新しい依存関係を UWP プロジェクトに追加した場合、この `*.csproj` ファイルにその情報が格納されます  
`ScrapyardPhoenix.csproj.user` | ***無視*** | このファイルにはローカル ユーザーの情報が格納されます

## 結果として得られる .gitignore

    ##################################################################
    # The original .gitignore file can be found at
    # https://github.com/github/gitignore/blob/master/Unity.gitignore
    ##################################################################

    # standard ignores for a Unity Project
    ...

    # ignore the whole UWP directory
    /UWP/**

    # except we want to keep...
    !/UWP/ScrapyardPhoenix/Assets/*
    !/UWP/ScrapyardPhoenix/Dependencies/*
    !/UWP/ScrapyardPhoenix/Properties/*
    !/UWP/ScrapyardPhoenix/App.cs
    !/UWP/ScrapyardPhoenix/Package.appxmanifest
    !/UWP/ScrapyardPhoenix/project.json
    !/UWP/ScrapyardPhoenix/ScrapyardPhoenix.csproj

これで、開発チームのメンバーは生成された最新の UWP プロジェクトを利用できるようになります。 新しいアセット、ソース、依存関係を、UWP プロジェクトに自由に追加できます。

UWP フォルダーのバージョン管理については、[これらの例](https://bitbucket.org/Unity-Technologies/windowsstoreappssamples/overview)もご覧ください。

## UWP アプリへの依存関係の追加

依存関係を **Plugins** フォルダーの下の **Unity Assets** フォルダーに置くことにより、DLL と WINMD に依存関係を追加します。次に Inspector でそれを選択し、ターゲット プラットフォーム設定を適切に設定します。

![UWP ソリューション](images/uwp-solution.PNG)

***ScrapyardPhoenix (ユニバーサル Windows)*** が、Xbox Live SDK などへの参照を追加する対象のプロジェクトです。

## 関連項目
- [既存のゲームの Xbox への移行](development-lanes-landing.md)
- [Xbox One の UWP](index.md)



<!--HONumber=Aug16_HO4-->


