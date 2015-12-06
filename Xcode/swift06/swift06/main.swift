//
//  main.swift
//  swift06
//
//  Created by 湯偉 on 2015/12/02.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

/******函数******/
//1.一个参数，一个返还值
func sayhello(name : String) -> String {
    return "Hello, " + name + "!"
}
//print(sayhello("toui"))

//2.2个参数，一个返还值
func add(a : Int , _ b : Int) -> Int {
    return a + b
}
//print(add(10,2))

//3.没有参数，一个返还值
func HelloWorld() -> String {
    return "HelloWorld"
}
//print(HelloWorld())

//4.外部参数引用，必须在虚参中定义一个外部参数名
func Area(长 width : Double , 高 height : Double) -> Double {
    return width * height
}
//print(Area(长: 3.0, 高: 4.5))

//5.外部参数名和内部参数名一致时，可在第一个参数名前添加第一个内部参数名
func Area1(width width : Double , height : Double , long : Double) -> Double {
    return width * height * long
}
//print(Area1(width: 1.4 , height: 2.4 , long: 4.3))

//6.可变参数，位于参数列表最后，并且只能有一个
func Sum (number : Int...) -> Int {
    var total : Int = 0
    for num in number {
        total += num
    }
    return total
}
//print(Sum(1 , 3 , 5 , 7 , 9))

//7.默认参数，内部参数名有赋值，外部参数缺失的情况，默认选取内部参数定义的值，如果不缺失，则调用外部参数值
//默认参数可以有多个，但必须在最后，如果最后有可变参数，则在倒数第二个
func Name (welcome : String , name : String = "toui" , s : Int = 9) {
    //print("\(name)" + "，\(welcome)\(String(s))")
}
Name("你好！")
Name("你好！" , name : "toni" , s: 5)

//8.变量参数，之前所有函数内部参数值都是常量，是不可变的，如果在定义内部参数值为变量，那么该值在函数内部是可变的，但不能用于函数外部
func factory (var number : Int) -> Int {
    var result = 1
    while(number > 0)
    {
        result *= number
        number--
    }
    return result
}
//print(factory(5))

//9.In-Out参数 强制调取值的指针？原理有待确认？
func swap (inout a : Int , inout b : Int) {
    let tmp = a
    a = b
    b = tmp
}
var a = 1 , b = 3
swap(&a , &b)
//print("a=\(a),b=\(b)")

//10.两个返回值
func st (weight : Double , height : Double) -> (Double , Double) {
    let s = weight * height
    let c = (weight + height) * 2
    return (s,c)
}
var c = st (2.3 , height : 3.1)
//print("\(c.0), \(c.1)")

//11.定义函数变量
var sum = add
//print("\(sum(2 , 3))")

//12.函数参数也可以是函数,在参数中定义一个变量函数，外部参数时直接调用函数名
func sum2 (mathfunc : (Int , Int) -> Int , a : Int , b : Int){
    //print("\(mathfunc(a, b))")
}
sum2(add, a: 5, b: 10)

//13.函数也可以作为返回值
func squr (num : Int) -> Int {
    return num * num
}
func cube (num : Int) -> Int {
    return num * num * num
}
func mathfunc (name name : String) -> Int -> Int {
    switch (name) {
    case "squr" :
        return squr
    default :
        return cube
    }
}
var math = mathfunc(name : "squr")
//print("\(math(9))")

//14.函数重载，只要参数列表或者返回值类型不同，函数名可以重名
func test () {
    print("test1")
}
func test (name : String) {
    print("test2,\(name)")
}
func test (name : String) -> String {
    print("test3,\(name)")
    return name
}
func test (name name : String) {
    print("test4,\(name)")
}
test()
var test2 : Void = test("toui")
var test3 : String = test("toui")
print(test3)
var test4 : Void = test(name : "toui")
