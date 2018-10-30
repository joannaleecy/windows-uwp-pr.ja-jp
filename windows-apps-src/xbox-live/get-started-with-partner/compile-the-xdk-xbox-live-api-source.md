---
title: XDK の Xbox Live API のソースをコンパイルする
author: KevinAsgari
description: Xbox 開発キット (XDK) に付属する Xbox Live API のソースをコンパイルする方法について説明します。
ms.assetid: 78425e82-c132-4f6b-9db3-2536862f1ce5
ms.author: kevinasg
ms.date: 04/04/2017
ms.topic: article
keywords: Xbox Live, Xbox, ゲーム, UWP, Windows 10, Xbox One, XDK
ms.localizationpriority: medium
ms.openlocfilehash: 2b30453946536a5bebce7577fec04e0346c8ac97
ms.sourcegitcommit: 753e0a7160a88830d9908b446ef0907cc71c64e7
ms.translationtype: MT
ms.contentlocale: ja-JP
ms.lasthandoff: 10/30/2018
ms.locfileid: "5749311"
---
# <a name="compile-the-xbox-developer-kit-xdk-xbox-live-api-source"></a>Xbox 開発キット (XDK) に付属する Xbox Live API のソースをコンパイルする

Xbox 開発キット (XDK) には、Microsoft.Xbox.Services.dll (XSAPI) をビルドするためのソースが含まれています。 開発者は、次の手順を使用して、DLL のローカル ビルドを使用するようにプロジェクトを更新できます。

次のような場合、XSAPI を自分でビルドする必要があります。
1. 問題をデバッグしてエラーのあるコードの場所を特定する場合。
1. QFE が配布されるまでに、問題を解決するためのソース コード パッチを提供する場合。

## <a name="to-compile-the-xdk-c-xsapi-project-for-yourself"></a>XDK C++ XSAPI プロジェクトを自分でコンパイルするには

<ol>
  <li> Microsoft.Xbox.Services ソースを取得します。 これを行うには、すべてのファイルを抽出"%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox サービス API\8.0\SourceDist\Xbox.Services.zip"または"C:\Program Files (x86)"以外の書き込み可能なフォルダーにソースを複製できます<a href ="https://github.com/Microsoft/xbox-live-api">https://github.com/Microsoft/xbox-live-api</a></li>
  <li> プロジェクトがビルド済み DLL を参照している場合は、参照を削除する必要があります。</li>
    <ul>
      <li> Visual Studio 2012 の場合: Visual Studio で、[プロジェクト] の [参照...] を選択します。 Xbox Services API が参照として一覧に表示されている場合は、それを選択し、[参照の削除] をクリックします。 [OK] をクリックしてプロジェクト ファイルを保存します。</li>
      <li> Visual Studio 2015 または 2017 の場合: Visual Studio で、[プロジェクト] -> [参照の追加...] の順に 選択します。 Xbox Services API がオンになっている場合、オフにします。 [OK] をクリックしてプロジェクト ファイルを保存します。</li>
    </ul>
  <li> XDK でビルドする場合は、Visual Studio で、[ファイル] -> [追加] -> [既存のプロジェクト...] の順に選択して、 次の 2 つのプロジェクトをアプリケーションのソリューションに追加します。 vcxproj ファイルは、ソースの抽出先のフォルダーに配置されます。</li>
Visual Studio 2017 の場合: <ul>
      <li>\Build\Microsoft.Xbox.Services.141.XDK.Cpp\Microsoft.Xbox.Services.141.XDK.Cpp.vcxproj</li>   <li>\External\cpprestsdk\Release\src\build\vs15.xbox\casablanca141.Xbox.vcxproj</li>
    </ul>
Visual Studio 2015 の場合: <ul>
      <li>\Build\Microsoft.Xbox.Services.140.XDK.Cpp\Microsoft.Xbox.Services.140.XDK.Cpp.vcxproj</li> <li>\External\cpprestsdk\Release\src\build\vs14.xbox\casablanca140.Xbox.vcxproj</li>
    </ul>
Visual Studio 2012 の場合: <ul>
      <li>\Build\Microsoft.Xbox.Services.110.XDK.Cpp\Microsoft.Xbox.Services.110.XDK.Cpp.vcxproj</li> <li>\External\cpprestsdk\Release\src\build\vs11.xbox\casablanca110.Xbox.vcxproj</li>
    </ul>
    <li> ソース プロジェクトを参照として追加します。そのためには、[プロジェクト] -> [参照...] の順に選択し、[参照の追加] を選択します。 次に、[ソリューション] -> [プロジェクト] で、上記 2 つのプロジェクトのエントリをどちらもオンにして、[OK] をクリックします。</li>
    <li> props ファイルをプロジェクトに追加します。そのためには、[表示] -> [その他のウィンドウ] -> [プロパティ マネージャー] の順にクリックし、プロジェクトを右クリックして、[既存のプロパティ シートの追加] を選択してから、最後に SDK ソース ルートにある xsapi.staticlib.props を選択します。  ビルド システムが props ファイルをサポートしていない場合は、プリプロセッサの定義とライブラリを手動で追加する必要があります。詳しくは、%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox.Services.API.Cpp\8.0\DesignTime\CommonConfiguration\Neutral\Xbox.Services.API.Cpp.props をご覧ください。</li>
    <li> services.h ファイルをアプリのソースに追加します。そのためには、プロジェクトを右クリックし、[追加] -> [既存の項目] の順に移動して、{SDK ソース ルート}\Include\xsapi\services.h ファイルを選びます。</li>
    <li> "出力フォルダー" がアプリケーション プロジェクトと Xbox サービス プロジェクトで同じであることを確認します。 この設定は、Visual Studio プロジェクトの [プロパティ] -> [構成プロパティ] -> [全般] -> [出力ディレクトリ] で確認できます。</li>
    <li> Visual Studio ソリューションをリビルドします。</li>
</ol>

## <a name="to-compile-the-xdk-winrt-xsapi-project-for-yourself"></a>XDK WinRT XSAPI プロジェクトを自分でコンパイルするには

<ol>
  <li> Microsoft.Xbox.Services ソースを取得します。 これを行うには、すべてのファイルを抽出する"%XboxOneExtensionSDKLatest%\ExtensionSDKs\Xbox サービス API\8.0\SourceDist\Xbox.Services.zip"または"C:\Program Files (x86)"以外の書き込み可能なフォルダーにソースを複製できます<a href ="https://github.com/Microsoft/xbox-live-api">https://github.com/Microsoft/xbox-live-api</a></li>
  <li> プロジェクトがビルド済み DLL を参照している場合は、参照を削除する必要があります。</li>
    <ul>
      <li> Visual Studio 2012 の場合: Visual Studio で、[プロジェクト] の [参照...] を選択します。 Xbox Services API が参照として一覧に表示されている場合は、それを選択し、[参照の削除] をクリックします。 [OK] をクリックしてプロジェクト ファイルを保存します。</li>
      <li> Visual Studio 2015 または 2017 の場合: Visual Studio で、[プロジェクト] -> [参照の追加...] の順に 選択します。 Xbox Services API がオンになっている場合、オフにします。 [OK] をクリックしてプロジェクト ファイルを保存します。</li>
    </ul>
  <li> XDK でビルドする場合は、Visual Studio で、[ファイル] -> [追加] -> [既存のプロジェクト...] の順に選択して、 次の 2 つのプロジェクトをアプリケーションのソリューションに追加します。 vcxproj ファイルは、ソースの抽出先のフォルダーに配置されます。  Visual Studio 2015 の場合、プロジェクトは、VS2015 形式に自動的にアップグレードされます。</li>
    <ul>
      <li>\Build\Microsoft.Xbox.Services.110.XDK.WinRT\Microsoft.Xbox.Services.110.XDK.WinRT.vcxproj</li> <li>\External\cpprestsdk\Release\src\build\vs11.xbox\casablanca110.Xbox.vcxproj</li>
    </ul>
  <li> Visual Studio で参照を追加します。</li>
    <ul>
      <li> Visual Studio 2012 の場合: Visual Studio で、[プロジェクト] の [参照...] を選択し、[参照の追加] を選択します。 次に、[ソリューション] -> [プロジェクト] で、上記 2 つのプロジェクトのエントリをどちらもオンにして、[OK] をクリックします。</li>
      <li> Visual Studio 2015 または 2017 の場合: Visual Studio で、[プロジェクト] -> [参照の追加...] の順に 選択します。 次に、[プロジェクト] で、上記 2 つのプロジェクトのエントリをどちらもオンにして、[OK] をクリックします。</li>
    </ul>
  <li> "出力フォルダー" がアプリケーション プロジェクトと Xbox サービス プロジェクトで同じであることを確認します。 この設定は、Visual Studio プロジェクトの [プロパティ] -> [構成プロパティ] -> [全般] -> [出力ディレクトリ] で確認できます。</li>
  <li> Visual Studio ソリューションをリビルドします。</li>
</ol>
