//
//  main.swift
//  swift02
//
//  Created by 湯偉 on 15/11/8.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

//字符与字符串
/***********字符***********/
/*
1.赋值的字符必须用双引号包起来
2.特殊字符前需加上反斜杠
3.使用\u{n}用于表示Unicode形式,n代表1～8位十六进制数
4.每一个字符代表了一个可扩展字母集(未理解)
*/
var 笑 : Character = "😊"
var char1 = "\u{22}"
var char2 = "\'"
print("\(笑)\n\(char1)\n\(char2)")


/***********字符串***********/
//1.创建
//1.1.创建字符串
var str1 = "你好"
//1.2.使用构造器创建字符串
var str2 = String()
//1.3.创建多个重复字符的字符串
var str3 = String(repeating: "😄" , count: 5)
print("\(str1)\n\(str2)\n\(str3)")


//2.判断字符串是否为空,空返还true，非空返还false
//print("\(str2.isEmpty)\n\(str3.isEmpty)")


/*
3.字符串的拼接
通过“＋”或“＋＝”号拼接，也可以通过append函数进行拼接
append函数只能连接字符或者Unicode字符
*/
var str4 = str1 + " 汤 伟"
//print(str4)
str4 += str3
//print(str4)
let str5 : Character = "!"
str4.append(str5)
//print(str4)


/*
4.字符串长度
通过调用全局count函数(String.characters.count)，可以获取该字符串长度
*/
//print("str4长度是\(str4.characters.count)")


/*
5.字符串的比较
5.1.“＝＝”号表示字符串相等
*/
var str6 = "你好"
if (str1 == str6) {
    //print("str1和str6字符相同")
}

/*
5.2hasPrefix函数可进行字符串前缀判别，返还值是boolean值
5.3hasSuffix函数可进行字符串后缀判别，返还值是boolean值
*/
print("\(str4.hasPrefix("你"))\n\(str4.hasSuffix("!"))")
