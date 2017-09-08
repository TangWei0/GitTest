//
//  main.swift
//  swift01
//
//  Created by 湯偉 on 15/11/8.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

// swift数据类型的定义
/*
以下所有print语句均不输出，如有需要可自行调用
调用方法将print语句前注释取消即可
*/

//变量与常量

//1.变量
//(1)变量直接赋值，系统自动识别变量数据类型
var str1 = "hello"
print(str1)

//变量可以重新赋值，但数据类型必须保持一致
str1 += " world"
print(str1)


//(2)自己定义变量数据类型
var str2 : String
//变量定义后，进行赋值，但赋值类型必须与定义的数据类型一致，赋值过的变量可以重新赋值但数据类型必须保持一致
str2 = "你好"
//print(str2)


//(3)自己定义变量的数据类型并且赋值
var age : Int = 0
//print(age)
//赋值过的变量可以重新赋值，但数据类型必须保持一致
age = 7
//print(age)


//(4)可赋值多个变量，可以任意使用上述(1)(2)(3)方法，每个变量之间用","号隔开
var a = "谢谢" , b : String , c : Int = 10
//print("a是 \(a)\nc是 \(c)")


//2.常量
//(1)常量直接赋值，赋值后不可以再次赋值
let name1 = "汤"
//print(name1)

//(2)可以定义常量数据类型后，再进行赋值，但赋值类型必须和定义数据类型一致，且只可以赋值一次
let name2 : String
name2 = "伟"
//print(name2)

//(3)自己定义数据类型并赋值，不可以再次赋值
let name3 : String = "汤 伟"
//print("我的名字叫 \(name3)")