---
author: QuinnRadich Description: Windows 10 バージョン 1511 と開発者ツールの更新プログラムでは、引き続きユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスを提供しています。
title: Windows 10 の開発者向け新着情報 (バージョン 1511: 2015 年 11 月)
---

# Windows 10 の開発者向け新着情報 (バージョン 1511: 2015 年 11 月)

\[Windows 10 の UWP アプリ向けに更新。 Windows 8.x の記事については、[アーカイブ](http://go.microsoft.com/fwlink/p/?linkid=619132)をご覧ください\]

Windows 10 バージョン 1511 と開発者ツールの更新プログラムでは、引き続きユニバーサル Windows プラットフォームによって強化されたツール、機能、およびエクスペリエンスを提供しています。 Windows 10 バージョン 1511 用の[ツールと SDK をインストール](https://dev.windows.com/downloads)すると、[新しいユニバーサル Windows アプリを作成](https://msdn.microsoft.com/library/windows/apps/bg124288)したり、[Windows の既存のアプリ コード](https://msdn.microsoft.com/library/windows/apps/mt238321)がどのように使えるかを試したりすることができます。

## ユーザー エクスペリエンス

新しい <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.startscreen.aspx">Windows.UI.StartScreen.JumpList</a> クラスと <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.startscreen.aspx">Windows.UI.StartScreen.JumpListItem</a> クラスは、アプリで使用するシステム管理されたジャンプ リストの種類をプログラミングで選択したり、ジャンプ リストにカスタム タスク エントリ ポイントを追加したり、カスタム グループを追加したりできる機能を提供します。

## 入力
                                        
* <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.input.keyboarddeliveryinterceptor.aspx">キーボード デリバリー インターセプター</a>
                                        
    アプリでショートカット キーやアクセス キー (またはホット キー)、アクセラレータ キー、アプリケーション キーなどの、キーボードからの生の入力のシステム プロセスを上書きします。ただし、Secure Attention Sequence (SAS) キーの組み合わせは除きます。

    Ctrl + Alt + Del と Windows + L を含む Secure Attention Sequence (SAS) キーの組み合わせは引き続きシステムで処理されます。
                                        
* <a href="https://msdn.microsoft.com/library/windows/apps/windows.ui.core.corewindow.aspx">UWP アプリ</a>と<a href="https://msdn.microsoft.com/library/windows/desktop/hh454903(v=vs.85).aspx">従来の Windows アプリ</a>のポインター入力のチェーンはプロセスを超えて処理されます。
                                        
    プロセス間の入力チェーンを実現する新しいポインター イベント。    
                                        
* <a href="https://msdn.microsoft.com/library/windows/desktop/mt622165(v=vs.85).aspx">従来のデスクトップ アプリ用のインク プレゼンター</a>
                                        
    インク プレゼンター API では、アプリの <a href="https://msdn.microsoft.com/library/windows/desktop/hh437371(v=vs.85).aspx">DirectComposition</a> ビジュアル ツリーに挿入された <a href="https://msdn.microsoft.com/library/windows/desktop/windows.ui.input.inking.inkpresenter.aspx">InkPresenter</a> オブジェクトを通じて、入力、処理、インク入力 (標準と変更) の描画の Microsoft Win32 アプリによる管理を実現しています。    
                                    
## ネットワーク
                                                                        
WebSocket ユーザー向け: <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.streams.datawriter.flushasync.aspx">MessageWebSocket.OutputStream.FlushAsync</a> と <a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.streams.datawriter.flushasync.aspx">StreamWebSocket.OutputStream.FlushAsync</a> の実装がすべて完了し、後は以前に発行された WriteAsync 呼び出しの完了を待つのみとなりました。 これにより、<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.streams.datawriter.flushasync.aspx">FlushAsync</a> 呼び出し時に WebSocket が無効な状態にあると、既存のコードが例外をスローする場合があります。    

新しいプロパティ <a href="https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx">CookieUsageBehavior</a> が既存の <a href="https://msdn.microsoft.com/library/windows/apps/windows.web.http.filters.httpbaseprotocolfilter.aspx">Windows.Web.Http.Filters.HttpBaseProtocolFilter クラス</a>に追加されました。 これにより、開発者は、システムによる Cookie の処理方法を制御できるようになります。    
                                    
## ORTC
                                    
Microsoft Edge に実装された <a href="https://msdn.microsoft.com/library/mt433097(v=vs.85).aspx">ORTC (Object Real-Time Communications)</a> を使用すると、ネイティブ Javascript API を通じ、ブラウザー、モバイル デバイス、サーバーの間で直接、Web の音声通話とビデオ通話をリアルタイムで行うことができます。 開発者は ORTC API と、グループ ビデオ通話、サイマルキャスト、スケーラブル ビデオ コーディング (SVC) などのサポートを使用して、Microsoft Edge ブラウザー上に高度なリアルタイム音声/ビデオ コミュニケーション アプリケーションを構築することができるようになりました。    

ORTC API を使った Microsoft Edge ブラウザー間の 1 対 1 の音声/ビデオ通話のデモは、<a href="/microsoft-edge/testdrive/demos/ortcdemo/">テスト ドライブ サイトとデモ</a>をご覧ください。 概要とコード サンプル デモは <a href="https://msdn.microsoft.com/library/mt588497(v=vs.85).aspx">ORTC 開発者向けガイド エントリ</a>をご覧ください。
                                        
## Microsoft Edge F12 開発者ツール
                                                                        
Microsoft Edge の F12 開発者ツールでは、<a href="https://wpdev.uservoice.com/forums/257854-microsoft-edge-developer">UserVoice</a> で最も要望の多かったいくつかの機能を含む、新しい改善点が導入されています。 DOM Explorer、コンソール、デバッガー、ネットワーク、パフォーマンス、メモリ、エミュレーション、そして新しい試験的機能ツールでは、完成間近の強力な新機能を試すことができます。 新しいツールは TypeScript で構築されており、常に実行されているため、再読み込みは必要ありません。 さらに、F12 開発者ツールのドキュメントが <a href="http://dev.modern.ie/">Microsoft Edge デベロッパー サイト</a>の一部になり、<a href="https://github.com/MicrosoftEdge/MicrosoftEdge-Documentation">GitHub</a> でも閲覧できるようになりました。 今後、ドキュメントはみなさんのフィードバックによって進化するだけでなく、ドキュメントの構築そのものに参加してもらえるようになります。 F12 開発者ツールに関する短いビデオによる説明は <a href="https://channel9.msdn.com/Blogs/One-Dev-Minute/Microsoft-Edge-F12-tools">Channel9 の One Dev Minute</a> をご覧ください。    
                                    
## Windows Hello
                                    
Windows Hello は Windows システムやデバイスへの顔認証または指紋認証によるログインを実現します。

Providers API は、IHV と OEM によるコンピューター ビジョンの深度、赤外線、色のカラー カメラ (および関連するメタデータ) の UWP への取り込み、カメラによる Windows Hello の顔認証を実現します。 <a href="http://go.microsoft.com/fwlink/?LinkId=691697">Windows.Devices.Perception</a> 名前空間には、UWP アプリケーションからコンピューター ビジョン カメラの色、深度、赤外線データへのアクセスを実現するクライアント API が含まれています。
                                    
## 新しいゲーム API

新しい Windows.Gaming.UI.GameBar クラスを使うと、ゲーム バーを表示または非表示にした時に通知を受け取ることができます。    
                            
                                    
## Bluetooth API
                                    
複数の API が追加、更新され、Bluetooth LE、デバイス列挙、および Bluetooth のその他の機能のサポートが拡張されました。 <a href="https://msdn.microsoft.com/library/windows/apps/windows.devices.bluetooth.aspx">Windows.Devices.Bluetooth</a> 名前空間をご覧ください。    
                                   
## Smart Card API ## 

複数の SmartCardCryptogram API が <a href="https://msdn.microsoft.com/library/windows/apps/windows.devices.smartcards.aspx">Windows.Devices.SmartCards</a> 名前空間に追加され、セキュアな暗号文支払いプロトコルがサポートされるようになりました。 ホスト カード エミュレーションを使って「タップして支払い」をサポートする支払いアプリでは、これらの API を使ってセキュリティとパフォーマンスを強化できます。 アプリでキーを作成して、TPM を使って使用制限のあるトランザクション キーを保護します。 また、NGC (Next Generation Credentials) フレームワークを活用してユーザーの PIN のキーを保護します。 これらの API は暗号文の生成をシステムに委任することでパフォーマンスが向上します。 これにより、他のアプリからのキーと暗号文へのあらゆるアクセスを防止することができます。    
                                    
## Updated Storage API ## 
    
<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.downloadsfolder.aspx">Windows.Storage.DownloadsFolder クラス</a><br />
特定の<a href="https://msdn.microsoft.com/library/windows/apps/windows.system.user.aspx">ユーザー</a>のダウンロード フォルダーに<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.downloadsfolder.createfileforuserasync.aspx">ファイルを作成</a>したり、<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.downloadsfolder.createfolderforuserasync.aspx">フォルダーを作成</a>したりできるようになりました。
                                            
<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.storagelibrary.aspx">Windows.Storage.StorageLibrary クラス</a><br />
特定の<a href="https://msdn.microsoft.com/library/windows/apps/windows.system.user.aspx">ユーザー</a>の<a href="https://msdn.microsoft.com/library/windows/apps/windows.storage.storagelibrary.getlibraryforuserasync.aspx">特定のライブラリを取得</a>できるようになりました。
                                    
## Windows アプリ認定キット ## 
                                    
Windows アプリ認定キットが更新され、テストも改善されました。 更新のリストについては、<a href="/develop/app-certification-kit">Windows アプリ認定キット</a>のページをご覧ください。    
                                    
## デザインに関するダウンロード ## 

Adobe Photoshop 用の新しい UWP アプリ デザイン テンプレートをご覧ください。 Microsoft PowerPoint と Adobe Illustrator のテンプレートも更新され、ガイドラインの PDF 版も利用可能になりました。 <a href="/design/assets">デザインに関するダウンロードのページをご覧ください</a>。    




<!--HONumber=May16_HO2-->


