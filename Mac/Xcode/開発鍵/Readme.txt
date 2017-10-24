1.GitHubのzhaozx branch更新
→syncボタンを押す

2.Xcodeで開く
  ..\GitTest\Mac\Xcode\Hello World\Hello World.xcodeproj

3.下記p12ファイルをインストール(ダブルクリック)
  ..\GitTest\Mac\Xcode\開発鍵\dev_A8DQ46LJ3M_Tangweizhaozhixian1234.p12
  
  PW:Tangweizhaozhixian1234
  
4.mobileprovisionをインストール(ダブルクリック)
  ..\GitTest\Mac\Xcode\開発鍵\tangandzhao.mobileprovision
  
5.アカウント追加
  昨日教えたようです

6.General タブ配置確認
Bundle Identifier : com.project.tangandzhao

Team : プロジェクト 仕事(Personal Team)

確認方法
プロジェクトナビゲータで「Hello World」プロジェクトの「Hello World」ターゲットを選択しています。
→General タブが現れています。

7.インストール
Mac とiPhone をLightinning USB ケーブルで接続すると
Xcode のSchemaに「◯◯◯のiPhone」のように
実機を選択できるようになります
三角マークをクリック

8.手順7でCould not launch “Hello World”エラーメッセージを表示する場合、端末認証
「設定」→「一般」→「プロファイルとデバイス管理」
 共同開発メールIDを選択し、共同開発メールIDの信頼する
 
9.手順8終わったら、再インストール
  手順7参照