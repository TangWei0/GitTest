//
//  main.swift
//  swift07
//
//  Created by 湯偉 on 2015/12/04.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

/******嵌套函数******/
func getMathFunc1(type : String) -> (Int) -> Int {
    func squre (_ num : Int) -> Int {
        return num * num
    }
    func cube (_ num : Int) -> Int {
        return num * num * num
    }
    switch (type) {
    case "squre" :
        return squre
    default :
        return cube
    }
}
var mathFunc = getMathFunc1(type: "squre")
//print(mathFunc(5))

/******闭包******/
func getMathFunc2(type : String) -> (Int) -> Int {
    switch (type) {
    case "squre" :
        return { (num : Int) -> Int in
            return num * num
        }
    default :
        return { (num : Int) -> Int in
            return num * num * num
        }
    }
}
mathFunc = getMathFunc2(type: "cube")
//print(mathFunc(6))

//利用上下文，可简写闭包表达式
var squre1 : (Int) -> Int = {(num) in return num * num }
print(squre1(7))
var squre2 : (Int) -> Int = {num in return num * num}
print(squre2(8))
var squre3 : (Int) -> Int = {$0 * $0}
print(squre3(9))

var result : Int = {
    var result = 1
    for i in 1...$1 {
        result *= $0
    }
    return result
}(4,5)
print(result)

//尾随闭包
func getFunc (_ num : Int , fn : (Int) -> Int) {
    if (num == fn(5)) {
        print("good job")
    }
}
getFunc(25){$0 * $0}
