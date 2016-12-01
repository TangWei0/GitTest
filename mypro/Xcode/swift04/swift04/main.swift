//
//  main.swift
//  swift04
//
//  Created by 湯偉 on 2015/11/23.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

/******数组和字典******/
/****数组****/
/*
数组的声明：第一种:Array<数据类型>
          第二种:[数据类型]
*/
var a = Array<String> ()//创建空数组
var b = Array<Int> (count: 3, repeatedValue: 1)
//print("\(a)\n\(b)")

var c : [Int] = [1 , 2 , 3]
print("\(c)")

//使用构造语法来创建一个由特定数据类型构成数组,多数使用第三种定义方法
var d = [Int] () //创建空数组
var e = [Double] (count: 5, repeatedValue: 1.0)
var f = ["apple" , "banana" , "orange" , "tomato" , "potato"]
//print("\(e)\n\(f[3])\n\(f.count)")

//数组中的类型不固定，那么该数组就是属于NSObject类型
var g = ["Eggs" , 100 , true]
for h in g {//for...in...语句中h默认是常量，不可以重新赋值
    //print("\(h)")
}

/**数组可变性**/
//1.append()方法在数组尾部添加新元素
f.append("suica")
print("\(f)")

//2.通过加法添加数组新元素
f += ["pineapple"]
//print("\(f)")

//3.数组内元素根据下标位置替换
//替换元素不足时，以空的形式进行替换，所以长度－1
f[0...2] =  ["a" , "b"]
//print("\(f)")

//4.根据索引值插入数据
f.insert("插入", atIndex: 0)
//print("\(f)")

//5.根据索引值删除数据
f.removeAtIndex(1)
//print("\(f)")

//6.删除最后一项数据
f.removeLast()
//print("\(f)")

//7.删除数组中所有数据,这里默认参数是false
f.removeAll(keepCapacity: false)
//print("\(f)")

/****字典(构造体)****/
/*
字典的声明 第一种:Dictionary<KeyType,valueType>
         第二种:[KeyType:valueType]
*/

//1.声明字典
var i : Dictionary <String , String>
var j : [String : Int]

//2.创建字典,创建字典时()不能少
i = Dictionary<String ,String>()
j = [String : Int](minimumCapacity: 5)
var k : [String : Int] = [ : ]//空字典
//print("\(k.isEmpty)")

//3.通过常量或变量决定字典是否可变
var l = ["age" : 30 , "name" : "Toui" , "height" : 170]
//print("\(l["age"]!)\n\(l["name"]!)\n\(l["height"]!)")//这里定义时，数据是需要强制解析的，否则系统无法正确判断数据类型
//print("\(l["weight"])")//key不存在时，返回nil

//可以更改任意key的value值，也可以添加一个不存在key以及的value值
l["name"] = "湯偉"
l["weight"] = 65
//print("\(l)")

//如果使用以下方法选取key的value值，上面定义的字典中的数据需变成字符串类型，输出时必须要强制解析
//var height : String? = l["height"]
//if height != nil {
//    print("\(height!)")
//}

//数据更新也可以使用updateValue(forKey :)，返回值是更新前的值，如果更新的key不存在时，会添加新key以及value值，但不返回值
if var oldname = l.updateValue("Toni", forKey: "name") {
    //print("\(oldname)")
}

if var score = l.updateValue(100, forKey: "Math") {
    print("\(score)")
}

//字典中for in语句的使用,这里的数据是可以不用强制解析的
for (key,value) in l {
    //print("\(key) \(value)")
}

//字典的删除，一种是和元组中removeAll()一样的删除，另一种是根据key删除value，参数函数是removeValueForKey("key的名称")
l.removeValueForKey("height")
print("\(l)")
l.removeAll(keepCapacity: false)
print("\(l)")

//字典中所有所有key成为一个数组，所有value成为一个数组的方法
var m = ["age" : "30" , "name" : "Toui" , "height" : "170"]
let keysArr = [String] (m.keys)
let valueArr = [String] (m.values)
print("\(keysArr)\n\(valueArr)")