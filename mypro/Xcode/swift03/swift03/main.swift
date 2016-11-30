//
//  main.swift
//  swift03
//
//  Created by 湯偉 on 2015/11/14.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

/***********数据类型***********/

/******整型******/
//整型：根据平台Int数据自动转换，所以一般情况下用Int就可以了，整数中下划线没有实际作用
let a = 1000000 , b = 1_000_000
if a==b {
    //print("下划线不起任何实际作用")
}
else {
    //print("下划线有作用")
}

//一般常用的2进制，8进制，16进制表示方法
//2进制前缀0b，8进制前缀0o，16进制前缀0x
let c = 0b10 , d = 0o10 , e = 0x10
//print("\(c)\n\(d)\n\(e)")

//整型类型不同是不可以进行运算的
var f : Int32 = 100 , g : Int16 = 60
//print("\(f + Int32(g))")

/******浮点型******/
//浮点型：Float和Double两种，用法和其他语言基本一致，不做过多解释
//0是可以作为除数存在，正数，0和负数除以0，分别得到inf(正无穷大)，nan(非数)和-inf(负无穷大)
//0作为除数，必须是浮点数类型，例如0.0才可以
var h = 4.0/0.0 , i = 0.0/0.0 , j = -3.8/0.0
//print("\(h)\n\(i)\n\(j)")

//浮点型数据转换，以及整数数据转换
var k : Float = 3.5 , l : Double = 4.9
//print("\(k * Float(l))\n\(Int(k) * Int(l))")

/******类型别名******/
//将某一数据类型，另起一个名字使用
typealias T16 = Int16
let m : T16 = 2
//print("\(m)")

/*******元组******/
/****元组定义***/
//元组用()表示，直接赋值或者先定义类型再赋值
var n = (178 , 70 , "male")
var o : (String , Int , Int)
o = ("汤伟",170,57)
//print("\(n)\n\(o)")
//print("\(o.0)\n\(n.2)")

//元组中可以嵌套元组
var p = (167 , (100 , 90, "good") , "bad")
//print("\(p.1.2)\n\(p.2)")

//通过key定义元组变量，赋值时key的顺序是没有要求的
var q = (Chinese : 90 , English : 90 , score : "S")
var r : (math : Int , English : Int , score : String)
r = (English : 80 , math : 90 ,score : "A")
//print("\(q.score)\n\(r.score)")

/******可选类型******/
/****可选类型****/
//任何已知数据类型后面紧跟？，即可代表可选类型
//例如将字符串转换成整型时即可用到可选数据，而转换结果为nil，表示值缺失
var s = "Hello,World!"
var t : Int? = Int(s)
//print("\(t)")

/****强制解析****/
//在可选类型变量或者常量后面添加 ！ ，前提：常量或者变量确实有值时才可以解析成功
var u : Int? = 10
var v : Int? = 20
if u != nil && v != nil {
    let w = u! + v!
    //print("\(w)")
}
else {
    print("数值为nil，不能强制解析")
}

/****可选绑定****/
//可以用在if或者while语句中，来对可选类型的值进行判断，并把值为给一个常量或者变量
var x : String? = "Hello,Swift"
if var y : String = x! {
    print("x的值为：\(y)")
}
else {
    print("x的值为nil，不能解析")
}

//隐式解析可选类型；在已有类型后面添加！，适用于被赋值之后不会重新变为nil的变量
//可以直接解析，不需要可选类型转换后再进行强制解析
var z : String! = "Toui"
//print("\(z)")
