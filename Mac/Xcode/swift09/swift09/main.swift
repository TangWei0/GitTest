//
//  main.swift
//  swift09
//
//  Created by 湯偉 on 2015/12/10.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

//1.类的定义
class Person {
    var name : String = "Jack"
    var age : Int = 19
    func say (dialog : String) {
        print("Hello,\(name)!\(dialog)")
    }
}

//2.结构体定义
struct Dog {
    var name : String
    var age : Int
    func run() {
        print("\(name) is runing")
    }
}

//3.类的创建
var p : Person
p = Person()//或者两句并一句，var p ＝ Person（）
print(p.name)
p.say("Hello")

//4.构造体的创建
var dog = Dog(name: "旺财", age: 2)
print(dog.name)
dog.run()

//5.值类型与引用类型区别，类是引用类型，结构体和枚举是值类型
var p2 = p
p2.name = "Rose"
print("\(p.name)  \(p2.name)")

var dog2 = dog
dog2.name = "小强"
print("\(dog.name)  \(dog2.name)")

//6引用对象的判断
class User {
    var name : String
    var age : Int
    init (name : String , age : Int) {
        self.name = name
        self.age = age
    }
}
var user1 = User(name: "A", age: 18)
var user2 = User(name: "A", age: 18)
print(user1 === user2)//判断引用对象是否一致，值是false
var user3 = user1
print(user1 === user3)
