//
//  main.swift
//  swift05
//
//  Created by 湯偉 on 2015/11/29.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

/******运算符******/
//1.判断运算符
var a = 3
var b = 4
//print(a == b ? "True" : "False")

//2.溢出运算符,数据运算超出取值范围，会报错。需添加溢出运算符 &+ &- &* &/
var c = UInt16.min
c = c &- 1
//print("\(c)")

//3.对浮点数求商和余数
//d是取余数，e是商数
var d = 100.truncatingRemainder(dividingBy: 2.3)
var e = 100 / 2.3
//print("\(d)\n\(e)")

//4.三目运算符(a ? b : c)
//1中已经有所使用，使用方法可参照上述命令

//5.空合并运算符(a ?? b)
/*
对a空判断，如果非空对a进行解封，如果非空执行b
表达式a必须是可选类型，b的默认类型必须要和a存储值的类型保持一致
*/
let f = "Hello"
var g : String?
let h = "Toui"
var i = g ?? f
var j = h
//print("\(i)\n\(j)")

//6.闭区间运算符 a...b 半开区间运算符 a..<b 意思是［a，b）
for k in 1...4 {
    //print("\(k)")
}
for k in 1..<4 {
    //print("\(k)")
}

/******流程控制******/
/****分支结构****/
//1.if else  同其他语言一样
//2.switch 语句中没有break
//3.fullthrough 贯穿语句(执行下一个case或者default语句)
var l = 5
var m = 0
switch l {
case 5 :
    m += l
    fallthrough
case 6:
    m += 10
default :
    m += 20
}
//print(m)

//4.case为元组条件以及值绑定条件
var point = (X : -6 , Y : -5)
switch point {
case (0,0):
    print("\(point.0,point.1)是原点")
case (_,0):
    print("\(point.0,point.1)在Y轴上")
case (0,_):
    print("\(point.0,point.1)在X轴上")
case (1..<Int.max , 1..<Int.max):
    print("\(point.0,point.1)在第一象限")
case var (x , y) where x < 0 && y < 0:
    print("(\(point.0,point.1))在第三象限")
default:
    break;
}

/****循环语句****/
//for语句
var s1 = 0
for x in 1..<5 {
    //1到4相加
    s1 += x
}
//print("\(s1)")

var s2 = 1
var s3 = 2
for _ in 1...5 {
    //1到5相乘
    s2 *= s3
}
//print("\(s2)")

for i in 1...5 {
    for j in 1...5 {
        if j == 3 {
            break //跳出j，继续执行i
        }
        else {
            print("(\(i)\(j))" , terminator : " ")
        }
    }
}
print("\n")
for i in 1...5 {
    for j in 1...5 {
        if j == 3 {
            continue//跳出j＝3，继续执行j
        }
        else {
            print("(\(i)\(j))" , terminator : " ")
        }
    }
}
print("\n")
out1: for i in 1...5 {
    for j in 1...5 {
        if j == 3 {
            break out1 //跳出i，执行后面程序
        }
        else {
            print("(\(i)\(j))" , terminator : " ")
        }
    }
}
print("\n")
out2: for i in 1...5 {
    for j in 1...5 {
        if j == 3 {
            continue out2 //跳出j，继续执行i
        }
        else {
            print("(\(i)\(j))" , terminator : " ")
        }
    }
}
print("\n")
