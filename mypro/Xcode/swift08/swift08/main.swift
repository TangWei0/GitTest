//
//  main.swift
//  swift08
//
//  Created by 湯偉 on 2015/12/09.
//  Copyright © 2015年 湯偉. All rights reserved.
//

import Foundation

/******枚举******/
//1.枚举的定义
enum senson {
    case spring
    case summer
    case fall
    case winter
}

// 或者
enum Senson {
    case spring , summer , fall , winter ,autm
}

//2.枚举声明
var day = senson.spring
//print("\(day)")

//3.枚举与swich语句
var Day = Senson.autm
switch Day {
case .spring :
    print("春天")
case .summer :
    print("夏天")
case .fall :
    print("秋天")
case .winter :
    print("冬天")
default :
    print("混合")
}

//4.获取原始值
enum week : Int {
    case mon = 1 , tur , wen , thu , fri , sat , sun
}
//print(week.Fri.rawValue)
//通过枚举值判断语句
var weekday = week.init(rawValue: 5)
if  weekday != nil {
    switch weekday! {
    case .mon , .tur , .wen , .thu , .fri :
        print("Work")
    default:
        print("休息")
    }
}

//5.关联值
enum Planet {
    case earth (Weight : Double , name : String)
    case mars (density : Double , name : String , weight : Double)
    case venus (Double , String)
    case sature
    case neptune
}
var p1 = Planet.earth(Weight: 1.0, name: "🌍")
var p2 = Planet.venus(0.815 , "金星")
var p3 = Planet.mars(density: 3.95 , name: "火星", weight: 0.1)
print("\(p3)")

switch p3 {
case Planet.earth (var weight , var name) :
    print("\(name)重量为：\(weight)")
case let Planet.mars (density , name , weight) :
    print("\(name)重量为：\(weight)，距离为：\(density)")
default:
    break
}
